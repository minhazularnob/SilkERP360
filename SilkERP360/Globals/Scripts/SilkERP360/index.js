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
                                var m_obj_EmployeeImage = "data:" + lcl_obj_UserProfile.Image.ImageType + ";base64," + lcl_obj_UserProfile.Image.ImageData;

                                var lcl_str_UserProfileDisplayHTML = `
                                                <div style="max-width:500px;margin:0 auto;font-family:'Times New Roman', Times, serif;">
                                                    <!-- Welcome Text -->
                                                    <p style="margin:5px 0;font-size:16px;font-weight:bold;text-align:center;color:#333;">Welcome ${lcl_obj_UserProfile.EmployeeName}</p>

                                                    <!-- Employee Card Frame with Soft Background -->
                                                    <div style="background: #e0f0ff; padding:10px; text-align:center; box-shadow:0 2px 6px rgba(0,0,0,0.1); border-radius:8px; margin-bottom:10px; color:#333;">
                                                        <!-- Employee Image -->
                                                        <img src="${m_obj_EmployeeImage}" alt="Employee Image" style="width:30%;object-fit:contain;margin-bottom:10px; border-radius:6px;"/>

                                                        <!-- Employee Info under Image -->
                                                        <div>
                                                            <p style="margin:2px 0;font-weight:bold;font-size:14px;">ID: ${lcl_obj_UserProfile.EmployeeID}</p>
                                                            <p style="margin:2px 0;font-weight:bold;font-size:15px;">${lcl_obj_UserProfile.EmployeeName}</p>
                                                            <p style="margin:2px 0;font-size:13px;">${lcl_obj_UserProfile.Company.Name}</p>
                                                        </div>
                                                    </div>

                                                    <!-- Module Permissions Table -->
                                                    <div style="max-height:200px;overflow-y:auto;border:1px solid #ccc;border-radius:6px;">
                                                        <table style="width:100%;border-collapse:collapse;text-align:center;font-size:13px;">
                                                            <thead style="position:sticky;top:0;background:#d9eaff;">
                                                                <tr>
                                                                    <th style="padding:6px;border-bottom:1px solid #ccc;">Module</th>
                                                                    <th style="padding:6px;border-bottom:1px solid #ccc;">Companies</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>`;

                                                                                // Add module rows with subtle alternate colors
                                                                                $.each(lcl_obj_ModulesMenusCompanies, function (index, lcl_obj_ModuleMenuCompany) {
                                                                                    var lcl_str_Company = "";
                                                                                    $.each(lcl_obj_ModuleMenuCompany.Companys, function (index1, lcl_obj_CompanyCore) {
                                                                                        lcl_str_Company += lcl_obj_CompanyCore.Name + "<br/>";
                                                                                    });

                                                                                    var rowBackground = index % 2 === 0 ? "#f0f8ff" : "#ffffff"; // alternating row colors

                                                                                    lcl_str_UserProfileDisplayHTML += `
                                                        <tr style="background:${rowBackground};">
                                                            <td style="padding:6px;border-bottom:1px solid #eee;">
                                                                <a href="${lcl_obj_ModuleMenuCompany.HomeLink}?Mod=${lcl_obj_ModuleMenuCompany.ModuleCode}" style="color:#394860;text-decoration:none;font-weight:500;">
                                                                    ${lcl_obj_ModuleMenuCompany.ModuleName}
                                                                </a>
                                                            </td>
                                                            <td style="padding:6px;border-bottom:1px solid #eee;">${lcl_str_Company}</td>
                                                        </tr>
                                                    `;
                                                                                });

                                                                                lcl_str_UserProfileDisplayHTML += `
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                `;

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