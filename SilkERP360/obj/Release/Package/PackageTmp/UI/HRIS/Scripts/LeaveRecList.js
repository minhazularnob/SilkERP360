var GBL_EMPLOYEE_LIST_TABLE;
var CLIPBOARD = "";

$(document).ready(function () {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();

    LeaveAppListEvent();


    //    var d = new Date(),
    //    
    //    n = d.getMonth(),
    //    
    //    y = d.getFullYear();

    //$('#ddlmonths option:eq('+n+')').prop('selected', true);

    //$('#ddlyears option[value="'+y+'"]').prop('selected', true);
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
                    { sTitle: '<b>Name</b>', sWidth: '40%', sClass: 'alignCenter' },
                    { sTitle: '<b>Desgn.</b>', sWidth: '30%', sClass: 'alignCenter' },
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
        			

			{ title: "Leave Recommen", cmd: "Leave Recommen", uiIcon: "", action: function (event, ui) {

			    var lcl_ui64_EmployeeCode = ui.target.attr('id');
			    $('#hdrSubForm').text('Leave Recommen');

			    $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployee",
                    // url: "~/../../../WebServices/UILoaderService.asmx/GetUIByEmployee",

                    data: "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewLeveRecommendation.ascx') + "}", //provide input for the getSM_PO method
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





function LeaveAppListEvent() {
    var lcl_str_LeaveListCode = 2;
    //alert(lcl_str_DepartmentCode);
    if (lcl_str_LeaveListCode == "0") {
        return;
    }

    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val(); //Retrieve company code from hidden field

    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetLeaveApplicationList",

            data: "{IP_ui64_LeaveListCode:" + JSON.stringify(lcl_str_LeaveListCode) + ",IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + "}", //provide input for the getSM_PO method
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
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' rel='hlnkContextMenu" + lcl_i32_EmployeeNumber.toString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_EmployeeProfile.EmployeeCode.toString() + " src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";


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