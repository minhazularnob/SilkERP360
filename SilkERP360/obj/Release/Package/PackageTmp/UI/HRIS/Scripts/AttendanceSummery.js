var GBL_EMPLOYEE_LIST_TABLE;
$(document).ready(function () {

    $("#txtAttendanceDateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtAttendanceDateUpto").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    GBL_EMPLOYEE_LIST_TABLE = $('#tblAttendanceSummery').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>Emp. Id</b>', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: '<b>Employee</b>', sWidth: '32%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Days</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Comm.<br/>Hours </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Served<BR/>Hours </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Present</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Absent </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Late</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Late App </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Leave </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Holiday </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Weekend </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>W.O.H</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (A)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (M)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (T)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>N.Allow</b>', sWidth: '5%', sClass: 'alignCenter' }
                  ]

    });
});


function GetAttendanceSummeryMaster(event) {
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    var lcl_dt_DateFrom = $('#txtAttendanceDateFrom').val();
    if (lcl_dt_DateFrom == '') {
        DisplayError("Please Select a Start Date!");
        return;
    }

    var lcl_dt_DateUpto = $('#txtAttendanceDateUpto').val();
    if (lcl_dt_DateUpto == '') {
        DisplayError("Please Select a Upto Date!");
        return;
    }
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetAttendanceSummery";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_DateFrom: '" + lcl_dt_DateFrom + "',IP_dt_DateUpto:'" + lcl_dt_DateUpto + "'}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            var EmployeeAttendanceSummeryMaster = lcl_obj_WSResponse.Data;
            DisplayAttendanceSummery(EmployeeAttendanceSummeryMaster);
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}

function DisplayAttendanceSummery(EmployeeAttendanceSummeryMaster) {
    $("#txtTotalEmployees").val(EmployeeAttendanceSummeryMaster.TotalEmployees);
    $("#txtTotalExpectedWorkHour").val((parseInt(EmployeeAttendanceSummeryMaster.TotalDesignatedWorkHour)).toString() + " Hrs.");
    $("#txtTotalWorkHourServed").val((parseInt(EmployeeAttendanceSummeryMaster.TotalWorkHour)).toString() + " Hrs.");
    $("#txtTotalOvertimeAuto").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertimeAuto)).toString() + " Hrs.");
    $("#txtTotalOvertimeManual").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertimeManual)).toString() + " Hrs.");
    $("#txtTotalOvertime").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertime)).toString() + " Hrs.");
     $("#txtTotalNightAllowance").val((parseInt(EmployeeAttendanceSummeryMaster.TotalNightAllowance)).toString() + " .00");

    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
    var lcl_i32_TotalManHourCommitted = 0;
    var lcl_i32_TotalManHourServed = 0;

    var lcl_objLst_EmployeeAttendanceSummery = new Array();

    $.each(EmployeeAttendanceSummeryMaster.AttendanceSummeryList, function (index, AttendanceSummery) {

        var lcl_str_EmployeeDetails = AttendanceSummery.EmployeeName + "[" + AttendanceSummery.Designation + "]";
        lcl_objLst_EmployeeAttendanceSummery[index] = new Object();

        lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeId;
        lcl_objLst_EmployeeAttendanceSummery[index][1] = lcl_str_EmployeeDetails;
        lcl_objLst_EmployeeAttendanceSummery[index][2] = AttendanceSummery.TotalDays;
        lcl_objLst_EmployeeAttendanceSummery[index][3] = AttendanceSummery.TotalDesignatedWorkHour;
        lcl_objLst_EmployeeAttendanceSummery[index][4] = AttendanceSummery.TotalWorkHour;
        lcl_objLst_EmployeeAttendanceSummery[index][5] = AttendanceSummery.TotalPresent;
        lcl_objLst_EmployeeAttendanceSummery[index][6] = AttendanceSummery.TotalAbsent;
        lcl_objLst_EmployeeAttendanceSummery[index][7] = AttendanceSummery.TotalLate;
        lcl_objLst_EmployeeAttendanceSummery[index][8] = AttendanceSummery.TotalLateApproved;
        lcl_objLst_EmployeeAttendanceSummery[index][9] = AttendanceSummery.TotalLeave;
        lcl_objLst_EmployeeAttendanceSummery[index][10] = AttendanceSummery.TotalHoliday;
        lcl_objLst_EmployeeAttendanceSummery[index][11] = AttendanceSummery.TotalWeekend;
        lcl_objLst_EmployeeAttendanceSummery[index][12] = AttendanceSummery.TotalWorkOnHoliday;
        lcl_objLst_EmployeeAttendanceSummery[index][13] = AttendanceSummery.TotalOvertimeAuto;
        lcl_objLst_EmployeeAttendanceSummery[index][14] = AttendanceSummery.TotalOvertimeManual;
        lcl_objLst_EmployeeAttendanceSummery[index][15] = AttendanceSummery.TotalOvertime;
        lcl_objLst_EmployeeAttendanceSummery[index][16] = AttendanceSummery.TotalNightAllowance;

    });
    GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_objLst_EmployeeAttendanceSummery);
}