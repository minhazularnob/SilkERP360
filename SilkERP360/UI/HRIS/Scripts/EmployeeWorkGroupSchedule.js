$(document).ready(function () {
    $("#txtScheduleDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $('#tblWorkGroupSchedule').appendGrid({
        caption: 'Employee WorkGroup Schedule',
        initRows: 0,
        columns: [
                {name: 'txtWGOperationMasterCode', type: 'hidden' },
                { name: 'txtEmployeeCode', type: 'hidden' },
                { name: 'txtEmployeeId', display: 'Emp. Id', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtEmplpoeeName', display: 'Emp. Name', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDesignation', display: 'Designation.', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDepartment', display: 'Department.', displayCss: { 'text-align': 'center', 'width': '15%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtWorkGroupName', display: 'Work Group', displayCss: { 'text-align': 'center', 'width': '15%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDutyScheduleFrom', display: 'Duty Schedule From', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDutyScheduleUpto', display: 'Duty Schedule Upto', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        rowDataLoaded: function (caller, record, rowIndex, uniqueIndex) {
            alert("DATA LOADED");
            var lcl_str_WGMasterCode = record["txtWGOperationMasterCode"];
            var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', rowIndex);
            if (lcl_str_WGMasterCode == "0") {
                //RED
                $(lcl_ctrl_EmployeeId).css('background-color', '#FF4C4C');
            }
            else {
                //GREEN
                $(lcl_ctrl_EmployeeId).css('background-color', '#67FF4C');
            }
        },
        hideButtons: {
            append: true,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: true,
            removeLast: true
        },
        hideRowNumColumn: false
    });
});

function GetEmployeeSchedule(event) {
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    var lcl_dt_ScheduleDate = $('#txtScheduleDate').val();
    if (lcl_dt_ScheduleDate == '') {
        DisplayError("Please Select Date!");
        return;
    }

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/GetEmployeeWorkGroupScheduleByDate";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_Date: '" + lcl_dt_ScheduleDate + "'}";
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            var EmployeeWorkGroupScheduleList = lcl_obj_WSResponse.Data;
            DisplayEmployeeWorkGroupSchedule(EmployeeWorkGroupScheduleList);
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}

function DisplayEmployeeWorkGroupSchedule(EmployeeWorkGroupScheduleList) {
    var lcl_objLst_EmployeeWorkGroupSchedule = new Array();
    $.each(EmployeeWorkGroupScheduleList, function (index, EmployeeWorkGroupSchedule) {
        lcl_objLst_EmployeeWorkGroupSchedule[index] = new Object();
        var lcl_str_DutyScheduleFrom = moment(new Date(parseInt(EmployeeWorkGroupSchedule.DutyScheduleFrom.substr(6)))).format('DD.MM.YY h:mm A');
        if (lcl_str_DutyScheduleFrom == "01.01.01 6:00 AM") {
            lcl_str_DutyScheduleFrom = "";
        }
        var lcl_str_DutyScheduleUpto = moment(new Date(parseInt(EmployeeWorkGroupSchedule.DutyScheduleUpto.substr(6)))).format('DD.MM.YY h:mm A');
        if (lcl_str_DutyScheduleUpto == "01.01.01 6:00 AM") {
            lcl_str_DutyScheduleUpto = "";
        }

        lcl_objLst_EmployeeWorkGroupSchedule[index].txtWGOperationMasterCode = EmployeeWorkGroupSchedule.WorkGroupOperationMasterCode;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtEmployeeCode = EmployeeWorkGroupSchedule.EmployeeCode;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtEmployeeId = EmployeeWorkGroupSchedule.EmployeeId;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtEmplpoeeName = EmployeeWorkGroupSchedule.EmployeeName;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtDesignation = EmployeeWorkGroupSchedule.Designation;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtDepartment = EmployeeWorkGroupSchedule.Department;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtWorkGroupName = EmployeeWorkGroupSchedule.WorkGroupName;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtDutyScheduleFrom = lcl_str_DutyScheduleFrom;
        lcl_objLst_EmployeeWorkGroupSchedule[index].txtDutyScheduleUpto = lcl_str_DutyScheduleUpto;

        if (lcl_objLst_EmployeeWorkGroupSchedule[index].txtWorkGroupName == "") {
            lcl_objLst_EmployeeWorkGroupSchedule[index].txtWorkGroupName = "WorkGroup Not Assigned";
        }
    });

    $('#tblWorkGroupSchedule').appendGrid('load', lcl_objLst_EmployeeWorkGroupSchedule);
}