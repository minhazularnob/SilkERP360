
$(document).ready(function () {
$( "#Month" ).datepicker({
        inline: true,
        showOtherMonths: true,
       dateFormat: 'dd-MM-yy',
    });

    $("#Month").datepicker("setDate", new Date());

    $('#ddlProductSelect').change(function () { LoadProductInformation(); });
    });

       function FormatDate(jsonDate) {
        var date = new Date(parseInt(jsonDate.substr(6)))
        var d = date.getDate(), m = date.getMonth() + 1, y;
        if (date.getFullYear) { y = date.getFullYear(); }
        else { y = 2000 + (date.getYear() % 100); }
        return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
    }

    function ProductPriceCreate()
    
     {

       var lcl_obj_RawMaterials = new Object();
               
            lcl_obj_RawMaterials.RMCode = $('#ddlProductSelect option:selected').val();
            if(lcl_obj_RawMaterials.RMCode=='0')
            {
            DisplayError("Please Select The 'Raw Materials'!!!");
                return;
            }

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
                        var lcl_i32_Count =  $('#Listofproduct').appendGrid('getRowCount');

                               for(var i=0;i<lcl_i32_Count;i++)
                               {
                               $('#Listofproduct').appendGrid('removeRow',0);
                               }
                                $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                                
                                 $('#Listofproduct').appendGrid('appendRow', [
                       { ProductName:lcl_obj_QuotationDetail.lcl_RawProductList.RMName,Date:FormatDate(lcl_obj_QuotationDetail.Month), Price: lcl_obj_QuotationDetail.PriceMTon },
      
        ]);
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
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#Listofproduct').appendGrid({
                         caption: 'Raw Materials Price Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                           
                                 {name: 'ProductName', display: 'Product Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Date', display: 'Ref', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 { name: 'Price', display: 'Price', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
         
                             ],
                          
                });

    });