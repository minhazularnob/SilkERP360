$(document).ready(function () {
    initializeSelect2('reportName', '', '100%');
});

$('#downLoadReport').click(function () {

    // Get selected report TEXT or VALUE
    // 1️⃣ Get selected report
    var reportName = $('#reportName option:selected').text();

    if (reportName === "------ Select Report ------") {
        alert("Please select a report");
        return;
    }

    var url = '/Handler/ReportDownloadHandler.ashx?report=' 
              + encodeURIComponent(reportName);

    // ✅ Open in NEW TAB
    window.open(url, '_blank');
});
