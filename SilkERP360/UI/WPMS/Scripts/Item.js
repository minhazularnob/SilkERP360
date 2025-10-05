function Save() {

var lcl_ui64_BuyerIndex=$.trim($("#ddlBuyer option:Selected").index());
var lcl_ui64_CatagoryIndex=$.trim($("#ddlItemCategory option:Selected").index());
var lcl_b_AutoItemCode=false;



var lcl_i32_Count = $('#tblforItems').appendGrid('getRowCount');
if (lcl_ui64_BuyerIndex == 0|| lcl_ui64_CatagoryIndex==0) {
        DisplayError("Buyer or Catagory Must be Selected'!!!");
        return false;
    }

if(lcl_i32_Count==0)
{
    DisplayError("No Data found in the grid to save in the database'!!!");
    return false;
}

 var lcl_obj_Fixed = new Array();
 debugger;

 if ($('#AutoItemCode').is(':checked')) {
        lcl_b_AutoItemCode=true;
      
        }
else
        {
         lcl_b_AutoItemCode=false;

        }
        
         var i=0;          
        for (var j = 0; j < lcl_i32_Count; j++) 
        
        {
            var lcl_str_ItemCodeHdn = $('#tblforItems').appendGrid('getCtrlValue', 'txtItemCodeHdn', j);
            if($.trim(lcl_str_ItemCodeHdn) == '')
            {
                    lcl_obj_Fixed[i]= new Object();
                    lcl_obj_Fixed[i].BuyerCode            =   $("#ddlBuyer option:selected").val();  
                    lcl_obj_Fixed[i].ItemCatagoryCode     =   $("#ddlItemCategory option:selected").val();
                    lcl_obj_Fixed[i].IPEmployeeCode     =   $("#txtSignedInEmployeeCode").val();
                    lcl_obj_Fixed[i].ItemCode = 0;
                   
                   if(lcl_b_AutoItemCode == false)
                   {
                   lcl_obj_Fixed[i].ItemCode = $.trim($('#tblforItems').appendGrid('getCtrlValue', 'txtItemCode', j));
                   }
                    lcl_obj_Fixed[i].ItemName             =   $('#tblforItems').appendGrid('getCtrlValue', 'txtItemName', j);
                    lcl_obj_Fixed[i].Width                =   $('#tblforItems').appendGrid('getCtrlValue', 'txtWidth', j);
                    lcl_obj_Fixed[i].Gusset               =   $('#tblforItems').appendGrid('getCtrlValue', 'txtGusset', j);
                    lcl_obj_Fixed[i].Length               =   $('#tblforItems').appendGrid('getCtrlValue', 'txtLength', j);
                    lcl_obj_Fixed[i].Thickness            =   $('#tblforItems').appendGrid('getCtrlValue', 'txtThickness', j);
                    lcl_obj_Fixed[i].ProcessingCost       =   $('#tblforItems').appendGrid('getCtrlValue', 'txtProcessingCost', j);
                    lcl_obj_Fixed[i].PrintingCharge       =   $('#tblforItems').appendGrid('getCtrlValue', 'txtPrintingCharge', j);
                    lcl_obj_Fixed[i].Punchout             =   $('#tblforItems').appendGrid('getCtrlValue', 'txtPunchOut', j);
                    lcl_obj_Fixed[i].Density              =   $('#tblforItems').appendGrid('getCtrlValue', 'txtDensity', j);
                    lcl_obj_Fixed[i].ItemRefCode          =   $('#tblforItems').appendGrid('getCtrlValue', 'txtRefCode', j);
                    lcl_obj_Fixed[i].HD = $('#tblforItems').appendGrid('getCtrlValue', 'txtHD', j);
                    lcl_obj_Fixed[i].HDPE = $('#tblforItems').appendGrid('getCtrlValue', 'txtHDPE', j);
                    lcl_obj_Fixed[i].LLDPE = $('#tblforItems').appendGrid('getCtrlValue', 'txtLLDPE', j);
                    lcl_obj_Fixed[i].COCO = $('#tblforItems').appendGrid('getCtrlValue', 'txtCOCO', j);
                    lcl_obj_Fixed[i].LDPE = $('#tblforItems').appendGrid('getCtrlValue', 'txtLDPE', j);
                    lcl_obj_Fixed[i].Recycle = $('#tblforItems').appendGrid('getCtrlValue', 'txtRecycle', j);
                    lcl_obj_Fixed[i].Thinner = $('#tblforItems').appendGrid('getCtrlValue', 'txtThinner', j);
                    lcl_obj_Fixed[i].D2W = $('#tblforItems').appendGrid('getCtrlValue', 'txtD2W', j);
                    lcl_obj_Fixed[i].EPI = $('#tblforItems').appendGrid('getCtrlValue', 'txtEPI', j);
                    lcl_obj_Fixed[i].AntiSlip = $('#tblforItems').appendGrid('getCtrlValue', 'txtAntiSlip', j);

                    lcl_obj_Fixed[i].MbBergundy = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBBergundy', j);
                    lcl_obj_Fixed[i].MbBlack = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBBlack', j);
                    lcl_obj_Fixed[i].MbBlue = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBBlue', j);
                    lcl_obj_Fixed[i].MbGreen = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBGreen', j);
                    lcl_obj_Fixed[i].MbLemonGrass = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBLemonGrass', j);
                    lcl_obj_Fixed[i].MbLory = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBLory', j);
                    lcl_obj_Fixed[i].MbOrange = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBOrange', j);
                    lcl_obj_Fixed[i].MbPink = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBPink', j);
                    lcl_obj_Fixed[i].MbRed = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBRed', j);
                    lcl_obj_Fixed[i].MbWhite = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBWhite', j);
                    lcl_obj_Fixed[i].MbYellow = $('#tblMasterBatch').appendGrid('getCtrlValue', 'txtMBYellow', j);

                    lcl_obj_Fixed[i].InkBlue = $('#tblInk').appendGrid('getCtrlValue', 'txtInkBlue', j);
                    lcl_obj_Fixed[i].InkGermanium = $('#tblInk').appendGrid('getCtrlValue', 'txtInkGermanium', j);
                    lcl_obj_Fixed[i].InkGrassGreen = $('#tblInk').appendGrid('getCtrlValue', 'txtInkGrassGreen', j);
                    lcl_obj_Fixed[i].InkGreen = $('#tblInk').appendGrid('getCtrlValue', 'txtInkGreen', j);
                    lcl_obj_Fixed[i].InkLemonYellow = $('#tblInk').appendGrid('getCtrlValue', 'txtInkLemonYellow', j);
                    lcl_obj_Fixed[i].InkMidYellow = $('#tblInk').appendGrid('getCtrlValue', 'txtInkMidYellow', j);
                    lcl_obj_Fixed[i].InkOrange = $('#tblInk').appendGrid('getCtrlValue', 'txtInkMolibDataOrange', j);
                    lcl_obj_Fixed[i].InkPeacockBlue = $('#tblInk').appendGrid('getCtrlValue', 'txtInkPeacockBlue', j);
                    lcl_obj_Fixed[i].InkRed = $('#tblInk').appendGrid('getCtrlValue', 'txtInkAjinomotoRed', j);
                    lcl_obj_Fixed[i].InkReflexBlue = $('#tblInk').appendGrid('getCtrlValue', 'txtInkReflexBlue', j);
                    lcl_obj_Fixed[i].InkRoyalBlue = $('#tblInk').appendGrid('getCtrlValue', 'txtInkRoyalBlue', j);
                    lcl_obj_Fixed[i].InkSilver = $('#tblInk').appendGrid('getCtrlValue', 'txtInkSilver', j);
                    lcl_obj_Fixed[i].InkWhite = $('#tblInk').appendGrid('getCtrlValue', 'txtInkWhite', j);
                    i++;
            }
                    
        
    }
    if (confirm("Are you sure you want to submit this application?") == true) {
        $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Item.asmx/SaveList",

                        data: "{IP_objLst_Item:" + JSON.stringify(lcl_obj_Fixed) + ",IP_b_AutoItemCode:" + JSON.stringify(lcl_b_AutoItemCode) + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                ShowMessageBoard(WSReturn.Message.toString());
                                var lcl_ui64Lst_ItemCodes = WSReturn.Data;
                               LoadItems();
                                return true;
                            }
                            else {
                                ShowErrorMessageBoard(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);

                        }
                    });
    } return false;
            }

            $(function () {
                // Initialize appendGrid

                var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");


                

                

                



            });

    function MasterBatchAndInk() {
        $("#dvMasterBatch").hide('slow', function () {
            $("#dvInk").hide('slow', function () {
            });
        });
        $("#dvMasterBatch").show('slow', function () {
            $("#dvInk").show('slow', function () {
            });
        });
    }

    function LoadItems() {
      
       var lcl_ui64_BuyerCode = $.trim($("#ddlBuyer option:Selected").val());
       var lcl_ui64_CatagoryCode=$.trim($("#ddlItemCategory option:Selected").val());

       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Item.asmx/LoadItem",
                        data: "{IP_ui64_BuyerCode:" + JSON.stringify(lcl_ui64_BuyerCode) + ",IP_ui64_CatagoryCode:" + JSON.stringify(lcl_ui64_CatagoryCode) + "}",
                        dataType: "json",
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == -1) {
                                var lcl_i32_Count = $('#tblforItems').appendGrid('getRowCount');
                                for (var i = 0; i < lcl_i32_Count; i++) {
                                    $('#tblforItems').appendGrid('removeRow', 0);
                                }

                                lcl_i32_Count = $('#tblMasterBatch').appendGrid('getRowCount');
                                for (var i = 0; i < lcl_i32_Count; i++) {
                                    $('#tblMasterBatch').appendGrid('removeRow', 0);
                                }

                                lcl_i32_Count = $('#tblInk').appendGrid('getRowCount');
                                for (var i = 0; i < lcl_i32_Count; i++) {
                                    $('#tblInk').appendGrid('removeRow', 0);
                                }

                                ShowInfoMessageBoard("No Item Master found for the selected Company and Category!!!");
                                return;
                            }
                            if (WSReturn.ResponseCode == 0) {
                                var lcl_obj_Item = WSReturn.Data;

                                var lcl_i32_Count = $('#tblforItems').appendGrid('getRowCount');

                                for (var i = 0; i < lcl_i32_Count; i++) {
                                    $('#tblforItems').appendGrid('removeRow', 0);
                                }
                                var lcl_objArr_ItemsDataToLoad = new Array();
                                var lcl_objArr_MasterBatchDataToLoad = new Array();
                                var lcl_objArr_InkDataToLoad = new Array();
                                $.each(lcl_obj_Item, function (index, lcl_obj_ItemDetail) {

                                    lcl_objArr_ItemsDataToLoad[index] = new Object();
                                    lcl_objArr_ItemsDataToLoad[index].txtItemCodeHdn = lcl_obj_ItemDetail.ItemCode;
                                    lcl_objArr_ItemsDataToLoad[index].txtItemCode = lcl_obj_ItemDetail.ItemCode;
                                    lcl_objArr_ItemsDataToLoad[index].txtItemName = lcl_obj_ItemDetail.ItemName;
                                    lcl_objArr_ItemsDataToLoad[index].txtRefCode = lcl_obj_ItemDetail.ItemRefCode;
                                    lcl_objArr_ItemsDataToLoad[index].txtWidth = lcl_obj_ItemDetail.Width;
                                    lcl_objArr_ItemsDataToLoad[index].txtGusset = lcl_obj_ItemDetail.Gusset;
                                    lcl_objArr_ItemsDataToLoad[index].txtLength = lcl_obj_ItemDetail.Length;
                                    lcl_objArr_ItemsDataToLoad[index].txtDensity = lcl_obj_ItemDetail.Density;
                                    lcl_objArr_ItemsDataToLoad[index].txtThickness = lcl_obj_ItemDetail.Thickness;
                                    lcl_objArr_ItemsDataToLoad[index].txtPunchOut = lcl_obj_ItemDetail.Punchout;
                                    lcl_objArr_ItemsDataToLoad[index].txtProcessingCost = lcl_obj_ItemDetail.ProcessingCost;
                                    lcl_objArr_ItemsDataToLoad[index].txtPrintingCharge = lcl_obj_ItemDetail.PrintingCharge;
                                    lcl_objArr_ItemsDataToLoad[index].txtHD = lcl_obj_ItemDetail.HD;
                                    lcl_objArr_ItemsDataToLoad[index].txtHDPE = lcl_obj_ItemDetail.HDPE;
                                    lcl_objArr_ItemsDataToLoad[index].txtLLDPE = lcl_obj_ItemDetail.LLDPE;
                                    lcl_objArr_ItemsDataToLoad[index].txtCOCO = lcl_obj_ItemDetail.COCO;
                                    lcl_objArr_ItemsDataToLoad[index].txtLDPE = lcl_obj_ItemDetail.LDPE;
                                    lcl_objArr_ItemsDataToLoad[index].txtRecycle = lcl_obj_ItemDetail.Recycle;
                                    lcl_objArr_ItemsDataToLoad[index].txtThinner = lcl_obj_ItemDetail.Thinner;
                                    lcl_objArr_ItemsDataToLoad[index].txtD2W = lcl_obj_ItemDetail.D2W;
                                    lcl_objArr_ItemsDataToLoad[index].txtEPI = lcl_obj_ItemDetail.EPI;
                                    lcl_objArr_ItemsDataToLoad[index].txtAntiSlip = lcl_obj_ItemDetail.AntiSlip;

                                    lcl_objArr_MasterBatchDataToLoad[index] = new Object();
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBWhite = lcl_obj_ItemDetail.MbWhite;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBBlue = lcl_obj_ItemDetail.MbBlue;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBGreen = lcl_obj_ItemDetail.MbGreen;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBRed = lcl_obj_ItemDetail.MbRed;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBYellow = lcl_obj_ItemDetail.MbYellow;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBLory = lcl_obj_ItemDetail.MbLory;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBBergundy = lcl_obj_ItemDetail.MbBergundy;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBPink = lcl_obj_ItemDetail.MbPink;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBLemonGrass = lcl_obj_ItemDetail.MbLemonGrass;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBBlack = lcl_obj_ItemDetail.MbBlack;
                                    lcl_objArr_MasterBatchDataToLoad[index].txtMBOrange = lcl_obj_ItemDetail.MbOrange;

                                    lcl_objArr_InkDataToLoad[index] = new Object();
                                    lcl_objArr_InkDataToLoad[index].txtInkGermanium = lcl_obj_ItemDetail.InkGermanium;
                                    lcl_objArr_InkDataToLoad[index].txtInkLemonYellow = lcl_obj_ItemDetail.InkLemonYellow;
                                    lcl_objArr_InkDataToLoad[index].txtInkMidYellow = lcl_obj_ItemDetail.InkMidYellow;
                                    lcl_objArr_InkDataToLoad[index].txtInkRoyalBlue = lcl_obj_ItemDetail.InkRoyalBlue;
                                    lcl_objArr_InkDataToLoad[index].txtInkBlue = lcl_obj_ItemDetail.InkBlue;
                                    lcl_objArr_InkDataToLoad[index].txtInkMolibDataOrange = lcl_obj_ItemDetail.InkOrange;
                                    lcl_objArr_InkDataToLoad[index].txtInkGreen = lcl_obj_ItemDetail.InkGreen;
                                    lcl_objArr_InkDataToLoad[index].txtInkGrassGreen = lcl_obj_ItemDetail.InkGrassGreen;
                                    lcl_objArr_InkDataToLoad[index].txtInkPeacockBlue = lcl_obj_ItemDetail.InkPeacockBlue;
                                    lcl_objArr_InkDataToLoad[index].txtInkAjinomotoRed = lcl_obj_ItemDetail.InkRed;
                                    lcl_objArr_InkDataToLoad[index].txtInkReflexBlue = lcl_obj_ItemDetail.InkReflexBlue;
                                    lcl_objArr_InkDataToLoad[index].txtInkWhite = lcl_obj_ItemDetail.InkWhite;
                                    lcl_objArr_InkDataToLoad[index].txtInkSilver = lcl_obj_ItemDetail.InkSilver;


                                });
                                $('#tblforItems').appendGrid('load', lcl_objArr_ItemsDataToLoad);
                                $('#tblInk').appendGrid('load', lcl_objArr_InkDataToLoad);
                                $('#tblMasterBatch').appendGrid('load', lcl_objArr_MasterBatchDataToLoad);

                                ShowMessageBoard("Item Master Retrieved and Displayed on grid!!!");
                            }

                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
        }
