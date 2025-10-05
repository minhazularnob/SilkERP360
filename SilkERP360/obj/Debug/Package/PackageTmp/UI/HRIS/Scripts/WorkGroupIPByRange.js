$(document).ready(function () {
    //$("#txtWorkDateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtWorkDateUpto").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, minDate: 0, maxDate: "+365D" });
    $("#txtWorkDateFrom").datepicker({ dateFormat: 'dd/MM/yy', showButtonPanel: true, minDate: 0, maxDate: "+365D",
        onSelect: function (dateStr) {
            //add 3month with the 'Joining Date' and populate Confirmation date
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            //var years = parseInt($("#equipment_warrantyLength").val(), 10);
            //d.setMonth(d.getMonth() + 3);
            //$("#txtWorkDateUpto").datepicker('setDate', d);
            //$("#txtWorkDateUpto").datepicker('destroy');
            $("#txtWorkDateUpto").datepicker('option', 'minDate', d);
        }
    });

    $("#txtDutyStartsAt").timepicker({ timeFormat: "hh:mm:ss TT" });

    //    $('#lnkRefresh').bind('click', function (event) {
    //        RefreshInput(event);
    //    });

    $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");


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
        //            $("#lnkUploadEmployeeFile").removeClass("command_button_enabled").addClass("command_button_disabled");
        //            $('#lnkUploadEmployeeFile').unbind('click');
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
        //var elem = $('#tblWorkgroupEmployee').appendGrid('getCellCtrl', 'ddlAssessmentStatus', 1);
        //alert($('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'ddlAssessmentStatus', i).toString());
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].AssessmentStatus = $('#tblWorkgroupEmployee').appendGrid('getCtrlValue', 'ddlAssessmentStatus', i);
        lcl_obj_WorkGroupOperationMaster.WorkGroupOperationHistoryCollection[i].EmployeeProfile = null;
    }
    //alert("OP MSTR CONFIGURED");
    //alert( JSON.stringify(GBL_WorkGroupOperationMaster));
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
            //ALL OK
            //Refresh Controls
            //GetWorkGroupByDate(event);
            //$("#lnkAddEmployee").removeClass("command_button_enabled").addClass("command_button_disabled");
            //$('#lnkAddEmployee').unbind('click');
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
    //$('#lnkUploadLogFile').bind('click',UploadEmployeeList(event));
    $("#lnkSave").removeClass("command_button_enabled").addClass("command_button_disabled");
    $('#lnkSave').unbind('click');
    var lcl_i32_Count = $('#tblWorkgroupEmployee').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblWorkgroupEmployee').appendGrid('removeRow', 0);
    }
    return false;
}