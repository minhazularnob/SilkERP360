$(document).ready(function () {

    $('#ddlCatagory').change(function () { LoadItemName(); });
    $('#ddlItemSpec').change(function () { LoadItemsSpecDetails(); });
    $('#ddlQuotation').change(function () { LoadAlllist(); });
    
    
    
    $('#Quotation').hide();
    

$('#leftrow').hide();
    $('#checkMasterbatch').hide();
        $('#chkInkOpen').hide();

        
$('#chkQuotation').click(function() {
    if($(this).is(':checked')){
    $('#Quotation').show(500);

    }

    else
    {
    $('#Quotation').hide(500);
 
    }
    });

$('#Digit2').click(function() {
    if($(this).is(':checked')){
     var num = parseFloat($("#txtNetWeight").val());
    var new_num = $("#txtNetWeight").val(num.toFixed(2));              
             }

             else
             {
             var lcl_str_Width = $.trim($("#txtWidth").val());
                 var lcl_str_Length = $.trim($("#txtLength").val());
                 var lcl_str_Gusset = $.trim($("#txtGusset").val());
                 var lcl_str_Density = $.trim($("#txtDensity").val());
                 var lcl_str_Thickness = $.trim($("#txtThickness").val());
                 var lcl_str_CutOut = $.trim($("#Cutout").val());
                      var lcl_flt_Width = parseFloat(lcl_str_Width);
                      var lcl_flt_Length = parseFloat(lcl_str_Length);
                      var lcl_flt_Gusset = parseFloat(lcl_str_Gusset);
                      var lcl_flt_Density = parseFloat(lcl_str_Density);
                      var lcl_flt_Thickness = parseFloat(lcl_str_Thickness);
                      var lcl_flt_CutOut = parseFloat(lcl_str_CutOut);
                      if (lcl_flt_CutOut == '13') {
                      var lcl_flt_13 = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000 * (lcl_flt_CutOut / 100));
                      var lcl_flt_T = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);

    var lcl_flt_NetWeight = lcl_flt_T - lcl_flt_13;
    $("#txtNetWeight").val(lcl_flt_NetWeight.toFixed(4));
    }

else {
        var lcl_flt_NetWeight = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);
    }
    
    $("#txtNetWeight").val(lcl_flt_NetWeight.toFixed(4));
             
             }
          
});

$('#HD').click(function() {
    if($(this).is(':checked')){
              $('#txtDensity').val('0.0952');
              }
              else
              {
               $('#txtDensity').val('0');
              }
});



$('#LD').click(function() {
    if($(this).is(':checked')){
              $('#txtDensity').val('0.091');
              }
              else
              {
               $('#txtDensity').val('0');
              }
});



    $('#NewProductName').hide();
    $('#NewProduct').click(function() {
    if($(this).is(':checked')){
              $('#NewProductName').show();
              $('#ProductName').hide();
              }
              else{
              $('#NewProductName').hide();
              $('#ProductName').show();
              }
    
});

    $("#txtWidth").click(function() {
                $(this).focus();
                $(this).select();
            });

  $("#txtLength").click(function() {
                $(this).focus();
                $(this).select();
            });



              $("#txtGusset").click(function() {
                $(this).focus();
                $(this).select();
            });


            $("#txtNetWeight").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#txtDensity").click(function() {
                $(this).focus();
                $(this).select();
            });

              $("#txtThickness").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#Cutout").click(function() {
                $(this).focus();
                $(this).select();
            });

              $("#Processingcost").click(function() {
                $(this).focus();
                $(this).select();
            });



              $("#printingCharge").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#Freightcost").click(function() {
                $(this).focus();
                $(this).select();
            });


            $("#Cylinder").click(function() {
                $(this).focus();
                $(this).select();
            });


            $("#Height").click(function() {
                $(this).focus();
                $(this).select();
            });
            
            $("#Width").click(function() {
                $(this).focus();
                $(this).select();
            });
               


                $("#Length").click(function() {
                $(this).focus();
                $(this).select();
            });


                     
           $("#txtQuantity").click(function() {
                $(this).focus();
                $(this).select();
            });


            $("#totalpcspercarton").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
             $("#totalpcspercarton1").click(function() {
                $(this).focus();
                $(this).select();
            });

            $("#txtbpc").click(function() {
                $(this).focus();
                $(this).select();
            }); 


             $("#txtppb").click(function() {
                $(this).focus();
                $(this).select();
            }); 


             $("#txtOuterBag").click(function() {
                $(this).focus();
                $(this).select();
            }); 

           

    $('#HDPE').click(function() {
    $('#txtHDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});


    $('#LDPE').click(function() {
    $('#TextBox4').attr('disabled', !this.checked);
    $('#TextBox5').attr('disabled', !this.checked);
    $('#TextBox6').attr('disabled', !this.checked);
    
});


   $('#LLDPE').click(function() {
    $('#txtLLDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});


   $('#PunchOut').click(function() {
    $('#txtPunchOut_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});


   $('#MasterBase').click(function() {

    if($(this).is(':checked')){
      $('#checkMasterbatch').show(500);
     
             }

             else{
              $('#checkMasterbatch').hide();
      
             } 
});

   $('#D2W').click(function() {
    $('#txtD2W_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_Price').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_StandardPrice').attr('disabled', !this.checked);
   
});

    $('#EPI').click(function() {
    $('#txtEPI_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Price').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});

  $('#Thinner').click(function() {
    $('#TextBox1').attr('disabled', !this.checked);
    $('#TextBox2').attr('disabled', !this.checked);
    $('#TextBox3').attr('disabled', !this.checked);
    
});


$('#chkInk').click(function() {


if($(this).is(':checked')){
      $('#chkInkOpen').show(500);
   
             }

             else{
              $('#chkInkOpen').hide();
            
             }
});

$('#COCO').click(function() {
    $('#txt_coco').attr('disabled', !this.checked);
    $('#txt_coco1').attr('disabled', !this.checked);
    $('#txt_coco2').attr('disabled', !this.checked);
    
});

$('#chkwhite').click(function() {
    $('#txtMWIn').attr('disabled', !this.checked);
    $('#txtMWOu').attr('disabled', !this.checked);
    $('#txtMWPr').attr('disabled', !this.checked);
    
});

$('#chkblue').click(function() {
    $('#txtBlueIn').attr('disabled', !this.checked);
    $('#txtBlueOu').attr('disabled', !this.checked);
    $('#txtBluePr').attr('disabled', !this.checked);
    
});


$('#chkgreen').click(function() {
    $('#txtGreenin').attr('disabled', !this.checked);
    $('#txtGreenou').attr('disabled', !this.checked);
    $('#txtGreenPr').attr('disabled', !this.checked);
    
});


$('#chkRed').click(function() {
    $('#txtRedin').attr('disabled', !this.checked);
    $('#txtRedou').attr('disabled', !this.checked);
    $('#txtRedPr').attr('disabled', !this.checked);
    
});


$('#chkYellow').click(function() {
    $('#txtyellowin').attr('disabled', !this.checked);
    $('#txtyellowou').attr('disabled', !this.checked);
    $('#txtyellowPr').attr('disabled', !this.checked);
    
});


$('#chkLory').click(function() {
    $('#txtLoryin').attr('disabled', !this.checked);
    $('#txtLoryou').attr('disabled', !this.checked);
    $('#txtLoryPr').attr('disabled', !this.checked);
    });

$('#chkBeige').click(function() {
    $('#txtBeigein').attr('disabled', !this.checked);
    $('#txtBeigeou').attr('disabled', !this.checked);
    $('#txtBeigePr').attr('disabled', !this.checked);
    });



$('#chkPink').click(function() {
    $('#txtPinkin').attr('disabled', !this.checked);
    $('#txtPinkou').attr('disabled', !this.checked);
    $('#txtPinkPr').attr('disabled', !this.checked);
    });


$('#chkBgendy').click(function() {
    $('#txtbgendyin').attr('disabled', !this.checked);
    $('#txtbgendyou').attr('disabled', !this.checked);
    $('#txtbgendyPr').attr('disabled', !this.checked);
    });


$('#chkBlack').click(function() {
    $('#Blackin').attr('disabled', !this.checked);
    $('#Blackou').attr('disabled', !this.checked);
    $('#BlackPr').attr('disabled', !this.checked);    
});


$('#chkOrange').click(function() {
    $('#txtOrangein').attr('disabled', !this.checked);
    $('#txtOrangeou').attr('disabled', !this.checked);
    $('#txtOrangePr').attr('disabled', !this.checked);
       
});


$('#chkLgrass').click(function() {
    $('#txtLgrassin').attr('disabled', !this.checked);
    $('#txtLgrassou').attr('disabled', !this.checked);
    $('#txtLgrassPr').attr('disabled', !this.checked);
       
});

//Ink Color

$('#chkgeranium').click(function() {
    $('#txtgeraniumin').attr('disabled', !this.checked);
    $('#txtgeraniumou').attr('disabled', !this.checked);
    $('#txtgeraniumPr').attr('disabled', !this.checked);
       
});


$('#chkinkyellow').click(function() {
    $('#txtlyellowin').attr('disabled', !this.checked);
    $('#txtlyellowou').attr('disabled', !this.checked);
    $('#txtlyellowPr').attr('disabled', !this.checked);       
});


$('#chkInkmYellow').click(function() {
    $('#txtmyellowin').attr('disabled', !this.checked);
    $('#txtmyellowou').attr('disabled', !this.checked);
    $('#txtmyellowPr').attr('disabled', !this.checked);
       
});


$('#chkinkrblue').click(function() {
    $('#txtRBluein').attr('disabled', !this.checked);
    $('#txtRBlueou').attr('disabled', !this.checked);
    $('#txtRBluePr').attr('disabled', !this.checked);
       
});

$('#chkInkblue').click(function() {
    $('#txtInkBluein').attr('disabled', !this.checked);
    $('#txtInkBlueou').attr('disabled', !this.checked);
    $('#txtInkBluePr').attr('disabled', !this.checked);
       
});


$('#chkinkmdorange').click(function() {
    $('#txtmdorangein').attr('disabled', !this.checked);
    $('#txtmdorangeou').attr('disabled', !this.checked);
    $('#txtmdorangePr').attr('disabled', !this.checked);
       
});


$('#chkinkgreen').click(function() {
    $('#txtInkgreenin').attr('disabled', !this.checked);
    $('#txtInkgreenou').attr('disabled', !this.checked);
    $('#txtInkgreenPr').attr('disabled', !this.checked);
       
});

$('#chkInkgrassgreen').click(function() {
    $('#txtInkggreenin').attr('disabled', !this.checked);
    $('#txtInkggreenou').attr('disabled', !this.checked);
    $('#txtInkggreenPr').attr('disabled', !this.checked);
       
});


$('#chkInkPBlue').click(function() {
    $('#txtInkpbluein').attr('disabled', !this.checked);
    $('#txtInkpblueou').attr('disabled', !this.checked);
    $('#txtInkpbluePr').attr('disabled', !this.checked);
       
});


$('#chkInkBlack').click(function() {
    $('#txtInkBlackin').attr('disabled', !this.checked);
    $('#txtInkBlackou').attr('disabled', !this.checked);
    $('#txtInkBlackPr').attr('disabled', !this.checked);
       
});


$('#chkInkAMRed').click(function() {
    $('#txtAMRedin').attr('disabled', !this.checked);
    $('#txtAMRedou').attr('disabled', !this.checked);
    $('#txtAMRedPr').attr('disabled', !this.checked);
       
});


$('#chkInkrfbluec').click(function() {
    $('#txtRFBluein').attr('disabled', !this.checked);
    $('#txtRFBlueou').attr('disabled', !this.checked);
    $('#txtRFBluePr').attr('disabled', !this.checked);
       
});


$('#chkInkWhite').click(function() {
    $('#txtInkWhitein').attr('disabled', !this.checked);
    $('#txtInkWhiteou').attr('disabled', !this.checked);
    $('#txtInkWhitePr').attr('disabled', !this.checked);
       
});


$('#chkInkSilver').click(function() {
    $('#txtInkSilverin').attr('disabled', !this.checked);
    $('#txtInkSilverou').attr('disabled', !this.checked);
    $('#txtInkSilverPr').attr('disabled', !this.checked);
       
});

$('#chkEntiSlip').click(function() {
    $('#EntiSlipin').attr('disabled', !this.checked);
    $('#EntiSlipout').attr('disabled', !this.checked);
    $('#EntiSlippr').attr('disabled', !this.checked);
       
});
        $('#ddlQuotationCode').change(function () { LoadAlllist(); });
//       $('#ddlProductSelect').change(function () { LoadAlllistProduct(); });
        $('#ddlQuotationCode').change(function () { LoadQuotationInfoQuotatioCode(); });
        $('#ddlProductSelect').change(function () { LoadProductInformation(); });        
       $('#ddlCustomerName').change(function () { LoadCustomerInfoCreateQuotatio(); });

        $('#radLstProductCatalog_NPQ').change(function () { buyerProductSelect(); });
        $('#ddlProductSelect0').change(function () { LoadAllProductInformation(); });
        $('#ddlSizeSpecification').change(function () {  LoadSizeSpec(); });
        $('#ddlItem').change(function () {  LoadItemSize(); });
        $('#ddlCustomerName1').change(function () {  LoadCustomerInfoPO(); });

$( "#Month" ).datepicker({
        inline: true,
        showOtherMonths: true,
       dateFormat: 'dd-MM-yy',
    });

    $("#Month").datepicker("setDate", new Date());

    $( "#OrderDate" ).datepicker({
        inline: true,
        showOtherMonths: true,
        dateFormat: 'yy-mm-dd',
        dayNamesMin: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],  
    });

    $("#LcValidity").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0 });
    $("#ShowResultMonth").datepicker({ dateFormat: 'dd-MM-yy'});
    $("#txtTodayDate").datepicker({ dateFormat: 'dd-MM-yy'});
    $("#txtTodayDate").datepicker("setDate", new Date());


});

function CalculateNetWeight() {

                 var lcl_str_Width = $.trim($("#txtWidth").val());
                 var lcl_str_Length = $.trim($("#txtLength").val());
                 var lcl_str_Gusset = $.trim($("#txtGusset").val());
                 var lcl_str_Density = $.trim($("#txtDensity").val());
                 var lcl_str_Thickness = $.trim($("#txtThickness").val());
                 var lcl_str_CutOut = $.trim($("#Cutout").val());

    if (lcl_str_Width == '') {
        DisplayError("Please Fill Up The Field 'Width'!!!");
        return;
    }

    if (lcl_str_Length == '') {
        DisplayError("Please Fill Up The Field 'Length'!!!");
        return;
    }

    if (lcl_str_Gusset == '') {
        DisplayError("Please Fill Up The Field 'Gusset'!!!");
        return;
    }

    if (lcl_str_Density == '') {
        DisplayError("Please Fill Up The Field 'Density'!!!");
        return;
    }

    if (lcl_str_Thickness == '') {
        DisplayError("Please Fill Up The Field 'Thickness'!!!");
        return;
    }
                      var lcl_flt_Width = parseFloat(lcl_str_Width);
                      var lcl_flt_Length = parseFloat(lcl_str_Length);
                      var lcl_flt_Gusset = parseFloat(lcl_str_Gusset);
                      var lcl_flt_Density = parseFloat(lcl_str_Density);
                      var lcl_flt_Thickness = parseFloat(lcl_str_Thickness);
                      var lcl_flt_CutOut = parseFloat(lcl_str_CutOut);
                      if (lcl_flt_CutOut == '13') {
                      var lcl_flt_13 = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000 * (lcl_flt_CutOut / 100));
                      var lcl_flt_T = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);

    var lcl_flt_NetWeight = lcl_flt_T - lcl_flt_13;
    $("#txtNetWeight").val(lcl_flt_NetWeight.toFixed(4));
    }

else {
        var lcl_flt_NetWeight = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);
    }
    
    $("#txtNetWeight").val(lcl_flt_NetWeight.toFixed(4));
    
}



function CalculateTotalPrice() {

                         var lcl_str_txtRawMaterialPrice = $.trim($('#txtRawMaterialPrice').val());
                         var lcl_str_txtQuantity = $.trim($("#txtQuantity").val());
                         var lcl_str_Processingcost = $.trim($("#Processingcost").val());
                         var lcl_str_printingCharge = $.trim($("#printingCharge").val());
                         var lcl_str_Freightcost = $.trim($("#Freightcost").val());
                         var lcl_str_insurance = $.trim($("#insurance").val());
                         var lcl_str_weight = $.trim($("#txtNetWeight").val());
                         var lcl_str_Kgs = $.trim($("#Kgs").val());
                         var lcl_str_Cylinder = $.trim($("#Cylinder").val());
                         var lcl_str_Height = $.trim($("#Height").val());
                         var lcl_str_Length =$.trim($("#Length").val());
                         var lcl_str_Width = $.trim($("#Width").val());
                         var lcl_flt_Height=parseFloat(lcl_str_Height);
                         var lcl_flt_Length = parseFloat(lcl_str_Length);
                         var lcl_flt_Width = parseFloat(lcl_str_Width);
                   
    if (lcl_str_weight == '') {
        DisplayError("Please Calculate the 'Weight'!!!");
        return;
    }
       if (lcl_str_txtQuantity == '') {
        DisplayError("Please Fill Up The Field 'Quantity'!!!");
        return;
    }
    if (lcl_str_Processingcost == '') {
        DisplayError("Please Fill Up The Field 'Processing Cost'!!!");
        return;
    }

    if (lcl_str_printingCharge == '') {
        DisplayError("Please Fill Up The Field 'Printing Charge'!!!");
        return;
    }
    if (lcl_str_Freightcost == '') {
        DisplayError("Please Fill Up The Field 'Frieght Cost'!!!");
        return;
    }

    var lcl_str_Quantityforcarton  = $.trim($("#txtQuantity").val());
    var lcl_flt_Quantityforcarton=parseFloat(lcl_str_Quantityforcarton);
    var lcl_str_totalpcspercarton  = $.trim($("#totalpcspercarton").val());
    var lcl_flt_totalpcspercarton=parseFloat(lcl_str_totalpcspercarton);
    var lcl_flt_Cylinder=parseFloat(lcl_str_Cylinder);

                             //Carton Calculation
                             if (lcl_str_totalpcspercarton=='0')
                             {
                             $("#Carton").val('0');
                             $("#CBM").val('0');
                             }
                             else
                             {
                             var lcl_str_Carton =  lcl_flt_Quantityforcarton/lcl_flt_totalpcspercarton;
                             $("#Carton").val(lcl_str_Carton);
                             var lcl_flt_Cartoon=parseFloat(lcl_str_Carton);
                             var lcl_str_CBM= (lcl_flt_Height*lcl_flt_Length*lcl_flt_Width/1000000)*lcl_flt_Cartoon;
                             $("#CBM").val(lcl_str_CBM);
                             }
                             var lcl_strsplit_txtRawMaterialPrice = lcl_str_txtRawMaterialPrice.replace("$", '');
                             var lcl_strrpc_txtRawMaterialPrice = lcl_strsplit_txtRawMaterialPrice.replace(/,/g, '');
                             var lcl_flt_txtRawMaterialPrice = parseFloat(lcl_strrpc_txtRawMaterialPrice);
                            // var lcl_flt_Price = parseFloat(lcl_str_Price);
                             var lcl_flt_weight = parseFloat(lcl_str_weight);   
                             var lcl_flt_txtQuantity = parseFloat(lcl_str_txtQuantity);    
                             var lcl_flt_Processingcost = parseFloat(lcl_str_Processingcost);
                             var lcl_flt_printingCharge = parseFloat(lcl_str_printingCharge);
                             var lcl_flt_Freightcost = parseFloat(lcl_str_Freightcost); 
                             var lcl_flt_insurance = parseFloat(lcl_str_insurance);
                             $("#txtRawMaterialPrice").val(lcl_flt_txtRawMaterialPrice.toFixed(4));
                              $("#Processingcost").val(lcl_flt_Processingcost);
                             $("#Processingcost").val(lcl_flt_Processingcost.toFixed(4));
                           //  $("#Processingcost").formatCurrency();
                             
                             $("#Freightcost").val(lcl_flt_Freightcost.toFixed(4));
                             //$("#Freightcost").formatCurrency();
                             $("#printingCharge").val(lcl_flt_printingCharge.toFixed(4));
                             //$("#printingCharge").formatCurrency();
                             $("#txtNetWeight").val(lcl_flt_weight.toFixed(4));
                             $("#Kgs").val(lcl_flt_insurance.toFixed(4));
                             var lcl_flt_Fob =  lcl_flt_weight*((lcl_flt_txtRawMaterialPrice + lcl_flt_Processingcost + lcl_flt_printingCharge + lcl_flt_Freightcost)/1000);
                             
                             $("#txt_FobPrice").val(lcl_flt_Fob.toFixed(2));
                             lcl_str_Kgs = (lcl_flt_weight * lcl_flt_txtQuantity) / 1000;
                             $("#Kgs").val(lcl_str_Kgs);
                             $("#Kgs").val(lcl_str_Kgs.toFixed(4));
                             var lcl_str_fo = $("#txt_FobPrice").val();
                             var lcl_flt_fo = parseFloat(lcl_str_fo);
                             lcl_flt_fo.toFixed(2);
                            if (lcl_flt_Cylinder=='0')
                            {
                            var lcl_flt_TotalPrice = (lcl_flt_txtQuantity*lcl_flt_fo)/1000;
                            $("#txt_totalPrice").val(lcl_flt_TotalPrice);
                             //$("#txt_totalPrice").formatCurrency();
                            }
                            else
                            {
                             var lcl_flt_TotalPrice = (lcl_flt_txtQuantity*lcl_flt_fo)/1000;
                             var lcl_flt_withCylinder= lcl_flt_TotalPrice+lcl_flt_Cylinder;
                            $("#txt_totalPrice").val(lcl_flt_withCylinder);
                            // $("#txt_totalPrice").formatCurrency();
                            }

                            if (lcl_flt_Freightcost=='0')
                             {
                             $("#insurance").val('0.00');
                             }

                             else
                             {
                             var lcl_flt_insurance = (lcl_flt_Fob * 0.59);


                             $("#insurance").val(lcl_flt_insurance);
                             $("#insurance").val(lcl_flt_insurance.toFixed(2));
                             
                             //$("#insurance").formatCurrency();
                             }
                             
                             $("#txt_FobPrice").val(lcl_flt_Fob.toFixed(2));
                             //$("#txt_FobPrice").formatCurrency();
                             //$("#txtRawMaterialPrice").formatCurrency();
                             
                           
}



function resetFixed() {

                   document.getElementById("ddlCustomerName0 option:selected").value                       = '0';
                   document.getElementById("ddlProductName1 option:selected").value                      = '0';
                   document.getElementById("txtWidthSpec").value                       = '0';
                   document.getElementById("txtGussetyspec").value                      = '0';
                   document.getElementById("txtLengthSpec").value                    = '0';
                   document.getElementById("txtDensitySpec").value                          = '0';
                   document.getElementById("txtThicknessSpec").value                    = '0';
                   document.getElementById("txtPunchOutSpec").value             = '0';
                   document.getElementById("txtfixedProcessingCost").value                  = '0';
                   document.getElementById("txtfixedPrintingCharge").value                  = '0';
                   document.getElementById("SpecificationName").value                     = '';
                   
}

function Allclear() {

                   document.getElementById("txt_ProductRef").value                  = '';
                   document.getElementById("txt_ProductDec").value                  = '';
                   document.getElementById("txtQuantity").value                     = "";
                   document.getElementById("txtWidth").value                        = "0";
                   document.getElementById("txtLength").value                       = '0';
                   document.getElementById("txtGusset").value                       = '0';
                   document.getElementById("txtDensity").value                      = '0';
                   document.getElementById("txtThickness").value                    = '0';
                   document.getElementById("Cutout").value                          = '0';
                   document.getElementById("txtNetWeight").value                    = '0';
                   document.getElementById("txtRawMaterialPrice").value             = '$0';
                   document.getElementById("Processingcost").value                  = '0';
                   document.getElementById("printingCharge").value                  = '0';
                   document.getElementById("Freightcost").value                     = '0';
                   document.getElementById("insurance").value                       = '0';
                   document.getElementById("txt_FobPrice").value                    = '0';
                   document.getElementById("txt_totalPrice").value                  = '0';
                   document.getElementById("Carton").value                          = '';
                   document.getElementById("Kgs").value                             = '0';                  
                   document.getElementById("txtHDPE_NPQ_Percentage").value          = '';
                   document.getElementById("txtLLDPE_NPQ_Percentage").value         = '';
                   document.getElementById("txtPunchOut_NPQ_Percentage").value      = '';                                 
                   document.getElementById("txtMWIn").value               = '';
                   document.getElementById("txtMWOu").value              = '';
                   document.getElementById("txtBlueIn").value           = '';                 
                   document.getElementById("txtBlueOu").value           = '';
                   document.getElementById("txtGreenin").value           = '';
                   document.getElementById("txtGreenou").value                = '';
                   document.getElementById("txtRedin").value                = '';
                   document.getElementById("txtRedou").value         = '';
                   document.getElementById("txtyellowin").value    = '';
                   document.getElementById("txtyellowou").value           = '';
                   document.getElementById("txtLoryin").value           = '';
                   document.getElementById("txtLoryou").value                = '';
                   document.getElementById("txtBeigein").value                = '';
                   document.getElementById("txtBeigeou").value               = '';
                   document.getElementById("txtPinkin").value              = '';
                   document.getElementById("txtPinkou").value           = '';
                   document.getElementById("txtbgendyin").value    = '';
                   document.getElementById("txtbgendyou").value           = '';
           
                   document.getElementById("Blackin").value                = '';
                   document.getElementById("Blackou").value               = '';
                   document.getElementById("txtOrangein").value              = '';
                   document.getElementById("txtOrangeou").value           = '';                 
                   document.getElementById("txtD2W_NPQ_Percentage").value           = '';
                   document.getElementById("txtEPI_NPQ_Percentage").value           = '';
                   document.getElementById("txtD2W_NPQ_Price").value                = '';
                   document.getElementById("txtEPI_NPQ_Price").value                = '';
                   document.getElementById("TextBox4").value         = '';
                   document.getElementById("TextBox5").value    = '';
                   document.getElementById("txt_coco").value           = '';
                   document.getElementById("txt_coco1").value           = '';
                   document.getElementById("txtPunchOut_NPQ_Percentage1").value                = '';
                   document.getElementById("txtPunchOut_NPQ_Price1").value                = '';                   
       
                   document.getElementById("txtHDPE_NPQ_Price").value           = '';
                   document.getElementById("txtLLDPE_NPQ_Price").value                = '';
                   document.getElementById("txtPunchOut_NPQ_Price").value                = '';  

                   document.getElementById("TextBox1").value                = '';
                   document.getElementById("TextBox2").value                = '';
               
                   document.getElementById("txtgeraniumou").value           = '';
                   document.getElementById("txtgeraniumin").value           = '';
                   document.getElementById("txtlyellowou").value                = '';
                   document.getElementById("txtlyellowin").value                = '';
                   document.getElementById("txtmyellowou").value         = '';
                   document.getElementById("txtmyellowin").value    = '';


                   document.getElementById("txtRBlueou").value              = '';
                   document.getElementById("txtRBluein").value           = '';                 
                   document.getElementById("txtInkBlueou").value           = '';
                   document.getElementById("txtInkBluein").value           = '';
                   document.getElementById("txtmdorangeou").value                = '';
                   document.getElementById("txtmdorangein").value                = '';
                   document.getElementById("txtInkgreenou").value         = '';
                   document.getElementById("txtInkgreenin").value    = '';


                   document.getElementById("txtInkggreenou").value              = '';
                   document.getElementById("txtInkggreenin").value           = '';                 
                   document.getElementById("txtInkpblueou").value           = '';
                   document.getElementById("txtInkpbluein").value           = '';
             
                   document.getElementById("txtInkBlackou").value         = '';
                   document.getElementById("txtInkBlackin").value    = '';
                   document.getElementById("txtAMRedou").value           = '';
                   document.getElementById("txtAMRedin").value           = '';
                   document.getElementById("txtRFBlueou").value                = '';
                   document.getElementById("txtRFBluein").value                = '';                   
                   document.getElementById("txtInkWhiteou").value           = '';
                   document.getElementById("txtInkWhitein").value           = '';
                   document.getElementById("txtInkSilverou").value                = '';
                   document.getElementById("txtInkSilverin").value                = '';
                   document.getElementById("EntiSlipin").value                = '';
                   document.getElementById("EntiSlipout").value                = '';

    $('#HDPE').attr('checked', false);
    $('#txtHDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Standard_Price').attr('disabled', !this.checked);     
    $('#RecycleOut').attr('checked', false);
    $('#txtPunchOut_NPQ_Percentage1').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price1').attr('disabled', !this.checked);
    $('#TextBox14').attr('disabled', !this.checked);    
    $('#LDPE').attr('checked', false);
    $('#TextBox4').attr('disabled', !this.checked);
    $('#TextBox5').attr('disabled', !this.checked);
    $('#TextBox6').attr('disabled', !this.checked);
   $('#LLDPE').attr('checked', false);
    $('#txtLLDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Standard_Price').attr('disabled', !this.checked);    
   $('#PunchOut').attr('checked', false);
    $('#txtPunchOut_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Standard_Price').attr('disabled', !this.checked);
   $('#MasterBase').attr('checked', false);        
    $('#chkwhite').attr('checked', false);
    $('#chkblue').attr('checked', false);
    $('#chkgreen').attr('checked', false);
    $('#chkRed').attr('checked', false);
    $('#chkYellow').attr('checked', false);
    $('#chkLory').attr('checked', false);
    $('#chkBeige').attr('checked', false);
    $('#chkPink').attr('checked', false);
    $('#chkBgendy').attr('checked', false);

    $('#chkBlack').attr('checked', false);
    $('#chkOrange').attr('checked', false);  
    $('#txtMWIn').attr('disabled', !this.checked);
    $('#txtMWOu').attr('disabled', !this.checked);  
    $('#txtBlueIn').attr('disabled', !this.checked);
    $('#txtBlueOu').attr('disabled', !this.checked);   
    $('#txtGreenin').attr('disabled', !this.checked);
    $('#txtGreenou').attr('disabled', !this.checked);   
    $('#txtRedin').attr('disabled', !this.checked);
    $('#txtRedou').attr('disabled', !this.checked);  
    $('#txtyellowin').attr('disabled', !this.checked);
    $('#txtyellowou').attr('disabled', !this.checked);
    $('#txtLoryin').attr('disabled', !this.checked);
    $('#txtLoryou').attr('disabled', !this.checked);   
    $('#txtBeigein').attr('disabled', !this.checked);
    $('#txtBeigeou').attr('disabled', !this.checked);    
    $('#txtPinkin').attr('disabled', !this.checked);
    $('#txtPinkou').attr('disabled', !this.checked);    
    $('#txtbgendyin').attr('disabled', !this.checked);
    $('#txtbgendyou').attr('disabled', !this.checked);    

    $('#Blackin').attr('disabled', !this.checked);
    $('#Blackou').attr('disabled', !this.checked);
    
    $('#txtOrangein').attr('disabled', !this.checked);
    $('#txtOrangeou').attr('disabled', !this.checked);
    $('#checkMasterbatch').hide();
    
   $('#D2W').attr('checked', false);
    $('#txtD2W_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_Price').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_StandardPrice').attr('disabled', !this.checked);

   $('#EPI').attr('checked', false);
    $('#txtEPI_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Price').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Standard_Price').attr('disabled', !this.checked);


  $('#Thinner').attr('checked', false);
    $('#TextBox1').attr('disabled', !this.checked);
    $('#TextBox2').attr('disabled', !this.checked);
    $('#TextBox3').attr('disabled', !this.checked);


$('#chkInk').attr('checked', false);
    $('#chkInkOpen').hide();

$('#COCO').attr('checked', false);
    $('#txt_coco').attr('disabled', !this.checked);
    $('#txt_coco1').attr('disabled', !this.checked);
    $('#txt_coco2').attr('disabled', !this.checked);

$('#chkwhite').attr('checked', false);
    $('#txtMWIn').attr('disabled', !this.checked);
    $('#txtMWOu').attr('disabled', !this.checked);
    $('#txtMWPr').attr('disabled', !this.checked);

$('#chkgeranium').attr('checked', false);
    $('#txtgeraniumin').attr('disabled', !this.checked);
    $('#txtgeraniumou').attr('disabled', !this.checked);
    $('#txtgeraniumPr').attr('disabled', !this.checked);

$('#chkinkyellow').attr('checked', false);
    $('#txtlyellowou').attr('disabled', !this.checked);
    $('#txtlyellowPr').attr('disabled', !this.checked);
    $('#txtlyellowin').attr('disabled', !this.checked);

$('#chkInkmYellow').attr('checked', false);
    $('#txtmyellowin').attr('disabled', !this.checked);
    $('#txtmyellowou').attr('disabled', !this.checked);
    $('#txtmyellowPr').attr('disabled', !this.checked);

$('#chkinkrblue').attr('checked', false);
    $('#txtRBluein').attr('disabled', !this.checked);
    $('#txtRBlueou').attr('disabled', !this.checked);
    $('#txtRBluePr').attr('disabled', !this.checked);

$('#chkInkblue').attr('checked', false);
    $('#txtInkBluein').attr('disabled', !this.checked);
    $('#txtInkBlueou').attr('disabled', !this.checked);
    $('#txtInkBluePr').attr('disabled', !this.checked);

$('#chkinkmdorange').attr('checked', false);
    $('#txtmdorangein').attr('disabled', !this.checked);
    $('#txtmdorangeou').attr('disabled', !this.checked);
    $('#txtmdorangePr').attr('disabled', !this.checked);


$('#chkinkgreen').attr('checked', false);
    $('#txtInkgreenin').attr('disabled', !this.checked);
    $('#txtInkgreenou').attr('disabled', !this.checked);
    $('#txtInkgreenPr').attr('disabled', !this.checked);

$('#chkInkgrassgreen').attr('checked', false);
    $('#txtInkggreenin').attr('disabled', !this.checked);
    $('#txtInkggreenou').attr('disabled', !this.checked);
    $('#txtInkggreenPr').attr('disabled', !this.checked);

$('#chkInkPBlue').attr('checked', false);
    $('#txtInkpbluein').attr('disabled', !this.checked);
    $('#txtInkpblueou').attr('disabled', !this.checked);
    $('#txtInkpbluePr').attr('disabled', !this.checked);



$('#chkInkBlack').attr('checked', false);
    $('#txtInkBlackin').attr('disabled', !this.checked);
    $('#txtInkBlackou').attr('disabled', !this.checked);
    $('#txtInkBlackPr').attr('disabled', !this.checked);

$('#chkInkAMRed').attr('checked', false);
    $('#txtAMRedin').attr('disabled', !this.checked);
    $('#txtAMRedou').attr('disabled', !this.checked);
    $('#txtAMRedPr').attr('disabled', !this.checked);
    
$('#chkInkrfbluec').attr('checked', false);
    $('#txtRFBluein').attr('disabled', !this.checked);
    $('#txtRFBlueou').attr('disabled', !this.checked);
    $('#txtRFBluePr').attr('disabled', !this.checked);

$('#chkInkWhite').attr('checked', false);
    $('#txtInkWhitein').attr('disabled', !this.checked);
    $('#txtInkWhiteou').attr('disabled', !this.checked);
    $('#txtInkWhitePr').attr('disabled', !this.checked);

$('#chkInkSilver').attr('checked', false);
    $('#txtInkSilverin').attr('disabled', !this.checked);
    $('#txtInkSilverou').attr('disabled', !this.checked);
    $('#txtInkSilverPr').attr('disabled', !this.checked);



$('#chkEntiSlip').attr('checked', false);
    $('#EntiSlipin').attr('disabled', !this.checked);
    $('#EntiSlipout').attr('disabled', !this.checked);
    $('#EntiSlippr').attr('disabled', !this.checked);

$('#HD').attr('checked', false); 
     $('#txtDensity').val('0');
  
  $('#LD').attr('checked', false); 
     $('#txtDensity').val('0');
                   
}           
        
        function addProduct()       
                   {

  var lcl_obj_ddlItemSpec               =          $('#ddlItemSpec option:Selected').val();
  var lcl_obj_CatagoryCode              =          $('#ddlCatagory option:Selected').val();
  var lcl_obj_CatagoryName              =          $('#ddlCatagory option:Selected').val();     
  

     if (lcl_obj_CatagoryName=='1010000001')
      {
     var val = 'T-Shirt Bag';
            lcl_obj_CatagoryName = val;  
        
        }

        if (lcl_obj_CatagoryName=='1010000002')
        {
        var val = 'Block Bag';
           lcl_obj_CatagoryName=val;  
        
        }

         if (lcl_obj_CatagoryName=='1010000003')
      {
     var val = 'Knot Bag';
            lcl_obj_CatagoryName=val;;  
        
        }

        if (lcl_obj_CatagoryName=='1010000004')
        {
        var val = 'Die-Cut Bag';
           lcl_obj_CatagoryName=val;  
        
        }

         if (lcl_obj_CatagoryName=='1010000005')
      {
     var val = 'Soft Loop Handle Bag';
            lcl_obj_CatagoryName=val;  
        
        }

        if (lcl_obj_CatagoryName=='1010000006')
        {
        var val = 'Garbage Bag on Roll';
            lcl_obj_CatagoryName=val;  
        
        }


         if (lcl_obj_CatagoryName=='1010000007')
      {
     var val = 'Flat Bag on Roll';
            lcl_obj_CatagoryName=val;  
        
        }

        if (lcl_obj_CatagoryName=='1010000008')
        {
        var val = 'T-Shirt Bag on Roll';
            lcl_obj_CatagoryName=val;  
        
        }

         if (lcl_obj_CatagoryName=='1010000009')
      {
     var val = 'Heat Seal Patch Handle Bag / Patch Handle Diecut Bag';
            lcl_obj_CatagoryName=val
        
        }

        if (lcl_obj_CatagoryName=='1010000010')
        {
        var val = 'Star Seal Bag on Roll with Core';
            lcl_obj_CatagoryName=val;  
        
        }

         if (lcl_obj_CatagoryName=='1010000011')
      {
     var val = 'Star Seal Bag on Roll without Core';
            lcl_obj_CatagoryName=val;  
        
        }

        if (lcl_obj_CatagoryName=='1010000012')
        {
        var val = 'Handgloves';
            lcl_obj_CatagoryName=val;  
        
        }

        if (lcl_obj_CatagoryName=='1010000013')
        {
        var val = 'Ice Bag';
            lcl_obj_CatagoryName=val;  
        
        }                

                         var lcl_obj_ItemNo              =          document.getElementById("ItemNo");        
                         var lcl_obj_ProductRef          =          document.getElementById("txt_ProductRef");
                         var lcl_obj_ProductDec          =          document.getElementById("txt_ProductDec");
                         var lcl_obj_Quantity            =          document.getElementById("txtQuantity");
                         var lcl_obj_TotalPrice          =          document.getElementById("txt_totalPrice");
                         var lcl_obj_FobPrice            =          document.getElementById("txt_FobPrice");
                         var lcl_obj_txtWidth            =          document.getElementById("txtWidth");
                         var lcl_obj_txtLength           =          document.getElementById("txtLength");
                         var lcl_obj_txtGusset           =          document.getElementById("txtGusset");
                         var lcl_obj_txtDensity          =          document.getElementById("txtDensity");
                         var lcl_obj_txtThickness        =          document.getElementById("txtThickness");
                         var lcl_obj_txtNetWeight        =          document.getElementById("txtNetWeight");
                         var lcl_obj_Carton              =          document.getElementById("Carton");
                         var lcl_obj_Kgs                 =          document.getElementById("Kgs");
                          var lcl_obj_txtppb              =         document.getElementById("txtppb");
                         var lcl_obj_txtbpc                 =       document.getElementById("txtbpc");        
                         var lcl_obj_Weight              =          document.getElementById("txtNetWeight");
                         var lcl_str_ItemNo              =          $.trim($(lcl_obj_ItemNo).val().toString());
                         var lcl_str_ProductRef          =          $.trim($(lcl_obj_ProductRef).val().toString());
                         var lcl_str_ProductDec          =          $.trim($(lcl_obj_ProductDec).val().toString());
                         var lcl_str_Quantity            =          $.trim($(lcl_obj_Quantity).val().toString());
                         var lcl_str_txtWidth            =          $.trim($(lcl_obj_txtWidth).val().toString());
                         var lcl_str_txtLength           =          $.trim($(lcl_obj_txtLength).val().toString());
                         var lcl_str_txtWidth            =          $.trim($(lcl_obj_txtWidth).val().toString());
                         var lcl_str_txtLength           =          $.trim($(lcl_obj_txtLength).val().toString());
                         var lcl_str_txtGusset           =          $.trim($(lcl_obj_txtGusset).val().toString());
                         var lcl_str_txtDensity          =          $.trim($(lcl_obj_txtDensity).val().toString());
                         var lcl_str_txtThickness        =          $.trim($(lcl_obj_txtThickness).val().toString());
                         var lcl_str_txtNetWeight        =          $.trim($(lcl_obj_txtNetWeight).val().toString());
                         var lcl_str_Carton              =          $.trim($(lcl_obj_Carton).val().toString());
                         var lcl_str_Kgs                 =          $.trim($(lcl_obj_Kgs).val().toString());
                        
                         var lcl_str_txtppb                 =          $.trim($(lcl_obj_txtppb).val().toString());
                         var lcl_str_txtbpc                 =          $.trim($(lcl_obj_txtbpc).val().toString());
                         
                         
                         var lcl_str_Weight              =          $.trim($(lcl_obj_Weight).val().toString());
                       
                         var lcl_str_PcsPerCarton         =          $.trim($("#totalpcspercarton").val());
                         var lcl_str_CBM         =          $.trim($("#CBM").val());
                       
    
  
  if (lcl_str_ProductRef == '') {
                 DisplayError("Please Fill Up The Field 'Product Ref'!!!");
                 return;
    }
    if (lcl_str_Quantity == '') {
                 DisplayError("Please Fill Up The Field 'Quantity'!!!");
                 return;
    }
    if (lcl_str_ProductDec == '') {
                 DisplayError("Please Fill Up The Field 'Product Description'!!!");
                return;
    }
    if (lcl_str_txtWidth == '') {
                DisplayError("Please Fill Up The Field 'Width'!!!");
                return;
    }
    if (lcl_str_txtLength == '') {
                DisplayError("Please Fill Up The Field 'Length'!!!");
                return;
    }
    if (lcl_str_txtGusset == '') {
                DisplayError("Please Fill Up The Field 'Gusset'!!!");
                return;
    }
    if (lcl_str_txtDensity == '') {
                DisplayError("Please Fill Up The Field 'Density'!!!");
                return;
    }
    if (lcl_str_txtThickness == '') {
                DisplayError("Please Fill Up The Field 'Thickness'!!!");
                return;
    }
//    if (lcl_str_fileBrowser == '') {
//                DisplayError("Please Upload Your Image !!!");
//                return;
//    }     
                      autoincrement();
                      
                       var lcl_str_Append              =       lcl_str_ProductDec;
                       var lcl_str_QuantityDesc        =       lcl_str_Kgs;    
                       var lcl_str_Pricedesc           =       lcl_str_TotalPrice;
                       var lcl_str_TotalPrice          =       $.trim($(lcl_obj_TotalPrice).val().toString());
                       var lcl_str_FobPrice            =       $.trim($(lcl_obj_FobPrice).val().toString());
                       var lcl_str_FobPriceTotal       =       lcl_str_FobPrice ;
                       var lcl_strsplit_FobPriceTotal  =       lcl_str_FobPriceTotal.replace("$", '');
                       var lcl_strrpc_FobPriceTotal    =       lcl_strsplit_FobPriceTotal.replace(/,/g, '');
                       var lcl_flt_FobPriceTotal       =       parseFloat(lcl_strrpc_FobPriceTotal);
                       var lcl_strsplit_Pricedesc      =       lcl_str_TotalPrice.replace("$", '');
                       var lcl_strrpc_Pricedesc        =       lcl_strsplit_Pricedesc.replace(/,/g, '');
                       

                       $('#tblProductDetails').appendGrid('appendRow', [

                       { CatagoryCode:lcl_obj_CatagoryCode,ItemCode:lcl_obj_ddlItemSpec,ItemNo:lcl_str_ItemNo, ProductRef: lcl_str_ProductRef,CatagoryName:lcl_obj_CatagoryName,Desc: lcl_str_Append,Width:lcl_str_txtWidth,Length:lcl_str_txtLength,Gusset:lcl_str_txtGusset,Density:lcl_str_txtDensity,Thickness:lcl_str_txtThickness,ppb:lcl_str_txtppb,bpc:lcl_str_txtbpc,Wgt1tp:lcl_str_Weight, Quantity:lcl_str_Quantity,Carton:lcl_str_Carton,PcsPerCarton:lcl_str_PcsPerCarton,CBM:lcl_str_CBM,KG:lcl_str_Kgs,UnitPrice:lcl_flt_FobPriceTotal,TotalPrice:lcl_strrpc_Pricedesc},
    
    ]);
   
}      

$(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#tblProductDetails').appendGrid({
                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                                 {name: 'ItemNo', display: 'No', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ProductRef', display: 'Ref', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },                                 
                                 { name: 'ItemCode', display: 'Item Code',type: 'text', value: 0 },
                                 { name: 'QuotationDetailsCode',display: 'Quo De', type: 'text', value: 0 },                                 
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

  function RefreshEducationControls() 
  {

                    document.getElementById("txt_ProductRef").value         =       '';
                    document.getElementById("txt_ProductDec").value         =       '';
                    document.getElementById("txtQuantity").value            =       '';
                    document.getElementById("txt_Price").value              =       '';
                    document.getElementById("txt_FobPrice").value           =       '';
                    document.getElementById("txtWidth").value               =       '';
                    document.getElementById("txtLength").value              =       '';
                    document.getElementById("txtGusset").value              =       '';
                    document.getElementById("txtDensity").value             =       '';
                    document.getElementById("txtThickness").value           =       '';
  }     
 
        

function Newcustomer() {

                     document.getElementById("txtCompany_NC").value        =     '';
                     document.getElementById("txtAddress_NC").value        =     '';
                     document.getElementById("txtPhone_NC").value          =     '';
                     document.getElementById("txtContactPerson_NC").value  =     '';
                     document.getElementById("Email").value                =     '';
                     document.getElementById("Country").value              =     '';
}




    function POSave()
    {
 var lcl_b_PO=false;
 if ($('#chkQuotation').is(':checked')) {
        lcl_b_PO=true;
      
        }
else
        {
         lcl_b_PO=false;

        }

      
                    var lcl_obj_PO = new Object();
                    lcl_obj_PO.BuyerCode= $("#ddlBuyer option:selected").val();
                    if(lcl_b_PO == true)
                   {
                    lcl_obj_PO.QuotationCode= $("#ddlQuotation option:selected").val();
                    }
                    lcl_obj_PO.CustomerReq= $("#txtCustomeReq").val();

                    lcl_obj_PO.IPEmployeeCode     =   $("#txtSignedInEmployeeCode").val();
                    lcl_obj_PO.ComName=$("#txt_ComName").val();
                    lcl_obj_PO.ComAddress=$("#txt_ComAddress").val();
                    lcl_obj_PO.ComPhone=$("#txt_ComPhone").val();
                    lcl_obj_PO.ComEmail=$("#txt_ComEmail").val();
                    lcl_obj_PO.ComAmount=$("#txt_ComAmount").val();
                    var lcl_i32_Count =  $('#tblProductDetails').appendGrid('getRowCount');
                   
                     debugger;
                   lcl_obj_PO.PurchaseOrderDetails=new  Array();
        for (var j = 0; j < lcl_i32_Count; j++)         
        {
                lcl_obj_PO.PurchaseOrderDetails[j]=new Object();
                     if(lcl_b_PO == true)
                   {
                    lcl_obj_PO.PurchaseOrderDetails[j].QuotationDetailsCode          =   $('#tblProductDetails').appendGrid('getCtrlValue', 'QuotationDetailsCode', j);
                    }
                   else{
                   lcl_obj_PO.PurchaseOrderDetails[j].QuotationDetailsCode=0;
                   lcl_obj_PO.PurchaseOrderDetails[j].ProductRef          =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ProductRef', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].ItemCode            =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ItemCode', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].ProductDesc         =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Desc', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].ItemCataGoryCode    =   $('#tblProductDetails').appendGrid('getCtrlValue', 'CatagoryCode', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].PPB                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ppb', j); 
                    lcl_obj_PO.PurchaseOrderDetails[j].BPC                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'bpc', j); 
                    lcl_obj_PO.PurchaseOrderDetails[j].Quantity            =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Quantity', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].Weight              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Wgt1tp', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].Carton              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Carton', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].PcsPerCarton        =   $('#tblProductDetails').appendGrid('getCtrlValue', 'PcsPerCarton', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].QtyPkg              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'KG', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].UnitPriceCifFos     =   $('#tblProductDetails').appendGrid('getCtrlValue', 'UnitPrice', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].TotalAmountCifFos   =   $('#tblProductDetails').appendGrid('getCtrlValue', 'TotalPrice', j);
                    lcl_obj_PO.PurchaseOrderDetails[j].CBM                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'CBM', j);

                   }
                    
}               
                 if (confirm("Are you sure you want to submit this application?") == true) {
             $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                       url: gbl_URL_Root + "WebServices/WPMS/PurchaseOrder.asmx/POSave", 

                        data: "{IP_obj_PO:" + JSON.stringify(lcl_obj_PO) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());

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
        }return false;
    }

      function LoadAlllist() {
      
       var lcl_str_ddlQuotationCode = $('#ddlQuotation option:selected').val();
    

       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                       url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/Retrive", 

                        data: "{IP_ui64_QuotationCode:" + JSON.stringify(lcl_str_ddlQuotationCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                         
                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                                 
                                     
     if (lcl_obj_QuotationDetail.ItemCode=='1010000001')
      {
     var val = 'T-Shirt Bag';
            lcl_obj_radion = val;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000002')
        {
        var val = 'Block Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_QuotationDetail.ItemCode=='1010000003')
      {
     var val = 'Knot Bag';
            lcl_obj_radion=val;;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000004')
        {
        var val = 'Die-Cut Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_QuotationDetail.ItemCode=='1010000005')
      {
     var val = 'Soft Loop Handle Bag';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000006')
        {
        var val = 'Garbage Bag on Roll';
            lcl_obj_radion=val;  
        
        }


         if (lcl_obj_QuotationDetail.ItemCode=='1010000007')
      {
     var val = 'Flat Bag on Roll';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000008')
        {
        var val = 'T-Shirt Bag on Roll';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_QuotationDetail.ItemCode=='1010000009')
      {
     var val = 'Heat Seal Patch Handle Bag / Patch Handle Diecut Bag';
            lcl_obj_radion=val
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000010')
        {
        var val = 'Star Seal Bag on Roll with Core';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_QuotationDetail.ItemCode=='1010000011')
      {
     var val = 'Star Seal Bag on Roll without Core';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000012')
        {
        var val = 'Handgloves';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_QuotationDetail.ItemCode=='1010000013')
        {
        var val = 'Ice Bag';
            lcl_obj_radion=val;  
        
        }                
                                $('#tblProductDetails').appendGrid('appendRow', [
                     { 
                       ProductRef:lcl_obj_QuotationDetail.ProductRef,
                       ItemCode:lcl_obj_QuotationDetail.ItemCode,
                       QuotationDetailsCode:lcl_obj_QuotationDetail.QuotationDCode, 
                       CatagoryCode:lcl_obj_QuotationDetail.ItemCatagoryCode,
                       CatagoryName:val,
                       Desc: lcl_obj_QuotationDetail.ProductDesc,
                       Width:lcl_obj_QuotationDetail.ProductSize,
                       Length:lcl_obj_QuotationDetail.Length,
                       Gusset:lcl_obj_QuotationDetail.Gusset,
                       Density:lcl_obj_QuotationDetail.Density,
                       Thickness:lcl_obj_QuotationDetail.Thickness,
                       ppb:lcl_obj_QuotationDetail.PPB,
                       bpc:lcl_obj_QuotationDetail.BPC,
                       Wgt1tp:lcl_obj_QuotationDetail.NetWeight, 
                       Quantity:lcl_obj_QuotationDetail.Quantity,
                       PcsPerCarton:lcl_obj_QuotationDetail.PkgPcsPerCarton,
                       Carton:lcl_obj_QuotationDetail.PkgCarton,
                       CBM:lcl_obj_QuotationDetail.CBM,
                       KG:lcl_obj_QuotationDetail.QtyKg,
                       UnitPrice:lcl_obj_QuotationDetail.UnitPriceCifFos,
                       TotalPrice:lcl_obj_QuotationDetail.TotalAmountCofFos},
        
      
        ]);                              
    });
}        else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function ( jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
        } 

       
   


   function autoincrement()
   {
      var lcl_str_ItemNo             =   $.trim($("#ItemNo").val());

   lcl_int_ItemNo = parseInt(lcl_str_ItemNo);
   lcl_int_Count= 1;
   lcl_int_ItemNo=lcl_int_ItemNo+lcl_int_Count;
   $("#ItemNo").val(lcl_int_ItemNo);
   
   }


        $(document).ready(function () {

        
     $(".float_only").keydown(function (event) {
        if (event.shiftKey == true) {
            event.preventDefault();
        }

        if ((event.keyCode >= 48 && event.keyCode <= 57) ||
            (event.keyCode >= 96 && event.keyCode <= 105) ||
            event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
            event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190) {

        } else {
            event.preventDefault();
        }

        if ($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
            event.preventDefault();
        //if a decimal has been added, disable the "."-button

    });

    $(".raw_mat_prcntge").blur(function () {
        var lcl_flt_RawMaterialPrice = 0; //will be assigned in each phase of calculation
        var lcl_flt_TotalPercentage = 0.0;
        var lcl_flt_InputValue = 0.0;

        var lcl_str_Value = $.trim($(this).val());

        if (lcl_str_Value == '') {
            return false;
        }
        lcl_flt_InputValue = parseFloat(lcl_str_Value);
        var lcl_flt_TotalPercentage = 0.0;
        $(".raw_mat_prcntge").each(function (index, element1) {
            var lcl_str_Percentage = $.trim($(element1).val());
            if (lcl_str_Percentage == "") {
                return;
            }
            var lcl_flt_Percentage = parseFloat(lcl_str_Percentage);
            lcl_flt_TotalPercentage += lcl_flt_Percentage;
        });

        if (lcl_flt_TotalPercentage > 100.0) {
            DisplayError("Total Raw Material Percentage is : " + lcl_flt_TotalPercentage.toString() + ".This Value Cannot Be More Than 100!!!");
            $(this).val('');
            return;
        }
        
        var lcl_str_ControlId = $.trim($(this).attr('id'));

        if (lcl_str_ControlId == "txtHDPE_NPQ_Percentage") {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price

            var lcl_str_HDPEStandardPrice = $("#txtHDPE_NPQ_Standard_Price").val();

            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtHDPE_NPQ_Price").val(lcl_flt_HDPEPrice);
            $("#txtHDPE_NPQ_Price").formatCurrency();
            // alert(lcl_str_ControlId);
        }

        if (lcl_str_ControlId == "txtLLDPE_NPQ_Percentage") {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_LLDPEStandardPrice = $("#txtLLDPE_NPQ_Standard_Price").val();
            var lcl_flt_LLDPEStandardPrice = parseFloat(lcl_str_LLDPEStandardPrice);
            var lcl_flt_LLDPEPrice = parseFloat((lcl_flt_LLDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_LLDPEPrice;
            $("#txtLLDPE_NPQ_Price").val(lcl_flt_LLDPEPrice);
            $("#txtLLDPE_NPQ_Price").formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == "txtPunchOut_NPQ_Percentage") {

            var lcl_str_HDPEStandardPrice = $("#txtPunchOut_NPQ_Standard_Price").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            //alert(lcl_flt_RawMaterialPrice);
            $("#txtPunchOut_NPQ_Price").val(lcl_flt_HDPEPrice);
            $('#txtPunchOut_NPQ_Price').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtMasterBase_NPQ_Percentage') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtMasterBase_NPQ_Standard_Price").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtMasterBase_NPQ_Price").val(lcl_flt_HDPEPrice);
            $('#txtMasterBase_NPQ_Price').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtD2W_NPQ_Percentage') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtD2W_NPQ_StandardPrice").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtD2W_NPQ_Price").val(lcl_flt_HDPEPrice);
            $('#txtD2W_NPQ_Price').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtEPI_NPQ_Percentage') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtEPI_NPQ_Standard_Price").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtEPI_NPQ_Price").val(lcl_flt_HDPEPrice);
            $('#txtEPI_NPQ_Price').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'TextBox1') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#TextBox3").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#TextBox2").val(lcl_flt_HDPEPrice);
            $('#TextBox2').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txt_ink') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txt_ink2").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txt_ink1").val(lcl_flt_HDPEPrice);
            $('#txt_ink1').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

if (lcl_str_ControlId == 'txtPunchOut_NPQ_Percentage1') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#TextBox14").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtPunchOut_NPQ_Price1").val(lcl_flt_HDPEPrice);
            $('#txtPunchOut_NPQ_Price1').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'TextBox4') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#TextBox6").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#TextBox5").val(lcl_flt_HDPEPrice);
            $('#TextBox5').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

         if (lcl_str_ControlId == 'txt_coco') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txt_coco2").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txt_coco1").val(lcl_flt_HDPEPrice);
            $('#txt_coco1').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtMWIn') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtMWPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtMWOu").val(lcl_flt_HDPEPrice);
            $('#txtMWOu').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }
        
        if (lcl_str_ControlId == 'txtBlueIn') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtBluePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtBlueOu").val(lcl_flt_HDPEPrice);
            $('#txtBlueOu').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

            if (lcl_str_ControlId == 'txtGreenin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtGreenPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtGreenou").val(lcl_flt_HDPEPrice);
            $('#txtGreenou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtRedin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRedPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRedou").val(lcl_flt_HDPEPrice);
            $('#txtRedou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }


        if (lcl_str_ControlId == 'txtyellowin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtyellowPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtyellowou").val(lcl_flt_HDPEPrice);
            $('#txtyellowou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }



        if (lcl_str_ControlId == 'txtLoryin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtLoryPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtLoryou").val(lcl_flt_HDPEPrice);
            $('#txtLoryou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtBeigein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtBeigePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtBeigeou").val(lcl_flt_HDPEPrice);
            $('#txtBeigeou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtPinkin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtPinkPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtPinkou").val(lcl_flt_HDPEPrice);
            $('#txtPinkou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }


        if (lcl_str_ControlId == 'txtbgendyin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtbgendyPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtbgendyou").val(lcl_flt_HDPEPrice);
            $('#txtbgendyou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        
        if (lcl_str_ControlId == 'Blackin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#BlackPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#Blackou").val(lcl_flt_HDPEPrice);
            $('#Blackou').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtOrangein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtOrangePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtOrangeou").val(lcl_flt_HDPEPrice);
            $('#txtOrangeou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtgeraniumin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtgeraniumPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtgeraniumou").val(lcl_flt_HDPEPrice);
            $('#txtgeraniumou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtlyellowin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtlyellowPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtlyellowou").val(lcl_flt_HDPEPrice);
            $('#txtlyellowou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

          if (lcl_str_ControlId == 'txtmyellowin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtmyellowPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtmyellowou").val(lcl_flt_HDPEPrice);
            $('#txtmyellowou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }


        if (lcl_str_ControlId == 'txtRBluein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRBluePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRBlueou").val(lcl_flt_HDPEPrice);
            $('#txtRBlueou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

          if (lcl_str_ControlId == 'txtInkBluein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkBluePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkBlueou").val(lcl_flt_HDPEPrice);
            $('#txtInkBlueou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtmdorangein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtmdorangePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtmdorangeou").val(lcl_flt_HDPEPrice);
            $('#txtmdorangeou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkgreenin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkgreenPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkgreenou").val(lcl_flt_HDPEPrice);
            $('#txtInkgreenou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkggreenin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkggreenPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkggreenou").val(lcl_flt_HDPEPrice);
            $('#txtInkggreenou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkpbluein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkpbluePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkpblueou").val(lcl_flt_HDPEPrice);
            $('#txtInkpblueou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

       
        if (lcl_str_ControlId == 'txtInkBlackin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkBlackPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkBlackou").val(lcl_flt_HDPEPrice);
            $('#txtInkBlackou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtAMRedin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtAMRedPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtAMRedou").val(lcl_flt_HDPEPrice);
            $('#txtAMRedou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }
        if (lcl_str_ControlId == 'txtRFBluein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRFBluePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRFBlueou").val(lcl_flt_HDPEPrice);
            $('#txtRFBlueou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkWhitein') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkWhitePr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkWhiteou").val(lcl_flt_HDPEPrice);
            $('#txtInkWhiteou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkSilverin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkSilverPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkSilverou").val(lcl_flt_HDPEPrice);
            $('#txtInkSilverou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }
        
        if (lcl_str_ControlId == 'EntiSlipin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#EntiSlippr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#EntiSlipout").val(lcl_flt_HDPEPrice);
            $('#EntiSlipout').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtLgrassin') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtLgrassPr").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtLgrassou").val(lcl_flt_HDPEPrice);
            $('#txtLgrassou').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        var lcl_flt_TotalPrice = 0.0;
        $(".raw_mat_prc").each(function (index, element) {
            var lcl_str_Price = $(element).val();
            lcl_str_Price = lcl_str_Price.replace('$', '');
            lcl_str_Price = lcl_str_Price.replace(',', '');
            if (lcl_str_Price == "") {
                return;
            }
            var lcl_flt_Price = parseFloat(lcl_str_Price);
            lcl_flt_TotalPrice += lcl_flt_Price;

        });
       
        $("#txtRawMaterialPrice").val(lcl_flt_TotalPrice.toString());
      $("#txtRawMaterialPrice").formatCurrency();
    });

    $('.number').keypress(function (event) {
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
        
        });


function LoadItemName()

{

var lcl_ui64_BuyerCode = $.trim($("#ddlBuyer option:Selected").val());
 var lcl_ui64_ItemCode              =          $("#ddlCatagory option:Selected").val();

 
$.ajax({

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Item.asmx/LoadItem", 

                        data: "{IP_ui64_BuyerCode:" + JSON.stringify(lcl_ui64_BuyerCode) + ",IP_ui64_CatagoryCode:" + JSON.stringify(lcl_ui64_ItemCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                             document.getElementById("Processingcost").value='0';
                                var lcl_obj_Quotation = WSReturn.Data;
                                   $("#ddlItemSpec").find("option").remove();
                               $("#ddlItemSpec").append("<option value='0'>....Select Specification...."+ "</option>");
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                            $("#ddlItemSpec").append("<option value='" + lcl_obj_QuotationDetail.ItemCode + "'>" + lcl_obj_QuotationDetail.ItemName + "</option>");
                             
                                     
                                });                                
        
}
                        else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function ( jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
});
}


function LoadItemsSpecDetails() {
      
      var lcl_obj_ddlItemSpec = $.trim($('#ddlItemSpec option:selected').val());

      if(lcl_obj_ddlItemSpec=='0')
      {
      
      return;
      }
    
       $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Item.asmx/LoadItemSpec", 

                        data: "{IP_obj_ddlItemSpec:" + JSON.stringify(lcl_obj_ddlItemSpec) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                             document.getElementById("txtWidth").value= lcl_obj_QuotationDetail.Width;
                             document.getElementById("txtLength").value= lcl_obj_QuotationDetail.Length;
                             document.getElementById("txtGusset").value= lcl_obj_QuotationDetail.Gusset;
                             document.getElementById("txtDensity").value= lcl_obj_QuotationDetail.Density;
                             document.getElementById("txtThickness").value= lcl_obj_QuotationDetail.Thickness;
                             document.getElementById("Cutout").value= lcl_obj_QuotationDetail.Punchout;
                             document.getElementById("Processingcost").value= lcl_obj_QuotationDetail.ProcessingCost;
                             document.getElementById("printingCharge").value= lcl_obj_QuotationDetail.PrintingCharge;
                                
                                });    
}
                        else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function ( jqXHR, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
        } 
