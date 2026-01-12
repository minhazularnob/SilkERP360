$(document).ready(function () {

    $("#txt_ProcesDate").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0, maxDate: 0 });
    // minDate: -15

    var lcl_str_CompanyCode = $('#ddlCompany option:selected').val(); 

    var lcl_str_WMData = "{IP_ui64_CompanyCode :" + lcl_str_CompanyCode + "}";

    //AjaxCallGlobal("WebServices/HRIS/LeaveService.asmx", "GetEmployeeLeaveList", lcl_str_WMData, ConfigureLeaveList);
});

function AttanProcess() {
    if (confirm("Are you sure you want to Attandace Process?") == true) {
         var lcl_obj_AttandanceProcess = new Object();
         lcl_obj_AttandanceProcess.CompanyCode = $('#ddlCompany option:selected').val();
         lcl_obj_AttandanceProcess.ProcessDate = trim($('#txt_ProcesDate').val());
         lcl_obj_AttandanceProcess.ShiftCode = $('#ddl_Off_Shift_Code option:selected').val();

            $.ajax(
            {
               
                type: "POST",
                async: false,
                contentType: "application/json; charset=utf-8",               
                url: gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/AttandaneceProcess",
                data: "{IP_obj_AttandanceCore:" + JSON.stringify(lcl_obj_AttandanceProcess) + "}", //provide input for the getSM_PO method
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