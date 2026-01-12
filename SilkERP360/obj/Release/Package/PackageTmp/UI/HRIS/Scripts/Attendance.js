var GBLAttendanceMaster;
var EDIT_AUTHORIZATION_CODE = "apwsyrzftm";
$(document).ready(function () {
    $("#txtAttendanceDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    $('#tblAttendance').appendGrid({
        caption: 'Attendance Details',
        initRows: 1,
        columns: [
                {
                name: 'chkSelect', display: '', type: 'checkbox', displayCss: { 'text-align': 'center', 'width': '1%' },
                    ctrlCss: { 'margin': 'auto', 'text-align': 'center' },
                    value: false
                },
                 {name: 'txtAttendanceCode', type: 'hidden' },
                { name: 'txtEmployeeCode', type: 'hidden' },
                { name: 'txtEmployeeId', display: 'Emp. Id', displayCss: { 'text-align': 'center', 'width': '8%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtEmplpoeeName', display: 'Emp. Name', displayCss: { 'text-align': 'center', 'width': '15%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDesignation', display: 'Desig.', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtInTime', display: 'In Time', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtInThrough', display: 'In Through', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtOutTime', display: 'Out Time', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtOutThrough', display: 'Out Through', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDutyMinute', display: 'D.HR', displayTooltip: 'Duty Hour', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtOvertimeAuto', display: 'O.T (A)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtOvertimeManual', display: 'O.T (M)', displayTooltip: '', displayCss: { 'width': '4%' }, type: 'text', ctrlAttr: {}, ctrlCss: { width: '100%', 'text-align': 'center' },
                    onChange: function (evt, rowIndex) {
                        if (confirm("Are You Sure You want to manually adjust the 'Overtime' for " + $('#tblAttendance').appendGrid('getCtrlValue', 'txtEmplpoeeName', rowIndex) + " ?")) {
                            var lcl_str_EmployeeCode = $("#txtSignedInEmployeeCode").val();
                            var lcl_str_AttendanceCode = $('#tblAttendance').appendGrid('getCtrlValue', 'txtAttendanceCode', rowIndex);
                            var lcl_str_ManualOvertimeAdjustment = $('#tblAttendance').appendGrid('getCtrlValue', 'txtOvertimeManual', rowIndex);
                            var lcl_str_Remarks = $('#tblAttendance').appendGrid('getCtrlValue', 'txtRemarks', rowIndex);
                            if (!($.isNumeric(lcl_str_ManualOvertimeAdjustment))) {
                                DisplayError("Incorrect Value Enter for manual overtime adjustment!!!");
                                return false;
                            }
                            var options = {};
                            options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/AdjustOvertime";
                            options.dataType = "json";
                            options.type = "POST";
                            options.data = "{IP_ui64_AttendanceCode: " + lcl_str_AttendanceCode + ",IP_i32_OvertimeAdjustment: " + lcl_str_ManualOvertimeAdjustment + ",IP_ui64_OvertimeAdjustmentEmpCode:" + lcl_str_EmployeeCode + ",IP_str_Remarks:'" + lcl_str_Remarks + "'}"; // JSON.stringify(lcl_obj_LogFile);
                            options.contentType = "application/json; charset=utf-8";
                            options.success = function (result) {
                                var lcl_obj_WSResponse = result.d;
                                if (lcl_obj_WSResponse.ResponseCode == 0) {
                                    DisplaySuccess("Overtime Adjusted Successfully!!");
                                    return true;
                                }
                                if (lcl_obj_WSResponse.ResponseCode == 1) {
                                    DisplayInformation(lcl_obj_WSResponse.Message);
                                    return true;
                                }
                            };

                            options.error = function (err) { DisplayError(err.statusText); };

                            $.ajax(options);
                        }
                        return false;
                    }
                },
                { name: 'txtOvertimeTotal', display: 'O.T (T)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtNightAllowance', display: 'N.A', displayTooltip: 'Night Allowance', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
            {
                name: 'ddlAttendanceStatus', type: 'select', display: 'Status', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'NONE', 1: 'PRESENT', 2: 'ABSENT', 3: 'LATE', 4: 'LATE APPROVED', 5: 'HOLIDAY', 6: 'ON LEAVE', 7: 'WEEKEND', 8: 'WORK ON HOLIDAY', 9: 'OUTSIDE DUTY', 10: 'REPLACEMENT DUTY', 11: 'ON FOREIGN TOUR', 12: 'ABSENT NO DATA Found', 13: 'ABSENT OVERRIDDEN PRESENT', 14: 'SHIFT CHANGE HOLIDAY' },
                    onChange: function (evt, rowIndex) {
                        var lcl_str_EmployeeCode = $("#txtSignedInEmployeeCode").val();
                        var lcl_str_AttendanceCode = $('#tblAttendance').appendGrid('getCtrlValue', 'txtAttendanceCode', rowIndex);
                        var lcl_str_Remarks = $('#tblAttendance').appendGrid('getCtrlValue', 'txtRemarks', rowIndex);
                        var lcl_ctrl_Status = $('#tblAttendance').appendGrid('getCellCtrl', 'ddlAttendanceStatus', rowIndex);
                        var lcl_str_Status = $(lcl_ctrl_Status).find(":selected").text();
                        if (lcl_str_Status == 'P') {
                            DisplayInformation("Cannot Change Attendance Status to 'P' Manually!!");
                            evt.preventDefault();
                            return;
                        }
                        lcl_str_Remarks += "||" + lcl_str_EmployeeCode.toString() + " Changed Status To " + lcl_str_Status;
                        $('#tblAttendance').appendGrid('setCtrlValue', 'txtRemarks', rowIndex, lcl_str_Remarks);
                        return false;
                    }
                },
                { name: 'txtRemarks', display: 'Remarks', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        customRowButtons: [
            {
                uiButton: { icons: { primary: 'ui-icon-disk' }, text: false },
                click: function (evtObj, uniqueIndex, rowData) {
                    if (CheckAuthorization() == false) {
                        DisplayInformation("You are not authorized to edit the Attendance Status!!!");
                        return;
                    }
                    var lcl_str_EmployeeCode = $("#txtSignedInEmployeeCode").val();
                    var lcl_str_AttendanceCode = rowData["txtAttendanceCode"];
                    var lcl_str_ManualOvertimeAdjustment = rowData["txtRemarks"];
                    var lcl_str_Remarks = rowData["txtRemarks"];
                    var lcl_str_Status = rowData["ddlAttendanceStatus"];
                    if (lcl_str_Status == '1') {
                        DisplayInformation("Cannot Change Attendance Status to 'P' Manually!!");
                        return;
                    }
                    var options = {};
                    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/UpdateAttendanceStatus";
                    options.dataType = "json";
                    options.type = "POST";
                    options.data = "{IP_ui64_AttendanceCode: " + lcl_str_AttendanceCode + ",IP_enm_AttendanceStatus: " + lcl_str_Status + ",IP_str_Remarks:'" + lcl_str_Remarks + "'}"; // JSON.stringify(lcl_obj_LogFile);
                    options.contentType = "application/json; charset=utf-8";
                    options.success = function (result) {
                        var lcl_obj_WSResponse = result.d;
                        if (lcl_obj_WSResponse.ResponseCode == 0) {
                            DisplaySuccess("Attendance Status Has Been Changed Successfullly!");
                        }
                    };

                    options.error = function (err) { DisplayError(err.statusText); };

                    $.ajax(options);
                }, btnCss: { 'min-width': '20px' },
                btnAttr: { title: 'Update Attendance Status' },
                atTheFront: true
            }
        ],
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            var lcl_ctrl_AttendanceStatus = $(caller).appendGrid('getCellCtrl', 'ddlAttendanceStatus', addedRowIndex);
            if (GBLAttendanceMaster != undefined) {
                if (GBLAttendanceMaster.IsSalaryProcessed == 0) {
                    $(lcl_ctrl_AttendanceStatus).prop("disabled", false);
                }
                else {
                    $(lcl_ctrl_AttendanceStatus).prop("disabled", true);
                }
            }
        },
        beforeRowRemove: function (caller, rowIndex) {
        },
        hideButtons: {
            append: true,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: true,
            removeLast: true
        },
        hideRowNumColumn: true,
        rowDragging: true
    });
    initializeSelect2('ddlBulkAttendanceStatus', '------ Select Status ------', '25%');
});

$('#chkSelectAllRows').on('change', function () {
    var isChecked = $(this).is(':checked');
    var rowCount = $('#tblAttendance').appendGrid('getRowCount');

    for (var i = 0; i < rowCount; i++) {
        $('#tblAttendance').appendGrid('setCtrlValue', 'chkSelect', i, isChecked);
    }
});

function BulkUpdateAttendance() {
    if (!CheckAuthorization()) {
        DisplayInformation("You are not authorized to edit the Attendance Status!");
        return;
    }

    var rowCount = $('#tblAttendance').appendGrid('getRowCount');
    var rowsToUpdate = [];
    var skippedPRows = [];
    var selectedStatuses = []; // 🔹 collect statuses of selected rows

    for (var i = 0; i < rowCount; i++) {

        var isChecked = $('#tblAttendance').appendGrid('getCtrlValue', 'chkSelect', i);
        if (!isChecked) continue;

        var statusCtrl = $('#tblAttendance').appendGrid('getCellCtrl', 'ddlAttendanceStatus', i);
        var status = $(statusCtrl).find(":selected").val();
        var remarks = $('#tblAttendance').appendGrid('getCtrlValue', 'txtRemarks', i);
        var attendanceCode = $('#tblAttendance').appendGrid('getCtrlValue', 'txtAttendanceCode', i);

        // collect selected statuses
        selectedStatuses.push(status);

        // PRESENT skip
        if (status == '1') {
            skippedPRows.push(i + 1);
            continue;
        }

        rowsToUpdate.push({
            AttendanceCode: attendanceCode,
            AttendanceStatus: status,
            Remarks: remarks
        });
    }

    // 🔴 CHECK: selected rows status must be same
    var uniqueStatuses = [...new Set(selectedStatuses)];
    if (uniqueStatuses.length > 1) {
        DisplayInformation(
            "Selected rows have different Attendance Status.\n" +
            "Please select rows with SAME status to bulk update."
        );
        return;
    }

    // PRESENT warning
    if (skippedPRows.length > 0) {
        DisplayInformation(
            "Attendance Status 'PRESENT' cannot be changed manually.\n" +
            "Skipped Rows: " + skippedPRows.join(", ")
        );
    }

    if (rowsToUpdate.length === 0) {
        DisplayInformation("No valid rows selected for update.");
        return;
    }

    var successCount = 0;
    var failCount = 0;
    var messages = [];

    function updateRow(index) {

        if (index >= rowsToUpdate.length) {
            var summary = "Attendance Update Complete\n\n";
            summary += "Success: " + successCount + "\n";
            summary += "Failed: " + failCount;

            if (messages.length > 0) {
                summary += "\n\nDetails:\n" + messages.join("\n");
            }

            DisplayInformation(summary);
            return;
        }

        var row = rowsToUpdate[index];

        $.ajax({
            url: gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/UpdateAttendanceStatus",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                IP_ui64_AttendanceCode: row.AttendanceCode,
                IP_enm_AttendanceStatus: row.AttendanceStatus,
                IP_str_Remarks: row.Remarks
            }),
            success: function (result) {
                if (result && result.d && result.d.ResponseCode == 0) {
                    successCount++;
                } else {
                    failCount++;
                    messages.push(
                        "AttendanceCode " + row.AttendanceCode + ": " +
                        (result && result.d ? result.d.Message : "Unknown error")
                    );
                }
                updateRow(index + 1);
            },
            error: function (err) {
                failCount++;
                messages.push(
                    "AttendanceCode " + row.AttendanceCode + ": " + err.statusText
                );
                updateRow(index + 1);
            }
        });
    }

    updateRow(0);
}

$('#ddlBulkAttendanceStatus').on('change', function () {

    var selectedStatus = $(this).val();

    if (selectedStatus === "") return;

    // PRESENT manually not allowed
    if (selectedStatus === "1") {
        DisplayInformation("Attendance Status 'PRESENT' cannot be changed manually!");
        $(this).val("");
        return;
    }

    var rowCount = $('#tblAttendance').appendGrid('getRowCount');
    var affectedRows = 0;
    var skippedPRows = [];

    for (var i = 0; i < rowCount; i++) {

        var isChecked = $('#tblAttendance').appendGrid('getCtrlValue', 'chkSelect', i);
        if (!isChecked) continue;

        var statusCtrl = $('#tblAttendance').appendGrid('getCellCtrl', 'ddlAttendanceStatus', i);
        var currentStatus = $(statusCtrl).val();

        // Skip PRESENT rows
        if (currentStatus == "1") {
            skippedPRows.push(i + 1);
            continue;
        }

        // Change status in grid
        $(statusCtrl).val(selectedStatus);

        // Auto update remarks
        var remarks = $('#tblAttendance').appendGrid('getCtrlValue', 'txtRemarks', i);
        var statusText = $('#ddlBulkAttendanceStatus option:selected').text();
        remarks += " || Bulk status changed to " + statusText;
        $('#tblAttendance').appendGrid('setCtrlValue', 'txtRemarks', i, remarks);

        affectedRows++;
    }

    if (affectedRows === 0) {
        DisplayInformation("No valid selected rows found!");
        $(this).val("");
        return;
    }

    if (skippedPRows.length > 0) {
        DisplayInformation(
            "Skipped PRESENT rows: " + skippedPRows.join(", ")
        );
    }
});


/*
//Check Authrization. If Authrization Code Matches, returns TRUE else returns FALSE
*/
function CheckAuthorization() {
    var lcl_str_AuthorizationCode = $('#txtAuthorizationCode').val();
    if (lcl_str_AuthorizationCode == EDIT_AUTHORIZATION_CODE) {
        return true;
    }
    return false;
}

function GetAttendanceMaster(event) {
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    var lcl_dt_AttendanceDate = $('#txtAttendanceDate').val();
    if (lcl_dt_AttendanceDate == '') {
        DisplayError("Please Select Date!");
        return;
    }
    // alert("1");
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetAttendanceMaster";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_AttendanceDate: '" + lcl_dt_AttendanceDate + "'}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //AtendanceMaster Not Found
            GBLAttendanceMaster = null;
            DisplayInformation(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            GBLAttendanceMaster = lcl_obj_WSResponse.Data;
            DisplayAttendanceMaster();
            //DisplayLeaveProfile();
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
    //evt.preventDefault();}
}

function DisplayAttendanceMaster() {
    $("#txtTotalProcessed").val(GBLAttendanceMaster.TotalProcessed);
    $("#txtTotalOnLeave").val(GBLAttendanceMaster.TotalLeave);
    $("#txtTotalOnHoliday").val(GBLAttendanceMaster.TotalHoliday);
    $("#txtTotalPresent").val(GBLAttendanceMaster.TotalPresent);
    $("#txtTotalLate").val(GBLAttendanceMaster.TotalLate);
    $("#txtTotalAbsent").val(GBLAttendanceMaster.TotalAbsent);
    $("#txtTotalManHourExpectedOT").val(GBLAttendanceMaster.TotalExpectedManhourOT + " Hrs.");
    $("#txtTotalManHourServedOT").val(GBLAttendanceMaster.TotalManHourServedOT + " Hrs.");
    $("#txtTotalManHourExpectedOff").val(GBLAttendanceMaster.TotalExpectedManhourOff + " Hrs.");
    $("#txtTotalManHourServedOff").val(GBLAttendanceMaster.TotalManHourServedOff + " Hrs.");
    $("#txtTotalOvertime").val(parseInt(GBLAttendanceMaster.TotalOvertime / 60) + " Hrs.");
    $("#txtTotalOvertimeAmount").val((GBLAttendanceMaster.TotalOvertimeAmount) + " BDT.");
    $("#txtAverageCostOfOvertimePerHour").val((GBLAttendanceMaster.AverageCostOfOvertimePerHour) + " BDT.");

    if (GBLAttendanceMaster.IsSalaryProcessed == 0) {
        $("#txtIsSalaryProcessed").val("NO");
        $("#dvAttendance").prop("disabled", false);
    }
    else {
        $("#txtIsSalaryProcessed").val("YES");
        $("#dvAttendance").prop("disabled", true);
    }

    var lcl_i32_Count = $('#tblAttendance').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblAttendance').appendGrid('removeRow', 0);
    }
    var lcl_i32_TotalManHour = 0;
    var lcl_i32_TotalOvertime = 0;

    if (GBLAttendanceMaster.AttendanceList != null) {
        var lcl_objLst_AttendanceRows = new Array();
        var lcl_i32_TotalNightAllowance = 0;
        $.each(GBLAttendanceMaster.AttendanceList, function (index, lcl_obj_Attendance) {
            //alert(lcl_obj_EmployeeLeaveApplication.LeaveEndDate.toString());

            lcl_i32_TotalNightAllowance += lcl_obj_Attendance.NightAllowance;

            var lcl_str_DutyScheduleStart = moment(new Date(parseInt(lcl_obj_Attendance.DutyScheduleFrom.substr(6)))).format('DD.MM.YY h:mm A');
            if (lcl_str_DutyScheduleStart == "01.01.01 6:00 AM") {
                lcl_str_DutyScheduleStart = "";
            }
            var lcl_str_DutyScheduleEnd = moment(new Date(parseInt(lcl_obj_Attendance.DutyScheduleUpto.substr(6)))).format('DD.MM.YY h:mm A');
            if (lcl_str_DutyScheduleEnd == "01.01.01 6:00 AM") {
                lcl_str_DutyScheduleEnd = "";
            }

            var lcl_str_InDate = moment(new Date(parseInt(lcl_obj_Attendance.DutyFrom.substr(6)))).format('DD.MM.YY h:mm A');
            if (lcl_str_InDate == "01.01.01 6:00 AM") {
                lcl_str_InDate = "";
            }
            var lcl_str_OutDate = moment(new Date(parseInt(lcl_obj_Attendance.DutyUpto.substr(6)))).format('DD.MM.YY h:mm A');
            if (lcl_str_OutDate == "01.01.01 6:00 AM") {
                lcl_str_OutDate = "";
            }


            var lcl_str_DutySchedule = "Start : " + lcl_str_DutyScheduleStart + "\nEnd : " + lcl_str_DutyScheduleEnd;
            var lcl_str_In = lcl_str_InDate + "[" + lcl_obj_Attendance.InThrough + "]";
            var lcl_str_Out = lcl_str_OutDate + "[" + lcl_obj_Attendance.OutThrough + "]";

            var lcl_str_AttendanceDetails = lcl_obj_Attendance.EmployeeName + "[" + lcl_obj_Attendance.Designation + "][" + lcl_str_DutyScheduleStart + "-" + lcl_str_DutyScheduleEnd + "]";

            //lcl_i32_TotalManHour += lcl_obj_Attendance.DutyMinutes;
            //lcl_i32_TotalOvertime += lcl_obj_Attendance.Overtime;
            var lcl_str_NightAllowance = lcl_obj_Attendance.NightAllowance.toString() + ".00";

            var lcl_ui64_DutyMinute = lcl_obj_Attendance.DutyMinutes;
            var lcl_ui64_DutyHour = 0;

            if (lcl_ui64_DutyMinute > 0) {
                lcl_ui64_DutyHour = Math.floor(lcl_ui64_DutyMinute / 60);
                lcl_ui64_DutyMinute = Math.floor(lcl_ui64_DutyMinute % 60);
            }
            var lcl_str_DutyHour = lcl_ui64_DutyHour.toString() + ":" + lcl_ui64_DutyMinute.toString();


            var lcl_ui64_OvertimeAutoMinute = lcl_obj_Attendance.OvertimeAuto;
            var lcl_ui64_OvertimeAutoHour = 0;
            if (lcl_ui64_OvertimeAutoMinute > 0) {
                lcl_ui64_OvertimeAutoHour = Math.floor(lcl_ui64_OvertimeAutoMinute / 60);
                lcl_ui64_OvertimeAutoMinute = Math.floor(lcl_ui64_OvertimeAutoMinute % 60);
            }
            var lcl_str_OvertimeAutoHour = lcl_ui64_OvertimeAutoHour.toString() + ":" + lcl_ui64_OvertimeAutoMinute.toString();


            var lcl_ui64_OvertimeTotalMinute = lcl_obj_Attendance.OvertimeTotal;
            var lcl_ui64_OvertimeTotalHour = 0;
            if (lcl_ui64_OvertimeTotalMinute > 0) {
                lcl_ui64_OvertimeTotalHour = Math.floor(lcl_ui64_OvertimeTotalMinute / 60);
                lcl_ui64_OvertimeTotalMinute = Math.floor(lcl_ui64_OvertimeTotalMinute % 60);
            }
            var lcl_str_OvertimeTotal = lcl_ui64_OvertimeTotalHour.toString() + ":" + lcl_ui64_OvertimeTotalMinute.toString();

            $('#tblAttendance').appendGrid('appendRow', [
            { txtAttendanceCode: lcl_obj_Attendance.AttendanceCode,
                txtEmployeeCode: lcl_obj_Attendance.EmployeeCode,
                txtEmployeeId: lcl_obj_Attendance.EmployeeId,
                txtEmplpoeeName: lcl_obj_Attendance.EmployeeName,
                txtDesignation: lcl_obj_Attendance.Designation,
                txtInTime: lcl_str_InDate,
                txtInThrough: lcl_obj_Attendance.InThrough,
                txtOutTime: lcl_str_OutDate,
                txtOutThrough: lcl_obj_Attendance.OutThrough,
                txtDutyMinute: lcl_str_DutyHour,
                txtOvertimeAuto: lcl_str_OvertimeAutoHour,
                txtOvertimeManual: lcl_obj_Attendance.OvertimeManualAdjustment,
                txtOvertimeTotal: lcl_str_OvertimeTotal,
                txtNightAllowance: lcl_str_NightAllowance,
                ddlAttendanceStatus: lcl_obj_Attendance.AttnStatus,
                txtRemarks: lcl_obj_Attendance.Remarks
            }
        ]);

        });
        $("#txtTotalNightAllowance").val(lcl_i32_TotalNightAllowance.toString() + ".00");
        }
}


