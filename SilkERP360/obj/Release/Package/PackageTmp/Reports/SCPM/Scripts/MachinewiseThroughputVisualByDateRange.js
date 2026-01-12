$(document).ready(function () {
    $("#txtStartDate").datepicker({
        dateFormat: 'dd/MM/yy',
        onSelect: function (dateText, instanceObject) {
            //alert(dateText);
            var dateObj = new Date(dateText);
            // $("#txtEndDate").attr("maxDate", dateObj);
            $("#txtEndDate").datepicker("destroy");
            $("#txtEndDate").val(dateText);
            //$("#txtEndDate").datepicker('option', 'minDate', dateObj);
            $("#txtEndDate").datepicker({ dateFormat: 'dd/MM/yy', constrainInput: true, changeMonth: false, changeYear: false, showButtonPanel: true, minDate: dateObj, maxDate: "0" });
        },
        constrainInput: true,
        changeMonth: false,
        changeYear: false,
        showButtonPanel: true,
        minDate: new Date("01/01/2014"),
        maxDate: "0"
    });

    $('#ddlSection').change(function () { SectionChangeEvent(); });
    $('#ddlProcess').change(function () { ProcessChangeEvent(); });
    $('#ddlMachine').change(function () { MachineChangeEvent(); });

});

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
        url: gbl_root + "WebServices/SCPM/ConfigurationService.asmx/GetProcessesBySection",
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
        url: gbl_root + "WebServices/SCPM/ConfigurationService.asmx/GetMachinesSTRByProcess",
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
                //document.getElementById("ddlMachine").options.add(dropdown_options);
            });
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });

}

function MachineChangeEvent() {

}

function GetMachineThroughputByDateRange() {
    var lcl_str_MachineCode = $("#ddlMachine option:selected").val();
    var lcl_str_StartDate = $("#txtStartDate").val();
    var lcl_str_EndDate = $("#txtEndDate").val();
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_root + "WebServices/SCPM/SCProductionService.asmx/GetMachinewiseThroughputByDateRange",
        data: "{IP_ui64_MachineCode: " + lcl_str_MachineCode + ",IP_str_StartDate : '" + lcl_str_StartDate + "',IP_str_EndDate:'" + lcl_str_EndDate + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_obj_MachinewiseThroughput = WSResponse.Data;
            //debugger;
            var lcl_objLst_DaywiseMachineThroughputList = lcl_obj_MachinewiseThroughput._DaywiseThroughputList;
            var lcl_i64_MaximumTarget = 0;
            var lcl_str_MeasurementUnit = "";
            var lcl_obj_ChartData = new Array();
            $.each(lcl_objLst_DaywiseMachineThroughputList, function (index, lcl_obj_DaywiseMachineThroughput) {
                lcl_obj_ChartData[index] = new Object();
                lcl_obj_ChartData[index].Date = lcl_obj_DaywiseMachineThroughput._AdditionalData["Date"].toString();
                lcl_obj_ChartData[index].Throughput = lcl_obj_DaywiseMachineThroughput._Throughput;
                //lcl_obj_ChartData[index].Wastage = lcl_obj_DaywiseMachineThroughput._Wastage;
                lcl_obj_ChartData[index].TargetThroughput = lcl_obj_DaywiseMachineThroughput._TargetThroughput;
                lcl_str_MeasurementUnit = lcl_obj_DaywiseMachineThroughput._AdditionalData["MeasurementUnit"].toString();
                if (lcl_obj_ChartData[index].TargetThroughput > lcl_i64_MaximumTarget) {
                    lcl_i64_MaximumTarget = lcl_obj_ChartData[index].TargetThroughput;
                }
            });
            console.log(JSON.stringify(lcl_obj_ChartData));
            //debugger;
            var lcl_ui64_MaximumValue = parseInt(lcl_i64_MaximumTarget * 1.5);
            var lcl_ui32_UnitInterval = lcl_ui64_MaximumValue / 20;
            /******************************************************************************************************************************/
            var settings = {
                title: "Machine Production Trend",
                description: "Machine :" +lcl_obj_MachinewiseThroughput._Name,
                showLegend: true,
                enableAnimations: true,
                padding: { left: 5, top: 5, right: 5, bottom: 5 },
                borderLineWidth: 1,
                titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },
                enableCrosshairs: true,
                source: lcl_obj_ChartData,
                categoryAxis:
                        {

                            dataField: 'Date',
                            showGridLines: false,
                            toolTipFormatSettings: { prefix: 'Country: '}
                        },
                colorScheme: 'scheme01',
                showToolTips: true,
                enableAnimations: true,
                seriesGroups:
                        [
                            {
                                type: 'column',
                                orientation: 'vertical',
                                columnsGapPercent: 50,
                                valueAxis:
                                {

                                    axisSize: 'auto',
                                    displayValueAxis: true,
                                    minValue: 0,
                                    maxValue: lcl_ui64_MaximumValue,
                                    unitInterval: lcl_ui32_UnitInterval,
                                    description: 'Throughput in ' + lcl_str_MeasurementUnit
                                },
                                //                            mouseover: myEventHandler,
                                //                            mouseout: myEventHandler,
                                //                            click: myEventHandler,

                                series: [
                                            { dataField: 'Throughput', displayText: 'Throughput' }
                                            //{ dataField: 'Wastage', displayText: 'Wastage' }
                                        ]
                            },
                            {
                                type: 'stackedline',
                                //toolTipFormatFunction: toolTipCustomFormatFn,
                                valueAxis:
                                {
                                    unitInterval: lcl_ui32_UnitInterval,
                                    displayValueAxis: false,
                                    minValue: 0,
                                    maxValue: lcl_ui64_MaximumValue
                                },
                                series: [
                                        { dataField: 'TargetThroughput', displayText: 'TargetThroughput', opacity: 1, lineWidth: 2 }
                                    ]
                            }
                        ]
            };
            // setup the chart
                        $('#jqxChart').jqxChart(settings);
            /******************************************************************************************************************************/
       }
         
    });

                       
}
