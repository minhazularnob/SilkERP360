var GBLAttendanceMaster;
$(document).ready(function () {
    $("#txtAttendanceDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    $('#tblAttendance').appendGrid({
        caption: 'Attendance Details',
        initRows: 1,
        columns: [
        //                                 { name: 'Image', display: 'img', type: 'image'},
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
                { name: 'txtOvertimeManual', display: 'O.T (M)', displayTooltip: '', displayCss: { 'width': '4%' }, type: 'text', ctrlAttr: {}, ctrlCss: { width: '100%', 'text-align': 'center'} },

                { name: 'txtOvertimeTotal', display: 'O.T (T)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtNightAllowance', display: 'N.A', displayTooltip: 'Night Allowance', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'ddlAttendanceStatus', type: 'select', display: 'Status', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlAttr: { 'disabled': 'disabled' }, ctrlOptions: { 0: 'NONE', 1: 'P', 2: 'A', 3: 'L', 4: 'L.A', 5: 'H', 6: 'O.L', 7: 'W', 8: 'W.O.H', 9: 'O.D', 10: 'R.D', 11: 'O.F.T', 12: 'A.N.D', 13: 'A.O.P', 14: 'S.C.H' },
                    onChange: function (evt, rowIndex) {

                        return false;
                        //alert(lcl_str_Status.toString());
                    }
                },
                { name: 'txtRemarks', display: 'Remarks', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        //        customRowButtons: [
        //            {
        //                uiButton: { icons: { primary: 'ui-icon-disk' }, text: false },
        //                click: function (evtObj, uniqueIndex, rowData) {
        //                    
        //                }, btnCss: { 'min-width': '20px' },
        //                btnAttr: { title: 'Upload Sample Image' }, atTheFront: true
        //            }
        //        ],
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {

        },
        beforeRowRemove: function (caller, rowIndex) {
            //            var lcl_str_ItemCode = $(caller).appendGrid('getCtrlValue', 'txtItemCode', rowIndex);
            //            if ($.trim(lcl_str_ItemCode) != '') {
            //                ShowInfoMessageBoard("Operational Error : You are not permitted to delete this row!!!");
            //                return false;
            //            }
            //            return true;
        },
        hideButtons: {
            append: true,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: true,
            removeLast: true
        },
        hideRowNumColumn: true
    });
});

function GetAttendanceByDesignationAndDate(event) {
    event.preventDefault();
    var lcl_ui64_DesignationCode = $("#ddlDesignation option:selected").val();
    var lcl_dt_AttendanceDate = $("#txtAttendanceDate").val();

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetAttendanceByDesignationAndDate",
        data: "{IP_ui64_DesignationCode: " + lcl_ui64_DesignationCode + ",IP_dt_AttendanceDate:'" + lcl_dt_AttendanceDate + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode == -100) {
                ShowErrorMessageBoard("System Error : Critical System Error Detected!!!Contact SSL!!!");
                GBLAttendanceMaster = null;
                var lcl_i32_Count = $('#tblAttendance').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_Count; i++) {
                    $('#tblAttendance').appendGrid('removeRow', 0);
                }
                return;
            }
            if (WSResponse.ResponseCode == -1) {
                GBLAttendanceMaster = null;
                var lcl_i32_Count = $('#tblAttendance').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_Count; i++) {
                    $('#tblAttendance').appendGrid('removeRow', 0);
                }
                ShowInfoMessageBoard(WSResponse.Message);
                return;
            }
            if (WSResponse.ResponseCode == 0) {
                GBLAttendanceMaster = WSResponse.Data;
                DisplayAttendanceMaster();
                return;
            }
            //            var lcl_objLst_OvertimeHistoryList = WSResponse.Data;
            //            var lcl_ui16_NumberOfOTDays = lcl_objLst_OvertimeHistoryList[0].OvertimeList.length;
            //            //alert(lcl_ui16_NumberOfOTDays);
            //            //            if (lcl_ui16_NumberOfOTDays > 31) {
            //            //                DisplayError("Maximum permissible Overtime days is 31!!!");
            //            //                return;
            //            //            }

            //            $('#dvOvertime').show('slow');
            //            var lcl_objArr_OvertimeData = new Array();
            //            $.each(lcl_objLst_OvertimeHistoryList, function (index, lcl_obj_OvertimeHistory) {
            //                lcl_objArr_OvertimeData[index] = new Object();

            //                var lcl_obj_EmployeeProfile = lcl_obj_OvertimeHistory.EmployeeProfile;
            //                var lcl_objLst_OvertimeList = lcl_obj_OvertimeHistory.OvertimeList;

            //                lcl_objArr_OvertimeData[index].EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
            //                lcl_objArr_OvertimeData[index].EmployeeID = lcl_obj_EmployeeProfile.EmployeeID;
            //                lcl_objArr_OvertimeData[index].EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
            //                lcl_objArr_OvertimeData[index].Designation = lcl_obj_EmployeeProfile.Designation.Name;
            //                lcl_objArr_OvertimeData[index].TotalOvertime = lcl_obj_OvertimeHistory.TotalOvertime;

            //            });
        },
        error: function (event, jqxhr, settings, exception) /// <reference path= />
        {
            var lcl_obj_WSResponse = ($.parseJSON(jqxhr.responseText)).d;
            DisplayError(lcl_obj_WSResponse.Message);
        }
    });
}





function DisplayAttendanceMaster() {
    $("#txtTotalProcessed").val(GBLAttendanceMaster.TotalProcessed);
    $("#txtTotalOnLeave").val(GBLAttendanceMaster.TotalLeave);
    $("#txtTotalOnHoliday").val(GBLAttendanceMaster.TotalHoliday);
    $("#txtTotalPresent").val(GBLAttendanceMaster.TotalPresent);
    $("#txtTotalLate").val(GBLAttendanceMaster.TotalLate);
    $("#txtTotalAbsent").val(GBLAttendanceMaster.TotalAbsent);

    $("#txtTotalOvertime").val(parseInt(GBLAttendanceMaster.TotalOvertime / 60) + " Hrs.");



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