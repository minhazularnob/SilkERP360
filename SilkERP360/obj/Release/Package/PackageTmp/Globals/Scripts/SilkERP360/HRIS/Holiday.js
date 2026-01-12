
//////**************** Date Settings *************///
$(document).ready(function () {

    /////************** Date number Count  1st Line************//////////////////////
    $('#txt_DecDateTime').change(function () { LoadAllHolidayCompanyWise(); });
   
    $('#txt_NumDays,#txt_leave_reason').click(function () { days(); });


    $("#txt_StartDate").datepicker({ dateFormat: 'dd/MM/yy',
        numberOfMonths: 2,
        onSelect: function (selected) {
            $("#txt_EndDate").datepicker("option", "minDate", selected);
        }
    });

    $("#txt_EndDate").datepicker({ dateFormat: 'dd/MM/yy',
        numberOfMonths: 2,
        onSelect: function (selected) {
            if ($.trim($("#txt_StartDate").val()) == '') {
                alert("Please Select a date in the field 'Date From' field first!!!");
                $("#txt_EndDate").val('');
            }
            $("#txt_StartDate").datepicker("option", "maxDate", selected);
            var join_date = new Date(selected);
            join_date.setDate(join_date.getDate() + 1);
            $("#txt_join_date").datepicker("option", "minDate", join_date); //joining date must be one day more than the LeaveUpto date
        }
    });

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblHolidayList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Holiday Data Available",
            "sZeroRecords": "No Holiday Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Holiday Type', sWidth: '14%', sClass: 'alignCenter' },
                    { sTitle: 'Declaretion Date', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'From Date', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'To Date.', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Number of Days', sWidth: '13%', sClass: 'alignCenter' },
                    { sTitle: 'Remarks', sWidth: '14%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '14%', sClass: 'alignCenter' },
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

            { title: "Delete HoliDay", cmd: "Delete", uiIcon: "", action: function (event, ui) {
                var lcl_ui64_HolidayMstCode = ui.target.attr('id');
                if (confirm("Are you sure you want to Delete this Holiday?") == true) {
                    $.ajax(
                {

                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/HRIS/HolidaySrevice.asmx/DeleteHoliday",
                    data: "{ IP_ui64_HolidayMasterCode:" + lcl_ui64_HolidayMstCode + " }", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {

                            DisplayInformation(WSReturn.Message.toString());
                            LoadAllHolidayCompanyWise();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
                }
                else {
                    return false;
                }

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

    /*************************************Ready function end**************************************/
    initializeSelect2('ddl_holidayName', '------ Select Employee ------', '25%');

});
/***************************************************************************/
$("#txt_DecDateTime").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0 });

/////************** Date number Count function ************//////////////////////

function days() {
    var d1 = $('#txt_StartDate').datepicker('getDate');
    var d2 = $('#txt_EndDate').datepicker('getDate');
    var diff = 0;
    if (d1 && d2) {
        var lastV = d2.getTime();
        var fastV = d1.getTime();
        var result = lastV - fastV;
        diff = result / 86400000 + 1;
    }
    $('#txt_NumDays').val(diff);
}


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
            var lcl_obj_HolidayMaster = new Object();
            
            lcl_obj_HolidayMaster.CompanyCode = trim($('#ddlCompany option:selected').val()); ;
          lcl_obj_HolidayMaster.DecDate = $("#txt_DecDateTime").val();
          lcl_obj_HolidayMaster.NumOfDays = $("#txt_NumDays").val();
          lcl_obj_HolidayMaster.StartDate = $("#txt_StartDate").val();
          lcl_obj_HolidayMaster.EndDate = $("#txt_EndDate").val();
          lcl_obj_HolidayMaster.Remarks = $("#txt_Remarks").val();
          lcl_obj_HolidayMaster.HolidayName = $("#ddl_holidayName").val();

       
            $.ajax(
                    {
                    
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/HolidaySrevice.asmx/SaveHolidayMaster",
                       // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_Obj_HolidayMaster:" + JSON.stringify(lcl_obj_HolidayMaster) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());
                                LoadAllHolidayCompanyWise();
                                return true;
                               
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

/*********************************** Load Holiday Data*******************************/
function LoadAllHolidayCompanyWise() {
    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val());
    var lcl_str_SerchDate = $.trim($('#txt_DecDateTime').val());
    //alert(lcl_str_DepartmentCode);
    if (lcl_str_CompanyCode == "0") {
        return;
    }
    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/HolidaySrevice.asmx/GetAllHoliday",
            data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + ",IP_str_SerchDate:" + JSON.stringify(lcl_str_SerchDate) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_HolidayList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_HolidayCode = 0;

                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllHolidayData = new Array();

                $.each(lcl_obj_HolidayList, function (index, lcl_obj_ExtendedAllHolidayData) {
                    //debugger;
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode] = new Array();
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][0] = lcl_obj_ExtendedAllHolidayData.HolidayName;
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][1] = FormatDate(lcl_obj_ExtendedAllHolidayData.DecDate); //$.datepicker.formatDate("mm/dd/yy", date);;
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][2] = FormatDate(lcl_obj_ExtendedAllHolidayData.StartDate);
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][3] = FormatDate(lcl_obj_ExtendedAllHolidayData.EndDate);
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][4] = lcl_obj_ExtendedAllHolidayData.NumOfDays;
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][5] = lcl_obj_ExtendedAllHolidayData.Remarks;
                    lcl_str_ExtendedAllHolidayData[lcl_i32_HolidayCode][6] = "<a id='hlnkContextMenu-" + lcl_i32_HolidayCode.toString() + "' rel='hlnkContextMenu" + lcl_i32_HolidayCode.toString() + "' class='ctx_mnu' href='#'><img id='" + lcl_obj_ExtendedAllHolidayData.HolidayMasterCode.toString() + "' src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_HolidayCode++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllHolidayData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
    }

    function FormatDate(jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)))
        var d = date.getDate(), m = date.getMonth() + 1, y;
        if (date.getFullYear) { y = date.getFullYear(); }
        else { y = 2000 + (date.getYear() % 100); }
        return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
    }