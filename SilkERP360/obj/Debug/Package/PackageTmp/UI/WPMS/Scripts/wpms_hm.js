var gbl_obj_CompanyDepartments = new Object(); //Stores DepartmentCore Objects, CompanyCode wise
$(document).ready(function () {

    //WELLCOME MESSAGE
    var lcl_str_EmpName = $("#txtName").text();
    var lcl_str_Msg = "Welcome " + lcl_str_EmpName + " !!!";
    //HideMessageBoard();
    ShowMessageBoard(lcl_str_Msg);

    
});

//************** Commit by HAsan...bgn 22-04-2014 ************* /////
var timeout = 1000000;
$(document).bind("idle.idleTimer", function () {
    // function you want to fire when the user goes idle
    $.timeoutDialog({
        title: 'Session Expire Notification',
        message: 'Automatic Logout in {0} Sec.',
        timeout: 300, //seconds0
        countdown: 60,
        keep_alive_button_text: 'Yes',
        sign_out_button_text: 'No',
        restart_on_yes: false,
        logout_url: gbl_URL_Root + 'WebServices/UserServices.asmx/Logout',
        logout_redirect_url: '/index.aspx',
        keep_alive_url: '/KeepAlive.aspx'
    });
});
$(document).bind("active.idleTimer", function () {
    //alert("active again");
    // function you want to fire when the user becomes active again
});
$.idleTimer(timeout);

/***************************************************************************************************************/
//$(document).ajaxSuccess(function (event, xhr, settings) {
//    var lcl_obj_WSResponseText = xhr.responseText;
//    var lcl_obj_WSResponse = new Object();
//    lcl_obj_WSResponse = ($.parseJSON(lcl_obj_WSResponseText)).d;
//    //        console.log(lcl_obj_WSResponse);
//    switch (lcl_obj_WSResponse.WebServiceExecutionStatus) {
//        case 0:
//            //Success
//            DisplaySuccess(lcl_obj_WSResponse.Message);
//            break;
//        case 1:
//            //error
//            DisplayError(lcl_obj_WSResponse.Message);
//            break;
//        case 2:
//            //Critical Error
//            DisplayError(lcl_obj_WSResponse.Message);
//            break;
//    }

//});
/***************************************************************************************************************/
//Company Change Event
//function EvntCompanyChanged() {
//    var lcl_ui32_SelectedIndex = $('#ddlCompany option:selected').index();
//    if (lcl_ui32_SelectedIndex == 0) {
//        $("select[id$=ddlDepartment] > option").remove();
//        $("#ddlDepartment").append($("<option></option>").val('0').html('----------Select Department'));
//        return;
//    }
//    //get selected companycode
//    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
//    if (lcl_str_CompanyCode == '') {
//        return;
//    }

//    var lcl_str_WMData = "{IP_ui64_CompanyCode : " + lcl_str_CompanyCode + "}";

//    $.ajax(
//        {
//            type: "POST",
//            async: true,
//            contentType: "application/json; charset=utf-8",
//            global: true,
//            url: gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/GetDepartmentCoresByCompany",
//            data: "{IP_ui64_CompanyCode:" + JSON.stringify(lcl_str_CompanyCode) + "}", //provide input for the getSM_PO method
//            dataType: "json",
//            success: function (response) {
//                var WSResponse = response.d;
//                var lcl_obj_DepartmentCores = WSResponse.Data;
//                //clear ddlDepartment
//                $("select[id$=ddlDepartment] > option").remove();
//                $("#ddlDepartment").append($("<option></option>").val('0').html('----------Select Department'));
//                $.each(lcl_obj_DepartmentCores, function (index, lcl_obj_DepartmentCore) {
//                    $('#ddlDepartment').append(new Option(lcl_obj_DepartmentCore.Name, lcl_obj_DepartmentCore.DepartmentCode, true, true));
//                });
//                $("#ddlDepartment").val(0); //set selected index value to 0
//            } /// <reference path= />
//        });
//    }




/***************************************************************************************************************/
/***************************************************************************************************************/
function Logout() {
    if (confirm("Are You sure, you want to log out?")) {
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            // url: "~/../../WebServices/UserServices.asmx/Logout",
            url: "~../../../../WebServices/UserServices.asmx/Logout",


            data: "", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode == -101) {
                    DisplayError("Your Session Has Already Expired!!!Redirecting!!!");
                    window.location = gbl_URL_Root + "index.aspx";
                    return;
                }
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    window.location = gbl_URL_Root + "index.aspx";
                    return;
                }
                window.location = gbl_URL_Root + "index.aspx";
            } /// <reference path= />
        });
    }
}

function ShowMessageBoard(Message) {
    $('#dvMessageBoard').hide('slow', function () {
        $("#dvMessageBoard span").text(Message);
        $('#spnMessage').css('color', 'white');
        $('#dvMessageBoard').css('background-color', 'green');
        $('#dvMessageBoard').show('slow');
    });
    //$('#dvMessageBoard').fadeOut().next().delay(500).fadeIn();
}
function ShowErrorMessageBoard(Message) {
    $('#dvMessageBoard').hide('slow', function () {
        $('#spnMessage').css('color', 'white');
        $("#dvMessageBoard span").text(Message);
        $('#dvMessageBoard').css('background-color', 'red');
        $('#dvMessageBoard').show('slow');
    });
    //$('#dvMessageBoard').fadeOut().next().delay(500).fadeIn();
}

function ShowInfoMessageBoard(Message) {
    $('#dvMessageBoard').hide('slow', function () {
        $("#dvMessageBoard span").text(Message);
        $('#spnMessage').css('color', 'black');
        $('#dvMessageBoard').css('background-color', 'yellow');
        $('#dvMessageBoard').show('slow');
    });
}

