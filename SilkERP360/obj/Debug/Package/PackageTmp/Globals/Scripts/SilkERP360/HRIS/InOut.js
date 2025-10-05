
var GBL_EMPLOYEE_LIST_TABLE;
var EmployeeId = new Array();
$(document).ready(function () {
    /*************************************************TimeIN && TimeOUt******************************************************/

    /***********************************************************END**************************************************************/




    $('#ddlDepartment').change(function () { DepartmentChangeEvent(); });

    $("#txtDate").datepicker({ dateFormat: "dd/MM/yy", maxDate: 0 }).datepicker("setDate", new Date());



    /*********************************************************************************************************************
    lcl_str_RoosterDepartmentCode is available here. It stores the DepartmentCode of the Department whose
    Rooster is being created. Written from Code Behind NewRooster.ascx.cs.page_load func
    *********************************************************************************************************************/
  
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val());
    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblAttendanceList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
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
                    { sTitle: 'Attn. Dt', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Emp. Id', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Name', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: 'Desgn.', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'In', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Out', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'O.T', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: 'Late', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Status', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '10%', sClass: 'alignCenter' },
                  ]

    });

    /*********************************************************************************************************************
    Context Menu Setup
    *********************************************************************************************************************/
    // debugger;
    //Context Menu Setup
    $("#switcher").themeswitcher({
        jqueryuiversion: "1",
        imgpath: "../../plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/images/",
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
			 {

			     title: "Change Employee Status", cmd: "ChangeEmployeeStatus", uiIcon: "", action: function (event, ui) {
			         var lcl_ui64_EmployeeCode = ui.target.attr('id');

			         $('#hdrSubForm').text('Change Employee Status');
			         //debugger;
			         $.ajax(
                {
                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUIByEmployeeComp",
                    data: "{ IP_ui64_CompanyCode:" + lcl_str_CompanyCode + ",IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/AttanStatusChange.ascx') + "}", //provide input for the getSM_PO method
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
            { title: "Change Entry Time", cmd: "ChangeEntryTime", uiIcon: "", action: function (event, ui) {
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
                .contextmenu("setEntry", "NewLeaveApp", "New Leave Application...")
				.contextmenu("setEntry", "NewAttnEntry", "New Attendance Entry...")
				.contextmenu("enableEntry", "NewAddDed", "New Addition Deduction...");


        }
    });


    /*********************************************************************************************************************/
});
    /*********************************************************************************************************************/
    function DepartmentChangeEvent() {
        var lcl_str_DepartmentCode = $.trim($('#ddlDepartment option:selected').val());
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val());
        var lcl_str_PunchDate = $.trim($('#txtDate').val());
        //alert(lcl_str_DepartmentCode);
        if (lcl_str_DepartmentCode == "0") {
            return;
        }
        $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetInOutDepartmentwise",
            data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + ",IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_DepartmentCode) + ",IP_str_PunchDate:" + JSON.stringify(lcl_str_PunchDate) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_EmployeeInOutList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_AttendanceNumber = 0;
                var lcl_str_EmployeeImage = "";
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAttendanceData = new Array();

                $.each(lcl_obj_EmployeeInOutList, function (index, lcl_obj_ExtendedAttendanceData) {
                    //                    lcl_str_EmployeeImage = "data:" + lcl_obj_EmployeeProfile.Image.ImageType + ";base64," + lcl_obj_EmployeeProfile.Image.ImageData;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber] = new Array();
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][0] = lcl_obj_ExtendedAttendanceData.PunchDate;
                    //                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = "<img id='imgEmployee-" + lcl_i32_EmployeeNumber + "' src='" + lcl_str_EmployeeImage + "' width='30px' height='30px'/>";
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][1] = lcl_obj_ExtendedAttendanceData.EmployeeID;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][2] = lcl_obj_ExtendedAttendanceData.EmployeeName;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][3] = lcl_obj_ExtendedAttendanceData.Designation;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][4] = lcl_obj_ExtendedAttendanceData.InTime;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][5] = lcl_obj_ExtendedAttendanceData.OutTime;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][6] = lcl_obj_ExtendedAttendanceData.OT;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][7] = lcl_obj_ExtendedAttendanceData.LateTime;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][8] = lcl_obj_ExtendedAttendanceData.Status;
                    lcl_str_ExtendedAttendanceData[lcl_i32_AttendanceNumber][9] = "<a id='hlnkContextMenu-" + lcl_i32_AttendanceNumber.toString() + "' rel='hlnkContextMenu" + lcl_i32_AttendanceNumber.toString() + "' class='ctx_mnu' href='#'><img id=" + lcl_obj_ExtendedAttendanceData.EmployeeCode.toString() + " src='/Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>"; 
                    lcl_i32_AttendanceNumber++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAttendanceData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
    }





