$(document).ready(function () {
    function getMonthName(idx) {
        const months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        return months[idx];
    }

    let loanAmount = 0;

    // Generate schedule inside modal
    $('#createSchedule').click(function () {

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
            <tr data-scheduled="${per}">
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
});

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


