$(document).ready(function () {
    $("#txtScheduleDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $(".time_input").timepicker({ timeFormat: "hh:mm:ss TT" });
    $('#tblWorkGroupSchedule').appendGrid({
        caption: 'Employee WorkGroup Schedule',
        initRows: 0,
        columns: [
                 {name: 'txtWGOperationMasterCode', type: 'hidden' },
                { name: 'txtWorkGroupCode', type: 'hidden' },
                { name: 'txtWorkGroupName', display: 'Work Group Name', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
            { name: 'txtWorkGroupStrength', display: 'Worker Strength', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center' } },
            { name: 'DutyStartFrom', display: 'Start From', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center' } },

                { name: 'txtDutyStartFrom', display: 'Duty Start From', ctrlClass: 'time_input', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'time', ctrlAttr: {}, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDutyHour', display: 'Duty Hour', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: {}, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtOvertimeLimit', display: 'Overtime Limit', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: {}, ctrlClass: 'required', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} },
                {name: 'ddlIsAttendanceProcessed', type: 'select', display: 'Attn. Prc. Status', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlAttr: { 'disabled': 'disabled' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Yet Processed', 1: 'Processed'} },
                { name: 'ddlOperationalStatus', type: 'select', display: 'Op. Status', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlAttr: {}, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Yet Scheduled', 1: 'On', 2: 'Off', 3: 'Holiday Off', 4: 'Weekend Off', 5: 'Scheduled Off', 6: 'Duty On Holiday', 7: 'Shift Change Duty', 8: 'Shift Change Off'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        customRowButtons: [
            {
                uiButton: { icons: { primary: 'ui-icon-disk' }, text: false },
                click: function (evtObj, uniqueIndex, rowData) {
                    var lcl_str_WGOperationMasterCode = rowData["txtWGOperationMasterCode"];
                    if (lcl_str_WGOperationMasterCode == 0) {
                        DisplayError("WorkGroup Has Not Yet Been Configured!!!Edit/Update Denied!!!");
                        return;
                    }

                    
                    var timeValue = rowData["txtDutyStartFrom"];  // "09:00" from input
                    var lcl_str_StartTime = formatTimeForOracle(timeValue);

                    var lcl_obj_WorkGroupOperationMasterProfile = new Object();
                    lcl_obj_WorkGroupOperationMasterProfile.WorkGroupOperationMasterCode = lcl_str_WGOperationMasterCode;
                    var lcl_str_StartTime = lcl_str_StartTime;
                    lcl_obj_WorkGroupOperationMasterProfile.DutyFrom = lcl_str_StartTime;
                    lcl_obj_WorkGroupOperationMasterProfile.DutyHour = rowData["txtDutyHour"];
                    lcl_obj_WorkGroupOperationMasterProfile.OvertimeLimit = rowData["txtOvertimeLimit"];
                    lcl_obj_WorkGroupOperationMasterProfile.IsAttendanceProcessed = rowData["ddlIsAttendanceProcessed"];
                    lcl_obj_WorkGroupOperationMasterProfile.OperationalStatus = rowData["ddlOperationalStatus"];
                    /***************************************************************************************************/
                    //Validate Time Format
                    var lcl_str_TimeFormatRegEx = "/^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/";
                    if (lcl_str_StartTime.match(lcl_str_TimeFormatRegEx)) {
                        //alert("Match");
                    }
                    else {
                        //alert("Mis Match");
                    }
                    /***************************************************************************************************/


                    var lcl_str_AttendanceCode = rowData["txtAttendanceCode"];
                    var lcl_str_ManualOvertimeAdjustment = rowData["txtRemarks"];
                    var lcl_str_Remarks = rowData["txtRemarks"];
                    var lcl_str_Status = rowData["ddlAttendanceStatus"];
                    var options = {};
                    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/UpdateWorkGroupOperationMaster";
                    options.dataType = "json";
                    options.type = "POST";
                    options.data = "{IP_obj_WorkGroupOperationMasterProfile: " + JSON.stringify(lcl_obj_WorkGroupOperationMasterProfile) + "}"; // JSON.stringify(lcl_obj_LogFile);
                    options.contentType = "application/json; charset=utf-8";
                    options.success = function (result) {
                        var lcl_obj_WSResponse = result.d;
                        if (lcl_obj_WSResponse.ResponseCode == -1) {
                            DisplayError(lcl_obj_WSResponse.Message);
                            return;
                        }
                        if (lcl_obj_WSResponse.ResponseCode == 0) {
                            DisplaySuccess(lcl_obj_WSResponse.Message);
                        }
                    };

                    options.error = function (err) { DisplayError(err.statusText); };

                    $.ajax(options);
                }, btnCss: { 'min-width': '20px' },
                btnAttr: { title: 'Update WorkGroup Master' }, atTheFront: true
            }
        ],
        rowDataLoaded: function (caller, record, rowIndex, uniqueIndex) {
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

function formatTimeForOracle(timeValue) {
    if (!timeValue) return "";

    var parts = timeValue.split(':');
    var hour = parseInt(parts[0], 10);
    var minute = parts[1];

    var ampm = hour >= 12 ? "PM" : "AM";
    hour = hour % 12;
    hour = hour === 0 ? 12 : hour;

    var hourStr = hour < 10 ? "0" + hour : "" + hour;

    return hourStr + ":" + minute + ":00 " + ampm;
}

function GetWorkGroupSchedule(event) {
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    var lcl_dt_ScheduleDate = $('#txtScheduleDate').val();
    if (lcl_dt_ScheduleDate == '') {
        DisplayError("Please Select Date!");
        return;
    }
   
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/GetWorkGroupSchedule";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_Date: '" + lcl_dt_ScheduleDate + "'}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            var WorkGroupScheduleList = lcl_obj_WSResponse.Data;
            DisplayEmployeeWorkGroupSchedule(WorkGroupScheduleList);
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}

function DisplayEmployeeWorkGroupSchedule(WorkGroupScheduleList) {
    var lcl_objLst_WorkGroupSchedule = new Array();
    $.each(WorkGroupScheduleList, function (index, WorkGroupSchedule) {
        lcl_objLst_WorkGroupSchedule[index] = new Object();

        lcl_objLst_WorkGroupSchedule[index].txtWGOperationMasterCode = WorkGroupSchedule.WorkGroupOperationMasterCode;
        lcl_objLst_WorkGroupSchedule[index].txtWorkGroupCode = WorkGroupSchedule.WorkGroupCode;
        lcl_objLst_WorkGroupSchedule[index].txtWorkGroupName = WorkGroupSchedule.WorkGroupName;
        lcl_objLst_WorkGroupSchedule[index].txtWorkGroupStrength = WorkGroupSchedule.WorkerStrength; 
        lcl_objLst_WorkGroupSchedule[index].DutyStartFrom = WorkGroupSchedule.DutyFrom;
        lcl_objLst_WorkGroupSchedule[index].txtDutyStartFrom = WorkGroupSchedule.DutyFrom;
        lcl_objLst_WorkGroupSchedule[index].txtDutyHour = WorkGroupSchedule.DutyHour;
        lcl_objLst_WorkGroupSchedule[index].txtOvertimeLimit = WorkGroupSchedule.OvertimeLimit;
        lcl_objLst_WorkGroupSchedule[index].ddlIsAttendanceProcessed = WorkGroupSchedule.IsAttendanceProcessed;
        lcl_objLst_WorkGroupSchedule[index].ddlOperationalStatus = WorkGroupSchedule.OperationalStatus;
    });

    $('#tblWorkGroupSchedule').appendGrid('load', lcl_objLst_WorkGroupSchedule);
}