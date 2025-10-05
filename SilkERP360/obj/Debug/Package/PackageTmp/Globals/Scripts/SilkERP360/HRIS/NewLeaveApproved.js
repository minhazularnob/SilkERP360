$(document).ready(function () {

});


function SaveLeaveApprover() {
debugger
    
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
            var lcl_obj_LeaveApproved = new Object();
            debugger;
            lcl_obj_LeaveApproved.LeaveAppCode = parseInt($("#txtLeaveCode").val().toString());
            lcl_obj_LeaveApproved.ApprovedBy = 101000000001
            //lcl_obj_LeaveApproved.APPROVAL_DATE = new date();
            lcl_obj_LeaveApproved.ApprovedLeaveCategory = $("#ddl_Lev_Category option:selected").val();
            lcl_obj_LeaveApproved.IsApproved = $("#ddl_Lev_CategoryBMode option:selected").val();
           
            
            //alert(lcl_obj_LeaveApplication.LeaveCategory);

            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",

                        url: gbl_URL_Root + "WebServices/HRIS/LeaveService.asmx/SaveEmployeeLeaveApproved",
                        data: "{IP_obj_EmployeeLeaveApproved:" + JSON.stringify(lcl_obj_LeaveApproved) + "}", //provide input for the getSM_PO method
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