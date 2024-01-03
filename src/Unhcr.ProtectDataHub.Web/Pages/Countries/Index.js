$(function () {
    var l = abp.localization.getResource('ProtectDataHub');
    var createModal = new abp.ModalManager(abp.appPath + 'Countries/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Countries/EditModal');

    var DataTable = $('#CountriesTable').DataTable(
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
                                        return l('CountryDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        unhcr.protectDataHub.countries.country
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
                    title: l('IsoCode'),
                    data: "isoCode"
                },
                {
                    title: l('Region'),
                    data: "regionName"
                },
                {
                    title: l('ClusterStructure'),
                    data: "clusterStructure",
                    render: function (data) {
                        return l('Enum:Cluster.' + data);
                    }
                }
            ]
        })
    );
    var createModal = new abp.ModalManager(abp.appPath + 'Countries/CreateModal');
    createModal.onResult(function () { DataTable.ajax.reload(); });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewCountryButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});