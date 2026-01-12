var GBL_EMPLOYEE_LIST_TABLE;
var CLIPBOARD = "";
$(document).ready(function () {
    $('#ddlDepartment').change(function () { DepartmentChangeEvent(); });

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblEmployeeList').dataTable({
        "bJQueryUI": true,
        "bProcessing": false,
        "bSort": false,
        "bFilter": true,
        "bLengthChange": true,
        "bPagination": true,
        "sPaginationType": "full_numbers",
        "bScrollAutoCss": false,
        "bLengthChange": false,
        "bDestroy": false,
        "iDisplayLength": 27,
        "oLanguage": {
            "sEmptyTable": "No Employee Data Available",
            "sZeroRecords": "No Employee Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Image', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Emp. Id', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Name', sWidth: '45%', sClass: 'alignCenter' },
                    { sTitle: 'Desgn.', sWidth: '30%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '5%', sClass: 'alignCenter', sType: "html" }
                  ],
        "fnPreDrawCallback": function (oSettings) {
            if ($('#test').val() == 1) {
                alert("REDRAW");
                return false;
            }
        }

    });
    // Removed forced page change to avoid confusing UI before data is loaded

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    $(function () {
    //        $.contextMenu({
    //            selector: '.ctx_mnu',
    //            trigger: 'left',
    //            callback: function (key, options) {
    //                var m = "clicked: " + key;
    //                window.console && console.log(m) || alert(m);
    //                window.console && console.log("Options.Selector :" + options.selector) || alert(m);
    //                window.console && console.log("Options.Trigger :" + options.trigger) || alert(m);
    //                window.console && console.log("options.inputs[key] :" + options.inputs[key].$input) || alert(m);
    //                
    //            },
    //            items: {
    //                "edit": { name: "Edit", icon: "edit" },
    //                "cut": { name: "Cut", icon: "cut" },
    //                "copy": { name: "Copy", icon: "copy" },
    //                "paste": { name: "Paste", icon: "paste" },
    //                "delete": { name: "Delete", icon: "delete" },
    //                "sep1": "---------",
    //                "quit": { name: "Quit", icon: "quit" }
    //            }
    //        });
    //    });
    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    //Context Menu Setup
    $("#switcher").themeswitcher({
        jqueryuiversion: "1",
        imgpath: "/Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
        loadTheme: "Cupertino"
    });

    /* Menu 1: init by passing an array of entries. */

    $(document).contextmenu({
        delegate: ".ctx_mnu",
        preventSelect: true,
        taphold: true,
        show: { effect: "fadeIn", duration: "slow" },
        hide: { effect: "fadeOut", duration: "fast" },
        width: "400px",
        menu: [
			{ title: "NewLeaveApplication", cmd: "NewLeaveApp", uiIcon: "", action: function (event, ui) {
			    var lcl_ui64_EmployeeCode = ui.target.attr('id');
			    alert(lcl_ui64_EmployeeCode);
			}
			},
			{ title: "NewAttendanceEntry", cmd: "NewAttnEntry", uiIcon: "", action: function (event, ui) {
			    var lcl_ui64_EmployeeCode = ui.target.attr('id');
			    alert(lcl_ui64_EmployeeCode);
			}
			},
			{ title: "NewAdditionDeduction", cmd: "NewAddDed", uiIcon: "", disabled: false, action: function (event, ui) {
			    var lcl_ui64_EmployeeCode = ui.target.attr('id');
			    alert(lcl_ui64_EmployeeCode);
			}
			}
			],
        // Implement the beforeOpen callback to dynamically change the entries
        beforeOpen: function (event, ui) {
            var $menu = ui.menu,

				$target = ui.target;
            $(document)
            //				.contextmenu("replaceMenu", [{title: "aaa"}, {title: "bbb"}])
            //				.contextmenu("replaceMenu", "#options2")
            //				.contextmenu("setEntry", "cut", {title: "Cuty", uiIcon: "ui-icon-heart", disabled: true})
                .contextmenu("setEntry", "NewLeaveApp", "New Leave Application...")
				.contextmenu("setEntry", "NewAttnEntry", "New Attendance Entry...")
				.contextmenu("enableEntry", "NewAddDed", "New Addition Deduction...");

            // Optionally return false, to prevent opening the menu now
        }
    });

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/

});



function CompanyChangeEvent() {
}

function DepartmentChangeEvent() {
    var lcl_str_DepartmentCode = $.trim($('#ddlDepartment option:selected').val());
    //alert(lcl_str_DepartmentCode);
    if (lcl_str_DepartmentCode == "0") {
        return;
    }

    var lcl_str_CompanyCode = $("#ddlCompany option:selected").val(); //Retrieve company code from hidden field

    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetRoosterAvailableEmployeeProfileListByDepartment",
            data: JSON.stringify({ "IP_ui64_DepartmentCode": lcl_str_DepartmentCode }),
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_EmployeeProfileList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_EmployeeNumber = 0;
                var lcl_str_EmployeeImage = "";
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                //GBL_EMPLOYEE_LIST_TABLE.fnDestroy();
                var lcl_str_EmployeeData = new Array();
                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                    lcl_str_EmployeeImage = "data:" + lcl_obj_EmployeeProfile.Image.ImageType + ";base64," + lcl_obj_EmployeeProfile.Image.ImageData;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber] = new Array();

                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][0] = "<img id='imgEmployee-" + lcl_i32_EmployeeNumber.toString() + "' src='" + lcl_str_EmployeeImage + "' width='30px' height='30px'/>";
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = lcl_obj_EmployeeProfile.EmployeeID;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][2] = lcl_obj_EmployeeProfile.EmployeeName;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][3] = lcl_obj_EmployeeProfile.Designation.Name;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_EmployeeProfile.EmployeeCode.toString() + " src='/Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_EmployeeNumber++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();

                /*************************************************************************************************************************/
                //Save the Respective EmployeeCode to Each Context Menu Trigger
                //                var i = 0;
                //                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                //                    $(('#imgContextMenu-' + i.toString())).data('EmployeeCode', lcl_obj_EmployeeProfile.EmployeeCode.toString());
                //                    i++;
                //                });
                /*************************************************************************************************************************/
            },
            error: function (xhr, status, errorThrown) {
                if (typeof DisplayError === 'function') {
                    DisplayError('Failed to load employees: ' + (xhr && xhr.responseText ? xhr.responseText : (errorThrown || status)));
                } else if (window.console && console.error) {
                    console.error('Failed to load employees:', status, errorThrown, xhr && xhr.responseText);
                }
            }
        });
}