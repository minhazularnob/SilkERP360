function POcheckMasterbatch0() {
    form = document.createElement("form");
    form.method = "GET";
    form.action = "ReportingViewer.aspx";
    form.target = "_blank";
    document.body.appendChild(form);
    form.submit();
}