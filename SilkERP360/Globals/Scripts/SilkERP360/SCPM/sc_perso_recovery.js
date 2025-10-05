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
        },
        "aoColumns": [
                    { sTitle: 'SL.', sWidth: '5%', sClass: 'alignCenter', sType: 'numeric' },
                    { sTitle: 'Card SL.', sWidth: '20%', sClass: 'alignCenter', sType: 'numeric' },
                    { sTitle: 'Fault Type', sWidth: '25%', sClass: 'alignCenter' },
                    { sTitle: 'Remarks', sWidth: '40%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '10%', sClass: 'alignCenter' },
                  ]

    });

    $('#tblRecoveredList').data('RecoveredCardCounter', '1');

    $('.barcode_input').on({
        keypress: function (e) {

            if (e.which == 13) {
                e.preventDefault();
                var lcl_str_Value = $.trim($(this).val());
                if (lcl_str_Value === '') {
                    return;
                }
                /****************************************************************************************************************************/
                //Clientside Validation
                //alert($('#ddlMachine option:selected').val());
                if ($('#ddlMachine option:selected').val() == 0) {
                    $(this).val('');
                    DisplayError("You Must Select A Machine Before Entering Faulty Card Data!!!");
                    return;
                }

                if ($('#ddlJobOrder option:selected').val() == 0) {
                    $(this).val('');
                    DisplayError("You Must Select A Job Order Before Entering Faulty Card Data!!!");
                    return;
                }

                if ($('#ddlBatch option:selected').val() == 0) {
                    $(this).val('');
                    DisplayError("You Must Select A Batch Before Entering Faulty Card Data!!!");
                    return;
                }
                var lcl_i32_CardCounter = parseInt($('#tblRecoveredList').data('RecoveredCardCounter').toString());
                /****************************************************************************************************************************/
                lcl_str_Value = lcl_str_Value.replace(/\D/g, '0');
                //check duplicate serial on the client
                var lcl_b_CardDuplicated = false;
                $('.sc_fault_card_sl').each(function (i, obj) {
                    if ($(this).text() == lcl_str_Value) {
                        //DisplayError("This Card Has Already Been Added In Current Session!!!");
                        $("#dvOperationStatus").css("background-color", "red");
                        $("#txtOperationStatus").html("Card : " + lcl_str_Value + "has already been entered registered in current session!!!");
                        lcl_b_CardDuplicated = true;
                        return false;
                    }
                });
                if (lcl_b_CardDuplicated == true) {
                    $(this).val('');
                    return;
                }

                var lcl_ui64_BatchCode = $("#ddlBatch option:selected").val();
                //check if this card was reported before in faulty card section
                $.ajax(
                {
                    type: "POST",
                    async: false,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/SCPM/SCFaultCardService.asmx/CheckSCSerialValidity",
                    data: "{IP_ui64_BatchCode : " + lcl_ui64_BatchCode + ",IP_ui64_CardSL :" + lcl_str_Value + "}",
                    dataType: "json", /// <reference path= />
                    success: function (response) {
                        var lcl_obj_WSResponse = response.d;
                        //        console.log(lcl_obj_WSResponse);
                        if (lcl_obj_WSResponse.ResponseCode < 0) {
                            DisplayError(lcl_obj_WSResponse.Message);
                            return false;
                        }
                        if (lcl_obj_WSResponse.BResponse == false) {
                            //duplicate exists
                            $('#txtCardSerial').val('');
                            $("#dvOperationStatus").css("background-color", "red");
                            $("#txtOperationStatus").html(lcl_obj_WSResponse.Message);
                            //DisplayError("This Card ");
                            return false;
                        }
                        else {
                            //add serial in table
                            var lcl_obj_FaultyCardData = new Array();
                            lcl_obj_FaultyCardData[0] = "<label id='txtSL-" + lcl_i32_CardCounter + "'>" + lcl_i32_CardCounter.toString() + "</label>";
                            lcl_obj_FaultyCardData[1] = "<label id='txtCardSL-" + lcl_i32_CardCounter + "' class='sc_fault_card_sl'>" + lcl_str_Value + "</label>";
                            lcl_obj_FaultyCardData[2] = "<select id='ddlFaultType-" + lcl_i32_CardCounter + "' class='sc_fault_type'>" +
                                                                "<option value='0'>--Select Fault Type</option>" +
                                                                "<option value='1'>PrintError</option>" +
                                                                "<option value='2'>LabelError</option>" +
                                                                "<option value='3'>OverprintError</option>" +
                                                                "<option value='4'>PhysicalError</option>" +
                                                                "<option value='5'>BarcodeError</option>" +
                                                "</select>";
                            lcl_obj_FaultyCardData[3] = "<input id='txtRemarks-" + lcl_i32_CardCounter + "' type='text' style='width:98%;' placeholder='Remarks'/>";
                            lcl_obj_FaultyCardData[4] = "<img class='row_delete_btn' src='../../Globals/Images/delete.png'  style='cursor:pointer;background-color:#ffffff' title='Delete'/>";
                            RECOVERED_CARD_LIST.fnAddData(lcl_obj_FaultyCardData);
                            $("#dvOperationStatus").css("background-color", "green");
                            $("#txtOperationStatus").html("Card : " + lcl_str_Value + " Has been added successfully!!!");
                            //alert($("#txtSL-" + lcl_i32_CardCounter).text());
                            //save the incremented counter
                            lcl_i32_CardCounter++;
                            $('#tblRecoveredList').data('RecoveredCardCounter', lcl_i32_CardCounter.toString());
                            $('#txtCardSerial').val('');
                        }
                    }, /// <reference path= />
                    error: function (event, jqxhr, settings, exception) {
                        //debugger;
                        //alert("LOCAL AJAX ERROR");
                        DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                        return false;
                    }
                });
                /****************************************************************************************************************************/




                //$(this).css('background-color', 'green');
            }

        }
    });

    //delete dynamically added rows
    $("#tblRecoveredList").on('click', '.row_delete_btn', function () {
        var srow = $(this).parent().parent();
        if (confirm("Do You Really Want to Delete This Row?")) {
            //            var lcl_iControlCount = $('#tblSelectedATR tr').length - 1; //first row is the header
            //            lcl_iControlCount--;
            //            //document.getElementById("txtATRSelectionControlCount").value = lcl_iControlCount.toString();
            srow.fadeOut(500, function () {
                srow.remove();
                //RECOVERED_CARD_LIST.fnDraw();
                //change the id of the dynamically added controls
                //get the total row count
                var lcl_i32_RowCount = parseInt($('#tblRecoveredList').data('RecoveredCardCounter').toString());
                //decrement row count;
                lcl_i32_RowCount--;
                //save new row count
                $('#tblRecoveredList').data('RecoveredCardCounter', lcl_i32_RowCount.toString());
                for (var i = 0; i < lcl_i32_RowCount - 1; i++) {
                    var grid_elements = document.getElementsByName("recovered_cards_grid_row").item(i);
                    //synchronize label controls
                    var grid_label_elements = grid_elements.getElementsByTagName("label");
                    //0 label is the row serial
                    grid_label_elements.item(0).setAttribute("id", "txtSL-" + (i + 1).toString());
                    $("#txtSL-" + (i + 1).toString()).text((i + 1).toString()); //reset SL value
                    //1 label is the card serial
                    grid_label_elements.item(1).setAttribute("id", "txtCardSL-" + (i + 1).toString()); //reset CardSL element name

                    //synchronize select controls ids
                    var grid_select_elements = grid_elements.getElementsByTagName("select");
                    //0 label is the row serial
                    grid_select_elements.item(0).setAttribute("id", "ddlFaultType-" + (i + 1).toString());

                    //synchronize input controls ids
                    var grid_input_elements = grid_elements.getElementsByTagName("input");
                    //0 label is the row serial
                    grid_input_elements.item(0).setAttribute("id", "txtRemarks-" + (i + 1).toString());

                }
            });
        }

    });

    $('body').on('change', '.sc_fault_type', function () {
        $(this).css('border', '1px solid rgba(91, 90, 90, 0.7)');
    });

    $('#ddlJobOrder').change(function () { JobOrderChanged(); });
    $('#ddlMachine').change(function () { MachineChanged(); });
    $('#ddlBatch').change(function () { BatchChanged(); });
});



function SavePersoFaultCards() {
    //e.preventDefault();
    if (confirm("Are you sure, You want to save the faulty cards to the database?")) {
        //debugger;
        var lcl_b_SCFaultTypeValidated = true;
        //check all fault type of all cards selected
        $('.sc_fault_type').each(function () {
            //alert($(this).val());
            if ($(this).val() == 0) {
                //alert("border redened");
                lcl_b_SCFaultTypeValidated = false;
                $(this).css('border-color', 'red');
                
            }

        });
        //alert(lcl_b_SCFaultTypeValidated.toString());
        if (lcl_b_SCFaultTypeValidated == false) {
            DisplayError("Please Select 'Card Fault Type' for the red bordered selection boxes!!!");
            return false;
        }
        else {
            var lcl_ui64_RowCounter = parseInt($('#tblRecoveredList').data('RecoveredCardCounter').toString());
            //alert(lcl_ui64_RowCounter);
            //debugger;
            var lcl_i32_MachineCode = $('#ddlMachine option:selected').val();
            var lcl_i32_JobOrderCode = $('#ddlJobOrder option:selected').val();
            var lcl_i32_BatchCode = $('#ddlBatch option:selected').val();
            var lcl_i32_EntryEmpCode = $('#txtEmployeeCode').val();
            //alert(lcl_i32_EntryEmpCode.toString());
            var lcl_objLst_FaultyCardList = new Array();
            for (var i = 1; i < lcl_ui64_RowCounter; i++) {
                lcl_objLst_FaultyCardList[(i - 1)] = new Object();
                lcl_objLst_FaultyCardList[(i - 1)].BatchCode = lcl_i32_BatchCode;
                lcl_objLst_FaultyCardList[(i - 1)].MachineCode = lcl_i32_MachineCode;
                lcl_objLst_FaultyCardList[(i - 1)].CardSl = $(('#txtCardSL-' + i)).text();
                lcl_objLst_FaultyCardList[(i - 1)].FaultType = $(('#ddlFaultType-' + i) + ' option:selected').val();
                lcl_objLst_FaultyCardList[(i - 1)].Remarks = $(('#txtRemarks-' + i)).val();
                lcl_objLst_FaultyCardList[(i - 1)].EntryEmpCode = lcl_i32_EntryEmpCode.toString();
            }
            //alert(lcl_ui64_RowCounter);
            $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/SCPM/SCFaultCardService.asmx/SaveScPersoFaultCards",
            data: "{IP_lstObj_ScFaultyPersoCard :" + JSON.stringify(lcl_objLst_FaultyCardList) + "}",
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
                $('#tblRecoveredList').data('RecoveredCardCounter', '1');
                RECOVERED_CARD_LIST.fnClearTable();

                $("select#ddlMachine").val('0');
                $("select#ddlJobOrder").val('0');
                $("select#ddlBatch").val('0');
                DisplaySuccess("Fault Cards Saved in Database Successfully!");
                return false;
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                return false;
            }
        });
        }
    }
    return false;
}

function JobOrderChanged() {
    var lcl_ui64_SCJobOrderCode = $('#ddlJobOrder option:selected').val();
    if (lcl_ui64_SCJobOrderCode == 0) {
        RECOVERED_CARD_LIST.fnClearTable();
        $('#tblRecoveredList').data('RecoveredCardCounter', '1');
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

    function MachineChanged() {
        RECOVERED_CARD_LIST.fnClearTable();
        $('#tblRecoveredList').data('RecoveredCardCounter', '1');
    }

    function BatchChanged() {
        var lcl_ui64_BatchCode = $("#ddlBatch option:selected").val();
        if (lcl_ui64_BatchCode == 0) {
            RECOVERED_CARD_LIST.fnClearTable();
            $('#tblRecoveredList').data('RecoveredCardCounter', '1');
            return;
        }
        $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/SCPM/SCJobOrderService.asmx/CheckIfBatchClearedForProduction",
            data: "{IP_ui64_ScBatchCode :" + lcl_ui64_BatchCode + "}",
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

                var lcl_b_BatchClearedForProduction = lcl_obj_WSResponse.BResponse;

                if (lcl_b_BatchClearedForProduction == false) {
                    DisplayError("This Batch has not been cleared for production");
                    $("select#ddlBatch").val('0'); 
                    RECOVERED_CARD_LIST.fnClearTable();
                    $('#tblRecoveredList').data('RecoveredCardCounter', '1');
                    return;
                }
            }, /// <reference path= />
            error: function (event, jqxhr, settings, exception) {
                //debugger;
                //alert("LOCAL AJAX ERROR");
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
            }
        });

    }