var lcl_dt_Date;
$(document).ready(function () {

    lcl_dt_Date = new Date($.now());
    var lcl_str_Time = lcl_dt_Date.getHours() + ":" + lcl_dt_Date.getMinutes() + ":" + lcl_dt_Date.getSeconds();
    $('#tblLWTTest').appendGrid({
        caption: 'Quality Control Test Data',
        initRows: 1,
        columns: [
                { name: 'Time', display: 'Time', type: 'time', value: lcl_str_Time, displayCss: { 'text-align': 'center' }, ctrlCss: {'text-align':'center'} },
                { name: 'Length', display: 'Length', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Width', display: 'Width', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Thickness', display: 'Thickness', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Status', display: 'Status', type: 'select', displayCss: { 'text-align': 'center' }, ctrlOptions: { 0: 'Rejected', 1: 'Accepted' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            // Copy data of `Year` from parent row to new added rows
            lcl_dt_Date = new Date($.now());
            var lcl_str_Time = $.formatDateTime('dd/mm/yy g:ii a', lcl_dt_Date);
            // Copy data of `Year` from parent row to new added rows
            $(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
        }
    });
});
