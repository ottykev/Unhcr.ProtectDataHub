$(function () {
    var l = abp.localization.getResource('ProtectDataHub');
    var createModal = new abp.ModalManager(abp.appPath + 'Regions/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Regions/EditModal');

    var dataTable = $('#RegionsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            processing: true,
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            ajax: abp.libs.datatables.createAjax(unhcr.protectDataHub.regions.region.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('RegionDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        unhcr.protectDataHub.regions.region
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
                    title: l('RegionName'),
                    data: "name"
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
    $('#NewRegionButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});