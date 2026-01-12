var GBL_INCREMENT_HISTORY;
var CLIPBOARD = "";
var MONTH_NAMES = ['January', 'February', 'March', 'April', 'May', 'June', 'July','August','September','October','November','December'];
$(document).ready(function () {
    GBL_INCREMENT_HISTORY = $('#tblIncrementSummery').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "aoColumns": [
            { sTitle: '<b>Prv. Gross</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. Amount</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Curr. Gross</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Eff. Month</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Eff. Year.</b>', sWidth: '10%', sClass: 'alignCenter' }
        ]

    });
    initializeSelect2('ddlEmployee', '------ Select Employee ------', '51%');
});


function DisplayIncrementHistory() {

    var lcl_i32_SelectedIndex = $('#ddlEmployee option:selected').index();
    if (lcl_i32_SelectedIndex == 0) {
        DisplayError("Please Select An Employee To Show Details!");
        return;
    }

    var lcl_ui64_EmployeeCode = $('#ddlEmployee option:selected').val();

    /*********************************************************************************************************************/
    //Get Current Salary
    var options_emp = {};
    options_emp.url = gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetEmployeeProfileByEmployeeCode";
    options_emp.type = "POST";
    options_emp.global = true,
    options_emp.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
    options_emp.contentType = "application/json; charset=utf-8",
    options_emp.processData = false;
    options_emp.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponseSal.Message);
            return;
        }
        var lcl_obj_EmployeeProfile = lcl_obj_WSResponse.Data;
        //
        
        //alert(lcl_obj_EmployeeProfile.Designation.Name);
        $('#txtDesig').val(lcl_obj_EmployeeProfile.Designation.Name);
        $('#txtDepartment').val(lcl_obj_EmployeeProfile.Department.Name);
        var lal_obj_JoiningDate = new Date(lcl_obj_EmployeeProfile.JoiningDate.match(/\d+/)[0] * 1);
        $('#txtJoiningDate').val($.datepicker.formatDate( "dd-MM-yy",lal_obj_JoiningDate));

    };
    options_emp.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options_emp);
    /*********************************************************************************************************************/

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/IncrementService.asmx/GetIncrementHistoryByEmployee";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode < 0) {
            //Incorrect EmployeeCode provided.No employee id found for provided employee code
            $('#dvReportBody').hide('slow');
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }

        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_obj_EmployeeIncrementList = lcl_obj_WSResponse.Data;

            if (lcl_obj_EmployeeIncrementList == null) {
                $('#dvReportBody').hide('slow');
                DisplayInformation("No Increment History Found For the Selected Employee!");
                GBL_INCREMENT_HISTORY.fnClearTable();
                return;
            }

            GBL_INCREMENT_HISTORY.fnClearTable();

            var lcl_objLst_TblIncrementHistory = new Array();


            $.each(lcl_obj_EmployeeIncrementList, function (index, lcl_obj_Increment) {


                lcl_objLst_TblIncrementHistory[index] = new Object();

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_TblIncrementHistory[index][0] = lcl_obj_Increment.PreviousGross;
                lcl_objLst_TblIncrementHistory[index][1] = Math.round((lcl_obj_Increment.IncGross - lcl_obj_Increment.PreviousGross) * 100) / 100;
                lcl_objLst_TblIncrementHistory[index][2] = lcl_obj_Increment.IncGross;
                lcl_objLst_TblIncrementHistory[index][3] = MONTH_NAMES[lcl_obj_Increment.EffectiveMonth - 1];
                lcl_objLst_TblIncrementHistory[index][4] = lcl_obj_Increment.EffectiveYear;

            });
            GBL_INCREMENT_HISTORY.fnAddData(lcl_objLst_TblIncrementHistory);
            $('#dvReportBody').show('slow');

        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}