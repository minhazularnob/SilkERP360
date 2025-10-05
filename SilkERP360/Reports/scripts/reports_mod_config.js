//var SilkERPRoot = "http://192.168.200.4/";
//var SilkERPRoot = "/";
var SilkERPRoot = "~/../../";
var gbl_root = "~/../../";
var gbl_rpt_root_path = "~/../";
//AJAX SETUP
$(document).ready(function () {
    $.ajaxSetup({
        global: true,
        type: "POST"
    });

    $(document).ajaxStart(function () {
        //alert("STARTING AJAX");
        $.blockUI({
            message: '<h3><img src="~/../../../Globals/Images/busy.gif"/> &nbsp;Please Wait...</h3>'
        });
    }).ajaxError(function (event, jqxhr, settings, exception) {
        //debugger;
        //alert("GLOBAL AJAX ERROR");
        var lcl_ui32_StatusCode = jqxhr.status;
        switch (lcl_ui32_StatusCode) {
            case -100:
                break;
            case 500:
                lcl_obj_WSResponse = ($.parseJSON(jqxhr.responseText)).d;
                DisplayError(lcl_obj_WSResponse.Message);
                break;
            case 403:
                DisplayError("You no Longer Have permission to access the application server now!!!Please re-login.");
                break;
            case 424:
                DisplayError(jqxhr.responseText);
                break;
            default:
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator.");
                break;
        }

        $.unblockUI();
    }).ajaxStop(function () {
        $.unblockUI();
    }).ajaxComplete(function () {
        //alert("AJAX COMPLETE");
        //$.unblockUI();
    });
});

/****************************************************************************************/
/***************************************************************************************************************/
//AJAX SETUP



function DisplayError(ErrorMessage) {
    var a = noty({
        layout: 'top',
        theme: 'defaultTheme',
        type: 'error',
        text: ErrorMessage,
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 400 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: true,
        closeWith: ['click'], // ['click', 'button', 'hover']
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () { }
        }
    });
    $("div").css("font-family", "Verdana");
    return false;
}

function DisplayInformation(Information) {
    var a = noty({
        layout: 'top',
        theme: 'defaultTheme',
        type: 'information',
        text: Information,
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 400 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: true,
        closeWith: ['click'], // ['click', 'button', 'hover']
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () { }
        }
    });
    $("div").css("font-family", "Verdana");
}

function DisplayWarning(Warning) {
    var a = noty({
        layout: 'top',
        theme: 'defaultTheme',
        type: 'warning',
        text: Warning,
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 400 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: true,
        closeWith: ['click'], // ['click', 'button', 'hover']
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () { }
        }
    });
    $("div").css("font-family", "Verdana");
}

function DisplayNotification(Notification) {
    var a = noty({
        layout: 'top',
        theme: 'defaultTheme',
        type: 'notification',
        text: Notification,
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 400 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: true,
        closeWith: ['button'], // ['click', 'button', 'hover']
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () { }
        }
    });
    $("div").css("font-family", "Verdana");
}

function DisplaySuccess(Success) {
    $.blockUI({ message: '<h1><img src="~/../../../Globals/Images/busy.jpg"/>Please Wait...</h1>' });
    var a = noty({
        layout: 'top',
        theme: 'defaultTheme',
        type: 'success',
        text: Success,
        dismissQueue: false, // If you want to use queue feature set this true
        template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
        animation: {
            open: { height: 'toggle' },
            close: { height: 'toggle' },
            easing: 'swing',
            speed: 400 // opening & closing animation speed
        },
        timeout: false, // delay for closing event. Set false for sticky notifications
        force: false, // adds notification to the beginning of queue when set to true
        modal: true,
        closeWith: ['click'], // ['click', 'button', 'hover']
        callback: {
            onShow: function () { },
            afterShow: function () { },
            onClose: function () { },
            afterClose: function () { }
        }
    });
    $("div").css("font-family", "Verdana");
}

function LoadDailyThroughputAnalysis() {
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_root + "WebServices/UILoaderService.asmx/GetUIFromPath",
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
                $('#dvContainer').html(lcl_str_ControlHTML);
                $('#dvContainer').css({ "visibility": "visible" }).fadeIn('slow');
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
            url: gbl_root + "WebServices/UILoaderService.asmx/GetUIFromPath",
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
                $('#dvContainer').html(lcl_str_ControlHTML);
                $('#dvContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadDailyThroughputVisual() {
    //load throughput IP module
    //alert("lOADING THROUGHPUT visual");
    var lcl_str_WSPath = "Reports/SCPM/DailyThroughputVisual.ascx"
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_root + "WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify(lcl_str_WSPath) + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return false;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvContainer').html(lcl_str_ControlHTML);
                $('#dvContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return false;
}

function LoadMachinewiseThroughputVisualByDateRange() {
    var lcl_str_WSPath = "Reports/SCPM/MachinewiseThroughputVisualByDateRange.ascx"
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_root + "WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify(lcl_str_WSPath) + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return false;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvContainer').html(lcl_str_ControlHTML);
                $('#dvContainer').css({ "visibility": "visible" }).fadeIn('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return false;
}

