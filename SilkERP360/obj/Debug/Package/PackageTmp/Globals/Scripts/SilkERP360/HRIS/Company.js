$(document).ready(function () {

    /***********************************************************Change Department**************************************************************/


 LoadAllCompany();



    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblCompanyList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Company Data Available",
            "sZeroRecords": "No Company Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Name', sWidth: '19%', sClass: 'alignCenter' },
                    { sTitle: 'Short Name', sWidth: '9%', sClass: 'alignCenter' },
                    { sTitle: 'Address', sWidth: '19%', sClass: 'alignCenter' },
                    { sTitle: 'Phone No.', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Fax No', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Email', sWidth: '14%', sClass: 'alignCenter' },
                    { sTitle: 'Website', sWidth: '14%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '5%', sClass: 'alignCenter' },

                  ]

    });

});


////******************************** SAVE Holiday  ********************************************////////////

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
            var lcl_obj_Company = new Object();
           // debugger;
            lcl_obj_Company.Name = $("#txt_CompanyName").val();
            lcl_obj_Company.CompanyShortName = $("#txt_CompShortName").val();
            lcl_obj_Company.Address = $("#txt_CompAddress").val();
            lcl_obj_Company.PhoneNo = $("#txt_CompPhoneNo").val();
            lcl_obj_Company.FaxNo = $("#txt_CompFaxNo").val();
            lcl_obj_Company.Email = $("#txt_Email").val();
            lcl_obj_Company.WebSite = $("#txt_CompWebSite").val();


            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/SaveCompany",
                        // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_Obj_Company:" + JSON.stringify(lcl_obj_Company) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());

                                /// to call the Load Company Data /////////
                                LoadAllCompany();
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





/*********************************** Load Company Data*******************************/
function LoadAllCompany() {
    //debugger;
//    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
//    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val());
//    var lcl_str_SerchDate = $.trim($('#txt_DecDateTime').val());
    //alert(lcl_str_DepartmentCode);
//    if (lcl_str_CompanyCode == "0") {
//        return;
//    }
    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/GetAllCompany",
            // data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + ",IP_str_SerchDate:" + JSON.stringify(lcl_str_SerchDate) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_CompanyList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_CompanyCode = 0;

                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllCompanyData = new Array();

                $.each(lcl_obj_CompanyList, function (index, lcl_obj_ExtendedAllCompanyData) {
                    //debugger;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode] = new Array();
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][0] = lcl_obj_ExtendedAllCompanyData.Name;
                    // lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][1] = Date(parseInt(lcl_obj_ExtendedAllCompanyData.DecDate)); //$.datepicker.formatDate("mm/dd/yy", date);;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][6] = lcl_obj_ExtendedAllCompanyData.CompanyShortName;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][2] = lcl_obj_ExtendedAllCompanyData.Address;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][3] = lcl_obj_ExtendedAllCompanyData.PhoneNo;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][4] = lcl_obj_ExtendedAllCompanyData.FaxNo;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][5] = lcl_obj_ExtendedAllCompanyData.Email;
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][1] = lcl_obj_ExtendedAllCompanyData.WebSite
                    lcl_str_ExtendedAllCompanyData[lcl_i32_CompanyCode][7] = "<a id='hlnkContextMenu-" + lcl_i32_CompanyCode.toString() + "' rel='hlnkContextMenu" + lcl_i32_CompanyCode.toString() + "' class='ctx_mnu' href='#'><img id='" + lcl_obj_ExtendedAllCompanyData.CompanyCode.toString() + "' src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_CompanyCode++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllCompanyData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
    }