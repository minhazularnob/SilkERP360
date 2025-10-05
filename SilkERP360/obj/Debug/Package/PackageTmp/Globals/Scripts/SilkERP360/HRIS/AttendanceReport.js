jQuery(document).ready(function () {

    $("#toDate").datepicker({ dateFormat: 'dd/MM/yy', minDate: -15, maxDate: 0 });
});

function reportSubmit() {
    debugger;
    //var ddlEmp = $("#ddlEmp");
    var searchObj = new Array();

    searchObj[0] = "ADR";
    searchObj[1] = trim($('#toDate').val());
    searchObj[2] = $('#ddl_Off_Department option:selected').val();
    searchObj[3] = $('#ddlCompany option:selected').val();
   if ( $('#ddl_Off_Department option:selected').val()==0)
   {
   return;
   }


    $.ajax({
        type: "POST",
        url: "~/../../../WebServices/HRIS/ReportService.asmx/ReportAttendance",
        data: "{obj:" + JSON.stringify(searchObj) + "}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            //window.location.href = "ReportViewer.aspx";
            window.open('~/../../../Reports/ReportViewer.aspx', '_blank');
        },
        failure: function (msg) {
            alert(msg);
        }
    });
}
