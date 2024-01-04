$(function () {
    var l = abp.localization.getResource('ProtectDataHub');
    var createModal = new abp.ModalManager(abp.appPath + 'Countries/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Countries/EditModal'); 

    var dataTable = $('#CountriesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(unhcr.protectDataHub.countries.country.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ProtectDataHub.Countries.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ProtectDataHub.Countries.Delete'),
                                    confirmMessage: function (data) {
                                        return l('PersonDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        unhcr.protectDataHub.persons.person
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Code'),
                    data: "code"
                },
                {
                    title: l('Region'),
                    data: "regionName"
                },
                {
                    title: l('ClustureStructure'),
                    data: "clusterStructure",
                    render: function (data) {
                        return l('Enum:Cluster.' + data);
                    }
                }
            ]
        })
    );
    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewCountryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
