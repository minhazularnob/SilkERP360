/**
02	 * This javascript file checks for the brower/browser tab action.
03	 * Reference: http://stackoverflow.com/questions/1921941/close-kill-the-session-when-the-browser-or-tab-is-closed
04	 */
var validNavigation = false;

function endSession() {
    // Browser or broswer tab is closed
    // Do sth here ...
    //alert("bye");
     $.ajax(
            {
                type: "POST",
                global: false,
                async: false,
                contentType: "application/json; charset=utf-8",
                url: gbl_URL_Root + 'WebServices/UserServices.asmx/Logout',
                //data: IP_obj_DATA, //"{IP_obj_Employee:" + JSON.stringify(lcl_obj_Employee) + "}", //provide input for the getSM_PO method
                dataType: "json", /// <reference path= />
                beforeSend: function () {
                    //IMPORTANT
                    //THIS WILL BYPASS THE GLOBAL AJAX SETUP
                },
                success: function () {
                    alert("You have been Logged out by the System!!!");
                    //self.redirectLogout(is_forced);
                }
            });
    
}

function wireUpEvents() {
    /*
    * For a list of events that triggers onbeforeunload on IE
    * check http://msdn.microsoft.com/en-us/library/ms536907(VS.85).aspx
    */
    window.onbeforeunload = function () {
        if (!validNavigation) {
            endSession();
        }
    }

    // Attach the event keypress to exclude the F5 refresh
    $('document').bind('keypress', function (e) {
        if (e.keyCode == 116) {
            validNavigation = true;
        }
    });

    // Attach the event click for all links in the page
    $("a").bind("click", function () {
        validNavigation = true;
    });

    // Attach the event submit for all forms in the page
    $("form").bind("submit", function () {
        validNavigation = true;
    });

    // Attach the event click for all inputs in the page
    $("input[type=submit]").bind("click", function () {
        validNavigation = true;
    });
}

// Wire up the events as soon as the DOM tree is ready
$(document).ready(function () {
    wireUpEvents();
});