var gbl_obj_CompanyDepartments = new Object(); //Stores DepartmentCore Objects, CompanyCode wise
$(document).ready(function () {
    $('div').css("font-family", "Verdana");
    $('#dvHMenu').html(lcl_str_HorizontalMenuHTML); //lcl_str_HorizontalMenuHTML variable in scpm_hm code behind
    loadEmployeeComapanyLogo();
    setCompanyName($('#companyIdHidden').val());
});
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

function Logout() {
    if (confirm("Are You sure, you want to log out?")) {
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/UserServices.asmx/Logout",
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

function expandSidebar() {
    const sidebar = document.getElementById("sidebar");
    const img = document.getElementById("sideBarIcon");
    sidebar.style.width = "226px";
    img.style.display = "none"; // Hide the image
}

function collapseSidebar() {
    const sidebar = document.getElementById("sidebar");
    const img = document.getElementById("sideBarIcon");
    sidebar.style.width = "0px";
    img.style.display = "block"; // Show the image again
}

function setCompanyName(code) {
    const companyMap = {
        "110000000002": "Wellpac Polymers Ltd.",
        "110000000001": "Silkways Card & Printing Ltd.",
        "110000000004": "Silkways Tours & Travels Ltd.",
        "110000000018": "Silkways Agro Ltd",
        "110000000019": "Silkways Cargo Services Ltd",
        "110000000003": "Silkways Solutions Ltd."
    };

    const companyName = companyMap[code] || "Unknown Company";
    //document.getElementById("footerCompanyName").textContent = companyName;
}

function generateCompanyimagePath(companyCode) {
    var imagePath = '';
    switch (companyCode) {
        case '110000000001':
            imagePath = '../../Globals/Images/Silkways_card&printing_ltd.png';
            break;
        case '110000000002':
            imagePath = '../../Globals/Images/wellpac_Logo.png';
            break;
        case '110000000018':
            imagePath = '../../Globals/Images/Silkways_Agro_Logo.png';
            break;
        case '110000000004':
            imagePath = '../../Globals/Images/Silkways_Tours&Travels_Logo.png';
            break;
        case '110000000019':
            imagePath = '../../Globals/Images/Silkways_Cargo_Service_Logo.png';
            break;
        case '110000000003':
            imagePath = '../../Globals/Images/Silkways_Solutions_Logo.png';
            break;
        default:
            imagePath = '';
            break;
    }
    return imagePath;
}

function loadEmployeeComapanyLogo() {

    var companyCode = $('#companyIdHidden').val();

    $('#companyLogoForEmployee').attr('src', generateCompanyimagePath(companyCode));

    if (companyCode == "110000000003") {
        $('#companyLogoForEmployee').height(45);
    }
    else if (companyCode == '110000000001') {
        $('#companyLogoForEmployee').height(55);

    }
    else {
        $('#companyLogoForEmployee').height(70);
    }
};


/***************************************************************************************************************/
/***************************************************************************************************************/

