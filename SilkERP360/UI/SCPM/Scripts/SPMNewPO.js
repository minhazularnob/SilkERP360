var GBL_GRID_SCRATCH_CARD_PO;
var GBL_GRID_SIM_CARD_PO;
$(document).ready(function ($) {
   
    $("#txtPODate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtPOIssueDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtSCDeliveryDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtSCExpiryDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtSIMDeliveryDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    /********************************************************************************************************************************************/
    //Hook Events
    $('#ddlTelco').change(function (event) { TelcoChanged(event); });
    /********************************************************************************************************************************************/

    GBL_GRID_SCRATCH_CARD_PO = $('#tblScratchcardPO').appendGrid({
        caption: 'Scratchcard P.O Details',
        initRows: 0,
        columns: [
                    { name: 'txtSCItemCode', type: 'hidden', value: 0 },
                    { name: 'txtSCItem', display: 'Item', type: 'text', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                    { name: 'txtSCDenomination', display: 'Deno.', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'hdnDenomination', type: 'hidden', value: 0 },
                    { name: 'txtSCQuantity', display: 'Qty.', type: 'text', value: '0', displayCss: { 'width': '4%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'ddlMeasurementUnit', type: 'select', display: 'M.Unit', displayCss: { 'width': '4%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 1: 'Piece', 2: 'PIN'} },
                    { name: 'txtSCDeliveryDate', display: 'Del. Date', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSCExpiryDate', display: 'Exp. Date', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'ddlSCHRNCover', type: 'select', display: 'HRN Cover', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: 'Single Label', 2: 'Sandwich Label', 3: 'Flexo Label'} },
                    { name: 'ddlSCOverprint', type: 'select', display: 'Ovr Prnt.', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'No', 1: 'Yes'} },
                    { name: 'ddlSCWrapping', type: 'select', display: 'Wrapping', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'No', 1: 'Yes'} },
                    { name: 'txtSCPackagingBox', display: 'O.Box', type: 'text', value: '0', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSCBoxStartSL', display: 'Box St SL.', type: 'text', value: '1', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSCRemarks', display: 'Remarks', type: 'text', value: '', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'RecordId', type: 'hidden', value: 0 }
                    ],
        hideButtons: {
            remove: false,
            removeLast: true,
            insert: true,
            append: true
        },
        hideRowNumColumn: false,
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            /*********************************************************************************************************************/
            //Check If The row is a new inclusion in the grid

            /*********************************************************************************************************************/
        }

    });

    GBL_GRID_SIM_CARD_PO = $('#tblSIMPO').appendGrid({
        caption: 'SIM P.O Details',
        initRows: 0,
        columns: [
                    { name: 'txtSIMItemCode', type: 'hidden', value: 0 },
                    { name: 'txtSIMItem', display: 'Item', type: 'text', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center'} },
                    { name: 'txtSIMDescHLR', display: 'HLR/Desc', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSIMQuantity', display: 'Quantity', type: 'text', value: '', displayCss: { 'width': '8%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSIMDeliveryDate', display: 'Del. Date', type: 'text', value: '', displayCss: { 'width': '7%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'ddlSIMChipType', type: 'select', display: 'Chip Type', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: '32k Native', 2: '64k Java', 3: '128k Java', 4: '256k Java'} },
                    { name: 'ddlSIMDye', type: 'select', display: 'Dye', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: '2FF (Regular)', 2: '3FF (Micro)', 3: '4FF (Nano)', 4: 'Combo (2FF+3FF+4FF'} },
                    { name: 'ddlSIMCoding', type: 'select', display: 'Coding', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: 'Tiyanu', 2: 'G & D', 3: 'Bluefish'} },
                    { name: 'ddlSIMPerso', type: 'select', display: 'Perso', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: 'Graphical & Electrical'} },
                    { name: 'ddlSIMModule', type: 'select', display: 'Module', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 0: 'Not Specified', 1: 'Flash', 2: 'Mask', 3: 'Chip Embedding', 4: 'GSM Punch & Stamping'} },
                    { name: 'txtSIMPackagingBox', display: 'O.Box', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSIMBoxStartSL', display: 'Box St SL.', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtSIMRemarks', display: 'Remarks', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'RecordId', type: 'hidden', value: 0 }
                    ],
        hideButtons: {
            remove: false,
            removeLast: true,
            insert: true,
            append: true
        },
        hideRowNumColumn: false,
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            /*********************************************************************************************************************/
            //Check If The row is a new inclusion in the grid

            /*********************************************************************************************************************/
        }

    });
});

function DisplayScratchcardPO(event) {
    $("#dvSIMCardPO").hide("slow", function () {
        $("#dvScratchCardPO").show("slow");
    });
}

function DisplaySIMPO(event) {
    $("#dvScratchCardPO").hide("slow", function () {
        $("#dvSIMCardPO").show("slow");
    });
}

function ClearAll() {
    $('.SC_IP').val('');
    $('.SIM_IP').val('');
    $('.PO_IP').val('');
    $('select[id$=ddlSCItem] > option:gt(0)').remove();
    $('select[id$=ddlSIMItem] > option:gt(0)').remove();
    //Clear AppendGrid for both SIM & Scratch Card
    $('.TELCO_INDEX_CHANGED').val('');

    var lcl_i32_NumberOfSC = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getRowCount');
    //alert(lcl_i32_NumberOfSC.toString());
    if (lcl_i32_NumberOfSC > 0) {
        for (var i = 0; i < lcl_i32_NumberOfSC; i++) {
            $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('removeRow', 0);
        }
    }

    var lcl_i32_NumberOfSM = $(GBL_GRID_SIM_CARD_PO).appendGrid('getRowCount');
    //alert(lcl_i32_NumberOfSC.toString());
    if (lcl_i32_NumberOfSM > 0) {
        for (var j = 0; j < lcl_i32_NumberOfSM; j++) {
            $(GBL_GRID_SIM_CARD_PO).appendGrid('removeRow', 0);
        }
    }
}

function TelcoChanged(event) {
    var lcl_i32_TelcoSelectedIndex = $('#ddlTelco option:selected').index();
    if (lcl_i32_TelcoSelectedIndex == 0) {

        ClearAll();
        return false;
    }
    ClearAll();
   

    var lcl_i32_CustomerCode = $('#ddlTelco option:selected').val();
    //alert(lcl_i32_CustomerCode);


    var options = {};
    options.url = gbl_URL_Root + "WebServices/SPM/SPMServices.asmx/GetProductMasterListByCustomer";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CustomerCode: " + lcl_i32_CustomerCode + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 1) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        var lcl_obj_SpmProductMasterList = lcl_obj_WSResponse.Data;


        $('select[id$=ddlSCItem] > option:gt(0)').remove();
        $('select[id$=ddlSIMItem] > option:gt(0)').remove();
        var lcl_objLst_ItemList = lcl_obj_WSResponse.Data;
        var ddl_option_sc = "";
        var ddl_option_sim = "";
        $.each(lcl_obj_SpmProductMasterList, function (index, lcl_obj_SpmProductMaster) {
            //alert(lcl_objLst_ItemList[index].ProductCode + " " + lcl_objLst_ItemList[index].ProductName);
            if (lcl_obj_SpmProductMaster.ProductType == 1) {
                ddl_option_sim += "<option value='" + lcl_obj_SpmProductMaster.SpmProductCode + "'>" + lcl_obj_SpmProductMaster.ProductName + "</option>";
            }
            if (lcl_obj_SpmProductMaster.ProductType == 2) {
                alert(lcl_obj_SpmProductMaster.SpmProductCode.toString());
                ddl_option_sc += "<option value='" + lcl_obj_SpmProductMaster.SpmProductCode + "'>" + lcl_obj_SpmProductMaster.ProductName + "</option>";
            }
        });
        $('#ddlSCItem').append(ddl_option_sc);
        $('#ddlSIMItem').append(ddl_option_sim);

        /********************************************************************************************************************/

    };

    options.error = function (err) { DisplayError(err.statusText); };

    $.ajax(options);
}

function InsertSCItemToGrid(event) {
    var lcl_i32_SCItemSelectedIndex = $("#ddlSCItem option:selected").index();
    if (lcl_i32_SCItemSelectedIndex == 0) {
        return;
    }
    var lcl_str_DeliveryDate = $("#txtSCDeliveryDate").val();
    var lcl_str_ExpiryDate = $("#txtSCExpiryDate").val();
    var lcl_i32_SCDenomination = $("#ddlSCItemDenomination option:selected").index();

    if ((lcl_str_DeliveryDate == '') || (lcl_str_ExpiryDate == '') || (lcl_i32_SCDenomination == 0)) {
        DisplayError("The Fields 'DeliveryDate' & 'ExpiryDate' & 'Denomination' must be filled!!!");
        return;
    }

    var lcl_str_SCDenomination = $("#ddlSCItemDenomination option:selected").text();
    var lcl_i32_SCDenomination = $("#ddlSCItemDenomination option:selected").val();

    var lcl_ui64_SCProductCode = $("#ddlSCItem option:selected").val();
    var lcl_ui64_SCProductName = $("#ddlSCItem option:selected").text();
    //alert(lcl_ui64_SCProductCode);
    //Check If Selected ProductCode has already been added to the grid
    var lcl_i32_RowCount = $('#tblScratchcardPO').appendGrid('getRowCount');
    for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
        var lcl_ui64_EnteredSCProductCode = $('#tblScratchcardPO').appendGrid('getCtrlValue', 'txtSCItemCode', lcl_i32_Counter);
        if (lcl_ui64_EnteredSCProductCode == lcl_ui64_SCProductCode) {
            DisplayError("Selected 'Scratchcard' Item has Already been added to the grid!!!");
            return;
        }
    }
    //All Validation Ok. Enter the Product into the Grid
    $('#tblScratchcardPO').appendGrid('appendRow', [
                    { txtSCItemCode: lcl_ui64_SCProductCode,
                        txtSCItem: lcl_ui64_SCProductName,
                        txtSCDenomination: lcl_str_SCDenomination,
                        hdnDenomination:lcl_i32_SCDenomination,
                        txtSCQuantity: '0',
                        txtSCDeliveryDate: lcl_str_DeliveryDate,
                        txtSCExpiryDate: lcl_str_ExpiryDate,
                        ddlSCHRNCover: 0,
                        ddlSCOverprint: 0,
                        ddlSCWrapping: 0,
                        txtSCPackagingBox: '0',
                        txtSCBoxStartSL: '1',
                        txtSCRemarks: ''
                    }]);
}
function InsertSIMItemToGrid(event) {
    var lcl_i32_SIMItemSelectedIndex = $("#ddlSIMItem option:selected").index();
    if (lcl_i32_SIMItemSelectedIndex == 0) {
        return;
    }
    var lcl_str_SIMDeliveryDate = $("#txtSIMDeliveryDate").val();

    if (lcl_str_SIMDeliveryDate == '') {
        DisplayError("The Fields 'DeliveryDate' must be filled!!!");
        return;
    }

    var lcl_ui64_SIMProductCode = $("#ddlSIMItem option:selected").val();
    var lcl_ui64_SIMProductName = $("#ddlSIMItem option:selected").text();
    //Check If Selected ProductCode has already been added to the grid
    var lcl_i32_RowCount = $('#tblSIMPO').appendGrid('getRowCount');
    for (var lcl_i32_Counter = 0; lcl_i32_Counter < lcl_i32_RowCount; lcl_i32_Counter++) {
        var lcl_ui64_EnteredSIMProductCode = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMItemCode', lcl_i32_Counter);
        if (lcl_ui64_EnteredSIMProductCode == lcl_ui64_SIMProductCode) {
            DisplayError("Selected 'SIM' Item has Already been added to the grid!!!");
            return;
        }
    }
    //All Validation Ok. Enter the Product into the Grid
    $('#tblSIMPO').appendGrid('appendRow', [
                    { txtSIMItemCode: lcl_ui64_SIMProductCode,
                        txtSIMItem: lcl_ui64_SIMProductName,
                        txtSIMDescHLR: '',
                        txtSIMQuantity: '',
                        txtSIMDeliveryDate: lcl_str_SIMDeliveryDate,
                        ddlSIMChipType: 0,
                        ddlSIMDye: 0,
                        ddlSIMCoding: 0,
                        ddlSIMPerso: 0,
                        ddlSIMModule: 0,
                        txtSIMPackagingBox: '',
                        txtSIMBoxStartSL: '',
                        txtSIMRemarks: ''
                    }]);
}

function SaveScratchCardPurchaseOrder(event) {

    var lcl_obj_SPMScPurchaseOrder = new Object();
    lcl_obj_SPMScPurchaseOrder.CustomerCode = $('#ddlTelco option:selected').val();
    lcl_obj_SPMScPurchaseOrder.EntryEmployeeCode = $('#txtSignedEmployeeCode').val();
    lcl_obj_SPMScPurchaseOrder.IssueDate = $('#txtPOIssueDate').val();
    lcl_obj_SPMScPurchaseOrder.PORefNumber = $('#txtPOReferenceNo').val();
    //lcl_obj_SCPMPurchaseOrder.ProductType = 2; //Scratch Card
    lcl_obj_SPMScPurchaseOrder.Remarks = $('#txtSCNotes').val();

    lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems = new Array();
    var lcl_i32_RowCount = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getRowCount');
    //alert(lcl_i32_RowCount);
    for (var j = 0; j < lcl_i32_RowCount; j++) {
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j] = new Object();
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].SpmProductCode = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCItemCode', j);
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].Quantity = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCQuantity', j);
        var lcl_objCtrl_UnitOfMeasurement = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCellCtrl', 'ddlMeasurementUnit', j);
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].MeasurementUnit = $('option:selected', lcl_objCtrl_UnitOfMeasurement).val();
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].Denomination = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'hdnDenomination', j);
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].Remarks = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCRemarks', j);
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].ExpiryDate = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCExpiryDate', j);
        lcl_obj_SPMScPurchaseOrder.PurchaseOrderItems[j].DeliveryStartDate = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCDeliveryDate', j);
    }

    //Scratchcard Job Order
    var lcl_obj_SPMScJobOrder = new Object();
    lcl_obj_SPMScJobOrder.CustomerCode = $('#ddlTelco option:selected').val();
    lcl_obj_SPMScJobOrder.ArtWork = $('#txtSCArtWork').val();
    lcl_obj_SPMScJobOrder.EntryEmployeeCode = $('#txtSignedEmployeeCode').val();
    lcl_obj_SPMScJobOrder.PaperWeight = $('#txtSCPaperWeight').val();
    lcl_obj_SPMScJobOrder.Remarks = $('#txtSCNotes').val();
    lcl_obj_SPMScJobOrder.Version = $('#txtSCVersion').val();

    lcl_obj_SPMScJobOrder.ScJobOrderItems = new Array();
    lcl_i32_RowCount = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_RowCount; i++) {
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i] = new Object();
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].SpmProductCode = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCItemCode', i);
        //lcl_obj_SPMScJobOrder.ScJobOrderItems[i].DeliveryDate = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCDeliveryDate', i);
        //var lcl_objCtrl_Denomination = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCellCtrl', 'hdnDenomination', i);
        //lcl_obj_SPMScJobOrder.ScJobOrderItems[i].Denomination = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'hdnDenomination', i);
        //lcl_obj_SPMScJobOrder.ScJobOrderItems[i].ExpiryDate = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCExpiryDate', i);
        var lcl_objCtrl_HRNCover = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCellCtrl', 'ddlSCHRNCover', i);
        // lcl_obj_SCPMSCJobOrder.JobOrderItems[i].HRNCover = $('option:selected', lcl_objCtrl_HRNCover).text(); //  $('#tblScratchcardPO').appendGrid('getCtrlValue', 'ddlSCHRNCover', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].HrnCover = $('option:selected', lcl_objCtrl_HRNCover).val(); //  $('#tblScratchcardPO').appendGrid('getCtrlValue', 'ddlSCHRNCover', i);
        //alert("HRN Cover" + lcl_obj_SCPMSCJobOrder.ScJobOrderItems[i].HRNCover);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].OuterBox = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCPackagingBox', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].BoxSlStart = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCBoxStartSL', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].OverPrint = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'ddlSCOverprint', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].Quantity = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCQuantity', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].Remarks = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'txtSCRemarks', i);
        lcl_obj_SPMScJobOrder.ScJobOrderItems[i].Wrapping = $(GBL_GRID_SCRATCH_CARD_PO).appendGrid('getCtrlValue', 'ddlSCWrapping', i);
    }
    //alert("Object Initialization Completed");
    var options_sc_po = {};
    options_sc_po.url = gbl_URL_Root + "WebServices/SPM/SPMServices.asmx/SaveScratchcardPO";
    options_sc_po.dataType = "json";
    options_sc_po.type = "POST";
    options_sc_po.data = "{IP_obj_SpmScPurchaseOrder: " + JSON.stringify(lcl_obj_SPMScPurchaseOrder) + ",IP_obj_SpmScJobOrder:" + JSON.stringify(lcl_obj_SPMScJobOrder) + "}"; // JSON.stringify(lcl_obj_LogFile);
    options_sc_po.contentType = "application/json; charset=utf-8";

    //options.processData = false;
    options_sc_po.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            DisplaySuccess(lcl_obj_WSResponse.Message);
            return;
        }
    };
    options_sc_po.error = function (err) { DisplayError(err.statusText); };

    $.ajax(options_sc_po);
}

function SaveSimCardPurchaseOrder(event) {

    var lcl_obj_SCPMPurchaseOrder = new Object();
    lcl_obj_SCPMPurchaseOrder.CustomerCode = $('#ddlTelco option:selected').val();
    lcl_obj_SCPMPurchaseOrder.EntryEmployeeCode = $('#txtSignedEmployeeCode').val();
    lcl_obj_SCPMPurchaseOrder.IssueDate = $('#txtPOIssueDate').val();
    lcl_obj_SCPMPurchaseOrder.PORefCode = $('#txtPOReferenceNo').val();
    lcl_obj_SCPMPurchaseOrder.ProductType = 2; //Scratch Card
    lcl_obj_SCPMPurchaseOrder.Remarks = $('#txtSCNotes').val();

    lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems = new Array();
    var lcl_i32_RowCount = $('#tblSIMPO').appendGrid('getRowCount');
    alert(lcl_i32_RowCount);
    for (var j = 0; j < lcl_i32_RowCount; j++) {
        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems[j] = new Object();
        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems[j].ProductCode = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMItemCode', j);
        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems[j].Quantity = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMQuantity', j);
        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems[j].Remarks = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMRemarks', j);
        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems[j].DeliveryDate = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMDeliveryDate', j);
    }

    //Scratchcard Job Order
    var lcl_obj_SCPMSIMJobOrder = new Object();
    lcl_obj_SCPMSIMJobOrder.ArtWork = $('#txtSIMArtWork').val();
    lcl_obj_SCPMSIMJobOrder.EntryEmployeeCode = $('#txtSignedEmployeeCode').val();
    lcl_obj_SCPMSIMJobOrder.Design = $('#txtSIMDesign').val();
    lcl_obj_SCPMSIMJobOrder.Remarks = $('#txtSIMNotes').val();
    lcl_obj_SCPMSIMJobOrder.LaminationFront = $('#ddlSIMLaminationFront option:selected').text();
    lcl_obj_SCPMSIMJobOrder.LaminationBack = $('#ddlSIMLaminationBack option:selected').text();
    lcl_obj_SCPMSIMJobOrder.MaterialDensity = $('#txtSIMMaterialDensity').val();
    lcl_obj_SCPMSIMJobOrder.VarnishBack = $('#ddlSIMVarnishBack option:selected').text();
    lcl_obj_SCPMSIMJobOrder.VarnishFront = $('#ddlSIMVarnishFront option:selected').text();


    lcl_obj_SCPMSIMJobOrder.SimJobOrderItems = new Array();
    lcl_i32_RowCount = $('#tblSIMPO').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_RowCount; i++) {
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i] = new Object();
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].ChipType = $('#tblSIMPO').appendGrid('getCtrlValue', 'ddlSIMChipType', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Coding = $('#tblSIMPO').appendGrid('getCtrlValue', 'ddlSIMCodng', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].DeliveryDate = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMDeliveryDate', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Dye = $('#tblSIMPO').appendGrid('getCtrlValue', 'ddlSIMDye', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Module = $('#tblSIMPO').appendGrid('getCtrlValue', 'ddlSIMModule', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].OuterBox = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMPackagingBox', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Perso = $('#tblSIMPO').appendGrid('getCtrlValue', 'ddlSIMPerso', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].ProductCode = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMItemCode', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Quantity = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMQuantity', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].Remarks = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMRemarks', i);
        lcl_obj_SCPMSIMJobOrder.SimJobOrderItems[i].StartBoxSerial = $('#tblSIMPO').appendGrid('getCtrlValue', 'txtSIMBoxStartSL', i);
    }

    alert("Object Initialization Completed");
    var options_sim_po = {};
    options_sim_po.url = gbl_URL_Root + "WebServices/SCPM/SCPMServices.asmx/SaveSIMCardPO";
    options_sim_po.dataType = "json";
    options_sim_po.type = "POST";
    options_sim_po.data = "{IP_obj_ScpmPurchaseOrder: " + JSON.stringify(lcl_obj_SCPMPurchaseOrder) + ",IP_obj_ScpmSimJobOrder:" + JSON.stringify(lcl_obj_SCPMSIMJobOrder) + "}"; // JSON.stringify(lcl_obj_LogFile);
    options_sim_po.contentType = "application/json; charset=utf-8";

    //options.processData = false;
    options_sim_po.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
    };
    options_sim_po.error = function (err) { DisplayError(err.statusText); };

    $.ajax(options_sim_po);
}




