$(document).ready(function () {

    $('#ddlPOCode').change(function () { LoadAlllist(); });
    });


function LoadAlllist() {

    var lcl_ui64_ddlPOCode = $('#ddlPOCode option:selected').val();


    $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/PurchaseOrder.asmx/Retrive",

                        data: "{IP_ui64_ddlPOCode:" + JSON.stringify(lcl_ui64_ddlPOCode) + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {
                                var lcl_obj_Quotation = WSReturn.Data;

                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {


                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000001') {
                                        var val = 'T-Shirt Bag';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000002') {
                                        var val = 'Block Bag';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000003') {
                                        var val = 'Knot Bag';
                                        lcl_obj_radion = val; ;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000004') {
                                        var val = 'Die-Cut Bag';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000005') {
                                        var val = 'Soft Loop Handle Bag';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000006') {
                                        var val = 'Garbage Bag on Roll';
                                        lcl_obj_radion = val;

                                    }


                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000007') {
                                        var val = 'Flat Bag on Roll';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000008') {
                                        var val = 'T-Shirt Bag on Roll';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000009') {
                                        var val = 'Heat Seal Patch Handle Bag / Patch Handle Diecut Bag';
                                        lcl_obj_radion = val

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000010') {
                                        var val = 'Star Seal Bag on Roll with Core';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000011') {
                                        var val = 'Star Seal Bag on Roll without Core';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000012') {
                                        var val = 'Handgloves';
                                        lcl_obj_radion = val;

                                    }

                                    if (lcl_obj_QuotationDetail.ItemCode == '1010000013') {
                                        var val = 'Ice Bag';
                                        lcl_obj_radion = val;

                                    }
                                    $('#tblProductDetails').appendGrid('appendRow', [
                     {
                         ProductRef: lcl_obj_QuotationDetail.ProductRef,
                         ItemCode: lcl_obj_QuotationDetail.ItemCode,
                         PODetailsCode: lcl_obj_QuotationDetail.PurchaseOrderDetailsCode,
                         CatagoryCode: lcl_obj_QuotationDetail.ItemCataGoryCode,
                         CatagoryName: val,
                         Desc: lcl_obj_QuotationDetail.ProductDesc,
                         Width: lcl_obj_QuotationDetail.Item.Width,
                         Length: lcl_obj_QuotationDetail.Item.Length,
                         Gusset: lcl_obj_QuotationDetail.Item.Gusset,
                         Density: lcl_obj_QuotationDetail.Item.Density,
                         Thickness: lcl_obj_QuotationDetail.Item.Thickness,
                         ppb: lcl_obj_QuotationDetail.Ppb,
                         bpc: lcl_obj_QuotationDetail.Bpc,
                         Wgt1tp: lcl_obj_QuotationDetail.Weight,
                         Quantity: lcl_obj_QuotationDetail.Quantity,
                         PcsPerCarton: lcl_obj_QuotationDetail.PcsPerCarton,
                         Carton: lcl_obj_QuotationDetail.Carton,
                         CBM: lcl_obj_QuotationDetail.Cbm,
                         KG: lcl_obj_QuotationDetail.QtyKg,
                         UnitPrice: lcl_obj_QuotationDetail.UnitPriceCifFos,
                         TotalPrice: lcl_obj_QuotationDetail.TotalAmountCifFos
                     },


        ]);
                                });
                            } else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
} 


$(function () {
    // Initialize appendGrid

                    
                    var table= $('#tblProductDetails').appendGrid({
                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
//  
                                 { name: 'ProductRef', display: 'Ref', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },                                 
                                 { name: 'ItemCode', display: 'Item Code',type: 'text', value: 0 },
                                 { name: 'PODetailsCode',display: 'Quo De', type: 'text', value: 0 },                                 
                                 { name: 'CatagoryCode',display: 'Catagory Code', type: 'text', value: 0 },
                                 { name: 'CatagoryName', display: 'Catagory Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Desc', display: 'Desc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Width', display: 'W', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Length', display: 'L', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Gusset', display: 'G', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Density', display: 'D', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Thickness', display: 'T', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'ppb', display: 'Ppb', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'bpc', display: 'Bpc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Wgt1tp', display: 'Wgt', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},                                 
                                 { name: 'Quantity', display: 'QP', type: 'text', ctrlCss: { width: '100%','text-align': 'left'} },
                                 { name: 'PcsPerCarton', display: 'PPC', type: 'text' , ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'Carton', display: 'TC', type: 'text', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'CBM', display: 'CBM', type: 'text' , ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'KG', display: 'KG', type: 'text', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'UnitPrice', display: 'Puc', type: 'text', ctrlCss: { width: '100%','text-align': 'left'} },
                                 { name: 'TotalPrice', display: 'Total', type: 'text', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });