$(document).ready(function () {
    //var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    //$('#ddlDepartment').change(function () { DepartmentChangeEvent(); });

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

function Analyse() {
    var lcl_str_StartDate = $("#txtStartDate").val();
    var lcl_str_EndDate = $("#txtEndDate").val();
    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: "/SILKERP/WebServices/SCPM/SCProductionService.asmx/GetAllSectionAvgThroughput",
        data: "{IP_str_StartDate: '" + lcl_str_StartDate + "',IP_str_EndDate:'" + lcl_str_EndDate + "'}", //provide input for the getSM_PO method
        dataType: "json",
        success: function (response) {
            var WSResponse = response.d;
            if (WSResponse.ResponseCode < 0) {
                DisplayError(WSResponse.Message);
                return;
            }
            var lcl_lst_SectionList = WSResponse.Data;
            var lcl_i32_ChartNo = 1;
            var lcl_str_SectionHTML = "";
            $('#tblAllSectionData').empty();
            $.each(lcl_lst_SectionList, function (indexSection, lcl_obj_Section) {
                lcl_str_SectionHTML += "<tr style='width:100%;'>";
                lcl_str_SectionHTML += "<td style='width:100%;text-align:center;'>";
                lcl_str_SectionHTML += "<div class='scpm_data_grid' style='width:99%;margin:0 auto;'>";
                lcl_str_SectionHTML += "<table style='width:100%;'>";
                lcl_str_SectionHTML += "<caption style='text-align:left;border:1px solid black;font-size:14px;'>";
                lcl_str_SectionHTML += "Section :";
                lcl_str_SectionHTML += lcl_obj_Section._Name_STR;
                lcl_str_SectionHTML += "</caption>";
                lcl_str_SectionHTML += "<tr>";
                lcl_str_SectionHTML += "<td style='width:25%'>" +
                                            "Process" +
                                        "</td>" +
                                        "<td style='width:15%'>" +
                                            "Date From" +
                                        "</td>" +
                                        "<td style='width:15%'>" +
                                            "Date To" +
                                        "</td>" +
                                        "<td style='width:25%'>" +
                                            "Machine" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Target" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Throughput" +
                                        "</td>" +
                                        "</tr>";
                var lcl_objLst_Process = lcl_obj_Section._SCPMProcesses;
                
                $.each(lcl_objLst_Process, function (indexProcess, lcl_obj_Process) {

                    var lcl_objLst_AvgMachineThroughputList = lcl_obj_Process._SCPMAvgMachineThroughputList;
                    var lcl_i32_MachineCount = lcl_objLst_AvgMachineThroughputList.length;
                    $.each(lcl_objLst_AvgMachineThroughputList, function (indexMachine, lcl_obj_AvgMachineThroughput) {
                        if (indexMachine == 0) {
                            lcl_str_SectionHTML += "<tr>" +
                                                    "<td rowspan=" + lcl_i32_MachineCount + ">" +
                                                        lcl_obj_Process._Name_STR +
                                                    "</td>" +
                                                    "<td>" +
                                                        lcl_str_StartDate +
                                                    "</td>" +
                                                    "<td>" +
                                                        lcl_str_EndDate +
                                                    "</td>" +
                                                    "<td>" +
                                                        lcl_obj_AvgMachineThroughput._Name_STR +
                                                    "</td>" +
                                                    "<td>" +
                                                        lcl_obj_AvgMachineThroughput._AvgTargetThroughput +
                                                    "</td>" +
                                                    "<td>" +
                                                        lcl_obj_AvgMachineThroughput._AvgThroughput.toString()
                            "</td>" +
                                                "</tr>";
                        }
                        else {
                            lcl_str_SectionHTML += "<tr>" +
                            "<td>" +
                                lcl_str_StartDate +
                            "</td>" +
                            "<td>" +
                                lcl_str_EndDate +
                            "</td>" +
                            "<td>" +
                                lcl_obj_AvgMachineThroughput._Name_STR +
                            "</td>" +
                            "<td>" +
                                lcl_obj_AvgMachineThroughput._AvgTargetThroughput +
                            "</td>" +
                            "<td>" +
                                lcl_obj_AvgMachineThroughput._AvgThroughput
                            "</td>" +
                        "</tr>";
                        }
                        //alert(lcl_obj_MachineThroughput._AvgThroughput);
                        //create chart



                    });
                });

                lcl_str_SectionHTML += "</table>";
                lcl_str_SectionHTML += "</div>";
                lcl_str_SectionHTML += "</td>";
                lcl_str_SectionHTML += "</tr>";
                
                $('#tblAllSectionData').append(lcl_str_SectionHTML);
                lcl_str_SectionHTML = "";
            });
            //$("#dvReport").show().fadeIn(1000);
        }, /// <reference path= />
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
}