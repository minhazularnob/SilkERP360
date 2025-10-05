

$(document).ready(function () {
    $('#ddl_sal_Addition').attr('disabled', true);
    $('#ddl_sal_Deduction').attr('disabled', true);
    debugger;

    var d = new Date(),

       a = d.getMonth(),

       b = d.getFullYear();

    // $('#ddl_sal_EffectMonth option:eq(' + a + ')').prop('selected', true);
    // $('#ddl_sal_EffectMonth1 option:eq(' + a + ')').prop('selected', true);

    $('#ddl_sal_EffectYear option[value="' + b + '"]').prop('selected', true);
    $("#txt_AddDed_Date").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0 });

    //LoadSalaryAddition();
    GBL_EMPLOYEE_LIST_TABLE = $('#tblEmployeeList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "500px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [

                        { sTitle: 'Addition/Deduction', sWidth: '20%', sClass: 'alignCenter' },
                        { sTitle: 'Type', sWidth: '25%', sClass: 'alignCenter' },
                        { sTitle: 'Effective Month', sWidth: '20%', sClass: 'alignCenter' },
                        { sTitle: 'Effective year', sWidth: '20%', sClass: 'alignCenter' },
                        { sTitle: 'Amount', sWidth: '15%', sClass: 'alignCenter' },

                     ]

    });
    

});
////******************************** SAVE SALARY ADDITION DEDUCTION  ********************************************////////////

function Save() {


    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {



            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        var d = new Date();
        var n = parseInt(d.getMonth());
        var y = parseInt(d.getFullYear());
        var sm = parseInt($("#ddl_sal_EffectMonth option:selected").val());
        var sy = parseInt($("#ddl_sal_EffectYear option:selected").val());
        if (n > sm) {
            lcl_b_InputValidated = false;
            DisplayError("Previous Month Not Allowed");
            return false;
        }
//        if (y > sy) {
//            lcl_b_InputValidated = false;
//            DisplayError("Previous year Not Allowed");
//            return false;
//        }

        if (lcl_b_InputValidated == true) {
            var lcl_obj_SalaryAddDed = new Object();
            debugger;
            lcl_obj_SalaryAddDed.EmployeeCode = gbl_ui64_EmployeeCode;

            lcl_obj_SalaryAddDed.AdditionOrDeduction = $("#ddl_sal_AddOrDed option:selected").val();
            lcl_obj_SalaryAddDed.Amount = $("#txt_Sal_AddDed_Amount").val();
            lcl_obj_SalaryAddDed.AdditionDeductionDate = $("#txt_AddDed_Date").val();
            lcl_obj_SalaryAddDed.Remarks = $("#txt_Sal_AddDedRemarks").val();
            lcl_obj_SalaryAddDed.EffectiveMonth = $("#ddl_sal_EffectMonth option:selected").val();
            lcl_obj_SalaryAddDed.EffectiveYear = $("#ddl_sal_EffectYear option:selected").val();
            // lcl_obj_SalaryAddDed.EffectiveMonthTo = $("#ddl_sal_EffectMonth1 option:selected").val();

            if (lcl_obj_SalaryAddDed.AdditionOrDeduction == 1) {
                //Addition
                lcl_obj_SalaryAddDed.AdditionDeductionType = $("#ddl_sal_Addition option:selected").val();
            }
            if (lcl_obj_SalaryAddDed.AdditionOrDeduction == 2) {
                //Deduction
                lcl_obj_SalaryAddDed.AdditionDeductionType = $("#ddl_sal_Deduction option:selected").val();
            }

            lcl_obj_SalaryAddDed.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();
            //  lcl_obj_SalaryAddDed.IsProcessed = '0';
            //alert(lcl_obj_LeaveApplication.LeaveCategory);

            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/SalaryAddDedService.asmx/SaveSalaryAdditionDeduction",

                        data: "{IP_Obj_SalaryAdditionDeduction:" + JSON.stringify(lcl_obj_SalaryAddDed) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message);
                                LoadSalaryAddition();
                                //alert(WSReturn.Message);
                                return false;
                            }
                            else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);
                            // $.unblockUI();
                        }
                    });
        }
    }
    return false;
}

function editRow(id) {
    debugger;
    var lcl_iu64_salaryAddDedcode = id;

    $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/SalaryAddDedService.asmx/SalaryAddDedUpdate",

                        data: "{IP_iu64_salaryAddDedcode:" + JSON.stringify(lcl_iu64_salaryAddDedcode) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                //DisplayInformation(WSReturn.Message);
                                LoadSalaryAddition();

                                //alert(WSReturn.Message);
                                return false;
                            }
                            else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);
                            // $.unblockUI();
                        }
                    });
    return false;
}

/*********************************** Load Salary Data*******************************/
function LoadSalaryAddition() {

    var lcl_iu64_EmployeeCode = gbl_ui64_EmployeeCode;
    //alert(lcl_str_DepartmentCode);
    if (lcl_iu64_EmployeeCode == "0") {
        return;
    }

    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val(); //Retrieve company code from hidden field

    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/SalaryAddDedService.asmx/GetSalaryAditionDeductionListByEmployee",

            data: "{IP_iu64_EmployeeCode:" + JSON.stringify(lcl_iu64_EmployeeCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_SalaryAddDedList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_EmployeeNumber = 0;

                var lcl_str_EmployeeImage = "";
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                //GBL_EMPLOYEE_LIST_TABLE.fnDestroy();
                var lcl_str_EmployeeData = new Array();
                if (lcl_obj_SalaryAddDedList.length == 0) {
                    DisplayInformation("No addition/deduction data found for the employee in the server!!!");
                    return;
                }
                $.each(lcl_obj_SalaryAddDedList, function (index, lcl_obj_SalaryAddDed) {
                    //lcl_str_EmployeeImage = "data:" + lcl_obj_SalaryAddDed.Image.ImageType + ";base64," + lcl_obj_SalaryAddDed.Image.ImageData;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber] = new Array();
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][0] = lcl_obj_SalaryAddDed._AdditionalData["AdditionOrDeduction"];
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = lcl_obj_SalaryAddDed._AdditionalData["AdditionDeductionType"];
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][2] = lcl_obj_SalaryAddDed._AdditionalData["EffectiveMonth"];
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][3] = lcl_obj_SalaryAddDed.EffectiveYear;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = lcl_obj_SalaryAddDed.Amount;

                    // lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = '<a href="javascript:void(0);"onclick="editRow(' + lcl_obj_SalaryAddDed.EmployeeCode.toString() + ')"><img src="~/../../../Globals/Images/delete.png" /></a>';

                    //= "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' rel='hlnkContextMenu" + lcl_i32_EmployeeNumber.toString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_SalaryAddDed.EmployeeCode.toString() + " src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";


                    lcl_i32_EmployeeNumber++;
                });
                
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
                //GBL_EMPLOYEE_LIST_TABLE.fnAdjustColumnSizing();rel="#petrol"
                //GBL_EMPLOYEE_LIST_TABLE.fnDraw();
                /*************************************************************************************************************************/
                // Save the Respective EmployeeCode to Each Context Menu Trigger
                var i = 0;
                $.each(lcl_obj_SalaryAddDedList, function (index, lcl_obj_SalaryAddDed) {
                    $(('#imgContextMenu-' + i.toString())).data('EmployeeCode', lcl_obj_SalaryAddDed.EmployeeCode.toString());
                    i++;
                });
                /*************************************************************************************************************************/
            },
            error: function (jqXHR, textStatus, errorThrown) {
                DisplayError("Fatal Error Occured on the Server!!Contact SSL!!!");
            }
        });
}


//$("#ddl_sal_AddOrDed").click(function () {
//   
//   //Get value of optgroup label

//    if ('ddl_sal_AddOrDed' == "Addition") {
//        $('#ddl_sal_AddOrDed0').attr('disabled', false); // Change Text Box 1 to Readonly
//   
//    } else {
//        //Remove class when optgroup label is not State
//    }
//});

//$("#ddl_sal_EffectMonth").change(function () {
//    $("#ddl_sal_EffectMonth1").val($(this).val());
//});

$('#ddl_sal_AddOrDed').change(function () {

    var val = $('#ddl_sal_AddOrDed option:selected').val();
    if (val == "1") {
        $('#ddl_sal_Addition').attr('disabled', false);
    }

    else {
        $('#ddl_sal_Addition').attr('disabled', true);
    }
});


$('#ddl_sal_AddOrDed').change(function () {

    var val = $('#ddl_sal_AddOrDed option:selected').val();
    if (val == "2") {
        $('#ddl_sal_Deduction').attr('disabled', false);
    }

    else {
        $('#ddl_sal_Deduction').attr('disabled', true);
    }
});


  