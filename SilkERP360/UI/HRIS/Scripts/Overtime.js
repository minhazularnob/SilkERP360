$(document).ready(function () {

    $("#txtOTDateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtOTDateTo").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    $(".numeric_only").number(true);
    //    $(".peel_off_ip_required").each(function () {
    //        //alert("a");
    //        $(this).css('background-color', 'black');
    //    });

    //GenerateMasterBatch();

    $('#tblOvertime').appendGrid('init', {
        caption: 'Quality Control Test Data',
        initRows: 0,
        columns: [
                    { name: 'EmployeeId', display: 'Emp. ID', type: 'text', displayCss: {'width' : '10px', 'text-align': 'center' }, ctrlAttr: { maxlength: 100 }, ctrlCss: {'text-align':'center'} },
                    { name: 'EmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'text-align': 'center' }, ctrlAttr: { maxlength: 300 }, ctrlCss: { 'text-align': 'center'} },
                    { name: 'Designation', display: 'Desig', type: 'text', displayCss: { 'text-align': 'center' }, ctrlAttr: { maxlength: 300 }, ctrlCss: { 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'TotalOvertime', display: 'Total O.T', type: 'text', displayCss: { 'text-align': 'center' }, ctrlAttr: { maxlength: 50 }, ctrlCss: { 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'EmployeeCode', type: 'hidden', value: 0 }

                 ],
        customRowButtons: [
                { uiButton: { icons: { primary: 'ui-icon-details' }, label: 'Details' }, click: function (evtObj, uniqueIndex, rowData) { alert('You clicked the print button!'); }, btnClass: 'print', atTheFront: true },
                
            ],
        hideButtons: {
            remove: true,
            removeLast: true,
            insert: true,
            append: true
        },
        hideRowNumColumn: false,
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            //lcl_dt_Date = new Date($.now());
            //var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
            // Copy data of `Year` from parent row to new added rows
            //$(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
            //alert(lcl_obj_SMQCRandomGenerator.RandomSequences[addedRowIndex]);
            //alert(addedRowIndex);
            //$(caller).appendGrid('setCtrlValue', 'SheetSequence', addedRowIndex, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[addedRowIndex]);
        }
    });
    $('#dvOvertime').show('slow');
});

function SetupOT(event) {
    var lcl_str_DepartmentCode = $('#hdnDepartmentCode').val();
    var lcl_str_StartDate = $('#txtOTDateFrom').val();
    var lcl_str_EndDate = $('#txtOTDateTo').val();

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/HRIS/OvertimeServices.asmx/GetDepartmentwiseOvertimeListByDateRange",
        data: "{IP_ui64_DepartmentCode: " + lcl_str_DepartmentCode + ",IP_dt_StartDate:'" + lcl_str_StartDate + "',IP_dt_EndDate:'" + lcl_str_EndDate + "'}", //provide input for the getSM_PO method
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
            //            if (lcl_ui16_NumberOfOTDays > 31) {
            //                DisplayError("Maximum permissible Overtime days is 31!!!");
            //                return;
            //            }

            $('#dvOvertime').show('slow');
            var lcl_objArr_OvertimeData = new Array();
            $.each(lcl_objLst_OvertimeHistoryList, function (index, lcl_obj_OvertimeHistory) {
                lcl_objArr_OvertimeData[index] = new Object();

                var lcl_obj_EmployeeProfile = lcl_obj_OvertimeHistory.EmployeeProfile;
                var lcl_objLst_OvertimeList = lcl_obj_OvertimeHistory.OvertimeList;

                lcl_objArr_OvertimeData[index].EmployeeCode = lcl_obj_EmployeeProfile.EmployeeCode;
                lcl_objArr_OvertimeData[index].EmployeeID = lcl_obj_EmployeeProfile.EmployeeID;
                lcl_objArr_OvertimeData[index].EmployeeName = lcl_obj_EmployeeProfile.EmployeeName;
                lcl_objArr_OvertimeData[index].Designation = lcl_obj_EmployeeProfile.Designation.Name;
                lcl_objArr_OvertimeData[index].TotalOvertime = lcl_obj_OvertimeHistory.TotalOvertime;
                
            });

            var lcl_i32_RowCount = lcl_objArr_OvertimeData.length;

            for (var i = 0; i < lcl_i32_RowCount; i++) {
                $('#tblOvertime').appendGrid('insertRow', [
                    { EmployeeId: lcl_objArr_OvertimeData[i].EmployeeID.toString(), EmployeeName: lcl_objArr_OvertimeData[i].EmployeeName.toString(), Designation: lcl_objArr_OvertimeData[i].Designation.toString(), TotalOvertime: lcl_objArr_OvertimeData[i].TotalOvertime.toString(), EmployeeCode: lcl_objArr_OvertimeData[i].EmployeeCode.toString() }
                ]);
                var lcl_ctrl_EmployeeId = $('#tblOvertime').appendGrid('getCellCtrl', 'EmployeeId', i);
                $(lcl_ctrl_EmployeeId).attr('readonly', 'readonly');
                var lcl_ctrl_EmployeeName = $('#tblOvertime').appendGrid('getCellCtrl', 'EmployeeName', i);
                $(lcl_ctrl_EmployeeName).attr('readonly', 'readonly');
                var lcl_ctrl_Designation = $('#tblOvertime').appendGrid('getCellCtrl', 'Designation', i);
                $(lcl_ctrl_Designation).attr('readonly', 'readonly');
                var lcl_ctrl_TotalOvertime = $('#tblOvertime').appendGrid('getCellCtrl', 'TotalOvertime', i);
                $(lcl_ctrl_TotalOvertime).attr('readonly', 'readonly');
            }
        },
        error: function (event, jqxhr, settings, exception) /// <reference path= />
        {
            var lcl_obj_WSResponse = ($.parseJSON(jqxhr.responseText)).d;
            DisplayError(lcl_obj_WSResponse.Message);
        }
    });
}