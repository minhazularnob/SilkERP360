var tableData = [];
$(document).ready(function () {

    var lcl_ui64_ModuleCode;
    var lcl_ui64_UserCode;
    var lcl_ui64_MenuCode;

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblMenuPermissionList').dataTable({
        bFilter: true,
        bPaginate: false,
        bLengthChange: false,
        bInfo: false,
        bSort: false,
        bAutoWidth: false,
        oLanguage: {
            sEmptyTable: "No Menu Data Available"
        },
        aoColumns: [
            { sTitle: '<input type="checkbox" id="selectAll" />', sWidth: '5%', sClass: 'alignLeft', orderable: false }, // Checkbox
            { sTitle: 'Menu', sWidth: '15%', sClass: 'alignLeft' } // Menu Name
        ]
    });
    initializeSelect2('ddl_ModuleName', '------ Select Module ------', '70%');
    initializeSelect2('ddl_MenuUserID', '------ Select Module ------', '70%');

    $('#ddl_MenuUserID').change(function () {
        if ($('#ddl_ModuleName').val() != '0') {
            LoadModuleMenu();
        }
        else {
            return;
        }
    });
    $('#ddl_ModuleName').change(function () {
        if ($('#ddl_MenuUserID').val() != '0') {
            LoadModuleMenu();
        }
        else {
            return;
        }
    });
   

});
$(document).on('change', '#selectAll', function () {
    var checked = $(this).is(':checked');
    $('#tblMenuPermissionList tbody input[type="checkbox"]').prop('checked', checked);
});

function LoadModuleMenu() {
    var ModuleCode = $('#ddl_ModuleName option:selected').val();
    var UserCode = $('#ddl_MenuUserID option:selected').val();

    $.ajax({
        type: "POST",
        async: false,
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/GetAllMenu",
        data: JSON.stringify({
            IP_ui64_ModuleCode: ModuleCode,
            IP_ui64_EmployeeCode: UserCode
        }),
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;

            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            var menuList = WSReturn.Data;
            tableData = [];
            var parentIndexMap = {};
            GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
            let rowIndex = 0;

            menuList.forEach(function (menuItem, index) {
                const isChecked = menuItem.Status == 1 ? "checked='checked'" : "";
                const checkboxId = `chkSelectMenu-${index}`;

                // Indent submenus
                let checkboxHTML = `<input id="${checkboxId}" type="checkbox" ${isChecked} />`;
                if (menuItem.MenuType === "Sub Menu") {
                    checkboxHTML = `<input id="${checkboxId}" type="checkbox" style="margin-left: 20px;" ${isChecked} />`;
                }

                let menuNameFormatted;
                let expandIcon = "";

                if (menuItem.MenuType === "Main menu") {
                    expandIcon = `<i class="fas fa-plus-square expand-icon" data-target="parent-${menuItem.MenuCode}" style="cursor:pointer; margin-right: 5px;"></i>`;
                    menuNameFormatted = `<b>${expandIcon}${menuItem.MenuName}</b>`;
                    parentIndexMap[menuItem.MenuCode] = `parent-${menuItem.MenuCode}`;
                } else {
                    menuNameFormatted = `&nbsp;&nbsp;&nbsp;↳ ${menuItem.MenuName}`;
                }

                const row = [
                    checkboxHTML,
                    menuNameFormatted
                ];

                tableData.push({
                    row,
                    menuCode: menuItem.MenuCode,
                    menuType: menuItem.MenuType,
                    isChecked: menuItem.Status == 1 ? true: false,
                    parentMenuCode: findParentCode(menuList, index),
                    index
                });

                rowIndex++;
            });

            // Add to DataTable
            tableData.forEach(item => {
                const rowNode = GBL_EMPLOYEE_LIST_TABLE.fnAddData(item.row);
                const tr = $(GBL_EMPLOYEE_LIST_TABLE.fnGetNodes()).eq(item.index);

                if (item.menuType === "Sub Menu") {
                    tr.addClass(`child-row child-of-${parentIndexMap[item.parentMenuCode]}`);
                    tr.hide();
                } else {
                    tr.addClass(`parent-row ${parentIndexMap[item.menuCode]}`);
                }
            });

            // Expand/Collapse toggle
            $('.expand-icon').on('click', function () {
                    const targetClass = $(this).data('target');
                    const $icon = $(this);
                    const isExpanded = $icon.hasClass('fa-minus-square');

                    $(`.child-of-${targetClass}`).toggle();

                    // Toggle icon class
                    if (isExpanded) {
                        $icon.removeClass('fa-minus-square').addClass('fa-plus-square');
                    } else {
                        $icon.removeClass('fa-plus-square').addClass('fa-minus-square');
                    }
            });

            // Checkbox permission handlers
            tableData.forEach(function (item) {
                const checkbox = $(`#chkSelectMenu-${item.index}`);
                checkbox.data("menuCode", item.menuCode);

                checkbox.on("click", function () {
                    if ($('#saveAllMenusCheckBoxId').prop('checked') == true) {
                        return;
                    }
                    else {
                        lcl_ui64_MenuCode = $(this).data("menuCode");
                        if ($(this).is(":checked")) {
                            Menupermission();
                        } else {
                            MenupermissionRemove();
                        }
                    }
                });
            });
        }
    });
}

$('#saveBtnId').on('click', function () {
    var menuStatusList = [];

    $('#tblMenuPermissionList').find('tbody tr').each(function (index, tr) {
        var $checkbox = $(tr).find('input[type="checkbox"]');
        var menuCode = $checkbox.data('menuCode'); // stored from LoadModuleMenu
        var isChecked = $checkbox.prop('checked');

        for (var i = 0; i < tableData.length; i++) {
            var item = tableData[i];
            if (menuCode === item.menuCode) {
                if (isChecked !== item.isChecked) {
                    menuStatusList.push({
                        MenuCode: menuCode,
                        IsChecked: isChecked
                    });
                }
                break;
            }
        }
    });

    console.log("Changed menus:", menuStatusList);
    saveMenuPermissionList(menuStatusList);
});


function saveMenuPermissionList(menuStatusList) {

    var IP_ui64_EmployeeCode = $.trim($('#ddl_MenuUserID option:selected').val());
    var IP_ui64_ModuleCode = $.trim($('#ddl_ModuleName option:selected').val());

    if (confirm("Are you sure want to permission This Menu?") == true) {

        // Collect menu items and their IsChecked status from UI

        // Prepare data object
        var IP_MenuList = menuStatusList;


        console.log(IP_MenuList);
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/moduleAndMenuService.asmx/SaveMenuPermissionList",
            data: "{ IP_ui64_ModuleCode:" + JSON.stringify(IP_ui64_ModuleCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(IP_ui64_EmployeeCode) + ", IP_MenuList: " + JSON.stringify(IP_MenuList) +"}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoadModuleMenu();
                    return true;
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            }
        });
    } else {
        LoadModuleMenu();
        return false;
    }
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

function findParentCode(menuList, currentIndex) {
    for (let i = currentIndex - 1; i >= 0; i--) {
        if (menuList[i].MenuType === "Main menu") {
            return menuList[i].MenuCode;
        }
    }
    return null;
}

$('#toggleMenuId').on('click', function () {
    const isExpanded = $(this).find('i').hasClass('fa-minus'); // Check if icon is expanded

    if (isExpanded) {
        // Collapse all menus
        $('.child-row').hide(); // Hide all submenu rows
        $(this).find('i').removeClass('fa-minus').addClass('fa-plus'); // Change icon to plus
    } else {
        // Expand all menus
        $('.child-row').show(); // Show all submenu rows
        $(this).find('i').removeClass('fa-plus').addClass('fa-minus'); // Change icon to minus
    }
});


$('#saveAllMenusCheckBoxId').on('click', function () {
    if ($(this).is(':checked')) {
        $('#saveBtnId').show();
    } else {
        $('#saveBtnId').hide();
    }
});