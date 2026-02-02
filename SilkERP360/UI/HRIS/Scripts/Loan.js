$(document).ready(function () {

    GBL_EMPLOYEE_LOAN_LIST_TABLE = $('#tblEmployeeLoanList').dataTable({
        "bJQueryUI": false,
        "bFilter": false,
        "bPaginate": false,
        "bLengthChange": true,
        "bSearch": false,
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
            { "mData": "NoOfInstallments", "sTitle": "No of Ins.", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "LoanDisburseDate", "sTitle": "Disbursement Date", "sWidth": "10%", "sClass": "alignCenter" },
            {
                "mData": "InstallmentStartMonth", "sTitle": "Ins. Start Month", "sWidth": "10%", "sClass": "alignCenter", "mRender": function (data, type, row) {
                    const months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                    if (data >= 1 && data <= 12) return months[data - 1];
                    return "-";
                }
            },
            { "mData": "InstallmentStartYear", "sTitle": "Ins. Start Year", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "CurrentDueAmount", "sTitle": "Current Due Amount", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "TotalPaidAmount", "sTitle": "Total Paid Amount", "sWidth": "10%", "sClass": "alignCenter" },
            {
                "mData": "Status", "sTitle": "Status", "sWidth": "10%", "sClass": "alignCenter", "mRender": function (data, type, row) {
                    if (data == 1) return "Running";
                    else if (data == 0) return "Closed";
                    else return "-";
                }
            }
        ]
    });

    let loanAmount = 0;

    // Generate schedule inside modal
    LoadEmployeeLoanList();
});

function LoadEmployeeLoanList() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/StaffLoanService.asmx/GetEmployeeLoanList",
        data: JSON.stringify({
            IP_ui64_companyCode: lcl_str_CompanyCode,
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
    debugger;
    const employee = $('#employeeIdLoan').val();
    const loanAmount = parseFloat($('#loanAmount').val());
    const ins = parseInt($('#installments').val());
    let startMonth = parseInt($('#month').val());
    let startYear = parseInt($('#startYear').val());

    if (!employee || !loanAmount || !ins || !startYear) {
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
    $('#loanModal').modal('show'); // open modal first (optional)
    loadEmployee(); // populate dropdown
    loadStartYearDropdown('startYear');
}

function loadEmployee() {
    var companyCode = $('#ddlCompany option:selected').val();
    $.ajax({
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

function SaveStaffLoan() {
    var employeeCode = $('#employeeIdLoan').val();
    var loanType = $('#loanTypeId').val();
    var loanAmount = parseFloat($('#loanAmount').val()) || 0;
    var installments = parseInt($('#installments').val()) || 0;
    var startMonth = parseInt($('#month').val());
    var startYear = parseInt($('#startYear').val());

    if (!employeeCode || !loanType || !loanAmount || !installments || !startYear) {
        DisplayError("Please fill all required fields.");
        return;
    }

    // Collect schedule data from table using data attributes
    var scheduleList = [];
    $('#scheduleBody tr').each(function () {
        var $tr = $(this);
        var month = parseInt($tr.data('month'))+1; // use data-month
        var year = parseInt($tr.data('year'));   // use data-year
        var scheduledAmount = parseFloat($tr.data('scheduled')) || 0;

        scheduleList.push({
            Month: month,
            Year: year,
            ScheduledAmount: scheduledAmount
        });
    });

    // Prepare payload
    var loanData = {
        EmployeeCode: employeeCode,
        LoanAmount: loanAmount,
        LoanType: loanType,
        NoOfInstallments: installments,
        InstallmentStartMonth: startMonth+1,
        InstallmentStartYear: startYear,
        Installments: scheduleList
    };

    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/StaffLoanService.asmx/SaveStaffLoan",
        data: JSON.stringify({ IP_objLst_StaffLoan: loanData }),
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            DisplayInformation(WSReturn.Message.toString());

            $('#loanModal').modal('hide'); // close modal
            // Optionally, refresh loan list table here
            clearLoanModal();
        },
        error: function (err) {
            console.error("Error saving loan:", err);
            DisplayError("Error saving loan.");
        }
    });
    LoadEmployeeLoanList();
}

function clearLoanModal() {
    $('#employeeIdLoan').val(null).trigger('change');
    $('#loanTypeId').val(null).trigger('change');

    $('#loanAmount').val('');
    $('#installments').val('');

    $('#month').val(null).trigger('change');
    $('#startYear').val(null).trigger('change');

    $('#scheduleBody').empty();
}




