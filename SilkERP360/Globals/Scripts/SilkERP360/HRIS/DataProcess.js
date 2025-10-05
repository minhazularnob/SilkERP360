var lcl_str_Result;
$(document).ready(function () {
    //debugger;
    
    $("#txt_AttenDate").datepicker({ dateFormat: 'dd/MM/yy', minDate: 0 });


});
function readBlob() {
    debugger;
    var files = document.getElementById('fileBrowser').files;
    if (!files.length) {

        DisplayError('Please select a file!!!');
        //alert('Please select a file!');
        return;
    }

    var file = files[0];
    var start = 0;  //parseInt(opt_startByte) || 0;
    var stop = file.size - 1; //parseInt(opt_stopByte) || file.size - 1;

    var reader = new FileReader();
   
    // If we use onloadend, we need to check the readyState.
    reader.onloadend = function (evt) {
        if (evt.target.readyState == FileReader.DONE) { // DONE == 2

            // document.getElementById('lcl_str_Result').textContent = evt.target.result;
            lcl_str_Result = evt.target.result;
            document.getElementById('byte_range').textContent =
            ['Read bytes: ', start + 1, ' - ', stop + 1,
             ' of ', file.size, ' byte file'].join('');
        }
    };

    var blob = file.slice(start, stop + 1);
    reader.readAsBinaryString(blob);

    false;
}


function ReadData() {
    
    $.ajax(
        {

            async: false,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: gbl_URL_Root + "WebServices/HRIS/AttendanceService.asmx/ReceiveAttandaneceData",
            data: "{IP_str_AttandenceData:" + JSON.stringify(lcl_str_Result) + "}", //provide input for the getSM_PO method
            dataType: 'json', /// <reference path= />
            success: function (response) {
                var WSReturn = response.d;
                if (WSReturn.ResponseCode == 0) {
                    DisplayInformation(WSReturn.Message);
                    return;
                }
                if (WSReturn.Data == true) {

                    return;
                }


            },
            error: function (data) {
                DisplayError("Fatal Server Error : Contact Administrator!!!");
            }
        });

}
function AttendanceProcess() {
    if (confirm("Are you sure you want to Attendance Process?") == true) {
        var lcl_b_InputValidated = true;
        $('.input-required').each(function (i, obj) {
            //test
            if ($.trim($(this).val().toString()) == '') {
                $(this).css('background-color', 'red');
                lcl_b_InputValidated = false;
                DisplayError("Fields with red background are mandatory fields.Please input Value!!!");
                return false;
            }



            //alert("ok");
        });

    }

}