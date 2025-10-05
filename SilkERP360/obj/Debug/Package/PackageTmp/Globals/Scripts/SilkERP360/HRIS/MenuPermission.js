$(document).ready(function () {

  var lcl_ui64_ModuleCode;
  var lcl_ui64_UserCode;
  var lcl_ui64_MenuCode;

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblMenuPermissionList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Menu Permission Data Available",
            "sZeroRecords": "No Menu Permission Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {

        },
        "aoColumns": [
                     { sTitle: 'Sel', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Menu Name', sWidth: '60%', sClass: 'alignCenter' },
                    { sTitle: 'Menu Type', sWidth: '25%', sClass: 'alignCenter' },

                  ]

    });

    $('#ddl_ModuleName').change(function () { LoadModuleMenu(); });
});



/*********************************** Load Module Data*******************************/
function LoadModuleMenu() {

    var ModuleCode = $('#ddl_ModuleName option:selected').val();
    var UserCode = $('#ddl_MenuUserID option:selected').val();

    $.ajax(
        {

            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/GetAllMenu",
            data: "{IP_ui64_ModuleCode:" + JSON.stringify(ModuleCode) + ",IP_ui64_EmployeeCode:" + JSON.stringify(UserCode) + "}",
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
                $.each(lcl_obj_ModuleList, function (index, lcl_objLst_MenuPermission) {

                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode] = new Array();

                    if (lcl_objLst_MenuPermission.Status == 1) {
                        CheckPermissinModule = "checked=checked";
                    }
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][0] = "<input id='chkSelectMenu-" + lcl_i32_ModuleCode.toString() + "' style='width:50%' " + CheckPermissinModule + " type='checkbox'/>";
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][1] = lcl_objLst_MenuPermission.MenuName;
                    lcl_str_ExtendedAllModuleData[lcl_i32_ModuleCode][2] = lcl_objLst_MenuPermission.MenuType;
                    lcl_i32_ModuleCode++;
                    CheckPermissinModule = "";

                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllModuleData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();

                /************************************************************************/

                $.each(lcl_obj_ModuleList, function (index, lcl_objLst_MenuPermission) {
                    $(("#chkSelectMenu-" + lcl_i32_CtrlIdx)).data("menuCode", lcl_objLst_MenuPermission.MenuCode);
                    $(("#chkSelectMenu-" + lcl_i32_CtrlIdx)).on("click", function () {
                        if ($(this).is(':checked')) {
                            lcl_ui64_MenuCode = $(this).data("menuCode");
                            Menupermission();
                        }
                        else {

                            lcl_ui64_MenuCode = $(this).data("menuCode");
                            MenupermissionRemove();

                        }
                    });
                    lcl_i32_CtrlIdx++;
                });
                /****************************************************************************/
            }
        });
}


function Menupermission() {

    lcl_ui64_UserCode = $.trim($('#ddl_MenuUserID option:selected').val());
    lcl_ui64_ModuleCode = $.trim($('#ddl_ModuleName option:selected').val());
    if (confirm("Are you sure want to permission This Menu?") == true) {

        $.ajax(
                {

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/AddToMenu",
                    data: "{ IP_ui64_ModuleCode:" + JSON.stringify(lcl_ui64_ModuleCode) + " ,IP_ui64_MenuCode:" + JSON.stringify(lcl_ui64_MenuCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_UserCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadModuleMenu();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
    }
    else {
        LoadModuleMenu();
        return false;
    }

}

function MenupermissionRemove() {

    lcl_ui64_UserCode = $.trim($('#ddl_MenuUserID option:selected').val());
    lcl_ui64_ModuleCode = $.trim($('#ddl_ModuleName option:selected').val());
    if (confirm("Are you sure Remove permission this menu?") == true) {
        debugger;
        $.ajax(
                {

                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/RemoveToMenu",
                    data: "{ IP_ui64_ModuleCode:" + JSON.stringify(lcl_ui64_ModuleCode) + " ,IP_ui64_MenuCode:" + JSON.stringify(lcl_ui64_MenuCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_UserCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadModuleMenu();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
    }
    else {
        LoadModuleMenu();
        return false;
    }
}