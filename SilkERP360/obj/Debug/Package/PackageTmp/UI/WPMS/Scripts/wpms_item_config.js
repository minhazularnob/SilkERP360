var gbl_obj_CompanyDepartments = new Object(); //Stores DepartmentCore Objects, CompanyCode wise
var GblColors;
var GBLColorsArray = new Array();
//Newly added Items will be stored here
var GblNewItems = new Array();
//Item list loaded currently
var GblItemsList = new Array();
var GblItemImageList = new Array(); //Sample Images of the items will be stored here
var GblImageUploadDialog;
var GblNoImageBanner = new Image(640,450);
var GBLItemSlider;

$(document).ready(function () {
    //alert("LOADING");/// <reference path="../../../Globals/Images/no-image-available.jpg" />

    GblNoImageBanner.src = "../../../Globals/Images/no-image-available.jpg";
//    var lcl_str_HTML = "<ul id='pgwSlider' class='pgwSlider'>" +
//                              + "<li>" 
//                                    + "<img src='../../../Globals/Images/no-image-available.jpg' alt='No Image Uploaded!' >" +
//                                "</li>" +
//                        "</ul>";
var lcl_str_HTML =  "<li><img src='../../../Globals/Images/no-image-available.jpg' alt='No Image Uploaded!'/></li>" ;
                        
                       
    //ConfigureImageSlider();
    //$("#dvImageGallery").html("");
    //$("#dvImageGallery ul").append(lcl_str_HTML);
    //GBLItemSlider = $('.pgwSlider').pgwSlider();
    //alert(GBLItemSlider);
    $("#fileBrowser").data('smpl_img', '');
    $("#fileBrowser").data('smpl_img_added', false);
    /***********************************************************************************************************/
    //Get Colors and Save in Global variable GblColors;
    /***********************************************************************************************************/
    $.ajax(
            {
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: gbl_URL_Root + "../../../WebServices/WPMS/PantoneColorServices.asmx/GetColors", /// <reference path="" />
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode == 0) {

                        //DisplayInformation(WSReturn.Message.toString());
                        GblColors = WSReturn.Data;
                        return true;
                    }
                    else {
                        DisplayError(WSReturn.Message.toString());
                    }
                },
                error: function (data) {
                    alert(data);

                }
            });

    //Create JSON string for controloptions
    var lcl_str_ColorString = "0 : 'Choose Color'";
    GBLColorsArray[0] = "Choose Color";
    $.each(GblColors, function (index, lcl_obj_GblColor) {
        GBLColorsArray[(index + 1)] = lcl_obj_GblColor.Name;
    });
    //GBLColorsString = lcl_str_ColorString;
    /***********************************************************************************************************/
    /***********************************************************************************************************/



    $("#tbItemsConfig").tabs();


    $('#tblItems').appendGrid({
        caption: 'Product Information',
        initRows: 1,
        columns: [
        //                                 { name: 'Image', display: 'img', type: 'image'},
                {name: 'txtItemCode', display: 'ItemCode', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'hidden', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtItemName', display: 'ItemName', displayCss: { 'text-align': 'center', 'width': '15%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtRefCode', display: 'Ref.Code', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtWidth', display: 'Width', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtGusset', display: 'Gusset', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtLength', display: 'Length', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtDensity', display: 'Density', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtThickness', display: 'Thknss',displayTooltip: 'Thickness', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'}  ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Thickness',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtPunchOut', display: 'P.Out',displayTooltip: 'Punch Out', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Punch Out',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtHandleWidth', display: 'H.Wdth',displayTooltip: 'Handle Width', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Handle Width',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtHandleLength', display: 'H.Lngth',displayTooltip: 'Handle Length', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Handle Length',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtPackingArea', display: 'P.Area',displayTooltip: 'Packaging Area', displayCss: { 'text-align': 'center', 'width': '3%' }, type: 'text', ctrlClass: 'required', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Packaging Area',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtProcessingCost', display: 'P. Cost',displayTooltip: 'Processing Cost', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', value: 0, type: 'text', ctrlCss: { width: '100%', 'text-align': 'center'},
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Processing Cost',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }
                },
                { name: 'txtPrintingCharge', display: 'P. Chrg',displayTooltip: 'Printing Charge', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', value: 0, type: 'text', ctrlCss: { width: '100%', 'text-align': 'center'},
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Printing Charge',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        } 
                        },
                { name: 'txtHD', display: 'HD', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtHDPE', display: 'HDPE', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtLLDPE', display: 'LLDPE', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtCOCO', display: 'COCO', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtLDPE', display: 'LDPE', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtRecycle', display: 'R.Cycl',displayTooltip: 'Recycle', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Recycle',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        } },
                { name: 'txtThinner', display: 'Thnr.',displayTooltip: 'Thinner', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'}  ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Thinner',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        }},
                { name: 'txtD2W', display: 'D2W', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtEPI', display: 'EPI', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtAntiSlip', display: 'A.Slip',displayTooltip: 'Anti-Slip', displayCss: { 'text-align': 'center', 'width': '3%' }, ctrlClass: 'required', type: 'text', value: 0, ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Anti-Slip',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        } },
                { name: 'txtItemCodeHdn', type: 'hidden', value: '' },
                { name: 'txtNote', display: 'Note',displayTooltip: 'Note', displayCss: { 'text-align': 'center', 'width': '10%' }, ctrlClass: 'required', type: 'text', value: '', ctrlCss: { width: '100%', 'text-align': 'center'} ,
                            uiTooltip: {
                                            items: 'input',
                                            content: 'Note',
                                            show: {
                                                effect: 'slideDown',
                                                delay: 250
                                            } 
                                        } },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        customRowButtons: [
            {
                uiButton: { icons: { primary: 'ui-icon-image' }, text: false},
                click: function (evtObj, uniqueIndex, rowData) {
                     ShowUploadImageDialog(evtObj, uniqueIndex, rowData);
                }, btnCss: { 'min-width': '20px' },
                btnAttr: { title: 'Upload Sample Image' }, atTheFront: true
            }
        ],
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            //Add parallal Row to MasterBatch
            //            $('#tblMasterBatch').appendGrid('appendRow', [
            //                { txtMBWhite: '0', txtMBBlue: '0', txtMBGreen: '0', txtMBRed: '0', txtMBYellow: '0', txtMBLory: '0', txtMBBergundy: '0', txtMBPink: '0', txtMBLemonGrass: '0', txtMBBlack: '0', txtMBOrange: '0' }
            //            ]);

            //            $('#tblInk').appendGrid('appendRow', [
            //                { txtInkGermanium: '0', txtInkLemonYellow: '0', txtInkMidYellow: '0', txtInkRoyalBlue: '0', txtInkBlue: '0', txtInkMolibDataOrange: '0', txtInkGreen: '0', txtInkGrassGreen: '0', txtInkPeacockBlue: '0', txtInkAjinomotoRed: '0', txtInkReflexBlue: '0', txtInkWhite: '0', txtInkSilver: '0' }
            //            ]);
        },
        beforeRowRemove: function (caller, rowIndex) {
            var lcl_str_ItemCode = $(caller).appendGrid('getCtrlValue', 'txtItemCode', rowIndex);
            if ($.trim(lcl_str_ItemCode) != '') {
                ShowInfoMessageBoard("Operational Error : You are not permitted to delete this row!!!");
                return false;
            }
            return true;
        },
        hideButtons: {
            append: false,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: false,
            removeLast: true
        }
    });


    $('#tblMasterBatch').appendGrid({
        caption: 'Master Batch',
        initRows: 1,
        columns: [
        //                                 { name: 'Image', display: 'img', type: 'image'},
                                 {name: 'txtMasterBatchCode', display: 'Code', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center', 'readonly': 'readonly'} },
                                 { name: 'ddlMasterBatchColor', display: 'Color', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'select', ctrlOptions: GBLColorsArray, ctrlClass: 'required', ctrlCss: { width: '97%', 'text-align': 'center' },
                                     onChange: function (evt, rowIndex) {
                                         //alert('You have changed value of Album at row ' + rowIndex);
                                         var ddlColorSelection = $('#tblMasterBatch').appendGrid('getCellCtrl', 'ddlMasterBatchColor', rowIndex);
                                         var lcl_str_SelectedColor = $(ddlColorSelection).val();
                                         var lcl_b_ColorFound = false;
                                         $.each(GblColors, function (index, lcl_obj_GblColor) {
                                             if (lcl_obj_GblColor.Name == lcl_str_SelectedColor) {
                                                 //Selected Color Found
                                                 $('#tblMasterBatch').appendGrid('setCtrlValue', 'txtMasterBatchColorHex', rowIndex, lcl_obj_GblColor.Hex);
                                                 $('#tblMasterBatch').appendGrid('setCtrlValue', 'txtMasterBatchColorPantone', rowIndex, lcl_obj_GblColor.PantoneCode);
                                                 var txtColorPreview = $('#tblMasterBatch').appendGrid('getCellCtrl', 'txtMasterBatchColorPreview', rowIndex);
                                                 $(txtColorPreview).css('background-color', lcl_obj_GblColor.Hex);
                                                 lcl_b_ColorFound = true;
                                             }
                                         });
                                         //if control reaches here, selected color not found
                                         //alert(lcl_i32_SelectedIndex);
                                         if (lcl_b_ColorFound == false) {
                                             $('#tblMasterBatch').appendGrid('setCtrlValue', 'txtMasterBatchColorHex', rowIndex, '');
                                             $('#tblMasterBatch').appendGrid('setCtrlValue', 'txtMasterBatchColorPantone', rowIndex, '');
                                             var txtColorPreview1 = $('#tblMasterBatch').appendGrid('getCellCtrl', 'txtMasterBatchColorPreview', rowIndex);
                                             $(txtColorPreview1).css('background-color', '#fff');
                                         }
                                     }
                                 },
                                 { name: 'txtMasterBatchColorPantone', display: 'Pantone', displayCss: { 'text-align': 'center', 'width': '20%' }, ctrlAttr: { 'readonly': 'readonly' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'txtMasterBatchColorHex', display: 'HEX', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'txtMasterBatchColorPercentage', display: 'Master Batch %', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'txtMasterBatchColorPreview', display: 'Preview', displayCss: { 'text-align': 'center', 'width': '20%' }, ctrlAttr: { 'readonly': 'readonly' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

        hideButtons: {
            append: false,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: true,
            removeLast: true
        }
    });


    $('#tblInk').appendGrid({
        caption: 'Ink',
        initRows: 1,
        columns: [
                                 { name: 'txtInkCode', display: 'Code', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'ddlInkColor', display: 'Color', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'select', ctrlAttr: { 'readonly': 'readonly' }, ctrlOptions: GBLColorsArray, ctrlClass: 'required', ctrlCss: { width: '97%', 'text-align': 'center' },
                                     onChange: function (evt, rowIndex) {
                                         //alert('You have changed value of Album at row ' + rowIndex);
                                         var ddlInkColor = $('#tblInk').appendGrid('getCellCtrl', 'ddlInkColor', rowIndex);
                                         var lcl_str_SelectedColor = $(ddlInkColor).val();
                                         var lcl_b_ColorFound = false;
                                         $.each(GblColors, function (index, lcl_obj_GblColor) {
                                             if (lcl_obj_GblColor.Name == lcl_str_SelectedColor) {
                                                 //Selected Color Found
                                                 $('#tblInk').appendGrid('setCtrlValue', 'txtInkColorHex', rowIndex, lcl_obj_GblColor.Hex);
                                                 $('#tblInk').appendGrid('setCtrlValue', 'txtInkColorPantone', rowIndex, lcl_obj_GblColor.PantoneCode);
                                                 var txtColorPreview = $('#tblInk').appendGrid('getCellCtrl', 'txtInkColorPreview', rowIndex);
                                                 $(txtColorPreview).css('background-color', lcl_obj_GblColor.Hex);
                                                 lcl_b_ColorFound = true;
                                             }
                                         });
                                         //if control reaches here, selected color not found
                                         //alert(lcl_i32_SelectedIndex);
                                         if (lcl_b_ColorFound == false) {
                                             $('#tblInk').appendGrid('setCtrlValue', 'txtInkColorHex', rowIndex, '');
                                             $('#tblInk').appendGrid('setCtrlValue', 'txtInkColorPantone', rowIndex, '');
                                             var txtColorPreview1 = $('#tblInk').appendGrid('getCellCtrl', 'txtInkColorPreview', rowIndex);
                                             $(txtColorPreview1).css('background-color', '#fff');
                                         }
                                     }
                                 },
                                 { name: 'txtInkColorPantone', display: 'Pantone', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'txtInkColorHex', display: 'HEX', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'txtInkColorPreview', display: 'Preview', displayCss: { 'text-align': 'center', 'width': '20%' }, type: 'text', ctrlAttr: { 'readonly': 'readonly' }, ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

        hideButtons: {
            append: false,
            insert: true,
            moveUp: true,
            moveDown: true,
            remove: false,
            removeLast: true
        },
        beforeRowRemove: function (caller, rowIndex) {
            var lcl_str_InkCode = $(caller).appendGrid('getCtrlValue', 'txtInkCode', rowIndex);
            if ($.trim(lcl_str_InkCode) != '') {
                ShowInfoMessageBoard("Operational Error : You are not permitted to delete this row!!!");
                return false;
            }
            return true;
        },
    });

    //ConfigureImageSlider();
});

function LoadItemListByBuyerAndCatagory() {
    var lcl_ui64_BuyerCode = $("#ddlBuyer option:selected").val();
    var lcl_ui64_ItemCatagoryCode = $("#ddlItemCategory option:selected").val();
    if((lcl_ui64_BuyerCode == 0) || (lcl_ui64_ItemCatagoryCode == 0))
    {
        return;
    }
    var options = {};
    options.url = gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/GetItemListByBuyerAndCatagory";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_BuyerCode: " + JSON.stringify(lcl_ui64_BuyerCode) + ",IP_ui64_ItemCatagoryCode:" + lcl_ui64_ItemCatagoryCode + "}";
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        GblItemsList = [];
        GblItemsList = lcl_obj_WSResponse.Data;
        var lcl_i32_Count = 0;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            lcl_i32_Count = $('#tblItems').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblItems').appendGrid('removeRow', 0);
            }
            //Load empty row
            $('#tblItems').appendGrid('appendRow', 1);
            ShowErrorMessageBoard(lcl_obj_WSResponse.Message)
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //Load Item Data In Grid
            lcl_i32_Count = $('#tblItems').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblItems').appendGrid('removeRow', 0);
            }
            var lcl_objLst_Data = new Array();
            $.each(GblItemsList, function (index, lcl_obj_Item) {
                lcl_i32_Count = $('#tblItems').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_Count; i++) {
                    $('#tblItems').appendGrid('removeRow', 0);
                }
                lcl_objLst_Data[index] = new Object();
                lcl_objLst_Data[index].txtItemCode = lcl_obj_Item.ItemCode;
                lcl_objLst_Data[index].txtItemName = lcl_obj_Item.ItemName;
                lcl_objLst_Data[index].txtRefCode = lcl_obj_Item.ItemRefCode;
                lcl_objLst_Data[index].txtWidth = lcl_obj_Item.Width;
                lcl_objLst_Data[index].txtGusset = lcl_obj_Item.Gusset;
                lcl_objLst_Data[index].txtLength = lcl_obj_Item.Length;
                lcl_objLst_Data[index].txtDensity = lcl_obj_Item.Density;
                lcl_objLst_Data[index].txtThickness = lcl_obj_Item.Thickness;
                lcl_objLst_Data[index].txtPunchOut = lcl_obj_Item.Punchout;
                lcl_objLst_Data[index].txtHandleWidth = lcl_obj_Item.HandleWidth;
                lcl_objLst_Data[index].txtHandleLength = lcl_obj_Item.HandleLength;
                lcl_objLst_Data[index].txtPackingArea = lcl_obj_Item.PackingArea;
                lcl_objLst_Data[index].txtProcessingCost = lcl_obj_Item.ProcessingCost;
                lcl_objLst_Data[index].txtPrintingCharge = lcl_obj_Item.PrintingCharge;
                lcl_objLst_Data[index].txtHD = lcl_obj_Item.HD;
                lcl_objLst_Data[index].txtHDPE = lcl_obj_Item.HDPE;
                lcl_objLst_Data[index].txtLLDPE = lcl_obj_Item.LLDPE;
                lcl_objLst_Data[index].txtCOCO = lcl_obj_Item.COCO;
                lcl_objLst_Data[index].txtLDPE = lcl_obj_Item.LDPE;
                lcl_objLst_Data[index].txtRecycle = lcl_obj_Item.Recycle;
                lcl_objLst_Data[index].txtThinner = lcl_obj_Item.Thinner;
                lcl_objLst_Data[index].txtD2W = lcl_obj_Item.D2W;
                lcl_objLst_Data[index].txtEPI = lcl_obj_Item.EPI;
                lcl_objLst_Data[index].txtAntiSlip = lcl_obj_Item.AntiSlip;
                lcl_objLst_Data[index].txtNote = lcl_obj_Item.Note;
                /****************************************************************************************************************************/
            });
            lcl_i32_Count = $('#tblItems').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblItems').appendGrid('removeRow', 0);
            }
            $('#tblItems').appendGrid('load', lcl_objLst_Data);

            //Clear Master Batch
            lcl_i32_Count = $('#tblMasterBatch').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblMasterBatch').appendGrid('removeRow', 0);
            }
            //Load a blank row in MasterBatch Table
            $('#tblMasterBatch').appendGrid('appendRow', [
                    { txtMasterBatchCode: '',
                        ddlMasterBatchColor: 0,
                        txtMasterBatchColorPantone: '',
                        txtMasterBatchColorHex: '',
                        txtMasterBatchColorPercentage: '',
                        txtMasterBatchColorPreview: ''
                    }
                ]);

            //Clear Ink Table
            lcl_i32_Count = $('#tblInk').appendGrid('getRowCount');
            for (var i = 0; i < lcl_i32_Count; i++) {
                $('#tblInk').appendGrid('removeRow', 0);
            }
            //Load a blank row\
            $('#tblInk').appendGrid('appendRow', [
                    { txtInkCode: '',
                        ddlInkColor: 0,
                        txtInkColorPantone: '',
                        txtInkColorHex: '',
                        txtInkColorPreview: ''
                    }
                ]);


            $("#ddlItem option:gt(0)").remove();
            $.each(GblItemsList, function (index, lcl_obj_Item) {
                var lcl_str_Item = '';
                if (lcl_obj_Item.ItemRefCode == '') {
                    lcl_str_Item = lcl_obj_Item.ItemName;
                }
                else {
                    lcl_str_Item = lcl_obj_Item.ItemName + " (Ref. Code : " + lcl_obj_Item.ItemRefCode + " )";
                }
                $('#ddlItem')
                .append($("<option></option>")
                .attr("value", lcl_obj_Item.ItemCode)
                .text(lcl_str_Item));
            });
        }

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
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);

}

function SaveItem() {
    //alert($('#tbItems').appendGrid('getCtrlValue', 'txtItemCode', 0));
    var lcl_i32_ItemCount = $('#tblItems').appendGrid('getRowCount');
    var lcl_i32_NewItemIndex = 0;
    for (var i = 0; i < lcl_i32_ItemCount; i++) {
        var lcl_str_ItemCode = $.trim(($('#tblItems').appendGrid('getCtrlValue', 'txtItemCode', i)));
        var lcl_str_ItemName = $.trim(($('#tblItems').appendGrid('getCtrlValue', 'txtItemName', i)));
        
        //alert(lcl_str_ItemCode);
        if ((lcl_str_ItemName != '') && (lcl_str_ItemCode == '')) {
            //New Item
            GblNewItems[lcl_i32_NewItemIndex] = new Object();
            GblNewItems[lcl_i32_NewItemIndex].BuyerCode = $("#ddlBuyer option:selected").val();
            GblNewItems[lcl_i32_NewItemIndex].ItemCatagoryCode = $("#ddlItemCategory option:selected").val();
            GblNewItems[lcl_i32_NewItemIndex].ItemName = $.trim(($('#tblItems').appendGrid('getCtrlValue', 'txtItemName', i)));
            GblNewItems[lcl_i32_NewItemIndex].ItemRefCode = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtRefCode', i));
            GblNewItems[lcl_i32_NewItemIndex].Width = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtWidth', i));
            GblNewItems[lcl_i32_NewItemIndex].Gusset = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtGusset', i));
            GblNewItems[lcl_i32_NewItemIndex].Length = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtLength', i));
            GblNewItems[lcl_i32_NewItemIndex].Density = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtDensity', i));
            GblNewItems[lcl_i32_NewItemIndex].Thickness = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtThickness', i));
            GblNewItems[lcl_i32_NewItemIndex].Punchout = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtPunchOut', i));
            GblNewItems[lcl_i32_NewItemIndex].HandleWidth = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtHandleWidth', i));
            GblNewItems[lcl_i32_NewItemIndex].HandleLength = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtHandleLength', i));
            GblNewItems[lcl_i32_NewItemIndex].PackingArea = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtPackingArea', i));
            GblNewItems[lcl_i32_NewItemIndex].ProcessingCost = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtProcessingCost', i));
            GblNewItems[lcl_i32_NewItemIndex].PrintingCharge = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtPrintingCharge', i));
            GblNewItems[lcl_i32_NewItemIndex].HD = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtHD', i));
            GblNewItems[lcl_i32_NewItemIndex].HDPE = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtHDPE', i));
            GblNewItems[lcl_i32_NewItemIndex].LLDPE = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtLLDPE', i));
            GblNewItems[lcl_i32_NewItemIndex].COCO = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtCOCO', i));
            GblNewItems[lcl_i32_NewItemIndex].LDPE = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtLDPE', i));
            GblNewItems[lcl_i32_NewItemIndex].Recycle = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtRecycle', i));
            GblNewItems[lcl_i32_NewItemIndex].Thinner = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtThinner', i));
            GblNewItems[lcl_i32_NewItemIndex].D2W = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtD2W', i));
            GblNewItems[lcl_i32_NewItemIndex].EPI = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtEPI', i));
            GblNewItems[lcl_i32_NewItemIndex].AntiSlip = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtAntiSlip', i));
            GblNewItems[lcl_i32_NewItemIndex].EntryEmployeeCode = $("#txtSignedInEmployeeCode").val();
            GblNewItems[lcl_i32_NewItemIndex].Note = $.trim($('#tblItems').appendGrid('getCtrlValue', 'txtNote', i));
            lcl_i32_NewItemIndex++;
        }
    }

    if (GblNewItems.length > 0) {
        //Save
        //alert("Saving");
        var options = {};
        options.url = gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveItemList";
        options.dataType = "json";
        options.type = "POST";
        options.data = "{IP_objLst_ItemList: " + JSON.stringify(GblNewItems) + "}";
        options.contentType = "application/json; charset=utf-8";
        //options.processData = false;
        options.success = function (result) {
            var lcl_obj_WSResponse = result.d;
            $(".SyncAssessmentStatus").prop("disabled", true);
            LoadItemListByBuyerAndCatagory();

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
    }
}

function ShowMasterBatchAndInk() {
    var lcl_ui64_ItemCode = $("#ddlItems option:selected").val();
    var lcl_b_ItemFound = false;
    var lcl_str_Msg = '';
    $.each(GblItemsList, function (index, lcl_obj_Item) {
        if (lcl_obj_Item.ItemMasterBatch == null) {
            lcl_b_ItemFound = true;
            lcl_str_Msg += "MasterBatch Not Configured!!!";
        }
        if (lcl_obj_Item.InkList == null) {
            lcl_b_ItemFound = true;

        }
    });

}

function SaveMasterBatch() {
    var lcl_ui64_ItemCode = $("#ddlItem option:selected").val();
    var lcl_obj_MasterBatch = new Object();
    lcl_obj_MasterBatch.ItemCode = lcl_ui64_ItemCode;
    lcl_obj_MasterBatch.PantoneColorName = $.trim($('#tblMasterBatch').appendGrid('getCtrlValue', 'ddlMasterBatchColor', 0));
    lcl_obj_MasterBatch.PantoneColor = $.trim($('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMasterBatchColorPantone', 0));
    lcl_obj_MasterBatch.ColorHex = $.trim($('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMasterBatchColorHex', 0));
    lcl_obj_MasterBatch.Percentage = $.trim($('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMasterBatchColorPercentage', 0));
    
    var options = {};
    options.url = gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveMasterBatch";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_obj_ItemMasterBatch: " + JSON.stringify(lcl_obj_MasterBatch) + "}";
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        LoadItemListByBuyerAndCatagory();

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
    options.error = function (err) {ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}

function SaveInkList() {
    var lcl_ui64_ItemCode = $("#ddlItem option:selected").val();
    var lcl_i32_InkCount = $('#tblInk').appendGrid('getRowCount');
    //alert(lcl_i32_InkCount);
    var lcl_i32_NewItemInkIndex = 0;
    var lcl_objLst_Ink = new Array();
    for (var i = 0; i < lcl_i32_InkCount; i++) {
        var lcl_str_InkCode = $.trim(($('#tblInk').appendGrid('getCtrlValue', 'txtInkCode', i)));
        
        if (lcl_str_InkCode == '') {
            //New Item
            //alert(lcl_str_InkCode);
            lcl_objLst_Ink[lcl_i32_NewItemInkIndex] = new Object();
            lcl_objLst_Ink[lcl_i32_NewItemInkIndex].ItemCode = lcl_ui64_ItemCode;
            lcl_objLst_Ink[lcl_i32_NewItemInkIndex].PantoneColorName = $.trim(($('#tblInk').appendGrid('getCtrlValue', 'ddlInkColor', i)));
            lcl_objLst_Ink[lcl_i32_NewItemInkIndex].PantoneColor = $.trim(($('#tblInk').appendGrid('getCtrlValue', 'txtInkColorPantone', i)));
            lcl_objLst_Ink[lcl_i32_NewItemInkIndex].ColorHex = $.trim(($('#tblInk').appendGrid('getCtrlValue', 'txtInkColorHex', i)));
            lcl_i32_NewItemInkIndex++;
        }
    }
    //alert(lcl_objLst_Ink.length);
    if (lcl_objLst_Ink.length > 0) {
        var options = {};
        options.url = gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveInkList";
        options.dataType = "json";
        options.type = "POST";
        options.data = "{IP_objLst_ItemInk: " + JSON.stringify(lcl_objLst_Ink) + "}";
        options.contentType = "application/json; charset=utf-8";
        //options.processData = false;
        options.success = function (result) {
            var lcl_obj_WSResponse = result.d;
            LoadItemListByBuyerAndCatagory();

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
        options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
        $.ajax(options);
    }
}

function ShowMasterBatchAndInkList() {
    ShowMasterBatchByItem();
    ShowInkListByItem();
    ShowImageListByItem();
}

function ShowMasterBatchByItem() {
    //Displays MasterBatch From GBLItemList
    var lcl_ui64_ItemCode = $("#ddlItem option:selected").val();
    var lcl_i32_Count = $('#tblMasterBatch').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblMasterBatch').appendGrid('removeRow', 0);
    }
    if(typeof GblItemsList.ItemMasterBatch == null)
    {
        $('#tblMasterBatch').appendGrid('appendRow', 1);
        return;
    }
    var lcl_i32_Index = 0;
    $.each(GblItemsList, function (index, lcl_obj_Item) {
        if (lcl_obj_Item.ItemCode == lcl_ui64_ItemCode) {
            if (lcl_obj_Item.ItemMasterBatch != null) {
                $('#tblMasterBatch').appendGrid('appendRow', [
                    { txtMasterBatchCode: lcl_obj_Item.ItemMasterBatch.MasterBatchCode,
                        ddlMasterBatchColor: lcl_obj_Item.ItemMasterBatch.PantoneColorName,
                        txtMasterBatchColorPantone: lcl_obj_Item.ItemMasterBatch.PantoneColor,
                        txtMasterBatchColorHex: lcl_obj_Item.ItemMasterBatch.ColorHex,
                        txtMasterBatchColorPercentage: lcl_obj_Item.ItemMasterBatch.Percentage,
                        txtMasterBatchColorPreview: ''
                    }
                ]);
                var txtColorPreview = $('#tblMasterBatch').appendGrid('getCellCtrl', 'txtMasterBatchColorPreview', lcl_i32_Index);
                $(txtColorPreview).css('background-color', lcl_obj_Item.ItemMasterBatch.ColorHex);
                $(txtColorPreview).attr('readonly', 'readonly');
                lcl_i32_Index++;
            }
        }


    });
}

function ShowInkListByItem() {
    //Displays InkList From GBLItemList
    //Displays MasterBatch From GBLItemList
    var lcl_ui64_ItemCode = $("#ddlItem option:selected").val();
    var lcl_i32_Count = $('#tblInk').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        $('#tblInk').appendGrid('removeRow', 0);
    }
    //alert(GblItemsList.InkList.length);
    if(typeof GblItemsList.InkList == null)
    {
        $('#tblInk').appendGrid('appendRow', 1);
        return;
    }
    var lcl_i32_Index = 0;
    $.each(GblItemsList, function (index, lcl_obj_Item) {
        if (lcl_obj_Item.ItemCode == lcl_ui64_ItemCode) {
            if (lcl_obj_Item.InkList != null) {
                $.each(lcl_obj_Item.InkList, function (index1, lcl_obj_ItemInk) {
                    $('#tblInk').appendGrid('appendRow', [
                    { txtInkCode: lcl_obj_ItemInk.InkCode,
                        ddlInkColor: lcl_obj_ItemInk.PantoneColorName,
                        txtInkColorPantone: lcl_obj_ItemInk.PantoneColor,
                        txtInkColorHex: lcl_obj_ItemInk.ColorHex,
                        txtInkColorPreview: ''
                    }
                ]);
                var txtColorPreview = $('#tblInk').appendGrid('getCellCtrl', 'txtInkColorPreview', lcl_i32_Index);
                $(txtColorPreview).css('background-color', lcl_obj_ItemInk.ColorHex);
                lcl_i32_Index++;    
                });
            }
        }


    });
}

function ShowImageListByItem()
{
     //Displays InkList From GBLItemList
    //Displays MasterBatch From GBLItemList
    var lcl_ui64_ItemCode = $("#ddlItem option:selected").val();
    
    //alert(GblItemsList.InkList.length);
    if(typeof GblItemsList.ItemImageList == null)
    {
        return;
    }
    var lcl_i32_Index = 0;
    GblItemImageList = [];
    var lcl_str_ImageGalleryHTML = "";
    
    $.each(GblItemsList, function (index, lcl_obj_Item) {
        if (lcl_obj_Item.ItemCode == lcl_ui64_ItemCode) {
            if (lcl_obj_Item.ItemImageList != null) {
                //lcl_str_ImageGalleryHTML = "<ul id='pg'>";
                $.each(lcl_obj_Item.ItemImageList, function (index1, lcl_obj_ItemImage) {
                    GblItemImageList [index1] = "data:" + lcl_obj_ItemImage.ImageType + ";base64," + lcl_obj_ItemImage.ImageB64String;
                    //$("#img1").attr("src",GblItemImageList [index1]);
                    lcl_str_ImageGalleryHTML += "<li>";
                    lcl_str_ImageGalleryHTML += "<img src='" + GblItemImageList [index1] + "' alt='" + lcl_obj_ItemImage.Note + "'/>";
                    //lcl_str_ImageGalleryHTML += "<img src='" + GblItemImageList [index1] + "' alt='NO IMAGE'/>";
                    lcl_str_ImageGalleryHTML += "</li>";
                lcl_i32_Index++;    
                });
                //alert(lcl_str_ImageGalleryHTML);
                if(GBLItemSlider == null)
                {
                    $("#dvImageGallery ul").append(lcl_str_ImageGalleryHTML);
                    GBLItemSlider = $('.pgwSlider').pgwSlider();
                }
                else
                {
                    //GBLItemSlider.stopSlide();
                 //GBLItemSlider.destroy();
                 $("#dvImageGallery ul").append(lcl_str_ImageGalleryHTML);
                 GBLItemSlider = $('.pgwSlider').pgwSlider().reload();
                }
                 
            }

            
   


        }
        
    });
}

function ShowUploadImageDialog(evtObj, uniqueIndex, rowData) {
    //debugger;
    var lcl_str_ItemCode = $.trim(rowData.txtItemCode);
    if(lcl_str_ItemCode == '')
    {
        ShowErrorMessageBoard("Operational Error : Sample Image Cannot be Added As the Item is not yet saved!!!");
        return;
    }
    //alert(lcl_ui64_ItemCode);
    GblImageUploadDialog = $("#dlgImageUpload").dialog({
                                                    autoOpen: true,
                                                    height: 450,
                                                    width: 500,
                                                    show: {
                                                        effect: "slide",
                                                        duration: 500
                                                        },
                                                    hide: {
                                                        effect: "explode",
                                                        duration: 1000
                                                        },
                                                    modal: true
                                                });
    $("#txtImageUploadItemCode").val(lcl_str_ItemCode);
    $("#txtImageUploadItemName").val(rowData.txtItemName);
}

function UploadImage(evtObj, uniqueIndex, rowData)
{
   if(uniqueIndex != undefined)
   {
        alert(uniqueIndex);
   }
}

function LoadImage()
{
    //alert("Loading Image");
    var input, file, fr, img;

    if (typeof window.FileReader !== 'function') {
        //write("The file API isn't supported on this browser yet.");
        DisplayInformation("Please Update Your Internet Browser!!!");
        return;
    }

    input = document.getElementById('fileBrowser');
    if (!input) {
        DisplayInformation("Image Box Was Not Found!!!");
        return;
    }
    else if (!input.files) {
        //write("This browser doesn't seem to support the `files` property of file inputs.");
        DisplayInformation("Please Update Your Internet Browser!!!");
        return;
    }
    else if (!input.files[0]) {
        DisplayInformation("Please Select a File!!!");
        return;
    }
    else {
        file = input.files[0];
        //check file type
        var lcl_str_FileType = file.type.toString();
        if ((lcl_str_FileType != "image/png") && (lcl_str_FileType != "image/gif") && (lcl_str_FileType != "image/jpeg") && (lcl_str_FileType != "image/jpg") && (lcl_str_FileType != "image/jpeg")) {
            DisplayInformation("You can select image type 'jpg,gif,png' only!!!");
            return;
        }
        //check file size.should not exceed 300kb
        var lcl_i32_FileSize = file.size.toString();
        //alert(lcl_i32_FileSize);
        if (lcl_i32_FileSize / 1024 > 3000) {
            DisplayInformation("Employee Image Size Cannot Exceed 30 KB!!!");
            return;
        }

        $("#txtImageType").val(lcl_str_FileType);
        $("#txtImageSize").val(parseInt((lcl_i32_FileSize / 1024).toString()).toString() + " KB");
        $("#txtImageSize").data('img_size', lcl_i32_FileSize.toString()); //storing file size in bytes
        var fr = new FileReader();
        fr.onload = function (event) {
            document.getElementById("imgItemSample").setAttribute("src", event.target.result);
            //save the read image object in the fileBrowser Control.VERY IMPORTANT ISSUE
            $("#fileBrowser").data('smpl_img_added', true); //indicates if image has been added.
            var lcl_str_Image = event.target.result.toString();
            alert(lcl_str_Image);
            //alert(lcl_str_Image);
            var lcl_imageByte = lcl_str_Image.replace(/^data:image\/(png|jpg|gif|jpeg);base64,/, ''); //data:image/jpeg;base64,/
            $("#fileBrowser").data('smpl_img', lcl_imageByte);
        }
        fr.readAsDataURL(file);
        //input.src = fr.result;

    }
}

function DeleteImage() {
    document.getElementById("imgItemSample").setAttribute("src", "");
    $("#txtImageType").val('');
    $("#txtImageSize").val('');
    $("#txtImageSize").data('img_size', '0');
    document.getElementById('fileBrowser').value = '';
    $("#fileBrowser").data('smpl_img', '');
    $("#fileBrowser").data('smpl_img_added', false);
    //alert($("#fileBrowser").data('emp_img').toString());
}

function CloseImageUploadDialog()
{
    $(GblImageUploadDialog).dialog("close");
}

function SaveSampleImage()
{
    var lcl_b_SampleImageAdded = $("#fileBrowser").data('smpl_img_added');
    if(lcl_b_SampleImageAdded == false)
    {
        DisplayError("Operational Error : No Sample Image Uploaded Yet!!!Save Failed!!!");
        return;
    }
    var lcl_obj_ItemImage = new Object();
    lcl_obj_ItemImage.ItemCode = $("#txtImageUploadItemCode").val();
    lcl_obj_ItemImage.ImageType = $("#txtImageType").val();
    lcl_obj_ItemImage.ImageSize = $("#txtImageSize").data('img_size');
    lcl_obj_ItemImage.ImageB64String = $("#fileBrowser").data('smpl_img');
    lcl_obj_ItemImage.Note = $("#txtNote").val();
    lcl_obj_ItemImage.EntryEmployeeCode = $("#txtSignedInEmployeeCode").val();
    var options = {};
    options.url = gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveItemImage";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_obj_ItemImage: " + JSON.stringify(lcl_obj_ItemImage) + "}";
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        //LoadItemListByBuyerAndCatagory();

        if (lcl_obj_WSResponse.ResponseCode == -100) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //Refresh Controls
            DeleteImage();
            DisplaySuccess(lcl_obj_WSResponse.Message);
        }
    };
    options.error = function (err) {ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}


