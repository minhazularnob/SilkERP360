var GBL_TBL_EMPLOYEE_MOVEMENT;
var GBL_TBL_EMPLOYEE_WISE_ATTENDANCE;
$(document).ready(function () {


    GBL_TBL_EMPLOYEE_WISE_ATTENDANCE = $('#tblEmployeewiseAttendance').dataTable({
        "bJQueryUI": false,
        "sScrollY": "auto",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "bSearch": false,
        "aoColumns": [
                    { sTitle: '<b>Date</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Duty Schedule</b>', sWidth: '25%', sClass: 'alignCenter' },
                    { sTitle: '<b>Duty</b>', sWidth: '25%', sClass: 'alignCenter' },
                    { sTitle: '<b>Duty Hour </b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Overtime (A)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Overtime (M)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Overtime</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Status</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Remarks</b>', sWidth: '10%', sClass: 'alignCenter' },
                  ]

    });

    GBL_TBL_EMPLOYEE_MOVEMENT = $('#tblMovementData').dataTable({
        "bJQueryUI": true,
        "sScrollY": "auto",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "bSearch": false,
        "aoColumns": [
                    { sTitle: '<b>BMS Point No</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>BMS Point</b>', sWidth: '25%', sClass: 'alignCenter' },
                    { sTitle: '<b>Date & Time</b>', sWidth: '25%', sClass: 'alignCenter' },
                  ]

    });

    $("#ddlQueryType").change(function () {
        var lcl_i32_SelectedIndex = $("option:selected", this).index();

        if (lcl_i32_SelectedIndex == 0) {
            $(".QI_EMPLOYEE_MOVEMENT_CTRL").prop("disabled", true);
            $(".QI_EMPLOYEE_MOVEMENT_CTRL").val("");
            $("#lnkGetEmployeeMovement").removeClass("command_button_enabled").addClass("command_button_disabled");
            $("#lnkGetEmployeeMovement").unbind("click");
        }
        GBL_TBL_EMPLOYEE_MOVEMENT.fnClearTable();
        GBL_TBL_EMPLOYEE_WISE_ATTENDANCE.fnClearTable();
        if (lcl_i32_SelectedIndex == 1) {
            //Employee Movement Selected
            $(".QI_EMPLOYEE_MOVEMENT_CTRL").prop("disabled", false);
            $("#lnkGetEmployeeMovement").removeClass("command_button_disabled").addClass("command_button_enabled");
            $("#lnkGetEmployeeMovement").bind("click", function () { GetEmployeeMovement(); });

            $("#lnkGetEmployeewiseAttendance").removeClass("command_button_enabled").addClass("command_button_disabled");
            $("#lnkGetEmployeewiseAttendance").unbind("click", function () { GetEmployeewiseAttendanceByDateRange(); });

            $("#dvEmployeewiseAttendance").hide("slow", function () {
                // Animation complete.
                if (GBL_TBL_EMPLOYEE_WISE_ATTENDANCE != null) {
                    GBL_TBL_EMPLOYEE_WISE_ATTENDANCE.fnClearTable();
                }
                $("#dvMovementData").show("slow", function () { });
            });
        }

        if (lcl_i32_SelectedIndex == 2) {
            //Employeewise Attendance By Date Range
            $(".QI_EMPLOYEE_MOVEMENT_CTRL").prop("disabled", false);
            $("#lnkGetEmployeewiseAttendance").removeClass("command_button_disabled").addClass("command_button_enabled");
            $("#lnkGetEmployeewiseAttendance").bind("click", function () { GetEmployeewiseAttendanceByDateRange(); });

            $("#lnkGetEmployeeMovement").removeClass("command_button_enabled").addClass("command_button_disabled");
            $("#lnkGetEmployeeMovement").unbind("click", function () { GetEmployeeMovement(); });

            $("#dvMovementData").hide("slow", function () {
                // Animation complete.
                $("#dvEmployeewiseAttendance").show("slow", function () { });
            });
        }
    });

    //$("#ddlEmployeeId").combobox();
    initializeSelect2('ddlQueryType', '------ Select Employee ------', '25%');

    initializeSelect2('ddlEmployeeId', '------ Select Employee ------', '25%');


    $("#txtStartDateTime").datetimepicker({ dateFormat: 'dd/MM/yy', timeFormat: 'hh:mm tt', showButtonPanel: true, maxDate: 0,
        onSelect: function (dateStr) {
        }
    });
    $("#txtEndDateTime").datetimepicker({ dateFormat: 'dd/MM/yy', timeFormat: 'hh:mm tt', showButtonPanel: true,  maxDate: 0,
        onSelect: function (dateStr) {
           
        }
    });
});

function GetEmployeewiseAttendanceByDateRange() {
    debugger;
    var lcl_ui64_EmployeeCode = $('#ddlEmployeeId option:selected').val();
    var lcl_dt_StartDateTime = $("#txtStartDateTime").val();
    var lcl_dt_EndDateTime = $("#txtEndDateTime").val();
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetEmployeewiseAttendanceByDateRange";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_dt_StartDate:" + JSON.stringify(lcl_dt_StartDateTime) + ",IP_dt_EndDate :" + JSON.stringify(lcl_dt_EndDateTime) + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //Incorrect EmployeeCode provided.No employee id found for provided employee code
            GBL_TBL_EMPLOYEE_WISE_ATTENDANCE.fnClearTable();
            DisplayError("Incorrect/Invalid Employee Id Provided!!!");
            return;
        }

        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_obj_EmployeewiseAttendanceByDateRange = lcl_obj_WSResponse.Data;
            GBL_TBL_EMPLOYEE_WISE_ATTENDANCE.fnClearTable();

            $("#txtEACompany").val(lcl_obj_EmployeewiseAttendanceByDateRange.Company);
            $("#txtEAEmployeeId").val(lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeId);
            $("#txtEADepartment").val(lcl_obj_EmployeewiseAttendanceByDateRange.Department);
            $("#txtEADesignation").val(lcl_obj_EmployeewiseAttendanceByDateRange.Designation);
            $("#txtEAEmployeeName").val(lcl_obj_EmployeewiseAttendanceByDateRange.Name);

            $("#txtEATotalManHourCommitted").val(lcl_obj_EmployeewiseAttendanceByDateRange.TotalWorkHourExpected);
            $("#txtEATotalManHourServed").val(lcl_obj_EmployeewiseAttendanceByDateRange.TotalWorkHourServed);
            $("#txtEATotalOvertime").val(lcl_obj_EmployeewiseAttendanceByDateRange.TotalOvertime);
            $("#txtTotalAbsentPercentage").val(lcl_obj_EmployeewiseAttendanceByDateRange.TotalAbsentPercentage + '%');
            $("#txtTotalLatePercentage").val(lcl_obj_EmployeewiseAttendanceByDateRange.TotalLatePercentage + '%');

            $("#txtEAAttendanceDateRange").val(lcl_obj_EmployeewiseAttendanceByDateRange.ReportDateRange);

            var lcl_img_EmployeeImage = 'data' + ':' + lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeImage.ImageType + ';' + 'base64' + ',' + lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeImage.ImageData;
            document.getElementById("imgEmployeeImage").setAttribute("src", lcl_img_EmployeeImage);

            var lcl_objLst_EmployeewiseAttendance = new Array();


            $.each(lcl_obj_EmployeewiseAttendanceByDateRange.DaysAttendanceList, function (index, lcl_obj_Attendance) {


                lcl_objLst_EmployeewiseAttendance[index] = new Object();

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_EmployeewiseAttendance[index][0] = lcl_obj_Attendance.AttendanceDate;
                lcl_objLst_EmployeewiseAttendance[index][1] = lcl_obj_Attendance.DutyScheduleDateTime;
                lcl_objLst_EmployeewiseAttendance[index][2] = lcl_obj_Attendance.DutyDateTime;
                lcl_objLst_EmployeewiseAttendance[index][3] = lcl_obj_Attendance.DutyHour;
                lcl_objLst_EmployeewiseAttendance[index][4] = lcl_obj_Attendance.OvertimeAuto;
                lcl_objLst_EmployeewiseAttendance[index][5] = lcl_obj_Attendance.OvertimeManual;
                lcl_objLst_EmployeewiseAttendance[index][6] = lcl_obj_Attendance.Overtime;
                lcl_objLst_EmployeewiseAttendance[index][7] = lcl_obj_Attendance.AttendanceStatus;
                lcl_objLst_EmployeewiseAttendance[index][8] = lcl_obj_Attendance.Remarks;
            });
            GBL_TBL_EMPLOYEE_WISE_ATTENDANCE.fnAddData(lcl_objLst_EmployeewiseAttendance);
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}

function GetEmployeeMovement() {
    var lcl_ui64_EmployeeCode = $('#ddlEmployeeId option:selected').val();
    var lcl_dt_StartDateTime = $("#txtStartDateTime").val();
    var lcl_dt_EndDateTime = $("#txtEndDateTime").val();
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetBiometricTransactionByDateRange";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_dt_StartDate:" + JSON.stringify(lcl_dt_StartDateTime) + ",IP_dt_EndDate :" + JSON.stringify(lcl_dt_EndDateTime) + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        //var lcl_obj_ResponseObject = lcl_obj_WSResponse.Data;
        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //Incorrect EmployeeCode provided.No employee id found for provided employee code
            GBL_TBL_EMPLOYEE_MOVEMENT.fnClearTable();
            DisplayError("Incorrect/Invalid Employee Id Provided!!!");
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 2) {
            //No Movement Found
            GBL_TBL_EMPLOYEE_MOVEMENT.fnClearTable();
            DisplayError("No Movement Detected For the Selected Employee on the specified date range!!!");
            return;
        }

        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_objLst_BMSTransaction = lcl_obj_WSResponse.Data;
            GBL_TBL_EMPLOYEE_MOVEMENT.fnClearTable();
            var lcl_objLst_MovementList = new Array();
            $.each(lcl_objLst_BMSTransaction, function (index, lcl_obj_BMSTransaction) {
                lcl_objLst_MovementList[index] = new Object();
                lcl_objLst_MovementList[index][0] = lcl_obj_BMSTransaction.ReaderNo.toString();
                lcl_objLst_MovementList[index][1] = lcl_obj_BMSTransaction.ReaderName.toString();
                lcl_objLst_MovementList[index][2] = moment(new Date(parseInt(lcl_obj_BMSTransaction.TranDateTime.substr(6)))).format('DD/MMMM/YY h:mm:ss A');
            });
            GBL_TBL_EMPLOYEE_MOVEMENT.fnAddData(lcl_objLst_MovementList);
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    //evt.preventDefault();
}