$(document).ready(function () {

    $("#txt_DegEffectiveFrom").datepicker({ dateFormat: 'dd/MM/yy', minDate: -15, maxDate: 0 });

    ////// Gross Declaretion //////
    $('#txt_DegGross').blur(function () { GrossSalaryChange(); });

    LoadAllDesignation();

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblDesignationList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Designation Data Available",
            "sZeroRecords": "No Designation Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Des. Name', sWidth: '17%', sClass: 'alignCenter' },
                    { sTitle: 'Short Name', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Gross', sWidth: '9%', sClass: 'alignCenter' },
                    { sTitle: 'Effective From', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Basic', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'Medical', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'Entertaiment', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'Conveyence', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'House Rent', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'Phone Bill', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: 'Others', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '6%', sClass: 'alignCenter' },

                  ]

    });

});

///////  Gross Change ////////////////

function GrossSalaryChange() {
    //debugger;
    var lcl_str_GrossSalary = $.trim($("#txt_DegGross").val().toString());
    if (lcl_str_GrossSalary == '') {
        //reset all fields to 0.00
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }
    $(".salary_field").val('0.00'); //zero out all salary fields
    lcl_str_GrossSalary = lcl_str_GrossSalary.replace(',', '');
    var lcl_flt_GrossSalary = parseFloat(lcl_str_GrossSalary);
    if (lcl_flt_GrossSalary == 0) {
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }
    var lcl_flt_Basic = (lcl_flt_GrossSalary * 60) / 100;
    $("#txt_DegBasic").val(lcl_flt_Basic.toString());
    var lcl_flt_HouseRent = (lcl_flt_GrossSalary * 30) / 100;
    $("#txt_houseRent").val(lcl_flt_HouseRent.toString());
    var lcl_flt_Medical = (lcl_flt_GrossSalary * 5) / 100;
    $("#txt_DegMedical").val(lcl_flt_Medical.toString());
    var lcl_flt_Conveyence = (lcl_flt_GrossSalary * 5) / 100;
    $("#txt_DegConveyence").val(lcl_flt_Conveyence.toString());
    //alert(lcl_flt_GrossSalary.toString());
}


////******************************** SAVE Designation  ********************************************////////////

function Save() {

    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            //test
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        if (lcl_b_InputValidated == true) {
            var lcl_obj_Designation = new Object();
            debugger;

            lcl_obj_Designation.CompanyCode = $('#ddlCompany option:selected').val();
            lcl_obj_Designation.DegnName = $("#txt_DesName").val();
            lcl_obj_Designation.ShortName = $("#txt_DesShortName").val();
            lcl_obj_Designation.Conveyence = $("#txt_DegConveyence").val();
            lcl_obj_Designation.Basic = $("#txt_DegBasic").val();
            lcl_obj_Designation.HouseRent = $("#txt_houseRent").val();
            lcl_obj_Designation.Medical = $("#txt_DegMedical").val();
            lcl_obj_Designation.Entertainment = $("#txt_DegEntertaiment").val();
            lcl_obj_Designation.PhoneBill = $("#txt_DegPhoneBill").val();
            lcl_obj_Designation.Others = $("#txt_DegOthers").val();
            lcl_obj_Designation.Gross = $("#txt_DegGross").val();
            lcl_obj_Designation.EffectiveFrom = $("#txt_DegEffectiveFrom").val();



            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/SaveDesignation",
                        // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_Obj_Designation:" + JSON.stringify(lcl_obj_Designation) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());
                                LoadAllDesignation()
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



/*********************************** Load Designation Data*******************************/
function LoadAllDesignation() {
   // debugger;
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();

    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DesignationService.asmx/GetAllDesignation",
            data: "{IP_ui64_companyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_DesignationList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_DesignationCode = 0;

                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllDesignationData = new Array();

                $.each(lcl_obj_DesignationList, function (index, lcl_obj_ExtendedAllDesignationData) {
                    //debugger;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode] = new Array();
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][0] = lcl_obj_ExtendedAllDesignationData.DegnName;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][1] = lcl_obj_ExtendedAllDesignationData.ShortName;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][2] = lcl_obj_ExtendedAllDesignationData.Gross;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][3] = FormatDate(lcl_obj_ExtendedAllDesignationData.EffectiveFrom);
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][4] = lcl_obj_ExtendedAllDesignationData.Basic;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][5] = lcl_obj_ExtendedAllDesignationData.Medical;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][6] = lcl_obj_ExtendedAllDesignationData.Entertainment;                    
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][7] = lcl_obj_ExtendedAllDesignationData.Conveyence;       
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][8] = lcl_obj_ExtendedAllDesignationData.HouseRent;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][9] = lcl_obj_ExtendedAllDesignationData.PhoneBill;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][10] = lcl_obj_ExtendedAllDesignationData.Others;
                    lcl_str_ExtendedAllDesignationData[lcl_i32_DesignationCode][11] = "<a id='hlnkContextMenu-" + lcl_i32_DesignationCode.toString() + "' rel='hlnkContextMenu" + lcl_i32_DesignationCode.toString() + "' class='ctx_mnu' href='#'><img id='" + lcl_obj_ExtendedAllDesignationData.CompanyCode.toString() + "' src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_DesignationCode++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllDesignationData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
    }

    function FormatDate(jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)))
        var d = date.getDate(), m = date.getMonth() + 1, y;
        if (date.getFullYear) { y = date.getFullYear(); }
        else { y = 2000 + (date.getYear() % 100); }
        return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
    }