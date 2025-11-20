$(document).ready(function () {
    $("#txtEffectiveFrom").datepicker({
        dateFormat: 'dd/MM/yy', showButtonPanel: true, minDate: 0, maxDate: "+365D",
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
          
        }
    });

    LoaddAllPromotionHistory();
    
    initializeSelect2('ddlEmployeePromotion', '------ Select Employee ------', '25%');
    initializeSelect2('ddlNewDesignation', '------ Select Designation ------', '25%');

    GBL_PROMOTION_HISTORY_LIST_TABLE = $('#tblPromotionHistory').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Promotion History Data Available",
            "sZeroRecords": "No Promotion History Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { "mData": "EmployeeId", "sTitle": "Employee ID", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Employee Name", "sClass": "alignCenter" },
            { "mData": "PreviousDesignationName", "sTitle": "Previous Designation", "sClass": "alignCenter" },
            { "mData": "CurentDesignationName", "sTitle": "New Designation", "sClass": "alignCenter" },
            {
                "mData": "EffectiveFrom",
                "sTitle": "Effective From",
                "sClass": "alignCenter",
                "mRender": function (data, type, full) {
                    return data ? FormatDateUniversal(data) : '';
                }
            },
            {
                "mData": "Remarks",
                "sTitle": "Remarks",
                "sClass": "alignCenter",
                "bSortable": false
            }
        ]
    });
});

function LoaddAllPromotionHistory() {
    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: true,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/GetAllPromotionHistory",
        data: "{IP_ui64_companyCode: " + JSON.stringify(lcl_str_CompanyCode) + "}",
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode < 0) {
                DisplayError(WSReturn.Message);
                return;
            }

            var lcl_obj_DesignationList = WSReturn.Data;

            // Clear existing table data
            GBL_PROMOTION_HISTORY_LIST_TABLE.fnClearTable();

            // Map promotion data to the DataTable format
            var mappedData = [];
            $.each(lcl_obj_DesignationList, function (index, item) {
                mappedData.push({
                    "EmployeeId": item.EmployeeId,
                    "EmployeeName": item.EmployeeName,
                    "PreviousDesignationName": item.PreviousDesignationName,
                    "CurentDesignationName": item.CurentDesignationName, // check spelling
                    "EffectiveFrom": item.EffectiveFrom,
                    "Remarks": item.Remarks
                });
            });

            // Add mapped data to DataTable
            GBL_PROMOTION_HISTORY_LIST_TABLE.fnAddData(mappedData);
            GBL_PROMOTION_HISTORY_LIST_TABLE.fnDraw();
        },
        error: function (err) {
            console.error("Error loading promotion history:", err);
        }
    });
}




function SavePromotion() {
    var lcl_obj_PromotionHistory = new Object();

    lcl_obj_PromotionHistory.EmployeeCode = $('#ddlEmployeePromotion option:selected').val();
    lcl_obj_PromotionHistory.PreviousDesignationCode = $("#ddlEmployeePromotion option:selected").attr("designationcode");
    lcl_obj_PromotionHistory.CurrentDesignationCode = $('#ddlNewDesignation').val();
    lcl_obj_PromotionHistory.EffectiveFrom = ConvertToOracleDate($('#txtEffectiveFrom').val());
    lcl_obj_PromotionHistory.Remarks = $("#txtRemarks").val();
    lcl_obj_PromotionHistory.CompanyCode = $('#ddlCompany').val();

    var validateObj = {
        EmployeeCode: lcl_obj_PromotionHistory.EmployeeCode,
        PreviousDesignationCode: lcl_obj_PromotionHistory.PreviousDesignationCode,
        CurrentDesignationCode: lcl_obj_PromotionHistory.CurrentDesignationCode,
        EffectiveFrom: lcl_obj_PromotionHistory.EffectiveFrom,
        CompanyCode: lcl_obj_PromotionHistory.CompanyCode
    };

    var validationMessage = validateFields(validateObj);
    if (validationMessage !== 'OK') {
        DisplayError(validationMessage.toString());
        return false;
    }

    if (confirm("Are you sure you want to submit this application?") == true) {
        $.ajax({
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/SavePromotionHistory",
            data: "{IP_Obj_PromotionHistory:" + JSON.stringify(lcl_obj_PromotionHistory) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message.toString());
                    LoaddAllPromotionHistory();
                    clearFields();
                } else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (xhr, status, error) {
                console.error("Error saving promotion:", status, error);
                DisplayError("An error occurred while saving the promotion. Please try again.");
            }
        });
    }
    return false;
}

$("#ddlEmployeePromotion").change(function () {
    var selectedText = $(this).find("option:selected").text();
    var match = selectedText.match(/\[([^\]]+)\]/);
    var designation = match ? match[1].trim() : '';
    $("#txtCurrentDesignation").val(designation);
});



function clearFields() {
    // Clear all input fields
    $('#dvWorkGroupMaster').find('input[type="text"], textarea').val('');
    $('#dvWorkGroupMaster').find('input[type="number"]').val('');
    
    // Clear dropdowns
    $('#ddlEmployeePromotion').val(null).trigger('change');
    $('#ddlNewDesignation').val(null).trigger('change');
    
    // Reinitialize datepicker
    $("#txtEffectiveFrom").datepicker('destroy'); // Remove existing datepicker
    $("#txtEffectiveFrom").datepicker({
        dateFormat: 'dd/MM/yy', 
        showButtonPanel: true, 
        minDate: 0, 
        maxDate: "+365D"
    });
    
    return false; // Prevent form submission
}



