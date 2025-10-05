var GBL_DEPARTMENT_LIST;
$(document).ready(function () {



    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    GBL_DEPARTMENT_LIST = $('#tblDepartmentList').dataTable();
    GBL_DEPARTMENT_LIST = $('#tblDepartmentList').dataTable({
        "bAutoWidth": false,
        "bJQueryUI": true,
//        "sScrollY": "400px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>Department</b>', sWidth: '40%', sClass: 'alignCenter' },
                    { sTitle: '<b>Strength</b>', sWidth: '30%', sClass: 'alignCenter' },
                    { sTitle: '<b>Action</b>', sWidth: '10%', sClass: 'alignCenter' }
                  ]

    });
    //    var lcl_obj_DepartmentData = new Array();
    //    var lcl_i32_DepartmentCounter = 0;
    //    $.each(lcl_obj_DepartmentStrengths, function (index, lcl_obj_DepartmentStrength) {
    //        lcl_obj_DepartmentData[lcl_i32_DepartmentCounter] = new Array();
    //        lcl_obj_DepartmentData[lcl_i32_DepartmentCounter][0] = lcl_obj_DepartmentStrength.DepartmentCode;
    //        lcl_obj_DepartmentData[lcl_i32_DepartmentCounter][1] = lcl_obj_DepartmentStrength.Name;
    //        lcl_obj_DepartmentData[lcl_i32_DepartmentCounter][2] = lcl_obj_DepartmentStrength.DepartmentStrength;
    //        lcl_i32_DepartmentCounter++;
    //    });
    //    GBL_DEPARTMENT_LIST.fnAddData(lcl_obj_DepartmentData);
    /***************************************************************************************************************************/
    /***************************************************************************************************************************/
    //    //Context Menu Setup
    $("#switcher").themeswitcher({
        jqueryuiversion: "1",      
        imgpath: "~/../../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
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
            { title: "New Appoinment", cmd: "NewAppoinment", uiIcon: "", action: function (event, ui) {
                var lcl_ui64_DepartmentCode = ui.target.attr('id');

                $('#hdrSubForm').text('New Appoinment Employee');
                $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIBydepartment",
                    data: "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_ui64_DepartmentCode: " + lcl_ui64_DepartmentCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewEmployee.ascx') + "}", //provide input for the getSM_PO method
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

			{ title: "New Rooster", cmd: "NewRooster", uiIcon: "", action: function (event, ui) {
			    var lcl_ui64_DepartmentCode = ui.target.attr('id');
			    $('#hdrSubForm').text('New Rooster');
			    $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');



			    $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIBydepartment",
                    data: "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_ui64_DepartmentCode: " + lcl_ui64_DepartmentCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
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

        { title: "Change Rooster", cmd: "Change Rooster", uiIcon: "", action: function (event, ui) {
            var lcl_ui64_DepartmentCode = ui.target.attr('id');
            $('#hdrSubForm').text('Change Rooster');
            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');



            $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIBydepartment",
                    data: "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_ui64_DepartmentCode: " + lcl_ui64_DepartmentCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/changeRooster.ascx') + "}", //provide input for the getSM_PO method
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

        { title: "Overtime", cmd: "Overtime", uiIcon: "", action: function (event, ui) {
            var lcl_ui64_DepartmentCode = ui.target.attr('id');
            $('#hdrSubForm').text('Overtime Management');
            $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');



            $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIBydepartment",
                    data: "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_ui64_DepartmentCode: " + lcl_ui64_DepartmentCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/Overtime.ascx') + "}", //provide input for the getSM_PO method
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

         { title: "Overtime Entry Edit", cmd: "OvertimeIP", uiIcon: "", action: function (event, ui) {
             var lcl_ui64_DepartmentCode = ui.target.attr('id');
             $('#hdrSubForm').text('Overtime Entry / Edit');
             $("#dvSubForm").delay(500).show().animate({ opacity: 1, top: "0px" }, 'slow');



             $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIBydepartment",
                    data: "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_ui64_DepartmentCode: " + lcl_ui64_DepartmentCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/OvertimeIP.ascx') + "}", //provide input for the getSM_PO method
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