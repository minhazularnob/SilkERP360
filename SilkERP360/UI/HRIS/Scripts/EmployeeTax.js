$(document).ready(function () {
    
    GBL_EMPLOYEE_TAX_LIST_TABLE = $('#tblEmployeeTaxList').dataTable({
        "bJQueryUI": false,
        "bFilter": false,
        "bPaginate": false,
        "bLengthChange": true,
        "bSearch": false,
        "responsive": true,
        "oLanguage": {
            "sEmptyTable": "No Employee Tax Data Available",
            "sZeroRecords": "No Emloyee Tax History Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { "mData": "SL", "sTitle": "Sl.","sWidth": "5%", "sClass": "alignCenter", "bVisible": true },
            { "mData": "EmployeeCode", "sTitle": "EmployeeCode", "sClass": "alignCenter", "bVisible": false },
            { "mData": "EmployeeId", "sTitle": "Employee ID", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Employee Name", "sWidth": "15%", "sClass": "alignCenter" },
            { "mData": "Gross", "sTitle": "Gross", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "Basic", "sTitle": "Basic", "sWidth": "10%", "sClass": "alignCenter" },
            { "mData": "TaxCode", "sTitle": "TaxCode", "sClass": "alignCenter","bVisible": false },
            {
                "mData": "IsTaxDeduction",
                "sTitle": '<input type="checkbox" id="chkSelectAll"/> Deduct Tax',
                "sClass": "alignCenter",
                "sWidth": "8%",
                "mRender": function (data, type, row) {
                    var checked = data ? "checked" : "";
                    return '<input type="checkbox" class="chkTaxDeduct" ' + checked + ' data-employeeid="' + row.EmployeeId + '" />';
                }
            },
            {
                "mData": "TaxAmount",
                "sTitle": "Tax Amount",
                "sClass": "alignRight",
                "sWidth": "10%",
                "mRender": function (data, type, row) {
                    return '<input type="number" class="txtTaxAmount" data-employeeid="' + row.EmployeeId + '" value="' + (data || 0) + '" min="0" />';
                }
            }
        ]
    });
    LoadEmployeeTaxList();
});

function LoadEmployeeTaxList() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/TaxService.asmx/GetEmployeeTaxList",
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

            var lcl_obj_EmployeeTaxList = WSReturn.Data;

            // Clear existing table data
            GBL_EMPLOYEE_TAX_LIST_TABLE.fnClearTable();

            var mappedData = [];
            $.each(lcl_obj_EmployeeTaxList, function (index, item) {
                mappedData.push({
                    "SL": index + 1, // ← Serial Number
                    "EmployeeCode": item.EmployeeCode,
                    "EmployeeId": item.EmployeeId,
                    "EmployeeName": item.EmployeeName,
                    "TaxCode": item.TaxCode,
                    "IsTaxDeduction": item.IsTaxDeduction,
                    "TaxAmount": item.TaxAmount,
                    "Basic": item.Basic,
                    "Gross": item.Gross,
                });
            });

            // Add mapped data to DataTable
            GBL_EMPLOYEE_TAX_LIST_TABLE.fnAddData(mappedData);
            GBL_EMPLOYEE_TAX_LIST_TABLE.fnDraw();
        },
        error: function (err) {
            console.error("Error loading promotion history:", err);
        }
    });
}

function SaveEmployeeTax() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    if (lcl_str_CompanyCode == '') {
        DisplayError("Please select a company.");
        return;
    }

    var employeeTaxList = [];

    // Use DataTables API to get row data
    var allData = GBL_EMPLOYEE_TAX_LIST_TABLE.fnGetData();

    $.each(allData, function (index, row) {
        var employeeCode = row.EmployeeCode; // get from data, not DOM
        var taxAmount = parseFloat($('.txtTaxAmount[data-employeeid="' + row.EmployeeId + '"]').val()) || 0;
        var isTaxDeduction = $('.chkTaxDeduct[data-employeeid="' + row.EmployeeId + '"]').is(':checked') ? 1 : 0;

        employeeTaxList.push({
            EmployeeCode: employeeCode,
            TaxCode: row.TaxCode,
            TaxAmount: taxAmount,
            IsTaxDeduction: isTaxDeduction
        });
    });

    $.ajax({
        async: false,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/TaxService.asmx/SaveEmployeeTaxList",
        data: JSON.stringify({
            IP_objLst_EmployeeTax: employeeTaxList
        }),
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            DisplayInformation(WSReturn.Message.toString());
            LoadEmployeeTaxList(); // reload table
        },
        error: function (err) {
            console.error("Error saving employee tax:", err);
            DisplayError("Error saving employee tax.");
        }
    });
}

// Handle Select All checkbox (using event delegation)
$(document).on('change', '#tblEmployeeTaxList #chkSelectAll', function () {
    var isChecked = $(this).is(':checked');
    // Find all row checkboxes and set their checked state
    $('#tblEmployeeTaxList').find('.chkTaxDeduct').prop('checked', isChecked);
});

// Handle individual checkbox changes to update Select All
$(document).on('change', '#tblEmployeeTaxList .chkTaxDeduct', function () {
    var total = $('#tblEmployeeTaxList .chkTaxDeduct').length;
    var checked = $('#tblEmployeeTaxList .chkTaxDeduct:checked').length;

    // Update header checkbox
    $('#tblEmployeeTaxList #chkSelectAll').prop('checked', total === checked);
});

$(document).on('input', '.txtTaxAmount', function () {
    if (parseFloat(this.value) < 0) this.value = 0;
});





