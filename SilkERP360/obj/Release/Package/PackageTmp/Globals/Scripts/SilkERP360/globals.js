//var gbl_obj_UserProfile = new Object();
var gbl_str_HostURL = new Object();
//var gbl_URL_Root = "/SilkERP";
var gbl_URL_Root1 = "~/.."
var gbl_URL_Root = " ~/../../../"

$(document).ready(function () {
    //    $('.tTip').betterTooltip({ speed: 150, delay: 300 });
    //ConfirmBoxSetup();
    //alert("globals loaded");
    gbl_str_HostURL = "~/..";

    $('input').css('font-family', 'Verdana');
    $('div').css('font-family', 'Verdana');

    /*Tooltip Setup*/
//    $(document).tooltip({
//        position: {
//            my: "center bottom-20",
//            at: "center top",
//            using: function (position, feedback) {
//                $(this).css(position);
//                $("<div>")
//            .addClass("arrow")
//            .addClass(feedback.vertical)
//            .addClass(feedback.horizontal)
//            .appendTo(this);
//            }
//        }
//    });
    /****************************************************************************************/
    /***************************************************************************************************************/
    //AJAX SETUP
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

    //    $(document).ajaxSuccess(function (event, xhr, settings) {
    //        if (settings.url == "ajax/test.html") {
    //            $(".log").text("Triggered ajaxSuccess handler. The ajax response was: " + xhr.responseText);
    //        }
    //    });
    /***************************************************************************************************************/
});

function AjaxCallGlobal(IP_str_WebServicePath, IP_str_WebMethod, IP_obj_DATA, FuncSuccessCallBack) {
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "/" + IP_str_WebServicePath + "/" + IP_str_WebMethod,
            data: IP_obj_DATA, //"{IP_obj_Employee:" + JSON.stringify(lcl_obj_Employee) + "}", //provide input for the getSM_PO method
            dataType: "json",
            global: true,
            success: function (response) { FuncSuccessCallBack(response); }
        });
}
function AjaxCall(IP_str_WebServicePath, IP_str_WebMethod, IP_obj_DATA) {
    //alert(IP_obj_DATA.toString());
    var lcl_str_URL = IP_str_WebServicePath + "/" + IP_str_WebMethod;
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: lcl_str_URL,
            data: IP_obj_DATA, //"{IP_obj_Employee:" + JSON.stringify(lcl_obj_Employee) + "}", //provide input for the getSM_PO method
            dataType: "json" /// <reference path= />
        });
    }

function AjaxLocalCall(IP_str_WebServicePath, IP_str_WebMethod, IP_obj_DATA, SuccessCallBackFunc) {
    var lcl_str_URL = gbl_str_HostURL + IP_str_WebServicePath + "/" + IP_str_WebMethod;
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: false,
            url: lcl_str_URL,
            data: IP_obj_DATA, //"{IP_obj_Employee:" + JSON.stringify(lcl_obj_Employee) + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                SuccessCallBackFunc(response);
            } /// <reference path= />
        });
}

function ValidateForm() {
    var lcl_b_InputValidated = true;
    var lcl_str_ErrorMessage = new Object(); //<br/> Separated error messages
    lcl_str_ErrorMessage = '';
    //Scan all input controls and Validate
    var lcl_str_PlaceHolderValue = new Object();
    lcl_str_PlaceHolderValue = '';
    $('.input-required').each(function (i, obj) {
        //test
        lcl_str_PlaceHolderValue = $(this).attr("placeholder").toString();
        $(this).attr("placeholder", '');
        if ($.trim($(this).val().toString()) == '') {
            //$(this).css('background-color', 'red');
            lcl_b_InputValidated = false;
            lcl_str_ErrorMessage += "The Field '" + lcl_str_PlaceHolderValue + "' Cannot be Empty!!!<br/>";
        }
        $(this).attr("placeholder", lcl_str_PlaceHolderValue);
    });
    if (lcl_b_InputValidated == false) {
        DisplayError(lcl_str_ErrorMessage);
    }
    return lcl_b_InputValidated;
}

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

function Logout() {
    alert("LOGOUT CLICKED");
}