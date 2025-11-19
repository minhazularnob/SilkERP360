var GBL_INCREMENT_HISTORY;
var CLIPBOARD = "";
var GBL_DESIGNATION_LIST = [];

$(document).ready(function () {
    $("#txtEffectiveFrom").datepicker({
        dateFormat: 'dd/MM/yy', showButtonPanel: true, minDate: -2, maxDate: 0,
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
          
        }
    });
    debugger;


    initializePromotionHistoryTable();

    LoadPromotionHistory();

    
    initializeSelect2('ddlEmployeePromotion', '------ Select Employee ------', '25%');
    initializeSelect2('ddlNewDesignation', '------ Select Designation ------', '25%');
});

function initializePromotionHistoryTable() {
    // Destroy existing DataTable if it exists
    if ($.fn.DataTable.fnIsDataTable($('#tblPromotionHistory'))) {
        $('#tblPromotionHistory').dataTable().fnDestroy();
    }

    GBL_PROMOTION_HISTORY_TABLE = $('#tblPromotionHistory').dataTable({
        "bProcessing": true,
        "sAjaxSource": gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/GetAllPromotionHistory",
        "fnServerData": function (sSource, aoData, fnCallback) {
            $.ajax({
                "dataType": 'json',
                "type": "POST",
                "contentType": "application/json; charset=utf-8",
                "url": sSource,
                "data": JSON.stringify({ IP_ui64_companyCode: $('#ddlCompany option:selected').val() }),
                "success": function (data) {
                    var json = data.d;
                    if (!json || json.ResponseCode < 0) {
                        DisplayError(json ? json.Message : "Invalid response");
                        fnCallback({ "aaData": [] });
                        return;
                    }
                    fnCallback({ "aaData": json.Data || [] });
                },
                "error": function (xhr, status, error) {
                    console.error("Error fetching promotion history:", error);
                    DisplayError("Error loading promotion history. Please try again.");
                    fnCallback({ "aaData": [] });
                }
            });
        },
        "aoColumns": [
            { "mData": "EmployeeId", "sTitle": "Employee ID", "sClass": "alignCenter" },
            { "mData": "EmployeeName", "sTitle": "Employee Name", "sClass": "alignCenter" },
            { "mData": "PreviousDesignationName", "sTitle": "Previous Designation", "sClass": "alignCenter" },
            { "mData": "CurentDesignationName", "sTitle": "Current Designation", "sClass": "alignCenter" },
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
        ],
        "bJQueryUI": false,
        "bPaginate": true,
        "bLengthChange": true,
        "bFilter": true,
        "bSort": true,
        "bInfo": true,
        "bAutoWidth": false,
        "oLanguage": {
            "sEmptyTable": "No Promotion History Available",
            "sZeroRecords": "No Record Found For Your Specified Criteria",
            "sProcessing": "Processing...",
            "sSearch": "Search:",
            "sLengthMenu": "Show _MENU_ entries",
            "oPaginate": {
                "sFirst": "First",
                "sLast": "Last",
                "sNext": "Next",
                "sPrevious": "Previous"
            }
        }
    });
}

function LoadPromotionHistory() {
    if (GBL_PROMOTION_HISTORY_TABLE) {
        GBL_PROMOTION_HISTORY_TABLE.fnDraw();
    }
}

$("#ddlEmployeePromotion").change(function () {
    var selectedText = $(this).find("option:selected").text();
    // Extract text inside the first set of square brackets
    var match = selectedText.match(/\[([^\]]+)\]/);
    var designation = match ? match[1].trim() : '';
    $("#txtCurrentDesignation").val(designation);
    //$("#ddlEmployeePromotion option:selected").attr("designationcode");
});

function SavePromotion() {
    var lcl_obj_PromotionHistory = new Object();

    lcl_obj_PromotionHistory.EmployeeCode = $('#ddlEmployeePromotion option:selected').val();
    lcl_obj_PromotionHistory.PreviousDesignationCode = $("#ddlEmployeePromotion option:selected").attr("designationcode");;
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
        $.ajax(
            {

                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                url: gbl_URL_Root + "WebServices/HRIS/PromotionHistoryService.asmx/SavePromotionHistory",
                data: "{IP_Obj_PromotionHistory:" + JSON.stringify(lcl_obj_PromotionHistory) + "}",
                dataType: "json", /// <reference path= />
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode == 0) {

                        DisplayInformation(WSReturn.Message.toString());
                        //LoadAllDesignation()
                        clearFields();
                        return false;
                    }
                    else {
                        DisplayError(WSReturn.Message.toString());
                    }
                },
                error: function (data) {
                    alert(data);
                }
            });
    }
    return false;
}

function clearFields() {
    $('#dvWorkGroupMaster').find('input[type="text"], textarea').val('');
    $('#dvWorkGroupMaster').find('input[type="number"], textarea').val(null);


    $('#ddlEmployeePromotion').val(null).trigger('change');
    $('#ddlNewDesignation').val(null).trigger('change');
}



