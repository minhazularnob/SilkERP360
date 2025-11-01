//will store image object of employee after the UserProfile is returned

$(document).ready(function () {
//    $.ajaxSetup({
//        global: true,
//        type: "POST"
//    });

    $(document).ajaxStart(function () {
        //alert("STARTING AJAX");
        $.blockUI({
            message: '<h3>Please Wait...</h3>'
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



//    });

});

function ChangePassword() {
    var lcl_str_Username = $.trim($('#txtUserNameResetPassword').val());
    var lcl_str_CurrentPassword = $.trim($('#txtCurrentPassword').val());
    var lcl_str_NewPassword1 = $.trim($('#txtNewPassword').val());
    var lcl_str_NewPassword2 = $.trim($('#txtReconfirmPassword').val());
    if (lcl_str_Username == '') {
        DisplayError("The Field 'Username' cannot be blank!!!");
        return;
    }
    if (lcl_str_CurrentPassword == '') {
        DisplayError("The Field 'Current Password' cannot be blank!!!");
        return;
    }
    if (lcl_str_NewPassword1 == '') {
        DisplayError("The Field 'New Password' cannot be blank!!!");
        return;
    }
    if (lcl_str_NewPassword2 == '') {
        DisplayError("The Field 'Reconfirm Password' cannot be blank!!!");
        return;
    }
    if (lcl_str_NewPassword1 === lcl_str_NewPassword2) {
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: false,
            url: gbl_URL_Root1 + "/WebServices/UserServices.asmx/ChangePassword",
            data: "{IP_str_Username :'" + lcl_str_Username + "',IP_str_OldPassword :'" + lcl_str_CurrentPassword + "',IP_str_NewPassword : '" + lcl_str_NewPassword1 + "'}",
            dataType: "json", /// <reference path= />
            success: function (response) {
                //alert("WS SUCCESS");
                //alert(xhr.responseText);
                //var lcl_obj_WSResponseText = xhresponseText;
                //var lcl_obj_WSResponse = new Object();
                //lcl_obj_WSResponse = ($.parseJSON(lcl_obj_WSResponseText)).d;
                var lcl_obj_WSResponse = response.d;
                //        console.log(lcl_obj_WSResponse);
                switch (lcl_obj_WSResponse.WebServiceExecutionStatus) {
                    case 0:
                        //Success
                        //debugger;
                        if (lcl_obj_WSResponse.BResponse == false) {
                            DisplayError(lcl_obj_WSResponse.Message);
                        }
                        else {
                            $('.c_p_field').val('');
                            DisplayInformation(lcl_obj_WSResponse.Message);
                        }
                        break;
                    case -100:
                        //error
                        //debugger;
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 2:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 3:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 4:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                }
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
            }
        });
    }
    else {
        DisplayError("'New Password' and 'Reconfirmed Password' dont match!!!");
        return;
    }
}
function Login() {
    var lcl_str_Username = $.trim($('#txtUsername').val());
    var lcl_str_Password = $.trim($('#txtPassword').val());
    var lcl_str_Message = "";
    var lcl_b_FormValidated = true;
    if (lcl_str_Username == '') {
        lcl_str_Message = "The Field 'Username' Cannot be Empty!<br/>";
        lcl_b_FormValidated = false;
    }
    if (lcl_str_Password == '') {
        lcl_str_Message += "The Field 'Password' Cannot be Empty!<br/>";
        lcl_b_FormValidated = false;
    }
    if (lcl_b_FormValidated == false) {
        DisplayError(lcl_str_Message);
        return lcl_b_FormValidated;
    }
    
    //var lcl_str_WMData = "{IP_str_Username :'" + lcl_str_Username + "',IP_str_Password :'" + lcl_str_Password + "'}";

    //Remove the Global ajaxSuccess event handler
    //$(document).unbind('ajaxSuccess');

//    $(document).ajaxSuccess(function (event, xhr, settings) {
//       

//    });
    //Validated. Send AJAX Request
   // AjaxCall(gbl_URL_Root + "/WebServices/UserServices.asmx", "Authenticate", lcl_str_WMData);

    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: false,
            url: gbl_URL_Root1 + "/WebServices/UserServices.asmx/Authenticate",
            data: "{IP_str_Username :'" + lcl_str_Username + "',IP_str_Password :'" + lcl_str_Password + "'}",
            dataType: "json", /// <reference path= />
            success: function (response) {

                var lcl_obj_WSResponse = response.d;
                
                switch (lcl_obj_WSResponse.WebServiceExecutionStatus) {
                    case 0:
                        //Success
                        //debugger;
                        var lcl_b_AuthenticUser = lcl_obj_WSResponse.BResponse;
                        if (lcl_b_AuthenticUser == false) {
                            DisplayError(lcl_obj_WSResponse.Message);
                        }
                        else {
                            //lcl_obj_WSResponse.Data will contain the UserProfile Object
                            //Get UserProfile object
                            var lcl_obj_UserProfile = lcl_obj_WSResponse.Data;
                            var lcl_obj_ModulesMenusCompanies = lcl_obj_UserProfile.ModuleMenusCompanies
                            if (lcl_obj_ModulesMenusCompanies.length == 1) {
                                var lcl_obj_ModuleMenusCompany = lcl_obj_ModulesMenusCompanies[0];
                                //append query string for Mod
                                window.location = lcl_obj_ModuleMenusCompany.HomeLink + "?Mod=" + lcl_obj_ModuleMenusCompany.ModuleCode;
                            }
                            else {
                                //Check what modules are permitted for the User
                                /******************************************************************/
                                /****************************SET IMAGE*****************************/
                                /******************************************************************/
                                //lcl_obj_UserProfile.ImageData = "data:" + lcl_obj_UserProfile.ImageType + ";base64," + lcl_obj_UserProfile.ImageData;
                                var m_obj_EmployeeImage = "data:" + lcl_obj_UserProfile.Image.ImageType + ";base64," + lcl_obj_UserProfile.Image.ImageData;
                                //alert(m_obj_EmployeeImage);

                                var lcl_str_UserProfileDisplayHTML =
                                    "<div style='width:420px;margin:20px auto;padding:20px;border:2px solid #0078D7;border-radius:15px;background: linear-gradient(45deg, var(--bs-info-bg-subtle), #0600ffe6);color:white;font-family:serif !important;'>" +
                                    "<table id='tblUserCredential' cellpadding='0' cellspacing='0' style='width:100%; border-collapse: collapse; background:transparent;'>" +
                                    // Header
                                    "<thead><th colspan='2' style='font-size:16px;font-weight:bold;padding:10px;text-align:center;background:transparent;color:white;'>" +
                                    "Welcome " + lcl_obj_UserProfile.EmployeeName + "!" +
                                    "</th></thead>" +
                                    "<tbody><tr>" +
                                    "<td colspan='2' style='text-align:center;padding:20px;'>" +
                                    "<div style='padding:15px;border-radius:10px;display:inline-block;background:transparent;'>" +
                                    "<img id='imgImage' style='width:180px;height:230px;border-radius:10px;margin-bottom:10px;' src='" + m_obj_EmployeeImage + "' />" +
                                    "<p style='margin:5px 0;'><strong></strong> " + lcl_obj_UserProfile.EmployeeID + "</p>" +
                                    "<p style='margin:5px 0;'><strong></strong> " + lcl_obj_UserProfile.EmployeeName + "</p>" +
                                    "<p style='margin:5px 0;'><strong></strong> " + lcl_obj_UserProfile.Company.Name + "</p>" +
                                    "</div>" +
                                    "</td>" +
                                    "</tr>" +
                                    // Module Permissions Header
                                    "<thead><th colspan='2' style='text-align:center;padding:10px;font-size:14px;font-weight:bold;background:transparent;color:black;'>MODULE PERMISSIONS</th></thead>" +
                                    "<thead>" +
                                    "<th style='text-align:center;padding:8px;background:#0078D7;color:white;'>MODULE</th>" +
                                    "<th style='text-align:center;padding:8px;background:#0078D7;color:white;'>COMPANIES</th>" +
                                    "</thead>";

                                // Loop through modules
                                $.each(lcl_obj_ModulesMenusCompanies, function (index, lcl_obj_ModuleMenuCompany) {
                                    lcl_str_UserProfileDisplayHTML += "<tr style='border-bottom:1px solid #ddd;'>" +
                                        "<td style='text-align:center;padding:8px;'><a style='color:#673ab7;font-weight:bold;text-decoration:none;' href='" + lcl_obj_ModuleMenuCompany.HomeLink + "?Mod=" + lcl_obj_ModuleMenuCompany.ModuleCode + "'>" +
                                        lcl_obj_ModuleMenuCompany.ModuleName +
                                        "</a></td>";

                                    var lcl_str_Company = "";
                                    $.each(lcl_obj_ModuleMenuCompany.Companys, function (index1, lcl_obj_CompanyCore) {
                                        lcl_str_Company += lcl_obj_CompanyCore.Name + "<br/>";
                                    });

                                    lcl_str_UserProfileDisplayHTML += "<td style='text-align:center;padding:8px;color:#673ab7'>" + lcl_str_Company + "</td></tr>";
                                });

                                lcl_str_UserProfileDisplayHTML += "</tbody></table></div>";

                                // Inject into page
                                $("#userProfileContainer").html(lcl_str_UserProfileDisplayHTML);


                                // Inject into page
                                $("#userProfileContainer").html(lcl_str_UserProfileDisplayHTML);


                                // Inject into page
                                $("#userProfileContainer").html(lcl_str_UserProfileDisplayHTML);


                                // Inject into page
                                $("#userProfileContainer").html(lcl_str_UserProfileDisplayHTML);


                                /******************************************************************/
                                /******************************************************************/
                                /******************************************************************/

                                if (lcl_obj_ModulesMenusCompanies == null) {
                                    DisplayNotification(lcl_str_UserProfileDisplayHTML); // "Your User Credential Has Been Authenticated!Your Module Access Permissions Has either been Revoked or Not Yet Been granted!Contact SSL Support!!!");
                                    return;
                                }
                                $.each(lcl_obj_ModulesMenusCompanies, function (index, lcl_obj_ModuleMenuCompany) {
                                    //alert(lcl_obj_ModuleMenuCompany.Companys.toString());
                                    if (lcl_obj_ModuleMenuCompany.Menus == "") {
                                        DisplayNotification(lcl_str_UserProfileDisplayHTML); //Your User Credential Has Been Authenticated!Module Functionalities Has either been Revoked or Not Yet Been granted!Contact SSL Support!!!");
                                        return;
                                    }
                                    if (lcl_obj_ModuleMenuCompany.Companys == "") {
                                        DisplayInformation("Your User Credential Has Been Authenticated!Your Data Access Permissions has either been Revoked or Not Yet Been granted!Contact SSL Support!!!");
                                        return;
                                    }
                                    //get HomeLink for the first permitted Module
                                    var lcl_str_HomeLink = lcl_obj_ModuleMenuCompany.HomeLink;
                                    //window.location = lcl_str_HomeLink;
                                    return;
                                });
                            }
                            //if Control reaches this point, it can be assumed that the User is not yet permitted to
                            //access any module
                            //DisplaySuccess("You are Authentic User but You have not yet been permitted to access any module of SilkERP360!!!Contact SSL!!!");
                            return;
                        }
                        break;
                    case 1:
                        //error
                        //debugger;
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 2:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 3:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                    case 4:
                        //Critical Error
                        DisplayError(lcl_obj_WSResponse.Message);
                        break;
                }
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
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
            }
        });
}