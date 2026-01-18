$(document).ready(function () {
    initializeSelect2('reportName', '', '100%');
    $("#rptTxtStartDateTime").datetimepicker({
        dateFormat: 'dd/MM/yy', timeFormat: 'hh:mm tt', showButtonPanel: true, maxDate: 0,
        onSelect: function (dateStr) {
        }
    });
    $("#rptTxtEndDateTime").datetimepicker({
        dateFormat: 'dd/MM/yy', timeFormat: 'hh:mm tt', showButtonPanel: true, maxDate: 0,
        onSelect: function (dateStr) {

        }
    });
});

$('#downLoadReport').click(function () {
    var reportName = $('#reportName option:selected').text();

    if (reportName === "------ Select Report ------") {
        alert("Please select a report");
        $('#datepickerDiv').hide();
        return;
    }

    var url = '/Handler/ReportDownloadHandler.ashx?report=' + encodeURIComponent(reportName);

    if (reportName === "Attendance") {
        var startDate = $('#rptTxtStartDateTime').val();
        var endDate = $('#rptTxtEndDateTime').val();
        if (!startDate || !endDate) {
            alert("Please select start and end date");
            return;
        }
        url += '&startDate=' + encodeURIComponent(startDate) + '&endDate=' + encodeURIComponent(endDate);
    }

    window.open(url, '_blank');
});


$('#reportName').on('change', function () {
    var reportName = $('#reportName option:selected').text();
    if (reportName === "Attendance") {
        $('#datepickerDiv').show();  // visible
    } else {
        $('#datepickerDiv').hide();  // hidden
    }
});
