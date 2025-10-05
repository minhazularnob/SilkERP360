var GBL_EMPLOYEE_LIST_TABLE;
$(document).ready(function () {

    $("#txtAttendanceDateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtAttendanceDateUpto").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    GBL_EMPLOYEE_LIST_TABLE = $('#tblAttendanceSummery').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>Emp. Id</b>', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: '<b>Employee</b>', sWidth: '32%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Days</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Comm.<br/>Hours </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Served<BR/>Hours </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Present</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Absent </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Late</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Late App </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Leave </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Holiday </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>Weekend </b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>Total<br/>W.O.H</b>', sWidth: '4%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (A)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (M)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T (T)</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>N.Allow</b>', sWidth: '5%', sClass: 'alignCenter' }
                  ]

    });

//    $('#tblAttendanceSummery').appendGrid({
//        caption: 'Attendance Summery',
//        initRows: 1,
//        columns: [
//        //                                 { name: 'Image', display: 'img', type: 'image'},
//                { name: 'txtEmployeeCode', type: 'hidden' },
//                { name: 'txtEmployeeId', display: 'Emp. Id', displayCss: { 'text-align': 'center', 'width': '8%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
//                { name: 'txtEmplpoeeDetails', display: 'Employee', displayCss: { 'text-align': 'center', 'width': '32%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly','text-alignment':'left' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
//                //{ name: 'txtDesignation', display: 'Desig.', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
//                {name: 'txtTotalDays', display: 'T. Days', displayCss: { 'text-align': 'center', 'width': '5%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
//                { name: 'txtTotalExpectedWorkHour', display: 'T.E.W.H', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Expected Work Hour',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalWorkHourServed', display: 'T.W.H.S', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Work Hour Served',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalPresent', display: 'T. P', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Present',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalAbsent', display: 'T. A', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'},
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Absent',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalLate', display: 'T. L', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Late',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalLateApproved', display: 'T.L.A', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Late Approved',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalLeave', display: 'T.LV', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Leave',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalHoliday', display: 'T.H', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Holiday',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalWeekend', display: 'T.W', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Weekend',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalWorkOnHoliday', display: 'T.W.O.H', displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '4%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Work On Holiday',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalOvertimeAuto', display: 'O.T(A)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '5%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Overtime By Automated System',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtTotalOvertimeManual', display: 'O.T(M)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '5%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Overtime By Manual Adjustment',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'txtOvertimeTotal', display: 'O.T(T)', displayTooltip: '', displayCss: { 'text-align': 'center', 'width': '5%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center' },
//                    uiTooltip: {
//                        items: 'input',
//                        content: 'Total Overtime',
//                        show: {
//                            effect: 'slideDown',
//                            delay: 250
//                        }
//                    }
//                },
//                { name: 'RecordId', type: 'hidden', value: 0 }
//            ],
////        customRowButtons: [
////            {
////                uiButton: { icons: { primary: 'ui-icon-disk' }, text: false },
////                click: function (evtObj, uniqueIndex, rowData) {
////                    var lcl_str_EmployeeCode = $("#txtSignedInEmployeeCode").val();
////                    var lcl_str_AttendanceCode = rowData["txtAttendanceCode"];
////                    var lcl_str_ManualOvertimeAdjustment = rowData["txtRemarks"];
////                    var lcl_str_Remarks = rowData["txtRemarks"];
////                    var lcl_str_Status = rowData["ddlAttendanceStatus"]; //$('#tblAttendance').appendGrid('getCtrlValue', 'ddlAttendanceStatus', uniqueIndex);
////                    //var lcl_str_Status = $(lcl_ctrl_Status).val();
////                    //alert();
////                    var options = {};
////                    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/UpdateAttendanceStatus";
////                    options.dataType = "json";
////                    options.type = "POST";
////                    options.data = "{IP_ui64_AttendanceCode: " + lcl_str_AttendanceCode + ",IP_enm_AttendanceStatus: " + lcl_str_Status + ",IP_str_Remarks:'" + lcl_str_Remarks + "'}"; // JSON.stringify(lcl_obj_LogFile);
////                    options.contentType = "application/json; charset=utf-8";
////                    //options.processData = false;
////                    options.success = function (result) {
////                        var lcl_obj_WSResponse = result.d;
////                        if (lcl_obj_WSResponse.ResponseCode == 0) {
////                            DisplaySuccess("Attendance Status Has Been Changed Successfullly!");
////                            //DisplayLeaveProfile();
////                        }
////                    };

////                    options.error = function (err) { DisplayError(err.statusText); };

////                    $.ajax(options);
////                }, btnCss: { 'min-width': '20px' },
////                btnAttr: { title: 'Upload Sample Image' }, atTheFront: true
////            }
////        ],
////        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
////            var lcl_ctrl_AttendanceStatus = $(caller).appendGrid('getCellCtrl', 'ddlAttendanceStatus', addedRowIndex);
////            if (GBLAttendanceMaster != undefined) {
////                if (GBLAttendanceMaster.IsSalaryProcessed == 0) {
////                    $(lcl_ctrl_AttendanceStatus).prop("disabled", false);
////                }
////                else {
////                    $(lcl_ctrl_AttendanceStatus).prop("disabled", true);
////                }
////            }
////        },
////        beforeRowRemove: function (caller, rowIndex) {
////            //            var lcl_str_ItemCode = $(caller).appendGrid('getCtrlValue', 'txtItemCode', rowIndex);
////            //            if ($.trim(lcl_str_ItemCode) != '') {
////            //                ShowInfoMessageBoard("Operational Error : You are not permitted to delete this row!!!");
////            //                return false;
////            //            }
////            //            return true;
////        },
//        hideButtons: {
//            append: true,
//            insert: true,
//            moveUp: true,
//            moveDown: true,
//            remove: true,
//            removeLast: true
//        },
//        hideRowNumColumn: true
//    });

});


function GetAttendanceSummeryMaster(event) {
    var lcl_ui64_CompanyCode = $('#ddlCompany option:selected').val();
    var lcl_dt_DateFrom = $('#txtAttendanceDateFrom').val();
    if (lcl_dt_DateFrom == '') {
        DisplayError("Please Select a Start Date!");
        return;
    }

    var lcl_dt_DateUpto = $('#txtAttendanceDateUpto').val();
    if (lcl_dt_DateUpto == '') {
        DisplayError("Please Select a Upto Date!");
        return;
    }

    //    var lcl_i32_Count = $('#tblWorkGroupSchedule').appendGrid('getRowCount');
    //    lcl_i32_Count -= 1;
    //    for (var i = lcl_i32_Count; i >= 0; lcl_i32_Count--) {
    //        $('#tblWorkGroupSchedule').appendGrid('removeRow', lcl_i32_Count);
    //    }
    // alert("1");
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/GetAttendanceSummery";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + lcl_ui64_CompanyCode + ",IP_dt_DateFrom: '" + lcl_dt_DateFrom + "',IP_dt_DateUpto:'" + lcl_dt_DateUpto + "'}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            var EmployeeAttendanceSummeryMaster = lcl_obj_WSResponse.Data;
            DisplayAttendanceSummery(EmployeeAttendanceSummeryMaster);
            //DisplayLeaveProfile();
        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
}

function DisplayAttendanceSummery(EmployeeAttendanceSummeryMaster) {
    $("#txtTotalEmployees").val(EmployeeAttendanceSummeryMaster.TotalEmployees);
    //$("#txtTotalDays").val(EmployeeAttendanceSummeryMaster.TotalEmployees);    
    $("#txtTotalExpectedWorkHour").val((parseInt(EmployeeAttendanceSummeryMaster.TotalDesignatedWorkHour)).toString() + " Hrs.");
    $("#txtTotalWorkHourServed").val((parseInt(EmployeeAttendanceSummeryMaster.TotalWorkHour)).toString() + " Hrs.");
    $("#txtTotalOvertimeAuto").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertimeAuto)).toString() + " Hrs.");
    $("#txtTotalOvertimeManual").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertimeManual)).toString() + " Hrs.");
    $("#txtTotalOvertime").val((parseInt(EmployeeAttendanceSummeryMaster.TotalOvertime)).toString() + " Hrs.");
     $("#txtTotalNightAllowance").val((parseInt(EmployeeAttendanceSummeryMaster.TotalNightAllowance)).toString() + " .00");

    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
    var lcl_i32_TotalManHourCommitted = 0;
    var lcl_i32_TotalManHourServed = 0;

    var lcl_objLst_EmployeeAttendanceSummery = new Array();

    $.each(EmployeeAttendanceSummeryMaster.AttendanceSummeryList, function (index, AttendanceSummery) {

        var lcl_str_EmployeeDetails = AttendanceSummery.EmployeeName + "[" + AttendanceSummery.Designation + "]";
        lcl_objLst_EmployeeAttendanceSummery[index] = new Object();

        //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
        lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeId;
        lcl_objLst_EmployeeAttendanceSummery[index][1] = lcl_str_EmployeeDetails;
        lcl_objLst_EmployeeAttendanceSummery[index][2] = AttendanceSummery.TotalDays;
        lcl_objLst_EmployeeAttendanceSummery[index][3] = AttendanceSummery.TotalDesignatedWorkHour;
        lcl_objLst_EmployeeAttendanceSummery[index][4] = AttendanceSummery.TotalWorkHour;
        lcl_objLst_EmployeeAttendanceSummery[index][5] = AttendanceSummery.TotalPresent;
        lcl_objLst_EmployeeAttendanceSummery[index][6] = AttendanceSummery.TotalAbsent;
        lcl_objLst_EmployeeAttendanceSummery[index][7] = AttendanceSummery.TotalLate;
        lcl_objLst_EmployeeAttendanceSummery[index][8] = AttendanceSummery.TotalLateApproved;
        lcl_objLst_EmployeeAttendanceSummery[index][9] = AttendanceSummery.TotalLeave;
        lcl_objLst_EmployeeAttendanceSummery[index][10] = AttendanceSummery.TotalHoliday;
        lcl_objLst_EmployeeAttendanceSummery[index][11] = AttendanceSummery.TotalWeekend;
        lcl_objLst_EmployeeAttendanceSummery[index][12] = AttendanceSummery.TotalWorkOnHoliday;
        lcl_objLst_EmployeeAttendanceSummery[index][13] = AttendanceSummery.TotalOvertimeAuto;
        lcl_objLst_EmployeeAttendanceSummery[index][14] = AttendanceSummery.TotalOvertimeManual;
        lcl_objLst_EmployeeAttendanceSummery[index][15] = AttendanceSummery.TotalOvertime;
        lcl_objLst_EmployeeAttendanceSummery[index][16] = AttendanceSummery.TotalNightAllowance;

    });
    GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_objLst_EmployeeAttendanceSummery);
    //$('#tblAttendanceSummery').appendGrid('load', lcl_objLst_EmployeeAttendanceSummery);
}