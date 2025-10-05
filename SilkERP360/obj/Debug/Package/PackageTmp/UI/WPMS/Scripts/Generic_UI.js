  
$(document).ready(function () {

//for PO
$('#SelectQuotationforPO').hide();

    $('#QuotationChkforPo').click(function() {
    if($(this).is(':checked')){
              $('#SelectQuotationforPO').show(500);
              $('#POCustomerInfo').hide(500);
              }
              else{
              $('#SelectQuotationforPO').hide(500);
              $('#POCustomerInfo').show(500);}
              });

///For PO


$('#leftrow').hide();
 $('#checkMasterbatch').hide();
 $('#chkInkOpen').hide(); 
 //for PO
 $('#leftrow0').hide();
 $('#checkMasterbatch0').hide();
 $('#chkInkOpen0').hide(); 

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

//for PO
$('#Digit3').click(function() {
    if($(this).is(':checked')){
     var num = parseFloat($("#txtNetWeight").val());
    var new_num = $("#txtNetWeight0").val(num.toFixed(2));
              
             }

             else
             {
             var lcl_str_Width = $.trim($("#txtWidth0").val());
                 var lcl_str_Length = $.trim($("#txtLength0").val());
                 var lcl_str_Gusset = $.trim($("#txtGusset0").val());
                 var lcl_str_Density = $.trim($("#txtDensity0").val());
                 var lcl_str_Thickness = $.trim($("#txtThickness0").val());
                 var lcl_str_CutOut = $.trim($("#Cutout0").val());
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
    $("#txtNetWeight0").val(lcl_flt_NetWeight.toFixed(4));
    }

else {
        var lcl_flt_NetWeight = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);
    }
    
    $("#txtNetWeight0").val(lcl_flt_NetWeight.toFixed(4));
             
             }
          
});

$('#HD').click(function() {
    if($(this).is(':checked')){
              $('#txtDensity').val('0.0952');
             }
             else{
              $('#txtDensity').val('0');
             }
});

//for PO
$('#HD0').click(function() {
    if($(this).is(':checked')){
              $('#txtDensity1').val('0.0952');
             }
             else{
              $('#txtDensity1').val('0');
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

//for PO

$('#LD0').click(function() {
    if($(this).is(':checked')){
              $('#txtDensity1').val('0.091');
              }
              else
              {
               $('#txtDensity1').val('0');
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
//For PO
    $('#NewProductName0').hide();
    $('#NewProduct0').click(function() {
    if($(this).is(':checked')){
              $('#NewProductName0').show();
              $('#ProductName0').hide();
              }
              else{
              $('#NewProductName0').hide();
              $('#ProductName0').show();
              }
    
});

    $("#txtWidth").click(function() {
                $(this).focus();
                $(this).select();
            });

            //for po
               $("#txtWidth1").click(function() {
                $(this).focus();
                $(this).select();
            });
  $("#txtLength").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
            $("#txtLength1").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#txtGusset").click(function() {
                $(this).focus();
                $(this).select();
            });

            //for PO

              $("#txtGusset1").click(function() {
                $(this).focus();
                $(this).select();
            });

            $("#txtNetWeight").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
            $("#txtNetWeight1").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#txtDensity").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
             $("#txtDensity1").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#txtThickness").click(function() {
                $(this).focus();
                $(this).select();
            });

             //For PO
              $("#txtThickness1").click(function() {
                $(this).focus();
                $(this).select();
            });

              $("#Cutout").click(function() {
                $(this).focus();
                $(this).select();
            });

            //for PO
             $("#Cutout1").click(function() {
                $(this).focus();
                $(this).select();
            });

              $("#Processingcost").click(function() {
                $(this).focus();
                $(this).select();
            });

            //FOR PO

            $("#Processingcost1").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#printingCharge").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO

             $("#printingCharge1").click(function() {
                $(this).focus();
                $(this).select();
            });


              $("#Freightcost").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
            $("#Freightcost1").click(function() {
                $(this).focus();
                $(this).select();
            });

            $("#Cylinder").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
             $("#Cylinder1").click(function() {
                $(this).focus();
                $(this).select();
            });

            $("#Height").click(function() {
                $(this).focus();
                $(this).select();
            });
            
            //For PO

            $("#Height1").click(function() {
                $(this).focus();
                $(this).select();
            });

            $("#Width").click(function() {
                $(this).focus();
                $(this).select();
            });
               

               //For PO
               $("#Width0").click(function() {
                $(this).focus();
                $(this).select();
            });

                $("#Length").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO
              $("#Length0").click(function() {
                $(this).focus();
                $(this).select();
            });

                     
           $("#txtQuantity").click(function() {
                $(this).focus();
                $(this).select();
            });

            //For PO

             $("#txtQuantity1").click(function() {
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

            //For PO

             $("#txtbpc0").click(function() {
                $(this).focus();
                $(this).select();
            });

             $("#txtppb").click(function() {
                $(this).focus();
                $(this).select();
            }); 

            //For PO
            $("#txtppb0").click(function() {
                $(this).focus();
                $(this).select();
            }); 


             $("#txtOuterBag").click(function() {
                $(this).focus();
                $(this).select();
            }); 

            //For PO
            $("#txtOuterBag0").click(function() {
                $(this).focus();
                $(this).select();
            }); 

           

    $('#HDPE').click(function() {
    $('#txtHDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});

//For PO

    $('#HDPE0').click(function() {
    $('#txtHDPE_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Standard_Price0').attr('disabled', !this.checked);
    
});



    $('#LDPE').click(function() {
    $('#TextBox4').attr('disabled', !this.checked);
    $('#TextBox5').attr('disabled', !this.checked);
    $('#TextBox6').attr('disabled', !this.checked);
    
});

//For PO
  $('#LDPE0').click(function() {
    $('#TextBox50').attr('disabled', !this.checked);
    $('#TextBox51').attr('disabled', !this.checked);
    $('#TextBox52').attr('disabled', !this.checked);
    
});
   $('#LLDPE').click(function() {
    $('#txtLLDPE_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Price').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});

//For PO

   $('#LLDPE0').click(function() {
    $('#txtLLDPE_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Standard_Price0').attr('disabled', !this.checked);
    
});

   $('#PunchOut').click(function() {
    $('#txtPunchOut_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});

//For PO

  $('#PunchOut0').click(function() {
    $('#txtPunchOut_NPQ_Percentage2').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price2').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Standard_Price0').attr('disabled', !this.checked);
    
});

   $('#MasterBase').click(function() {

    if($(this).is(':checked')){
      $('#checkMasterbatch').show(500);
     
             }

             else{
              $('#checkMasterbatch').hide();
      
             } 
});

//For PO

   $('#MasterBase0').click(function() {

    if($(this).is(':checked')){
      $('#checkMasterbatch0').show(500);
     
             }

             else{
              $('#checkMasterbatch0').hide();
      
             } 
});

   $('#D2W').click(function() {
    $('#txtD2W_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_Price').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_StandardPrice').attr('disabled', !this.checked);
   
});

//For PO
 $('#D2W0').click(function() {
    $('#txtD2W_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_StandardPrice0').attr('disabled', !this.checked);
   
});


    $('#EPI').click(function() {
    $('#txtEPI_NPQ_Percentage').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Price').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Standard_Price').attr('disabled', !this.checked);
    
});

//For PO
  $('#EPI0').click(function() {
    $('#txtEPI_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Standard_Price0').attr('disabled', !this.checked);
    
});

  $('#Thinner').click(function() {
    $('#TextBox1').attr('disabled', !this.checked);
    $('#TextBox2').attr('disabled', !this.checked);
    $('#TextBox3').attr('disabled', !this.checked);
    
});

//For PO

  $('#Thinner0').click(function() {
    $('#TextBox79').attr('disabled', !this.checked);
    $('#TextBox80').attr('disabled', !this.checked);
    $('#TextBox81').attr('disabled', !this.checked);
    
});

$('#chkInk').click(function() {


if($(this).is(':checked')){
      $('#chkInkOpen').show(500);
   
             }

             else{
              $('#chkInkOpen').hide();
            
             }
});

//For PO

$('#chkInk0').click(function() {


if($(this).is(':checked')){
      $('#chkInkOpen0').show(500);
   
             }

             else{
              $('#chkInkOpen0').hide();
            
             }
});


$('#COCO').click(function() {
    $('#txt_coco').attr('disabled', !this.checked);
    $('#txt_coco1').attr('disabled', !this.checked);
    $('#txt_coco2').attr('disabled', !this.checked);
    
});


//For Po

$('#COCO0').click(function() {
    $('#txt_coco3').attr('disabled', !this.checked);
    $('#txt_coco4').attr('disabled', !this.checked);
    $('#txt_coco5').attr('disabled', !this.checked);
    
});


$('#chkwhite').click(function() {
    $('#txtMWIn').attr('disabled', !this.checked);
    $('#txtMWOu').attr('disabled', !this.checked);
    $('#txtMWPr').attr('disabled', !this.checked);
    
});

//For PO
$('#chkwhite0').click(function() {
    $('#txtMWIn0').attr('disabled', !this.checked);
    $('#txtMWOu0').attr('disabled', !this.checked);
    $('#txtMWPr0').attr('disabled', !this.checked);
    
});


$('#chkblue').click(function() {
    $('#txtBlueIn').attr('disabled', !this.checked);
    $('#txtBlueOu').attr('disabled', !this.checked);
    $('#txtBluePr').attr('disabled', !this.checked);
    
});

//For PO
$('#chkblue0').click(function() {
    $('#txtBlueIn0').attr('disabled', !this.checked);
    $('#txtBlueOu0').attr('disabled', !this.checked);
    $('#txtBluePr0').attr('disabled', !this.checked);
    
});


$('#chkgreen').click(function() {
    $('#txtGreenin').attr('disabled', !this.checked);
    $('#txtGreenou').attr('disabled', !this.checked);
    $('#txtGreenPr').attr('disabled', !this.checked);
    
});

//For PO
$('#chkgreen0').click(function() {
    $('#txtGreenin0').attr('disabled', !this.checked);
    $('#txtGreenou0').attr('disabled', !this.checked);
    $('#txtGreenPr0').attr('disabled', !this.checked);
    
});

$('#chkRed').click(function() {
    $('#txtRedin').attr('disabled', !this.checked);
    $('#txtRedou').attr('disabled', !this.checked);
    $('#txtRedPr').attr('disabled', !this.checked);
    
});

//For PO
$('#chkRed0').click(function() {
    $('#txtRedin0').attr('disabled', !this.checked);
    $('#txtRedou0').attr('disabled', !this.checked);
    $('#txtRedPr0').attr('disabled', !this.checked);
    
});

$('#chkYellow').click(function() {
    $('#txtyellowin').attr('disabled', !this.checked);
    $('#txtyellowou').attr('disabled', !this.checked);
    $('#txtyellowPr').attr('disabled', !this.checked);
    
});

//For PO
$('#chkYellow0').click(function() {
    $('#txtyellowin0').attr('disabled', !this.checked);
    $('#txtyellowou0').attr('disabled', !this.checked);
    $('#txtyellowPr0').attr('disabled', !this.checked);
    
});

$('#chkLory').click(function() {
    $('#txtLoryin').attr('disabled', !this.checked);
    $('#txtLoryou').attr('disabled', !this.checked);
    $('#txtLoryPr').attr('disabled', !this.checked);
    });

    //For PO
    $('#chkLory0').click(function() {
    $('#txtLoryin0').attr('disabled', !this.checked);
    $('#txtLoryou0').attr('disabled', !this.checked);
    $('#txtLoryPr0').attr('disabled', !this.checked);
    });

$('#chkBeige').click(function() {
    $('#txtBeigein').attr('disabled', !this.checked);
    $('#txtBeigeou').attr('disabled', !this.checked);
    $('#txtBeigePr').attr('disabled', !this.checked);
    });

    //For PO
    $('#chkBeige0').click(function() {
    $('#txtBeigein0').attr('disabled', !this.checked);
    $('#txtBeigeou0').attr('disabled', !this.checked);
    $('#txtBeigePr0').attr('disabled', !this.checked);
    });

$('#chkPink').click(function() {
    $('#txtPinkin').attr('disabled', !this.checked);
    $('#txtPinkou').attr('disabled', !this.checked);
    $('#txtPinkPr').attr('disabled', !this.checked);
    });
    //For PO
   $('#chkPink0').click(function() {
    $('#txtPinkin0').attr('disabled', !this.checked);
    $('#txtPinkou0').attr('disabled', !this.checked);
    $('#txtPinkPr0').attr('disabled', !this.checked);
    });

$('#chkBgendy').click(function() {
    $('#txtbgendyin').attr('disabled', !this.checked);
    $('#txtbgendyou').attr('disabled', !this.checked);
    $('#txtbgendyPr').attr('disabled', !this.checked);
    });

    //For PO
    $('#chkBgendy0').click(function() {
    $('#txtbgendyin0').attr('disabled', !this.checked);
    $('#txtbgendyou0').attr('disabled', !this.checked);
    $('#txtbgendyPr0').attr('disabled', !this.checked);
    });

$('#chkBlack').click(function() {
    $('#Blackin').attr('disabled', !this.checked);
    $('#Blackou').attr('disabled', !this.checked);
    $('#BlackPr').attr('disabled', !this.checked);    
});

//For PO
$('#chkBlack0').click(function() {
    $('#Blackin0').attr('disabled', !this.checked);
    $('#Blackou0').attr('disabled', !this.checked);
    $('#BlackPr0').attr('disabled', !this.checked);    
});

$('#chkOrange').click(function() {
    $('#txtOrangein').attr('disabled', !this.checked);
    $('#txtOrangeou').attr('disabled', !this.checked);
    $('#txtOrangePr').attr('disabled', !this.checked);
       
});

//for PO
$('#chkOrange0').click(function() {
    $('#txtOrangein0').attr('disabled', !this.checked);
    $('#txtOrangeou0').attr('disabled', !this.checked);
    $('#txtOrangePr0').attr('disabled', !this.checked);
       
});

$('#chkLgrass').click(function() {
    $('#txtLgrassin').attr('disabled', !this.checked);
    $('#txtLgrassou').attr('disabled', !this.checked);
    $('#txtLgrassPr').attr('disabled', !this.checked);
       
});
//For PO
$('#chkLgrass0').click(function() {
    $('#txtLgrassin0').attr('disabled', !this.checked);
    $('#txtLgrassou0').attr('disabled', !this.checked);
    $('#txtLgrassPr0').attr('disabled', !this.checked);
       
});

//Ink Color

$('#chkgeranium').click(function() {
    $('#txtgeraniumin').attr('disabled', !this.checked);
    $('#txtgeraniumou').attr('disabled', !this.checked);
    $('#txtgeraniumPr').attr('disabled', !this.checked);
       
});

//For PO

$('#chkgeranium0').click(function() {
    $('#txtgeraniumin0').attr('disabled', !this.checked);
    $('#txtgeraniumou0').attr('disabled', !this.checked);
    $('#txtgeraniumPr0').attr('disabled', !this.checked);
       
});

$('#chkinkyellow').click(function() {
    $('#txtlyellowin').attr('disabled', !this.checked);
    $('#txtlyellowou').attr('disabled', !this.checked);
    $('#txtlyellowPr').attr('disabled', !this.checked);       
});

//For PO
$('#chkinkyellow0').click(function() {
    $('#txtlyellowin0').attr('disabled', !this.checked);
    $('#txtlyellowou0').attr('disabled', !this.checked);
    $('#txtlyellowPr0').attr('disabled', !this.checked);       
});

$('#chkInkmYellow').click(function() {
    $('#txtmyellowin').attr('disabled', !this.checked);
    $('#txtmyellowou').attr('disabled', !this.checked);
    $('#txtmyellowPr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkmYellow0').click(function() {
    $('#txtmyellowin0').attr('disabled', !this.checked);
    $('#txtmyellowou0').attr('disabled', !this.checked);
    $('#txtmyellowPr0').attr('disabled', !this.checked);
       
});

$('#chkinkrblue').click(function() {
    $('#txtRBluein').attr('disabled', !this.checked);
    $('#txtRBlueou').attr('disabled', !this.checked);
    $('#txtRBluePr').attr('disabled', !this.checked);
       
});
//for PO
$('#chkinkrblue0').click(function() {
    $('#txtRBluein0').attr('disabled', !this.checked);
    $('#txtRBlueou0').attr('disabled', !this.checked);
    $('#txtRBluePr0').attr('disabled', !this.checked);
       
});

$('#chkInkblue').click(function() {
    $('#txtInkBluein').attr('disabled', !this.checked);
    $('#txtInkBlueou').attr('disabled', !this.checked);
    $('#txtInkBluePr').attr('disabled', !this.checked);
       
});
//For PO
$('#chkInkblue0').click(function() {
    $('#txtInkBluein0').attr('disabled', !this.checked);
    $('#txtInkBlueou0').attr('disabled', !this.checked);
    $('#txtInkBluePr0').attr('disabled', !this.checked);
       
});

$('#chkinkmdorange').click(function() {
    $('#txtmdorangein').attr('disabled', !this.checked);
    $('#txtmdorangeou').attr('disabled', !this.checked);
    $('#txtmdorangePr').attr('disabled', !this.checked);
       
});

//For PO

$('#chkinkmdorange0').click(function() {
    $('#txtmdorangein0').attr('disabled', !this.checked);
    $('#txtmdorangeou0').attr('disabled', !this.checked);
    $('#txtmdorangePr0').attr('disabled', !this.checked);
       
});

$('#chkinkgreen').click(function() {
    $('#txtInkgreenin').attr('disabled', !this.checked);
    $('#txtInkgreenou').attr('disabled', !this.checked);
    $('#txtInkgreenPr').attr('disabled', !this.checked);
       
});

//For PO

$('#chkinkgreen0').click(function() {
    $('#txtInkgreenin0').attr('disabled', !this.checked);
    $('#txtInkgreenou0').attr('disabled', !this.checked);
    $('#txtInkgreenPr0').attr('disabled', !this.checked);
       
});

$('#chkInkgrassgreen').click(function() {
    $('#txtInkggreenin').attr('disabled', !this.checked);
    $('#txtInkggreenou').attr('disabled', !this.checked);
    $('#txtInkggreenPr').attr('disabled', !this.checked);
       
});

//For PO

$('#chkInkgrassgreen0').click(function() {
    $('#txtInkggreenin0').attr('disabled', !this.checked);
    $('#txtInkggreenou0').attr('disabled', !this.checked);
    $('#txtInkggreenPr0').attr('disabled', !this.checked);
       
});

$('#chkInkPBlue').click(function() {
    $('#txtInkpbluein').attr('disabled', !this.checked);
    $('#txtInkpblueou').attr('disabled', !this.checked);
    $('#txtInkpbluePr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkPBlue0').click(function() {
    $('#txtInkpbluein0').attr('disabled', !this.checked);
    $('#txtInkpblueou0').attr('disabled', !this.checked);
    $('#txtInkpbluePr0').attr('disabled', !this.checked);
       
});


$('#chkInkBlack').click(function() {
    $('#txtInkBlackin').attr('disabled', !this.checked);
    $('#txtInkBlackou').attr('disabled', !this.checked);
    $('#txtInkBlackPr').attr('disabled', !this.checked);
       
});

// For PO
$('#chkInkBlack0').click(function() {
    $('#txtInkBlackin0').attr('disabled', !this.checked);
    $('#txtInkBlackou0').attr('disabled', !this.checked);
    $('#txtInkBlackPr0').attr('disabled', !this.checked);
       
});

$('#chkInkAMRed').click(function() {
    $('#txtAMRedin').attr('disabled', !this.checked);
    $('#txtAMRedou').attr('disabled', !this.checked);
    $('#txtAMRedPr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkAMRed0').click(function() {
    $('#txtAMRedin0').attr('disabled', !this.checked);
    $('#txtAMRedou0').attr('disabled', !this.checked);
    $('#txtAMRedPr0').attr('disabled', !this.checked);
       
});

$('#chkInkrfbluec').click(function() {
    $('#txtRFBluein').attr('disabled', !this.checked);
    $('#txtRFBlueou').attr('disabled', !this.checked);
    $('#txtRFBluePr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkrfbluec0').click(function() {
    $('#txtRFBluein0').attr('disabled', !this.checked);
    $('#txtRFBlueou0').attr('disabled', !this.checked);
    $('#txtRFBluePr0').attr('disabled', !this.checked);
       
});

$('#chkInkWhite').click(function() {
    $('#txtInkWhitein').attr('disabled', !this.checked);
    $('#txtInkWhiteou').attr('disabled', !this.checked);
    $('#txtInkWhitePr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkWhite0').click(function() {
    $('#txtInkWhitein0').attr('disabled', !this.checked);
    $('#txtInkWhiteou0').attr('disabled', !this.checked);
    $('#txtInkWhitePr0').attr('disabled', !this.checked);
       
});

$('#chkInkSilver').click(function() {
    $('#txtInkSilverin').attr('disabled', !this.checked);
    $('#txtInkSilverou').attr('disabled', !this.checked);
    $('#txtInkSilverPr').attr('disabled', !this.checked);
       
});

//For PO
$('#chkInkSilver0').click(function() {
    $('#txtInkSilverin0').attr('disabled', !this.checked);
    $('#txtInkSilverou0').attr('disabled', !this.checked);
    $('#txtInkSilverPr0').attr('disabled', !this.checked);
       
});

$('#chkEntiSlip').click(function() {
    $('#EntiSlipin').attr('disabled', !this.checked);
    $('#EntiSlipout').attr('disabled', !this.checked);
    $('#EntiSlippr').attr('disabled', !this.checked);
       
});

// For PO
$('#chkEntiSlip0').click(function() {
    $('#EntiSlipin0').attr('disabled', !this.checked);
    $('#EntiSlipout0').attr('disabled', !this.checked);
    $('#EntiSlippr0').attr('disabled', !this.checked);
       
});
        $('#ddlQuotationCode').change(function () { LoadAlllist(); });
//       $('#ddlProductSelect').change(function () { LoadAlllistProduct(); });
        $('#ddlQuotationCode').change(function () { LoadQuotationInfoQuotatioCode(); });
        $('#ddlProductSelect').change(function () { LoadProductInformation(); });        
        $('#ddlCustomerName').change(function () { LoadCustomerInfoCreateQuotatio(); });
        $('#ddlQuotationCode').change(function () { LoadCustomerInfoinSalesContract(); });
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
    $("#dvTabBody").tabs();

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

    //For Po........................................................

    $(".float_only1").keydown(function (event) {
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

    $(".raw_mat_prcntge1").blur(function () {
        var lcl_flt_RawMaterialPrice = 0; //will be assigned in each phase of calculation
        var lcl_flt_TotalPercentage = 0.0;
        var lcl_flt_InputValue = 0.0;

        var lcl_str_Value = $.trim($(this).val());

        if (lcl_str_Value == '') {
            return false;
        }
        lcl_flt_InputValue = parseFloat(lcl_str_Value);
        var lcl_flt_TotalPercentage = 0.0;
        $(".raw_mat_prcntge1").each(function (index, element1) {
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

        if (lcl_str_ControlId == "txtHDPE_NPQ_Percentage0") {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price

            var lcl_str_HDPEStandardPrice = $("#txtHDPE_NPQ_Standard_Price0").val();

            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtHDPE_NPQ_Price0").val(lcl_flt_HDPEPrice);
            $("#txtHDPE_NPQ_Price0").formatCurrency();
            // alert(lcl_str_ControlId);
        }

        if (lcl_str_ControlId == "txtLLDPE_NPQ_Percentage0") {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_LLDPEStandardPrice = $("#txtLLDPE_NPQ_Standard_Price0").val();
            var lcl_flt_LLDPEStandardPrice = parseFloat(lcl_str_LLDPEStandardPrice);
            var lcl_flt_LLDPEPrice = parseFloat((lcl_flt_LLDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_LLDPEPrice;
            $("#txtLLDPE_NPQ_Price0").val(lcl_flt_LLDPEPrice);
            $("#txtLLDPE_NPQ_Price0").formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == "txtPunchOut_NPQ_Percentage2") {

            var lcl_str_HDPEStandardPrice = $("#txtPunchOut_NPQ_Standard_Price0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            //alert(lcl_flt_RawMaterialPrice);
            $("#txtPunchOut_NPQ_Price2").val(lcl_flt_HDPEPrice);
            $('#txtPunchOut_NPQ_Price2').formatCurrency();
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
        
        if (lcl_str_ControlId == 'TextBox50') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#TextBox52").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#TextBox51").val(lcl_flt_HDPEPrice);
            $('#TextBox51').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

         if (lcl_str_ControlId == 'txt_coco3') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txt_coco5").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txt_coco4").val(lcl_flt_HDPEPrice);
            $('#txt_coco4').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtMWIn0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtMWPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtMWOu0").val(lcl_flt_HDPEPrice);
            $('#txtMWOu0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }
        
        if (lcl_str_ControlId == 'txtBlueIn0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtBluePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtBlueOu0").val(lcl_flt_HDPEPrice);
            $('#txtBlueOu0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

            if (lcl_str_ControlId == 'txtGreenin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtGreenPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtGreenou0").val(lcl_flt_HDPEPrice);
            $('#txtGreenou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtRedin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRedPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRedou0").val(lcl_flt_HDPEPrice);
            $('#txtRedou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }


        if (lcl_str_ControlId == 'txtyellowin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtyellowPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtyellowou0").val(lcl_flt_HDPEPrice);
            $('#txtyellowou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }



        if (lcl_str_ControlId == 'txtLoryin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtLoryPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtLoryou0").val(lcl_flt_HDPEPrice);
            $('#txtLoryou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtBeigein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtBeigePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtBeigeou0").val(lcl_flt_HDPEPrice);
            $('#txtBeigeou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtPinkin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtPinkPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtPinkou0").val(lcl_flt_HDPEPrice);
            $('#txtPinkou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }


        if (lcl_str_ControlId == 'txtbgendyin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtbgendyPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtbgendyou0").val(lcl_flt_HDPEPrice);
            $('#txtbgendyou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        
        if (lcl_str_ControlId == 'Blackin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#BlackPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#Blackou0").val(lcl_flt_HDPEPrice);
            $('#Blackou0').formatCurrency();
            //alert(lcl_str_ControlId);
            //return false;
        }

        if (lcl_str_ControlId == 'txtOrangein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtOrangePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtOrangeou1").val(lcl_flt_HDPEPrice);
            $('#txtOrangeou1').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtgeraniumin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtgeraniumPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtgeraniumou0").val(lcl_flt_HDPEPrice);
            $('#txtgeraniumou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtlyellowin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtlyellowPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtlyellowou0").val(lcl_flt_HDPEPrice);
            $('#txtlyellowou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

          if (lcl_str_ControlId == 'txtmyellowin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtmyellowPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtmyellowou0").val(lcl_flt_HDPEPrice);
            $('#txtmyellowou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }


        if (lcl_str_ControlId == 'txtRBluein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRBluePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRBlueou0").val(lcl_flt_HDPEPrice);
            $('#txtRBlueou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

          if (lcl_str_ControlId == 'txtInkBluein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkBluePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkBlueou0").val(lcl_flt_HDPEPrice);
            $('#txtInkBlueou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtmdorangein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtmdorangePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtmdorangeou0").val(lcl_flt_HDPEPrice);
            $('#txtmdorangeou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkgreenin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkgreenPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkgreenou0").val(lcl_flt_HDPEPrice);
            $('#txtInkgreenou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkggreenin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkggreenPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkggreenou0").val(lcl_flt_HDPEPrice);
            $('#txtInkggreenou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkpbluein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkpbluePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkpblueou0").val(lcl_flt_HDPEPrice);
            $('#txtInkpblueou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

       
        if (lcl_str_ControlId == 'txtInkBlackin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkBlackPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkBlackou0").val(lcl_flt_HDPEPrice);
            $('#txtInkBlackou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtAMRedin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtAMRedPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtAMRedou0").val(lcl_flt_HDPEPrice);
            $('#txtAMRedou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }
        if (lcl_str_ControlId == 'txtRFBluein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtRFBluePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtRFBlueou0").val(lcl_flt_HDPEPrice);
            $('#txtRFBlueou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkWhitein0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkWhitePr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkWhiteou0").val(lcl_flt_HDPEPrice);
            $('#txtInkWhiteou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtInkSilverin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtInkSilverPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtInkSilverou0").val(lcl_flt_HDPEPrice);
            $('#txtInkSilverou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }
        
        if (lcl_str_ControlId == 'EntiSlipin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#EntiSlippr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#EntiSlipout0").val(lcl_flt_HDPEPrice);
            $('#EntiSlipout0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtLgrassin0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtLgrassPr0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtLgrassou0").val(lcl_flt_HDPEPrice);
            $('#txtLgrassou0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'TextBox79') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#TextBox81").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#TextBox80").val(lcl_flt_HDPEPrice);
            $('#TextBox80').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        if (lcl_str_ControlId == 'txtD2W_NPQ_Percentage0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtD2W_NPQ_StandardPrice0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtD2W_NPQ_Price0").val(lcl_flt_HDPEPrice);
            $('#txtD2W_NPQ_Price0').formatCurrency();
            //alert(txtOrangeou);
            //return false;
        }

        
        if (lcl_str_ControlId == 'txtEPI_NPQ_Percentage0') {
            //txtHDPE_NPQ_Price
            //txtHDPE_NPQ_Standard_Price
            var lcl_str_HDPEStandardPrice = $("#txtEPI_NPQ_Standard_Price0").val();
            var lcl_flt_HDPEStandardPrice = parseFloat(lcl_str_HDPEStandardPrice);
            var lcl_flt_HDPEPrice = parseFloat((lcl_flt_HDPEStandardPrice * lcl_flt_InputValue) / 100);
            lcl_flt_RawMaterialPrice = lcl_flt_HDPEPrice;
            $("#txtEPI_NPQ_Price0").val(lcl_flt_HDPEPrice);
            $('#txtEPI_NPQ_Price0').formatCurrency();
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
        $("#txtRawMaterialPrice1").val(lcl_flt_TotalPrice.toString());
        $("#txtRawMaterialPrice1").formatCurrency();
    });

    $('.number').keypress(function (event) {
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();
        }
    });
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


///for PO

function CalculateNetWeightPO() {

                 var lcl_str_Width = $.trim($("#txtWidth1").val());
                 var lcl_str_Length = $.trim($("#txtLength1").val());
                 var lcl_str_Gusset = $.trim($("#txtGusset1").val());
                 var lcl_str_Density = $.trim($("#txtDensity1").val());
                 var lcl_str_Thickness = $.trim($("#txtThickness1").val());
                 var lcl_str_CutOut = $.trim($("#Cutout1").val());

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
    $("#txtNetWeight1").val(lcl_flt_NetWeight.toFixed(4));
    }

else {
        var lcl_flt_NetWeight = (((lcl_flt_Width + lcl_flt_Gusset) * lcl_flt_Length * lcl_flt_Density * lcl_flt_Thickness) / 1000);
    }
    
    $("#txtNetWeight1").val(lcl_flt_NetWeight.toFixed(4));
    
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

//For PO

function CalculateTotalPricePO() {
debugger;
                         var lcl_str_txtRawMaterialPrice = $.trim($('#txtRawMaterialPrice1').val());
                         var lcl_str_txtQuantity = $.trim($("#txtQuantity1").val());
                         var lcl_str_Processingcost = $.trim($("#Processingcost1").val());
                         var lcl_str_printingCharge = $.trim($("#printingCharge1").val());
                         var lcl_str_Freightcost = $.trim($("#Freightcost1").val());
                         var lcl_str_insurance = $.trim($("#insurance1").val());
                         var lcl_str_weight = $.trim($("#txtNetWeight1").val());
                         var lcl_str_Kgs = $.trim($("#Kgs1").val());
                         var lcl_str_Cylinder = $.trim($("#Cylinder1").val());
                         var lcl_str_Height = $.trim($("#Height0").val());
                         var lcl_str_Length =$.trim($("#Length0").val());
                         var lcl_str_Width = $.trim($("#Width0").val());
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

    var lcl_str_Quantityforcarton  = $.trim($("#txtQuantity1").val());
    var lcl_flt_Quantityforcarton=parseFloat(lcl_str_Quantityforcarton);
    var lcl_str_totalpcspercarton  = $.trim($("#totalpcspercarton1").val());
    var lcl_flt_totalpcspercarton=parseFloat(lcl_str_totalpcspercarton);
    var lcl_flt_Cylinder=parseFloat(lcl_str_Cylinder);

                             //Carton Calculation
                             if (lcl_str_totalpcspercarton=='0')
                             {
                             $("#Carton1").val('0');
                             $("#CBM0").val('0');
                             }
                             else
                             {
                             var lcl_str_Carton =  lcl_flt_Quantityforcarton/lcl_flt_totalpcspercarton;
                             $("#Carton1").val(lcl_str_Carton);
                             var lcl_flt_Cartoon=parseFloat(lcl_str_Carton);
                             var lcl_str_CBM= (lcl_flt_Height*lcl_flt_Length*lcl_flt_Width/1000000)*lcl_flt_Cartoon;
                             $("#CBM0").val(lcl_str_CBM);
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
                             $("#txtRawMaterialPrice1").val(lcl_flt_txtRawMaterialPrice.toFixed(4));
                              $("#Processingcost1").val(lcl_flt_Processingcost);
                             $("#Processingcost1").val(lcl_flt_Processingcost.toFixed(4));
                           //  $("#Processingcost").formatCurrency();
                             
                             $("#Freightcost1").val(lcl_flt_Freightcost.toFixed(4));
                             //$("#Freightcost").formatCurrency();
                             $("#printingCharge1").val(lcl_flt_printingCharge.toFixed(4));
                             //$("#printingCharge").formatCurrency();
                             $("#txtNetWeight1").val(lcl_flt_weight.toFixed(4));
                             $("#Kgs1").val(lcl_flt_insurance.toFixed(4));
                             var lcl_flt_Fob =  lcl_flt_weight*((lcl_flt_txtRawMaterialPrice + lcl_flt_Processingcost + lcl_flt_printingCharge + lcl_flt_Freightcost)/1000);
                             
                             $("#txt_FobPrice1").val(lcl_flt_Fob.toFixed(2));
                             lcl_str_Kgs = (lcl_flt_weight * lcl_flt_txtQuantity) / 1000;
                             $("#Kgs1").val(lcl_str_Kgs);
                             $("#Kgs1").val(lcl_str_Kgs.toFixed(4));
                             var lcl_str_fo = $("#txt_FobPrice1").val();
                             var lcl_flt_fo = parseFloat(lcl_str_fo);
                             lcl_flt_fo.toFixed(2);
                            if (lcl_flt_Cylinder=='0')
                            {
                            var lcl_flt_TotalPrice = (lcl_flt_txtQuantity*lcl_flt_fo)/1000;
                            $("#txt_totalPrice1").val(lcl_flt_TotalPrice);
                             //$("#txt_totalPrice").formatCurrency();
                            }
                            else
                            {
                             var lcl_flt_TotalPrice = (lcl_flt_txtQuantity*lcl_flt_fo)/1000;
                             var lcl_flt_withCylinder= lcl_flt_TotalPrice+lcl_flt_Cylinder;
                            $("#txt_totalPrice1").val(lcl_flt_withCylinder);
                            // $("#txt_totalPrice").formatCurrency();
                            }

                            if (lcl_flt_Freightcost=='0')
                             {
                             $("#insurance1").val('0.00');
                             }

                             else
                             {
                             var lcl_flt_insurance = (lcl_flt_Fob * 0.59);


                             $("#insurance1").val(lcl_flt_insurance);
                             $("#insurance1").val(lcl_flt_insurance.toFixed(2));
                             
                             //$("#insurance").formatCurrency();
                             }
                             
                             $("#txt_FobPrice1").val(lcl_flt_Fob.toFixed(2));
                             //$("#txt_FobPrice").formatCurrency();
                             //$("#txtRawMaterialPrice").formatCurrency();
                             
           debugger;                
}


function CustomerSave() {

        var lcl_obj_Buyer = new Object();
        // debugger;
        lcl_obj_Buyer.CompanyName = $("#txtCompany_NC").val();
        lcl_obj_Buyer.Address = $("#txtAddress_NC").val();
        lcl_obj_Buyer.Phone = $("#txtPhone_NC").val();
        lcl_obj_Buyer.ContactPerson = $("#txtContactPerson_NC").val();
        lcl_obj_Buyer.Email = $("#Email").val();
        lcl_obj_Buyer.Country = $("#Country").val();
        if (lcl_obj_Buyer.CompanyName == '') {
        DisplayError("Please Fill Up The Field 'Country Name'!!!");
        return;
    }
        if (lcl_obj_Buyer.CompanyName == '') {
        DisplayError("Please Fill Up The Field 'Company Name'!!!");
        return;
    }

//    if (lcl_obj_Buyer.Address == '') {
//        DisplayError("Please Fill Up The Field 'Address'!!!");
//        return;
//    }

//    if (lcl_obj_Buyer.Phone == '') {
//        DisplayError("Please Fill Up The Field 'Phone'!!!");
//        return;
//    }
//    if (lcl_obj_Buyer.ContactPerson == '') {
//        DisplayError("Please Fill Up The Field 'ContactPerson'!!!");
//        return;
//    }

//    if (lcl_obj_Buyer.Email == '') {
//        DisplayError("Please Fill Up The Field 'Email'!!!");
//        return;
//    }

    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        if (lcl_b_InputValidated == true) {
    
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "../../../WebServices/WPMS/ItemsService.asmx/CustomerSave", /// <reference path="" />

                        data: "{IP_obj_Buyer:" + JSON.stringify(lcl_obj_Buyer) + "}", 
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
        }
    }
    return false;
   
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
                   
                   debugger;
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

//For PO

function AllclearPO() {

                   document.getElementById("txt_ProductRef1").value                  = '';
                   document.getElementById("txt_ProductDec1").value                  = '';
                   document.getElementById("txtQuantity1").value                     = "";
                   document.getElementById("txtWidth1").value                        = "0";
                   document.getElementById("txtLength1").value                       = '0';
                   document.getElementById("txtGusset1").value                       = '0';
                   document.getElementById("txtDensity1").value                      = '0';
                   document.getElementById("txtThickness1").value                    = '0';
                   document.getElementById("Cutout1").value                          = '0';
                   document.getElementById("txtNetWeight1").value                    = '0';
                   document.getElementById("txtRawMaterialPrice1").value             = '$0';
                   document.getElementById("Processingcost1").value                  = '0';
                   document.getElementById("printingCharge1").value                  = '0';
                   document.getElementById("Freightcost1").value                     = '0';
                   document.getElementById("insurance1").value                       = '0';
                   document.getElementById("txt_FobPrice1").value                    = '0';
                   document.getElementById("txt_totalPrice1").value                  = '0';
                   document.getElementById("Carton1").value                          = '';
                   document.getElementById("Kgs1").value                             = '0';                  
                   document.getElementById("txtHDPE_NPQ_Percentage0").value          = '';
                   document.getElementById("txtLLDPE_NPQ_Percentage0").value         = '';
                   document.getElementById("txtPunchOut_NPQ_Percentage2").value      = '';                                 
                   document.getElementById("txtMWIn0").value               = '';
                   document.getElementById("txtMWOu0").value              = '';
                   document.getElementById("txtBlueIn0").value           = '';                 
                   document.getElementById("txtBlueOu0").value           = '';
                   document.getElementById("txtGreenin0").value           = '';
                   document.getElementById("txtGreenou0").value                = '';
                   document.getElementById("txtRedin0").value                = '';
                   document.getElementById("txtRedou0").value         = '';
                   document.getElementById("txtyellowin0").value    = '';
                   document.getElementById("txtyellowou0").value           = '';
                   document.getElementById("txtLoryin0").value           = '';
                   document.getElementById("txtLoryou0").value                = '';
                   document.getElementById("txtBeigein0").value                = '';
                   document.getElementById("txtBeigeou0").value               = '';
                   document.getElementById("txtPinkin0").value              = '';
                   document.getElementById("txtPinkou0").value           = '';
                   document.getElementById("txtbgendyin0").value    = '';
                   document.getElementById("txtbgendyou0").value           = '';           
                   document.getElementById("Blackin0").value                = '';
                   document.getElementById("Blackou0").value               = '';
                   document.getElementById("txtOrangein0").value              = '';
                   document.getElementById("txtOrangeou0").value           = '';                 
                   document.getElementById("txtD2W_NPQ_Percentage0").value           = '';
                   document.getElementById("txtEPI_NPQ_Percentage0").value           = '';
                   document.getElementById("txtD2W_NPQ_Price0").value                = '';
                   document.getElementById("txtEPI_NPQ_Price0").value                = '';
                   document.getElementById("TextBox50").value         = '';
                   document.getElementById("TextBox51").value    = '';
                   document.getElementById("txt_coco3").value           = '';
                   document.getElementById("txt_coco4").value           = '';
                   document.getElementById("txtPunchOut_NPQ_Percentage2").value                = '';
                   document.getElementById("txtPunchOut_NPQ_Price2").value                = '';        
                   document.getElementById("txtHDPE_NPQ_Price0").value           = '';
                   document.getElementById("txtLLDPE_NPQ_Price0").value                = '';
                   document.getElementById("txtPunchOut_NPQ_Price2").value                = ''; 
                   document.getElementById("TextBox79").value                = '';
                   document.getElementById("TextBox80").value                = '';               
                   document.getElementById("txtgeraniumou0").value           = '';
                   document.getElementById("txtgeraniumin0").value           = '';
                   document.getElementById("txtlyellowou0").value                = '';
                   document.getElementById("txtlyellowin0").value                = '';
                   document.getElementById("txtmyellowou0").value         = '';
                   document.getElementById("txtmyellowin0").value    = '';
                   document.getElementById("txtRBlueou0").value              = '';
                   document.getElementById("txtRBluein0").value           = '';                 
                   document.getElementById("txtInkBlueou0").value           = '';
                   document.getElementById("txtInkBluein0").value           = '';
                   document.getElementById("txtmdorangeou0").value                = '';
                   document.getElementById("txtmdorangein0").value                = '';
                   document.getElementById("txtInkgreenou0").value         = '';
                   document.getElementById("txtInkgreenin0").value    = '';
                   document.getElementById("txtInkggreenou0").value              = '';
                   document.getElementById("txtInkggreenin0").value           = '';                 
                   document.getElementById("txtInkpblueou0").value           = '';
                   document.getElementById("txtInkpbluein0").value           = '';             
                   document.getElementById("txtInkBlackou0").value         = '';
                   document.getElementById("txtInkBlackin0").value    = '';
                   document.getElementById("txtAMRedou0").value           = '';
                   document.getElementById("txtAMRedin0").value           = '';
                   document.getElementById("txtRFBlueou0").value                = '';
                   document.getElementById("txtRFBluein0").value                = '';                   
                   document.getElementById("txtInkWhiteou0").value           = '';
                   document.getElementById("txtInkWhitein0").value           = '';
                   document.getElementById("txtInkSilverou0").value                = '';
                   document.getElementById("txtInkSilverin0").value                = '';
                   document.getElementById("EntiSlipin0").value                = '';
                   document.getElementById("EntiSlipout0").value                = '';
                   document.getElementById("txtLgrassin0").value                = '';
                   document.getElementById("txtLgrassou0").value                = '';
                   document.getElementById("txtOrangeou1").value                = '';
                   debugger;
    $('#HDPE0').attr('checked', false);
    $('#txtHDPE_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtHDPE_NPQ_Standard_Price0').attr('disabled', !this.checked);     
    $('#RecycleOut0').attr('checked', false);
    $('#txtPunchOut_NPQ_Percentage3').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Percentage3').attr('disabled', !this.checked);
    $('#TextBox53').attr('disabled', !this.checked);    
    $('#LDPE0').attr('checked', false);
    $('#TextBox50').attr('disabled', !this.checked);
    $('#TextBox51').attr('disabled', !this.checked);
    $('#TextBox52').attr('disabled', !this.checked);
   $('#LLDPE0').attr('checked', false);
    $('#txtLLDPE_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtLLDPE_NPQ_Standard_Price0').attr('disabled', !this.checked);    
   $('#PunchOut0').attr('checked', false);
    $('#txtPunchOut_NPQ_Percentage2').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Price2').attr('disabled', !this.checked);
    $('#txtPunchOut_NPQ_Standard_Price0').attr('disabled', !this.checked);
   $('#MasterBase0').attr('checked', false);        
    $('#chkwhite0').attr('checked', false);
    $('#chkblue0').attr('checked', false);
    $('#chkgreen0').attr('checked', false);
    $('#chkRed0').attr('checked', false);
    $('#chkYellow0').attr('checked', false);
    $('#chkLory0').attr('checked', false);
    $('#chkBeige0').attr('checked', false);
    $('#chkPink0').attr('checked', false);
    $('#chkBgendy0').attr('checked', false);

    $('#chkBlack0').attr('checked', false);
    $('#chkOrange0').attr('checked', false);  
    $('#txtMWIn0').attr('disabled', !this.checked);
    $('#txtMWOu0').attr('disabled', !this.checked);  
    $('#txtBlueIn0').attr('disabled', !this.checked);
    $('#txtBlueOu0').attr('disabled', !this.checked);   
    $('#txtGreenin0').attr('disabled', !this.checked);
    $('#txtGreenou0').attr('disabled', !this.checked);   
    $('#txtRedin0').attr('disabled', !this.checked);
    $('#txtRedou0').attr('disabled', !this.checked);  
    $('#txtyellowin0').attr('disabled', !this.checked);
    $('#txtyellowou0').attr('disabled', !this.checked);
    $('#txtLoryin0').attr('disabled', !this.checked);
    $('#txtLoryou0').attr('disabled', !this.checked);   
    $('#txtBeigein0').attr('disabled', !this.checked);
    $('#txtBeigeou0').attr('disabled', !this.checked);    
    $('#txtPinkin0').attr('disabled', !this.checked);
    $('#txtPinkou0').attr('disabled', !this.checked);    
    $('#txtbgendyin0').attr('disabled', !this.checked);
    $('#txtbgendyou0').attr('disabled', !this.checked);    

    $('#Blackin0').attr('disabled', !this.checked);
    $('#Blackou0').attr('disabled', !this.checked);
    
    $('#txtOrangein0').attr('disabled', !this.checked);
    $('#txtOrangeou0').attr('disabled', !this.checked);
    $('#checkMasterbatch0').hide();
    
   $('#D2W0').attr('checked', false);
    $('#txtD2W_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtD2W_NPQ_StandardPrice0').attr('disabled', !this.checked);

   $('#EPI0').attr('checked', false);
    $('#txtEPI_NPQ_Percentage0').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Price0').attr('disabled', !this.checked);
    $('#txtEPI_NPQ_Standard_Price0').attr('disabled', !this.checked);


  $('#Thinner0').attr('checked', false);
    $('#TextBox79').attr('disabled', !this.checked);
    $('#TextBox80').attr('disabled', !this.checked);
    $('#TextBox81').attr('disabled', !this.checked);


$('#chkInk0').attr('checked', false);
    $('#chkInkOpen0').hide();

$('#COCO0').attr('checked', false);
    $('#txt_coco3').attr('disabled', !this.checked);
    $('#txt_coco4').attr('disabled', !this.checked);
    $('#txt_coco5').attr('disabled', !this.checked);

$('#chkwhite0').attr('checked', false);
    $('#txtMWIn0').attr('disabled', !this.checked);
    $('#txtMWOu0').attr('disabled', !this.checked);
    $('#txtMWPr0').attr('disabled', !this.checked);

$('#chkgeranium0').attr('checked', false);
    $('#txtgeraniumin0').attr('disabled', !this.checked);
    $('#txtgeraniumou0').attr('disabled', !this.checked);
    $('#txtgeraniumPr0').attr('disabled', !this.checked);

$('#chkinkyellow0').attr('checked', false);
    $('#txtlyellowou0').attr('disabled', !this.checked);
    $('#txtlyellowPr0').attr('disabled', !this.checked);
    $('#txtlyellowin0').attr('disabled', !this.checked);

$('#chkInkmYellow0').attr('checked', false);
    $('#txtmyellowin0').attr('disabled', !this.checked);
    $('#txtmyellowou0').attr('disabled', !this.checked);
    $('#txtmyellowPr0').attr('disabled', !this.checked);

$('#chkinkrblue0').attr('checked', false);
    $('#txtRBluein0').attr('disabled', !this.checked);
    $('#txtRBlueou0').attr('disabled', !this.checked);
    $('#txtRBluePr0').attr('disabled', !this.checked);

$('#chkInkblue0').attr('checked', false);
    $('#txtInkBluein0').attr('disabled', !this.checked);
    $('#txtInkBlueou0').attr('disabled', !this.checked);
    $('#txtInkBluePr0').attr('disabled', !this.checked);

$('#chkinkmdorange0').attr('checked', false);
    $('#txtmdorangein0').attr('disabled', !this.checked);
    $('#txtmdorangeou0').attr('disabled', !this.checked);
    $('#txtmdorangePr0').attr('disabled', !this.checked);


$('#chkinkgreen0').attr('checked', false);
    $('#txtInkgreenin0').attr('disabled', !this.checked);
    $('#txtInkgreenou0').attr('disabled', !this.checked);
    $('#txtInkgreenPr0').attr('disabled', !this.checked);

$('#chkInkgrassgreen0').attr('checked', false);
    $('#txtInkggreenin0').attr('disabled', !this.checked);
    $('#txtInkggreenou0').attr('disabled', !this.checked);
    $('#txtInkggreenPr0').attr('disabled', !this.checked);

$('#chkInkPBlue0').attr('checked', false);
    $('#txtInkpbluein0').attr('disabled', !this.checked);
    $('#txtInkpblueou0').attr('disabled', !this.checked);
    $('#txtInkpbluePr0').attr('disabled', !this.checked);

$('#chkInkBlack0').attr('checked', false);
    $('#txtInkBlackin0').attr('disabled', !this.checked);
    $('#txtInkBlackou0').attr('disabled', !this.checked);
    $('#txtInkBlackPr0').attr('disabled', !this.checked);

$('#chkInkAMRed0').attr('checked', false);
    $('#txtAMRedin0').attr('disabled', !this.checked);
    $('#txtAMRedou0').attr('disabled', !this.checked);
    $('#txtAMRedPr0').attr('disabled', !this.checked);
    
$('#chkInkrfbluec0').attr('checked', false);
    $('#txtRFBluein0').attr('disabled', !this.checked);
    $('#txtRFBlueou0').attr('disabled', !this.checked);
    $('#txtRFBluePr0').attr('disabled', !this.checked);

$('#chkInkWhite0').attr('checked', false);
    $('#txtInkWhitein0').attr('disabled', !this.checked);
    $('#txtInkWhiteou0').attr('disabled', !this.checked);
    $('#txtInkWhitePr0').attr('disabled', !this.checked);

$('#chkInkSilver0').attr('checked', false);
    $('#txtInkSilverin0').attr('disabled', !this.checked);
    $('#txtInkSilverou0').attr('disabled', !this.checked);
    $('#txtInkSilverPr0').attr('disabled', !this.checked);

$('#chkEntiSlip0').attr('checked', false);
    $('#EntiSlipin0').attr('disabled', !this.checked);
    $('#EntiSlipout0').attr('disabled', !this.checked);
    $('#EntiSlippr0').attr('disabled', !this.checked);

    $('#chkLgrass0').attr('checked', false);
    $('#txtLgrassin0').attr('disabled', !this.checked);
    $('#txtLgrassou0').attr('disabled', !this.checked);
    $('#txtLgrassPr0').attr('disabled', !this.checked);

$('#HD0').attr('checked', false); 
     $('#txtDensity').val('0');
  
  $('#LD0').attr('checked', false); 
     $('#txtDensity').val('0');
                   
}
      



function LoadImage() {
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
        if (lcl_i32_FileSize / 1024 > 3000) {
            DisplayInformation("Image Size Cannot Exceed 30 KB!!!");
            return;
        }

        $("#txt_EI_ImageType").val(lcl_str_FileType);
        $("#txt_EI_ImageSize").val(parseInt((lcl_i32_FileSize / 1024).toString()).toString() + " KB");
        $("#txt_EI_ImageSize").data('img_size', lcl_i32_FileSize.toString()); //storing file size in bytes
        var fr = new FileReader();
        fr.onload = function (event) {
            document.getElementById("imgCustomerImage").setAttribute("src", event.target.result);
            //save the read image object in the fileBrowser Control.VERY IMPORTANT ISSUE
            $("#fileBrowser").data('emp_img_added', true); //indicates if image has been added.
            var lcl_str_Image = event.target.result.toString();
            var lcl_imageByte = lcl_str_Image.replace(/^data:image\/(png|jpg|gif|jpeg);base64,/, ''); //data:image/jpeg;base64,/
            $("#fileBrowser").data('emp_img', lcl_imageByte);
        }
        fr.readAsDataURL(file);
        //input.src = fr.result;
    }
}

function DeleteImage() {
    document.getElementById("imgCustomerImage").setAttribute("src", "");
    $("#txt_EI_ImageType").val('');
    $("#txt_EI_ImageSize").val('');
    $("#txt_EI_ImageSize").data('img_size', '0');
    document.getElementById('fileBrowser').value = '';
    $("#fileBrowser").data('emp_img', '');
    
}

function addImage() {
                 var lcl_str_fileBrowser             =   $.trim($("#fileBrowser").val());
                 var lcl_str_txt_EI_ImageType        =   $.trim($("#txt_EI_ImageType").val());
                 var lcl_str_txt_EI_ImageSize        =   $.trim($("#txt_EI_ImageSize").val());
                 var lcl_str_txt_Image               =   $.trim($("#imgCustomerImage").val());
                 var lcl_obj_ProductRef              =   document.getElementById("txt_ProductRef");
                 var lcl_str_ProductRef              =   $.trim($(lcl_obj_ProductRef).val().toString());

    if (lcl_str_fileBrowser == '') {
        DisplayError("Please Upload Your Image !!!");
        return;
    }

     $('#tblProductDetails').appendGrid('appendRow', [
        { Image: lcl_str_fileBrowser, ProductRef: lcl_str_ProductRef},
      
    ]);
}
           
        function addProduct() 

                   {

                   var lcl_obj_radionID              =          $('#radLstProductCatalog_NPQ input:checked').val();
  var lcl_obj_radion              =          $('#radLstProductCatalog_NPQ input:checked').val();
     if (lcl_obj_radion=='1010000001')
      {
     var val = 'T-Shirt Bag';
            lcl_obj_radion = val;  
        
        }

        if (lcl_obj_radion=='1010000002')
        {
        var val = 'Block Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000003')
      {
     var val = 'Knot Bag';
            lcl_obj_radion=val;;  
        
        }

        if (lcl_obj_radion=='1010000004')
        {
        var val = 'Die-Cut Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000005')
      {
     var val = 'Soft Loop Handle Bag';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000006')
        {
        var val = 'Garbage Bag on Roll';
            lcl_obj_radion=val;  
        
        }


         if (lcl_obj_radion=='1010000007')
      {
     var val = 'Flat Bag on Roll';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000008')
        {
        var val = 'T-Shirt Bag on Roll';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000009')
      {
     var val = 'Heat Seal Patch Handle Bag / Patch Handle Diecut Bag';
            lcl_obj_radion=val
        
        }

        if (lcl_obj_radion=='1010000010')
        {
        var val = 'Star Seal Bag on Roll with Core';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000011')
      {
     var val = 'Star Seal Bag on Roll without Core';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000012')
        {
        var val = 'Handgloves';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000013')
        {
        var val = 'Ice Bag';
            lcl_obj_radion=val;  
        
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

                         var lcl_obj_imgCustomerImage    =          document.getElementById("imgCustomerImage");
        
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
                         
                         var lcl_str_txt_Image           =          $.trim($(lcl_obj_imgCustomerImage).val());
                         var lcl_str_Weight              =          $.trim($(lcl_obj_Weight).val().toString());
                         var lcl_str_fileBrowser         =          $.trim($("#fileBrowser").val());
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
                       var lcl_i32_imageCount          =       parseInt(document.getElementById("ImageCount").value.toString());    
                       lcl_i32_imageCount++;
                       $('#tblProductDetails').appendGrid('appendRow', [
                       { Name:lcl_obj_radionID,ItemNo:lcl_str_ItemNo, ProductRef: lcl_str_ProductRef,ID:lcl_obj_radion,Desc: lcl_str_Append,size:lcl_str_txtWidth,Length:lcl_str_txtLength,Gusset:lcl_str_txtGusset,Density:lcl_str_txtDensity,Thickness:lcl_str_txtThickness,ppb:lcl_str_txtppb,bpc:lcl_str_txtbpc,Wgt1tp:lcl_str_Weight, Quantity:lcl_str_Quantity,Carton:lcl_str_Carton,PcsPerCarton:lcl_str_PcsPerCarton,CBM:lcl_str_CBM,KG:lcl_str_Kgs,UnitPrice:lcl_flt_FobPriceTotal,TotalPrice:lcl_strrpc_Pricedesc},
      
    ]);
 
}      

// For PO
function addProduct() 

                   {

                   var lcl_obj_radionID              =          $('#radLstProductCatalog_NPQ0 input:checked').val();
  var lcl_obj_radion              =          $('#radLstProductCatalog_NPQ0 input:checked').val();
     if (lcl_obj_radion=='1010000001')
      {
     var val = 'T-Shirt Bag';
            lcl_obj_radion = val;  
        
        }

        if (lcl_obj_radion=='1010000002')
        {
        var val = 'Block Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000003')
      {
     var val = 'Knot Bag';
            lcl_obj_radion=val;;  
        
        }

        if (lcl_obj_radion=='1010000004')
        {
        var val = 'Die-Cut Bag';
           lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000005')
      {
     var val = 'Soft Loop Handle Bag';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000006')
        {
        var val = 'Garbage Bag on Roll';
            lcl_obj_radion=val;  
        
        }


         if (lcl_obj_radion=='1010000007')
      {
     var val = 'Flat Bag on Roll';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000008')
        {
        var val = 'T-Shirt Bag on Roll';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000009')
      {
     var val = 'Heat Seal Patch Handle Bag / Patch Handle Diecut Bag';
            lcl_obj_radion=val
        
        }

        if (lcl_obj_radion=='1010000010')
        {
        var val = 'Star Seal Bag on Roll with Core';
            lcl_obj_radion=val;  
        
        }

         if (lcl_obj_radion=='1010000011')
      {
     var val = 'Star Seal Bag on Roll without Core';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000012')
        {
        var val = 'Handgloves';
            lcl_obj_radion=val;  
        
        }

        if (lcl_obj_radion=='1010000013')
        {
        var val = 'Ice Bag';
            lcl_obj_radion=val;  
        
        }                                     
                         var lcl_obj_ItemNo              =          document.getElementById("ItemNo0");        
                         var lcl_obj_ProductRef          =          document.getElementById("txt_ProductRef1");
                         var lcl_obj_ProductDec          =          document.getElementById("txt_ProductDec1");
                         var lcl_obj_Quantity            =          document.getElementById("txtQuantity1");
                         var lcl_obj_TotalPrice          =          document.getElementById("txt_totalPrice1");
                         var lcl_obj_FobPrice            =          document.getElementById("txt_FobPrice1");
                         var lcl_obj_txtWidth            =          document.getElementById("txtWidth1");
                         var lcl_obj_txtLength           =          document.getElementById("txtLength1");
                         var lcl_obj_txtGusset           =          document.getElementById("txtDensity1");
                         var lcl_obj_txtDensity          =          document.getElementById("txtDensity1");
                         var lcl_obj_txtThickness        =          document.getElementById("txtThickness1");
                         var lcl_obj_txtNetWeight        =          document.getElementById("txtNetWeight1");
                         var lcl_obj_Carton              =          document.getElementById("Carton1");
                         var lcl_obj_Kgs                 =          document.getElementById("Kgs1");
                         var lcl_obj_txtppb              =         document.getElementById("txtppb0");
                         var lcl_obj_txtbpc                 =       document.getElementById("txtbpc0");
                         var lcl_obj_imgCustomerImage    =          document.getElementById("imgCustomerImage");
                         var lcl_obj_Weight              =          document.getElementById("txtNetWeight1");
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
                         var lcl_str_txt_Image           =          $.trim($(lcl_obj_imgCustomerImage).val());
                         var lcl_str_Weight              =          $.trim($(lcl_obj_Weight).val().toString());
                         var lcl_str_fileBrowser         =          $.trim($("#fileBrowser").val());
                         var lcl_str_PcsPerCarton         =          $.trim($("#totalpcspercarton1").val());
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
                       var lcl_i32_imageCount          =       parseInt(document.getElementById("ImageCount").value.toString());    
                       lcl_i32_imageCount++;
                       $('#tblProductDetails1').appendGrid('appendRow', [
                       { Name:lcl_obj_radionID,ItemNo:lcl_str_ItemNo, ProductRef: lcl_str_ProductRef,ID:lcl_obj_radion,Desc: lcl_str_Append,size:lcl_str_txtWidth,Length:lcl_str_txtLength,Gusset:lcl_str_txtGusset,Density:lcl_str_txtDensity,Thickness:lcl_str_txtThickness,ppb:lcl_str_txtppb,bpc:lcl_str_txtbpc,Wgt1tp:lcl_str_Weight, Quantity:lcl_str_Quantity,Carton:lcl_str_Carton,PcsPerCarton:lcl_str_PcsPerCarton,CBM:lcl_str_CBM,KG:lcl_str_Kgs,UnitPrice:lcl_flt_FobPriceTotal,TotalPrice:lcl_strrpc_Pricedesc},
      
    ]);
 
}      
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
 
    
    //Sales Contract........................................................................................................................................................................
        
            function Save() {
    
             var lcl_obj_SalesContract = new Object();
             lcl_obj_SalesContract.QuotationCode         =       $("#ddlQuotationCode option:selected").val();
             lcl_obj_SalesContract.PortOfDelivery        =       $("#PortofDelivert").val();
             lcl_obj_SalesContract.AdvisingBank          =       $("#AdvisingBank").val();
             lcl_obj_SalesContract.LCValidity            =       $("#LcValidity").val();
             lcl_obj_SalesContract.TransHipment          =       $("#Transhipment").val();
             lcl_obj_SalesContract.HSCode                =       $("#HsCode").val();
             lcl_obj_SalesContract.BuyerCode             =       $("#txtsBuyerCode").val();
             lcl_obj_SalesContract.SalesContractDate     =       $("#lblTodayDate").val();
             lcl_obj_SalesContract.Packing               =       $("#PkgSpecification").val();
             lcl_obj_SalesContract.TermsOfPayments       =       $("#PaymensTerms").val();
             lcl_obj_SalesContract.Delivery              =       $("#DestinationCountry").val();
             lcl_obj_SalesContract.Description           =       $("#Description").val();
             lcl_obj_SalesContract.CountryOrigin         =       $("#LoadingCountry").val();
             lcl_obj_SalesContract.PortofDestination     =       $("#DestinationPort").val();     
             var lcl_i32_Count =  $('#tblProductDetails0').appendGrid('getRowCount');
   
           lcl_obj_SalesContract.SalesContractDetails = new Array();
        for (var j = 0; j < lcl_i32_Count; j++) 
        {
                    lcl_obj_SalesContract.SalesContractDetails[j]= new Object();
                    lcl_obj_SalesContract.SalesContractDetails[j].QuotationDetailsCode=   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Code', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ItemNo              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'ItemNo', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductRef          =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'ProductRef', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ItemCode            =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Name', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductDesc         =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Desc', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductSize         =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'size', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Length              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Length', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Gusset              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Gusset', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Density             =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Density', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Thickness           =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Thickness', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].PPB                 =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'ppb', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].BPC                 =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'bpc', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Quantity            =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Quantity', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Weight              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Wgt1tp', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Carton              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'Carton', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].PcsPerCarton        =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'PcsPerCarton', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].QtyPkg              =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'KG', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].UnitPriceCifFos     =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'UnitPrice', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].TotalAmountCifFos   =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'TotalPrice', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].CBM                 =   $('#tblProductDetails0').appendGrid('getCtrlValue', 'CBM', j);
debugger;
}               
if (lcl_obj_SalesContract.CustomerCode == '0') {
          
                DisplayError("Please Select The Field 'Company Name'!!!");
                return;
            }

            if (lcl_obj_SalesContract.SalesContratNo == '') {
                DisplayError("Please Fill Up The Field 'SalesContract'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PortOfDelivery == '') {
                DisplayError("Please Fill Up The Field 'PortOfDelivery'!!!");
                return;
            }

            if (lcl_obj_SalesContract.AdvisingBank == '') {
                DisplayError("Please Fill Up The Field 'AdvisingBank'!!!");
                return;
            }

            if (lcl_obj_SalesContract.LCValidity == '') {
                DisplayError("Please Fill Up The Field 'LCValidity'!!!");
                return;
            }

            if (lcl_obj_SalesContract.TransHipment == '') {
                DisplayError("Please Fill Up The Field 'TransHipment'!!!");
                return;
            }

            if (lcl_obj_SalesContract.HSCode == '') {
                DisplayError("Please Fill Up The Field 'HSCode'!!!");
                return;
            }

            if (lcl_obj_SalesContract.LoadingCountry == '') {
                DisplayError("Please Fill Up The Field 'LoadingCountry'!!!");
                return;
            }

            if (lcl_obj_SalesContract.DestinationPort == '') {
                DisplayError("Please Fill Up The Field 'DestinationPort'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PkgSpecification == '') {
                DisplayError("Please Fill Up The Field 'PkgSpecification'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PaymentsTerms == '') {
                DisplayError("Please Fill Up The Field 'PaymentsTerms'!!!");
                return;
            } 
                        
             if (confirm("Are you sure you want to submit this application?") == true) {

                 
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveItems", 

                        data: "{IP_obj_SalesContract:" + JSON.stringify(lcl_obj_SalesContract) + "}", 
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

    //For PO

    function POSave() {

    $('#QuotationChkforPo').click(function() {
    if($(this).is(':checked')){
            lcl_obj_SalesContract.QuotationCode         =       $("#ddlCustomerName2 option:selected").val();
            var lcl_i32_Count =  $('#tblProductDetails1').appendGrid('getRowCount');
   
           lcl_obj_SalesContract.SalesContractDetails = new Array();
        for (var j = 0; j < lcl_i32_Count; j++) 
        {
                    lcl_obj_SalesContract.SalesContractDetails[j]= new Object();
                    lcl_obj_SalesContract.SalesContractDetails[j].QuotationDetailsCode=   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Code', j);
                    }
              }
              else{
                    var lcl_obj_SalesContract = new Object();
             lcl_obj_SalesContract.QuotationCode         =       $("#ddlQuotationCode option:selected").val();
             lcl_obj_SalesContract.PortOfDelivery        =       $("#PortofDelivert").val();
             lcl_obj_SalesContract.AdvisingBank          =       $("#AdvisingBank").val();
             lcl_obj_SalesContract.LCValidity            =       $("#LcValidity").val();
             lcl_obj_SalesContract.TransHipment          =       $("#Transhipment").val();
             lcl_obj_SalesContract.HSCode                =       $("#HsCode").val();
             lcl_obj_SalesContract.BuyerCode             =       $("#txtsBuyerCode").val();
             lcl_obj_SalesContract.SalesContractDate     =       $("#lblTodayDate").val();
             lcl_obj_SalesContract.Packing               =       $("#PkgSpecification").val();
             lcl_obj_SalesContract.TermsOfPayments       =       $("#PaymensTerms").val();
             lcl_obj_SalesContract.Delivery              =       $("#DestinationCountry").val();
             lcl_obj_SalesContract.Description           =       $("#Description").val();
             lcl_obj_SalesContract.CountryOrigin         =       $("#LoadingCountry").val();
             lcl_obj_SalesContract.PortofDestination     =       $("#DestinationPort").val();     
             var lcl_i32_Count =  $('#tblProductDetails0').appendGrid('getRowCount');
   
           lcl_obj_SalesContract.SalesContractDetails = new Array();
        for (var j = 0; j < lcl_i32_Count; j++) 
        {
                    lcl_obj_SalesContract.SalesContractDetails[j]= new Object();
                    lcl_obj_SalesContract.SalesContractDetails[j].QuotationDetailsCode=   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Code', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ItemNo              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'ItemNo', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductRef          =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'ProductRef', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ItemCode         =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Name', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductDesc         =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Desc', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].ProductSize         =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'size', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Length              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Length', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Gusset              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Gusset', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Density             =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Density', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Thickness           =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Thickness', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].PPB                 =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'ppb', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].BPC                 =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'bpc', j); 
                    lcl_obj_SalesContract.SalesContractDetails[j].Quantity            =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Quantity', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Weight              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Wgt1tp', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].Carton              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'Carton', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].PcsPerCarton        =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'PcsPerCarton', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].QtyPkg              =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'KG', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].UnitPriceCifFos     =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'UnitPrice', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].TotalAmountCifFos   =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'TotalPrice', j);
                    lcl_obj_SalesContract.SalesContractDetails[j].CBM                 =   $('#tblProductDetails1').appendGrid('getCtrlValue', 'CBM', j);
debugger;
}               
if (lcl_obj_SalesContract.CustomerCode == '0') {
          
                DisplayError("Please Select The Field 'Company Name'!!!");
                return;
            }

            if (lcl_obj_SalesContract.SalesContratNo == '') {
                DisplayError("Please Fill Up The Field 'SalesContract'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PortOfDelivery == '') {
                DisplayError("Please Fill Up The Field 'PortOfDelivery'!!!");
                return;
            }

            if (lcl_obj_SalesContract.AdvisingBank == '') {
                DisplayError("Please Fill Up The Field 'AdvisingBank'!!!");
                return;
            }

            if (lcl_obj_SalesContract.LCValidity == '') {
                DisplayError("Please Fill Up The Field 'LCValidity'!!!");
                return;
            }

            if (lcl_obj_SalesContract.TransHipment == '') {
                DisplayError("Please Fill Up The Field 'TransHipment'!!!");
                return;
            }

            if (lcl_obj_SalesContract.HSCode == '') {
                DisplayError("Please Fill Up The Field 'HSCode'!!!");
                return;
            }

            if (lcl_obj_SalesContract.LoadingCountry == '') {
                DisplayError("Please Fill Up The Field 'LoadingCountry'!!!");
                return;
            }

            if (lcl_obj_SalesContract.DestinationPort == '') {
                DisplayError("Please Fill Up The Field 'DestinationPort'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PkgSpecification == '') {
                DisplayError("Please Fill Up The Field 'PkgSpecification'!!!");
                return;
            }

            if (lcl_obj_SalesContract.PaymentsTerms == '') {
                DisplayError("Please Fill Up The Field 'PaymentsTerms'!!!");
                return;
            } 
                        
             if (confirm("Are you sure you want to submit this application?") == true) {

                 
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/SaveItems", 

                        data: "{IP_obj_SalesContract:" + JSON.stringify(lcl_obj_SalesContract) + "}", 
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
          });
    }
    
function Newcustomer() {

                     document.getElementById("txtCompany_NC").value        =     '';
                     document.getElementById("txtAddress_NC").value        =     '';
                     document.getElementById("txtPhone_NC").value          =     '';
                     document.getElementById("txtContactPerson_NC").value  =     '';
                     document.getElementById("Email").value                =     '';
                     document.getElementById("Country").value              =     '';
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
                                 { name: 'ID', display: 'Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Name', type: 'hidden', value: 0 },
                                 { name: 'Desc', display: 'Desc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'size', display: 'W', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
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

    //Dor Sales Contract

     $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#tblProductDetails0').appendGrid({
                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                                 { name: 'Code', type: 'hidden', value: 0 },
                                 {name: 'ItemNo', display: 'No', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ProductRef', display: 'Ref', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ID', display: 'Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Name', type: 'hidden', value: 0 },
                                 { name: 'Desc', display: 'Desc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'size', display: 'W', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
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
                                // { name: 'test', display: 'test', type: 'button', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],
                          
                });

    });
    


    //For PO

    $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#tblProductDetails1').appendGrid({
                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                                 { name: 'Code', type: 'hidden', value: 0 },
                                 {name: 'ItemNo', display: 'No', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ProductRef', display: 'Ref', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ID', display: 'Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Name', type: 'hidden', value: 0 },
                                 { name: 'Desc', display: 'Desc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'size', display: 'W', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
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
                                // { name: 'test', display: 'test', type: 'button', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });

   

    $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Table1').appendGrid({
//                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
                                 
                                 { name: 'Product', display: 'Product', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Sample', display: 'Sample Date', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'DateofStart', display: 'Start Date', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Dateoffinish', display: 'Finish Date', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Exfactory', display: 'Ex-Factory', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });
    
     $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Table6').appendGrid({
//                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
                                 
                                 { name: 'Product', display: 'Product', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Description', display: 'Description', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Quantity', display: 'Quantity', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Price', display: 'Price', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'ShipmentDate', display: 'FOB SD', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Quantity', display: 'Quantity', type: 'text' , ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });
     $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Table2').appendGrid({
//                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
                                 
                                 { name: 'Type', display: 'Type', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'PONo', display: 'PO No', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Size', display: 'Size', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Description', display: 'Description', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'TotalKg', display: 'Total Kg', type: 'text', ctrlCss: { width: '100%','text-align': 'left',Mode:'multiline'}},
                                 { name: 'Quantity', display: 'Quantity', type: 'text' , ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'CTN', display: 'CTN', type: 'text', ctrlCss: { width: '100%','text-align': 'left'}},
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });


    $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Table3').appendGrid({
//                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
                                 
                                 { name: 'CartonSize', display: 'Carton Size', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'PO', display: 'PO', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],
                });

    });

   
    $(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Table4').appendGrid({
//                         caption: 'Product Information',
                         initRows: 0,
                         columns: [
                                 
                               
                                 { name: 'Packing', display: 'Packing Specification', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });

    function SaveQuotaion()
    {

 
                    var lcl_obj_Quotaion = new Object();
                    lcl_obj_Quotaion.BuyerCode= $("#ddlCustomerName option:selected").val();
                    lcl_obj_Quotaion.CustomerReq= $("#txtCustomeReq").val();
                    //lcl_obj_Quotaion.QuotationDate=$("#lblTodayDate").val();
                    lcl_obj_Quotaion.ComName=$("#txt_ComName").val();
                    lcl_obj_Quotaion.ComAddress=$("#txt_ComAddress").val();
                    lcl_obj_Quotaion.ComPhone=$("#txt_ComPhone").val();
                    lcl_obj_Quotaion.ComEmail=$("#txt_ComEmail").val();
                    lcl_obj_Quotaion.ComAmount=$("#txt_ComAmount").val();
                    var lcl_i32_CountQuotationDetails =  $('#tblProductDetails').appendGrid('getRowCount');
                    lcl_obj_Quotaion.QuotationDetails = new Array();
        for (var j = 0; j < lcl_i32_CountQuotationDetails; j++) 
        
        {
       
                    lcl_obj_Quotaion.QuotationDetails[j]= new Object();
                    lcl_obj_Quotaion.QuotationDetails[j].ItemNo              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ItemNo', j);
                    lcl_obj_Quotaion.QuotationDetails[j].ProductRef          =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ProductRef', j);
                    lcl_obj_Quotaion.QuotationDetails[j].ItemCode         =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Name', j);
                    lcl_obj_Quotaion.QuotationDetails[j].ProductDesc         =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Desc', j);
                    lcl_obj_Quotaion.QuotationDetails[j].ProductSize         =   $('#tblProductDetails').appendGrid('getCtrlValue', 'size', j);
                    lcl_obj_Quotaion.QuotationDetails[j].Length              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Length', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].Gusset              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Gusset', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].Density             =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Density', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].Thickness           =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Thickness', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].PPB                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'ppb', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].BPC                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'bpc', j); 
                    lcl_obj_Quotaion.QuotationDetails[j].Quantity            =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Quantity', j);
                    lcl_obj_Quotaion.QuotationDetails[j].Weight              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Wgt1tp', j);
                    lcl_obj_Quotaion.QuotationDetails[j].Carton              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'Carton', j);
                    lcl_obj_Quotaion.QuotationDetails[j].PcsPerCarton        =   $('#tblProductDetails').appendGrid('getCtrlValue', 'PcsPerCarton', j);
                    lcl_obj_Quotaion.QuotationDetails[j].QtyPkg              =   $('#tblProductDetails').appendGrid('getCtrlValue', 'KG', j);
                    lcl_obj_Quotaion.QuotationDetails[j].UnitPriceCifFos     =   $('#tblProductDetails').appendGrid('getCtrlValue', 'UnitPrice', j);
                    lcl_obj_Quotaion.QuotationDetails[j].TotalAmountCifFos   =   $('#tblProductDetails').appendGrid('getCtrlValue', 'TotalPrice', j);
                    lcl_obj_Quotaion.QuotationDetails[j].CBM                 =   $('#tblProductDetails').appendGrid('getCtrlValue', 'CBM', j);

debugger;
}               
                 if (confirm("Are you sure you want to submit this application?") == true) {
             $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                       url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/QuotationSave", 

                        data: "{IP_obj_Quotaion:" + JSON.stringify(lcl_obj_Quotaion) + "}", 
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
      
       var lcl_str_ddlQuotationCode = $('#ddlQuotationCode option:selected').val();
    

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
                                $('#tblProductDetails0').appendGrid('appendRow', [
                       { Code:lcl_obj_QuotationDetail.QuotationDetailsCode,ItemNo:lcl_obj_QuotationDetail.Itemno, ProductRef: lcl_obj_QuotationDetail.ProductRef,Name:lcl_obj_QuotationDetail.ItemCode,ID:val,Desc: lcl_obj_QuotationDetail.ProductDesc,
                       size:lcl_obj_QuotationDetail.ProductSize,Length:lcl_obj_QuotationDetail.Length,Gusset:lcl_obj_QuotationDetail.Gusset,
                       Density:lcl_obj_QuotationDetail.Density,Thickness:lcl_obj_QuotationDetail.Thickness,ppb:lcl_obj_QuotationDetail.PPB,bpc:lcl_obj_QuotationDetail.BPC,
                       Wgt1tp:lcl_obj_QuotationDetail.Weight, Quantity:lcl_obj_QuotationDetail.Quantity,Carton:lcl_obj_QuotationDetail.Carton,
                       PcsPerCarton:lcl_obj_QuotationDetail.PcsPerCarton,CBM:lcl_obj_QuotationDetail.CBM,KG:lcl_obj_QuotationDetail.QtyPkg,UnitPrice:lcl_obj_QuotationDetail.UnitPriceCifFos,TotalPrice:lcl_obj_QuotationDetail.TotalAmountCifFos},
      
        ]);                              
    });
}

//For PO



                        else {
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

    function ProductPriceCreate()
    
     {
     
       var lcl_obj_RawMaterials = new Object();
            debugger;
               
            lcl_obj_RawMaterials.RMCode = $('#ddlProductSelect option:selected').val();
            if(lcl_obj_RawMaterials.RMCode=='0')
            {
            DisplayError("Please Select The 'Raw Materials'!!!");
                return;
            }
            lcl_obj_RawMaterials.Month = $("#Month").val();
            lcl_obj_RawMaterials.PriceMTon = $("#newPrice").val();

            if(lcl_obj_RawMaterials.PriceMTon=='')
            {
            DisplayError("Please Fill UP The 'Price'!!!");
                return;
            }
             if (confirm("Are you sure you want to Save new Price?") == true) {
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/RawMaterials.asmx/SaveItems",

                        data: "{IP_obj_RawMaterials:" + JSON.stringify(lcl_obj_RawMaterials) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {
                          
                                DisplayInformation(WSReturn.Message.toString());
LoadProductInformation();
                                return true;
                                  
                                
                            }
                            else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);
                            
                        }
                    }); return false;
                }
        }
   
   function LoadQuotationInfoQuotatioCode() {
      
       var lcl_str_ddlQuotationCode = $('#ddlQuotationCode option:selected').val();
    
      
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/LoadQuotationInfoQuotatioCode", 

                        data: "{IP_ui64_QuotationCode:" + JSON.stringify(lcl_str_ddlQuotationCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               
                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                                 document.getElementById("resCustomerReq").value= lcl_obj_QuotationDetail.CustomerReq;

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
     
       function LoadProductInformation() {
      
       var lcl_str_ddlProductName = $('#ddlProductSelect option:selected').val();
 if(lcl_str_ddlProductName=='0')   
  {
  return;
  }

       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/RawMaterials.asmx/LoadProductInfo", 

                        data: "{IP_obj_ddlProductName:" + JSON.stringify(lcl_str_ddlProductName) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               $('#Listofproduct tr').has('td').remove();
                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                                
                                lcl_obj_Html="<tr>"+"<td align=center>"+lcl_obj_QuotationDetail.lcl_RawProductList.RMName+"</td>"+"<td align=center>"+FormatDate(lcl_obj_QuotationDetail.Month) + "</td>"+ "<td align=right>"+lcl_obj_QuotationDetail.PriceMTon+"</td>"+"</tr>";     
                                     $('#Listofproduct tbody').append(lcl_obj_Html);
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

//////////..................................Product Table.........................................................
//        $(function () {
//              
//                    var table= $('#Listofproduct').appendGrid({
//                         caption: 'Product Information',
//                         initRows: 0,
//                         columns: [
////                                 { name: 'Image', display: 'img', type: 'image'},
//                                 
//                                 { name: 'ProductName', display: 'ProductName', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
//                                 { name: 'Subname', display: 'Subname', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
//                                 { name: 'Price', display: 'Price', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
//                                 { name: 'Date', display: 'Date', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
//                                 
//                                 { name: 'RecordId', type: 'hidden', value: 0 }
//                             ],

//                });

//    });


    //...................................Customer Table in SalesContract..................................................

   




    //................Sub Product in DropDownlist.............................


//     function LoadSubDropdownlistProduct() {
//      
//       var lcl_str_ddlItemCode = $('#ddlNameRawName option:selected').val();
//    
//      debugger;
//       $.ajax(
//                    {
//                        type: "POST",
//                        async: false,
//                        contentType: "application/json; charset=utf-8",
//                        url: gbl_URL_Root + "WebServices/WPMS/RawMaterials.asmx/LoadSubProduct", 


//                        data: "{IP_obj_ddlItemCode:" + JSON.stringify(lcl_str_ddlItemCode) + "}", 
//                        dataType: "json", 
//                        success: function (response) {
//                            var WSReturn = response.d;
//                            if (WSReturn.ResponseCode == 0) {  
//                                var lcl_obj_Quotation = WSReturn.Data;
//                              $("#SubMasterBatch").find("option").remove();
//                               $("#SubMasterBatch").append("<option value='0'>None"+ "</option>");
//                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
//                                              
//                    $("#SubMasterBatch").append("<option value='" + lcl_obj_QuotationDetail.RMSubCode + "'>" + lcl_obj_QuotationDetail.RMSubName + "</option>");
//                });

//}
//                        else {
//                                DisplayError(WSReturn.Message.toString());
//                            }
//                        },
//                        error: function ( jqXHR, textStatus, errorThrown) {
//                            alert(textStatus);
//                        }
//                    });
//        } debugger;

//    ...............................Load Customer information in Price Quotation..............................
        function LoadCustomerInfoCreateQuotatio() {
      
       var lcl_str_ddlCustomerCode = $('#ddlCustomerName option:selected').val();
       if(lcl_str_ddlCustomerCode==0
       )
       {
       return;
       }

      document.getElementById("Processingcost").value= '0';
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/LoadCustomerInfoCreateQuotatio", 

                        data: "{IP_obj_ddlCustomerCode:" + JSON.stringify(lcl_str_ddlCustomerCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                             document.getElementById("txtContactPerson_NPQ").value= lcl_obj_QuotationDetail.ContactPerson;
                             document.getElementById("txtAddress").value= lcl_obj_QuotationDetail.Address;
                             document.getElementById("txtEmail").value= lcl_obj_QuotationDetail.Email;
                                     
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
     
     //For PO

       function LoadCustomerInfoPO() {
      
       var lcl_str_ddlCustomerCode = $('#ddlCustomerName1 option:selected').val();
       if(lcl_str_ddlCustomerCode==0
       )
       {
       return;
       }

       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/LoadCustomerInfoCreateQuotatio", 

                        data: "{IP_obj_ddlCustomerCode:" + JSON.stringify(lcl_str_ddlCustomerCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                             document.getElementById("txtContactPerson_NPQ0").value= lcl_obj_QuotationDetail.ContactPerson;
                             document.getElementById("txtAddress0").value= lcl_obj_QuotationDetail.Address;
                             document.getElementById("txtEmail0").value= lcl_obj_QuotationDetail.Email;
                                     
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


     //    ...............................Load Customer information in SalesContract..............................
        function LoadCustomerInfoinSalesContract() {
      
       var lcl_str_ddlCustomerCode = $('#ddlQuotationCode option:selected').val();
  
      
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Buyer.asmx/LoadCustomerInfoQuotatioCode", 

                        data: "{IP_obj_ddlCustomerCode:" + JSON.stringify(lcl_str_ddlCustomerCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                                            var lcl_obj_Quotation = WSReturn.Data;
                               
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                             
                             document.getElementById("txtsBuyerCode").value= lcl_obj_QuotationDetail.CustomerCode;
                             document.getElementById("ResCustomerName").value= lcl_obj_QuotationDetail.CompanyName;
                             document.getElementById("resContactPerson").value= lcl_obj_QuotationDetail.ContactPerson;
                             document.getElementById("resAddres").value= lcl_obj_QuotationDetail.Address;
                             document.getElementById("resEmail").value= lcl_obj_QuotationDetail.Email;
                                     
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


              $(function () {
   
                    var table= $('#CustomerTableInSalesContract').appendGrid({
                         caption: 'Buyer Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                                 { name: 'Code',  type: 'hidden' },
                                 { name: 'Cusname', display: 'Company', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'ConPer', display: 'Contact Person', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Email', display: 'Email', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                  { name: 'Address', display: 'Address', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'RecordId', type: 'hidden', value: 0 }
                             ],

                });

    });
    

    $(function () {
   
                    var table= $('#Spacification').appendGrid({
                         caption: '',
                         initRows: 0,
                         columns: [
//
                                 { name: 'Item', display: 'Item', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },                                 
                                 { name: 'txtItemNo', display: 'ItemNo', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Desc', display: 'Desc', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtWidthSpec', display: 'W', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtGussetyspec', display: 'G', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtLengthSpec', display: 'L', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
{ name: 'txtDensitySpec', display: 'D', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtThicknessSpec', display: 'T', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtPunchOutSpec', display: 'P', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'txtfixedProcessingCost', display: 'P', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },                                 
                                 { name: 'txtfixedPrintingCharge', display: 'PC', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'SpecificationName', display: 'SN', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Remarks', display: 'Remarks', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                
                             ],

                });

    });

    function ProductBuyerRelation()    
     {
     
       var lcl_obj_RelationBuyerProduct = new Object();
               
            lcl_obj_RelationBuyerProduct.BuyerCode = $("#ddlCustomerName0 option:selected").val();
           
if(lcl_obj_RelationBuyerProduct.BuyerCode=='0')
{
DisplayError("Please Select The Field 'Company'!!!");
                return;
}

            lcl_obj_RelationBuyerProduct.FinishedItemCode = $("#ddlProductName1 option:selected").val();
            if(lcl_obj_RelationBuyerProduct.FinishedItemCode=='0')
{
DisplayError("Please Select The Field 'Product'!!!");
                return;
} 
            lcl_obj_RelationBuyerProduct.ItemCode = $("#ddlItem option:selected").val();
            lcl_obj_RelationBuyerProduct.Width = $("#txtWidthSpec").val();
            lcl_obj_RelationBuyerProduct.Gusset=$("#txtGussetyspec").val();
            lcl_obj_RelationBuyerProduct.Length = $("#txtLengthSpec").val();
            lcl_obj_RelationBuyerProduct.Density = $("#txtDensitySpec").val();
            lcl_obj_RelationBuyerProduct.Thickness = $("#txtThicknessSpec").val();
            lcl_obj_RelationBuyerProduct.PunchOut=$("#txtPunchOutSpec").val();
            lcl_obj_RelationBuyerProduct.ProcessingCost = $("#txtfixedProcessingCost").val();
            lcl_obj_RelationBuyerProduct.PrintingCharge = $("#txtfixedPrintingCharge").val();
            lcl_obj_RelationBuyerProduct.SpecificationName = $("#SpecificationName").val();
                 
            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/RelationBuyerProduct.asmx/Save",

                        data: "{IP_obj_RelationBuyerProduct:" + JSON.stringify(lcl_obj_RelationBuyerProduct) + "}", 
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
                    }); return false;
          
        }

        $(document).ready(function () {

        $( "#radLstProductCatalog_NPQ" ).click(function() {
        
var lcl_obj_BuyerInfo = $.trim($('#ddlCustomerName option:selected').val());
if(lcl_obj_BuyerInfo=='0')
{

DisplayError("Please Select 'Buyer First'!!!");

return;
}
});
});


function LoadItemName()

{

var lcl_ui64_BuyerCode = $.trim($("#ddlBuyer option:Selected").val());
 var lcl_ui64_ItemCode              =          $('#radLstProductCatalog_NPQ input:checked').val();


$.ajax({

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Item.asmx/LoadItem", 

                        data: "{IP_obj_radion:" + JSON.stringify(lcl_obj_radion) + ",IP_ui64_ItemCode:" + JSON.stringify(lcl_ui64_ItemCode) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                             document.getElementById("Processingcost").value='0';
                                var lcl_obj_Quotation = WSReturn.Data;
                                   $("#ddlSizeSpecification").find("option").remove();
                               $("#ddlSizeSpecification").append("<option value='0'>....Select Specification...."+ "</option>");
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                            $("#ddlSizeSpecification").append("<option value='" + lcl_obj_QuotationDetail.ItemCode + "'>" + lcl_obj_QuotationDetail.SpecificationName + "</option>");
                             
                                     
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

function LoadAllProductInformation() {
      
       var lcl_str_Month = $("#ShowResultMonth").val();
    
      debugger;
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/RawMaterials.asmx/LoadAllProductInfo", 

                        data: "{IP_str_Month:" + JSON.stringify(lcl_str_Month) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               $('#Listofproduct tr').has('td').remove();
                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                                
                                lcl_obj_Html="<tr>"+"<td align=center>"+lcl_obj_QuotationDetail.lcl_RawProductList.RMName+"</td>"+"<td align=center>"+FormatDate(lcl_obj_QuotationDetail.Month) + "</td>"+ "<td align=right>"+lcl_obj_QuotationDetail.PriceMTon+"</td>"+"</tr>";     
                                     $('#Listofproduct tbody').append(lcl_obj_Html);
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

        function LoadSizeSpec() {
      
      var lcl_obj_ddlSizeSpecification = $.trim($('#ddlSizeSpecification option:selected').val());

      if(lcl_obj_ddlSizeSpecification=='0')
      {
      
      return;
      }
    
       $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/RelationBuyerProduct.asmx/RetriveSizeSpec", 

                        data: "{IP_obj_ddlSizeSpecification:" + JSON.stringify(lcl_obj_ddlSizeSpecification) + "}", 
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
                             document.getElementById("Cutout").value= lcl_obj_QuotationDetail.PunchOut;
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


function resetFixed()
{

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

   function FormatDate(jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)))
        var d = date.getDate(), m = date.getMonth() + 1, y;
        if (date.getFullYear) { y = date.getFullYear(); }
        else { y = 2000 + (date.getYear() % 100); }
        return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
    }

    function newTab() {
     form = document.createElement("form");
     form.method = "GET";
     form.action = "ReportingViewer.aspx";
     form.target = "_blank";
     document.body.appendChild(form);
     form.submit();
}


        function LoadCustomerLoad() {
      
       var lcl_str_Status = 1;
  
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/Buyer.asmx/LoadCustomer", 
                        data: "{IP_str_Status:" + JSON.stringify(lcl_str_Status) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Quotation = WSReturn.Data;
                               $('#CustomerList tr').has('td').remove();
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                            lcl_obj_Html="<tr>"+"<td class='Table'>"+lcl_obj_QuotationDetail.CompanyName+"</td>"+"<td class='Table'>"+lcl_obj_QuotationDetail.ContactPerson + "</td>"+ "<td class='Table'>"+lcl_obj_QuotationDetail.Email+"</td>"+"<td class='Table'>"+lcl_obj_QuotationDetail.Country+"</td>"+"<td class='Table'>"+lcl_obj_QuotationDetail.Address+"</td>"+"</tr>";     
                                     $('#CustomerList tbody').append(lcl_obj_Html);                               
                                
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


   function test()

   {
   var data = $('#tblProductDetails0').appendGrid('getAllValue');
    // Get the Album of row 1
    alert('Album of first row is ' + data[0].ProductRef);
    // Get the Artist of row 2

   }

   function LoadItemSize() {
      
      var lcl_obj_ddlSizeSpecification = $.trim($('#ddlItem option:selected').val());

      if(lcl_obj_ddlSizeSpecification=='0')
      {
      
      return;
      }
    
       $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/WPMS/ItemsService.asmx/LoadItemSize", 

                        data: "{IP_obj_ddlSizeSpecification:" + JSON.stringify(lcl_obj_ddlSizeSpecification) + "}", 
                        dataType: "json", 
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {  
                                var lcl_obj_Item = WSReturn.Data;
                               
                             $.each(lcl_obj_Item, function (index, lcl_obj_ItemDetails) {
                             document.getElementById("txtWidthSpec").value= lcl_obj_ItemDetails.Width;
                             document.getElementById("txtLengthSpec").value= lcl_obj_ItemDetails.Length;
                             document.getElementById("txtGussetyspec").value= lcl_obj_ItemDetails.Gusset;
                             //document.getElementById("txtDensity").value= lcl_obj_ItemDetails.Density;
                             document.getElementById("txtThicknessSpec").value= lcl_obj_ItemDetails.Thickness;
                             document.getElementById("txtPunchOutSpec").value= lcl_obj_ItemDetails.Punchout;
                             document.getElementById("txtfixedProcessingCost").value= lcl_obj_ItemDetails.ProcessingCost;
                             document.getElementById("txtfixedPrintingCharge").value= lcl_obj_ItemDetails.PrintingCharge;
                                
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
