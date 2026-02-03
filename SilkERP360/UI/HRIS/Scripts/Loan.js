$(document).ready(function () {
    $("#loanHistory_txtStartDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getFirstDay(),
        onSelect: function (d) {
            const min = $.datepicker.parseDate(dateFormat, d);
            $("#loanHistory_txtEndDate").datepicker("option", "minDate", min);
            LoadEmployeeLoanList();
        }
    });

    // End Date Picker
    $("#loanHistory_txtEndDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getLastDay(),
        onSelect: function (d) {
            const max = $.datepicker.parseDate(dateFormat, d);
            $("#loanHistory_txtStartDate").datepicker("option", "maxDate", max);
            LoadEmployeeLoanList();
        }

    });

    $("#loanHistory_txtStartDate").val(getFirstDay());
    $("#loanHistory_txtEndDate").val(getLastDay());

    GBL_EMPLOYEE_LOAN_LIST_TABLE = $('#tblEmployeeLoanList').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": true,
        "bSearch": true,
        "responsive": true,
        "oLanguage": {
            "sEmptyTable": "No Loan  Data Available",
            "sZeroRecords": "No Employee Loan History Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { "mData": "SL", "sTitle": "Sl.", "sWidth": "5%", "sClass": "alignCenter", "bVisible": true },
            { "mData": "LoanCode", "sTitle": "Loan Code", "sClass": "alignCenter", "bVisible": false },
            { "mData": "EmployeeCode", "sTitle": "Employee Code", "sClass": "alignCenter", "bVisible": false },
            { "mData": "EmployeeId", "sTitle": "Employee ID", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Employee Name", "sWidth": "15%", "sClass": "alignCenter" },
            {
                "mData": "LoanType", "sTitle": "Type", "sWidth": "15%", "sClass": "alignCenter", "mRender": function (data, type, row) {
                    const loanTypes = {
                        1: "Staff Loan",
                        2: "Salary Advance",
                        3: "Vehicle Loan",
                        4: "Housing Loan",
                        5: "Medical Loan",
                        6: "Education Loan",
                        7: "Festival Loan",
                        8: "Emergency Loan"
                    };
                    return loanTypes[data] || "-";
                }
            },
            { "mData": "LoanAmount", "sTitle": "Loan Amount", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "TotalPaidAmount", "sTitle": "Total Paid Amount", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "CurrentDueAmount", "sTitle": "Current Due Amount", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "NoOfInstallments", "sTitle": "No of Ins.", "sWidth": "10%", "sClass": "alignCenter" },
            {
                "mData": "LoanDisburseDate",
                "sTitle": "Disbursement Date",
                "sWidth": "10%",
                "sClass": "alignCenter",
                "mRender": function (data, type, row) {
                    if (!data) return "-"; // safety
                    var d = new Date(data); // server theke asha date string
                    var day = ('0' + d.getDate()).slice(-2);
                    var month = ('0' + (d.getMonth() + 1)).slice(-2);
                    var year = d.getFullYear();
                    return day + '/' + month + '/' + year;
                }
            },
            {
                "mData": "InstallmentStartMonth", "sTitle": "Ins. Start Month", "sWidth": "10%", "sClass": "alignCenter", "mRender": function (data, type, row) {
                    const months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                    if (data >= 1 && data <= 12) return months[data - 1];
                    return "-";
                }
            },
            { "mData": "InstallmentStartYear", "sTitle": "Ins. Start Year", "sWidth": "10%", "sClass": "alignCenter" },
            {
                "mData": "Status", "sTitle": "Status", "sWidth": "10%", "sClass": "alignCenter", "mRender": function (data, type, row) {
                    if (data == 1)
                        return '<span style="color:orange;font-weight:bold;">Running</span>';
                    else if (data == 0)
                        return '<span style="color:green;font-weight:bold;">Closed</span>';
                    else
                        return '<span>-</span>';
                }
            }
        ]
    });

    $('#tblEmployeeLoanList tbody').on('click', 'tr', function () {

        var rowData = GBL_EMPLOYEE_LOAN_LIST_TABLE.fnGetData(this);
        if (!rowData) return;

        openLoanEditModal(rowData);
    });


    let loanAmount = 0;

    // Generate schedule inside modal
    LoadEmployeeLoanList();
});

function openLoanEditModal(data) {
    clearLoanModal();
    $('#loanModal').modal('show');
    $('.edit-only').show();
    $('#loanCode').val(data.LoanCode);
    $('#createSchedule').hide();
    loadEmployee();
    loadStartYearDropdown('startYear');
    $('#employeeIdLoan').val(data.EmployeeCode).trigger('change');
    $('#loanTypeId').val(data.LoanType).trigger('change');
    $('#loanAmount').val(data.LoanAmount);
    $('#installments').val(data.NoOfInstallments);
    $('#month').val(data.InstallmentStartMonth - 1).trigger('change');
    $('#startYear').val(data.InstallmentStartYear).trigger('change');
    $('#loanDisburseDate').val(formatDate(data.LoanDisburseDate));

    setLoanFormReadOnly();
    loadLoanSchedule(data.LoanCode);
}

function loadDatepickerForDisbursement() {
    $("#loanDisburseDate").datepicker({
        dateFormat: 'dd/MM/yy',
        showButtonPanel: true,
        maxDate: "+365D",
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            console.log("Selected date:", d);
        }
    });
}

function formatDate(rawDateStr) {
    if (!rawDateStr) return "";

    var rawDate = new Date(rawDateStr);

    if (isNaN(rawDate.getTime())) return ""; // Invalid date safety

    var day = ('0' + rawDate.getDate()).slice(-2);
    var month = ('0' + (rawDate.getMonth() + 1)).slice(-2); // JS month is 0-based
    var year = rawDate.getFullYear().toString().slice(-2);

    return day + '/' + month + '/' + year;
}


function loadLoanSchedule(loanCode) {
    $.ajax({
        type: "POST",
        url: gbl_URL_Root + "WebServices/HRIS/StaffLoanService.asmx/GetLoanSchedule",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ IP_ui64_LoanCode: loanCode }),
        success: function (response) {

            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            var schedules = WSReturn.Data;
            $('#scheduleBody').empty();

            $.each(schedules, function (i, s) {
                $('#scheduleBody').append(`
                    <tr data-loan-schedule-code="${s.LoanScheduleCode}" data-month="${s.Month - 1}" data-year="${s.Year}" data-scheduled="${s.ScheduledAmount}">
                        <td>${i + 1}</td>
                        <td>${getMonthName(s.Month - 1)}</td>
                        <td>${s.Year}</td>
                        <td class="text-end">${s.ScheduledAmount}</td>
                        <td class="text-end">
                            ${renderPaidAmountCell(s.Status, s.PaidAmount, i)}
                        </td>
                        <td>${getScheduleStatus(s.Status)}</td>
                    </tr>
                `);
            });
        }
    });
}

function renderPaidAmountCell(status, paidAmount, index) {
    status = parseInt(status);
    paidAmount = paidAmount || 0;

    // Unpaid → editable input
    if (status === 0) {
        return `
            <input type="number"
                   class="form-control form-control-sm text-end paid-input"
                   value="${paidAmount}"
                   data-index="${index}"
                   min="0" style="height: 26px; padding: 2px 6px;" />
        `;
    }

    // Paid / Partial → readonly text
    return `<span class="text-muted">${paidAmount}</span>`;
}


function getScheduleStatus(status) {
    switch (parseInt(status)) {
        case 0:
            return '<span class="badge bg-danger">Unpaid</span>';
        case 1:
            return '<span class="badge bg-success">Paid</span>';
        case 2:
            return '<span class="badge bg-warning text-dark">Partial</span>';
        default:
            return '-';
    }
}



function setLoanFormReadOnly(isReadOnly) {

    // input
    $('#loanAmount').prop('readonly', isReadOnly);
    $('#installments').prop('readonly', isReadOnly);

    // select2 / dropdown
    $('#employeeIdLoan').prop('disabled', isReadOnly);
    $('#loanTypeId').prop('disabled', isReadOnly);
    $('#month').prop('disabled', isReadOnly);
    $('#startYear').prop('disabled', isReadOnly);

    // buttons
    $('#createSchedule').prop('disabled', isReadOnly);
    $('#loanSaveId').prop('disabled', isReadOnly);
}

function LoadEmployeeLoanList() {
    from = $('#loanHistory_txtStartDate').val();
    to = $('#loanHistory_txtEndDate').val();
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/StaffLoanService.asmx/GetEmployeeLoanList",
        data: JSON.stringify({
            IP_ui64_companyCode: lcl_str_CompanyCode,
            from: from,
            to: to
        }),
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            var lcl_obj_EmployeeLoanList = WSReturn.Data;

            // Clear existing table data
            GBL_EMPLOYEE_LOAN_LIST_TABLE.fnClearTable();

            var mappedData = [];
            $.each(lcl_obj_EmployeeLoanList, function (index, item) {
                mappedData.push({
                    "SL": index + 1, // ← Serial Number
                    "EmployeeCode": item.EmployeeCode,
                    "EmployeeId": item.EmployeeId,
                    "EmployeeName": item.EmployeeName,
                    "LoanCode": item.LoanCode,
                    "LoanAmount": item.LoanAmount,
                    "LoanType": item.LoanType,
                    "NoOfInstallments": item.NoOfInstallments,
                    "LoanDisburseDate": item.LoanDisburseDate,
                    "InstallmentStartMonth": item.InstallmentStartMonth,
                    "InstallmentStartYear": item.InstallmentStartYear,
                    "CurrentDueAmount": item.CurrentDueAmount,
                    "EntryDate": item.EntryDate,
                    "TotalPaidAmount": item.TotalPaidAmount,
                    "Status": item.Status
                });
            });

            // Add mapped data to DataTable
            GBL_EMPLOYEE_LOAN_LIST_TABLE.fnAddData(mappedData);
            GBL_EMPLOYEE_LOAN_LIST_TABLE.fnDraw();
        },
        error: function (err) {
            console.error("Error loading Loan history:", err);
        }
    });
}


$('#createSchedule').click(function () {
    const employee = $('#employeeIdLoan').val();
    const loanAmount = parseFloat($('#loanAmount').val());
    const ins = parseInt($('#installments').val());
    let startMonth = parseInt($('#month').val());
    let startYear = parseInt($('#startYear').val());
    let disburseDate= $('#loanDisburseDate').val();

    if (!employee || !loanAmount || !ins || !startYear || !disburseDate) {
        alert("Fill all fields");
        return;
    }

    const per = (loanAmount / ins).toFixed(2);

    $('#scheduleBody').empty();

    let month = startMonth;
    let year = startYear;

    for (let i = 0; i < ins; i++) {

        $('#scheduleBody').append(`
                <tr data-month="${month}" data-year="${year}" data-scheduled="${per}">
                <td>${i + 1}</td>
                <td>${getMonthName(month)}</td>
                <td>${year}</td>
                <td class="text-end">${per}</td>
             </tr>
            `);

        // move to next month
        month++;
        if (month > 11) {
            month = 0;
            year++; // year auto increase
        }
    }
});

function getMonthName(idx) {
    const months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
    return months[idx];
}

function OpenModal() {
    $('#loanModal').modal('show');
    $('.edit-only').hide();
    $('#createSchedule').show();
    loadEmployee();
    loadDatepickerForDisbursement();
    loadStartYearDropdown('startYear');
}

function loadEmployee() {
    var companyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: false,
        type: "POST",
        url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetAllActiveEmployeeByCompany",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ IP_ui64_CompanyCode: companyCode }),
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }
            var datas = WSReturn.Data;
            var $dropdown = $('#employeeIdLoan');

            $dropdown.empty();
            $dropdown.append('<option></option>');
            // Populate options
            $.each(datas, function (index, employee) {
                $dropdown.append(
                    $('<option></option>').val(employee.EmployeeCode).text(`${employee.EmployeeName} [${employee.EmployeeID}]`)
                );
            });

            if ($dropdown.hasClass('select2-hidden-accessible')) {
                $dropdown.trigger('change');
            } else {
                initializeSelect2('employeeIdLoan', 'Select Employee', '95%', '#loanModal');
                initializeSelect2('month', 'Select Month', '95%', '#loanModal');
                initializeSelect2('startYear', 'Select Year', '95%', '#loanModal'); 
                initializeSelect2('loanTypeId', 'Select Loan Type', '95%', '#loanModal');
            }
        },
        error: function (xhr, status, error) {
            console.error("Error loading employees:", error);
        }
    });
}

// Initialize Select2
function initializeSelect2(dropdownId, placeholderText, width, dropdownParentSelector) {
    $('#' + dropdownId).select2({
        placeholder: placeholderText,
        allowClear: true,
        width: width,
        dropdownParent: $(dropdownParentSelector)
    });
}

function loadStartYearDropdown(dropdownId) {
    const currentYear = new Date().getFullYear();
    const $year = $('#' + dropdownId);

    $year.empty(); // safety: clear existing
    $year.append('<option value="">Select Year</option>');

    for (let y = currentYear - 2; y <= currentYear + 5; y++) {
        $year.append(`<option value="${y}">${y}</option>`);
    }
    // default select current year
    $year.val(currentYear);
}

$('#installments').on('input blur', function () {
    let val = $(this).val();
    // remove decimals
    val = val.replace(/[^0-9]/g, '');
    let num = parseInt(val || 0);
    if (num > 360) num = 360;
    if (num < 1 && val !== '') num = 1;
    $(this).val(num || '');
});

// ----------------- Helper Functions -----------------

function getPaidSchedulesFromTable() {
    const totalLoanAmount = parseFloat($('#loanAmount').val()) || 0;
    let totalPaidSoFar = 0;
    let hasError = false;
    let result = [];

    $('#scheduleBody tr').each(function () {
        if (hasError) return false; // break loop

        const $tr = $(this);
        const loanScheduleCode = $tr.data('loan-schedule-code');
        const paidAmount = parseFloat($tr.find('.paid-input').val()) || 0;
        const status = $tr.find('td:last').text().trim();

        if (!loanScheduleCode || paidAmount <= 0 || status !== "Unpaid") return;

        totalPaidSoFar += paidAmount;

        // ❌ simple loan amount check
        if (totalPaidSoFar > totalLoanAmount) {
            DisplayError("Paid amount total cannot exceed Loan Amount!");
            $tr.find('.paid-input').focus();
            hasError = true;
            return false; // stop processing
        }

        result.push({
            LoanScheduleCode: loanScheduleCode,
            PaidAmount: paidAmount
        });
    });

    if (hasError) return null;

    return result;
}



// Get full installment schedules from table
function getInstallmentSchedulesFromTable() {
    return $('#scheduleBody tr').map(function () {
        const $tr = $(this);
        return {
            Month: parseInt($tr.data('month')) + 1,
            Year: parseInt($tr.data('year')),
            ScheduledAmount: parseFloat($tr.data('scheduled')) || 0
        };
    }).get();
}

// AJAX POST helper
function postJSON(url, data, successMsg) {
    $.ajax({
        async: false,
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (response) {
            const WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) return DisplayError(WSReturn.Message);
            if (successMsg) DisplayInformation(successMsg);
        },
        error: function (err) {
            console.error("AJAX error:", err);
            DisplayError("An error occurred during server request.");
        }
    });
}

// ----------------- Main Functions -----------------

function SaveInstallmentAmount(loanCode) {
    const scheduleList = getPaidSchedulesFromTable();
    if (!scheduleList.length) return alert("No updates to save.");

    // Attach LoanCode to each item
    scheduleList.forEach(s => s.LoanCode = loanCode);

    postJSON(
        `${gbl_URL_Root}WebServices/HRIS/StaffLoanService.asmx/UpdateLoanPaidAmounts`,
        { IP_objLst_StaffLoanSchedule: scheduleList },
        "Paid amounts updated successfully!"
    );

    loadLoanSchedule($('#loanCode').val());
    LoadEmployeeLoanList();
}


function SaveStaffLoan() {
    const loanCode = $('#loanCode').val();
    if (loanCode) return SaveInstallmentAmount(loanCode);

    const employeeCode = $('#employeeIdLoan').val();
    const loanType = $('#loanTypeId').val();
    const loanAmount = parseFloat($('#loanAmount').val()) || 0;
    const installments = parseInt($('#installments').val()) || 0;
    const startMonth = parseInt($('#month').val());
    const startYear = parseInt($('#startYear').val());
    const disbursedDate = $('#loanDisburseDate').val();

    if (!employeeCode || !loanType || !loanAmount || !installments || !startYear)
        return DisplayError("Please fill all required fields.");

    const loanData = {
        EmployeeCode: employeeCode,
        LoanAmount: loanAmount,
        LoanType: loanType,
        NoOfInstallments: installments,
        InstallmentStartMonth: startMonth + 1,
        InstallmentStartYear: startYear,
        LoanDisburseDate: disbursedDate,
        Installments: getInstallmentSchedulesFromTable()
    };

    if(loanData.Installments.length == 0) return DisplayError("Generate installment schedule first.");

    postJSON(
        `${gbl_URL_Root}WebServices/HRIS/StaffLoanService.asmx/SaveStaffLoan`,
        { IP_objLst_StaffLoan: loanData },
        "Loan saved successfully!"
    );

    $('#loanModal').modal('hide');
    clearLoanModal();
    LoadEmployeeLoanList();
}


function clearLoanModal() {
    $('#loanCode').val('');
    $('#employeeIdLoan').val(null).trigger('change');
    $('#loanTypeId').val(null).trigger('change');

    $('#loanAmount').val('');
    $('#installments').val('');

    $('#month').val(null).trigger('change');
    $('#startYear').val(null).trigger('change');
    $("#loanDisburseDate").datepicker('destroy'); // Remove existing datepicker
    $('#loanDisburseDate').val('');
    $('#scheduleBody').empty();
}