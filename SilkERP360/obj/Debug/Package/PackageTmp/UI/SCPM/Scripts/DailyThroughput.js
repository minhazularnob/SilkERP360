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

function GetDailyThroughput() {
    var lcl_str_Date = $("#txtDate").val();

    $.ajax(
    {
        type: "POST",
        async: true,
        contentType: "application/json; charset=utf-8",
        global: true,
        url: "/SILKERP/WebServices/SCPM/SCProductionService.asmx/GetAllSectionThroughputByDate",
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
            var lcl_str_SectionHTML = "";
            $('#tblAllSectionThroughput').empty();
            var lcl_str_SectionHTML = "";
            $.each(lcl_lst_SectionwiseThroughputList, function (indexSection1, lcl_obj_SectionwiseThroughput) {
                var lcl_obj_ProcesswiseMachineThroughputList = lcl_obj_SectionwiseThroughput._ProcesswiseMachineThroughputList;
                lcl_str_SectionHTML += "<tr style='width:100%;'>";
                lcl_str_SectionHTML += "<td style='width:100%;text-align:center;'>";
                lcl_str_SectionHTML += "<div class='scpm_data_grid' style='width:99%;margin:0 auto;'>";

                lcl_str_SectionHTML += "<table style='width:100%;'>";
                lcl_str_SectionHTML += "<caption style='text-align:left;border:1px solid black;font-size:14px;'>";
                lcl_str_SectionHTML += "<b>Section :</b>";
                lcl_str_SectionHTML += lcl_obj_SectionwiseThroughput._Name;
                lcl_str_SectionHTML += "<br/><b>    Date :</b>";
                lcl_str_SectionHTML += lcl_str_Date
                lcl_str_SectionHTML += "</caption>";
                lcl_str_SectionHTML += "<tr>";
                lcl_str_SectionHTML += "<td style='width:15%'>" +
                                            "Process" +
                                        "</td>" +
                                        "<td style='width:20%'>" +
                                            "Machine" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Shift" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Target" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Throughput" +
                                        "</td>" +
                                        "<td style='width:10%'>" +
                                            "Wastage" +
                                        "</td>" +
                                        "<td style='width:25%'>" +
                                            "Remarks" +
                                        "</td>" +
                                        "</tr>";
                $.each(lcl_obj_ProcesswiseMachineThroughputList, function (indexSection2, lcl_obj_ProcesswiseMachineThroughput) {
                    var lcl_obj_MachinewiseThroughputList = lcl_obj_ProcesswiseMachineThroughput._MachinewiseThroughputList;
                    var lcl_i32_MachineCount = lcl_obj_MachinewiseThroughputList.length;
                    $.each(lcl_obj_MachinewiseThroughputList, function (indexSection3, lcl_obj_MachinewiseThroughput) {
                        var lcl_obj_MachineThroughputList = lcl_obj_MachinewiseThroughput._MachineThroughputList;

                        $.each(lcl_obj_MachineThroughputList, function (indexSection4, lcl_obj_MachineThroughput) {
                            lcl_i32_Counter++;
                            lcl_str_SectionHTML += "<tr>";
                            //                            lcl_str_SectionHTML += "<td rowspan='" + lcl_i32_MachineCount + "'>" +
                            //                                                        lcl_obj_ProcesswiseMachineThroughput._Name + //ProcessName
                            //                                                   "</td>";
                            //                            lcl_str_SectionHTML += "<td rowspan='" + lcl_i32_MachineCount + "'>" +
                            //                                                        lcl_str_Date +
                            //                                                   "</td>";
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_ProcesswiseMachineThroughput._Name + //ProcessName
                                                   "</td>";

                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_MachinewiseThroughput._Name + //Machine Name
                                                   "</td>";
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_MachineThroughput._AdditionalData.ShiftName + //Shift
                                                   "</td>";
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_MachineThroughput._TargetThroughput + //Machine Name
                                                   "</td>";
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_MachineThroughput._Throughput + //Machine Name
                                                   "</td>";
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_obj_MachineThroughput._Wastage + //Machine Name
                                                   "</td>";
                            var lcl_str_Remarks = lcl_obj_MachineThroughput._Remarks;
                            if (lcl_obj_MachineThroughput._DailySCPMMachineStatus == 1) {
                                lcl_str_Remarks = "SCHEDULED SHIFT OFF";
                            }

                            if (lcl_obj_MachineThroughput._DailySCPMMachineStatus == 2) {
                                lcl_str_Remarks = "MACHINE DOWN : MECH. ERROR";
                            }
                            if (lcl_obj_MachineThroughput._DailySCPMMachineStatus == 3) {
                                lcl_str_Remarks = "MACHINE DOWN : NO RAW MATERIAL";
                            }
                            if (lcl_obj_MachineThroughput._DailySCPMMachineStatus == 4) {
                                lcl_str_Remarks = "MACHINE DOWN : NO ORDER";
                            }
                            if (lcl_obj_MachineThroughput._DailySCPMMachineStatus == 4) {
                                lcl_str_Remarks = "MACHINE DOWN : NO SPARE PART";
                            }
                            lcl_str_SectionHTML += "<td>" +
                                                        lcl_str_Remarks + //Machine Name
                                                   "</td>";
                            lcl_str_SectionHTML += "</tr>";
                            //alert(lcl_obj_MachineThroughput._Remarks);
                        });
                    });

                });
                lcl_str_SectionHTML += "</table>";
                lcl_str_SectionHTML += "</div>";
                lcl_str_SectionHTML += "</td>";
                lcl_str_SectionHTML += "</tr>";


            });
            $('#tblAllSectionThroughput').append(lcl_str_SectionHTML);
            lcl_str_SectionHTML = "";
            //alert(lcl_i32_Counter.toString());
        },
        error: function (event, jqxhr, settings, exception) {
            DisplayError("There seems to be some network or server problem!!!Please contact the administrator!!!");
        }
    });
}
