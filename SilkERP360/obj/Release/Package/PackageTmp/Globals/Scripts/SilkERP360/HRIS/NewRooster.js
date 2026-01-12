
var GBL_EMPLOYEE_LIST_TABLE;
var EmployeeId = new Array();
$(document).ready(function () {

   $('#txtRoosterDateFrom').blur(function () { CheckIfRosterExists(); });
    
    /*********************************************************************************************************************
    lcl_str_RoosterDepartmentCode is available here. It stores the DepartmentCode of the Department whose
    Rooster is being created. Written from Code Behind NewRooster.ascx.cs.page_load func
    *********************************************************************************************************************/
    var lcl_str_RoosterDepartmentCode = $('#txtRoosterDepartmentCode').val();
    /********************************************************************************************************************
    FORMAT THE TABLE
    ********************************************************************************************************************/
    GBL_EMPLOYEE_LIST_TABLE = $('#tblEmployeeList').dataTable({
        "bJQueryUI": true,
        "sScrollY": "700px",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "oLanguage": {
            "sEmptyTable": "No Employee Data Available",
            "sZeroRecords": "No Employee Record Found For Your Specified Criteria"
        },
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            //                        // Bold the grade for all 'A' grade browsers
            //                        if (aData[4] == "A") {
            //                            $('td:eq(4)', nRow).html('<b>A</b>');
            //                        }
        },
        "aoColumns": [
                    { sTitle: 'Sel.', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: 'Photo', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: 'Emp. Id', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: 'Name', sWidth: '40%', sClass: 'alignCenter' },
                    { sTitle: 'Desgn.', sWidth: '25%', sClass: 'alignCenter' },
                  ]

    });

    /*********************************************************************************************************************/
    /*********************************************************************************************************************/
    /*********************************************************************************************************************
    Get Roosterable EmployeeProfiles 
    *********************************************************************************************************************/
   
    $.ajax(
   
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetRoosterAvailableEmployeeProfileListByDepartment",
            data: "{IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_RoosterDepartmentCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_EmployeeProfileList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_EmployeeNumber = 0;
                var lcl_str_EmployeeImage = "";
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_EmployeeData = new Array();
                
                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                    lcl_str_EmployeeImage = "data:" + lcl_obj_EmployeeProfile.Image.ImageType + ";base64," + lcl_obj_EmployeeProfile.Image.ImageData;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber] = new Array();
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][0] = "<input id='chkSelectEmployee-" + lcl_i32_EmployeeNumber.toString() + "' style='width:50%' type='checkbox'/>";
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = "<img id='imgEmployee-" + lcl_i32_EmployeeNumber + "' src='" + lcl_str_EmployeeImage + "' width='30px' height='30px'/>";
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][2] = lcl_obj_EmployeeProfile.EmployeeID;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][3] = lcl_obj_EmployeeProfile.EmployeeName;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = lcl_obj_EmployeeProfile.Designation.Name;
                    lcl_i32_EmployeeNumber++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();
                var lcl_i32_CtrlIdx = 0;
                var lcl_i32_DesignationCounter = 0;
                //SAVE EmployeeCode into the chkSelectEmployee0-n controls
                var lcl_strArr_UniqueDepartmentCodes = new Array();
                var lcl_strArr_UniqueDepartmentNames = new Array();
                var lcl_str_RoosterDesignationSummeryHTMLTable = "<table style='width:90%; margin:0 auto;'><caption style='text-align:center;'><span><b>Rooster Summery</b></span></caption><tr><td style='width:75%;text-align:center;back-color:blue;'><span><b>Desig</b></span></td><td style='width:25%;text-align:center;'><span><b>Num</b></span></td></tr>";
                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfileTmp) {
                    $(("#chkSelectEmployee-" + lcl_i32_CtrlIdx)).data("EmployeeCode", lcl_obj_EmployeeProfileTmp.EmployeeCode);
                    $(("#chkSelectEmployee-" + lcl_i32_CtrlIdx)).data("Designation", "txt-" + lcl_obj_EmployeeProfileTmp.Designation.DesignationCode);
                    // $(("#chkSelectEmployee-" + lcl_i32_CtrlIdx)).data("EmployeeCode", lcl_obj_EmployeeProfileTmp.EmployeeCode);
                    var lcl_str_DesignationNumberId = "txt" + lcl_obj_EmployeeProfileTmp.Designation.DesignationCode;

                    if (lcl_strArr_UniqueDepartmentCodes.indexOf(lcl_obj_EmployeeProfileTmp.Designation.DesignationCode) == -1) {
                        lcl_strArr_UniqueDepartmentCodes[lcl_i32_DesignationCounter] = lcl_obj_EmployeeProfileTmp.Designation.DesignationCode;
                        lcl_strArr_UniqueDepartmentNames[lcl_i32_DesignationCounter++] = lcl_obj_EmployeeProfileTmp.Designation.Name;
                    }
                    $(("#chkSelectEmployee-" + lcl_i32_CtrlIdx)).on("click", function () {
                       // alert($(this).data("EmployeeCode"));
                        if ($(this).is(':checked')) {
                            var lcl_str_SelectedDesignation = $(this).data("Designation");
                            var lcl_str_SelectedDesignationNumber = $(("#" + lcl_str_SelectedDesignation)).text();
                            var lcl_i32_SelectedDesignationNumber = parseInt(lcl_str_SelectedDesignationNumber);
                            lcl_i32_SelectedDesignationNumber++;
                            //alert(lcl_i32_SelectedDesignationNumber.toString());
                            $(("#" + lcl_str_SelectedDesignation)).text(lcl_i32_SelectedDesignationNumber.toString());
                            addEmpId($(this).data("EmployeeCode"));
                        }
                        else {
                            var lcl_str_SelectedDesignation = $(this).data("Designation");
                            var lcl_str_SelectedDesignationNumber = $(("#" + lcl_str_SelectedDesignation)).text();
                            var lcl_i32_SelectedDesignationNumber = parseInt(lcl_str_SelectedDesignationNumber);
                            lcl_i32_SelectedDesignationNumber--;
                            //alert(lcl_i32_SelectedDesignationNumber.toString());
                            $(("#" + lcl_str_SelectedDesignation)).text(lcl_i32_SelectedDesignationNumber.toString());
                            RemoveEmpId($(this).data("EmployeeCode"));

                        }
                    });
                    lcl_i32_CtrlIdx++;
                });
                for (var i = 0; i < lcl_i32_DesignationCounter; i++) {
                    lcl_str_RoosterDesignationSummeryHTMLTable += "<tr><td><span>" + lcl_strArr_UniqueDepartmentNames[i] + "</span></td><td>" + "<span id='txt-" + lcl_strArr_UniqueDepartmentCodes[i] + "'>0</span></td></tr>";
                }
                lcl_str_RoosterDesignationSummeryHTMLTable += "</table>";
                $("#dvNotification").attr("class", "SilkInfoTable_Horizontal");
                $("#dvNotification").html(lcl_str_RoosterDesignationSummeryHTMLTable);
            }
        });
    /***************************************************************************************************************************
    ***************************************************************************************************************************/
    $("#txtRoosterDateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: false, changeYear: false, showButtonPanel: true, minDate: 0, maxDate: +30,
        onSelect: function (dateStr) {
            //add 3month with the 'Joining Date' and populate Confirmation date
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            //var years = parseInt($("#equipment_warrantyLength").val(), 10);
            d.setDate(d.getDate() + 1);
            //alert(d.toString());
            $("#txtRoosterDateTo").datepicker("option", 'minDate', d);
            $("#txtRoosterDateTo").val('');
        }
    });
    $("#txtRoosterDateTo").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: false, changeYear: false, showButtonPanel: true, minDate: 0, maxDate: +30,
        onSelect: function (dateStr) {
            lcl_str_PlaceHolderValue = $("#txtRoosterDateFrom").attr("placeholder").toString();
            $("#txtRoosterDateFrom").attr("placeholder", '');
            if ($.trim($("#txtRoosterDateFrom").val().toString()) == '') {
                //$(this).css('background-color', 'red');
                DisplayError("You Must Select a Date for the Field 'Date From' Before Selecting this date!!!");
                $("#txtRoosterDateTo").val('');
            }
            $("#txtRoosterDateFrom").attr("placeholder", lcl_str_PlaceHolderValue);
        }
    });
    $("#txtShiftChangeDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: false, changeYear: false, showButtonPanel: true, minDate: 0, maxDate: +30,
        onSelect: function (dateStr) {
            //            lcl_str_PlaceHolderValue = $("#txtRoosterDateFrom").attr("placeholder").toString();
            //            $("#txtShiftChangeDate").attr("placeholder", '');
            //            if ($.trim($("#txtShiftChangeDate").val().toString()) == '') {
            //                //$(this).css('background-color', 'red');
            //                DisplayError("You Must Select a Date for the Field 'Date From' Before Selecting this date!!!");
            //                $("#txtRoosterDateTo").val('');
            //            }
            //            $("#txtRoosterDateFrom").attr("placeholder", lcl_str_PlaceHolderValue);
        }
    });


});

function SaveRoster() {
    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            //test
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        if (lcl_b_InputValidated == true) {
            var lcl_obj_EmployeeRooster = new Object();

            // lcl_obj_EmployeeRooster.RoosTerMaseterCode = $("#ddl_LeaveType_id option:selected").val();
            lcl_obj_EmployeeRooster.ShiftCode = $("#ddlShift option:selected").val();
            lcl_obj_EmployeeRooster.DepartmentCode = $('#txtRoosterDepartmentCode').val();
            lcl_obj_EmployeeRooster.RosterDateFrom = $('#txtRoosterDateFrom').val();
            lcl_obj_EmployeeRooster.RosterDateTo = $('#txtRoosterDateTo').val();
            lcl_obj_EmployeeRooster.RosterChangeDate = $('#txtShiftChangeDate').val();
            var lcl_i32_EmployeeCount = EmployeeId.length;
            lcl_obj_EmployeeRooster.EmployeeRooster = new Array();
            for (var i = 0; i < lcl_i32_EmployeeCount; i++) {
                lcl_obj_EmployeeRooster.EmployeeRooster[i] = new Object();
                lcl_obj_EmployeeRooster.EmployeeRooster[i].DutyDate = $('#txtShiftChangeDate').val();
                lcl_obj_EmployeeRooster.EmployeeRooster[i].EmployeeCode = EmployeeId[i];

            }

            //alert(lcl_obj_LeaveApplication.LeaveCategory);
            debugger;

            $.ajax(
                    {

                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        //url: gbl_URL_Root + "/WebServices/HRIS/RoasterService.asmx/SaveRoosterMaster",
                        url: "~/../../../WebServices/HRIS/RoasterService.asmx/SaveRoosterMaster",
                        data: "{IP_Obj_RoosterMaster:" + JSON.stringify(lcl_obj_EmployeeRooster) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />

                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {
                                DisplayInformation(WSReturn.Message);
                                return true;
                            }
                            else {
                                DisplayError(WSReturn.Message.toString());
                            }
                        },
                        error: function (data) {
                            alert(data);
                            // $.unblockUI();
                        }
                    });


        }



    }
}                    
                       
//                        success: function (response) {
//                        var WSReturn = response.d;




//                     if (WSReturn.ResponseCode == 0) {
//                            
////                                $('select').val('');
////                                $("input:not(:button)").val('');
////                                $("input:not(:submit)").val('');

//                                //alert(WSReturn.Message);
//                                //DisplayInformation("Rooster Save Successfully");
//                                DisplayInformation(WSReturn.Message);
//                                return true;
//                            }
//                            else {
//                                //alert(WSReturn.Message.toString());
//                                DisplayError("Critical Unknown Error!");
//                            }
//                        },
//                        error: function (data) {
//                            //alert(data);
//                            // $.unblockUI();
//                        }
//                    });

//                    return false;
//                }
//                
//    }
//   
//}




function addEmpId(empid){

EmployeeId.push(empid)

//alert(EmployeeId);
}

function RemoveEmpId(empid){

    EmployeeId = jQuery.grep(EmployeeId, function (value) {
  return value != empid;
});

//alert(EmployeeId);
}



////////////////////Check rooster //////////////////////////////////
function CheckIfRosterExists() {
    var lcl_str_PlaceHolderValue = $('#txtRoosterDateFrom').attr("PlaceHolder").toString();
    $('#txtRoosterDateFrom').attr("PlaceHolder", '');
    var lcl_dt_DateFrom = $.trim($('#txtRoosterDateFrom').val().toString());
    if (lcl_dt_DateFrom == "") {
        $('#txtRoosterDateFrom').attr("PlaceHolder", lcl_str_PlaceHolderValue);
        return;
    }
    debugger;
    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/CheckIfRosterExists",
            data: "{IP_srt_fromdate:" + JSON.stringify(lcl_dt_DateFrom) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("Rooster already exists in the database!!!");
                    $('#txtRoosterDateFrom').val('');
                    $('#txtRoosterDateFrom').attr("PlaceHolder", lcl_str_PlaceHolderValue);
                    return;
                }


            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });
}


function CreateRosterName() {

    if (confirm("Are you sure want to Create a Rooster?") == true) {
        /************************************************************************************************************/
        alert("y");
        debugger;
        var lcl_b_InputValidated = true;
        //input validation
//        $('#apply-form input').blur(function () {
//            if (!$(this).val()) {
//                $(this).parents('p').addClass('warning');
//            }
//        });
//        $('.input-required').each(function (i, obj) {
//            //test
//            if ($.trim($(this).val().toString()) == '') {
//                $(this).css('background-color', 'red');
//                lcl_b_InputValidated = false;
//            }
//        });
//        if (lcl_b_InputValidated == false) {
//            alert("The fields with red background are mandatory fields.Please Fill those fields!!!");
//            return false;
//        }

        debugger;
        var lcl_ui64_CompanyCode = trim($('#ddlCompany option:selected').val());
        var lcl_ui64_ShiftCode = $("#ddlShift option:selected").val();
        var lcl_ui64_DepartmentCode = $('#txtRoosterDepartmentCode').val();
        var lcl_dt_RosterDateFrom = $('#txtRoosterDateFrom').val();
        var lcl_dt_RosterDateTo = $('#txtRoosterDateTo').val();
        
    }
    else {
        return false;
    }
}