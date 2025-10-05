function LoadPantoneConfiguration() {
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/PantoneColor.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
}

function LoadItemConfiguration() {

//    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
//    if (lcl_ui32_CompanySelectedIndex <= 0) {
//        //No Company Selected
//        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
//        return;
//    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/wpms_item_config.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

    }



    function LoadBuyer() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Buyer.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path="~/UI/WPMS/Buyer.ascx" />

            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

    }


    function LoadRawMaterial() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/RawMaterial.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path="~/UI/WPMS/Buyer.ascx" />

            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

    }


    function LoadFixed() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Fixed.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json", 


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });

    }


    function LoadQuotation() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Quotation.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }


    function LoadPurchaseOrder() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/PurchaseOrder.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }


    function LoadSalesContract() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/SalesContract.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }


    function LoadFactoryOrderSheet() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/FactoryOrderSheet.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }



    function LoadInvoice() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/Invoice.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }


    function LoadPackingList() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/PackingList.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",

            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }



    function LoadQuotationReport() {

        //    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
        //    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //        //No Company Selected
        //        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        //        return;
        //    }
        var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
        if (lcl_str_CompanyCode == '') {
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/WPMS/QuotationReport.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",


            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvUIContainer').html(lcl_str_ControlHTML);
                $('#dvUIContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    }
