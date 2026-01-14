$(document).ready(function () {

    LoadAllDepartment();
   
    GBL_DEPARTMENT_LIST_TABLE = $('#tblDepartmentList').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Department Data Available",
            "sZeroRecords": "No DEpartment Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { sTitle: 'Dept. Code', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: 'Company Code', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: 'Dept. Name', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: 'Short Name', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: 'Head Of Dept.', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: 'Is Rosterable', sWidth: '10%', sClass: 'alignCenter' },
            {
                sTitle: 'Action',
                sWidth: '10%',
                sClass: 'alignCenter',
                mRender: function (data, type, full) {
                    return `
                    <button type="button" class="btn btn-sm btn-primary edit-btn" data-companycode="${full[0]}">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button type="button" class="btn btn-sm btn-danger delete-btn ms-1" data-companycode="${full[0]}">
                        <i class="fas fa-trash"></i>
                    </button>`;
                }
            },
            { sTitle: 'Department Head Id', sWidth: '10%', sClass: 'alignCenter', bVisible: false },

        ]

    });
    initializeSelect2('departmentHeadId', 'Select Head of Department', '94%');
    initializeSelect2('isRosterable', '', '94%');
    getAllEmployees();
});

function LoadAllDepartment() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/GetAllDepartment",
            data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_DepartmentList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_DepartmentCode = 0;

                GBL_DEPARTMENT_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllDepartmentData = new Array();

                $.each(lcl_obj_DepartmentList, function (index, lcl_obj_ExtendedAllDepartmentData) {
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode] = new Array();
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][0] = lcl_obj_ExtendedAllDepartmentData.DepartmentCode;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][1] = lcl_obj_ExtendedAllDepartmentData.CompanyCode;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][2] = lcl_obj_ExtendedAllDepartmentData.DeptName
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][3] = lcl_obj_ExtendedAllDepartmentData.ShortName;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][4] = lcl_obj_ExtendedAllDepartmentData.DeptHeadName;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][5] = lcl_obj_ExtendedAllDepartmentData.IsRosterable ? "Yes" : "No";
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][6] = '<button class="btn btn-sm btn-primary edit-btn" id="editId_' + lcl_i32_DepartmentCode + '">Edit</button>';
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][7] = lcl_obj_ExtendedAllDepartmentData.HeadEmployeeId;

                    lcl_i32_DepartmentCode++;
                });
                GBL_DEPARTMENT_LIST_TABLE.fnAddData(lcl_str_ExtendedAllDepartmentData);
                GBL_DEPARTMENT_LIST_TABLE.fnDraw();
            }
        });
}

function Save() {
    var lcl_obj_Department = new Object();

    lcl_obj_Department.DeptName = $("#txt_DeptName").val();
    lcl_obj_Department.ShortName = $("#txt_DeptShortName").val();
    lcl_obj_Department.CompanyCode = parseInt($('#ddlCompany').val());
    lcl_obj_Department.HeadEmployeeId = $("#departmentHeadId").val();
    lcl_obj_Department.IsRosterable = $("#isRosterable").val() == "True" ? 1 : 0;

    var validateObj = {
        DeptName: lcl_obj_Department.DeptName
    };

    var validationMessage = validateFields(validateObj);
    if (validationMessage !== 'OK') {
        DisplayError(validationMessage.toString());
        return false;
    }

    if (confirm("Are you sure you want to save this department?") === true) {
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/SaveDepartment",
            data: "{IP_Obj_Department:" + JSON.stringify(lcl_obj_Department) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode === 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllDepartment();
                    closeModal();
                    clearFields();
                    return false;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
                alert(data);
            }
        });
    }
    return false;
}

function UpdateDept() {
    var lcl_obj_Department = new Object();
    lcl_obj_Department.DepartmentCode = $("#deptCode").val();
    lcl_obj_Department.DeptName = $("#deptName").val();
    lcl_obj_Department.ShortName = $("#deptShortName").val();
    lcl_obj_Department.CompanyCode = $("#deptCompanyCode").val();
    lcl_obj_Department.HeadEmployeeId = $("#deptHeadModal").val();
    lcl_obj_Department.IsRosterable = $("#deptIsRosterableModal").val();
    lcl_obj_Department.Status = $("#deptStatus").val();

    var validateObj = {
        DeptName: lcl_obj_Department.DeptName,
        CompanyCode: lcl_obj_Department.CompanyCode
    };

    var validationMessage = validateFields(validateObj);
    if (validationMessage !== 'OK') {
        DisplayError(validationMessage.toString());
        return false;
    }

    if (confirm("Are you sure you want to save this department?") === true) {
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/UpdateDepartment",
            data: "{IP_Obj_Department:" + JSON.stringify(lcl_obj_Department) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode === 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllDepartment();
                    closeModal();
                    clearModalFields('departmentModal');
                    return false;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
                alert(data);
            }
        });
    }
    return false;
}

function DeleteDepartment(departmentCode) {
    if (confirm("Are you sure you want to Delete this data?") == true) {
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/DeleteDepartment",
            data: "{IP_Ui64_DepartmentCode: " + JSON.stringify(departmentCode) + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadAllDepartment();
                    return false;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
                alert(data);
            }
        });
        return false;
    }
}

$('#tblDepartmentList').on('click', '.edit-btn', function () {
    var row = $(this).closest('tr')[0];
    var rowData = GBL_DEPARTMENT_LIST_TABLE.fnGetData(row);

    $('#deptCode').val(rowData[0]);
    $('#deptName').val(rowData[2]);

    $('#deptShortName').val(rowData[3]);


    initializeSelect2('deptCompanyCode', '', '95%', '#departmentModal');
    initializeSelect2('deptHeadModal', 'Select Department Head', '95%', '#departmentModal');
    initializeSelect2('deptStatus', '', '95%', '#departmentModal');
    initializeSelect2('deptIsRosterableModal', '', '95%', '#departmentModal');

    var companies = [];
    companies = getAllCompany();

    $.each(companies, function (index, company) {
        var $option = $('<option></option>').val(company.CompanyCode).text(company.Name);

        if (company.CompanyCode === rowData[1]) {
            $option.prop('selected', true);
        }
        $('#deptCompanyCode').append($option);
    });


    var employees = [];
    employees = getAllEmployee(rowData[1]);

    $.each(employees, function (index, employee) {
        var $option = $('<option></option>').val(employee.EmployeeId).text(employee.EmployeeName + " [" + employee.DesignationName + "]" + " [" + employee.EmployeeId + "]");
        if (employee.EmployeeId === rowData[7]) {
            $option.prop('selected', true);
        }
        $('#deptHeadModal').append($option);
    });

    $('#departmentModal').modal('show');
});

$('#tblDepartmentList').on('click', '.delete-btn', function () {
    var row = $(this).closest('tr')[0];
    var rowData = GBL_DEPARTMENT_LIST_TABLE.fnGetData(row);

    let departmentCode = rowData[0];
    DeleteDepartment(departmentCode);
});

function getAllEmployees() {
    employees = getAllEmployee($('#ddlCompany').val());
    $.each(employees, function (index, employee) {
        var $option = $('<option></option>').val(employee.EmployeeId).text(employee.EmployeeName + " [" + employee.DesignationName + "]" + " [" + employee.EmployeeId + "]");
        $('#departmentHeadId').append($option);
    });

}

function clearFields() {
    $('#departmentWrapper').find('input[type="text"], textarea').val('');
    $('#departmentHeadId').val(null).trigger('change');
    $('#isRosterable').val(true).trigger('change');
}

function closeModal() {
    $('#departmentModal').modal('hide');
}

$(document).ready(function () {
    $('#departmentModal').on('shown.bs.modal', function () {
        $('#deptCompanyCode, #deptHeadModal, #deptStatus, #deptIsRosterableModal').select2({
            dropdownParent: $('#departmentModal')
        });
    });
});