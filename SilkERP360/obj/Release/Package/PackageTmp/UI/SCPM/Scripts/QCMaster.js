/************************************************************************************************************************************/
//The following ProductionProcessCodes are taken from DB and hard coded. If the ProductionProcessCodes in DB changes for
//corresponding ProductionProcesses, the following values will change as well.
var GBL_SIMProductionProcesses = new Array();
GBL_SIMProductionProcesses[0] = new Object();
GBL_SIMProductionProcesses[0].Process = "Printing";
GBL_SIMProductionProcesses[0].ProcessCode = "2";

GBL_SIMProductionProcesses[1] = new Object();
GBL_SIMProductionProcesses[1].Process = "Punching";
GBL_SIMProductionProcesses[1].ProcessCode = "4";

GBL_SIMProductionProcesses[2] = new Object();
GBL_SIMProductionProcesses[2].Process = "Milling";
GBL_SIMProductionProcesses[2].ProcessCode = "13";

GBL_SIMProductionProcesses[3] = new Object();
GBL_SIMProductionProcesses[3].Process = "Embedding";
GBL_SIMProductionProcesses[3].ProcessCode = "14";

GBL_SIMProductionProcesses[4] = new Object();
GBL_SIMProductionProcesses[4].Process = "Plug-in-Punch";
GBL_SIMProductionProcesses[4].ProcessCode = "15";

GBL_SIMProductionProcesses[5] = new Object();
GBL_SIMProductionProcesses[5].Process = "Personalization";
GBL_SIMProductionProcesses[5].ProcessCode = "10";

//GBL_SIMProductionProcesses['PRINTING'] = 2;
//GBL_SIMProductionProcesses['PUNCHING'] = 4;
//GBL_SIMProductionProcesses['MILLING'] = 13;
//GBL_SIMProductionProcesses['EMBEDDING'] = 14;
//GBL_SIMProductionProcesses['PLUG-IN-PUNCH'] = 15;
//GBL_SIMProductionProcesses['PERSONALIZATION'] = 10;
/************************************************************************************************************************************/
var GBL_SCPMJobOrderList;
var GBL_SCPMMachineList;

$(document).ready(function () {

    $(".numeric_only").number(true);
    $("#ddlMachine").change(function () {
        var lcl_str_MachineCode = $("#ddlMachine option:selected").val();
        //alert(lcl_str_MachineCode);
        $.each(GBL_SCPMMachineList, function (index, lcl_obj_SCPMMachine) {
            if (lcl_str_MachineCode == lcl_obj_SCPMMachine.MachineCode) {
                $("#ddlMachine").data('IDNT', lcl_obj_SCPMMachine.Identifier);
            }
            //$("#ddlMachine").append("<option value='" + lcl_obj_SCPMMachine.MachineCode + "'>" + lcl_obj_SCPMMachine.Name + "</option>");
        });
    });
    $("#ddlJobOrderNo").change(function () {
        var lcl_i32_SelectedIndex = $('#ddlSection option:selected').index();
        if (lcl_i32_SelectedIndex == 0) {
            return;
        }
        var lcl_i32_SelectedJobOrderCode = $('#ddlJobOrderNo option:selected').val();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        $("#ddlJobOrderNo").data('JB_CD', lcl_i32_SelectedJobOrderCode);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //alert(lcl_i32_SelectedJobOrderCode);
        $('#txtOrderedQuantity').val('');
        $('#txtCompletedQuantity').val('');
        $('#txtProductSpecification').val('');
        $('#txtCustomer').val('');
        $('#txtCustomer').data('CUST_CODE', '');
        $.each(GBL_SCPMJobOrderList, function (index, lcl_obj_SCPMJobOrder) {
            //alert(lcl_obj_SCPMJobOrder.JobOrderCode);
            if (lcl_obj_SCPMJobOrder.JobOrderCode == lcl_i32_SelectedJobOrderCode) {
                //alert(lcl_obj_SCPMJobOrder._AdditionalData['CUST_NAME']);
                $('#txtOrderedQuantity').val(lcl_obj_SCPMJobOrder.OrderQuantity);
                $('#txtCompletedQuantity').val(lcl_obj_SCPMJobOrder.CompletedQuantity);
                $('#txtProductSpecification').val(lcl_obj_SCPMJobOrder.ProductSpecification);
                $('#txtCustomer').val(lcl_obj_SCPMJobOrder._AdditionalData['CUST_NAME']);
                $('#txtCustomer').data('CUST_CODE', lcl_obj_SCPMJobOrder.CustomerCode);
                //return;
            }

            //$("#ddlJobOrderNo").append("<option value='" + lcl_obj_SCPMJobOrder.JobOrderCode + "'>" + lcl_obj_SCPMJobOrder.JobOrderCode + "</option>");
        });

    });
    $("#ddlSection").change(function () {

        var lcl_i32_SelectedSectionCode = $('#ddlSection option:selected').val();
        var lcl_str_SelectedSection = $('#ddlSection option:selected').text();
        /*******************************************************************************************************************/
        //Configure ProductionProcess Based on Section selected
        if (lcl_str_SelectedSection == "SIM") {
            //Clear existing option except Index 0
            $("select[id$=ddlProductionProcess] > option:gt(0)").remove();

            $.each(GBL_SIMProductionProcesses, function (index, lcl_obj_SIMProductionProcess) {
                $("#ddlProductionProcess").append("<option value='" + lcl_obj_SIMProductionProcess.ProcessCode + "'>" + lcl_obj_SIMProductionProcess.Process + "</option>");
            });

            /*******************************************************************************************************************/

            $.ajax(
            {
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",
                global: true,
                url: gbl_URL_Root + "WebServices/SCPM/SCJobOrderService.asmx/GetSCPMJobOrdersBySection",
                data: "{IP_ui64_SectionCode: " + lcl_i32_SelectedSectionCode + "}", //provide input for the getSM_PO method
                dataType: "json",
                success: function (response) {
                    var WSReturn = response.d;
                    if (WSReturn.ResponseCode < 0) {
                        DisplayError(WSReturn.Message);
                        return;
                    }
                    var lcl_objList_SCPMJobOrderList = WSReturn.Data;
                    GBL_SCPMJobOrderList = lcl_objList_SCPMJobOrderList;
                    if (lcl_objList_SCPMJobOrderList.length == 0) {
                        $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
                        $('.ProductTypeIndexChange_0').val('');
                        //$("select[id$=ddlProductionProcess] > option:gt(0)").remove();
                        $('#dvQCTest').hide('slow', function () {
                            $('.qc_test_type_container').hide(1000);
                        });
                        DisplayError("No Incomplete JobOrder Found for The Selected Section!!!");
                        return;
                    }
                    //Clear existing option except Index 0
                    $("select[id$=ddlJobOrderNo] > option:gt(0)").remove();

                    $.each(GBL_SCPMJobOrderList, function (index, lcl_obj_SCPMJobOrder) {
                        $("#ddlJobOrderNo").append("<option value='" + lcl_obj_SCPMJobOrder.JobOrderCode + "'>" + lcl_obj_SCPMJobOrder.JobOrderCode + "</option>");
                    });
                    //Clear Necessery Things
                    //ProductionSection SIM = 1
                    //SIM type Q.C setup
                    //Insert ProductionProcesses for SIM
                    $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
                    $('.ProductTypeIndexChange_0').val('');
                    $('#dvQCSim').show('slow');
                    return;
                },
                error: function (event, jqxhr, settings, exception) {
                    DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
                }
            });
        }
        else {
            $("select[id$=ddlProductionProcess] > option:gt(0)").remove();
        }

    });
    $("#txtDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    /*********************************************************************************************************************************/
    //Configure Q.C test form Buttons
    $('#btnPeelOff').data('PPC', GBL_SIMProductionProcesses['PRINTING']);
    $('#btnPeelOff').data('PPN', 'PRINTING');
    $('#btnACDC').data('PPC', GBL_SIMProductionProcesses['PRINTING']);
    $('#btnACDC').data('PPN', 'PRINTING');
    $('#btnLWT').data('PPC', GBL_SIMProductionProcesses['PUNCHING']);
    $('#btnLWT').data('PPN', 'PUNCHING');
    $('#btnCDDL').data('PPC', GBL_SIMProductionProcesses['MILLING']);
    $('#btnCDDL').data('PPN', 'MILLING');
    $('#btnBending').data('PPC', GBL_SIMProductionProcesses['EMBEDDING']);
    $('#btnBending').data('PPN', 'EMBEDDING');
    $('#btnTorsion').data('PPC', GBL_SIMProductionProcesses['EMBEDDING']);
    $('#btnTorsion').data('PPN', 'EMBEDDING');
    $('#btnPOC').data('PPC', GBL_SIMProductionProcesses['EMBEDDING']);
    $('#btnPOC').data('PPN', 'EMBEDDING');
    $('#btnCLA').data('PPC', GBL_SIMProductionProcesses['EMBEDDING']);
    $('#btnCLA').data('PPN', 'EMBEDDING');
    $('#btnBreakOutForce').data('PPC', GBL_SIMProductionProcesses['PLUG-IN-PUNCH']);
    $('#btnBreakOutForce').data('PPN', 'PLUG-IN-PUNCH');
    $('#btnDimension').data('PPC', GBL_SIMProductionProcesses['PLUG-IN-PUNCH']);
    $('#btnDimension').data('PPN', 'PLUG-IN-PUNCH');
    $('#btnPerso').data('PPC', GBL_SIMProductionProcesses['PERSONALIZATION']);
    $('#btnPerso').data('PPN', 'PERSONALIZATION');
    /*********************************************************************************************************************************/
    /*********************************************************************************************************************************/
    $(".ip_required").focus(function () {
        $(this).css('background-color', 'white');
    });
    $('.qc_test_form_btn').click(function (event) {
        event.preventDefault();
        /*****************************************************************************************************************************/
        //Validate if all necessery fields are filled or selected
        //alert("b");
        //var lcl_b_InputValidated = true;
        //        $(".ip_required").each(function () {
        //            if ($(this).is("[type=text]")) {
        //                var lcl_str_Value = $(this).val();
        //                if ((lcl_str_Value.length == 0) || (lcl_str_Value == '0')) {
        //                    lcl_b_InputValidated = false;
        //                    $(this).css('background-color', 'red');
        //                }
        //            }
        //            if ($(this).is("select")) {
        //                //get control id
        //                var lcl_i32_SelectedIndex = $(this).find(":selected").index();
        //                if (lcl_i32_SelectedIndex == 0) {
        //                    $(this).css('background-color', 'red');
        //                    lcl_b_InputValidated = false;
        //                }
        //            }

        //        });
        //        if (lcl_b_InputValidated == false) {
        //           return false;
        //        }

        /*****************************************************************************************************************************/
        var lcl_str_ProductionProcessCode = $(this).data('PPC');
        var lcl_str_ProductionProcessName = $(this).data('PPN');
        $('#txtProductionProcess').val(lcl_str_ProductionProcessName);
        $('#txtProductionProcess').data('PPC', lcl_str_ProductionProcessCode);
        /*
        =>Call SCPMMachineServices.GetMachinesByProductionProcess
        */
        $.ajax(
        {
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: gbl_URL_Root + "WebServices/SCPM/SCPMMachineServices.asmx/GetMachinesByProductionProcess",
            data: "{IP_ui64_ProductionProcessCode: " + lcl_str_ProductionProcessCode + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_SCPMMachineList = WSReturn.Data;
                //Clear existing option excepty Index 0
                $("select[id$=ddlMachine] > option:gt(0)").remove();
                if (lcl_obj_SCPMMachineList.length == 0) {
                    DisplayError("No Machine Was Found For The Selected Production Process!!!");
                    return;
                }
                GBL_SCPMMachineList = lcl_obj_SCPMMachineList;
                $.each(lcl_obj_SCPMMachineList, function (index, lcl_obj_SCPMMachine) {
                    $("#ddlMachine").append("<option value='" + lcl_obj_SCPMMachine.MachineCode + "'>" + lcl_obj_SCPMMachine.Name + "</option>");
                });
                return;
            },
            error: function (event, jqxhr, settings, exception) {
                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
            }
        });
    });
    /*********************************************************************************************************************************/
});


function CreateBatchConfig(event) {
    event.preventDefault();

    $('#dvNewBatch').show('slow');
}



//function LockQCMaster() {
//    
//    var lcl_i32_SelectedSectionCode = $('#ddlSection option:selected').val();
//    
//    $.ajax(
//        {
//            type: "POST",
//            async: false,
//            contentType: "application/json; charset=utf-8",
//            global: true,
//            url: gbl_URL_Root + "WebServices/SCPM/SCJobOrderService.asmx/GetSCPMJobOrdersBySection",
//            data: "{IP_ui64_SectionCode: " + lcl_i32_SelectedSectionCode + "}", //provide input for the getSM_PO method
//            dataType: "json",
//            success: function (response) {
//                var WSReturn = response.d;
//                if (WSReturn.ResponseCode < 0) {
//                    DisplayError(WSReturn.Message);
//                    return;
//                }
//                var lcl_objList_SCPMJobOrderList = WSReturn.Data;
//                GBL_SCPMJobOrderList = lcl_objList_SCPMJobOrderList;
//                if (lcl_objList_SCPMJobOrderList.length == 0) {
//                    $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//                    $('.ProductTypeIndexChange_0').val('');
//                    //$("select[id$=ddlProductionProcess] > option:gt(0)").remove();
//                    $('#dvQCTest').hide('slow', function () {
//                        $('.qc_test_type_container').hide(1000);
//                    });
//                    DisplayError("No Incomplete JobOrder Found for The Selected Section!!!");
//                    return;
//                }
//                //Clear existing option excepty Index 0
//                $("select[id$=ddlJobOrderNo] > option:gt(0)").remove();
//                $.each(GBL_SCPMJobOrderList, function (index, lcl_obj_SCPMJobOrder) {
//                    $("#ddlJobOrderNo").append("<option value='" + lcl_obj_SCPMJobOrder.JobOrderCode + "'>" + lcl_obj_SCPMJobOrder.JobOrderCode + "</option>");
//                });
//                //Clear Necessery Things
//                //ProductionSection SIM = 1
//                //SIM type Q.C setup
//                //Insert ProductionProcesses for SIM
//                $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//                $('.ProductTypeIndexChange_0').val('');
//                $('#dvQCSim').show('slow');
//                return;
//            },
//            error: function (event, jqxhr, settings, exception) {
//                DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
//            }
//        });
//    if (lcl_i32_SelectedSectionCode == 0) {
//        //Clear Necessery Things
//        //            $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//        //            $('.ProductTypeIndexChange_0').val('');
//        //            //$("select[id$=ddlProductionProcess] > option:gt(0)").remove();
//        //            $('#dvQCTest').hide('slow', function () {
//        //                $('.qc_test_type_container').hide(1000);
//        //            });
//        //return;
//    }
//    if (lcl_i32_SelectedSectionCode == 1) {

//        //Clear Necessery Things
//        //ProductionSection SIM = 1
//        //SIM type Q.C setup
//        //Insert ProductionProcesses for SIM
//                    $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//                    $('.ProductTypeIndexChange_0').val('');
//                    $('#dvQCSim').show('slow');
//        //return;
//    }
//    if (lcl_i32_SelectedSectionCode == 2) {
//        //ProductionSection ScratchCard = 2
//        $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//        $('.ProductTypeIndexChange_0').val('');
//        $('#dvQCTest').hide('slow', function () {
//            $('.qc_test_type_container').hide(1000);
//        });
//        //return;
//    }
//    if (lcl_i32_SelectedSectionCode == 3) {
//        //Clear Necessery Things
//        //ProductionSection BankCard = 3
//        //            $('.ProductTypeIndexChange_0').prop('selectedIndex', 0);
//        //            $('.ProductTypeIndexChange_0').val('');
//        //            $('#dvQCTest').hide('slow', function () {
//        //                $('.qc_test_type_container').hide(1000);
//        //            });
//        //return;
//    }
//}

function LoadAppearanceColorDensityTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('PRINTING');
    //$('#txtProductionProcess').data('CODE', '901');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCACDTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadLWTTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('PUNCHING');
    //$('#txtProductionProcess').data('CODE', '902');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCLWTTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}



function LoadPOTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('PRINTING');
    //$('#txtProductionProcess').data('CODE', '901');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCPOTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadPersoTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('PERSONALIZATION');
    //$('#txtProductionProcess').data('CODE', '906');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCPersoTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadCLATest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('EMBEDDING');
    //$('#txtProductionProcess').data('CODE', '904');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCCLATest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadDimensionTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('PLUG-IN-PUNCH');
    //$('#txtProductionProcess').data('CODE', '905');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCDimensionTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadQCCDDLTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('MILLING');
    //$('#txtProductionProcess').data('CODE', '903');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCCDDLTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadTorsionTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('EMBEDDING');
    //$('#txtProductionProcess').data('CODE', '904');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCTorsionTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadPOCTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('EMBEDDING');
    //$('#txtProductionProcess').data('CODE', '904');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCPOCTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadQCBendingTest() {
    $('#dvQCTest').hide(1000);
    //$('#txtProductionProcess').val('EMBEDDING');
    //$('#txtProductionProcess').data('CODE', '904');
    $.ajax(
        {
            type: "POST",
            async: true,
            contentType: "application/json; charset=utf-8",
            global: true,
            url: "~/../../../WebServices/UILoaderService.asmx/GetUIFromPath",
            // url: gbl_URL_Root + "WebServices/UILoaderService.asmx/GetUI",
            data: "{IP_str_VirtualPath:" + JSON.stringify('~/UI/SCPM/QCBendingTest.ascx') + "}", //provide input for the getSM_PO method
            //data: "{IP_ui64_CompanyCode: " + lcl_str_CompanyCode + ",IP_str_VirtualPath:" + JSON.stringify('~/UI/HRIS/NewRooster.ascx') + "}", //provide input for the getSM_PO method
            dataType: "json",
            success: function (response) {
                var WSResponse = response.d;
                if (WSResponse.ResponseCode < 0) {
                    DisplayError(WSResponse.Message);
                    return;
                }
                var lcl_str_ControlHTML = WSResponse.Data;
                $('#dvQCTest').html(lcl_str_ControlHTML);
                //$('#dvQCTest').css({ "visibility": "visible" }).fadeIn('slow');
                $('#dvQCTest').show('slow');
                //alert(lcl_str_ControlHTML);
            } /// <reference path= />
        });
    return;
}

function LoadBreakOutForce() {
}