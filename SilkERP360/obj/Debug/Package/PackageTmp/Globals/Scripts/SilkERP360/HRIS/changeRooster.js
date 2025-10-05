var GBL_EMPLOYEE_LIST_TABLE;
var EmployeeId = new Array();

$(document).ready(function () {

    //  $(document).click(function (e) { e.preventDefault(); });
    var lcl_str_RoosterMstCode;
    var lcl_ui64_EmployeeCode;
    $('#ddlRoosterName').change(function () { LoadRoosterEmployee(); });



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

});

function LoadRoosterEmployee() {
    GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
     lcl_str_RoosterMstCode = $.trim($('#ddlRoosterName option:selected').val());
    var lcl_str_RoosterDepartmentCode = gbl_ui64_DepartmentCode;


    $.ajax(

        {
            async: false,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetExistingRoosterEmployeeProfileListByDepartment",
            data: "{IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_RoosterDepartmentCode) + ",IP_ui64_RoosterMasterCode:" + JSON.stringify(lcl_str_RoosterMstCode) + "}", //provide input for the getSM_PO method
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

                var lcl_i32_CtrlIdx = 0;
                var lcl_i32_DesignationCounter = 0;
                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_EmployeeData = new Array();
                var ChecktxtRooster = "";
                $.each(lcl_obj_EmployeeProfileList, function (index, lcl_obj_EmployeeProfile) {
                    lcl_str_EmployeeImage = "data:" + lcl_obj_EmployeeProfile.Image.ImageType + ";base64," + lcl_obj_EmployeeProfile.Image.ImageData;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber] = new Array();
                    if (lcl_obj_EmployeeProfile.IsRooster == 1) {
                        ChecktxtRooster = "checked=checked";
                    }
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][0] = "<input id='chkSelectEmployee-" + lcl_i32_EmployeeNumber.toString() + "' style='width:50%' " + ChecktxtRooster + " type='checkbox'/>";
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][1] = "<img id='imgEmployee-" + lcl_i32_EmployeeNumber + "' src='" + lcl_str_EmployeeImage + "' width='30px' height='30px'/>";
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][2] = lcl_obj_EmployeeProfile.EmployeeID;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][3] = lcl_obj_EmployeeProfile.EmployeeName;
                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][4] = lcl_obj_EmployeeProfile.Designation.Name;
//                    lcl_str_EmployeeData[lcl_i32_EmployeeNumber][5] = "<a id='hlnkContextMenu-" + lcl_i32_EmployeeNumber.toString() + "' rel='hlnkContextMenu" + lcl_i32_EmployeeNumber.toString() + "' class='ctx_mnu' href='#'><img id='" + lcl_obj_EmployeeProfile.EmployeeCode.toString() + "' src='~/../../../Globals/Images/cntx_mnu.png' style='width:30px;height:30px;'/></a>";
                    lcl_i32_EmployeeNumber++;
                    ChecktxtRooster = "";
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_EmployeeData);
                GBL_EMPLOYEE_LIST_TABLE.fnDraw();


                /*****************************/

                //SAVE EmployeeCode into the chkSelectEmployee0-n controls
                var lcl_strArr_UniqueDepartmentCodes = new Array();
                var lcl_strArr_UniqueDepartmentNames = new Array();
                //                var lcl_str_RoosterDesignationSummeryHTMLTable = "<table style='width:90%; margin:0 auto;'><caption style='text-align:center;'><span><b>Rooster Summery</b></span></caption><tr><td style='width:75%;text-align:center;back-color:blue;'><span><b>Desig</b></span></td><td style='width:25%;text-align:center;'><span><b>Num</b></span></td></tr>";
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

                        if ($(this).is(':checked')) {
                            var lcl_str_SelectedDesignation = $(this).data("Designation");
                            var lcl_str_SelectedDesignationNumber = $(("#" + lcl_str_SelectedDesignation)).text();
                            var lcl_i32_SelectedDesignationNumber = parseInt(lcl_str_SelectedDesignationNumber);
                            lcl_i32_SelectedDesignationNumber++;
                            //alert(lcl_i32_SelectedDesignationNumber.toString());
                            $(("#" + lcl_str_SelectedDesignation)).text(lcl_i32_SelectedDesignationNumber.toString());
                            
                            lcl_ui64_EmployeeCode = $(this).data("EmployeeCode");
                            AddToRooster();
                        }
                        else {

                            var lcl_str_SelectedDesignation = $(this).data("Designation");
                            var lcl_str_SelectedDesignationNumber = $(("#" + lcl_str_SelectedDesignation)).text();
                            var lcl_i32_SelectedDesignationNumber = parseInt(lcl_str_SelectedDesignationNumber);
                            lcl_i32_SelectedDesignationNumber--;
                            //alert(lcl_i32_SelectedDesignationNumber.toString());
                            $(("#" + lcl_str_SelectedDesignation)).text(lcl_i32_SelectedDesignationNumber.toString());
                            lcl_ui64_EmployeeCode = $(this).data("EmployeeCode");
                            RemoveFromRooster();

                        }
                    });
                    lcl_i32_CtrlIdx++;
                });
                //                for (var i = 0; i < lcl_i32_DesignationCounter; i++) {

                //                    lcl_str_RoosterDesignationSummeryHTMLTable += "<tr><td><span>" + lcl_strArr_UniqueDepartmentNames[i] + "</span></td><td>" + "<span id='txt-" + lcl_strArr_UniqueDepartmentCodes[i] + "'>0</span></td></tr>";
                //                }
                //                lcl_str_RoosterDesignationSummeryHTMLTable += "</table>";
                //                $("#dvNotification").attr("class", "SilkInfoTable_Horizontal");
                //                $("#dvNotification").html(lcl_str_RoosterDesignationSummeryHTMLTable);
                /*****************************/
            }
        });
    }


    function RemoveFromRooster() {
 
        // lcl_ui64_EmployeeCode = ui.target.attr('id')
        lcl_str_RoosterMstCode = $.trim($('#ddlRoosterName option:selected').val());
        if (confirm("Are you sure you want to Remove From Roster?") == true) {
            debugger;
            $.ajax(
                {

                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/HRIS/RoasterService.asmx/RemoveFromRooster",
                    data: "{ IP_ui64_RoosterMasterCode:" + JSON.stringify(lcl_str_RoosterMstCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_EmployeeCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadRoosterEmployee();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
        }
            else {
                LoadRoosterEmployee();
            return false;
        }

    }


    function AddToRooster() {

        lcl_str_RoosterMstCode = $.trim($('#ddlRoosterName option:selected').val());
        if (confirm("Are you sure you want to Add To Rooster?") == true) {
            debugger;
            $.ajax(
                {

                    type: "POST",
                    async: true,
                    contentType: "application/json; charset=utf-8",
                    global: true,
                    url: gbl_URL_Root + "WebServices/HRIS/RoasterService.asmx/AddToRooster",
                    data: "{ IP_ui64_RoosterMasterCode:" + JSON.stringify(lcl_str_RoosterMstCode) + " ,IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_EmployeeCode) + "}", //provide input for the getSM_PO method
                    dataType: "json",
                    success: function (response) {
                        var WSReturn = response.d;
                        if (WSReturn.ResponseCode == 0) {
                            DisplayInformation(WSReturn.Message.toString());
                            LoadRoosterEmployee();
                            return true;

                        }
                        else {
                            DisplayError(WSReturn.Message.toString());
                        }

                    }
                });
        }
        else {
            LoadRoosterEmployee();
            return false;
        }

    }