$(document).ready(function () {
    $("#txtUptoDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, minDate: "+1D", maxDate: "+365D" });
    $("#txtFromDate").datepicker({ dateFormat: 'dd/MM/yy', showButtonPanel: true, minDate: "+1D", maxDate: "+365D",
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            $("#txtUptoDate").datepicker('option', 'minDate', d);
        }
    });


    $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");


    $('#tblEmployees').appendGrid({
        caption: 'Employees',
        initRows: 0,
        columns: [
                        {name: 'txtEmployeeCode', display: 'Emp. Code', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                        { name: 'txtEmployeeId', display: 'Emp. Id', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                        { name: 'txtEmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                        { name: 'txtDepartment', display: 'Dept.', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                        { name: 'txtDesignation', display: 'Degn.', type: 'text', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                        { name: 'ddlWeekendDay', type: 'select', display: 'Weekend Day', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'None', 1: 'Saturday', 2: 'Sunday', 3: 'Monday', 4: 'Tuesday', 5: 'Wednesday', 6: 'Thursday', 7: 'Friday'} },
                        { name: 'RecordId', type: 'hidden', value: 0, }
                        ],
        hideButtons: {
            remove: true,
            removeLast: true,
            insert: true,
            append: true
        },
        customRowButtons: [
            {
                uiButton: { icons: { primary: 'ui-icon-disk' }, text: false },
                click: function (evtObj, uniqueIndex, rowData) {
                    var lcl_str_EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();
                    var lcl_str_EmployeeCode = rowData["txtEmployeeCode"];
                    var lcl_str_EmployeeId = rowData["txtEmployeeId"];
                    var lcl_i32_WeekendDay = rowData["ddlWeekendDay"];
                    if (lcl_i32_WeekendDay == 0) {
                        DisplayError("Please Select a Weekend Day!!!");
                        return;
                    }

                    var lcl_dt_DateFrom = $("#txtFromDate").val();
                    var lcl_dt_DateUpto = $("#txtUptoDate").val();

                    //var lcl_obj_EmployeeWeekend = new Object();


                    var lcl_objArr_EmployeeWeekends = new Array();
                    lcl_objArr_EmployeeWeekends[0] = new Object();
                    lcl_objArr_EmployeeWeekends[0].EmployeeCode = lcl_str_EmployeeCode;
                    lcl_objArr_EmployeeWeekends[0].EmployeeId = lcl_str_EmployeeId;
                    lcl_objArr_EmployeeWeekends[0].WeekDayName = lcl_i32_WeekendDay;


                    var options = {};
                    options.url = gbl_URL_Root + "WebServices/HRIS/WeekendManagementService.asmx/UpdateEmployeeWeekend";
                    options.dataType = "json";
                    options.type = "POST";
                    options.data = "{IP_ui64_EntryEmployeeCode : " + lcl_str_EntryEmployeeCode + ",IP_dt_FromDate:'" + lcl_dt_DateFrom + "',IP_dt_UptoDate:'" + lcl_dt_DateUpto + "',IP_objLst_EmployeeAssignedWeekend:" + JSON.stringify(lcl_objArr_EmployeeWeekends) + "}"; // JSON.stringify(lcl_obj_LogFile);
                    options.contentType = "application/json; charset=utf-8";
                    //options.processData = false;
                    options.success = function (result) {
                        var lcl_obj_WSResponse = result.d;
                        if (lcl_obj_WSResponse.ResponseCode < 0) {
                            DisplayError(lcl_obj_WSResponse.Message);
                            return;
                        }
                        if (lcl_obj_WSResponse.ResponseCode == 1) {
                            DisplayInformation(lcl_obj_WSResponse.Message);
                            return;
                        }
                        if (lcl_obj_WSResponse.ResponseCode == 0) {
                            DisplaySuccess(lcl_obj_WSResponse.Message);
                            //DisplayLeaveProfile();
                        }
                    };

                    options.error = function (err) { DisplayError(err.statusText); };

                    $.ajax(options);
                }, btnCss: { 'min-width': '20px' },
                btnAttr: { title: 'Update Weekend Day' }, atTheFront: true
            }
        ],
        rowDataLoaded: function (caller, record, rowIndex, uniqueIndex) {
        },
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
});

function GetAllEmployees(event) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    
    var lcl_dt_DateFrom = $("#txtFromDate").val();
    var lcl_dt_DateUpto = $("#txtUptoDate").val();
    if ((lcl_dt_DateFrom == '') || (lcl_dt_DateUpto == '')) {
        DisplayError("The Fields 'Date From' & 'Date Upto' must be filled before uploading the file!!!");
        return;
    }

    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: "~/../../../WebServices/HRIS/EmployeeService.asmx/GetEmployeeMiniProfileListByCompany",
            data: "{IP_ui64_CompanyCode:" + JSON.stringify(lcl_ui64_CompanyCode) + "}", //provide input for the getSM_PO method
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
                // GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                //GBL_EMPLOYEE_LIST_TABLE.fnDestroy();
                var lcl_str_EmployeeData = new Array();
                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                    $('#tblEmployees').appendGrid('appendRow', [
                    { txtEmployeeCode: lcl_obj_EmployeeProfile.EmployeeCode.toString(),
                        txtEmployeeId: lcl_obj_EmployeeProfile.EmployeeID.toString(),
                        txtEmployeeName: lcl_obj_EmployeeProfile.EmployeeName.toString(),
                        txtDesignation: lcl_obj_EmployeeProfile.Designation.toString(),
                        txtDepartment: lcl_obj_EmployeeProfile.DepartmentName.toString(),
                        ddlWeekendDay: $("#ddlWeekday option:selected").val()
                        
                        
                    }]);

                    lcl_i32_EmployeeNumber++;
                });
 
            }
        });
}

function GetEmployee(event) {
    alert("GET EMPLOYEE");
}

function EmployeeListFileSelected(event) {
    event.preventDefault();
    //Activate the Upload file button
    $("#lnkUploadEmployeeFile").removeClass("command_button_disabled").addClass("command_button_enabled");
    $('#lnkUploadEmployeeFile').bind('click', function (e) {
        //e.preventDefault();
        UploadEmployeeList(event);
    })
}

function UploadEmployeeList(evt) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_WorkGroupSelectedIndex = $("#ddlWorkGroup option:selected").index();
    if (lcl_ui64_WorkGroupSelectedIndex == 0) {
        DisplayError("A 'WorkGroup' must be selected before uploading the 'Employee' file!!!");
        return;
    }
    var lcl_ui64_WorkGroupCode = $("#ddlWorkGroup option:selected").val();
    var lcl_dt_DateFrom = $("#txtWorkDateFrom").val();
    var lcl_dt_DateUpto = $("#txtWorkDateUpto").val();
    if ((lcl_dt_DateFrom == '') || (lcl_dt_DateUpto == '')) {
        DisplayError("The Fields 'WorkDate (From)' & 'WorkDate (Upto)' must be filled before uploading the file!!!");
        return;
    }


    var fileUpload = $("#fuUploadFile").get(0);
    //alert(fileUpload);
    var files = fileUpload.files;
    if (files.length == 0) {
        DisplayError("Operational Error : No files have been selected to be uploaded!!!");
        return;
    }
    var data = new FormData();
    data.append("CompanyCode", lcl_ui64_CompanyCode);
    data.append("WorkGroupCode", lcl_ui64_WorkGroupCode);
    data.append("WorkDateFrom", lcl_dt_DateFrom);
    data.append("WorkDateUpto", lcl_dt_DateUpto);
    for (var i = 0; i < files.length; i++) {
        //alert(files[i].name);
        data.append(files[i].name, files[i]);
    }
    var options = {};
    options.url = gbl_URL_Root + "Uploaders/HRIS/EmployeeProfileGeneratorForWorkGroupByDateRange.ashx";
    options.type = "POST";
    options.global = true,
        options.data = data; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = false;
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result;
        //var lcl_obj_ResponseObject = lcl_obj_WSResponse.Data;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -2) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -3) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -4) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -5) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -6) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -7) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -8) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -9) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
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
            $('#dvWorkgroupEmployee').show('slow');
            $("#lnkSave").removeClass("command_button_disabled").addClass("command_button_enabled");
            $('#lnkSave').bind('click', function (event) {
                Save(event);
            });
            $("#lnkUploadEmployeeFile").removeClass("command_button_enabled").addClass("command_button_disabled");
            $('#lnkUploadEmployeeFile').unbind('click');
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    evt.preventDefault();

}

function Save(event) {
    event.preventDefault();
    //alert("SAVING");
    var lcl_obj_WorkGroupOperationMaster = new Object();
    var lcl_dt_DateFrom = $("#txtWorkDateFrom").val();
    var lcl_dt_DateUpto = $("#txtWorkDateUpto").val();

    lcl_obj_WorkGroupOperationMaster.WorkGroupCode = $("#ddlWorkGroup option:selected").val();
    lcl_obj_WorkGroupOperationMaster.WorkGroupOperationMasterCode = 0; //To be filled after inserting.Indicates SAVE Operation
    lcl_obj_WorkGroupOperationMaster.WorkerStrength = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
    lcl_obj_WorkGroupOperationMaster.WorkDate = $("#txtWorkDate").val();
    lcl_obj_WorkGroupOperationMaster.TotalPresent = 0;
    lcl_obj_WorkGroupOperationMaster.TotalLate = 0;
    lcl_obj_WorkGroupOperationMaster.TotalAbsent = 0;
    lcl_obj_WorkGroupOperationMaster.OperationalStatus = $("#ddlOperationalStatus option:selected").val();
    lcl_obj_WorkGroupOperationMaster.IsAttendanceProcessed = 0;
    lcl_obj_WorkGroupOperationMaster.IsSalaryProcessed = 0;
    lcl_obj_WorkGroupOperationMaster.DutyStartFrom = $.trim($("#txtDutyStartsAt").val());
    lcl_obj_WorkGroupOperationMaster.DutyHour = $.trim($("#txtDutyHour").val());
    lcl_obj_WorkGroupOperationMaster.OvertimeLimit = $.trim($("#txtOvertimeLimit").val());
    lcl_obj_WorkGroupOperationMaster.DayAttribute = $("#ddlDayAttribute option:selected").val();
    lcl_obj_WorkGroupOperationMaster.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();

    /**************************************************************************************************************/
    //For OnLeaveGroup/OnForeignTour Group, DutyStartFrom = '' and DutyHour = 0
    if ((lcl_obj_WorkGroupOperationMaster.DutyStartFrom == '') || (lcl_obj_WorkGroupOperationMaster.DutyHour == '')) {
        DisplayError("The Field 'DutyStartFrom' Cannot be blank!!!");
        return;
    }
    /**************************************************************************************************************/

    //txtSignedInEmployeeCode
    //alert("MSTR OB CREATED");
    lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection = new Array();
    for (var i = 0; i < lcl_obj_WorkGroupOperationMaster.WorkerStrength; i++) {
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i] = new Object();
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeCode = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'txtEmployeeCode', i);
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeWorkGroupHistoryCode = 0;
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].WorkGroupOperationMasterCode = 0; //to be set in server
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].AssessmentStatus = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'ddlAssessmentStatus', i);
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeProfile = null;
    }
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/SaveWorkGroupOperationMasterByDateRange";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_dt_DateFrom:'" + lcl_dt_DateFrom + "',IP_dt_DateUpto:'" + lcl_dt_DateUpto + "',IP_obj_WorkGroupOperationMaster: " + JSON.stringify(lcl_obj_WorkGroupOperationMaster) + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode < 0) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            $("#lnkUploadLogFile").removeClass("command_button_enabled").addClass("command_button_disabled");
            $('#lnkUploadLogFile').unbind('click');
            $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
            $('#lnkSave').unbind('click');
            //RefreshInput();
            DisplaySuccess(lcl_obj_WSResponse.Message);
        }
    };

    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);


}

function RefreshInput(event) {
    //alert("Refreshing...");
    event.preventDefault();
    $('.WG_IP').val('');

    $("#lnkUploadLogFile").removeClass("command_button_disabled").addClass("command_button_enabled");
    $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
    $('#lnkSave').unbind('click');
    var lcl_i32_Count = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblWorkgroupEmployee').appendGrid('removeRow', 0);
    }
    return false;
}