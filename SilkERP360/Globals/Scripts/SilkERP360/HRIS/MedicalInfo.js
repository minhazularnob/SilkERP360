
$(document).ready(function () {

    //$("#txt_VisitedDate").datepicker({ dateFormat: 'dd/MM/yy', minDate: -15, maxDate: 0 });
    $("#txt_VisitedDate").datepicker({ dateFormat: 'dd/MM/yy', maxDate: 0 });


    //Load Medical Information();
    GBL_EMPLOYEE_LIST_TABLE = $('#tblMdcnInfoList').dataTable({
        "bJQueryUI": false,
        "bFilter": true,
        "bPaginate": true,
        "bLengthChange": false,
        "bSearch": true,
        "aoColumns": [
            { sTitle: 'Visited Date', sWidth: '15%', sClass: 'alignCenter' },
            { sTitle: 'Age', sWidth: '08%', sClass: 'alignCenter' },
            { sTitle: 'Blood Group', sWidth: '12%', sClass: 'alignCenter' },
            { sTitle: 'Diagnosis', sWidth: '33%', sClass: 'alignCenter' },
            { sTitle: 'Remarks', sWidth: '32%', sClass: 'alignCenter' },
        ]

    });
    initializeSelect2('ddlEmployeeId', '------ Select Employee ------', '35%');
    initializeSelect2('ddlBloodGroup', '------ Select Employee ------', '98%');
    initializeSelect2('ddlSex', '------ Select Employee ------', '98%');
});

$("#combobox").on("keypress", function (keyarg) {
    if (keyarg.keyCode == 13) { //Enter keycode
        GetEmployeeLeaveProfile(keyarg);
    }
});


$('.ip_required').focus(function () {
    $(this).css('background-color', 'white');
});

$(".ip_required").change(function () {
    $(this).css('background-color', 'white');
});



function GetEmployeeMedicalInfoProfile(event) {
    var lcl_ui64_EmployeeCode = $('#ddlEmployeeId option:selected').val();
    if (lcl_ui64_EmployeeCode == 0) {
        return;
    }
    // alert("1");
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/GetEmployeeLeaveProfileByEmployeeCode";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == 0) {

        }
    };

    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);
    //evt.preventDefault();}
}

////******************************** SAVE Designation  ********************************************////////////

function Save() {

    if (confirm("Are you sure you want to submit this application?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            //test
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                // alert("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }
        });
        if (lcl_b_InputValidated == true) {
            var lcl_obj_MedicineInfo = new Object();
            // debugger;

            lcl_obj_MedicineInfo.EmployeeCode = $('#ddlEmployeeId option:selected').val();
            lcl_obj_MedicineInfo.Age = $("#txt_Age").val();
            lcl_obj_MedicineInfo.Sex = $("#ddlSex").val();
            lcl_obj_MedicineInfo.VisitedDate = $("#txt_VisitedDate").val();
            lcl_obj_MedicineInfo.Remarks = $("#txt_Remarks").val();
            lcl_obj_MedicineInfo.BloodGroup = $("#ddlBloodGroup").val();
            lcl_obj_MedicineInfo.Diagnosis = $("#txt_Diagnosis").val();

            $.ajax(
                    {
                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/MedicalInfoService.asmx/SaveMedicalInfo",

                        data: "{IP_Obj_MedicineInfo:" + JSON.stringify(lcl_obj_MedicineInfo) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());

                                LoadMedicalInfo();
                                return false;
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
    return false;
}

/************************ Load Medical Info -*********/

function LoadMedicalInfo() {
    // debugger;
    var lcl_str_EmployeeCode = $('#ddlEmployeeId option:selected').val();

    $.ajax(

        {

            async: true,
            type: "POST",
            global: true,
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/MedicalInfoService.asmx/GetMedicalInfoData",
            data: "{IP_iu64_EmployeeCode: " + JSON.stringify(lcl_str_EmployeeCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayError(WSReturn.Message);
                    return;
                }
                var lcl_obj_MedicalInfoList = WSReturn.Data;
                //CLEAR Ref Employee
                var lcl_i32_MedicalInfoCode = 0;

                GBL_EMPLOYEE_LIST_TABLE.fnClearTable();
                var lcl_str_ExtendedAllMedicalInfoData = new Array();

                $.each(lcl_obj_MedicalInfoList, function (index, lcl_obj_ExtendedAllMedicalInfoData) {
                    //debugger;
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode] = new Array();
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode][0] = FormatDate(lcl_obj_ExtendedAllMedicalInfoData.VisitedDate);
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode][1] = lcl_obj_ExtendedAllMedicalInfoData.Age;
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode][2] = lcl_obj_ExtendedAllMedicalInfoData.BloodGroup;
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode][3] = lcl_obj_ExtendedAllMedicalInfoData.Diagnosis;
                    lcl_str_ExtendedAllMedicalInfoData[lcl_i32_MedicalInfoCode][4] = lcl_obj_ExtendedAllMedicalInfoData.Remarks;
                    lcl_i32_MedicalInfoCode++;
                });
                GBL_EMPLOYEE_LIST_TABLE.fnAddData(lcl_str_ExtendedAllMedicalInfoData);
                $('#dvReportBody').show('slow');
                //GBL_EMPLOYEE_LIST_TABLE.fnDraw();
            }
        });
}

function FormatDate(jsonDate) {
    var date = new Date(parseInt(jsonDate.substr(6)))
    var d = date.getDate(), m = date.getMonth() + 1, y;
    if (date.getFullYear) { y = date.getFullYear(); }
    else { y = 2000 + (date.getYear() % 100); }
    return (10 > d ? '0' : '') + d + (10 > m ? '-0' : '-') + m + '-' + y;
}