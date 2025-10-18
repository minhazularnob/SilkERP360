var gbl_obj_CompanyDepartments = new Object(); //Stores DepartmentCore Objects, CompanyCode wise
$(document).ready(function () {

    //WELLCOME MESSAGE
    var lcl_str_EmpName = $("#txtName").text();
    var lcl_str_Msg = "Welcome " + lcl_str_EmpName + " !!!";
    //HideMessageBoard();
    ShowMessageBoard(lcl_str_Msg);
    //ShowInfoMessageBoard("INFO MESSAGE BOARD");
    //Hook Company Changed Event
    //$('#ddlCompany').change(function () { EvntCompanyChanged();});
    $('div').css("font-family", "Verdana");
    //ConfigureMenu();
    //$('#hrisFuncMenu').menu();
    $('#dvHMenu').html(lcl_str_HorizontalMenuHTML);
    //Hook CompanyChangeEvent
    loadEmployeeComapanyLogo();
    setCompanyName($('#companyIdHidden').val());
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
function Refresh(event) {
    $('#dvUIContainer').css({ "visibility": "visible" }).fadeOut('slow', function () {
        $('#dvUIContainer').html("");    
    });
    event.preventDefault();
}
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

function expandSidebar() {
    const sidebar = document.getElementById("sidebar");
    const img = document.getElementById("sideBarIcon");
    sidebar.style.width = "300px";
    img.style.display = "none"; // Hide the image
}

function collapseSidebar() {
    const sidebar = document.getElementById("sidebar");
    const img = document.getElementById("sideBarIcon");
    sidebar.style.width = "15px";
    img.style.display = "block"; // Show the image again
}

document.addEventListener('DOMContentLoaded', function () {
    new TomSelect("#ddlCompany", {
        create: false,           // allows typing custom value when true (combo box behavior)
        closeAfterSelect: true,
        sortField: {
            field: "text",
            direction: "asc"
        },
        placeholder: "Select Company",
        onItemAdd: function () {
            this.control_input.blur(); // 👈 Forces blur immediately after selection
        }
    });
});

function changeCompanyLogo() {
    var companyCode = $(this).val();
    const $logoDiv = $('#companyLogoDiv');

    

    $('#comapanyLogo').attr('src', generateCompanyimagePath(companyCode));
    // Apply dimensions and object-fit
    if (companyCode === '') {
        $logoDiv.hide();
    }
    else {
        $logoDiv.show();
        if (companyCode == "110000000003") {
            $('#comapanyLogo').height(36);
        }
        else {
            $('#comapanyLogo').height(50);

        }
    }
};

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

function setCompanyName(code) {
    const companyMap = {
        "110000000002": "Wellpac Polymers Ltd.",
        "110000000001": "Silkways Card & Printing Ltd.",
        "110000000004": "Silkways Tours & Travels Ltd.",
        "110000000018": "Silkways Agro Ltd",
        "110000000019": "Silkways Cargo Services Ltd",
        "110000000003": "Silkways Solutions Ltd."
    };

    console.log(companyMap[code]);
    const companyName = companyMap[code] || "Unknown Company";
    document.getElementById("footerCompanyName").textContent = companyName;
}


