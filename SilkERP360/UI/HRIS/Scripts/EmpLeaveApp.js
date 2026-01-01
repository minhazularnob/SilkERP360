var GBLEmployeeLeaveProfile;
var GBL_Months = new Array();
GBL_Months[0] = "January";
GBL_Months[1] = "February";
GBL_Months[2] = "March";
GBL_Months[3] = "April";
GBL_Months[4] = "May";
GBL_Months[5] = "June";
GBL_Months[6] = "July";
GBL_Months[7] = "August";
GBL_Months[8] = "September";
GBL_Months[9] = "October";
GBL_Months[10] = "November";
GBL_Months[11] = "December";

var GBLLeaveType = new Array();
GBLLeaveType [0] = "NONE";
GBLLeaveType [1] = "CL";
GBLLeaveType [2] = "SL";
GBLLeaveType [3] = "ML";
GBLLeaveType [4] = "EL";
var GBLLeaveCategory = new Array();
GBLLeaveCategory [1] = "Paid";
GBLLeaveCategory [2] = "Unpaid";

$(document).ready(function () {
    //$("#ddlEmployeeId").combobox();

    $("#combobox").on("keypress", function (keyarg) {
        if (keyarg.keyCode == 13) {
            GetEmployeeLeaveProfile(keyarg);
        }
    });


    $('.ip_required').focus(function () {
        $(this).css('background-color', 'white');
    });

    $(".ip_required").change(function () {
        $(this).css('background-color', 'white');
    });


    $('#tblEmpLeaveAppList').appendGrid({
        caption: 'Leave Applications',
        initRows: 1,
        columns: [
                    { name: 'txtLALeaveAppCode', display: 'Emp. Code', type: 'hidden' },
                    { name: 'txtLALeaveType', display: 'Type', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLALeaveCategory', display: 'Category', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLAStartDate', display: 'St. Date.', type: 'text', value: '', displayCss: { 'width': '13%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLAEndDate', display: 'End Date', type: 'text', value: '', displayCss: { 'width': '13%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLANumOfDays', display: 'Days', type: 'text', value: '', displayCss: { 'width': '6%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLARejoinDate', display: 'Rejoin Date', type: 'text', value: '', displayCss: { 'width': '13%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLALeaveReason', display: 'Reason', type: 'text', value: '', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtLARemarks', display: 'Remarks', type: 'text', value: '', displayCss: { 'width': '30%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'RecordId', type: 'hidden', value: 0 }
                    ],
        customRowButtons: [
            {
                uiButton: { icons: { primary: 'ui-icon-close' }, text: false },
                click: function (evtObj, uniqueIndex, rowData) {
                    if (!(confirm("Are You sure, You want to cancel this leave?"))) {
                        return;
                    }
                    var lcl_ui64_LeaveAppCode = rowData["txtLALeaveAppCode"].toString();
                    var lcl_ui64_CancelEmployeeCode = $('#txtSignedInEmployeeCode').val();

                    var options = {};
                    options.url = gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/CancelLeaveApplication";
                    options.dataType = "json";
                    options.type = "POST";
                    options.data = "{IP_ui64_LeaveApplicationCode: " + lcl_ui64_LeaveAppCode + ",IP_ui64_CancelEmployeeCode: " + lcl_ui64_CancelEmployeeCode + "}"; // JSON.stringify(lcl_obj_LogFile);
                    options.contentType = "application/json; charset=utf-8";
                    options.processData = false;
                    options.success = function (result) {

                        var lcl_obj_WSResponse = result.d;
                        if (lcl_obj_WSResponse.ResponseCode == -1) {
                            DisplayInformation(lcl_obj_WSResponse.Message);
                            return;
                        }
                        if (lcl_obj_WSResponse.ResponseCode == 0) {
                            var lcl_i32_RowIndex = $('#tblEmpLeaveAppList').appendGrid('getRowIndex', uniqueIndex);
                            $('#tblEmpLeaveAppList').appendGrid('removeRow', lcl_i32_RowIndex);
                            DisplaySuccess(lcl_obj_WSResponse.Message);
                            return;
                        }
                        DisplayError(lcl_obj_WSResponse.Message);
                    };

                    options.error = function (err) { DisplayError(err.statusText); };

                    $.ajax(options);
                }, btnCss: { 'min-width': '20px' },
                btnAttr: { title: 'Cancel Leave' }, atTheFront: true

            }
        ],
        hideButtons: {
            remove: true,
            removeLast: true,
            insert: true,
            append: true,
            moveUp: true,
            moveDown: true
        },
        hideRowNumColumn: true

    });



    $("#txtStartDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true,
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            $("#txtEndDate").datepicker("option", "minDate", d);
            $("#txtEndDate").datepicker('setDate', d);
            d.setDate(d.getDate() + 1);
            $("#txtRejoinDate").val((d.getDate()).toString() + '/' + GBL_Months[d.getMonth()] + '/' + d.getFullYear().toString());
            $("#txtNumOfDays").val("1");
        }
    });
    $("#txtEndDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true,
        onSelect: function (dateStr) {
            //add 3month with the 'Joining Date' and populate Confirmation date
            var EndDate = $.datepicker.parseDate('dd/MM/yy', dateStr);
            var StartDate = $.datepicker.parseDate('dd/MM/yy', ($("#txtStartDate").val()));
            var NumOfDaysInMS = EndDate - StartDate;
            var NumOfDays = ((((NumOfDaysInMS / 1000) / 60) / 60) / 24);
            NumOfDays += 1;
            $("#txtNumOfDays").val(NumOfDays);
            EndDate.setDate(EndDate.getDate() + 1);
            $("#txtRejoinDate").val((EndDate.getDate()).toString() + '/' + GBL_Months[EndDate.getMonth()] + '/' + EndDate.getFullYear().toString());
        }
    });
    initializeSelect2('ddlEmployeeId', '------ Select Employee ------', '25%'); 
    initializeSelect2('ddlLeaveType', '------ Select Leave Type ------', '25%');
    initializeSelect2('ddlLeaveCategory', '------ Select Leave Type ------', '25%');
});

function GetEmployeeLeaveProfile(event) {
    var lcl_ui64_EmployeeCode = $('#ddlEmployeeId option:selected').val();
    if (lcl_ui64_EmployeeCode == 0) {
        return;
    }
   // alert("1");
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/GetEmployeeLeaveProfileByEmployeeCode";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}";
    options.contentType = "application/json; charset=utf-8";
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            GBLEmployeeLeaveProfile = lcl_obj_WSResponse.Data;
            DisplayLeaveProfile();
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}


function DisplayLeaveProfile() {
    $("#txtEmpName").val(GBLEmployeeLeaveProfile.EmployeeName);
    $("#txtDesignation").val(GBLEmployeeLeaveProfile.Designation.Name);
    $("#txtDepartment").val(GBLEmployeeLeaveProfile.Department.Name);
    $("#txtCL").val(GBLEmployeeLeaveProfile.LeaveAccount.CL);
    $("#txtSL").val(GBLEmployeeLeaveProfile.LeaveAccount.SL);
    $("#txtML").val(GBLEmployeeLeaveProfile.LeaveAccount.ML);
    $("#txtEL").val(GBLEmployeeLeaveProfile.LeaveAccount.EL);

    var lcl_i32_Count = $('#tblEmpLeaveAppList').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblEmpLeaveAppList').appendGrid('removeRow', 0);
    }
    if (GBLEmployeeLeaveProfile.EmployeeLeaveApplicationList != null) {
        $.each(GBLEmployeeLeaveProfile.EmployeeLeaveApplicationList, function (index, lcl_obj_EmployeeLeaveApplication) {
            $('#tblEmpLeaveAppList').appendGrid('appendRow', [
            { txtLALeaveAppCode: lcl_obj_EmployeeLeaveApplication.LeaveApplicationCode,
                txtLALeaveType: GBLLeaveType[lcl_obj_EmployeeLeaveApplication.LeaveType],
                txtLALeaveCategory: GBLLeaveCategory[lcl_obj_EmployeeLeaveApplication.LeaveCategory],
                txtLAStartDate: $.datepicker.formatDate('dd/MM/yy', new Date(parseInt(lcl_obj_EmployeeLeaveApplication.LeaveStartDate.substr(6)))),
                txtLAEndDate: $.datepicker.formatDate('dd/MM/yy', new Date(parseInt(lcl_obj_EmployeeLeaveApplication.LeaveEndDate.substr(6)))),
                txtLANumOfDays: lcl_obj_EmployeeLeaveApplication.NumOfDays,
                txtLARejoinDate: $.datepicker.formatDate('dd/MM/yy', new Date(parseInt(lcl_obj_EmployeeLeaveApplication.RejoinDate.substr(6)))),
                txtLALeaveReason: lcl_obj_EmployeeLeaveApplication.Reason,
                txtLARemarks: lcl_obj_EmployeeLeaveApplication.Remarks
            }
        ]);
        });
    }
}

function SaveLeaveApplication(event) {
    var lcl_str_Name = $.trim($("#txtEmpName").val());
    if (lcl_str_Name == '') {
        DisplayError("Please Load A Employee Leave Profile Before Saving Any Leave Application!!!");
        return;
    }
    var lcl_b_Validated = true;
    $('.ip_required').each(function () {
        var lcl_str_Value = $(this).val();
        if ($.trim(lcl_str_Value) == '') {
            $(this).css('background-color', 'red');
            lcl_b_Validated = false;
        }
    });

    if (lcl_b_Validated == false) {
        DisplayError("Fields with Red background are mandatory fields!!!");
        return;
    }

    var lcl_obj_EmployeeLeaveApplication = new Object();
    lcl_obj_EmployeeLeaveApplication.EmployeeCode = $('#ddlEmployeeId option:selected').val();
    lcl_obj_EmployeeLeaveApplication.LeaveCategory = $('#ddlLeaveCategory option:selected').val();
    lcl_obj_EmployeeLeaveApplication.LeaveType = $('#ddlLeaveType option:selected').val();
    lcl_obj_EmployeeLeaveApplication.LeaveStartDate = $('#txtStartDate').val();
    lcl_obj_EmployeeLeaveApplication.LeaveEndDate = $('#txtEndDate').val();
    lcl_obj_EmployeeLeaveApplication.NumOfDays = $('#txtNumOfDays').val();
    lcl_obj_EmployeeLeaveApplication.RejoinDate = $('#txtRejoinDate').val();
    lcl_obj_EmployeeLeaveApplication.Reason = $('#txtReason').val();
    lcl_obj_EmployeeLeaveApplication.Remarks = $('#txtRemarks').val();
    lcl_obj_EmployeeLeaveApplication.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();

    var lcl_b_LeaveDaysValidated = true;

    //alert(lcl_obj_EmployeeLeaveApplication.NumOfDays);
    var lcl_i32_NumOfDays = $('#txtNumOfDays').val();

    if(lcl_obj_EmployeeLeaveApplication.LeaveCategory == 1){
        //PAID LEAVE
        if (lcl_obj_EmployeeLeaveApplication.LeaveType == 1) {
            //LeaveType CL; check account
            if (lcl_i32_NumOfDays > GBLEmployeeLeaveProfile.LeaveAccount.CL) {
                //DisplayError("The Leave Account For Leave Type 'CL' does not have sufficient balance!!!");
                lcl_b_LeaveDaysValidated = false;
                //return;
            }
        }

        if (lcl_obj_EmployeeLeaveApplication.LeaveType == 2) {
            //LeaveType SL; check account
            if (lcl_i32_NumOfDays > GBLEmployeeLeaveProfile.LeaveAccount.SL) {
                //DisplayError("The Leave Account For Leave Type 'SL' does not have sufficient balance!!!");
                lcl_b_LeaveDaysValidated = false;
                //return;
            }
        }

        if (lcl_obj_EmployeeLeaveApplication.LeaveType == 3) {
            //LeaveType ML; check account
            if (lcl_i32_NumOfDays > GBLEmployeeLeaveProfile.LeaveAccount.ML) {
                //DisplayError("The Leave Account For Leave Type 'ML' does not have sufficient balance!!!");
                lcl_b_LeaveDaysValidated = false;
                //return;
            }
        }

        if (lcl_obj_EmployeeLeaveApplication.LeaveType == 4) {
            //LeaveType EL; check account
            if (lcl_i32_NumOfDays > GBLEmployeeLeaveProfile.LeaveAccount.EL) {
                //DisplayError("The Leave Account For Leave Type 'EL' does not have sufficient balance!!!");
                lcl_b_LeaveDaysValidated = false;
                //return;
            }
        }

         if (lcl_obj_EmployeeLeaveApplication.LeaveType == 0) {
             DisplayError("Leave Type 'None' cannot be selected for Leave Category 'Paid'!");
            return;
         }
    }

    if(lcl_obj_EmployeeLeaveApplication.LeaveCategory == 2){
        //UNPAID LEAVE
        if (lcl_obj_EmployeeLeaveApplication.LeaveType != 0) {
            //lEAVE tYPE MUST BE SELECTED AS NONE
            DisplayError("Leave Type 'None' Must be Selected for Leave Category 'Unpaid'!");
            return;
        }
    }
    

    if (lcl_b_LeaveDaysValidated == false) {
        DisplayError("Leave Account Does Not Have Sufficient Balance!!!");
        return;
    }

    //User at this pount is forced to select CL/ML/EL/SL for Paid leave and NONE for Unpaid Leave


    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/SaveEmployeeLeaveApplication";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_obj_EmployeeLeaveApplication: " + JSON.stringify(lcl_obj_EmployeeLeaveApplication) + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            GBLEmployeeLeaveProfile = lcl_obj_WSResponse.Data;
            DisplayLeaveProfile();
            DisplaySuccess(lcl_obj_WSResponse.Message);
            $('.ip_required').each(function () {
                $(this).val('');
            });
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}