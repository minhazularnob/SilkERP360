var GBL_EMPLOYEE_LIST_TABLE;

$(document).ready(function () {

    var lcl_ui64_ModuleCode;
    var lcl_ui64_UserCode;

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblMdlPermissionList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Module Permission Data Available",
            "sZeroRecords": "No Module Permission Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {

        },
        "aoColumns": [
                     { sTitle: 'Sel', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Module Name', sWidth: '60%', sClass: 'alignCenter' },
                    { sTitle: 'Short Name', sWidth: '25%', sClass: 'alignCenter' },

                  ]

    });


    $('#ddl_UserID').change(function () { LoadAllModule(); });

});


/*********************************** Load Module Data*******************************/
function LoadAllModule() {
    var username =$('#ddl_UserID option:selected').val();

    $.ajax(
        {

            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/GetAllModule",
            data: "{IP_ui64_UserName:" + JSON.stringify(username) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }

                var lcl_obj_ModuleList = WSReturn.Data;

                var lcl_i32_ModuleCode = 0;
                var lcl_i32_CtrlIdx = 0;
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();

                var lcl_str_ExtendedAllModuleData = new Array();
                var CheckPermissinModule = "";
                $.each(lcl_obj_ModuleList, function (index, lcl_objLst_Module) {

                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode] = new Array();

                    if (lcl_objLst_Module.Status == 1) {
                        CheckPermissinModule = "checked=checked";
                    }
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][0] = "<input id='chkSelectModule-" + lcl_i32_ModuleCode.toString() + "' style='width:50%' " + CheckPermissinModule + " type='checkbox'/>";
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][1] = lcl_objLst_Module.ModuleName;
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][2] = lcl_objLst_Module.Shortname;
                    lcl_i32_ModuleCode++;
                    CheckPermissinModule = "";

                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllModuleData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();

                /************************************************************************/

                $.each(lcl_obj_ModuleList, function (index, lcl_objLst_Module) {
                    $(("#chkSelectModule-" + lcl_i32_CtrlIdx)).data("ModuleCode", lcl_objLst_Module.ModuleCode);
                    $(("#chkSelectModule-" + lcl_i32_CtrlIdx)).on("click", function () {
                        if ($(this).is(':checked')) {
                            lcl_ui64_ModuleCode = $(this).data("ModuleCode");
                            Modulepermission();
                        }
                        else {

                            lcl_ui64_ModuleCode = $(this).data("ModuleCode");                        
                            ModulepermissionRemove();

                        }
                    });
                    lcl_i32_CtrlIdx++;
                });
                /****************************************************************************/
            }
        });
    }


    function Modulepermission() {

        lcl_ui64_UserCode = $.trim($('#ddl_UserID option:selected').val());
        if (confirm("Are you sure permission This module?") == true) {
            debugger;
            $.ajax(
                {

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/AddToModule",
                    data: "{ IP_ui64_ModuleCode:" + JSON.stringify(lcl_ui64_ModuleCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_UserCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadAllModule();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
        }
        else {
            LoadAllModule();
            return false;
        }

    }

    function ModulepermissionRemove() {

        lcl_ui64_UserCode = $.trim($('#ddl_UserID option:selected').val());
        if (confirm("Are you sure Remove permission From This module?") == true) {
            debugger;
            $.ajax(
                {

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/RemoveModulepermissin",
                    data: "{ IP_ui64_ModuleCode:" + JSON.stringify(lcl_ui64_ModuleCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_UserCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadAllModule();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
        }
        else {
            LoadAllModule();
            return false;
        }

    }