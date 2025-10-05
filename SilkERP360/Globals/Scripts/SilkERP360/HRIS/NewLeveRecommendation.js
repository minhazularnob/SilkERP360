$(document).ready(function () {

});


function SaveLeaveRecommended() {

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
            var lcl_obj_LeaveRecomanded = new Object();
            debugger;
            lcl_obj_LeaveRecomanded.LeaveAppCode = parseInt($("#txtLeaveCode").val().toString());
            lcl_obj_LeaveRecomanded.RecommendBy = 101000000864;
            //lcl_obj_LeaveRecomanded.APPROVAL_DATE = new Date();
            lcl_obj_LeaveRecomanded.ApprovedLeaveCategory = $("#ddl_Lev_Recommended option:selected").val();
            lcl_obj_LeaveRecomanded.IsRecommended = $("#ddl_Lev_RecommendedMode option:selected").val();


            

            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/UpdateLeaveRecomanded",
                        data: "{IP_obj_EmployeeLeaveRecommended:" + JSON.stringify(lcl_obj_LeaveRecomanded) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {
                                $('select').val('');
                                //$("input:not(:button)").val('');
                                $("input:not(:submit)").val('');
                                $("#tblLeaveDetails").find("tr:gt(0)").remove();
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