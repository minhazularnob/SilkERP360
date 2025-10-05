$(document).ready(function () {

    $("#txt_StartTime").datepicker({ dateFormat: 'dd/MM/yy' });
    $("#txt_EndTime").datepicker({ dateFormat: 'dd/MM/yy' });
    $("#txt_ToleranceTime").datepicker({ dateFormat: 'dd/MM/yy' });


});


/********************************************************************************************************************
FORMAT THE TABLE
********************************************************************************************************************/
GBL_EMPLOYEE_LIST_TABLE = $('#tblShiftList').dataTable({
    "bJQueryUI": true,
    "sScrollY": "700px",
    "bFilter": true,
    "bPaginate": false,
    "bLengthChange": false,
    "oLanguage": {
        "sEmptyTable": "No SHIFT Data Available",
        "sZeroRecords": "No SHIFT Record Found For Your Specified Criteria"
    },
    "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
        //                        // Bold the grade for all 'A' grade browsers
        //                        if (aData[4] == "A") {
        //                            $('td:eq(4)', nRow).html('<b>A</b>');
        //                        }
    },
    "aoColumns": [
                    { sTitle: 'Shift Name', sWidth: '16%', sClass: 'alignCenter' },
                    { sTitle: 'Start Time', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'End Time', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Tolerance Time', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Short Order', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: 'Regular Duty Hour', sWidth: '16%', sClass: 'alignCenter' },
                    { sTitle: 'Action', sWidth: '8%', sClass: 'alignCenter' },                    
                  ]
});

////******************************** SAVE Shift  ********************************************////////////

function Save() {

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
            var lcl_obj_Shift = new Object();
            debugger;

            lcl_obj_Shift.CompanyCode = $('#ddlCompany option:selected').val();
            lcl_obj_Shift.ShiftName = $("#txt_ShiftName").val();
            lcl_obj_Shift.StartTime = $("#txt_StartTime").val();
            lcl_obj_Shift.EndTime = $("#txt_EndTime").val();
            lcl_obj_Shift.ToleranceTime = $("#txt_ToleranceTime").val();
            lcl_obj_Shift.SortOrder = $("#txt_SortOrder").val();
            lcl_obj_Shift.RegularDutyHour = $("#txt_RgrDutyHour").val();



            $.ajax(
                    {

                        type: "POST",
                        async: false,
                        contentType: "application/json; charset=utf-8",
                        url: gbl_URL_Root + "WebServices/HRIS/ShiftService.asmx/SaveShift",
                        // url: gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/SaveEmployeeAppoinment",

                        data: "{IP_Obj_Shift:" + JSON.stringify(lcl_obj_Shift) + "}", //provide input for the getSM_PO method
                        dataType: "json", /// <reference path= />
                        success: function (response) {
                            var WSReturn = response.d;
                            if (WSReturn.ResponseCode == 0) {

                                DisplayInformation(WSReturn.Message.toString());
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
