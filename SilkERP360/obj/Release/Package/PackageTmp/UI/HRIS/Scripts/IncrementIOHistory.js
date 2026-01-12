var GBL_INCREMENT_HISTORY;
var CLIPBOARD = "";

$(document).ready(function () {

    GBL_INCREMENT_HISTORY = $('#tblIncrementHistory').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "aoColumns": [
                    { sTitle: '<b>Prv. Gross</b>', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Gross</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Basic</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. H.Rent</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Conv.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Inc. Med.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Eff. Month</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Eff. Year</b>', sWidth: '10%', sClass: 'alignCenter' },
                    {
                        sTitle: '<b>Status</b>', sWidth: '10%', sClass: 'alignCenter',
                        mRender: function (data, type, full) {
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
                        sTitle: '<b>Action</b>',
                        sWidth: '15%',
                        sClass: 'alignCenter',

                        mRender: function (data, type, full) {
                            if (
                                full[8] === 0 || full[8] === 2 ||
                                full[9] === 0 || full[9] === 2
                            ) {
                                return '<span class="text-muted">No actions available</span>';
                            }

                            return `
                            <div class="action-buttons">
                                <a href="javascript:void(0);" 
                                   class="btn-approve" 
                                   title="Approve"
                                   onclick="approveIncrement(${full[10]}, ${full[9]}); return false;">
                                    <i class="fa fa-check-circle text-success"></i> Approve
                                </a>

                                <a href="javascript:void(0);" 
                                   class="btn-reject" 
                                   title="Reject"
                                   onclick="rejectIncrement(${full[10]}, ${full[9]}); return false;"
                                   style="margin-left: 10px;">
                                    <i class="fa fa-times-circle text-danger"></i> Reject
                                </a>
                            </div>
                        `;
                        }
                    }
                  ]
    });

    $("#txtIncGross").blur(function () {
        CalculateSalary();
    });

    initializeSelect2('ddlEmployee', '------ Select Employee ------', '25%');
    initializeSelect2('ddlEffectiveMonth', '------ Select Month ------', '101%');
    initializeSelect2('ddlEffectiveYear', '------ Select Month ------', '101%');
    initializeSelect2('increment_approvers', '------ Select Approvers ------', '25%');
    bindAllAprovers("increment_approvers");
});

function approveIncrement(incrementId, employeeCode) {
    if (confirm("Are you sure you want to approve this promotion?")) {
        updatePromotionStatusForApprover(incrementId, employeeCode, 'approved');
    }
}

function rejectIncrement(incrementId, employeeCode) {
    if (confirm("Are you sure you want to reject this promotion?")) {
        updatePromotionStatusForApprover(incrementId, employeeCode, 'rejected');
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
        url: gbl_URL_Root + "WebServices/HRIS/IncrementService.asmx/UpdateIncrementStatusForApprover",
        data: JSON.stringify({
            IP_ui64_PromotionHistoryCode: promotionHistoryCode,
            status: statusCode
        }),
        dataType: "json",
        success: function (response) {
            var WSReturn = response.d;
            if (WSReturn.ResponseCode == 0) {
                DisplayInformation(WSReturn.Message.toString());
                DisplayIncrementHistory();

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

function DisplayIncrementHistory() {

    var lcl_i32_SelectedIndex = $('#ddlEmployee option:selected').index();
    if (lcl_i32_SelectedIndex == 0) {
        DisplayError("Please Select An Employee To Show Details!");
        return;
    }

    var lcl_ui64_EmployeeCode = $('#ddlEmployee option:selected').val();

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
        $("#txtCurrGross").val(lcl_obj_SalaryStructure.Gross);
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
                $('#dvReportBody').hide('slow');
                DisplayInformation("No Increment History Found For the Selected Employee!");
                GBL_INCREMENT_HISTORY.fnClearTable();
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
                lcl_objLst_TblIncrementHistory[index][8] = lcl_obj_Increment.IsApproved;
                lcl_objLst_TblIncrementHistory[index][9] = lcl_obj_Increment.UserSpecifcApprovalStatus;
                lcl_objLst_TblIncrementHistory[index][10] = lcl_obj_Increment.IncrementCode;

            });
            GBL_INCREMENT_HISTORY.fnAddData(lcl_objLst_TblIncrementHistory);
            $('#dvReportBody').show('slow');
            
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
}

function SaveIncrement() {
    var lcl_ui32_Gross = $("#txtIncGross").val();
    var approvers = $('#increment_approvers').val();

    if ((lcl_ui32_Gross == 0) || (lcl_ui32_Gross == '')) {
        DisplayError("No Increment Given To Selected Employees!Cannot Save!");
        return;
    }


    var lcl_i32_EffectiveMonth = $('#ddlEffectiveMonth option:selected').index();
    var lcl_i32_EffectiveYear = $('#ddlEffectiveYear option:selected').index();

    if ((lcl_i32_EffectiveMonth == 0) || (lcl_i32_EffectiveYear == 0)) {
        DisplayError("Please Select Increment Effective Month/Effective Year!!!Operation Terminated!");
        return;
    }

    var lcl_i32_PreviousGross = $('#txtCurrGross').val();
    if ((lcl_i32_PreviousGross == '0') || (lcl_i32_PreviousGross == '')) {
        DisplayError("No previous gross Entry for the Selected Employee!");
        return;
    }

    if (approvers == null   ) {
        DisplayError("Please select at least one approver");
        return;
    }



    var lcl_obj_Increment = new Object();

    lcl_obj_Increment.EmployeeCode = $('#ddlEmployee option:selected').val();
    lcl_obj_Increment.IncGross = $('#txtIncGross').val();
    lcl_obj_Increment.IncBasic = $('#txtIncBasic').val();
    lcl_obj_Increment.IncHouseRent = $('#txtIncHR').val();
    lcl_obj_Increment.IncConveyence = $('#txtIncConv').val();
    lcl_obj_Increment.IncMedical = $('#txtIncMed').val();
    lcl_obj_Increment.IncEntertainment = $('#txtIncEnt').val();
    lcl_obj_Increment.PreviousGross = $('#txtCurrGross').val();
    lcl_obj_Increment.EntryEmployeeCode = $('#txtSignedInEmployeeCode').val();
    lcl_obj_Increment.EffectiveMonth = $('#ddlEffectiveMonth option:selected').val();
    lcl_obj_Increment.EffectiveYear = $('#ddlEffectiveYear option:selected').val(); 
  

    IP_obj_ApproverDetails = [];

    $.each(approvers, function (index, approver) {
        lcl_obj_approverDetail = new Object();
        lcl_obj_approverDetail.EmployeeCode = approver;
        IP_obj_ApproverDetails.push(lcl_obj_approverDetail);
    });

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/IncrementService.asmx/SaveIncrement";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_obj_Increment: " + JSON.stringify(lcl_obj_Increment) + ",IP_obj_ApproverDetails: " + JSON.stringify(IP_obj_ApproverDetails) + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponseSal = result.d;
        if (lcl_obj_WSResponseSal.ResponseCode < 0) {
            DisplayError(lcl_obj_WSResponseSal.Message);
            return;
        }
        DisplaySuccess("Employee Has Been Incremented Successfully!");
        DisplayIncrementHistory();
        $(".INC_IP").val('0');
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    
}

//txtIncGross.Change function
function CalculateSalary() {
    var lcl_ui32_Gross = $("#txtIncGross").val();
    var lcl_ui32_Basic = (lcl_ui32_Gross * 60) / 100;
    var lcl_ui32_HouseRent = (lcl_ui32_Gross * 30) / 100;
    var lcl_ui32_Conveyence = (lcl_ui32_Gross * 5) / 100;
    var lcl_ui32_Medical = (lcl_ui32_Gross * 5) / 100;

    $("#txtIncBasic").val(lcl_ui32_Basic);
    $("#txtIncHR").val(lcl_ui32_HouseRent);
    $("#txtIncConv").val(lcl_ui32_Conveyence);
    $("#txtIncMed").val(lcl_ui32_Medical);
}