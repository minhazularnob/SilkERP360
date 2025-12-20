var numWeekEnd = new Array();

$(document).ready(function () {
    $(function () { $("#tabs").tabs(); });

    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val();  // $("#txtCompanyCode").val().toString();

    var lcl_str_designationCode = $('#ddl_Off_Department option:selected').val();

    var lcl_str_WMDataSup = "{IP_ui64_designationCode :" + lcl_str_designationCode + "}";

    LoadLeaveList();
    CheckBoxCount();


    $('#txt_Sal_Gross').blur(function () { GrossSalaryChange(); });
    $('#txt_Off_ACSCode').blur(function () { CheckIfACSCodeExists(); });
    $('#txt_Pers_VoterCardNo').blur(function () { CheckIfVoterIDExists(); });
    $('#txt_Pers_PassportNo').blur(function () { CheckIfPassPortNoExists(); });
    $('#ddl_Off_Designation').change(function () { DesignationChangeEvent(); });
    $('#txt_Off_AutoRefEmployee').change(function () { AutoRefEmployeeChangeEvent(); });
    $('#ddl_Off_Department').change(function () { DepartmentChangeEvent(); });
    $('#txt_Off_Tin').blur(function () { CheckIfEtinExists(); });

    $("#chk_eTIN_Eligible").click(function () {
        if ($('#chk_eTIN_Eligible').is(':checked')) {
            $('#txt_Off_Tin').removeAttr('disabled');
            $('#txt_Off_Tin').val('');

            return true;
        }
        $('#txt_Off_Tin').val('');
        $('#txt_Off_Tin').attr('disabled', true);

        return true;

    });
    $("#chkBankSalary").click(function () {
        if ($('#chkBankSalary').is(':checked')) {
            $('#txt_Off_BankAccountCode').removeAttr('disabled');
            $('#txt_Off_BankAccountCode').val('');

            return true;
        }
        $('#txt_Off_BankAccountCode').val('');
        $('#txt_Off_BankAccountCode').attr('disabled', true);

        return true;

    });

    $("#chkBankSalary").click(function () {
        if ($('#chkBankSalary').is(':checked')) {
            $('#txtBankName').removeAttr('disabled');
            $('#txtBankName').val('');

            return true;
        }
        $('#txtBankName').val('');
        $('#txtBankName').attr('disabled', true);

        return true;

    });

    $('#ddl_BondYear').change(function () {

        var dateStr = $("#txt_BondIssueDate").val();

        var d = $.datepicker.parseDate('dd/MM/yy', dateStr);

        var years = parseInt($('#ddl_BondYear option:selected').val(), 10);
        d.setFullYear(d.getFullYear() + years);
        $("#txt_BondValidityDate").datepicker('setDate', d);

        var years = parseInt($("#equipment_warrantyLength").val(), 10);

    });

    $("#txt_Exp_DateFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txt_Exp_DateTo").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txt_Off_JoiningDate").datepicker({ dateFormat: 'dd/MM/yy', showButtonPanel: true, minDate: -2, maxDate: 0,
        onSelect: function (dateStr) {
            var d = $.datepicker.parseDate('dd/MM/yy', dateStr);
            d.setMonth(d.getMonth() + 3);
            $("#txt_Off_ConfirmationDate").datepicker('setDate', d);
        }
    });

    $("#txt_Off_ConfirmationDate").datepicker({ dateFormat: 'dd/MM/yy', showButtonPanel: true });
    $("#txt_Off_RetirementDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, minDate: 0 });
    $("#txt_Off_SettlementDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, minDate: 0 });
    $("#txt_Off_PFStartDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, minDate: 0 });
    $("#txt_Pers_DateOfBirth").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true, maxDate: "-18Y" });
    $("#txt_BondValidityDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txt_BondIssueDate").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });



    $(function () {
        $("#txt_Off_JoiningDate").datepicker();
    });
    

    initializeSelect2('ddl_Off_Department', '-----Select Department-----', '100%');
    initializeSelect2('ddl_Off_RefEmployee', '----- Select REF. Employee -----', '100%');
    initializeSelect2('ddl_Off_Supervisor', '----- Select Supervisor -----', '100%');
    initializeSelect2('ddl_BondYear', '-----Select Bond Year-----', '100%');
    initializeSelect2('txtBankName', '------Select Bank-----', '100%');
    initializeSelect2('ddl_JobLocation', '------Select Job Location-----', '100%');

    initializeSelect2('ddl_Pers_MaritalStatus', '-----Select Marital Status-----', '100%');
    initializeSelect2('ddl_Pers_Sex', '-----Select Gender-----', '100%');
    initializeSelect2('ddl_Pers_Religion', '----- Select Religion -----', '100%');
    initializeSelect2('ddl_Pers_BloodGroup', '-----Select Blood Group-----', '100%');
    initializeSelect2('ddl_Pers_PresentDistrict', '-----Select District-----', '100%');
    initializeSelect2('ddl_Pers_PermanentDistrict', '----- Select District -----', '100%');
    initializeSelect2('ddl_Off_Shift_Code', '-----Select Shift Code-----', '100%'); 
    initializeSelect2('ddl_Off_Designation', '-----Select Designation-----', '100%');

});
function CheckIfACSCodeExists() {
    var lcl_str_PlaceHolderValue = $('#txt_Off_ACSCode').attr("PlaceHolder").toString();
    $('#txt_Off_ACSCode').attr("PlaceHolder", '');
    var lcl_str_ACSValue = $.trim($('#txt_Off_ACSCode').val().toString());
    if (lcl_str_ACSValue == "") {
        $('#txt_Off_ACSCode').attr("PlaceHolder", lcl_str_PlaceHolderValue);
        return;
    }

    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "~/../../../WebServices/HRIS/EmployeeService.asmx/CheckIfACSCodeExists",

            data: "{IP_str_ACSCode:" + JSON.stringify(lcl_str_ACSValue) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("The ACS Code entered already exists in the database!!!Cannot Accept duplicate ACS Code!!!");
                    $('#txt_Off_ACSCode').val('');
                    $('#txt_Off_ACSCode').attr("PlaceHolder", lcl_str_PlaceHolderValue);
                    return;
                }
            },
            error: function (data) {
                DisplayInformation("Fatal Server Error : Contact Administrator!!!");
            }
        });
}
function CheckIfVoterIDExists() {
    var lcl_str_PlaceHolderValue = $('#txt_Pers_VoterCardNo').attr("PlaceHolder").toString();
    $('#txt_Pers_VoterCardNo').attr("PlaceHolder", '');
    var lcl_str_VoterIDValue = $.trim($('#txt_Pers_VoterCardNo').val().toString());
    if (lcl_str_VoterIDValue == "") {
        $('#txt_Pers_VoterCardNo').attr("PlaceHolder", lcl_str_PlaceHolderValue);
        return;
    }

    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: " ~/../../../WebServices/HRIS/EmployeeService.asmx/CheckIfVoterIDExists",

            data: "{IP_str_VoterID:" + JSON.stringify(lcl_str_VoterIDValue) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("The Voter ID entered already exists in the database!!!Cannot Accept duplicate Voter ID!!!");
                    $('#txt_Pers_VoterCardNo').val('');
                    $('#txt_Pers_VoterCardNo').attr("PlaceHolder", lcl_str_PlaceHolderValue);
                    return;
                }
            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });
    }
    function CheckIfEtinExists() {
        var lcl_str_PlaceHolderValue = $('#txt_Off_Tin').attr("PlaceHolder").toString();
        $('#txt_Off_Tin').attr("PlaceHolder", '');
        var lcl_str_eTinIDValue = $.trim($('#txt_Off_Tin').val().toString());
        if (lcl_str_eTinIDValue == "") {
            $('#txt_Off_Tin').attr("PlaceHolder", lcl_str_PlaceHolderValue);
            return;
        }

        $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/CheckIfEtinExists",
            data: "{IP_str_eTinID:" + JSON.stringify(lcl_str_eTinIDValue) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("The e-TIN ID entered already exists in the database!!!Cannot Accept duplicate e-TIN ID!!!");
                    $('#txt_Off_Tin').val('');
                    $('#txt_Off_Tin').attr("PlaceHolder", lcl_str_PlaceHolderValue);
                    return;
                }
            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });
    }

function CheckIfPassPortNoExists() {
    var lcl_str_PlaceHolderValue = $('#txt_Pers_PassportNo').attr("PlaceHolder").toString();
    $('#txt_Pers_PassportNo').attr("PlaceHolder", '');
    var lcl_str_PassPortNoValue = $.trim($('#txt_Pers_PassportNo').val().toString());
    if (lcl_str_PassPortNoValue == "") {
        $('#txt_Pers_PassportNo').attr("PlaceHolder", lcl_str_PlaceHolderValue);
        return;
    }

    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: " ~/../../../WebServices/HRIS/EmployeeService.asmx/CheckIfPassPortNoExists",

            data: "{IP_str_PassPortNo:" + JSON.stringify(lcl_str_PassPortNoValue) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("The PassPort No entered already exists in the database!!!Cannot Accept duplicate PassPort No!!!");
                    $('#txt_Pers_PassportNo').val('');
                    $('#txt_Pers_PassportNo').attr("PlaceHolder", lcl_str_PlaceHolderValue);
                    return;
                }
            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });
}

function ConfigureLeaveList(response) {

    var lcl_obj_WSResponse = response.d;
    switch (lcl_obj_WSResponse.WebServiceExecutionStatus) {
        case 0:
            var lcl_obj_Leave_List = lcl_obj_WSResponse.Data;
            var lcl_i32_Leave_Counter = 0;
            $.each(lcl_obj_Leave_List, function (index, lcl_obj_Leave) {
                lcl_i32_Leave_Counter++;
                var lcl_str_Leave_HTML = "<tr>";
                lcl_str_Leave_HTML += "<td align='center' style='width:20%;text-align:center;'><input id='chkLeave-" + lcl_i32_Leave_Counter.toString() + "' style='width:50%' type='checkbox'/></td>";
                lcl_str_Leave_HTML += "<td align='center' style='width:30%;text-align:center;'>" + lcl_obj_Leave.LeaveName + "</td>";
                lcl_str_Leave_HTML += "<td align='center' style='width:30%';text-align:center;>" + lcl_obj_Leave.NoOfDays + "</td>";
                lcl_str_Leave_HTML += "<td align='center' style='width:20%';text-align:center;>" + lcl_obj_Leave.IsCarryForwarded + "</td>";
                lcl_str_Leave_HTML += "<input id='txtLeaveCode-" + lcl_i32_Leave_Counter.toString() + "' type='hidden' value='" + lcl_obj_Leave.LeaveCode + "'/>";
                lcl_str_Leave_HTML += "<input id='txtBalance-" + lcl_i32_Leave_Counter.toString() + "' type='hidden' value='" + lcl_obj_Leave.NoOfDays + "'/>";
                lcl_str_Leave_HTML += "</tr>";

                $("#tblLeave tr:last").after(lcl_str_Leave_HTML);
                $("#tblLeave tr:last").hide().fadeIn('slow');
                $("#txtLeaveCounter").val(lcl_i32_Leave_Counter.toString());
            });
            break;
        case 1:
            DisplayError(lcl_obj_WSResponse.Message);
            break;
        case 2:
            DisplayError(lcl_obj_WSResponse.Message);
            break;
    }
}
function DesignationChangeEvent() {

    var lcl_str_SelectedText = $.trim($('#ddl_Off_Designation option:selected').text());

    if (lcl_str_SelectedText == '') {
        return;
    }
    var lcl_str_DesignationCode = $.trim($('#ddl_Off_Designation option:selected').val());

    var lcl_str_CompanyCode = $("#ddlCompany option:selected").val();
    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: " ~/../../../WebServices/HRIS/DesignationService.asmx/GetDesignationDetails",
            data: "{IP_ui64_DesignationCode:" + JSON.stringify(lcl_str_DesignationCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;

                var lcl_obj_Salary_Structure = WSReturn.Data;
                $("#txt_Stan_Sal_Basic").val(lcl_obj_Salary_Structure.Basic);
                $("#txt_Stan_Sal_HouseRent").val(lcl_obj_Salary_Structure.HouseRent);
                $("#txt_Stan_Sal_Medical").val(lcl_obj_Salary_Structure.Medical);
                $("#txt_Stan_Sal_Entertainment").val(lcl_obj_Salary_Structure.Entertainment);
                $("#txt_Stan_Sal_Conveyence").val(lcl_obj_Salary_Structure.Conveyence);
                $("#txt_Stan_Sal_PhoneBill").val(lcl_obj_Salary_Structure.PhoneBill);
                $("#txt_Stan_Sal_Others").val(lcl_obj_Salary_Structure.Others);
                $("#txt_Stan_Sal_Gross").val(lcl_obj_Salary_Structure.Gross);

                $("#txt_Sal_Basic").val(lcl_obj_Salary_Structure.Basic);
                $("#txt_Sal_HouseRent").val(lcl_obj_Salary_Structure.HouseRent);
                $("#txt_Sal_Medical").val(lcl_obj_Salary_Structure.Medical);
                $("#txt_Sal_Entertainment").val(lcl_obj_Salary_Structure.Entertainment);
                $("#txt_Sal_Conveyence").val(lcl_obj_Salary_Structure.Conveyence);
                $("#txt_Sal_PhoneBill").val(lcl_obj_Salary_Structure.PhoneBill);
                $("#txt_Sal_Others").val(lcl_obj_Salary_Structure.Others);
                $("#txt_Sal_Gross").val(lcl_obj_Salary_Structure.Gross);
            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });
    return false;
}
function GrossSalaryChange() {

    var lcl_str_GrossSalary = $.trim($("#txt_Sal_Gross").val().toString());
    if (lcl_str_GrossSalary == '') {
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }
    $(".salary_field").val('0.00');
    lcl_str_GrossSalary = lcl_str_GrossSalary.replace(',', '');
    var lcl_flt_GrossSalary = parseFloat(lcl_str_GrossSalary);
    if (lcl_flt_GrossSalary == 0) {
        $(".salary_field").val('0.00');
        $(".gross_salary").val('0.00');
        return false;
    }
    var lcl_flt_Basic = (lcl_flt_GrossSalary * 60) / 100;
    $("#txt_Sal_Basic").val(lcl_flt_Basic.toString());
    var lcl_flt_HouseRent = (lcl_flt_GrossSalary * 30) / 100;
    $("#txt_Sal_HouseRent").val(lcl_flt_HouseRent.toString());
    var lcl_flt_Medical = (lcl_flt_GrossSalary * 5) / 100;
    $("#txt_Sal_Medical").val(lcl_flt_Medical.toString());
    var lcl_flt_Conveyence = (lcl_flt_GrossSalary * 5) / 100;
    $("#txt_Sal_Conveyence").val(lcl_flt_Conveyence.toString());
}
$("#tblEducation td img.row_delete_btn").on("click", function () {


    var srow = $(this).parent().parent();
    if (confirm("Do You Really Want to Delete This Row?")) {
        var lcl_i32_EducationCount = parseInt(document.getElementById("txtEducationCount").value.toString());
        lcl_i32_EducationCount--;
        document.getElementById("txtEducationCount").value = lcl_i32_EducationCount.toString();
        srow.fadeOut(500, function () {
            srow.remove();
            for (var i = 0; i < lcl_i32_EducationCount; i++) {
                var education_elements = document.getElementsByName("EducationTableRow").item(i);
                var education_ip_elements = education_elements.getElementsByTagName("input");
                education_ip_elements.item(0).setAttribute("id", "txt_Edu_ExamName-" + (i + 1).toString());
                education_ip_elements.item(1).setAttribute("id", "txt_Edu_InstituteName-" + (i + 1).toString());
                education_ip_elements.item(2).setAttribute("id", "txt_Edu_BoardUniversity-" + (i + 1).toString());
                education_ip_elements.item(3).setAttribute("id", "txt_Edu_MajorSubject-" + (i + 1).toString());
                education_ip_elements.item(4).setAttribute("id", "txt_Edu_DivisionClass-" + (i + 1).toString());
                education_ip_elements.item(5).setAttribute("id", "txt_Edu_CGPA-" + (i + 1).toString());
                education_ip_elements.item(6).setAttribute("id", "txt_Edu_PassingYear-" + (i + 1).toString());
            }
        });
    }
});

function addEducation() {
    var lcl_obj_txtExamName = document.getElementById("txt_Edu_ExamName");
    var lcl_obj_txtBoardUniversity = document.getElementById("txt_Edu_BoardUniversity");
    var lcl_obj_txtInstituteName = document.getElementById("txt_Edu_InstituteName");
    var lcl_obj_txtMajorSubject = document.getElementById("txt_Edu_MajorSubject");
    var lcl_obj_txtDivisionClass = document.getElementById("txt_Edu_DivisionClass");
    var lcl_obj_txtCGPA = document.getElementById("txt_Edu_CGPA");
    var lcl_obj_txtPassingYear = document.getElementById("txt_Edu_PassingYear");

    if (IsBlank(lcl_obj_txtExamName, "The Field 'Exam' Cannot Be Blank!!!") == false) {
        if (IsBlank(lcl_obj_txtInstituteName, "The Field 'Inst. Name' Cannot Be Blank!!!") == false) {
            if (IsBlank(lcl_obj_txtBoardUniversity, "The Field 'Board/University' Cannot Be Blank!!!") == false) {
                if (IsBlank(lcl_obj_txtPassingYear, "The Field 'Passing Year' Cannot Be Blank!!!") == false) {
                    var lcl_str_ExamName = trim(lcl_obj_txtExamName.value.toString());
                    var lcl_str_BoardUniversity = trim(lcl_obj_txtBoardUniversity.value.toString());
                    var lcl_str_InstituteName = trim(lcl_obj_txtInstituteName.value.toString());
                    var lcl_str_MajorSubject = trim(lcl_obj_txtMajorSubject.value.toString());
                    var lcl_str_DivisionClass = trim(lcl_obj_txtDivisionClass.value.toString());
                    var lcl_str_CGPA = trim(lcl_obj_txtCGPA.value.toString());
                    var lcl_str_PassingYear = trim(lcl_obj_txtPassingYear.value.toString());
                    var lcl_i32_EducationCount = parseInt(document.getElementById("txtEducationCount").value.toString());
                    lcl_i32_EducationCount++;
                    var lcl_str_HTML = "<tr name='EducationTableRow'>" +
                                            "<td align='center'><input id = 'txt_Edu_ExamName-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:94%;' value = '" + lcl_str_ExamName + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_BoardUniversity-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_BoardUniversity + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_InstituteName-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_InstituteName + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_MajorSubject-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_MajorSubject + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_DivisionClass-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_DivisionClass + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_CGPA-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_CGPA + "'></td>" +
                                            "<td align='center'><input id = 'txt_Edu_PassingYear-" + lcl_i32_EducationCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_PassingYear + "'></td>" +
                                            "<td align='center'><img src='../../Globals/Images/delete.png' class='row_delete_btn'  style='cursor:pointer;background-color:#ffffff;text-align:right;' title='Delete'/></td>" +
                                      "</tr>";
                    $("#tblEducation tbody").append(lcl_str_HTML);
                    $("#tblEducation tbody > tr:last").hide().fadeIn('slow');
                    document.getElementById("txtEducationCount").value = lcl_i32_EducationCount.toString();
                    RefreshEducationControls();
                }
            }
        }
    }
}

function RefreshEducationControls() {
    document.getElementById("txt_Edu_ExamName").value = '';
    document.getElementById("txt_Edu_InstituteName").value = '';
    document.getElementById("txt_Edu_BoardUniversity").value = '';
    document.getElementById("txt_Edu_MajorSubject").value = '';
    document.getElementById("txt_Edu_DivisionClass").value = '';
    document.getElementById("txt_Edu_CGPA").value = '';
    document.getElementById("txt_Edu_PassingYear").value = '';
}

function addExperience() {

    var lcl_obj_txtOrganization = document.getElementById("txt_Exp_OrganizationName");
    var lcl_obj_txtExpAddress = document.getElementById("txt_Exp_Address");
    var lcl_obj_txtDateFrom = document.getElementById("txt_Exp_DateFrom");
    var lcl_obj_txtDateTo = document.getElementById("txt_Exp_DateTo");
    var lcl_obj_txtNatureOfJob = document.getElementById("txt_Exp_NatureOfJob");
    var lcl_obj_txtResponsibility = document.getElementById("txt_Exp_Responsibility");
    var lcl_obj_txtContactNo = document.getElementById("txt_Exp_ContactNo");


    if (IsBlank(lcl_obj_txtOrganization, "The Field 'Organization' Cannot Be Blank!!!") == false) {
        if (IsBlank(lcl_obj_txtExpAddress, "The Field 'Address' Cannot Be Blank!!!") == false) {
            if (IsBlank(lcl_obj_txtDateFrom, "Please Select a Date in the field 'From'.") == false) {
                if (IsBlank(lcl_obj_txtDateTo, "Please Select a Date in the field 'To'.") == false) {

                    var lcl_str_Organization = trim(lcl_obj_txtOrganization.value.toString());
                    var lcl_str_Address = trim(lcl_obj_txtExpAddress.value.toString());
                    var lcl_str_Responsibility = trim(lcl_obj_txtResponsibility.value.toString());
                    var lcl_str_NatureOfJob = trim(lcl_obj_txtNatureOfJob.value.toString());
                    var lcl_str_ContactNo = trim(lcl_obj_txtContactNo.value.toString());
                    var lcl_str_DateFrom = trim(lcl_obj_txtDateFrom.value.toString());
                    var lcl_str_DateTo = trim(lcl_obj_txtDateTo.value.toString());

                    lcl_i32_ExperienceCount = parseInt(document.getElementById("txtExperienceCount").value.toString());
                    lcl_i32_ExperienceCount++;

                    var lcl_str_HTML = "<tr name='ExperienceTableRow'>" +
                                            "<td align='center'><input id='txt_Exp_OrganizationName-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:94%;' value = '" + lcl_str_Organization + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_Address-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_Address + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_Responsibility-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_Responsibility + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_NatureOfJob-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:96%;' value = '" + lcl_str_NatureOfJob + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_ContactNo-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_ContactNo + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_DateFrom-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_DateFrom + "'></td>" +
                                            "<td align='center'><input id='txt_Exp_DateTo-" + lcl_i32_ExperienceCount.toString() + "' readonly='readonly' style='width:92%;' value = '" + lcl_str_DateTo + "'></td>" +
                                            "<td align='center'><img src='../../Globals/Images/delete.png' class='row_delete_btn'  style='cursor:pointer;background-color:#ffffff;text-align:right;' title='Delete'/></td>" +
                                      "</tr>";
                    $("#tblExperience tbody").append(lcl_str_HTML);
                    $("#tblExperience tbody > tr:last").hide().fadeIn('slow');

                    document.getElementById("txtExperienceCount").value = lcl_i32_ExperienceCount.toString();
                    RefreshExperienceControl();
                }
            }
        }
    }
}

function RefreshExperienceControl() {
    document.getElementById("txt_Exp_OrganizationName").value = '';
    document.getElementById("txt_Exp_Address").value = '';
    document.getElementById("txt_Exp_Responsibility").value = '';
    document.getElementById("txt_Exp_NatureOfJob").value = '';
    document.getElementById("txt_Exp_ContactNo").value = '';
    document.getElementById("txt_Exp_DateFrom").value = '';
    document.getElementById("txt_Exp_DateTo").value = '';
}

function LoadImage() {
    var input, file, fr, img;

    if (typeof window.FileReader !== 'function') {
        DisplayInformation("Please Update Your Internet Browser!!!");
        return;
    }

    input = document.getElementById('fileBrowser');
    if (!input) {
        DisplayInformation("Image Box Was Not Found!!!");
        return;
    }
    else if (!input.files) {
        DisplayInformation("Please Update Your Internet Browser!!!");
        return;
    }
    else if (!input.files[0]) {
        DisplayInformation("Please Select a File!!!");
        return;
    }
    else {
        file = input.files[0];
        var lcl_str_FileType = file.type.toString();
        if ((lcl_str_FileType != "image/png") && (lcl_str_FileType != "image/gif") && (lcl_str_FileType != "image/jpeg") && (lcl_str_FileType != "image/jpg") && (lcl_str_FileType != "image/jpeg")) {
            DisplayInformation("You can select image type 'jpg,gif,png' only!!!");
            return;
        }
        //check file size.should not exceed 300kb
        var lcl_i32_FileSize = file.size.toString();
        if (lcl_i32_FileSize / 1024 > 3000) {
            DisplayInformation("Employee Image Size Cannot Exceed 30 KB!!!");
            return;
        }

        $("#txt_EI_ImageType").val(lcl_str_FileType);
        $("#txt_EI_ImageSize").val(parseInt((lcl_i32_FileSize / 1024).toString()).toString() + " KB");
        $("#txt_EI_ImageSize").data('img_size', lcl_i32_FileSize.toString()); //storing file size in bytes
        var fr = new FileReader();
        fr.onload = function (event) {
            document.getElementById("imgEmployeeImage").setAttribute("src", event.target.result);
            //save the read image object in the fileBrowser Control.VERY IMPORTANT ISSUE
            $("#fileBrowser").data('emp_img_added', true); //indicates if image has been added.
            var lcl_str_Image = event.target.result.toString();
            var lcl_imageByte = lcl_str_Image.replace(/^data:image\/(png|jpg|gif|jpeg);base64,/, ''); //data:image/jpeg;base64,/
            $("#fileBrowser").data('emp_img', lcl_imageByte);
        }
        fr.readAsDataURL(file);
        //input.src = fr.result;

    }
}

function DeleteImage() {
    document.getElementById("imgEmployeeImage").setAttribute("src", "");
    $("#txt_EI_ImageType").val('');
    $("#txt_EI_ImageSize").val('');
    $("#txt_EI_ImageSize").data('img_size', '0');
    document.getElementById('fileBrowser').value = '';
    $("#fileBrowser").data('emp_img', '');
}
function BindRefEmpControls() {
    $("#txt_Off_RefEmployee").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "~/../../../WebServices/HRIS/AutoSearchService.asmx/GetAtutoSearceResultList",
                data: "{ 'sLookUP': '" + request.term + "' }",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return { value: item }
                    }))
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert(textStatus);
                }
            });
        },
        minLength: 1    // MINIMUM 1 CHARACTER TO START WITH.
    });
}
/*********************************************Auto RefEmp*********************************************/
function AutoRefEmployeeChangeEvent() {

    var $txt = $('input[id$=txt_Off_AutoRefEmployee]');
    var $ddl = $('select[id$=ddl_Off_RefEmployee]');
    var $items = $('select[id$=ddl_Off_RefEmployee] option');

    $txt.keyup(function () {
        searchDdl($txt.val());
    });

    function searchDdl(item) {
        $ddl.empty();
        var exp = new RegExp(item, "i");
        var arr = $.grep($items,
                    function (n) {
                        return exp.test($(n).text());
                    });

        if (arr.length > 0) {
            countItemsFound(arr.length);
            $.each(arr, function () {
                $ddl.append(this);
                $ddl.get(0).selectedIndex = 0;
            }
                    );
        }
        else {
            countItemsFound(arr.length);
            $ddl.append("<option>No Items Found</option>");
        }
    }

    function countItemsFound(num) {
        $("#para").empty();
        if ($txt.val().length) {
            $("#para").html(num + " items found");
        }

    }
}
/*********************************************Department Change Event Load ddlSupervisor List*********************************************/

function DepartmentChangeEvent() {

    var lcl_str_SelectedText = $.trim($('#ddl_Off_Department option:selected').text());

    if (lcl_str_SelectedText == '') {
        return;
    }
    var lcl_str_DepartmentCode = $.trim($('#ddl_Off_Department option:selected').val());

    var lcl_str_CompanyCode = $("#ddlCompany option:selected").val(); //Retrieve company code from hidden field

    $.ajax(
        {
            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: " ~/../../../WebServices/HRIS/EmployeeService.asmx/GetEmployeeDataByDepartment",

            data: "{IP_ui64_DepartmentCode:" + JSON.stringify(lcl_str_DepartmentCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_EmployeeMNList = WSReturn.Data;
                //CLEAR Ref Employee
                $("select[id$=#ddl_Off_Supervisor] > option").remove();
                $('#ddl_Off_Supervisor').empty();
                $('#ddl_Off_Supervisor').append($("<option value='0'>----- Select Supervisor</option>")); //.val('').html(''));
                $.each(lcl_obj_EmployeeMNList, function (index, lcl_obj_EmployeeMN) {
                    var dropdown_options = document.createElement("option");
                    dropdown_options.value = lcl_obj_EmployeeMN.EmployeeCode.toString();
                    dropdown_options.text = lcl_obj_EmployeeMN.EmployeeName + " (" + lcl_obj_EmployeeMN.EmployeeID + ")";
                    document.getElementById("ddl_Off_Supervisor").options.add(dropdown_options);
                });
            }
        });
    return false;
}


function toogleReference1Controls() {
    if ($('#chk_Ref_Reference_1').is(':checked')) {
        $('#txt_Ref_Name1').removeAttr('disabled');
        $('#txt_Ref_Name1').val('');
        $('#txt_Ref_Address1').removeAttr('disabled');
        $('#txt_Ref_Address1').val('');
        $('#txt_Ref_ContactNo1').removeAttr('disabled');
        $('#txt_Ref_ContactNo1').val('');
        $('#txt_Ref_Organization1').removeAttr('disabled');
        $('#txt_Ref_Organization1').val('');
        $('#txt_Ref_Designation1').removeAttr('disabled');
        $('#txt_Ref_Designation1').val('');
        return true;
    }
    $('#txt_Ref_Name1').val('');
    $('#txt_Ref_Name1').attr('disabled', true);
    $('#txt_Ref_Address1').val('');
    $('#txt_Ref_Address1').attr('disabled', true);
    $('#txt_Ref_ContactNo1').val('');
    $('#txt_Ref_ContactNo1').attr('disabled', true);
    $('#txt_Ref_Organization1').val('');
    $('#txt_Ref_Organization1').attr('disabled', true);
    $('#txt_Ref_Designation1').val('');
    $('#txt_Ref_Designation1').attr('disabled', true);
    if ($('#chk_Ref_Reference_2').is(':checked')) {
        $('#chk_Ref_Reference_2').attr('checked', false);
        toogleReference2Controls();
    }
    return true;
}

function toogleReference2Controls() {
    if ($('#chk_Ref_Reference_2').is(':checked')) {
        if (!($('#chk_Ref_Reference_1').is(':checked'))) {
            DisplayInformation("Please Select Reference 1 Before Selecting Reference 2!!!");
            return false;
        }
        $('#txt_Ref_Name2').removeAttr('disabled');
        $('#txt_Ref_Name2').val('');
        $('#txt_Ref_Address2').removeAttr('disabled');
        $('#txt_Ref_Address2').val('');
        $('#txt_Ref_ContactNo2').removeAttr('disabled');
        $('#txt_Ref_ContactNo2').val('');
        $('#txt_Ref_Organization2').removeAttr('disabled');
        $('#txt_Ref_Organization2').val('');
        $('#txt_Ref_Designation2').removeAttr('disabled');
        $('#txt_Ref_Designation2').val('');
        return true;
    }
    $('#txt_Ref_Name2').val('');
    $('#txt_Ref_Name2').attr('disabled', true);
    $('#txt_Ref_Address2').val('');
    $('#txt_Ref_Address2').attr('disabled', true);
    $('#txt_Ref_ContactNo2').val('');
    $('#txt_Ref_ContactNo2').attr('disabled', true);
    $('#txt_Ref_Organization2').val('');
    $('#txt_Ref_Organization2').attr('disabled', true);
    $('#txt_Ref_Designation2').val('');
    $('#txt_Ref_Designation2').attr('disabled', true);
    return true;
}

/***********************************************Save new epmloyee***********************************************************************************/
function Save() {

    if (confirm("Are you sure you want to save this employee?") == true) {
        /************************************************************************************************************/

        var lcl_b_InputValidated = true;
        /************************************************************************************************************/

        var lcl_obj_EmpApp = new Object();
        lcl_obj_EmpApp.Employee = new Object();
        lcl_obj_EmpApp.Employee.EmployeeCode = parseInt($("#txtUserEmployeeCode").val().toString()); //trim($('#txtUserEmployeeCode').val());
        lcl_obj_EmpApp.Employee.EmployeeACSCode = trim($('#txt_Off_ACSCode').val());
        lcl_obj_EmpApp.Employee.EmployeeName = trim($('#txt_Off_Name').val());
        lcl_obj_EmpApp.Employee.DesignationCode = trim($('#ddl_Off_Designation option:selected').val());
        lcl_obj_EmpApp.Employee.DepartmentCode = trim($('#ddl_Off_Department option:selected').val());
        lcl_obj_EmpApp.Employee.CompanyCode = trim($('#ddlCompany option:selected').val());
        lcl_obj_EmpApp.Employee.RefEmployeeCode = (trim($('#ddl_Off_RefEmployee option:selected').val()) == "") ? 0 : $('#ddl_Off_RefEmployee option:selected').val();
        lcl_obj_EmpApp.Employee.SupervisorCode = $('#ddl_Off_Supervisor option:selected') == 0 ? 0 : $('#ddl_Off_Supervisor option:selected').val();
        lcl_obj_EmpApp.Employee.JoiningDate = trim($('#txt_Off_JoiningDate').val());
        lcl_obj_EmpApp.Employee.ConfirmationDate = trim($('#txt_Off_ConfirmationDate').val());
        lcl_obj_EmpApp.Employee.RetirementDate = trim($('#txt_Off_RetirementDate').val());
        lcl_obj_EmpApp.Employee.SettlementDate = trim($('#txt_Off_SettlementDate').val());
        lcl_obj_EmpApp.Employee.OfficialFileNo = trim($('#txt_Off_OfficialFileNo').val());
        lcl_obj_EmpApp.Employee.JobLocation = trim($('#ddl_JobLocation option:selected').val());
        lcl_obj_EmpApp.Employee.BondIssueDate = trim($('#txt_BondIssueDate').val());
        lcl_obj_EmpApp.Employee.BondValidityDate = trim($('#txt_BondValidityDate').val());
        lcl_obj_EmpApp.Employee.BondRefference = trim($('#txt_BondRefference').val());
        lcl_obj_EmpApp.Employee.BondYear = trim($('#ddl_BondYear option:selected').val())
        lcl_obj_EmpApp.Employee.BankName = trim($('#txtBankName').val());

        if ($('#chkBankSalary').is(':checked')) {
            lcl_obj_EmpApp.Employee.SalaryPayableAtBank = 1;
            lcl_obj_EmpApp.Employee.BankAccNo = trim($('#txt_Off_BankAccountCode').val());
        }
        lcl_obj_EmpApp.Employee.Remarks = trim($('#txt_Off_Remarks').val());

        if ($('#chkPFEligable').is(':checked')) {
            lcl_obj_EmpApp.Employee.IsPfEligible = 1;

        }
        if ($('#chkOTEligable').is(':checked')) {
            lcl_obj_EmpApp.Employee.IsOtEligible = 1;
        }
        if ($('#chkRoster').is(':checked')) {
            lcl_obj_EmpApp.Employee.IsOnRoster = 1;
        }
        if ($('#checNightBill').is(':checked')) {
            lcl_obj_EmpApp.Employee.NightBillEligible = 1;
        }

        if ($('#Check_ComUniform').is(':checked')) {
            lcl_obj_EmpApp.Employee.ComUniformEligible = 1;
        }
        if ($('#chk_eTIN_Eligible').is(':checked')) {
            lcl_obj_EmpApp.Employee.eTinEligible = 1;
            lcl_obj_EmpApp.Employee.Tin = trim($('#txt_Off_Tin').val());
        }

        lcl_obj_EmpApp.Employee.ShiftCode = $('#ddl_Off_Shift_Code').val();
        lcl_obj_EmpApp.EmployeePersonal = new Object();
        lcl_obj_EmpApp.EmployeePersonal.FatherName = trim($('#txt_Pers_FatherName').val());
        lcl_obj_EmpApp.EmployeePersonal.MotherName = trim($('#txt_Pers_MotherName').val());
        lcl_obj_EmpApp.EmployeePersonal.SpouseName = trim($('#txt_Pers_SpouseName').val());
        lcl_obj_EmpApp.EmployeePersonal.DateOfBirth = trim($('#txt_Pers_DateOfBirth').val());
        lcl_obj_EmpApp.EmployeePersonal.MaritalStatus = trim($('#ddl_Pers_MaritalStatus option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.Sex = trim($('#ddl_Pers_Sex option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.Religion = trim($('#ddl_Pers_Religion option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.Nationality = trim($('#txt_Pers_Nationality').val());
        lcl_obj_EmpApp.EmployeePersonal.BloodGroup = trim($('#ddl_Pers_BloodGroup option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.Height = trim($('#txt_Pers_Height').val());
        lcl_obj_EmpApp.EmployeePersonal.Weight = trim($('#txt_Pers_Weight').val());
        lcl_obj_EmpApp.EmployeePersonal.Identification = trim($('#txt_Pers_Identification').val());
        lcl_obj_EmpApp.EmployeePersonal.MobileNo = trim($('#txt_Pers_MobileNo').val());
        lcl_obj_EmpApp.EmployeePersonal.HomePhoneNo = trim($('#txt_Pers_HomePhone').val());
        lcl_obj_EmpApp.EmployeePersonal.FaxNo = trim($('#txt_Pers_FaxNo').val());
        lcl_obj_EmpApp.EmployeePersonal.Email = trim($('#txt_Pers_Email').val());
        lcl_obj_EmpApp.EmployeePersonal.PresentAddress = trim($('#txt_Pers_PresentAddress').val());
        lcl_obj_EmpApp.EmployeePersonal.PresentPo = trim($('#txt_Pers_PresentPO').val());
        lcl_obj_EmpApp.EmployeePersonal.PresentPc = trim($('#txt_Pers_PresentPC').val());
        lcl_obj_EmpApp.EmployeePersonal.PresentDistrictCode = trim($('#ddl_Pers_PresentDistrict option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.PermanentAddress = trim($('#txt_Pers_PermanentAddress').val());
        lcl_obj_EmpApp.EmployeePersonal.PermanentPo = trim($('#txt_Pers_PermanentPO').val());
        lcl_obj_EmpApp.EmployeePersonal.PermanentPc = trim($('#txt_Pers_PermanentPC').val());
        lcl_obj_EmpApp.EmployeePersonal.PermanentDistrictCode = trim($('#ddl_Pers_PermanentDistrict option:selected').val());
        lcl_obj_EmpApp.EmployeePersonal.CitizenCardId = trim($('#txt_Pers_VoterCardNo').val());
        lcl_obj_EmpApp.EmployeePersonal.PassportNo = trim($('#txt_Pers_PassportNo').val());

        var lcl_i32_EducationCount = parseInt(document.getElementById("txtEducationCount").value.toString());
        lcl_obj_EmpApp.EmployeeEducation = new Array();

        for (var i = 0; i < lcl_i32_EducationCount; i++) {
            lcl_obj_EmpApp.EmployeeEducation[i] = new Object(); //txt_Edu_EDUCATION_CODE
            lcl_obj_EmpApp.EmployeeEducation[i].EducationCode = trim($('#txt_Edu_CODE-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].ExamName = trim($('#txt_Edu_ExamName-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].InstName = trim($('#txt_Edu_InstituteName-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].BoardUniversity = trim($('#txt_Edu_BoardUniversity-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].MajorSubject = trim($('#txt_Edu_MajorSubject-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].DivisionClass = trim($('#txt_Edu_DivisionClass-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].Cgpa = trim($('#txt_Edu_CGPA-' + (i + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeEducation[i].PassYear = trim($('#txt_Edu_PassingYear-' + (i + 1).toString()).val());
        }


        var lcl_i32_WeekEndCount = numWeekEnd.length;
        lcl_obj_EmpApp.EmployeeWeekEnd = new Array();
        for (var i = 0; i < lcl_i32_WeekEndCount; i++) {
            lcl_obj_EmpApp.EmployeeWeekEnd[i] = new Object();
            lcl_obj_EmpApp.EmployeeWeekEnd[i].Day = numWeekEnd[i];
        }
        //Instantiate Employee_Experience Object
        var lcl_i32_ExperienceCount = parseInt(document.getElementById('txtExperienceCount').value.toString());

        lcl_obj_EmpApp.EmployeeExperienceList = new Array();
        for (var j = 0; j < lcl_i32_ExperienceCount; j++) {
            lcl_obj_EmpApp.EmployeeExperienceList[j] = new Object();
            lcl_obj_EmpApp.EmployeeExperienceList[j].ExperienceCode = trim($('#txt_Exp_CODE-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].EmployerName = trim($('#txt_Exp_OrganizationName-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].Address = trim($('#txt_Exp_Address-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].ContactNo = trim($('#txt_Exp_ContactNo-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].NatureOfJob = trim($('#txt_Exp_NatureOfJob-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].Responsibility = trim($('#txt_Exp_Responsibility-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].FromDate = trim($('#txt_Exp_DateFrom-' + (j + 1).toString()).val());
            lcl_obj_EmpApp.EmployeeExperienceList[j].ToDate = trim($('#txt_Exp_DateTo-' + (j + 1).toString()).val());
        }

        //Instantiate Employee_Salary Object
        lcl_obj_EmpApp.EmployeeSalaryStructure = new Object();
        lcl_obj_EmpApp.EmployeeSalaryStructure.EmployeeCode = parseInt($("#txtUserEmployeeCode").val().toString()); //trim($('#txtUserEmployeeCode').val());
        lcl_obj_EmpApp.EmployeeSalaryStructure.Basic = $.trim(($('#txt_Sal_Basic').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.HouseRent = $.trim(($('#txt_Sal_HouseRent').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.Medical = $.trim(($('#txt_Sal_Medical').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.Entertainment = $.trim(($('#txt_Sal_Entertainment').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.Conveyence = $.trim(($('#txt_Sal_Conveyence').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.PhoneBill = $.trim(($('#txt_Sal_PhoneBill').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.Others = $.trim(($('#txt_Sal_Others').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeSalaryStructure.Gross = $.trim(($('#txt_Sal_Gross').val().toString().replace(',', '')));
        lcl_obj_EmpApp.EmployeeReferenceList = new Array();
        var lcl_obj_Ref_txtName1 = document.getElementById('txt_Ref_Name1');
        var lcl_obj_Ref_txtContactNo1 = document.getElementById('txt_Ref_ContactNo1');
        if ($('#chk_Ref_Reference_1').is(':checked')) {
            if (IsBlank(lcl_obj_Ref_txtName1, "The Field 'Name' in Reference 1 Cannot Be Blank!!!") == false) {
                if (IsBlank(lcl_obj_Ref_txtContactNo1, "The Field 'Address' in Reference 1 Cannot Be Blank!!!") == false) {
                    lcl_obj_EmpApp.EmployeeReferenceList[0] = new Object();

                    lcl_obj_EmpApp.EmployeeReferenceList[0].ReferenceCode = parseInt($("#txtref1").val().toString());
                    lcl_obj_EmpApp.EmployeeReferenceList[0].Name = $('#txt_Ref_Name1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[0].Address = $('#txt_Ref_Address1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[0].ContactNo = $('#txt_Ref_ContactNo1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[0].Designation = $('#txt_Ref_Designation1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[0].CompanyOrganization = $('#txt_Ref_Organization1').val();

                }
            }
        }

        var lcl_obj_Ref_txtName2 = document.getElementById('txt_Ref_Name1');
        var lcl_obj_Ref_txtContactNo2 = document.getElementById('txt_Ref_ContactNo1');
        if ($('#chk_Ref_Reference_2').is(':checked')) {
            if (IsBlank(lcl_obj_Ref_txtName2, "The Field 'Name' in Reference 2 Cannot Be Blank!!!") == false) {
                if (IsBlank(lcl_obj_Ref_txtContactNo2, "The Field 'Address' in Reference 2 Cannot Be Blank!!!") == false) {
                    lcl_obj_EmpApp.EmployeeReferenceList[1] = new Object();
                    lcl_obj_EmpApp.EmployeeReferenceList[1].ReferenceCode = parseInt($("#txtref1").val().toString());
                    lcl_obj_EmpApp.EmployeeReferenceList[1].Name = $('#txt_Ref_Name1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[1].Address = $('#txt_Ref_Address1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[1].ContactNo = $('#txt_Ref_ContactNo1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[1].Designation = $('#txt_Ref_Designation1').val();
                    lcl_obj_EmpApp.EmployeeReferenceList[1].CompanyOrganization = $('#txt_Ref_Organization1').val();
                }
            }
        }


        //INITIATE Employee_Entitle_Leave Object
        var lcl_i32_Leave_Counter = parseInt($("#txtLeaveCounter").val().toString());
        var lcl_b_LeaveSelected = false; //to check if any leave has been selected
        lcl_obj_EmpApp.EmployeeEntitledLeaveList = new Array();
        var lcl_i32_Array_Counter = 0;
        for (var m = 0; m < lcl_i32_Leave_Counter; m++) {
            if ($('#chkLeave-' + (m + 1).toString()).is(':checked')) {
                lcl_obj_EmpApp.EmployeeEntitledLeaveList[lcl_i32_Array_Counter] = new Object();
                lcl_obj_EmpApp.EmployeeEntitledLeaveList[lcl_i32_Array_Counter].LeaveCode = parseInt($("#txtLeaveCode-" + (m + 1).toString()).val().toString());
                lcl_obj_EmpApp.EmployeeEntitledLeaveList[lcl_i32_Array_Counter].Balance = parseInt($("#txtBalance-" + (m + 1).toString()).val().toString());
                lcl_b_LeaveSelected = true;
                lcl_i32_Array_Counter++;
            }
        }
        if (lcl_b_LeaveSelected == false) {
            DisplayInformation("No 'Leave' was selected for this employee!!!Cannot save.");
            return false;
        }

        lcl_obj_EmpApp.Image = new Object();
        if ($('#fileBrowser').data('is_emp_img_added') == false) {
            lcl_obj_EmpApp.Image = null;
        }
        else {
            lcl_obj_EmpApp.Image.ImageType = $("#txt_EI_ImageType").val().toString();
            lcl_obj_EmpApp.Image.ImageSize = $("#txt_EI_ImageSize").data('img_size');
            lcl_obj_EmpApp.Image.Image1 = $('#fileBrowser').data('emp_img');
        }
        $.ajax(

            {

                type: "POST",
                async: true,
                contentType: "application/json; charset=utf-8",
                url: " ~/../../../WebServices/HRIS/EmployeeService.asmx/UpdateEmployeeAppoinment",

                data: "{IP_obj_EmployeeAppoinment:" + JSON.stringify(lcl_obj_EmpApp) + "}",
                dataType: "json",
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
                }
            });
        return false;
    }
}


function CheckBoxCount() {

    var gv = document.getElementById("chkbox");
    var inputList = gv.getElementsByTagName("input");
    WeekEnd = [];



    for (var i = 0; i < inputList.length; i++) {
        if (inputList[i].type == "checkbox" && inputList[i].checked) {
            WeekEnd[i] = i + 1;
        }
    }

    numWeekEnd = WeekEnd.filter(Number)
}


function LoadLeaveList() {
    var lcl_str_CompanyCode = $("#ddlCompany option:selected").val();
    if (lcl_str_CompanyCode == 0) {

        return
    }

    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",

            url: gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/GetEmployeeLeaveList",

            data: "{IP_ui64_CompanyCode:" + JSON.stringify(lcl_str_CompanyCode) + "}",
            dataType: "json",
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    var lcl_obj_WSResponse = response.d;

                    var lcl_obj_Leave_List = lcl_obj_WSResponse.Data;
                    var lcl_i32_Leave_Counter = 0;
                    $.each(lcl_obj_Leave_List, function (index, lcl_obj_Leave) {
                        lcl_i32_Leave_Counter++;
                        var lcl_str_Leave_HTML = "<tr>";
                        lcl_str_Leave_HTML += "<td align='center' style='width:20%;text-align:center;'><input id='chkLeave-" + lcl_i32_Leave_Counter.toString() + "' style='width:50%' type='checkbox'/></td>";
                        lcl_str_Leave_HTML += "<td align='center' style='width:30%;text-align:center;'>" + lcl_obj_Leave.LeaveName + "</td>";
                        lcl_str_Leave_HTML += "<td align='center' style='width:30%';text-align:center;>" + lcl_obj_Leave.NoOfDays + "</td>";
                        lcl_str_Leave_HTML += "<td align='center' style='width:20%';text-align:center;>" + lcl_obj_Leave.IsCarryForwarded + "</td>";
                        lcl_str_Leave_HTML += "<input id='txtLeaveCode-" + lcl_i32_Leave_Counter.toString() + "' type='hidden' value='" + lcl_obj_Leave.LeaveCode + "'/>";
                        lcl_str_Leave_HTML += "<input id='txtBalance-" + lcl_i32_Leave_Counter.toString() + "' type='hidden' value='" + lcl_obj_Leave.NoOfDays + "'/>";
                        lcl_str_Leave_HTML += "</tr>";

                        $("#tblLeave tr:last").after(lcl_str_Leave_HTML);
                        $("#tblLeave tr:last").hide().fadeIn('slow');
                        $("#txtLeaveCounter").val(lcl_i32_Leave_Counter.toString());
                    });
                    return true;

                }
                else {
                    DisplayError(WSReturn.Message.toString());
                }
            },
            error: function (data) {
            }
        });
    return false;
}