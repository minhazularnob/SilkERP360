var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
$(document).ready(function () {
    //var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    //$('#ddlDepartment').change(function () { DepartmentChangeEvent(); });

    //$("#txtDate").datepicker({ dateFormat: 'dd/MM/yy', constrainInput: true, changeMonth: false, changeYear: false, showButtonPanel: true, minDate: "-4D", maxDate: "0" });

    $('#ddlSection').change(function () { SectionChangeEvent(); });
    $('#ddlProcess').change(function () { ProcessChangeEvent(); });
    $('#ddlMachine').change(function () { MachineChangeEvent(); });
    $('#ddlShift').change(function () { ShiftChangeEvent(); });
    //$("#ddlDailyStatus").change(function () { DailyStatusChangeEvent(); });
    $('#ddlDailyStatus').change(function () { DailyStatusChangeEvent(); });
    $(".numeric_only").numeric();
});

function DailyStatusChangeEvent() {
    var lcl_i32_DailyStatus = $('#ddlDailyStatus option:selected').val();
    var lcl_i32_MachineIndex = $('#ddlMachine option:selected').index();
    if (lcl_i32_MachineIndex == 0) {
       // DisplayInformation("A 'Machine' must be selected before changing status!!!");
        //$('#ddlMachine option:selected').index(0);
       // $("#ddlMachine").val('0');
        return false;
    }
    if (lcl_i32_DailyStatus == 0) {
        // DisplayInformation("A 'Machine' must be selected before changing status!!!");
        //$('#ddlMachine option:selected').index(0);
        // $("#ddlMachine").val('0');
//        lcl_obj_MachineThroughput._Throughput_I64 = $('#txtThroughput').val();
//        lcl_obj_MachineThroughput._Wastage_UI32 = $('#txtWastage').val();
        $('#txtThroughput').removeAttr('readonly');
        $('#txtWastage').removeAttr('readonly');
        return false;
    }
    if (lcl_i32_DailyStatus == 1) {
        //SHIFT OFF
        // DisplayInformation("A 'Machine' must be selected before changing status!!!");
        //$('#ddlMachine option:selected').index(0);
        // $("#ddlMachine").val('0');
        $('#txtTargetThroughput').val('0');
        $('#txtThroughput').val('0');
        $('#txtWastage').val('0');
        $('#txtThroughput').attr('readonly', 'readonly');
        $('#txtWastage').attr('readonly', 'readonly');
        return false;
    }
    if (lcl_i32_DailyStatus == 4) {
        //NO ORDER
        // DisplayInformation("A 'Machine' must be selected before changing status!!!");
        //$('#ddlMachine option:selected').index(0);
        // $("#ddlMachine").val('0');
        $('#txtTargetThroughput').val('0');
        $('#txtThroughput').val('0');
        $('#txtWastage').val('0');
        $('#txtThroughput').attr('readonly', 'readonly');
        $('#txtWastage').attr('readonly', 'readonly');
        return false;
    }
    $('#txtThroughput').attr('readonly', 'readonly');
    $('#txtWastage').attr('readonly', 'readonly');
    var lcl_i64_TargetThroughput = $('#txtTargetThroughput').val();

    lcl_i64_TargetThroughput = lcl_i64_TargetThroughput * (-1);
    $('#txtThroughput').val(lcl_i64_TargetThroughput.toString());
    
    $('#txtWastage').val('0');
    $("#ddlMachine").trigger("change");
}

function SaveThroughput() {
    if (confirm("Are you sure, you want to save this throughput?") == true) {
    }
    return false;
}

function ShiftChangeEvent() {
    var lcl_i32_SelectedIndex = $('#ddlShift option:selected').index();
    //alert(lcl_i32_SelectedIndex);
    $("#txtDate").val('');
    var lcl_obj_Today = new Date();
    if (lcl_i32_SelectedIndex == 1) {
        //day shift
        $("#txtDate").val((lcl_obj_Today.getDate() + "/" + months[lcl_obj_Today.getMonth()] + "/" + lcl_obj_Today.getFullYear()));
        return;
    }
    if (lcl_i32_SelectedIndex == 2) {
        //night shift
        //set date for the night shift of the previous day
        lcl_obj_Today.setDate((lcl_obj_Today.getDate() - 1));
        
        $("#txtDate").val(lcl_obj_Today.getDate() + "/" + months[lcl_obj_Today.getMonth()] + "/" + lcl_obj_Today.getFullYear());
        return;
    }
}

function SectionChangeEvent() {
    //get Processes based on selected section
    var lcl_str_SelectedText = $.trim($('#ddlSection option:selected').text());
    //alert(lcl_str_SelectedText);
    var lcl_i32_SectionCode = $('#ddlSection option:selected').val();
    if (lcl_i32_SectionCode == 0) {
        return;
    }
    //alert(lcl_i32_SectionCode.toString());
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/SCPM/ConfigurationService.asmx/GetProcessesBySection",
        data: "{IP_str_SectionCode: '" + lcl_i32_SectionCode + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_lst_Processes = WSResponse.Data;
            $("select[id$=ddlProcess] > option:gt(0)").remove();
            $.each(lcl_lst_Processes, function (index, lcl_lst_Process) {
                var dropdown_options = document.createElement("option");
                dropdown_options.value = lcl_lst_Process._ProcessCode_UI64.toString();
                dropdown_options.text = lcl_lst_Process._Name_STR;
                //document.getElementById("ddlProcess").options.add(dropdown_options);
                $('#ddlProcess').append(dropdown_options);
                //neutralise other ddl s selection
                //$('#ddlMachine select').SelectedIndex = 0;
                $("select#ddlMachine").prop("selectedIndex", 0);
                $("#ddlMachine").trigger('change');
            });
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
    
}

function ProcessChangeEvent() {
    //get Machines based on selected section
    var lcl_str_SelectedText = $.trim($('#ddlProcess option:selected').text());
    //alert(lcl_str_SelectedText);
    var lcl_i32_ProcessCode = $('#ddlProcess option:selected').val();
    if (lcl_i32_ProcessCode == 0) {
        return;
    }
    //alert(lcl_i32_SectionCode.toString());
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/SCPM/ConfigurationService.asmx/GetMachinesSTRByProcess",
        data: "{IP_str_ProcessCode: '" + lcl_i32_ProcessCode + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_lst_MachinesSTR = WSResponse.Data;
            $("select[id$=ddlMachine] > option:gt(0)").remove();
            $.each(lcl_lst_MachinesSTR, function (index, lcl_obj_MachineSTR) {
                var dropdown_options = document.createElement("option");
                dropdown_options.value = lcl_obj_MachineSTR._MachineCode_UI64.toString();
                dropdown_options.text = lcl_obj_MachineSTR._Name_STR;
                $('#ddlMachine').append(dropdown_options);
                $("select#ddlMachine").prop("selectedIndex", 0);
                $("#ddlMachine").trigger('change');
            });
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
    
}

function MachineChangeEvent() {
    //get Selected Machines details
    //get Machines based on selected section
    var lcl_str_SelectedText = $.trim($('#ddlMachine option:selected').text());
    //alert(lcl_str_SelectedText);
    
    var lcl_i32_SelectedIndex = $('#ddlMachine option:selected').index();
    //alert(lcl_i32_SelectedIndex.toString());
    if (lcl_i32_SelectedIndex == 0) {
        $('#txtTargetThroughput').val("");
        $('#lblTargetThroughputMeasurementUnit').text("");
        $('#lblThroughputMeasurementUnit').text("");
        $('#lblWastageMeasurementUnit').text("");
        $("#ddlDailyStatus").attr("disabled", "disabled");
    }
    var lcl_i32_MachineCode = $('#ddlMachine option:selected').val();
    if (lcl_i32_MachineCode == 0) {
        $('#txtTargetThroughput').val("");
        $('#lblTargetThroughputMeasurementUnit').text("");
        $('#lblThroughputMeasurementUnit').text("");
        $('#lblWastageMeasurementUnit').text("");
        $("#ddlDailyStatus").attr("disabled", "disabled");
        return;
    }
    $("#ddlDailyStatus").removeAttr("disabled");
    
    //alert(lcl_i32_SectionCode.toString());
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/SCPM/ConfigurationService.asmx/GetMachinesSTRByMachineCode",
        data: "{IP_str_MachineCode: '" + lcl_i32_MachineCode + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_lst_MachinesSTR = WSResponse.Data;

            $('#txtTargetThroughput').val(lcl_lst_MachinesSTR._TargetThroughput_UI32);
            $('#lblTargetThroughputMeasurementUnit').text(lcl_lst_MachinesSTR._MeasurementUnit_STR + '/Shift');
            $('#lblThroughputMeasurementUnit').text(lcl_lst_MachinesSTR._MeasurementUnit_STR);
            $('#lblWastageMeasurementUnit').text(lcl_lst_MachinesSTR._MeasurementUnit_STR);
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
}

function SaveThroughput() {

    var lcl_obj_MachineThroughput = new Object();
    lcl_obj_MachineThroughput._MachineCode_UI64 = $('#ddlMachine option:selected').val();
    lcl_obj_MachineThroughput._ShiftCode_UI64 = $('#ddlShift option:selected').val();
    lcl_obj_MachineThroughput._EntryEmployeeCode_UI64 = $('#txtSignedEmployeeCode').val(); //hidden field
    lcl_obj_MachineThroughput._TargetThroughput_UI32 = $('#txtTargetThroughput').val();
    lcl_obj_MachineThroughput._Throughput_I64 = $('#txtThroughput').val();
    lcl_obj_MachineThroughput._Wastage_UI32 = $('#txtWastage').val();
    lcl_obj_MachineThroughput._Remarks_STR = $('#txtRemarks').val();
    lcl_obj_MachineThroughput._ThroughputDateTime_DT = $('#txtDate').val();
    lcl_obj_MachineThroughput._DailySCPMMachineStatus = $('#ddlDailyStatus option:selected').val();
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_URL_Root + "WebServices/SCPM/SCPMDataWriterService.asmx/SaveMachineThroughput",
        data: "{IP_obj_MachineThroughput: " + JSON.stringify(lcl_obj_MachineThroughput) + "}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            DisplaySuccess(WSResponse.Message);
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
}