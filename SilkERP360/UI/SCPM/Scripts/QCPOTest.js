var GBL_SM_QC_TEST_TYPE = 1; //CONSTANT VALUE. MUST MATCH VALUES WITH Enum.SCPM.SMQCTestType
var GBL_PRODUCT_TYPE = "SM";
var GBL_PROCESS_IDENTIFIER = "PRNT"; //This test belongs to the 'Printing' Process
var GBL_RAW_MATERIAL_TYPE = 1;//PVC Sheet
var lcl_dt_Date;
$(document).ready(function () {

    $(".numeric_only").number(true);
    //    $(".peel_off_ip_required").each(function () {
    //        //alert("a");
    //        $(this).css('background-color', 'black');
    //    });

    //GenerateMasterBatch();

    $('#tblDMTest').appendGrid({
        caption: 'Quality Control Test Data',
        initRows: 0,
        columns: [
                    { name: 'SheetSequence', display: 'Sheet Seq.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                    { name: 'Time', display: 'Time', type: 'text', value: '', displayCss: { 'text-align': 'center' }, ctrlCss: { 'width': '20%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'PeelOffPercentage', display: 'Peel-Off %', type: 'text', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '20%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'Status', display: 'Status', type: 'text', value: 'Not Evaluated', displayCss: { 'text-align': 'center'}, ctrlCss: {'width':'10%'},ctrlClass: 'qc_not_evaluated' },
                    { name: 'Glitch Type', display: 'Glitch Type', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'width' : '40%','text-align': 'center'} },
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
            //lcl_dt_Date = new Date($.now());
            //var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
            // Copy data of `Year` from parent row to new added rows
            //$(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
            //alert(lcl_obj_SMQCRandomGenerator.RandomSequences[addedRowIndex]);
            //alert(addedRowIndex);
            //$(caller).appendGrid('setCtrlValue', 'SheetSequence', addedRowIndex, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[addedRowIndex]);
        }
    });


});


function GenerateMasterBatch() {
    
}


    function Clear() {
        var lcl_i32_RowCount = $('#tblDMTest').appendGrid('getRowCount');
        for (var i = 0; i < lcl_i32_RowCount; i++) {
            $('#tblDMTest').appendGrid('removeRow', 0);
        }
    }

    function EvaluateTest() {
        var lcl_b_Validated = true;
        var lcl_i32_RowCount = $('#tblDMTest').appendGrid('getRowCount');
        if (lcl_i32_RowCount <= 0) {
            DisplayError('The Peel-Off Q.C Has not been set up yet!!!');
            return false;
        }
       
            var lcl_objList_SMPeelOffTest = new Array();
            var lcl_i32_RowCount = $('#tblDMTest').appendGrid('getRowCount');
            //alert(lcl_i32_RowCount);
            for (var i = 0; i < lcl_i32_RowCount; i++) {
                var lcl_str_PeelOffPercentage = $('#tblDMTest').appendGrid('getCtrlValue', 'PeelOffPercentage', i);
                var lcl_str_SheetSequence = $('#tblDMTest').appendGrid('getCtrlValue', 'SheetSequence', i);
                lcl_objList_SMPeelOffTest[i] = new Object();
                //var lcl_obj_SMPeelOffPercentage = new Object();
                lcl_objList_SMPeelOffTest[i].SMQCMasterCode = 0;
                lcl_objList_SMPeelOffTest[i].SMPeelOffCode = 0;
                lcl_objList_SMPeelOffTest[i].Sequence = lcl_str_SheetSequence;
                lcl_objList_SMPeelOffTest[i].PeelOffPercentage = lcl_str_PeelOffPercentage;
                lcl_objList_SMPeelOffTest[i].DateTime = new Date();
                lcl_objList_SMPeelOffTest[i].Status = 0;
                //lcl_objList_SMPeelOffTest[i] = lcl_obj_SMPeelOffPercentage;
            }
            //alert(JSON.stringify(lcl_objList_SMPeelOffTest));
            $.ajax(
            {
                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                global: true,
                url: gbl_URL_Root + "WebServices/SCPM/SMQCServices.asmx/EvaluateSMPeelOffTest",
                data: "{IP_objList_SMPeelOffTests: " + JSON.stringify(lcl_objList_SMPeelOffTest) + "}", //provide input for the getSM_PO method
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode < 0) {
                        DisplayError(WSReturn.Message);
                        return;
                    }
                    var lcl_objList_SMPeelOffTestSvr = WSReturn.Data;
                    var lcl_b_BatchStatusOk = true;
                    $.each(lcl_objList_SMPeelOffTestSvr, function (index, lcl_obj_SMPeelOffTest) {
                        for (var j = 0; j < lcl_i32_RowCount; j++) {
                            var lcl_str_SheetSequenceTmp = $('#tblDMTest').appendGrid('getCtrlValue', 'SheetSequence', j);

                            if (lcl_str_SheetSequenceTmp == lcl_obj_SMPeelOffTest.Sequence) {
                                var lcl_obj_StatusElement = $('#tblDMTest').appendGrid('getCellCtrl', 'Status', j);
                                var lcl_obj_PeelOffPercentageElement = $('#tblDMTest').appendGrid('getCellCtrl', 'PeelOffPercentage', j);
                                if (lcl_obj_SMPeelOffTest.Status == -1) {
                                    $(lcl_obj_StatusElement).val('Failed');
                                    $(lcl_obj_StatusElement).css('background-color', 'red');

                                    lcl_b_BatchStatusOk = false;
                                }
                                if (lcl_obj_SMPeelOffTest.Status == 1) {
                                    $(lcl_obj_StatusElement).val('Passed');
                                    $(lcl_obj_StatusElement).css('background-color', 'green');
                                }
                                $(lcl_obj_PeelOffPercentageElement).attr('readonly', 'readonly');
                                //alert("STATUS : " + $(elem).data('STATUS'));
                            }
                        }
                    });
                    if (lcl_b_BatchStatusOk == false) {
                        $("#txtBatchStatus").data('STATUS', '-1');
                        $("#txtBatchStatus").data('DELIVERY_STATUS', '-1');
                    }
                    else {
                        $("#txtBatchStatus").data('STATUS', '2');
                        $("#txtBatchStatus").data('DELIVERY_STATUS', '1');
                    }
                    $('#txtBatchStatus').removeClass('qc_not_evaluated');

                    if (lcl_b_BatchStatusOk == false) {
                        $('#txtBatchStatus').addClass('qc_failed');
                        $('#txtBatchStatus').val('ON HOLD');
                    }
                    else {
                        $('#txtBatchStatus').addClass('qc_passed');
                        $('#txtBatchStatus').val('RELEASE');
                    }
                    return;
                },
                error: function (event, jqxhr, settings, exception) {
                    DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                    return;
                }
            });
         
        }

        function SetupPOTest(event) {
            event.preventDefault();
            var lcl_str_DateFormat = "ddmmy";
            //get Selected Shift
            var lcl_i32_SelectedShiftIndex = $("#ddlShift option:selected").index();
            if (lcl_i32_SelectedShiftIndex == 0) {
                DisplayError("A shift must be selected to setup the Q.C test!!!");
                return false;
            }
            var lcl_str_SelectedShift = $("#ddlShift option:selected").text();
            var lcl_str_SelectedJobOrderNo = $("#ddlJobOrderNo option:selected").val().toString();
            var lcl_i32_SelectedJobOrderNoLength = lcl_str_SelectedJobOrderNo.length;
            var lcl_str_SelectedJobOrderNoSorted = lcl_str_SelectedJobOrderNo.substr((lcl_i32_SelectedJobOrderNoLength - 6));
            var lcl_c_ShiftChar = lcl_str_SelectedShift.charAt(0);
            //get current date
            var lcl_str_SelectedDate = $('#txtDate').val(); //QCMasterControl
            var lcl_dt_Today = new Date(lcl_str_SelectedDate);
            var lcl_str_Date = $.formatDateTime(lcl_str_DateFormat, lcl_dt_Today);

            var lcl_str_MachineIdentifier = $("#ddlMachine").data('IDNT');
            //alert(lcl_str_MachineIdentifier);

            if (lcl_str_MachineIdentifier == undefined) {
                DisplayError("No machine was selected for this production!!!");
                return false;
            }

            //MasterBatch generated here
            var lcl_str_MasterBatch = GBL_PRODUCT_TYPE + '-' + GBL_PROCESS_IDENTIFIER + '-' + lcl_str_MachineIdentifier + '-' + lcl_c_ShiftChar + '-' + lcl_str_Date + '-' + lcl_str_SelectedJobOrderNoSorted;

            var lcl_obj_ScpmSmMasterBatch = new Object();
            lcl_obj_ScpmSmMasterBatch.MasterBatch = lcl_str_MasterBatch;
            lcl_obj_ScpmSmMasterBatch.JobOrderCode = $("#ddlJobOrderNo").data('JB_CD');
            lcl_obj_ScpmSmMasterBatch.MachineCode = $("#ddlMachine option:selected").val();
            lcl_obj_ScpmSmMasterBatch.MasterBatchDate = $("#txtDate").val();
            lcl_obj_ScpmSmMasterBatch.ProcessCode = $("#txtProductionProcess").data('PPC');
            lcl_obj_ScpmSmMasterBatch.ShiftCode = $("#ddlShift option:selected").val();
            $.ajax(
            {
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                global: false,
                url: gbl_URL_Root + "WebServices/SCPM/SMQCServices.asmx/SMPeelOffQCMasterBatchSetup",
                data: "{IP_obj_ScpmSmMasterBatch: " + JSON.stringify(lcl_obj_ScpmSmMasterBatch) + "}", //provide input for the getSM_PO method
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode < 0) {
                        DisplayError(WSReturn.Message);
                        return;
                    }
                    var lcl_obj_ScpmSmMasterBatch = WSReturn.Data;
                    $("#txtMasterBatchQuantity").val(lcl_obj_ScpmSmMasterBatch.TotalQuantity);
                    $("#txtMasterBatchQuantityDispatched").val(lcl_obj_ScpmSmMasterBatch.TotalReleasedQuantity);
                    $("#txtMasterBatchQuantityRemaining").val(lcl_obj_ScpmSmMasterBatch.TotalStockQuantity);
                    $("#txtMasterBatch").data('MSTR_BTCH', lcl_obj_ScpmSmMasterBatch);

                    /******************************************************************************************************************************/
                    //Generate Random Sequence for Test
                    var lcl_i32_BatchQuantity = $('#txtSubBatchQuantity').val();
                    var lcl_obj_SMQCRandomGenerator = new Object();
                    lcl_obj_SMQCRandomGenerator.SMQCTestTypes = GBL_SM_QC_TEST_TYPE;
                    lcl_obj_SMQCRandomGenerator.BatchQuantity = lcl_i32_BatchQuantity;

                    //Send object to server for the random sequences

                    $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        global: true,
                        url: gbl_URL_Root + "WebServices/SCPM/SMQCServices.asmx/GetRandomSequences",
                        data: "{IP_obj_SMQCRandomGenerator: " + JSON.stringify(lcl_obj_SMQCRandomGenerator) + "}", //provide input for the getSM_PO method
                        dataType: "json",
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode < 0) {
                                DisplayError(WSReturn.Message);
                                return;
                            }
                            var lcl_obj_SMQCRandomGeneratorSvr = WSReturn.Data;

                            //Clear existing option excepty Index 0
                            var lcl_i32_NumberOfRandomSequence = lcl_obj_SMQCRandomGeneratorSvr.RandomSequences.length;
                            $('#tblDMTest').appendGrid({
                                caption: 'Quality Control Test Data',
                                initRows: lcl_i32_NumberOfRandomSequence,
                                columns: [
                                { name: 'SheetSequence', display: 'Sheet Seq.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                { name: 'Time', display: 'Time', type: 'text', value: '', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                { name: 'PeelOffPercentage', display: 'Peel-Off %', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                { name: 'Status', display: 'Status', type: 'text', value: 'Not Evaluated', displayCss: { 'text-align': 'center' }, ctrlClass: 'qc_not_evaluated' },
                                { name: 'GlitchType', display: 'Glitch Type', type: 'text', displayCss: { 'text-align': 'center', 'width': '200px'} },
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
                                    //lcl_dt_Date = new Date($.now());
                                    //var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
                                    // Copy data of `Year` from parent row to new added rows
                                    //$(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
                                    //alert(lcl_obj_SMQCRandomGenerator.RandomSequences[addedRowIndex]);
                                    //alert(addedRowIndex);
                                    //$(caller).appendGrid('setCtrlValue', 'SheetSequence', addedRowIndex, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[addedRowIndex]);
                                }
                            });
                            //$('#txtSheetSequence_2').val("AMITAV");
                            for (var i = 0; i < lcl_i32_NumberOfRandomSequence; i++) {
                                $('#tblDMTest').appendGrid('setCtrlValue', 'SheetSequence', i, lcl_obj_SMQCRandomGeneratorSvr.RandomSequences[i]);
                                var lcl_ctrl_SheetSequence = $('#tblDMTest').appendGrid('getCellCtrl', 'SheetSequence', i);
                                $(lcl_ctrl_SheetSequence).attr('readonly', 'readonly');

                                var lcl_ctrl_Time = $('#tblDMTest').appendGrid('getCellCtrl', 'Time', i);
                                $(lcl_ctrl_Time).attr('readonly', 'readonly');
                                $(lcl_ctrl_Time).timepicker({ timeFormat: "hh:mm:ss tt" }); // .attr('readonly', 'readonly');

                                var lcl_ctrl_Status = $('#tblDMTest').appendGrid('getCellCtrl', 'Status', i);
                                $(lcl_ctrl_Status).attr('readonly', 'readonly');

                            }
                            return;
                        },
                        error: function (event, jqxhr, settings, exception) {
                            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                        }
                    });
                    /******************************************************************************************************************************/

                    return;
                },
                error: function (event, jqxhr, settings, exception) {
                    DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                    return;
                }
            });

            $("#txtMasterBatch").val(lcl_str_MasterBatch);
            return true;
        }

        function Clear(event) {
            event.preventDefault();
            if (confirm("Are you sure you want to Clear the Test?")) {
                var lcl_i32_RowCount = $('#tblDMTest').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_RowCount; i++) {
                    $('#tblDMTest').appendGrid('removeRow', 0);
                }
            }
            $('#txtBatchStatus').removeClass();
            $('#txtBatchStatus').addClass('qc_not_evaluated');
            $('#txtBatchStatus').val('NOT EVALUATED');
            return false;
        }

        function Save(event) {
            //event.preventDefault();
            //alert("SAVING");
            var lcl_obj_SMMasterBatch = $("#txtMasterBatch").data('MSTR_BTCH');
            //lcl_obj_SMMasterBatch.MasterBatchCode = 0;
            //lcl_obj_SMMasterBatch.MasterBatch = $("#txtMasterBatch").val();
            //lcl_obj_SMMasterBatch.JobOrderCode = $("#ddlJobOrderCode option:selected").val();
            //lcl_obj_SMMasterBatch.MachineCode = $("#ddlMachine option:selected").val();
            //lcl_obj_SMMasterBatch.ProcessCode = $("#txtProductionProcess").data("PPC");
            //lcl_obj_SMMasterBatch.ShiftCode = $("#ddlShift option:selected").val();

            lcl_obj_SMMasterBatch.MasterBatchDate = $("#txtDate").val();

            lcl_obj_SMMasterBatch.ScpmSmSubBatchList = new Array();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0] = new Object();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].BatchDate = $("#txtDate").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].OperatorCode = $("#ddlOperator option:selected").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].Quantity = $("#txtSubBatchQuantity").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].Wastage = $("#txtWastage").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].Remarks = $("#txtRemarks").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].Status = $("#txtBatchStatus").data('STATUS');
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].DeliveryStatus = $("#txtBatchStatus").data('DELIVERY_STATUS');

            $(lcl_obj_StatusElement).data('STATUS', '2');
            $(lcl_obj_StatusElement).data('DELIVERY_STATUS', '1');


            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].RMVendorRefList = new Array();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].RMVendorRefList[0] = new Object();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].RMVendorRefList[0].BatchCode = 0;
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].RMVendorRefList[0].RawMaterialType = GBL_RAW_MATERIAL_TYPE;
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].RMVendorRefList[0].VendorCode = $("#ddlSheetVendor option:selected").val();

            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList = new Array();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0] = new Object();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].QCDate = $("#txtDate").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].QCEngineerCode = $("#hdnQAEngineerCode").val();
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].SMQCTestType = GBL_SM_QC_TEST_TYPE;
            lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests = new Array();

            var lcl_str_Date = $("#txtDate").val();
            //alert("OK-1");
            var lcl_i32_QCTestCount = $('#tblDMTest').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_QCTestCount; i++) {
                //lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].ScpmSmQCTestsList = new Array();
                var lcl_str_QcDateTime = $("#txtDate").val() + " " + $('#tblDMTest').appendGrid('getCtrlValue', 'Time', i);
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i] = new Object();
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].SMQCMasterCode = 0;
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].SMPeelOffCode = 0;
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].TestDateTime = lcl_str_QcDateTime;
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].Sequence = $('#tblDMTest').appendGrid('getCtrlValue', 'SheetSequence', i);
                var lcl_obj_StatusElement = $('#tblDMTest').appendGrid('getCellCtrl', 'Status', i);
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].Status = $(lcl_obj_StatusElement).data("STATUS");
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].PeelOffPercentage = $('#tblDMTest').appendGrid('getCtrlValue', 'PeelOffPercentage', i);
                lcl_obj_SMMasterBatch.ScpmSmSubBatchList[0].SMQCMasterList[0].PeelOffTests[i].PossibleGlitch = $('#tblDMTest').appendGrid('getCtrlValue', 'GlitchType', i);
            }

            alert(JSON.stringify(lcl_obj_SMMasterBatch));

            $.ajax(
            {
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                global: true,
                url: gbl_URL_Root + "WebServices/SCPM/SMQCServices.asmx/SaveSMPeelOffQC",
                data: "{IP_obj_SMMasterBatch: " + JSON.stringify(lcl_obj_SMMasterBatch) + "}", //provide input for the getSM_PO method
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode < 0) {
                        DisplayError(WSReturn.Message);
                        return;
                    }
                    var lcl_obj_SMQCRandomGeneratorSvr = WSReturn.Data;
                    DisplaySuccess("DATA SAVED SUCCESSFULLY");
                    //Clear existing option excepty Index 0
                    //var lcl_i32_NumberOfRandomSequence = lcl_obj_SMQCRandomGeneratorSvr.RandomSequences.length;
                },
                error: function (event, jqxhr, settings, exception) {
                    DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                }
            });





            var lcl_str_ResultHTML = "<table style='width:60%;margin:0 auto;border:1px ridge black;font-size:14px;'>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td colspan='2' style='border:1px ridge black;font-size:18px;text-align:center;padding:5px;'>";
            lcl_str_ResultHTML += "SilkERP360-Silk Production Management System v.1.0";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr style='width:100%;'>";
            lcl_str_ResultHTML += "<tr style='width:100%;'>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Customer ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtCustomer").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Section ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#ddlSection option:selected").text();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Machine ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#ddlMachine option:selected").text();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Process ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtProductionProcess").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Production Date ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtDate").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Master Batch ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtMasterBatch").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Sub Batch ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtSubBatch").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Quantity ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += $("#txtBatchQuantity").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td style='width:40%;border:1px ridge black;font-size:14px;'>";
            lcl_str_ResultHTML += "Status ";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "<td style='width:60%;border:1px ridge black;font-size:14px;font-weight:bold;'>";
            lcl_str_ResultHTML += $("#txtBatchStatus").val();
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "<tr>";
            lcl_str_ResultHTML += "<td colspan='2' style='border:0px ridge black;font-size:14px;text-align:center;padding:5px;'>";
            lcl_str_ResultHTML += "<input type='button' value='Print' style='width:100px;margin:0 auto;' />";
            lcl_str_ResultHTML += "</td>";
            lcl_str_ResultHTML += "</tr>";

            lcl_str_ResultHTML += "</table>";

            DisplayNotification(lcl_str_ResultHTML);

            //return ;

            //lcl_obj_MasterBatch
        }