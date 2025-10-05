//var SessionRefreshTimer = setInterval('RefreshSession()', 10000);
jQuery(document).ready(function () {
//    $(document).ajaxStart(function () { $.blockUI(); clearInterval(SessionRefreshTimer); }).ajaxStop($.unblockUI);
//    SetFontAndFontSize(); //defined in .Globals/Scripts/common.js
//    $(document).ajaxComplete(function () {
//        SetFontAndFontSize(); //defined in .Globals/Scripts/common.js
//        SessionRefreshTimer = setInterval('RefreshSession()', 600000);
});    

//var timeout = 10000;
//$(document).bind("idle.idleTimer", function () {
//    // function you want to fire when the user goes idle
//    $.timeoutDialog({
//        title: 'Session Expire Notification',
//        message: 'Automatic Logout in {0} Sec.',
//        timeout: 10,
//        countdown: 60,
//        keep_alive_button_text: 'Yes',
//        sign_out_button_text: 'No',
//        restart_on_yes: false,
//        logout_url: 'javascript:Logout()',
//        logout_redirect_url: '/index.aspx',
//        keep_alive_url: '/KeepAlive.aspx'
//    });
//});
//$(document).bind("active.idleTimer", function () {
//    //alert("active again");
//    // function you want to fire when the user becomes active again
//});
//$.idleTimer(timeout);


function RefreshSession() {
    //Automatically refreshes session
    $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: gbl_str_HostURL + "WebServices/UserServices.asmx/RefreshSession",
                data: "{}", //provide input for the getSM_PO method
                dataType: "json", /// <reference path= />
                async: true,
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.Code == 0) {
                        return false;
                    }
                    else {
                        alert(WSReturn.Message.toString());
                    }
                },
                error: function (data) {
                    HandleFatalAjaxError();
                }
            });
}