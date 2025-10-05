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

        if (lcl_obj_Buyer.Address == '') {
            DisplayError("Please Fill Up The Field 'Address'!!!");
            return;
        }

        if (lcl_obj_Buyer.Phone == '') {
            DisplayError("Please Fill Up The Field 'Phone'!!!");
            return;
        }
        if (lcl_obj_Buyer.ContactPerson == '') {
            DisplayError("Please Fill Up The Field 'ContactPerson'!!!");
            return;
        }

        if (lcl_obj_Buyer.Email == '') {
            DisplayError("Please Fill Up The Field 'Email'!!!");
            return;
        }

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
        debugger;
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
        }debugger;
    }
    return false;

}

$(function () {
    // Initialize appendGrid

                    var lcl_obj_ProductRef = document.getElementById("txt_ProductRef");
                    var table= $('#CustomerList').appendGrid({
                         caption: 'Buyer Information',
                         initRows: 0,
                         columns: [
//                                 { name: 'Image', display: 'img', type: 'image'},
                                 {  name: 'CompanyName', display: 'Company Name', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 {  name: 'ContactPerson', display: 'Contact Person', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 {  name: 'Email', display: 'Email', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 
                                 {  name: 'Address', display: 'Address', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 {  name: 'Country', display: 'Country', type: 'text', ctrlCss: { width: '100%','text-align': 'left',mode: 'multiline'} },
                                 
                             ],

                });

    });

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
                        var lcl_i32_Count =  $('#CustomerList').appendGrid('getRowCount');

                               for(var i=0;i<lcl_i32_Count;i++)
                               {
                               $('#CustomerList').appendGrid('removeRow',0);
                               }
                             $.each(lcl_obj_Quotation, function (index, lcl_obj_QuotationDetail) {
                            
                            $('#CustomerList').appendGrid('appendRow', [
                            { CompanyName:lcl_obj_QuotationDetail.CompanyName,ContactPerson:lcl_obj_QuotationDetail.ContactPerson, Email: lcl_obj_QuotationDetail.Email,Address:lcl_obj_QuotationDetail.Address,Country:lcl_obj_QuotationDetail.Address },
      
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
