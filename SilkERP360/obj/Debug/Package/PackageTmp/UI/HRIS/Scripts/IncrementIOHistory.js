var GBL_INCREMENT_HISTORY;
var CLIPBOARD = "";

$(document).ready(function () {


    GBL_INCREMENT_HISTORY = $('#tblIncrementHistory').dataTable({
        "bJQueryUI": true,
        "sScrollY": "auto",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "bSearch": false,
        "aoColumns": [
                    { sTitle: '<b>Prv. Gross</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Gross</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Basic</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. H.Rent</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Conv.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Med.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Eff. Month</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Eff. Year</b>', sWidth: '10%', sClass: 'alignCenter' },
                  ]

    });
    $("#ddlEmployee").combobox();

    $("#txtIncGross").blur(function () {
        CalculateSalary();
    });

//    $("#txtIncGross").keypress(function (e) {
//        //if the letter is not digit then display error and don't type anything
//        if ((e.which != 8 && e.which != 0 && e.which != 190) && (e.which < 48 || e.which > 57)) {
//            //display error message
//            //$("#errmsg").html("Digits Only").show().fadeOut("slow");
//            return false;
//        }
//        return true;
//    });

    $('#txtIncGross').keydown(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode > 112) {

        }
        else {
            if (event.keyCode < 95) {
                if (event.keyCode < 47 || event.keyCode > 57) {
                    event.preventDefault();
                }
            }
            else {
                if (event.keyCode < 97 || event.keyCode > 105) {
                    event.preventDefault();
                }
            }
        }

    });

    //    $('#txtIncGross').keypress(function (event) {
    //        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
    //            event.preventDefault();
    //        }
    //    });
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
    var options_sal = {};
    options_sal.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/GetSalaryStructureByEmployee";
    options_sal.type = "POST";
    options_sal.global = true,
            options_sal.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
            options_sal.contentType = "application/json; charset=utf-8",
            options_sal.processData = false;
    options_sal.success = function (result) {
        var lcl_obj_WSResponseSal = result.d;
        if (lcl_obj_WSResponseSal.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponseSal.Message);
            return;
        }
        var lcl_obj_SalaryStructure = lcl_obj_WSResponseSal.Data;
        $("#txtCurrGross").val(lcl_obj_SalaryStructure.Gross);
    };
    options_sal.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options_sal);
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
                lcl_objLst_TblIncrementHistory[index][1] = lcl_obj_Increment.IncGross;
                lcl_objLst_TblIncrementHistory[index][2] = lcl_obj_Increment.IncBasic;
                lcl_objLst_TblIncrementHistory[index][3] = lcl_obj_Increment.IncHouseRent;
                lcl_objLst_TblIncrementHistory[index][4] = lcl_obj_Increment.IncConveyence;
                lcl_objLst_TblIncrementHistory[index][5] = lcl_obj_Increment.IncMedical;
                lcl_objLst_TblIncrementHistory[index][6] = lcl_obj_Increment.EffectiveMonth;
                lcl_objLst_TblIncrementHistory[index][7] = lcl_obj_Increment.EffectiveYear;

            });
            GBL_INCREMENT_HISTORY.fnAddData(lcl_objLst_TblIncrementHistory);
            $('#dvReportBody').show('slow');
            
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}

function SaveIncrement() {
    var lcl_ui32_Gross = $("#txtIncGross").val();
    if ((lcl_ui32_Gross == 0) || (lcl_ui32_Gross == '')) {
        DisplayError("No Increment Given To Selected Employees!Cannot Save!");
        return;
    }


    var lcl_i32_EffectiveMonth = $('#ddlEffectiveMonth option:selected').index();
    var lcl_i32_EffectiveYear = $('#ddlEffectiveYear option:selected').index();

    if ((lcl_i32_EffectiveMonth == 0) || (lcl_i32_EffectiveYear == 0)) {
        DisplayError("Please Select Increment Effective Month/Effective Year!!!Operation Terminated!");
        return;
    }

    var lcl_i32_PreviousGross = $('#txtCurrGross').val();
    if ((lcl_i32_PreviousGross == '0') || (lcl_i32_PreviousGross == '')) {
        DisplayError("No previous gross Entry for the Selected Employee!");
        return;
    }



    var lcl_obj_Increment = new Object();

    lcl_obj_Increment.EmployeeCode = $('#ddlEmployee option:selected').val();
    lcl_obj_Increment.IncGross = $('#txtIncGross').val();
    lcl_obj_Increment.IncBasic = $('#txtIncBasic').val();
    lcl_obj_Increment.IncHouseRent = $('#txtIncHR').val();
    lcl_obj_Increment.IncConveyence = $('#txtIncConv').val();
    lcl_obj_Increment.IncMedical = $('#txtIncMed').val();
    lcl_obj_Increment.IncEntertainment = $('#txtIncEnt').val();
    lcl_obj_Increment.PreviousGross = $('#txtCurrGross').val();
    lcl_obj_Increment.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();
    lcl_obj_Increment.EffectiveMonth = $('#ddlEffectiveMonth option:selected').val();
    lcl_obj_Increment.EffectiveYear = $('#ddlEffectiveYear option:selected').val();

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/IncrementService.asmx/SaveIncrement";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_obj_Increment: " + JSON.stringify(lcl_obj_Increment) + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponseSal = result.d;
        if (lcl_obj_WSResponseSal.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponseSal.Message);
            return;
        }
        DisplaySuccess("Employee Has Been Incremented Successfully!");
        $(".INC_IP").val('0');
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    
}

//txtIncGross.Change function
function CalculateSalary() {
    var lcl_ui32_Gross = $("#txtIncGross").val();
    var lcl_ui32_Basic = (lcl_ui32_Gross * 60) / 100;
    var lcl_ui32_HouseRent = (lcl_ui32_Gross * 30) / 100;
    var lcl_ui32_Conveyence = (lcl_ui32_Gross * 5) / 100;
    var lcl_ui32_Medical = (lcl_ui32_Gross * 5) / 100;

    $("#txtIncBasic").val(lcl_ui32_Basic);
    $("#txtIncHR").val(lcl_ui32_HouseRent);
    $("#txtIncConv").val(lcl_ui32_Conveyence);
    $("#txtIncMed").val(lcl_ui32_Medical);
}