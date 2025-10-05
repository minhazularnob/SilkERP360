function LoadNewPurchaseOrder() {
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/SPMNewPO.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}


function LoadDailyThroughputAnalysis() {
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/DailyThroughput.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}

function LoadThroughputAnalysis() {
    //load throughput IP module
    //alert("lOADING THROUGHPUT IP");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/ThroughputAnalysis.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}

function LoadThroughputIP() {
    //load throughput IP module
    //alert("lOADING THROUGHPUT IP");
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/ThroughputIP.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}

function LoadSCPersoPhysicalRecovery() {
    var lcl_str_CompanyCode = $('#txtCompanyCode').val();
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,


            url: "~/../../../WebServices/UILoaderService.asmx/GetUI",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/SC_Perso_Recovery.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}

function LoadSCPersoFaultRecoveryList() {
    var lcl_str_CompanyCode = $('#txtCompanyCode').val();
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,


            url: "~/../../../WebServices/UILoaderService.asmx/GetUI",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/SC_Fault_Perso_Card_List_Download.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}

function LoadQC() {
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCMaster.ascx') + "}", //provide input for the getSM_PO method
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
    return;
}