var RECOVERED_CARD_LIST;
$(document).ready(function () {


    /*********************************************************************************************************************
    lcl_str_RoosterDepartmentCode is available here. It stores the DepartmentCode of the Department whose
    Rooster is being created. Written from Code Behind NewRooster.ascx.cs.page_load func
    *********************************************************************************************************************/

    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    RECOVERED_CARD_LIST = $('#tblRecoveredList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Card Data Entered",
            "sZeroRecords": "No Card Data"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            $(nRow).addClass('recovered_cards_grid_row');
            $(nRow).attr("name", 'recovered_cards_grid_row');
            $(nRow).css('height',"30px");
        },
        "aoColumns": [
                    { sTitle: 'SL.', sWidth: '10%', sClass: 'alignCenter', sType: 'numeric' },
                    { sTitle: 'Card SL.', sWidth: '30%', sClass: 'alignCenter', sType: 'numeric' },
                    { sTitle: 'Fault Type', sWidth: '30%', sClass: 'alignCenter' },
                    //{ sTitle: 'Remarks', sWidth: '40%', sClass: 'alignCenter' },
                    { sTitle: 'Barcode', sWidth: '30%', sClass: 'alignCenter' },
                  ]

    });

    // $('#tblRecoveredList').data('RecoveredCardCounter', '1');

    //delete dynamically added rows

    $('#ddlJobOrder').change(function () { JobOrderChanged(); });
    $('#ddlMachine').change(function () { MachineChanged(); });
    //$('#ddlBatch').change(function () { BatchChanged(); });
    $("#ddlBatch").on('change', function () {
        //alert("Batch Changed");
        RECOVERED_CARD_LIST.fnClearTable();
        var lcl_i32_SelectedIndex = $("#ddlBatch option:selected").val();
        if (lcl_i32_SelectedIndex <= 0) {
            return;
        }

        var lcl_ui64_MachineCode = $("#ddlMachine option:selected").val();
        if (lcl_ui64_MachineCode <= 0) {
            DisplayError("Please Select Machine Before Selecting Batch!!!");
            return;
        }

        //no need to validate as with selecting Job Order, its not possible to select batch
        var lcl_ui64_JobOrderCode = $("#ddlJobOrder option:selected").val();
        var lcl_ui64_BatchCode = $("#ddlBatch option:selected").val();

        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/SCPM/SCFaultCardService.asmx/GetSCPersoFaultyCards",
            data: "{IP_ui64_MachineCode :" + lcl_ui64_MachineCode + ",IP_ui64_JobOrderCode :" + lcl_ui64_JobOrderCode + ",IP_ui64_BatchCode : " + lcl_ui64_BatchCode + "}",
            dataType: "json", /// <reference path= />
            success: function (response) {
                //alert("WS SUCCESS");
                //alert(xhr.responseText);
                //var lcl_obj_WSResponseText = xhresponseText;
                //var lcl_obj_WSResponse = new Object();
                //lcl_obj_WSResponse = ($.parseJSON(lcl_obj_WSResponseText)).d;
                var lcl_obj_WSResponse = response.d;
                //        console.log(lcl_obj_WSResponse);
                if (lcl_obj_WSResponse.ResponseCode < 0) {
                    DisplayError(lcl_obj_WSResponse.Message);
                    return false;
                }
                var lcl_obj_SCFaultyCardList = lcl_obj_WSResponse.Data;
                var lcl_ui32_Counter = 1;
                $.each(lcl_obj_SCFaultyCardList, function (index, lcl_obj_SCFaultyCard) {
                    var lcl_obj_FaultyCardData = new Array();
                    lcl_obj_FaultyCardData[0] = lcl_ui32_Counter;
                    lcl_obj_FaultyCardData[1] = lcl_obj_SCFaultyCard.CardSl;
                    lcl_obj_FaultyCardData[2] = lcl_obj_SCFaultyCard.FaultTypeStr;
                    //lcl_obj_FaultyCardData[3] = lcl_obj_SCFaultyCard.Remarks;
                    lcl_obj_FaultyCardData[3] = "<div class='card_sl_barcode' style = 'width:100px;height:25px;border:1px solid black;margin:0 auto;'>" + lcl_obj_SCFaultyCard.CardSl + "</div>";
                    RECOVERED_CARD_LIST.fnAddData(lcl_obj_FaultyCardData);

                    lcl_ui32_Counter++;
                });
                //$(('#dvBarcode-' + lcl_ui32_Counter)).barcode({ code: 'code39' });
                $('.card_sl_barcode').barcode({ code: 'code39' });
                return false;
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                return false;
            }
        });
    });
});





function JobOrderChanged() {
    var lcl_ui64_SCJobOrderCode = $('#ddlJobOrder option:selected').val();
    if (lcl_ui64_SCJobOrderCode == 0) {
        RECOVERED_CARD_LIST.fnClearTable();
        $('#ddlBatch').empty();
        return;
    }
    //alert(lcl_ui64_SCJobOrderCode);
    $('#ddlBatch').empty();
    $('#ddlBatch').append($("<option value='0'>----- Select Batch</option>"));
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/SCPM/SCJobOrderService.asmx/GetScBatchByJobOrder",
            data: "{IP_ui64_ScJobOrderCode :'" + lcl_ui64_SCJobOrderCode + "'}",
            dataType: "json", /// <reference path= />
            success: function (response) {
                //alert("WS SUCCESS");
                //alert(xhr.responseText);
                //var lcl_obj_WSResponseText = xhresponseText;
                //var lcl_obj_WSResponse = new Object();
                //lcl_obj_WSResponse = ($.parseJSON(lcl_obj_WSResponseText)).d;
                var lcl_obj_WSResponse = response.d;
                //        console.log(lcl_obj_WSResponse);
                if (lcl_obj_WSResponse.ResponseCode < 0) {
                    DisplayError(lcl_obj_WSResponse.Message);
                    return;
                }

                var lcl_objLst_Batch = lcl_obj_WSResponse.Data;

                $.each(lcl_objLst_Batch, function (index, lcl_obj_Batch) {
                    var dropdown_options = document.createElement("option");
                    dropdown_options.value = lcl_obj_Batch.BatchCode.toString();
                    dropdown_options.text = lcl_obj_Batch.ScBatchName;
                    document.getElementById("ddlBatch").options.add(dropdown_options);
                });
                
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
            }
        });
}

function BatchChanged() {
    
}
function MachineChanged() {
    $("select#ddlJobOrder").val('0');
    $("select#ddlBatch").val('0');
    RECOVERED_CARD_LIST.fnClearTable();
}
