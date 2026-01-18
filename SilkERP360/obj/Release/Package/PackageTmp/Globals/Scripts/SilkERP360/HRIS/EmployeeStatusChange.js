$(document).ready(function () {
    $("#txt_Efct_Date").datepicker({ dateFormat: "dd/MM/yy", maxDate: 0 }).datepicker("setDate", new Date());
    initializeSelect2('ddl_Off_ChangeStatus', '-----Select Status-----', '100%');
});


function Save() {
    if (confirm("Are you sure you want to change Employee status?") == true) {
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
            var lcl_obj_EmployeeStatusHistory = new Object();
            lcl_obj_EmployeeStatusHistory.EmployeeCode = gbl_ui64_EmployeeCode;
            lcl_obj_EmployeeStatusHistory.OldtStatusCode = gbl_ui16_CurrentStatus; //txt_Currnt_status
            //lcl_obj_EmployeeStatusHistory.OldtStatusCode = $("#txt_Currnt_status").val();
            lcl_obj_EmployeeStatusHistory.CurrentStatusCode = $("#ddl_Off_ChangeStatus").val();
            lcl_obj_EmployeeStatusHistory.EffectDate = $("#txt_Efct_Date").val();

            //alert(lcl_obj_EmployeeStatusHistory.OldtStatusCode);
            debugger;
            $.ajax(
                    {

                        type: "POST",
                        async: true,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/ChangeEmployeeStatus",
                        // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_obj_EmployeeStatusHistory:" + JSON.stringify(lcl_obj_EmployeeStatusHistory) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

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