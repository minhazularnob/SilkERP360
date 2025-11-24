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
    initializeSelect2('promotion_approvers', '------ Select Approvers ------', '25%');

    bindAllAprovers();

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
            { "mData": "EmployeeCode", "sTitle": "EmployeeCode", "sClass": "alignCenter", bvisible: false },
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
            },
            {
                "mData": "IsApproved",
                "sTitle": "Status",
                "sClass": "alignCenter",
                "mRender": function (data, type, full) {
                    if (data == 0) {
                        return `<span class="text-danger">Rejected</span>`;
                    }
                    else if (data == 1) {
                        return `<span class="text-warning">Pending</span>`;
                    }
                    else if (data == 2) {
                        return `<span class="text-primary">Approved</span>`;
                    }
                    else if (data == 3) {
                        return `<span class="text-success">Promoted</span>`;
                    }

                    return "";
                }
            },
            {
                "mData": "PromotionID",
                "sTitle": "Actions",
                "sClass": "alignCenter",
                "bSortable": false,
                "mRender": function (data, type, full) {
                    // If status is rejected (0), return only text without any interactive elements
                    if (full.IsApproved === 0 || full.IsApproved === 2 || full.IsApproved === 3 || full.UserSpecifcApprovalStatus === 0 || full.UserSpecifcApprovalStatus === 2 || full.UserSpecifcApprovalStatus === 3) {
                        return '<span class="text-muted">No actions available</span>';
                    }
                    // Only show buttons if status is not rejected
                    return `
                    <div class="action-buttons">
                        <a href="javascript:void(0);" 
                           class="btn-approve" 
                           title="Approve" 
                           onclick="approvePromotion(${full.PromotionID}, ${full.EmployeeCode}); return false;">
                            <i class="fa fa-check-circle text-success"></i> Approve
                        </a>
                        <a href="javascript:void(0);" 
                           class="btn-reject" 
                           title="Reject" 
                           onclick="rejectPromotion(${full.PromotionID}, ${full.EmployeeCode}); return false;" 
                           style="margin-left: 10px;">
                            <i class="fa fa-times-circle text-danger"></i> Reject
                        </a>
                    </div>`;
                }
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
                    "Remarks": item.Remarks,
                    "IsApproved": item.IsApproved,
                    "PromotionID": item.PromotionID,
                    "EmployeeCode": item.EmployeeCode,
                    "UserSpecifcApprovalStatus": item.UserSpecifcApprovalStatus
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
    lcl_obj_PromotionHistory.approverDetails = [];
    
    var approvers = $('#promotion_approvers').val();

    $.each(approvers, function (index, approver) {
        lcl_obj_approverDetail = new Object();
        lcl_obj_approverDetail.EmployeeCode = approver;
        lcl_obj_PromotionHistory.approverDetails.push(lcl_obj_approverDetail);
    });

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
    if (validateObj.PreviousDesignationCode == validateObj.CurrentDesignationCode) {
        validationMessage = "Previous Designation and New Designation cannot be the same.";
    }

    if (approvers == null) {
        validationMessage = "Please select at least one approver.";
    }

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
    $('#promotion_approvers').val(null).trigger('change');
    
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

function getAllApprovers() {
    var lcl_str_CompanyCode = $('#promotion_approvers option:selected').val();
    var result = null;
    $.ajax(
        {
            async: false,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/GetAllApprovers",
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

function bindAllAprovers() {
    var approvers = getAllApprovers();
    var $approverSelect = $('#promotion_approvers');

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

function approvePromotion(promotionId, employeeCode) {
    if (confirm("Are you sure you want to approve this promotion?")) {
        updatePromotionStatusForApprover(promotionId, employeeCode,'approved');
    }
}

function rejectPromotion(promotionId, employeeCode) {
    if (confirm("Are you sure you want to reject this promotion?")) {
        updatePromotionStatusForApprover(promotionId, employeeCode, 'rejected');
    }
}

function updatePromotionStatusForApprover(promotionHistoryCode, approverCode, status) {
    // Convert status to integer (1 for approved, 0 for rejected)
    var statusCode = (status === 'approved') ? 2 : 0;
    
    $.ajax({
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/UpdatePromotionStatusForApprover",
        data: JSON.stringify({ 
            IP_ui64_PromotionHistoryCode: promotionHistoryCode, 
            status: statusCode 
        }),
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
                console.error("Error updating status:", status, error);
                DisplayError("An error occurred while updating the status.. Please try again.");
            }
        });
    return false;
}