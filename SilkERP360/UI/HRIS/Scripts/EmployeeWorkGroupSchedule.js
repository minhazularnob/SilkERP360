$(document).ready(function () {

    initDatePicker();
    initGrid();

});

/* =========================
   INITIALIZE DATE PICKER
========================= */

function initDatePicker() {

    $("#txtScheduleDate").datepicker({
        dateFormat: 'dd/MM/yy',
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true
    });

}

/* =========================
   INITIALIZE SIMPLE GRID
========================= */

function initGrid() {
    $("#tblWorkGroupSchedule tbody").empty();
}

/* =========================
   FETCH DATA (AJAX)
========================= */

async function GetEmployeeSchedule() {

    const companyCode = $('#ddlCompany').val();
    const scheduleDate = $('#txtScheduleDate').val();

    if (!scheduleDate) {
        DisplayError("Please Select Date!");
        return;
    }

    try {

        const response = await $.ajax({
            url: gbl_URL_Root + "WebServices/HRIS/WorkGroupServices.asmx/GetEmployeeWorkGroupScheduleByDate",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                IP_ui64_CompanyCode: companyCode,
                IP_dt_Date: scheduleDate
            })
        });

        const wsResponse = response.d;

        if (wsResponse.ResponseCode === 0) {
            loadSchedule(wsResponse.Data);
        } else {
            DisplayError(wsResponse.Message);
        }

    } catch (error) {
        ShowErrorMessageBoard(error.statusText);
    }
}

/* =========================
   LOAD GRID DATA
========================= */

function loadSchedule(dataList) {

    const $tbody = $("#tblWorkGroupSchedule tbody");
    $tbody.empty();

    if (!dataList || dataList.length === 0) {

        $tbody.append(`
            <tr>
                <td colspan="8" style="text-align:center;">
                    No Data Found
                </td>
            </tr>
        `);

        return;
    }

    dataList.forEach((item, index) => {

        const dutyFrom = formatDotNetDate(item.DutyScheduleFrom);
        const dutyUpto = formatDotNetDate(item.DutyScheduleUpto);

        const bgColor = item.WorkGroupOperationMasterCode === "0"
            ? "#ffcccc"
            : "#ccffcc";

        const row = `
            <tr>
                <td style="text-align:center;font-weight:bold;">
                    ${index + 1}
                </td>
                <td style="background:${bgColor}">
                    ${item.EmployeeId || ''}
                </td>
                <td>${item.EmployeeName || ''}</td>
                <td>${item.Designation || ''}</td>
                <td>${item.Department || ''}</td>
                <td>
                    ${item.WorkGroupName || 'WorkGroup Not Assigned'}
                </td>
                <td>${dutyFrom}</td>
                <td>${dutyUpto}</td>
            </tr>
        `;

        $tbody.append(row);
    });
}

/* =========================
   DATE FORMATTER (.NET)
========================= */

function formatDotNetDate(dotNetDate) {

    if (!dotNetDate) return '';

    const date = new Date(parseInt(dotNetDate.substr(6)));

    const day = ("0" + date.getDate()).slice(-2);
    const month = ("0" + (date.getMonth() + 1)).slice(-2);
    const year = date.getFullYear().toString().slice(-2);

    let hours = date.getHours();
    const minutes = ("0" + date.getMinutes()).slice(-2);
    const ampm = hours >= 12 ? 'PM' : 'AM';

    hours = hours % 12;
    hours = hours ? hours : 12;

    return `${day}.${month}.${year} ${hours}:${minutes} ${ampm}`;
}