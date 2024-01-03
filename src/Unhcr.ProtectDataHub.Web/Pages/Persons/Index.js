$(function () {
    var l = abp.localization.getResource('ProtectDataHub');
    var createModal = new abp.ModalManager(abp.appPath + 'Persons/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Persons/EditModal');

    var DataTable = $('#PersonsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(unhcr.protectDataHub.persons.person.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('ProtectDataHub.Persons.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('ProtectDataHub.Persons.Delete'),
                                    confirmMessage: function (data) {
                                        return l('PersonDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        unhcr.globalDataHub.persons.person
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
                    title: l('FullName'),
                    data: "fullName"
                },
                {
                    title: l('Email'),
                    data: "email"
                },
                {
                    title: l('PhoneNumber'),
                    data: "phoneName"
                },
                {
                    title: l('Country'),
                    data: "countryName"
                },
                {
                    title: l('AOR'),
                    data: "aor",
                    render: function (data) {
                        return l('Enum:ClusterAor.' + data);
                    }
                },
                {
                    title: l('LevelofCordination'),
                    data: "levelOfCordination",
                    render: function (data) {
                        return l('Enum:Cordination.' + data);
                    }
                },
                {
                    title: l('DutyStation'),
                    data: "dutyStation"
                },
                {
                    title: l('WorkingFromDutyStation'),
                    data: "workingFromDutyStation",
                    render: function (data) {
                        return data ? l('Yes') : l('No');
                    }
                },
                {
                    title: l('Organization Type'),
                    data: "typeOrganization",
                    render: function (data) {
                        return l('Enum:OrgType.' + data);
                    }
                },
                {
                    title: l('Organization Name'),
                    data: "organizationName"
                },
                {
                    title: l('Position'),
                    data: "position",
                    render: function (data) {
                        return l('Enum:Position.' + data);
                    }
                },
                {
                    title: l('Staff%'),
                    data: "staff",
                    render: function (data) {
                        return l('Enum:StaffLevel.' + data);
                    }
                },
                {
                    title: l('Double Hatting %'),
                    data: "doubleHattingLevel",
                    render: function (data) {
                        return l('Enum:DoubleHattingLevel.' + data);
                    }
                },
                {
                    title: l('StaffGrade'),
                    data: "staffGrade",
                    render: function (data) {
                        return l('Enum:StaffGrade.' + data);
                    }
                },
                {
                    title: l('Contract Type'),
                    data: "contractType",
                    render: function (data) {
                        return l('Enum:ContractType.' + data);
                    }
                },
                {
                    title: l('StartDate'),
                    data: "startDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('EndDate'),
                    data: "endDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('IsActive'),
                    data: "isActive",
                    render: function (data) {
                        return data ? l('Yes') : l('No');
                    }
                },
            ]
        })
    );
    var createModal = new abp.ModalManager(abp.appPath + 'Persons/CreateModal');
    createModal.onResult(function () { DataTable.ajax.reload(); });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });
    $('#NewPersonButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});