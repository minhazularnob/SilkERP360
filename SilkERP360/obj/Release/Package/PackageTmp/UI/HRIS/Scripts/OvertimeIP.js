var GBL_DisplayedOvertimeObjects = new Array();
var GBL_UpdatedOvertime;
var GBL_NewOvertime;
$(document).ready(function () {

    Object.size = function (obj) {
        var size = 0, key;
        for (key in obj) {
            if (obj.hasOwnProperty(key)) size++;
        }
        return size;
    };

    $("#txtOTDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    
    $(".numeric_only").number(true);
    //    $(".peel_off_ip_required").each(function () {
    //        //alert("a");
    //        $(this).css('background-color', 'black');
    //    });

    //GenerateMasterBatch();

//    $('#tblDMTest').appendGrid({
//        caption: 'Quality Control Test Data',
//        initRows: 0,
//        columns: [
//                    { name: 'SheetSequence', display: 'Sheet Seq.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
//                    { name: 'Time', display: 'Time', type: 'text', value: '', displayCss: { 'text-align': 'center' }, ctrlCss: { 'width': '20%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
//                    { name: 'PeelOffPercentage', display: 'Peel-Off %', type: 'text', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '20%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
//                    { name: 'Status', display: 'Status', type: 'text', value: 'Not Evaluated', displayCss: { 'text-align': 'center' }, ctrlCss: { 'width': '10%' }, ctrlClass: 'qc_not_evaluated' },
//                    { name: 'Glitch Type', display: 'Glitch Type', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'width': '40%', 'text-align': 'center'} },
//                    { name: 'RecordId', type: 'hidden', value: 0 }
//                    ],
//        hideButtons: {
//            remove: true,
//            removeLast: true,
//            insert: true,
//            append: true
//        },
//        hideRowNumColumn: false,
//        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
//            //lcl_dt_Date = new Date($.now());
//            //var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
//            // Copy data of `Year` from parent row to new added rows
//            //$(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
//            //alert(lcl_obj_SMQCRandomGenerator.RandomSequences[addedRowIndex]);
//            //alert(addedRowIndex);
//            //$(caller).appendGrid('setCtrlValue', 'SheetSequence', addedRowIndex, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[addedRowIndex]);
//        }
//    });
});

function Refresh(event) {
    var lcl_str_DepartmentCode = $('#hdnDepartmentCode').val();
    var lcl_str_OTDate = $('#txtOTDate').val();
    GBL_UpdatedOvertime = new Object();

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/HRIS/OvertimeServices.asmx/GetDepartmentwiseOvertimeListByDate",
        data: "{IP_ui64_DepartmentCode: " + lcl_str_DepartmentCode + ",IP_dt_OvertimeDate:'" + lcl_str_OTDate + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }

            var lcl_objLst_OvertimeHistoryList = WSResponse.Data;

            var lcl_ui16_NumberOfOTDays = lcl_objLst_OvertimeHistoryList[0].OvertimeList.length;
            //alert(lcl_ui16_NumberOfOTDays);
            if (lcl_ui16_NumberOfOTDays > 31) {
                DisplayError("Maximum permissible Overtime days is 31!!!");
                return;
            }
            $('#dvOvertime').show('slow');

            var lcl_objArr_OvertimeData = new Array();
            GBL_DisplayedOvertimeObjects = new Array();
            GBL_NewOvertime = new Object();
            GBL_UpdatedOvertime = new Object();
            $.each(lcl_objLst_OvertimeHistoryList, function (index, lcl_obj_OvertimeHistory) {

                var lcl_obj_EmployeeProfile = lcl_obj_OvertimeHistory.EmployeeProfile;
                var lcl_objLst_OvertimeList = lcl_obj_OvertimeHistory.OvertimeList;
                var lcl_obj_Overtime = null;
                if (lcl_objLst_OvertimeList.length > 0) {
                    var lcl_obj_Overtime = lcl_objLst_OvertimeList[0];
                    lcl_obj_Overtime.OvertimeDate = lcl_str_OTDate;
                    lcl_obj_Overtime.EntryDate = lcl_str_OTDate; //Modify Entry Date
                }
                else {
                    lcl_obj_Overtime = new Object();
                    lcl_obj_Overtime.OvertimeCode = "";
                    lcl_obj_Overtime.EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                    lcl_obj_Overtime.OvertimeDate = lcl_str_OTDate;
                    lcl_obj_Overtime.OvertimeHour = "";
                    lcl_obj_Overtime.IsProcessed = 0;
                    lcl_obj_Overtime.EntryEmployeeCode = $("#txtSignedInEmployeeCode").val();
                }

                GBL_DisplayedOvertimeObjects[index] = lcl_obj_Overtime;

                lcl_objArr_OvertimeData[index] = new Object();
                lcl_objArr_OvertimeData[index].OTCode = lcl_obj_Overtime.OvertimeCode;
                lcl_objArr_OvertimeData[index].EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                lcl_objArr_OvertimeData[index].EmployeeId = lcl_obj_EmployeeProfile.EmployeeID;
                lcl_objArr_OvertimeData[index].EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                lcl_objArr_OvertimeData[index].Designation = lcl_obj_EmployeeProfile.Designation.Name;
                lcl_objArr_OvertimeData[index].OTRate = lcl_obj_OvertimeHistory.OvertimeRate;
                lcl_objArr_OvertimeData[index].OT = lcl_obj_Overtime.OvertimeHour;

            });
            //alert(JSON.stringify(lcl_objArr_OvertimeData));
            $('#tblOvertime').appendGrid({
                caption: 'Overtime',
                initRows: 0,
                columns: [
                    { name: 'OTCode', display: 'Code', type: 'text', displayCss: { 'width': '100px', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                    { name: 'EmployeeId', display: 'Emp. ID', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                    { name: 'EmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '40%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'Designation', display: 'Desig', type: 'text', displayCss: { 'width': '40%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'OTRate', display: 'Overtime Rate', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'OT', display: 'Overtime Hour', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required',
                        onChange: function (evt, rowIndex) {
                            //alert('You have changed value of Album at row ' + rowIndex);
                            var lcl_str_OTCode = $('#tblOvertime').appendGrid('getCtrlValue', 'OTCode', rowIndex);
                            var lcl_str_EmployeeId = $('#tblOvertime').appendGrid('getCtrlValue', 'EmployeeId', rowIndex);
                            var lcl_str_EmployeeName = $('#tblOvertime').appendGrid('getCtrlValue', 'EmployeeName', rowIndex);
                            var lcl_str_Designation = $('#tblOvertime').appendGrid('getCtrlValue', 'Designation', rowIndex);
                            var lcl_str_OTRate = $('#tblOvertime').appendGrid('getCtrlValue', 'OTRate', rowIndex);
                            var lcl_str_OT = $('#tblOvertime').appendGrid('getCtrlValue', 'OT', rowIndex);
                            var lcl_str_EmployeeCode = $('#tblOvertime').appendGrid('getCtrlValue', 'EmployeeCode', rowIndex);
                            //alert(lcl_str_EmployeeCode);

                            var lcl_ctrl_OT = $('#tblOvertime').appendGrid('getCellCtrl', 'OT', rowIndex);

                            var lcl_obj_OT = $(lcl_ctrl_OT).data('OT');
                            //Replace
                            if ((lcl_obj_OT.OvertimeCode == "") && (lcl_obj_OT.OvertimeHour == "")) {
                                //New Overtime---Save Overtime
                                lcl_obj_OT.OvertimeHour = lcl_str_OT;
                                GBL_NewOvertime[lcl_obj_OT.EmployeeCode.toString()] = lcl_obj_OT;
                                $(lcl_ctrl_OT).css('background-color', 'rgb(255,0,85)');
                            }
                            else {
                                //Updated OT. Update
                                lcl_obj_OT.OvertimeHour = lcl_str_OT;
                                GBL_UpdatedOvertime[lcl_obj_OT.EmployeeCode.toString()] = lcl_obj_OT;
                                $(lcl_ctrl_OT).css('background-color', 'rgb(255,255,85)');
                            }
                            //modify object

                            //alert(lcl_obj_OT.EmployeeCode);

                            //GBL_UpdatedOvertime[lcl_str_EmployeeCode] = lcl_str_OT;
                        }
                    },

                    { name: 'EmployeeCode', type: 'hidden', value: 0 }
                    ],
                hideButtons: {
                    remove: true,
                    removeLast: true,
                    insert: true,
                    append: true
                },
                hideRowNumColumn: false,
                afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
                    var lcl_str_EmployeeId = lcl_objArr_OvertimeData[addedRowIndex].EmployeeId;
                    //$(caller).appendGrid('setCtrlValue', 'EmployeeId', addedRowIndex, lcl_str_EmployeeId);
                    //                    $(caller).appendGrid('setCtrlValue', 'EmployeeName', addedRowIndex, lcl_objArr_OvertimeData[addedRowIndex].EmployeeName);
                    //                    $(caller).appendGrid('setCtrlValue', 'Designation', addedRowIndex, lcl_objArr_OvertimeData[addedRowIndex].Designation);
                    //                    $(caller).appendGrid('setCtrlValue', 'OTRate', addedRowIndex, lcl_objArr_OvertimeData[addedRowIndex].OTRate);
                    //                    $(caller).appendGrid('setCtrlValue', 'OT', addedRowIndex, lcl_objArr_OvertimeData[addedRowIndex].OT);
                    //lcl_dt_Date = new Date($.now());
                    //var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
                    // Copy data of `Year` from parent row to new added rows
                    //$(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
                    //alert(lcl_obj_SMQCRandomGenerator.RandomSequences[addedRowIndex]);
                    //alert(addedRowIndex);
                    //$(caller).appendGrid('setCtrlValue', 'SheetSequence', addedRowIndex, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[addedRowIndex]);
                }
            });

            var lcl_i32_RowCount = lcl_objArr_OvertimeData.length;

            for (var i = 0; i < lcl_i32_RowCount; i++) {
                $('#tblOvertime').appendGrid('insertRow', [
                    { OTCode: lcl_objArr_OvertimeData[i].OTCode.toString(), EmployeeId: lcl_objArr_OvertimeData[i].EmployeeId.toString(), EmployeeName: lcl_objArr_OvertimeData[i].EmployeeName.toString(), Designation: lcl_objArr_OvertimeData[i].Designation.toString(), OTRate: lcl_objArr_OvertimeData[i].OTRate.toString(), OT: lcl_objArr_OvertimeData[i].OT.toString(), EmployeeCode: lcl_objArr_OvertimeData[i].EmployeeCode.toString() }
                ]);
                var lcl_ctrl_OTCode = $('#tblOvertime').appendGrid('getCellCtrl', 'OTCode', i);
                $(lcl_ctrl_OTCode).attr('readonly', 'readonly');
                var lcl_ctrl_EmployeeId = $('#tblOvertime').appendGrid('getCellCtrl', 'EmployeeId', i);
                $(lcl_ctrl_EmployeeId).attr('readonly', 'readonly');
                var lcl_ctrl_EmployeeName = $('#tblOvertime').appendGrid('getCellCtrl', 'EmployeeName', i);
                $(lcl_ctrl_EmployeeName).attr('readonly', 'readonly');
                var lcl_ctrl_Designation = $('#tblOvertime').appendGrid('getCellCtrl', 'Designation', i);
                $(lcl_ctrl_Designation).attr('readonly', 'readonly');
                var lcl_ctrl_OTRate = $('#tblOvertime').appendGrid('getCellCtrl', 'OTRate', i);
                $(lcl_ctrl_OTRate).attr('readonly', 'readonly');

                var lcl_ctrl_OT = $('#tblOvertime').appendGrid('getCellCtrl', 'OT', i);
                $(lcl_ctrl_OT).data('OT', GBL_DisplayedOvertimeObjects[i]);

                if (lcl_objArr_OvertimeData[i].OTCode.toString() == "") {
                    $(lcl_ctrl_OT).css('background-color', 'rgb(255,255,255)');
                }
                else {
                    $(lcl_ctrl_OT).css('background-color', 'rgb(0,255,45)');
                }
            }

        } /// <reference path= />
    });
}

function UpdateOT(event) {
    //alert("Inserted Overtime : " + Object.size(GBL_NewOvertime));
    var lcl_i32_UpdatedOvertimeCount = Object.size(GBL_UpdatedOvertime);

    if (lcl_i32_UpdatedOvertimeCount == 0) {
        DisplayInformation("No Overtime data was updated!!!");
        return;
    }

    var lcl_objLst_Overtime = new Array();
    var lcl_i32_Counter = 0;
    for (key in GBL_UpdatedOvertime) {
        if (GBL_UpdatedOvertime.hasOwnProperty(key)) {
            lcl_objLst_Overtime[lcl_i32_Counter] = GBL_UpdatedOvertime[key];
            //lcl_objLst_Overtime[lcl_i32_Counter].OvertimeCode = 0;
            lcl_i32_Counter++;
        }
    }

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/HRIS/OvertimeServices.asmx/UpdateOvertime",
        data: "{IP_objLst_Overtime: " + JSON.stringify(lcl_objLst_Overtime) + "}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_i32_RowCount = $('#tblOvertime').appendGrid('getRowCount');
            for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
                var lcl_ctrl_OT = $('#tblOvertime').appendGrid('getCellCtrl', 'OT', lcl_i32_Counter);
                if ($(lcl_ctrl_OT).css("background-color") == "rgb(255, 255, 85)") {
                    $(lcl_ctrl_OT).css("background-color", "rgb(0, 255, 45)");
                }
            }
            DisplaySuccess("Overtime Updates has been synchronised successfully with the database!!!");
            GBL_UpdatedOvertime = new Object();
        },
        error: function (event, jqxhr, settings, exception) /// <reference path= />
        {
            var lcl_obj_WSResponse = ($.parseJSON(jqxhr.responseText)).d;
            DisplayError(lcl_obj_WSResponse.Message);
        }
    });
}

function Save(event) {
    //alert("Inserted Overtime : " + Object.size(GBL_NewOvertime));
    var lcl_i32_NewOvertimeCount = Object.size(GBL_NewOvertime);

    if (lcl_i32_NewOvertimeCount == 0) {
        DisplayInformation("No Overtime Data Inserted for Saving in the Database!!!");
        return;
    }

    var lcl_objLst_Overtime = new Array();
    var lcl_i32_Counter = 0;
    for (key in GBL_NewOvertime) {
        if (GBL_NewOvertime.hasOwnProperty(key)) {
            lcl_objLst_Overtime[lcl_i32_Counter] = GBL_NewOvertime[key];
            lcl_objLst_Overtime[lcl_i32_Counter].OvertimeCode = 0;
            lcl_i32_Counter++;
        }
    }

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/HRIS/OvertimeServices.asmx/SaveOvertime",
        data: "{IP_objLst_NewOvertime: " + JSON.stringify(lcl_objLst_Overtime) + "}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }

            var lcl_i32_RowCount = $('#tblOvertime').appendGrid('getRowCount');
            for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
                var lcl_ctrl_OT = $('#tblOvertime').appendGrid('getCellCtrl', 'OT', lcl_i32_Counter);
                if ($(lcl_ctrl_OT).css("background-color") == "rgb(255, 0, 85)") {
                    $(lcl_ctrl_OT).css("background-color","rgb(0, 255, 45)");
                }
            }

            DisplaySuccess("Overtime Has been saved successfully in the database!!!");
            GBL_NewOvertime = new Object();
        },
        error: function (event, jqxhr, settings, exception) /// <reference path= />
        {
            var lcl_obj_WSResponse = ($.parseJSON(jqxhr.responseText)).d;
            DisplayError(lcl_obj_WSResponse.Message);
        }
    });

}