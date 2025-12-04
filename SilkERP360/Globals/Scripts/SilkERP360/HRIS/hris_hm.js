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
            }
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
}
function ShowErrorMessageBoard(Message) {
    $('#dvMessageBoard').hide('slow', function () {
        $('#spnMessage').css('color', 'white');
        $("#dvMessageBoard span").text(Message);
        $('#dvMessageBoard').css('background-color', 'red');
        $('#dvMessageBoard').show('slow');
    });
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

    const companyName = companyMap[code] || "Unknown Company";
    document.getElementById("footerCompanyName").textContent = companyName;
}

    function initializeSelect2(dropdownId, placeholderText, width, dropdownParentSelector) {
        $('#' + dropdownId).select2({
            placeholder: placeholderText,
            allowClear: true,
            width: width,
            dropdownParent: $(dropdownParentSelector)
        });
    }

function validateFields(obj) {
    const emptyFields = [];

    for (const key in obj) {
        if (obj[key] === null || obj[key] === undefined || obj[key] === '') {
            emptyFields.push(key);
        }
    }

    if (emptyFields.length > 0) {
        return `These fields are required: ${emptyFields.join(', ')}`;
    } else {
        return 'OK';
    }
}

function getAllCompany() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    var result = null;
    $.ajax(
        {
            async: false,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/GetAllCompany",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                result =  WSReturn.Data;
            }
        });
    return result;
}

function getAllEmployee(lcl_str_CompanyCode) {
    var result = null;
    $.ajax(
        {
            async: false,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/CompanyService.asmx/GetAllEmployee",
            data: "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                result = WSReturn.Data;
            }
        });
    return result;
}

function ConvertToOracleDate(value) {
    let dt = new Date(value);

    if (isNaN(dt.getTime())) {
        return null;
    }

    // Month names
    const months = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];

    let formattedDate =
        dt.getDate() + " " +
        months[dt.getMonth()] + " " +
        dt.getFullYear();

    return formattedDate;
}

function FormatDateUniversal(jsonDate) {
    if (!jsonDate) return '';

    let timestamp = null;

    // Handle /Date(1234567890)/
    const match = /Date\((\d+)\)/.exec(jsonDate);
    if (match) {
        timestamp = parseInt(match[1]);
    } else {
        // Normal ISO or common date strings
        timestamp = Date.parse(jsonDate);
    }

    if (isNaN(timestamp)) return '';

    const date = new Date(timestamp);

    const day = String(date.getDate()).padStart(2, '0');
    const monthNames = [
        "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November", "December"
    ];
    const month = monthNames[date.getMonth()];
    const year = date.getFullYear();

    return `${day}/${month}/${year}`;
}
function getFirstDay() {
    var d = new Date();
    return "01/" + (("0" + (d.getMonth() + 1)).slice(-2)) + "/" + d.getFullYear();
}

var dateFormat = "dd/mm/yy"; // or whatever format you want

function getLastDay() {
    var d = new Date();
    var last = new Date(d.getFullYear(), d.getMonth() + 1, 0);
    return (("0" + last.getDate()).slice(-2)) + "/" + (("0" + (last.getMonth() + 1)).slice(-2)) + "/" + last.getFullYear();
}

function getAllApprovers(dropdownId) {
    var selectedValue = $('#' + dropdownId + ' option:selected').val();
    var result = null;

    $.ajax({
        async: false, // Note: synchronous AJAX is generally discouraged
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/GetAllApprovers",
        dataType: "json",
        data: JSON.stringify({ companyCode: selectedValue }), // assuming service expects { companyCode: "value" }
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }
            result = WSReturn.Data;
        }
    });

    return result;
}

function bindAllAprovers(dropdownId) {
    var approvers = getAllApprovers(dropdownId);
    var $approverSelect = $('#'+dropdownId);

    // Clear existing options
    $approverSelect.empty();

    // Populate new options
    $.each(approvers, function (index, approver) {
        var option = $('<option></option>')
            .attr('value', approver.EmployeeCode)  // Fixed closing parenthesis
            .text(approver.EmployeeId + ' [' + approver.EmployeeName + ']');

        $approverSelect.append(option);
    });

    // Refresh Select2 (if applied)
    $approverSelect.trigger('change');
}

function clearModalFields(modalId) {
    const modal = document.getElementById(modalId);
    if (!modal) return;

    const fields = modal.querySelectorAll('input, textarea, select');

    fields.forEach(field => {
        const type = field.type;

        switch (type) {
            case 'text':
            case 'email':
            case 'tel':
            case 'url':
            case 'number':
            case 'password':
            case 'hidden':
            case 'search':
            case 'date':
            case 'datetime-local':
            case 'month':
            case 'week':
            case 'time':
            case 'color':
                field.value = '';
                break;

            case 'checkbox':
            case 'radio':
                field.checked = false;
                break;

            default:
                if (field.tagName.toLowerCase() === 'textarea') {
                    field.value = '';
                } else if (field.tagName.toLowerCase() === 'select') {
                    field.selectedIndex = 0;
                }
                break;
        }
    });
}