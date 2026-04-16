var GBL_WorkGroupOperationMaster = null;
var GBL_UpdateableWorkGroupOperationHistory = new Object();
var GBL_DeletableWorkGroupOperationHistory = new Object();
var GBL_InsertableWorkGroupOperationHistory = new Object();
$(document).ready(function () {
    ShowMessageBoard("Work Group Management Loaded");
    ShowOperationalDirection("<b>Direction : Select a WorkGroup | Select a Date | Press Synchroniser</b>");
    $("#txtWorkDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtDutyStartsAt").timepicker({ timeFormat: "hh:mm:ss TT" });
    $(".operational_command").prop("disabled", true);

    /***************************************************************************************************************************/

    $("#lnkSyncInclusion").on("click", function (event) {
        var lcl_b_ReturnValue = SyncWorkGroupInclusion(event);
        $("#lnkSyncInclusion").removeClass("command_button_enabled").addClass("command_button_disabled");
        $('#lnkSyncInclusion').unbind('click');
    });


    $("#lnkSyncRemoval").on("click", function (event) {
        var lcl_b_ReturnValue = SyncWorkGroupRemoval(event);
        return lcl_b_ReturnValue;
    });

    $("#lnkSyncAssessmentStatus").on("click", function (event) {
        var lcl_b_ReturnValue = SyncAssessmentStatus(event);
        return lcl_b_ReturnValue;
    });


    $("#btnUploadLogFile").click(function (evt) {
    });
    initializeSelect2('ddlWorkGroup', '------ Select WorkGroup ------', '25%');
    initializeSelect2('ddlOperationalStatus', '------ Select Operational Status ------', '25%');
    initializeSelect2('ddlDayAttribute', '------ Select Day Attribute ------', '25%');


});

function EmployeeListFileSelected(event) {
    event.preventDefault();
    //Activate the Upload file button
    $("#lnkUploadEmployeeFile").removeClass("command_button_disabled").addClass("command_button_enabled");
    $('#lnkUploadEmployeeFile').unbind('click');
    $('#lnkUploadEmployeeFile').bind('click', function (e) {
        UploadEmployeeList(event);
    })
}

function UploadEmployeeList(evt) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_WorkGroupCode = $("#ddlWorkGroup option:selected").val();
    var lcl_dt_Date = $("#txtWorkDate").val();

    var fileUpload = $("#fuUploadFile").get(0);
    var files = fileUpload.files;
    if (files.length == 0) {
        ShowInfoMessageBoard("Operational Error : No files have been selected to be uploaded!!!");
        return;
    }
    var data = new FormData();
    data.append("CompanyCode", lcl_ui64_CompanyCode);
    data.append("WorkGroupCode", lcl_ui64_WorkGroupCode);
    data.append("WorkDate", lcl_dt_Date);
    for (var i = 0; i < files.length; i++) {
        data.append(files[i].name, files[i]);
    }
    var options = {};
    options.url = gbl_URL_Root + "Uploaders/HRIS/EmployeeProfileGenerator.ashx";
    options.type = "POST";
    options.global = true,
        options.data = data;
    options.contentType = false;
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -2) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -3) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -4) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -5) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -6) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -7) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -8) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -9) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            var lcl_objLst_EmployeeProfile = lcl_obj_WSResponse.Data;
            var lcl_i32_EmployeeCounter = lcl_objLst_EmployeeProfile.length;
            var lcl_i32_Count = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblWorkgroupEmployee').appendGrid('removeRow', 0);
            }
            $.each(lcl_objLst_EmployeeProfile, function (index, lcl_obj_EmployeeProfile) {

                /****************************************************************************************************************************/
                //check if employee id already added to grid
                var lcl_i32_RowCount = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
                for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
                    var lcl_str_EmployeeIdTmp = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtEmployeeId', lcl_i32_Counter);
                    if (lcl_str_EmployeeIdTmp.toUpperCase() == lcl_obj_EmployeeProfile.EmployeeID.toUpperCase()) {
                        ShowErrorMessageBoard("The Employee with ID '" + lcl_obj_EmployeeProfile.EmployeeID + "' has already been included!!!");
                        return;
                    }
                }
                /****************************************************************************************************************************/

                $('#tblWorkgroupEmployee').appendGrid('appendRow', [
                    { txtEmployeeCode: lcl_obj_EmployeeProfile.EmployeeCode.toString(),
                        txtEmployeeId: lcl_obj_EmployeeProfile.EmployeeID.toString(),
                        txtEmployeeName: lcl_obj_EmployeeProfile.EmployeeName.toString(),
                        txtDesignation: lcl_obj_EmployeeProfile.Designation.Name.toString(),
                        txtDepartment: lcl_obj_EmployeeProfile.Department.Name.toString(),
                        ddlAssessmentStatus: 0,
                        txtWorkGroupOperationHistoryCode: 0,
                        txtWorkGroupOperationMasterCode: 0
                    }]);
            });
        }
        $("#lnkUploadEmployeeFile").removeClass("command_button_enabled").addClass("command_button_disabled");
        $('#lnkUploadEmployeeFile').unbind('click');
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    evt.preventDefault();

}



function SyncAssessmentStatus(event) {

    var lcl_objLst_UpdateableWorkGroupOperationHistory = new Array();
    lcl_i32_Counter = 0;
    for (key in GBL_UpdateableWorkGroupOperationHistory) {
        if (GBL_UpdateableWorkGroupOperationHistory.hasOwnProperty(key)) {
            lcl_objLst_UpdateableWorkGroupOperationHistory[lcl_i32_Counter] = GBL_UpdateableWorkGroupOperationHistory[key];
            lcl_i32_Counter++;
        }
    }

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/SynchronizeEmployeeAssessmentStatus";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_objLst_UpdateableWorkGroupOperationHistory: " + JSON.stringify(lcl_objLst_UpdateableWorkGroupOperationHistory) + "}";
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {


        var lcl_obj_WSResponse = result.d;
        $("#lnkSyncAssessmentStatus").removeClass("command_button_enabled").addClass("command_button_disabled");
        $('#lnkSyncAssessmentStatus').unbind('click');
        GBL_UpdateableWorkGroupOperationHistory = [];

        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //Refresh Controls
            ShowMessageBoard(lcl_obj_WSResponse.Message);

        }

    };

    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
    return false;
}

function SyncWorkGroupRemoval(event) {
    //Click Event for btnSyncRemoval Button
    var lcl_objLst_DeletableWorkGroupOperationHistory = new Array();
    lcl_i32_Counter = 0;
    for (key in GBL_DeletableWorkGroupOperationHistory) {
        if (GBL_DeletableWorkGroupOperationHistory.hasOwnProperty(key)) {
            lcl_objLst_DeletableWorkGroupOperationHistory[lcl_i32_Counter] = GBL_DeletableWorkGroupOperationHistory[key];
            lcl_i32_Counter++;
        }
    }

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/SynchronizeEmployeeRemoval";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_objLst_DeletableWorkGroupOperationHistory: " + JSON.stringify(lcl_objLst_DeletableWorkGroupOperationHistory) + "}";
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        $("#lnkSyncRemoval").removeClass("command_button_enabled").addClass("command_button_disabled");
        $('#lnkSyncRemoval').unbind('click');

        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //Refresh Controls
            GBL_DeletableWorkGroupOperationHistory = [];
            GBL_UpdateableWorkGroupOperationHistory = [];
            ShowMessageBoard(lcl_obj_WSResponse.Message);
        }
    };
    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    return false;
}

function SyncWorkGroupInclusion(event) {
    //Click Event for btnSyncRemoval Button
    var lcl_objLst_IncludedWorkGroupOperationHistory = new Array();
    lcl_i32_Counter = 0;
    for (key in GBL_InsertableWorkGroupOperationHistory) {
        if (GBL_InsertableWorkGroupOperationHistory.hasOwnProperty(key)) {
            lcl_objLst_IncludedWorkGroupOperationHistory[lcl_i32_Counter] = GBL_InsertableWorkGroupOperationHistory[key];
            lcl_i32_Counter++;
        }
    }

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/SynchronizeEmployeeInclusion";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_objLst_IncludedWorkGroupOperationHistory: " + JSON.stringify(lcl_objLst_IncludedWorkGroupOperationHistory) + "}";
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        $("#lnkSyncInclusion").removeClass("command_button_enabled").addClass("command_button_disabled");
        $('#lnkSyncInclusion').unbind('click');
        GBL_InsertableWorkGroupOperationHistory = [];

        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //Refresh Controls
            ShowMessageBoard(lcl_obj_WSResponse.Message);
        }
    };
    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    return false;
}

function GetWorkGroupByDate(event) {
    debugger;
    event.preventDefault();
    /*$("#ddlOperationalStatus").val(null).trigger('change');*/
    //$("#btnManage").prop("disabled", true);
    var lcl_ui64_WorkGroupCode = $("#ddlWorkGroup option:selected").val();
    var lcl_dt_Date = $("#txtWorkDate").val();
    $(".SyncRemoval").prop("disabled", true);
    $(".SyncAssessmentStatus").prop("disabled", true);
    $(".SyncInclusion").prop("disabled", true);
    $.ajax(
            {
                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                global: true,
                url: gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/GetWorkGroupDetailsByDate",
                data: "{IP_ui64_WorkGroupCode: " + lcl_ui64_WorkGroupCode + ",IP_dt_Date:" + JSON.stringify(lcl_dt_Date) + "}", //provide input for the getSM_PO method
                dataType: "json",
                success: function (response) {
                    var WSResponse = response.d;
                    if (WSResponse.ResponseCode == -1) {
                        ShowErrorMessageBoard(WSResponse.Message);
                        GBL_WorkGroupOperationMaster = null;
                        GBL_UpdateableWorkGroupOperationHistory = new Object();
                        GBL_DeletableWorkGroupOperationHistory = new Object();
                        GBL_InsertableWorkGroupOperationHistory = new Object();
                        ShowWorkGroupAttendanceSummery(GBL_WorkGroupOperationMaster);
                        $("#lnkAddEmployee").addClass("command_button_enabled").removeClass("command_button_disabled");
                        $('#lnkAddEmployee').unbind('click');
                        $('#lnkAddEmployee').bind('click', function (event) {
                            IncludeEmployeeToWorkGroup(event);
                        });
                        $("#lnkUploadLogFile").addClass("command_button_enabled").removeClass("command_button_disabled");
                        $('#lnkUploadLogFile').unbind('click');
                        $('#lnkUploadLogFile').bind('click', function (event) {
                            UploadEmployeeList(event);
                        });
                        $("#lnkSave").addClass("command_button_enabled").removeClass("command_button_disabled");
                        $('#lnkSave').unbind('click');
                        $('#lnkSave').bind('click', function (event) {
                            Save(event);
                        });
                    }

                    if (WSResponse.ResponseCode == -2) {
                        //alert("CONFIGURING");
                        ShowInfoMessageBoard(WSResponse.Message);
                        GBL_WorkGroupOperationMaster = null;
                        GBL_UpdateableWorkGroupOperationHistory = {};
                        GBL_DeletableWorkGroupOperationHistory = {};
                        GBL_InsertableWorkGroupOperationHistory = {};
                        $('#tblWorkgroupEmployee').appendGrid({
                            caption: 'Work Group Employees',
                            initRows: 1,
                            columns: [
                                        { name: 'txtEmployeeCode', display: 'Emp. Code', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                                        { name: 'txtEmployeeId', display: 'Emp. Id', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtEmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDesignation', display: 'Degn.', type: 'text', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDepartment', display: 'Dept.', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'ddlAssessmentStatus', type: 'select', display: 'Assmnt. Status', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Regular', 1: 'Late Arrival Requested', 2: 'Sick Leave Requested'} },
                                        { name: 'txtWorkGroupOperationHistoryCode', type: 'hidden', value: 1 },
                                        { name: 'txtWorkGroupOperationMasterCode', type: 'hidden', value: 1 },
                                        { name: 'RecordId', type: 'hidden', value: 0 }
                                        ],
                            hideButtons: {
                                remove: false,
                                removeLast: true,
                                insert: true,
                                append: true
                            },
                            rowDragging: true,
                            hideRowNumColumn: false,
                            afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
                                /*********************************************************************************************************************/
                                //Check If The row is a new inclusion in the grid
                                var lcl_ui64_WorkGroupOperationHistoryCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', addedRowIndex);
                                if (lcl_ui64_WorkGroupOperationHistoryCode == 0) {
                                    //New Employee Inclusion to WorkGroup
                                    //Mark Employee ID red
                                    var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                                    //$(lcl_ctrl_EmployeeId).css('background-color', 'red');
                                    $(lcl_ctrl_EmployeeId).css('border', '1px solid red');
                                }
                                else {
                                    //Display only
                                    var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                                    //$(lcl_ctrl_EmployeeId).css('background-color', 'green');
                                    $(lcl_ctrl_EmployeeId).css('border', '1px solid green');
                                }
                                /*********************************************************************************************************************/
                            }

                        });
                        HideData();
                        var lcl_str_HTMLDirection = "Direction : WprkGroup needs to be scheduled for the selected day->Do Following :";
                        lcl_str_HTMLDirection += "Select Start time | Enter duty duration | Upload CSV File Containing Ids of the employees designated to serve this WorkGroup!!!";
                        ShowOperationalDirection(lcl_str_HTMLDirection);
                        $('#dvWorkgroupEmployee').show('slow');
                        ShowWorkGroupAttendanceSummery(GBL_WorkGroupOperationMaster);
                        $("#lnkAddEmployee").addClass("command_button_enabled").removeClass("command_button_disabled");
                        $('#lnkAddEmployee').unbind('click');
                        $('#lnkAddEmployee').bind('click', function (event) {
                            IncludeEmployeeToWorkGroup(event);
                        });
                        $("#fuUploadFile").prop("disabled", false);
                        $("#lnkSave").addClass("command_button_enabled").removeClass("command_button_disabled");
                        $('#lnkSave').unbind('click');
                        $('#lnkSave').bind('click', function (event) {
                            Save(event);
                        });
                    }
                    if (WSResponse.ResponseCode == -3) {
                        //WorkGroup Configured but no employee assigned to work in the group
                        ShowInfoMessageBoard(WSResponse.Message);
                        //GBL_WorkGroupOperationMaster = new Object();
                        GBL_WorkGroupOperationMaster = WSResponse.Data;
                        GBL_WorkGroupOperationMaster.WorkDate = $("#txtWorkDate").val();
                        GBL_UpdateableWorkGroupOperationHistory = new Object();
                        GBL_DeletableWorkGroupOperationHistory = new Object();
                        GBL_InsertableWorkGroupOperationHistory = new Object();
                        var lcl_str_HTMLDirection = "Direction : WprkGroup Scheduled | Assign Employees->Do Following :";
                        lcl_str_HTMLDirection += "Upload CSV File Containing Ids of the employees designated to serve this WorkGroup OR Include Employees one by one!!!";
                        ShowOperationalDirection(lcl_str_HTMLDirection);
                        ShowWorkGroupAttendanceSummery(GBL_WorkGroupOperationMaster);
                    }
                    if (WSResponse.ResponseCode == 0) {
                        ShowInfoMessageBoard(WSResponse.Message);
                        //GBL_WorkGroupOperationMaster = new Object();
                        $('#dvWorkgroupEmployee').hide('slow');
                        GBL_WorkGroupOperationMaster = WSResponse.Data;
                        GBL_WorkGroupOperationMaster.WorkDate = $("#txtWorkDate").val();
                        GBL_UpdateableWorkGroupOperationHistory = new Object();
                        GBL_DeletableWorkGroupOperationHistory = new Object();
                        GBL_InsertableWorkGroupOperationHistory = new Object();


                        $("#ddlOperationalStatus").val(null).trigger('change');
                        if (GBL_WorkGroupOperationMaster.IsAttendanceProcessed == 1) {
                            debugger;
                            $("#ddlOperationalStatus").val(GBL_WorkGroupOperationMaster.OperationalStatus).trigger('change');
                            $("#ddlDayAttribute").val(GBL_WorkGroupOperationMaster.DayAttribute);
                            $("#txtDutyStartsAt").val(GBL_WorkGroupOperationMaster.DutyStartFrom);
                            $("#txtDutyHour").val(GBL_WorkGroupOperationMaster.DutyHour);
                            $("#txtOvertimeLimit").val(GBL_WorkGroupOperationMaster.OvertimeLimit);

                            $("#txtTotalPresent").val(GBL_WorkGroupOperationMaster.TotalPresent);
                            $("#txtTotalAbsent").val(GBL_WorkGroupOperationMaster.TotalAbsent);
                            $("#txtTotalLate").val(GBL_WorkGroupOperationMaster.TotalLate);
                            $("#txtTotalLeave").val(GBL_WorkGroupOperationMaster.TotalLeave);
                            $("#txtTotalManHour").val((GBL_WorkGroupOperationMaster.TotalManHour / 60).toString());
                            $("#txtTotalOvertime").val((GBL_WorkGroupOperationMaster.TotalOvertime / 60).toString());
                            //YES-ATTENDANCE HAS BEEN PROCESSED
                            //CONFIGURE READ ONLY
                            /********************************************************************************************************************************/
                            //CONFIGURE APPENDROW
                            $('#tblWorkgroupEmployee').appendGrid({
                                caption: 'Work Group Employees',
                                initRows: 0,
                                columns: [
                                        { name: 'txtEmployeeCode', display: 'Emp. Code', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                                        { name: 'txtEmployeeId', display: 'Emp. Id', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtEmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDesignation', display: 'Degn.', type: 'text', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDepartment', display: 'Dept.', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'ddlAssessmentStatus', type: 'select', display: 'Assmnt. Status', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Regular', 1: 'Late Arrival Requested', 2: 'Sick Leave Requested'} },
                                        { name: 'txtWorkGroupOperationHistoryCode', type: 'hidden', value: 1 },
                                        { name: 'txtWorkGroupOperationMasterCode', type: 'hidden', value: 1 },
                                        { name: 'RecordId', type: 'hidden', value: 0 }
                                        ],
                                hideButtons: {
                                    remove: true,
                                    removeLast: true,
                                    insert: true,
                                    append: true
                                },
                                rowDragging: true,
                                hideRowNumColumn: false,
                                afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
                                    /*********************************************************************************************************************/
                                    //DISABLE THE ASSESSMENT STATUS OF THE EMPLOYEE
                                    var lcl_ctrl_AssessmentStatus = $(caller).appendGrid('getCellCtrl', 'ddlAssessmentStatus', addedRowIndex);
                                    var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                                    //                                    $(lcl_ctrl_EmployeeId).css('background-color', 'gray');
                                    $(lcl_ctrl_EmployeeId).css('border', '1px solid gray');
                                    $(lcl_ctrl_AssessmentStatus).prop("disabled", true);

                                    /*********************************************************************************************************************/
                                }
                            });

                            //INPUT DATA INTO THE GRID
                            $.each(GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection, function (index, lcl_obj_WorkGroupOperationHistory) {

                                /****************************************************************************************************************************/
                                $('#tblWorkgroupEmployee').appendGrid('appendRow', [
                                    { txtEmployeeCode: lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeCode.toString(),
                                        txtEmployeeId: lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeID.toString(),
                                        txtEmployeeName: lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeName.toString(),
                                        txtDesignation: lcl_obj_WorkGroupOperationHistory.EmployeeProfile.Designation.Name.toString(),
                                        txtDepartment: lcl_obj_WorkGroupOperationHistory.EmployeeProfile.Department.Name.toString(),
                                        ddlAssessmentStatus: lcl_obj_WorkGroupOperationHistory.AssessmentStatus,
                                        txtWorkGroupOperationHistoryCode: lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode,
                                        txtWorkGroupOperationMasterCode: lcl_obj_WorkGroupOperationHistory.WorkGroupOperationMasterCode
                                    }
                                  ]);
                                $('#tblWorkgroupEmployee').appendGrid('setCtrlValue', 'ddlAssessmentStatus', index, lcl_obj_WorkGroupOperationHistory.AssessmentStatus);
                                //lcl_i32_EmployeeNumber++;
                            });
                            $("#lnkAddEmployee").removeClass("command_button_enabled").addClass("command_button_disabled");
                            $('#lnkAddEmployee').unbind('click');
                            $("#fuUploadFile").prop("disabled", true);
                            $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
                            $('#lnkSave').unbind('click');
                            $("#ddlDayAttribute").prop("disabled", true);
                            $("#ddlOperationalStatus").prop("disabled", true);
                            $('#dvWorkgroupEmployee').show('slow');
                            var lcl_str_HTMLDirection = "Direction : WorkGroups attendance has been processed | You are not allowed to edit any aspect!!!Read only mode enabled.";
                            //lcl_str_HTMLDirection += "Select Start time | Enter duty duration | Upload CSV File Containing Ids of the employees designated to serve this WorkGroup!!!";
                            ShowOperationalDirection(lcl_str_HTMLDirection);
                            ShowWorkGroupAttendanceSummery(GBL_WorkGroupOperationMaster);
                            return;
                        }

                        if (GBL_WorkGroupOperationMaster.IsAttendanceProcessed == 0) {
                            //NO-ATTENDANCE HAS NOT BEEN PROCESSED
                            //CONFIGURE READ/WRITE/EDIT ONLY
                            //DisplayError(WSResponse.Message);
                            /********************************************************************************************************************************/
                            //Config AppendGrid with RemoveButton
                            //CONFIGURE APPENDROW
                            $("#ddlOperationalStatus").val(GBL_WorkGroupOperationMaster.OperationalStatus).trigger('change');
                            $("#ddlDayAttribute").val(GBL_WorkGroupOperationMaster.DayAttribute);
                            $("#txtDutyStartsAt").val(GBL_WorkGroupOperationMaster.DutyStartFrom);
                            $("#txtDutyHour").val(GBL_WorkGroupOperationMaster.DutyHour);
                            $("#txtOvertimeLimit").val(GBL_WorkGroupOperationMaster.OvertimeLimit);
                            $('#tblWorkgroupEmployee').appendGrid({
                                caption: 'Work Group Employees',
                                initRows: 0,
                                columns: [
                                         { name: 'txtEmployeeCode', display: 'Emp. Code', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                                        { name: 'txtEmployeeId', display: 'Emp. Id', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtEmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDesignation', display: 'Degn.', type: 'text', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'txtDepartment', display: 'Dept.', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'ddlAssessmentStatus', type: 'select', display: 'Assmnt. Status', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Regular', 1: 'Late Arrival Requested', 2: 'Sick Leave Requested' },
                                            onChange: function (evt, rowIndex) {
                                                // alert('You have changed value of Album at row ' + rowIndex);
                                                var lcl_str_WorkGroupOperationMasterCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtWorkGroupOperationMasterCode', rowIndex);
                                                var lcl_str_WorkGroupOperationHistoryCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex);
                                                if ((lcl_str_WorkGroupOperationMasterCode == "0") || (lcl_str_WorkGroupOperationHistoryCode == "0")) {
                                                    //New Addition. No need to track update
                                                    return;
                                                }
                                                //EDIT
                                                //Add WorkGroupOperationHistory object to Updateable list
                                                var lcl_str_Key = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex).toString();
                                                GBL_UpdateableWorkGroupOperationHistory[lcl_str_Key.toString()] = new Object();
                                                GBL_UpdateableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeWorkGroupHistoryCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex);
                                                GBL_UpdateableWorkGroupOperationHistory[lcl_str_Key.toString()].WorkGroupOperationMasterCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtWorkGroupOperationMasterCode', rowIndex);
                                                GBL_UpdateableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtEmployeeCode', rowIndex);
                                                GBL_UpdateableWorkGroupOperationHistory[lcl_str_Key.toString()].AssessmentStatus = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'ddlAssessmentStatus', rowIndex);
                                               
                                                $("#lnkSyncAssessmentStatus").removeClass("command_button_disabled").addClass("command_button_enabled");
                                                $('#lnkSyncAssessmentStatus').unbind('click');
                                                $("#lnkSyncAssessmentStatus").on("click", function (event) {
                                                    var lcl_b_ReturnValue = SyncAssessmentStatus(event);
                                                    return lcl_b_ReturnValue;
                                                });
                                                var lcl_str_HTMLDirection = "Direction : You have requested Assessment Status of a Personnel!Please sync WorkGroup to have effect.->Press 'Sync Status' button.";
                                                ShowOperationalDirection(lcl_str_HTMLDirection);
                                            }
                                        },
                                        { name: 'txtWorkGroupOperationHistoryCode', type: 'hidden', value: 1 },
                                        { name: 'txtWorkGroupOperationMasterCode', type: 'hidden', value: 1 },
                                        { name: 'RecordId', type: 'hidden', value: 0 }
                                        ],
                                hideButtons: {
                                    remove: false,
                                    removeLast: true,
                                    insert: true,
                                    append: true
                                },
                                rowDragging: true,
                                beforeRowRemove: function (caller, rowIndex) {
                                    if (confirm('Are you sure to remove this Employee From the Assigned WorkGroup?')) {
                                        var lcl_str_WorkGroupOperationMasterCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationMasterCode', rowIndex);
                                        var lcl_str_WorkGroupOperationHistoryCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex);
                                        //alert(lcl_str_WorkGroupOperationHistoryCode);
                                        if ((lcl_str_WorkGroupOperationMasterCode == "0") || (lcl_str_WorkGroupOperationHistoryCode == "0")) {
                                            //New Addition. No need to track delete
                                            return true;
                                        }
                                        //EDIT
                                        //Add WorkGroupOperationHistory object to Updateable list
                                        var lcl_str_Key = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex).toString();
                                        GBL_DeletableWorkGroupOperationHistory[lcl_str_Key.toString()] = new Object();
                                        GBL_DeletableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeWorkGroupHistoryCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', rowIndex);
                                        GBL_DeletableWorkGroupOperationHistory[lcl_str_Key.toString()].WorkGroupOperationMasterCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationMasterCode', rowIndex);
                                        GBL_DeletableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeCode = $(caller).appendGrid('getCtrlValue', 'txtEmployeeCode', rowIndex);
                                        GBL_DeletableWorkGroupOperationHistory[lcl_str_Key.toString()].AssessmentStatus = $(caller).appendGrid('getCtrlValue', 'ddlAssessmentStatus', rowIndex);
                                        $(".SyncRemoval").prop("disabled", false);
                                        $("#lnkSyncRemoval").removeClass("command_button_disabled").addClass("command_button_enabled");
                                        $('#lnkSyncRemoval').unbind('click');
                                        $('#lnkSyncRemoval').bind('click', function (event) {
                                            var lcl_b_ReturnValue = SyncWorkGroupRemoval(event);
                                        });

                                        var lcl_str_HTMLDirection = "Direction : You have requested a removal of an employee from this schedule!Please sync WorkGroup to have effect.->Press 'Sync Removal' button.";
                                        ShowOperationalDirection(lcl_str_HTMLDirection);
                                        return true;
                                    }
                                    return false;
                                },
                                afterRowRemoved: function (caller, rowIndex) {
                                },
                                hideRowNumColumn: false,
                                afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
                                    /*********************************************************************************************************************/
                                    //Check If The row is a new inclusion in the grid
                                    var lcl_ui64_WorkGroupOperationHistoryCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', addedRowIndex);
                                    if (lcl_ui64_WorkGroupOperationHistoryCode == 0) {
                                        //New Employee Inclusion to WorkGroup
                                        //Mark Employee ID red
                                        var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                                        $(lcl_ctrl_EmployeeId).css('border', '1px solid red');
                                        //NEW INSERTION INTO THE GROUP
                                        var lcl_str_Key = $(caller).appendGrid('getCtrlValue', 'txtEmployeeCode', addedRowIndex).toString();
                                        GBL_InsertableWorkGroupOperationHistory[lcl_str_Key.toString()] = new Object();
                                        GBL_InsertableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeWorkGroupHistoryCode = 0; //Not yet saved..so 0
                                        GBL_InsertableWorkGroupOperationHistory[lcl_str_Key.toString()].WorkGroupOperationMasterCode = GBL_WorkGroupOperationMaster.WorkGroupOperationMasterCode;
                                        GBL_InsertableWorkGroupOperationHistory[lcl_str_Key.toString()].EmployeeCode = $(caller).appendGrid('getCtrlValue', 'txtEmployeeCode', addedRowIndex);
                                        GBL_InsertableWorkGroupOperationHistory[lcl_str_Key.toString()].AssessmentStatus = $(caller).appendGrid('getCtrlValue', 'ddlAssessmentStatus', addedRowIndex);
                                        $(".SyncInclusion").prop("disabled", false);
                                        var lcl_str_HTMLDirection = "Direction : You have requested inclusion of an employee for this schedule!Please sync WorkGroup to have effect.->Press 'Sync Inclusion' button.";
                                        ShowOperationalDirection(lcl_str_HTMLDirection);
                                    }
                                    else {
                                        //Display only
                                        var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                                        $(lcl_ctrl_EmployeeId).css('border', '1px solid gray');
                                    }
                                    /*********************************************************************************************************************/
                                }
                            });
                            //INPUT DATA INTO THE GRID
                            var lcl_objLst_Data = new Array();
                            $.each(GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection, function (index, lcl_obj_WorkGroupOperationHistory) {
                                lcl_objLst_Data[index] = new Object();
                                lcl_objLst_Data[index].txtEmployeeCode = lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeCode.toString();
                                lcl_objLst_Data[index].txtEmployeeId = lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeID.toString();
                                lcl_objLst_Data[index].txtEmployeeName = lcl_obj_WorkGroupOperationHistory.EmployeeProfile.EmployeeName.toString();
                                lcl_objLst_Data[index].txtDesignation = lcl_obj_WorkGroupOperationHistory.EmployeeProfile.Designation.Name.toString();
                                lcl_objLst_Data[index].txtDepartment = lcl_obj_WorkGroupOperationHistory.EmployeeProfile.Department.Name.toString();
                                lcl_objLst_Data[index].ddlAssessmentStatus = parseInt(lcl_obj_WorkGroupOperationHistory.AssessmentStatus);
                                lcl_objLst_Data[index].txtWorkGroupOperationHistoryCode = lcl_obj_WorkGroupOperationHistory.EmployeeWorkGroupHistoryCode;
                                lcl_objLst_Data[index].txtWorkGroupOperationMasterCode = lcl_obj_WorkGroupOperationHistory.WorkGroupOperationMasterCode;
                                /****************************************************************************************************************************/
                            });



                            $("#lnkAddEmployee").addClass("command_button_enabled").removeClass("command_button_disabled");
                            $('#lnkAddEmployee').unbind('click');
                            $('#lnkAddEmployee').bind('click', function (event) {
                                IncludeEmployeeToWorkGroup(event);
                            });
                            $("#lnkUploadLogFile").removeClass("command_button_enabled").addClass("command_button_disabled");
                            $('#lnkUploadLogFile').unbind('click');
                            $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
                            $('#lnkSave').unbind('click');

                            $('#tblWorkgroupEmployee').appendGrid('load', lcl_objLst_Data);
                            var lcl_str_HTMLDirection = "Direction : WorkGroups Scheduled| You can do : Change Start Time | Change Day Attribute | Change Operational Status | Change Employee Assessment Status | Remove Employee | Add Employee";
                            //lcl_str_HTMLDirection += "Select Start time | Enter duty duration | Upload CSV File Containing Ids of the employees designated to serve this WorkGroup!!!";
                            ShowOperationalDirection(lcl_str_HTMLDirection);
                            ShowWorkGroupAttendanceSummery(GBL_WorkGroupOperationMaster);
                        }
                        $('#dvWorkgroupEmployee').show('slow');
                        /********************************************************************************************************************************/
                        return;
                    }
                }
            });
}

function IncludeEmployeeToWorkGroup(event) {
    //alert('1');
    event.preventDefault();
    //alert('1');
    var lcl_str_EmployeeId = $('#txtNewEmployee').val();
    //alert('2');
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    //alert('3');
    var lcl_dt_WorkDate = $('#txtWorkDate').val();
    /****************************************************************************************************************************/
    //check if employee id already added to grid
    var lcl_i32_RowCount = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
    for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
        var lcl_str_EmployeeIdTmp = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtEmployeeId', lcl_i32_Counter);
        if (lcl_str_EmployeeIdTmp.toUpperCase() == lcl_str_EmployeeId.toUpperCase()) {
            ShowErrorMessageBoard("The Employee with ID '" + lcl_str_EmployeeId + "' has already been included!!!");
            return;
        }
    }
    /****************************************************************************************************************************/

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/CheckEmployeeProfileAndWorkGroupSchedule";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_WorkDate:'" + lcl_dt_WorkDate + "',IP_str_EmployeeId:'" + lcl_str_EmployeeId + "'}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -2) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -3) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -4) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -5) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -6) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -7) {
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_obj_EmployeeProfile = lcl_obj_WSResponse.Data;
            $('#tblWorkgroupEmployee').appendGrid('appendRow', [
                    { txtEmployeeCode: lcl_obj_EmployeeProfile.EmployeeCode.toString(),
                        txtEmployeeId: lcl_obj_EmployeeProfile.EmployeeID.toString(),
                        txtEmployeeName: lcl_obj_EmployeeProfile.EmployeeName.toString(),
                        txtDesignation: lcl_obj_EmployeeProfile.Designation.Name.toString(),
                        txtDepartment: lcl_obj_EmployeeProfile.Department.Name.toString(),
                        ddlAssessmentStatus: 0,
                        txtWorkGroupOperationHistoryCode: 0,
                        txtWorkGroupOperationMasterCode: 0
                    }]);
            $("#lnkSyncInclusion").removeClass("command_button_disabled").addClass("command_button_enabled");
            $('#lnkSyncInclusion').unbind('click');
            $('#lnkSyncInclusion').bind('click');
            $("#lnkSyncInclusion").on("click", function (event) {
                var lcl_b_ReturnValue = SyncWorkGroupInclusion(event);
            });
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
    //evt.preventDefault();
}

function Save(event) {
    event.preventDefault();
    //alert("SAVING");
    if (GBL_WorkGroupOperationMaster == null) {
        GBL_WorkGroupOperationMaster = new Object();
        GBL_WorkGroupOperationMaster.WorkGroupCode = $("#ddlWorkGroup option:selected").val();
        GBL_WorkGroupOperationMaster.WorkGroupOperationMasterCode = 0; //To be filled after inserting.Indicates SAVE Operation
        GBL_WorkGroupOperationMaster.WorkerStrength = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
        GBL_WorkGroupOperationMaster.WorkDate = $("#txtWorkDate").val();
        GBL_WorkGroupOperationMaster.TotalPresent = 0;
        GBL_WorkGroupOperationMaster.TotalLate = 0;
        GBL_WorkGroupOperationMaster.TotalAbsent = 0;
        GBL_WorkGroupOperationMaster.OperationalStatus = $("#ddlOperationalStatus option:selected").val();
        GBL_WorkGroupOperationMaster.IsAttendanceProcessed = 0;
        GBL_WorkGroupOperationMaster.IsSalaryProcessed = 0;
        GBL_WorkGroupOperationMaster.DutyStartFrom = $.trim($("#txtDutyStartsAt").val());
        GBL_WorkGroupOperationMaster.DutyHour = $.trim($("#txtDutyHour").val());
        GBL_WorkGroupOperationMaster.OvertimeLimit = $.trim($("#txtOvertimeLimit").val());
        GBL_WorkGroupOperationMaster.DayAttribute = $("#ddlDayAttribute option:selected").val();
        GBL_WorkGroupOperationMaster.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();

        /**************************************************************************************************************/
        //For OnLeaveGroup/OnForeignTour Group, DutyStartFrom = '' and DutyHour = 0
        if ((GBL_WorkGroupOperationMaster.DutyStartFrom == '') || (GBL_WorkGroupOperationMaster.DutyHour == '')) {
            DisplayError("The Field 'DutyStartFrom' Cannot be blank!!!");
            return;
        }
        /**************************************************************************************************************/

        //txtSignedInEmployeeCode
        //alert("MSTR OB CREATED");
        GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = new Array();
        for (var i = 0; i < GBL_WorkGroupOperationMaster.WorkerStrength; i++) {
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i] = new Object();
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtEmployeeCode', i);
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeWorkGroupHistoryCode = 0;
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].WorkGroupOperationMasterCode = 0; //to be set in server
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].AssessmentStatus = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'ddlAssessmentStatus', i);
            GBL_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeProfile = null;
        }
        //alert("OP MSTR CONFIGURED");
        //alert( JSON.stringify(GBL_WorkGroupOperationMaster));
        var options = {};
        options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/SaveWorkGroupOperationMaster";
        options.dataType = "json";
        options.type = "POST";
        options.data = "{IP_obj_WorkGroupOperationMaster: " + JSON.stringify(GBL_WorkGroupOperationMaster) + "}"; // JSON.stringify(lcl_obj_LogFile);
        options.contentType = "application/json; charset=utf-8";
        options.success = function (result) {
            var lcl_obj_WSResponse = result.d;

            if (lcl_obj_WSResponse.ResponseCode == -100) {
                //SYSTEM EXCEPTION
                DisplayError(lcl_obj_WSResponse.Message);
                return;
            }
            if (lcl_obj_WSResponse.ResponseCode == 0) {
                //ALL OK
                //Refresh Controls
                GetWorkGroupByDate(event);
                $("#lnkAddEmployee").removeClass("command_button_enabled").addClass("command_button_disabled");
                $('#lnkAddEmployee').unbind('click');
                $("#lnkUploadLogFile").removeClass("command_button_enabled").addClass("command_button_disabled");
                $('#lnkUploadLogFile').unbind('click');
                $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
                $('#lnkSave').unbind('click');
                ShowMessageBoard(lcl_obj_WSResponse.Message);
            }
        };

        options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

        $.ajax(options);

    }
}




function ShowWorkGroupAttendanceSummery(IP_obj_WorkGroupOperationMaster) {
    var lcl_str_HTML = "";
    if (IP_obj_WorkGroupOperationMaster == null) {
        lcl_str_HTML = "";
    }
    else {
        lcl_str_HTML = "<table><tr><td>";
        lcl_str_HTML += "<b>Total Strength :</b>" + IP_obj_WorkGroupOperationMaster.WorkerStrength;
        lcl_str_HTML += " | <b>Total Present : </b>" + IP_obj_WorkGroupOperationMaster.TotalPresent;
        lcl_str_HTML += " | <b>Total Absent :</b> " + IP_obj_WorkGroupOperationMaster.TotalAbsent;
        lcl_str_HTML += " | <b>Total Late : </b>" + IP_obj_WorkGroupOperationMaster.TotalLate;
        lcl_str_HTML += " | <b>Total On Leave : </b>" + IP_obj_WorkGroupOperationMaster.TotalLeave;
        lcl_str_HTML += " | <b>Total Off : </b>" + IP_obj_WorkGroupOperationMaster.TotalOff;
        if (IP_obj_WorkGroupOperationMaster.IsAttendanceProcessed == 0) {
            //$("#txtAttnProcessingStatus").val("NOT PROCESSED");
            lcl_str_HTML += "<br/><b>ATTENDANCE NOT YET PROCESSED</b>";
        }
        else {
            lcl_str_HTML += "<br/><b>ATTENDANCE PROCESSED</b>";
        }
        if (IP_obj_WorkGroupOperationMaster.IsSalaryProcessed == 0) {
            lcl_str_HTML += " | <b>NOT YET PROCESSED FOR SALARY</b>";
        }
        else {
            lcl_str_HTML += " | <b>PROCESSED FOR SALARY</b>";
        }
        lcl_str_HTML += "</td></tr></table>";
    }
    ShowData(lcl_str_HTML);
}

function ShowData(HtmlData) {
    $('#dvData').hide('slow', function () {
        $('#dvData').html(HtmlData);
        $('#dvData').show('slow');
    });
}

function HideData() {
    $('#dvData').hide('slow', function () {
        $('#dvData').html("");
    });
}

function ShowOperationalDirection(HtmlMessage) {
    $('#dvNotification').hide('slow', function () {
        $("#dvNotification").html(HtmlMessage);
        $('#dvNotification').show('slow');
    });
}