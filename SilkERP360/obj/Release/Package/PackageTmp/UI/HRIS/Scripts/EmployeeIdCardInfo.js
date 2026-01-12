$(document).ready(function () {
    //Load Medical Information();
    initializeSelect2('ddlEmployeeId', 'Select Employee', '35%');
});

function GetEmployeeIdCardInfo() {
    var lcl_str_EmployeeCode = $('#ddlEmployeeId option:selected').val();

    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetEmployeeIdCardInfo",
            data: "{IP_ui64_EmployeeCode: " + JSON.stringify(lcl_str_EmployeeCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                else {
                    $('#lblEmployeeId').text(WSReturn.Data.EmployeeId);
                    $('#lblEmployeeName').text(WSReturn.Data.EmployeeName);
                    $('#lblJoiningDate').text(FormatDate(WSReturn.Data.JoiningDate));
                    $('#lblCompanyName').text(WSReturn.Data.CompanyName);
                    $('#lblDepartment').text(WSReturn.Data.DepartmentName);
                    $('#lblDesignation').text(WSReturn.Data.DesignationName);
                    $('#lblBloodGroup').text(WSReturn.Data.BloodGroup);
                    $('#lblCitizenCardId').text(WSReturn.Data.CitizenCardID);
                    $('#lblMobileNo').text(WSReturn.Data.MobileNo);
                    if (WSReturn.Data.EmployeePhotoBase64) {
                        $('#imgEmployeePhoto').attr('src', WSReturn.Data.EmployeePhotoBase64);
                    } else {
                        $('#imgEmployeePhoto').attr('src', '/images/default-user.png');
                    }
                }
            }
        });
}

function FormatDate(jsonDate) {
    var date = new Date(parseInt(jsonDate.substr(6)))
    var d = date.getDate(), m = date.getMonth() + 1, y;
    if (date.getFullYear) { y = date.getFullYear(); }
    else { y = 2000 + (date.getYear() % 100); }
    return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
}

$('#btnDownloadPhoto').on('click', function () {
    var img = $('#imgEmployeePhoto').attr('src'); // current image src
    if (!img || img.includes("default-user.png")) {
        alert("No photo available to download!");
        return;
    }

    // Create a temporary link to download
    var a = document.createElement('a');
    a.href = img;
    a.download = $('#lblEmployeeName').text() + "_photo.png";
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
});

$('#btnCopyTable').on('click', function () {
    var tableHtml = document.getElementById('tblEmployeeInfo').outerHTML;

    // Create temporary element for copy
    var tempElem = document.createElement('div');
    tempElem.style.position = 'absolute';
    tempElem.style.left = '-9999px';
    tempElem.innerHTML = tableHtml;
    document.body.appendChild(tempElem);

    // Select & copy
    var range = document.createRange();
    range.selectNodeContents(tempElem);
    var selection = window.getSelection();
    selection.removeAllRanges();
    selection.addRange(range);

    try {
        var successful = document.execCommand('copy');
        alert('Copied');
    } catch (err) {
        console.error('Copy failed', err);
    }

    // Clean up
    selection.removeAllRanges();
    document.body.removeChild(tempElem);
});

$('#ddlEmployeeId').on('change', function () {
    // GetEmployeeIdCardInfo function call
    GetEmployeeIdCardInfo();
});