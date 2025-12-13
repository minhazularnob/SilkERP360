$(document).ready(function () {
    $("#incrementAndpromotionHistory_txtStartDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getFirstDay(),
        onSelect: function (d) {
            const min = $.datepicker.parseDate(dateFormat, d);
            $("#incrementAndpromotionHistory_txtStartDate").datepicker("option", "minDate", min);
            LoadAllIncrementAndPromotionHistory();
        }
    });

    // End Date Picker
    $("#incrementAndpromotionHistory_txtEndDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getLastDay(),
        onSelect: function (d) {
            const max = $.datepicker.parseDate(dateFormat, d);
            $("#incrementAndpromotionHistory_txtStartDate").datepicker("option", "maxDate", max);
            LoadAllIncrementAndPromotionHistory();
        }

    });
    debugger;
    $("#incrementAndpromotionHistory_txtStartDate").val(getFirstDay());
    $("#incrementAndpromotionHistory_txtEndDate").val(getLastDay());


    LoadAllIncrementAndPromotionHistory();

    GBL_INCREMENT_AND_PROMOTION_HISTORY_LIST_TABLE = $('#tblIncrementAndPromotionHistory').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": true,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Increment And Promotion History Data Available",
            "sZeroRecords": "No Increment And Promotion History Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        
        "aoColumns": [
            { "mData": "SL", "sTitle": "Sl.", "sClass": "alignCenter", "bVisible": false },
            { "mData": "EmployeeId", "sTitle": "Emp.ID", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Emp.Name", "sClass": "alignCenter" },
            { "mData": "PreviousDesignation", "sTitle": "Prv.Desg", "sClass": "alignCenter" },
            { "mData": "NewDesignation", "sTitle": "New.Desg", "sClass": "alignCenter" },
            {
                "mData": "PromotionEffectiveDate",
                "sTitle": "Promotion Effective From",
                "sClass": "alignCenter",
                "mRender": function (data, type, full) {
                    return data ? FormatDateUniversal(data) : '';
                }
            },
            { "mData": "PreviousGross", "sTitle": "Prv.Gross", "sClass": "alignCenter" },
            { "mData": "IncGross", "sTitle": "Inc.Gross", "sClass": "alignCenter" },
            { "mData": "IncBasic", "sTitle": "Inc.Basic", "sClass": "alignCenter" },
            { "mData": "IncHouseRent", "sTitle": "Inc.H.Rent", "sClass": "alignCenter" },
            { "mData": "IncConveyance", "sTitle": "Inc.Conv.", "sClass": "alignCenter" },
            { "mData": "IncMedical", "sTitle": "Inc.Medical", "sClass": "alignCenter" },
            { "mData": "IncEntertainment", "sTitle": "Inc.Enter.", "sClass": "alignCenter" },
            { "mData": "IncEffectiveMonth", "sTitle": "Inc.Eff.Month", "sClass": "alignCenter" },
            { "mData": "IncEffectiveYear", "sTitle": "Inc.Eff.Year", "sClass": "alignCenter" },
            { "mData": "Type", "sTitle": "Type", "sClass": "alignCenter" }
        ]
    });
});

function LoadAllIncrementAndPromotionHistory() {
    from = $('#incrementAndpromotionHistory_txtStartDate').val();
    to = $('#incrementAndpromotionHistory_txtEndDate').val();

    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: true,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/IncrementAndPromotionService.asmx/GetAllApprovedIncrementAndPromotionHistory",
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

            var lcl_obj_DesignationList = WSReturn.Data;

            // Clear existing table data
            GBL_INCREMENT_AND_PROMOTION_HISTORY_LIST_TABLE.fnClearTable();

            // Map promotion data to the DataTable format
            var mappedData = [];
            $.each(lcl_obj_DesignationList, function (index, item) {
                mappedData.push({
                    "SL": index + 1, // ← Serial Number
                    "EmployeeId": item.EmployeeId,
                    "EmployeeName": item.EmployeeName,
                    "PreviousDesignation": item.PreviousDesignation,
                    "NewDesignation": item.NewDesignation,
                    "PromotionEffectiveDate": item.PromotionEffectiveDate,
                    "Type": item.Type,
                    "PreviousGross": item.PreviousGross,
                    "IncGross": item.IncGross,
                    "IncBasic": item.IncBasic,
                    "IncHouseRent": item.IncHouseRent,
                    "IncConveyance": item.IncConveyance,
                    "IncMedical": item.IncMedical,
                    "IncEntertainment": item.IncEntertainment,
                    "IncEffectiveMonth": item.IncEffectiveMonth,
                    "IncEffectiveYear": item.IncEffectiveYear,
                });
            });

            // Add mapped data to DataTable
            GBL_INCREMENT_AND_PROMOTION_HISTORY_LIST_TABLE.fnAddData(mappedData);
            GBL_INCREMENT_AND_PROMOTION_HISTORY_LIST_TABLE.fnDraw();
        },
        error: function (err) {
            console.error("Error loading promotion history:", err);
        }
    });
}