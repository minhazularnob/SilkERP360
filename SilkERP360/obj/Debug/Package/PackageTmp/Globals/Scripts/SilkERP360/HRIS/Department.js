 $(document).ready(function () {


    LoadAllDepartment();


    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblDepartmentList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Department Data Available",
            "sZeroRecords": "No Department Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Dept. Name', sWidth: '30%', sClass: 'alignCenter' },
                    { sTitle: 'Short Name', sWidth: '30%', sClass: 'alignCenter' },
                   // { sTitle: 'Company Code', sWidth: '22%', sClass: 'alignCenter' },
                    { sTitle: 'Head Emp Code.', sWidth: '25%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '15%', sClass: 'alignCenter' },

                  ]

    });

});


////******************************** SAVE Department  ********************************************////////////

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
            var lcl_obj_Department = new Object();
   
            lcl_obj_Department.DeptName = $("#txt_DptName").val();
            lcl_obj_Department.ShortName = $("#txt_ShortName").val();
            lcl_obj_Department.CompanyCode = $('#ddlCompany option:selected').val();
            lcl_obj_Department.HeadEmployeeId = $("#txt_HdEmpCode").val();


            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/SaveDepartment",
                        // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_Obj_Department:" + JSON.stringify(lcl_obj_Department) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());
                                /// to call the Load Department Data /////////
                                LoadAllDepartment();
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


/*********************************** Load Department Data*******************************/
function LoadAllDepartment() {
   var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/GetAllDepartment",
             data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_DepartmentList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_DepartmentCode = 0;

                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllDepartmentData = new Array();

                $.each(lcl_obj_DepartmentList, function (index, lcl_obj_ExtendedAllDepartmentData) {
                    //debugger;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode] = new Array();
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][0] = lcl_obj_ExtendedAllDepartmentData.DeptName;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][1] = lcl_obj_ExtendedAllDepartmentData.ShortName
                    //lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][2] = lcl_obj_ExtendedAllDepartmentData.CompanyCode;
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][2] = lcl_obj_ExtendedAllDepartmentData.HeadEmployeeId;                                    
                    lcl_str_ExtendedAllDepartmentData[lcl_i32_DepartmentCode][3] = "<a id='hlnkContextMenu-" + lcl_i32_DepartmentCode.toString() + "' rel='hlnkContextMenu" + lcl_i32_DepartmentCode.toString() + "' class='ctx_mnu' href='#'><img id='" + lcl_obj_ExtendedAllDepartmentData.CompanyCode.toString() + "' src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_DepartmentCode++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllDepartmentData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
}