$(document).ready(function () {
    $('#showIncrementSectionChkBox').prop('checked', false);

    loadDatepicker();

    $("#promotionHistory_txtStartDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getFirstDay(),
        onSelect: function (d) {
            const min = $.datepicker.parseDate(dateFormat, d);
            $("#promotionHistory_txtEndDate").datepicker("option", "minDate", min);
            LoaddAllPromotionHistory();
        }
    });

    // End Date Picker
    $("#promotionHistory_txtEndDate").datepicker({
        dateFormat: dateFormat,
        changeMonth: true,
        changeYear: true,
        showButtonPanel: true,
        defaultDate: getLastDay(),
        onSelect: function (d) {
            const max = $.datepicker.parseDate(dateFormat, d);
            $("#promotionHistory_txtStartDate").datepicker("option", "maxDate", max);
            LoaddAllPromotionHistory();
        }

    });

    $("#promotionHistory_txtStartDate").val(getFirstDay());
    $("#promotionHistory_txtEndDate").val(getLastDay());


    LoaddAllPromotionHistory();
    
    initializeSelect2('ddlEmployeePromotion', '------ Select Employee ------', '25%');
    initializeSelect2('ddlNewDesignation', '------ Select Designation ------', '25%');
    initializeSelect2('promotion_approvers', '------ Select Approvers ------', '25%');

    bindAllAprovers("promotion_approvers");

    GBL_PROMOTION_HISTORY_LIST_TABLE = $('#tblPromotionHistory').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": true,
        "bSearch": true,
        "oLanguage": {
            "sEmptyTable": "No Promotion History Data Available",
            "sZeroRecords": "No Promotion History Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        },
        "aoColumns": [
            { "mData": "SL", "sTitle": "Sl.", "sClass": "alignCenter", "bVisible": true },
            { "mData": "EmployeeCode", "sTitle": "EmployeeCode", "sClass": "alignCenter", "bVisible": false },
            { "mData": "EmployeeId", "sTitle": "Employee ID", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Employee Name", "sClass": "alignCenter" },
            { "mData": "PreviousDesignationName", "sTitle": "Pr.Designation", "sClass": "alignCenter" },
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
            { "mData": "WithIncrement", "sTitle": "With Increment", "sClass": "alignCenter" },
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
                        return `<span class="text-success">Approved</span>`;
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

    GBL_INCREMENT_HISTORY = $('#tblIncrementHistoryFromPromotion').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "aoColumns": [
            { sTitle: '<b>Prv. Gross</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. Gross</b>', sWidth: '20%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. Basic</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. H.Rent</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. Conv.</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Inc. Med.</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Eff. Month</b>', sWidth: '10%', sClass: 'alignCenter' },
            { sTitle: '<b>Eff. Year</b>', sWidth: '10%', sClass: 'alignCenter' },
        ]
    });
});

function LoaddAllPromotionHistory() {
    from = $('#promotionHistory_txtStartDate').val();
    to = $('#promotionHistory_txtEndDate').val();

    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();
    $.ajax({
        async: true,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/GetAllPromotionHistory",
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
            GBL_PROMOTION_HISTORY_LIST_TABLE.fnClearTable();

            // Map promotion data to the DataTable format
            var mappedData = [];
            $.each(lcl_obj_DesignationList, function (index, item) {
                mappedData.push({
                    "SL": index + 1, // ← Serial Number
                    "EmployeeId": item.EmployeeId,
                    "EmployeeName": item.EmployeeName,
                    "PreviousDesignationName": item.PreviousDesignationName,
                    "CurentDesignationName": item.CurentDesignationName, // check spelling
                    "EffectiveFrom": item.EffectiveFrom,
                    "Remarks": item.Remarks,
                    "IsApproved": item.IsApproved,
                    "PromotionID": item.PromotionID,
                    "EmployeeCode": item.EmployeeCode,
                    "UserSpecifcApprovalStatus": item.UserSpecifcApprovalStatus,
                    "WithIncrement": item.WithIncrement
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

    if ($('#ddlEmployeePromotion').val() == '') {
        DisplayError("please select employee");
        return;
    }

    if (approvers == null) {
        DisplayError("Please select at least one approver.");
        return;
    }
       

    lcl_obj_PromotionHistory.EmployeeCode = $('#ddlEmployeePromotion option:selected').val();
    lcl_obj_PromotionHistory.EmployeeId = $('#ddlEmployeePromotion option:selected').text().match(/\[([^\]]+)\]$/)[1];
    lcl_obj_PromotionHistory.EmployeeName = $('#ddlEmployeePromotion option:selected').text().split('[')[0];;
    lcl_obj_PromotionHistory.PreviousDesignationCode = $("#ddlEmployeePromotion option:selected").attr("designationcode");
    lcl_obj_PromotionHistory.PreviousDesignationName = ($('#ddlEmployeePromotion option:selected').text().match(/\[(.*?)\]/) || [])[1];
    lcl_obj_PromotionHistory.CurrentDesignationCode = $('#ddlNewDesignation').val();
    lcl_obj_PromotionHistory.CurentDesignationName = $('#ddlNewDesignation option:selected').text();
    lcl_obj_PromotionHistory.EffectiveFrom = ConvertToOracleDate($('#txtEffectiveFromPromotion').val());
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

    $.each(approvers, function (index, approver) {
        lcl_obj_approverDetail = new Object();
        lcl_obj_approverDetail.EmployeeCode = approver;
        lcl_obj_PromotionHistory.approverDetails.push(lcl_obj_approverDetail);
    });

    if ($('#showIncrementSectionChkBox').is(':checked')) {
        var lcl_ui32_Gross = $("#txtIncGrossWithPromotion").val();
        if ((lcl_ui32_Gross == 0) || (lcl_ui32_Gross == '')) {
            DisplayError("No Increment Given To Selected Employees!Cannot Save!");
            return;
        }

        var lcl_i32_PreviousGross = $('#txtCurrGrossWithPromotion').val();
        if ((lcl_i32_PreviousGross == '0') || (lcl_i32_PreviousGross == '')) {
            DisplayError("No previous gross Entry for the Selected Employee!");
            return;
        }

        let ent = $('#txtIncEntWithPromotion').val();

        var lcl_obj_Increment = new Object();

        lcl_obj_Increment.EmployeeCode = $('#ddlEmployeePromotion option:selected').val();
        lcl_obj_Increment.IncGross = $('#txtIncGrossWithPromotion').val();
        lcl_obj_Increment.IncBasic = $('#txtIncBasicWithPromotion').val();
        lcl_obj_Increment.IncHouseRent = $('#txtIncHR').val();
        lcl_obj_Increment.IncConveyence = $('#txtIncConvWithPromotion').val();
        lcl_obj_Increment.IncMedical = $('#txtIncMedWithPromotion').val();
        lcl_obj_Increment.IncEntertainment = ent === undefined || ent.trim() === "" || isNaN(ent) ? 0 : parseFloat(ent);
        lcl_obj_Increment.PreviousGross = $('#txtCurrGrossWithPromotion').val();
        lcl_obj_Increment.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();
        lcl_obj_Increment.EffectiveMonth = new Date(Date.parse($('#txtEffectiveFromPromotion').val().split("/")[1] + " 1, 2000")).getMonth() + 1
        lcl_obj_Increment.EffectiveYear = $('#txtEffectiveFromPromotion').val().split("/")[2];

        lcl_obj_PromotionHistory.IP_obj_Increment = lcl_obj_Increment;

    }

    if (confirm("Are you sure you want to submit this application?") == true) {
        
        $.ajax({
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/SavePromotionHistory",
            data: JSON.stringify({
                IP_Obj_PromotionHistory: lcl_obj_PromotionHistory,
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
                console.error("Error saving promotion:", status, error);
                DisplayError("An error occurred while saving the promotion. Please try again.");
            }
        });
    }
    return false;
}

$("#ddlEmployeePromotion").change(function () {
    var selectedText = $(this).find("option:selected").text();
    if (selectedText == '') {
        return false;
    }

    var match = selectedText.match(/\[([^\]]+)\]/);
    var designation = match ? match[1].trim() : '';
    $("#txtCurrentDesignation").val(designation);
    if ($('#showIncrementSectionChkBox').is(':checked')) {
        $('#tblIncrementHistoryDiv').show();
        DisplayIncrementHistory();
    }
});

function clearFields() {
    // Clear all input fields
    $('#dvWorkGroupMaster').find('input[type="text"]:not(#dvReportBody input[type="text"]), textarea:not(#dvReportBody textarea)').val('');
    $('#dvWorkGroupMaster').find('input[type="number"]').val('');
    
    // Clear dropdowns
    $('#ddlEmployeePromotion').val(null).trigger('change');
    $('#ddlNewDesignation').val(null).trigger('change');
    $('#promotion_approvers').val(null).trigger('change');
    
    // Reinitialize datepicker
    $("#txtEffectiveFromPromotion").datepicker('destroy'); // Remove existing datepicker

    loadDatepicker();

    $('#showIncrementSectionChkBox').prop('checked', false);

    $('#incrementDiv').hide();

    // Hide Increment table wrapper div
    $('#tblIncrementHistoryDiv').hide();
    
    return false; // Prevent form submission
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
    console.log(gbl_URL_Root);
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

$('#showIncrementSectionChkBox').on('change', function () {
    if ($(this).is(':checked')) {
        $('#incrementDiv').show();
        $('#tblIncrementHistoryDiv').show();
        if ($('#ddlEmployeePromotion').val()) {
            DisplayIncrementHistory();
        }
    }
    else {
        $('#incrementDiv').hide();
        $('#tblIncrementHistoryDiv').hide();
    }
});

$("#txtIncGrossWithPromotion").blur(function () {
    CalculateSalary();
});

function CalculateSalary() {
    var lcl_ui32_Gross = $("#txtIncGrossWithPromotion").val();
    var lcl_ui32_Basic = (lcl_ui32_Gross * 60) / 100;
    var lcl_ui32_HouseRent = (lcl_ui32_Gross * 30) / 100;
    var lcl_ui32_Conveyence = (lcl_ui32_Gross * 5) / 100;
    var lcl_ui32_Medical = (lcl_ui32_Gross * 5) / 100;

    $("#txtIncBasicWithPromotion").val(lcl_ui32_Basic);
    $("#txtIncHRWithPromotion").val(lcl_ui32_HouseRent);
    $("#txtIncConvWithPromotion").val(lcl_ui32_Conveyence);
    $("#txtIncMedWithPromotion").val(lcl_ui32_Medical);
    
}

function loadDatepicker() {
    // Reinitialize
    $("#txtEffectiveFromPromotion").datepicker({
        dateFormat: 'dd/MM/yy',
        showButtonPanel: true,
        minDate: 1,
        maxDate: "+365D",

        beforeShowDay: function (date) {
            // allow only 1st day of each month
            if (date.getDate() === 1) {
                return [true, "", ""];
            } else {
                return [false, "", ""];
            }
        },

        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            console.log("Selected date:", d);
        }
    });
}


function DisplayIncrementHistory() {
    var lcl_ui64_EmployeeCode = $('#ddlEmployeePromotion').val();

    /*********************************************************************************************************************/
    //Get Current Salary
    var options_sal = {};
    options_sal.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/GetSalaryStructureByEmployee";
    options_sal.type = "POST";
    options_sal.global = true,
        options_sal.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
        options_sal.contentType = "application/json; charset=utf-8",
        options_sal.processData = false;
    options_sal.success = function (result) {
        var lcl_obj_WSResponseSal = result.d;
        if (lcl_obj_WSResponseSal.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponseSal.Message);
            return;
        }
        var lcl_obj_SalaryStructure = lcl_obj_WSResponseSal.Data;
        $("#txtCurrGrossWithPromotion").val(lcl_obj_SalaryStructure.Gross);
    };
    options_sal.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options_sal);
    /*********************************************************************************************************************/

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/IncrementService.asmx/GetIncrementHistoryByEmployee";
    options.type = "POST";
    options.global = true,
        options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
        options.contentType = "application/json; charset=utf-8",
        options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode < 0) {
            //Incorrect EmployeeCode provided.No employee id found for provided employee code
            $('#dvReportBody').hide('slow');
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }

        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_obj_EmployeeIncrementList = lcl_obj_WSResponse.Data;

            if (lcl_obj_EmployeeIncrementList == null) {
                var lcl_obj_EmployeeIncrementList = null;
                return;
            }

            GBL_INCREMENT_HISTORY.fnClearTable();

            var lcl_objLst_TblIncrementHistory = new Array();


            $.each(lcl_obj_EmployeeIncrementList, function (index, lcl_obj_Increment) {


                lcl_objLst_TblIncrementHistory[index] = new Object();

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_TblIncrementHistory[index][0] = lcl_obj_Increment.PreviousGross;
                lcl_objLst_TblIncrementHistory[index][1] = lcl_obj_Increment.IncGross;
                lcl_objLst_TblIncrementHistory[index][2] = lcl_obj_Increment.IncBasic;
                lcl_objLst_TblIncrementHistory[index][3] = lcl_obj_Increment.IncHouseRent;
                lcl_objLst_TblIncrementHistory[index][4] = lcl_obj_Increment.IncConveyence;
                lcl_objLst_TblIncrementHistory[index][5] = lcl_obj_Increment.IncMedical;
                lcl_objLst_TblIncrementHistory[index][6] = lcl_obj_Increment.EffectiveMonth;
                lcl_objLst_TblIncrementHistory[index][7] = lcl_obj_Increment.EffectiveYear;

            });
            GBL_INCREMENT_HISTORY.fnAddData(lcl_objLst_TblIncrementHistory);
            $('#dvReportBody').show('slow');

        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}
