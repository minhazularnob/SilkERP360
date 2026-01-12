$(document).ready(function () {
    //var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    //$('#ddlDepartment').change(function () { DepartmentChangeEvent(); });
    $("#txtDate").datepicker({
        dateFormat: 'dd/MM/yy',
        onSelect: function (dateText, instanceObject) {
            //alert(dateText);
            var dateObj = new Date(dateText);
            // $("#txtEndDate").attr("maxDate", dateObj);
        },
        constrainInput: true,
        changeMonth: false,
        changeYear: false,
        showButtonPanel: true,
        minDate: new Date("01/01/2014"),
        maxDate: "0"
    });
    //$("#txtEndDate").datepicker({ dateFormat: 'dd/MM/yy', constrainInput: true, changeMonth: false, changeYear: false, showButtonPanel: true, minDate: "0", maxDate: "0" });


});

function GetDailyThroughputAllSections() {
    var lcl_str_Date = $("#txtDate").val();
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: gbl_root + "WebServices/SCPM/SCProductionService.asmx/GetAllSectionThroughputByDate",
        data: "{IP_str_Date: '" + lcl_str_Date + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_lst_SectionwiseThroughputList = WSResponse.Data;
            var lcl_i32_Counter = 1;
            var lcl_i32_ChartCounter = 1;
            var lcl_obj_ChartData = new Array();
            $("#tblChart").empty();
            $.each(lcl_lst_SectionwiseThroughputList, function (indexSection, lcl_obj_SectionwiseThroughput) {
                var lcl_obj_ProcesswiseMachineThroughputList = lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList;


                var lcl_i64_MaximumTargetThroughput = 0;

                var lcl_str_MeasurementUnit = "";
                lcl_obj_ChartData[indexSection] = new Array();
                $.each(lcl_obj_ProcesswiseMachineThroughputList, function (indexProcess, lcl_obj_ProcesswiseMachineThroughput) {
                    lcl_obj_ChartData[indexSection][indexProcess] = new Array();
                    var lcl_obj_MachinewiseThroughputList = lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList;
                    var lcl_i32_MachineCount = lcl_obj_MachinewiseThroughputList.length;
                    var lcl_i32_ChartWidth = 200 * lcl_i32_MachineCount; //px
                    //CREATE DIV IN tblChart TO PLACE THE CHART
                    var lcl_str_DVName = "ProcessChart-" + lcl_i32_ChartCounter;
                    //height of the div is set before creating the chart
                    var lcl_str_ChartRow = "<tr><td style='background-color:#ffffff;text-align:center;'><div id='" + lcl_str_DVName + "'  style='height:300px;width:100%;margin:0 auto;'/></td></tr>";
                    $("#tblChart").append(lcl_str_ChartRow);
                    $.each(lcl_obj_MachinewiseThroughputList, function (indexMachine, lcl_obj_MachinewiseThroughput) {
                        lcl_str_MeasurementUnit = lcl_obj_MachinewiseThroughput._AdditionalData["MeasurementUnit"];
                        var lcl_obj_MachineThroughputList = lcl_obj_MachinewiseThroughput._MachineThroughputList;
                        lcl_obj_ChartData[indexSection][indexProcess][indexMachine] = new Object(); //machine will have two maximum Throughput. DayShift and NightShift
                        lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Machine = lcl_obj_MachinewiseThroughput._ShortName;
                        lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Target = lcl_obj_MachinewiseThroughput._TargetThroughput;
                        lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Day = 0;
                        lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Night = 0;
                        if (lcl_obj_MachineThroughputList.length == 0) {
                            //no throughput data
                            lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Day = 0;
                            lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Night = 0;
                            return;
                        }
                        if (lcl_obj_MachineThroughputList.length == 1) {
                            //Either dayshift or nightshift data
                            if (lcl_obj_MachineThroughputList[0]._AdditionalData["ShiftName"] == "Night") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Night = lcl_obj_MachineThroughputList[0]._Throughput;
                            }
                            if (lcl_obj_MachineThroughputList[0]._AdditionalData["ShiftName"] == "Day") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Day = lcl_obj_MachineThroughputList[0]._Throughput;
                            }
                        }
                        if (lcl_obj_MachineThroughputList.length == 2) {

                            if (lcl_obj_MachineThroughputList[0]._AdditionalData["ShiftName"] == "Night") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Night = lcl_obj_MachineThroughputList[0]._Throughput;

                            }
                            if (lcl_obj_MachineThroughputList[0]._AdditionalData["ShiftName"] == "Day") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Day = lcl_obj_MachineThroughputList[0]._Throughput;

                            }
                            if (lcl_obj_MachineThroughputList[1]._AdditionalData["ShiftName"] == "Night") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Night = lcl_obj_MachineThroughputList[1]._Throughput;
                            }
                            if (lcl_obj_MachineThroughputList[1]._AdditionalData["ShiftName"] == "Day") {
                                lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Day = lcl_obj_MachineThroughputList[1]._Throughput;
                            }
                        }
                        if (lcl_obj_MachineThroughputList[0]._TargetThroughput > lcl_i64_MaximumTargetThroughput) {
                            lcl_i64_MaximumTargetThroughput = lcl_obj_MachineThroughputList[0]._TargetThroughput;
                        }

                        if (lcl_obj_MachinewiseThroughput._DailySCPMMachineStatus == 1) {
                            //implement Shift Off
                            lcl_obj_ChartData[indexSection][indexProcess][indexMachine].Target = 0;
                        }
                        $.each(lcl_obj_MachineThroughputList, function (indexThroughput, lcl_obj_MachineThroughput) {

                        });
                    });

                    var settings = {
                        title: lcl_obj_ProcesswiseMachineThroughput._Name,
                        description: "Silkcard Production",
                        showLegend: true,
                        enableAnimations: true,
                        padding: { left: 5, top: 5, right: 5, bottom: 5 },
                        borderLineWidth: 0,
                        titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },
                        enableCrosshairs: true,
                        source: lcl_obj_ChartData[indexSection][indexProcess],
                        categoryAxis:
                        {

                            dataField: 'Machine',
                            showGridLines: true,
                            axisSize: 'auto'
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
                                    maxValue: lcl_i64_MaximumTargetThroughput + ((lcl_i64_MaximumTargetThroughput / 10) * 2),
                                    unitInterval: (lcl_i64_MaximumTargetThroughput / 10),
                                    description: 'Throughput in ' + lcl_str_MeasurementUnit
                                },
                                //                            mouseover: myEventHandler,
                                //                            mouseout: myEventHandler,
                                //                            click: myEventHandler,

                                series: [
                                            { dataField: 'Day', displayText: 'Day' },
                                            { dataField: 'Night', displayText: 'Night' }
                                        ]
                            },
                            {
                                type: 'stackedline',
                                //toolTipFormatFunction: toolTipCustomFormatFn,
                                valueAxis:
                                {
                                    unitInterval: (lcl_i64_MaximumTargetThroughput / 10),
                                    displayValueAxis: false,
                                    minValue: 0,
                                    maxValue: lcl_i64_MaximumTargetThroughput + ((lcl_i64_MaximumTargetThroughput / 10) * 2)
                                },
                                series: [
                                        { dataField: 'Target', displayText: 'Target', opacity: 1, lineWidth: 2 }
                                    ]
                            }
                        ]
                    };
                    //set DIV height
                    lcl_i32_ChartHeight = 300;
                    if (lcl_i32_MachineCount < 4) {
                        $(("#ProcessChart-" + lcl_i32_ChartCounter)).css('width', ((lcl_i32_MachineCount * 200) + "px")); // (lcl_i32_ChartHeight + 'px'));
                    }

                    $(("#ProcessChart-" + lcl_i32_ChartCounter)).jqxChart(settings);
                    lcl_i32_ChartCounter++;
                    lcl_i64_MaximumTargetThroughput = 0;
                });
            });
        },
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
}