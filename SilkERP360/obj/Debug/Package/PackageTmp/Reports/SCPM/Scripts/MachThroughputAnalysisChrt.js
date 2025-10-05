$(document).ready(function () {
    //var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    //$('#ddlDepartment').change(function () { DepartmentChangeEvent(); });
    $('#ddlSection').change(function () { SectionChangeEvent(); });
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
    //$("#txtEndDate").datepicker({ dateFormat: 'dd/MM/yy', constrainInput: true, changeMonth: false, changeYear: false, showButtonPanel: true, minDate: "0", maxDate: "0" });


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
        url: "/WebServices/SCPM/ConfigurationService.asmx/GetProcessesBySection",
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


function GetMachineSTRThroughputChart() {
    
    var lcl_str_StartDate = $("#txtStartDate").val();
    var lcl_str_EndDate = $("#txtEndDate").val();

    if (($.trim(lcl_str_StartDate) == "") || ($.trim(lcl_str_EndDate) == "")) {
        DisplayError("Start and End Date must be selected!!!");
        return false;
    }
    var lcl_ui64_SectionCode = $('#ddlSection option:selected').val();
    var lcl_ui64_ProcessCode = $('#ddlProcess option:selected').val();

    if (lcl_ui64_SectionCode == 0) {
        DisplayError("A Section must be selected before analysing data!!!");
        return false;
    }
    if (lcl_ui64_ProcessCode == 0) {
        DisplayError("A Process must be selected before analysing data!!!");
        return false;
    }
    //alert(lcl_ui64_SectionCode);
    //alert(lcl_ui64_ProcessCode);
    var lcl_str_AjaxData = "{IP_str_SectionCode:'" + lcl_ui64_SectionCode + "',IP_str_ProcessCode:'" + lcl_ui64_ProcessCode + "',IP_str_StartDate:'" + lcl_str_StartDate + "',IP_str_EndDate:'"  + lcl_str_EndDate + "'}";
   // alert(lcl_str_AjaxData);
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: "/WebServices/SCPM/SCPMReaderService.asmx/GetMachineSTRExtThroughput",
        data: lcl_str_AjaxData, //provide input for the getSM_PO method
        //data:{},
        dataType: "json",
        success: function (response) {
            //alert(lcl_ui64_ProcessCode);
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return false;
            }
            var lcl_objLst_SCPMMachineExt = WSResponse.Data;
            var lcl_obj_ChartData = new Array();
            $.each(lcl_objLst_SCPMMachineExt, function (indexMachineExt, lcl_obj_SCPMMachineExt) {
                //CREATE DIV IN tblChart TO PLACE THE CHART
                var lcl_str_DVName = "MachChart-" + indexMachineExt;
                var lcl_str_ChartRow = "<tr><td><div id='" + lcl_str_DVName + "'  style='width:100%; height: 300px'/></td></tr>";

                $("#tblChart").append(lcl_str_ChartRow);
                var lcl_objLst_SCPMMachineThroughputList = lcl_obj_SCPMMachineExt._SCPMMachineThroughput;

                lcl_obj_ChartData[indexMachineExt] = new Array();
                $.each(lcl_objLst_SCPMMachineThroughputList, function (indexMachineThroughput, lcl_obj_SCPMMachineThroughput) {
                    //debugger;
                    //var lcl_str_ThroughputDateSTR = lcl_obj_SCPMMachineThroughput._ThroughputDateTime_DT;
                    var lcl_obj_ThroughputDate = new Date(lcl_obj_SCPMMachineThroughput._ThroughputDateTime_DT.match(/\d+/)[0] * 1);
                    var lcl_obj_Date = new Date();
                    lcl_obj_ChartData[indexMachineExt][indexMachineThroughput] = new Object();
                    lcl_obj_ChartData[indexMachineExt][indexMachineThroughput].Date = lcl_obj_ThroughputDate.getDate();
                    lcl_obj_ChartData[indexMachineExt][indexMachineThroughput].TargetThroughput = lcl_obj_SCPMMachineThroughput._TargetThroughput_UI32;
                    lcl_obj_ChartData[indexMachineExt][indexMachineThroughput].Throughput = lcl_obj_SCPMMachineThroughput._Throughput_I64;
                    //lcl_obj_ChartData[indexMachineExt][indexMachineThroughput].Wastage = lcl_obj_SCPMMachineThroughput._Wastage_UI32;
                });
            });

            $.each(lcl_objLst_SCPMMachineExt, function (indexMachineExt2, lcl_obj_SCPMMachineExt) {
                // print(lcl_obj_ChartData[indexMachineExt]);
                var settings = {
                    title: "Day to Day Machine Throughput : " + lcl_obj_SCPMMachineExt._Name_STR,
                    description: "Comparison between Target and Achieved Throughput",
                    padding: { left: 5, top: 5, right: 5, bottom: 5 },
                    titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
                    source: lcl_obj_ChartData[indexMachineExt2],
                    categoryAxis:
                    {
                        dataField: 'Date',
                        showGridLines: false
                    },
                    colorScheme: 'scheme03',
                    showToolTips: false,
                    enableAnimations: true,
                    seriesGroups:
                    [
                        {
                            type: 'column',
                            valueAxis:
                            {
                                minValue: 0,
                                maxValue: (lcl_obj_SCPMMachineExt._TargetThroughput_UI32 * 2), //8 hours a shift * 2 shift
                                unitInterval: ((lcl_obj_SCPMMachineExt._TargetThroughput_UI32 * 2) / 10),
                                description: 'Throughput in ' + lcl_obj_SCPMMachineExt._MeasurementUnit_STR
                            },
                            mouseover: myEventHandler,
                            mouseout: myEventHandler,
                            click: myEventHandler,

                            series: [
                                    { dataField: 'TargetThroughput', displayText: 'Target' },
                                    { dataField: 'Throughput', displayText: 'Achieved' }
                                    //{ dataField: 'Wastage', displayText: 'Wastage' }
                                ]
                        }
                    ]
                };
                function myEventHandler(e) {
                    //                        var eventData = '<div><b>Last Event: </b>' + e.event + '<b>, DataField: </b>' + e.serie.dataField + '<b>, Value: </b>' + e.elementValue + "</div>";
                    //                        $('#eventText').html(eventData);
                };
                $(("#MachChart-" + indexMachineExt2)).jqxChart(settings);
                //return;
                // $(("'#" + lcl_str_DVName + "'")).jqxChart(settings);
            });
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {

            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
            return false;
        }
    });
    return false;
}

/*
else if (jqXHR.status == 404) {
    alert("Requested page not found. [HTTP 404]");
} 
else if (jqXHR.status == 500) {
    alert("Internal Server Error [HTTP 500].");
}
else if (exception === 'parsererror') {
    alert("Requested JSON parse failed.");
} 
else if (exception === 'timeout') {
    alert("Time out error.");
} 
else if (exception === 'abort') {
    alert("AJAX request aborted.');
}
*/