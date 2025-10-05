
$(document).ready(function () {
    //debugger;

    $('#txt_leave_reason').blur(function () { CheckIfLeaveApplicationExists(); });
    /////************** Date number Count  1st Line************//////////////////////


   $('#txt_lve_total_days,#txt_leave_reason').click(function () { days(); });


    $("#txt_Leave_from_date").datepicker({ dateFormat: 'dd/MM/yy',
        numberOfMonths: 2,
        onSelect: function (selected) {
            $("#txt_Leave_to_date").datepicker("option", "minDate", selected);
        }
    });

    $("#txt_Leave_to_date").datepicker({ dateFormat: 'dd/MM/yy',
        numberOfMonths: 2,
        onSelect: function (selected) {
            if ($.trim($("#txt_Leave_from_date").val()) == '') {
                alert("Please Select a date in the field 'Date From' field first!!!");
                $("#txt_Leave_to_date").val('');
            }
            $("#txt_Leave_from_date").datepicker("option", "maxDate", selected);
            var join_date = new Date(selected);
            join_date.setDate(join_date.getDate() + 1);
            $("#txt_join_date").datepicker("option", "minDate", join_date); //joining date must be one day more than the LeaveUpto date
        }
    });

    $("#txt_JoiningDate").datepicker({ dateFormat: 'dd/MM/yy',
        numberOfMonths: 2,
        onSelect: function (selected) {
            if ($.trim($("#txt_DateFrom").val()) == '') {
                alert("Please Select a date in the field 'Date From' field first!!!");
                $("#txt_JoiningDate").val('');
            }
            if ($.trim($("#txt_DateTo").val()) == '') {
                alert("Please Select a date in the field 'Date To' field first!!!");
                $("#txt_JoiningDate").val('');
            }
        }
    });
});

$("#txt_join_date").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0 });

/////************** Date number Count function ************//////////////////////

function days() {
    var d1 = $('#txt_Leave_from_date').datepicker('getDate');
    var d2 = $('#txt_Leave_to_date').datepicker('getDate');
    var diff = 0;
    if (d1 && d2) {
        var lastV = d2.getTime();
        var fastV = d1.getTime();
        var result = lastV - fastV;
        diff = result / 86400000 + 1;
    }
    $('#txt_lve_total_days').val(diff);
}

////*****///////


function SaveLeaveApplication() {
    //alert("SAVING APPLICATION");

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
            var lcl_obj_LeaveApplication = new Object();

            lcl_obj_LeaveApplication.LeaveCode = $("#ddl_LeaveType_id option:selected").val();
            lcl_obj_LeaveApplication.EmployeeCode = gbl_ui64_EmployeeCode;
            lcl_obj_LeaveApplication.LeaveStDate = $("#txt_Leave_from_date").val();
            lcl_obj_LeaveApplication.LeaveEndDate = $("#txt_Leave_to_date").val();

            lcl_obj_LeaveApplication.NoOfDays = $("#txt_lve_total_days").val();
            lcl_obj_LeaveApplication.RejoinDate = $("#txt_join_date").val();
            lcl_obj_LeaveApplication.LeaveReason = $("#txt_leave_reason").val();
            lcl_obj_LeaveApplication.LeaveCategory = $("#ddl_Lev_Category option:selected").val();
            lcl_obj_LeaveApplication.ReplEmployeeCode = $("#ddl_emp_Replacmnt option:selected").val();
            //alert(lcl_obj_LeaveApplication.LeaveCategory);

            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/SaveEmployeeLeaveApplication",
                        data: "{IP_obj_EmployeeLeaveApplication:" + JSON.stringify(lcl_obj_LeaveApplication) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {
                               // $('select').val('');
                                //$("input:not(:button)").val('');
                               // $("input:not(:submit)").val('');
                               // $("#tblLeaveDetails").find("tr:gt(0)").remove();
                                DisplayInformation(WSReturn.Message);
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



function CheckIfLeaveApplicationExists() {
    debugger;
    var lcl_ui64_EmployeeCode = gbl_ui64_EmployeeCode;
   

    $.ajax(
        {
            async: true,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/CheckIifLeaveApp",
            data: "{IP_ui64_EmployeeCode:" + JSON.stringify(lcl_ui64_EmployeeCode) + "}", //provide input for the getSM_PO method
            dataType: "json", /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode < 0) {
                    DisplayMessage(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {
                    DisplayError("The Leave Aplication already exists !!!");
                   
                    return;
                }


            },
            error: function (data) {
                alert("Fatal Server Error : Contact Administrator!!!");
            }
        });

}

