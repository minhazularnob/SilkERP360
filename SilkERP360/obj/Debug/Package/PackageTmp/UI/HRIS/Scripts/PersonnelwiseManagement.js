var GBL_EMPLOYEE_LIST_TABLE;
var CLIPBOARD = "";
$(document).ready(function () {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    $('#ddlDepartment').change(function () { DepartmentChangeEvent(); });

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblEmployeeList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>Image</b>', sWidth: '7%', sClass: 'alignCenter' },
                    { sTitle: '<b>Emp. Id</b>', sWidth: '13%', sClass: 'alignCenter' },
                    { sTitle: '<b>Name</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Desgn.</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Salary.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>J. Date</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Action</b>', sWidth: '5%', sClass: 'alignCenter', sType: "html" }
                  ]

    });
    //GBL_EMPLOYEE_LIST_TABLE.fnPageChange('next', true);
    /***************************************************************************************************************************/
    /***************************************************************************************************************************/

    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    //Context Menu Setup
    $("#switcher").themeswitcher({
        jqueryuiversion: "1",
        imgpath: "~/../../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
        loadTheme: "Cupertino"
    });

    /* Menu 1: init by passing an array of entries. *//// 

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
			    $('#hdrSubForm').text('Leave Application');

			    $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    //url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployee",
                     url:  "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployee",
                    
                    data: "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewLeaveApplication.ascx') + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSResponse = response.d;
                        if (WSResponse.ResponseCode < 0) {
                            DisplayError(WSResponse.Message);
                            return;
                        }
                        var lcl_str_ControlHTML = WSResponse.Data;
                        $('#dvSubFormContainer').html(lcl_str_ControlHTML);
                        $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        //$('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                        //alert(lcl_str_ControlHTML);
                    } /// <reference path= />
                });
			}
			},

			{

			    title: "Salary Addition/deduction", cmd: "SalaryAdditionORdeduction", uiIcon: "", action: function (event, ui) {
			        var lcl_ui64_EmployeeCode = ui.target.attr('id');
			        $('#hdrSubForm').text('Salary Addition/deduction');

			        $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                   // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployee",
                     url:   "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployee",
                   
                    data: "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/SalaryAdditionDeduction.ascx') + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSResponse = response.d;
                        if (WSResponse.ResponseCode < 0) {
                            DisplayError(WSResponse.Message);
                            return;
                        }
                        var lcl_str_ControlHTML = WSResponse.Data;
                        $('#dvSubFormContainer').html(lcl_str_ControlHTML);
                        $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        //$('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                        //alert(lcl_str_ControlHTML);
                    } /// <reference path= />
                });
			    }

			},
            {

                title: "Employee Edit", cmd: "EmployeeEdit", uiIcon: "", action: function (event, ui) {
                    var lcl_ui64_EmployeeCode = ui.target.attr('id');

                    $('#hdrSubForm').text('Employee Edit');
    
                    $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                     //url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                    url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                    data: "{ IP_ui64_CompanyCode:" + lcl_ui64_CompanyCode + ",IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeEdit.ascx') + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSResponse = response.d;
                        if (WSResponse.ResponseCode < 0) {
                            DisplayError(WSResponse.Message);
                            return;
                        }
                        var lcl_str_ControlHTML = WSResponse.Data;
                        $('#dvSubFormContainer').html(lcl_str_ControlHTML);
                        $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        //$('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                        //alert(lcl_str_ControlHTML);
                    } /// <reference path= />
                });
                }

            },
        ////////////////////////////

            {

            title: "Change Employee Status", cmd: "ChangeEmployeeStatus", uiIcon: "", action: function (event, ui) {
                var lcl_ui64_EmployeeCode = ui.target.attr('id');

                $('#hdrSubForm').text('Change Employee Status');

                $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                   // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                     url:  "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                   
                    data: "{ IP_ui64_CompanyCode:" + lcl_ui64_CompanyCode + ",IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/EmployeeStatusChange.ascx') + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSResponse = response.d;
                        if (WSResponse.ResponseCode < 0) {
                            DisplayError(WSResponse.Message);
                            return;
                        }
                        var lcl_str_ControlHTML = WSResponse.Data;
                        $('#dvSubFormContainer').html(lcl_str_ControlHTML);
                        $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');
                        //$('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                        //alert(lcl_str_ControlHTML);
                    } /// <reference path= />
                });
            }
        }
        /////////////////////////
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
    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: "~/../../../WebServices/HRIS/EmployeeService.asmx/GetAvailableEmployeeProfileListByDepartment",
            //url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetRoosterAvailableEmployeeProfileListByDepartment",
            data: "{IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_DepartmentCode) + "}", //provide input for the getSM_PO method
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
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = lcl_obj_EmployeeProfile.Salary + ".00";
                    //alert(lcl_obj_EmployeeProfile.JoiningDate.toString());
                    //var lcl_obj_JoiningDate = lcl_obj_EmployeeProfile.JoiningDate;
                    var parsedDate = new Date(parseInt(lcl_obj_EmployeeProfile.JoiningDate.substr(6)));
                    var lcl_obj_JoiningDate = new Date(parsedDate);
                    var lcl_str_JoiningDate = $.datepicker.formatDate("dd/MM/yy", lcl_obj_JoiningDate);
                    //alert(lcl_str_JoiningDate);
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][5] = lcl_str_JoiningDate;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][6] = "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' rel='hlnkContextMenu" + lcl_i32_EmployeeNumber.toString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_EmployeeProfile.EmployeeCode.toString() + " src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_EmployeeNumber++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
                //GBL_EMPLOYEE_LIST_TABLE.fnAdjustColumnSizing();rel="#petrol"
                //GBL_EMPLOYEE_LIST_TABLE.fnDraw();
                /*************************************************************************************************************************/
                //Save the Respective EmployeeCode to Each Context Menu Trigger
                //                var i = 0;
                //                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                //                    $(('#imgContextMenu-' + i.toString())).data('EmployeeCode', lcl_obj_EmployeeProfile.EmployeeCode.toString());
                //                    i++;
                //                });
                /*************************************************************************************************************************/
            }
        });
}