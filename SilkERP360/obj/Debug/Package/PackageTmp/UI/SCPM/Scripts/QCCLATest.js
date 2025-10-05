var lcl_dt_Date;
$(document).ready(function () {

    lcl_dt_Date = new Date($.now());
    //var lcl_str_Time = $.formatDateTime('dd/mm/yy g:ii a', lcl_dt_Date);
    var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
    //alert("a");
    $('#tblCLATest').appendGrid({
        caption: 'Quality Control Test Data',
        initRows: 1,
        columns: [
                { name: 'CardNo', display: 'Card No', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Time', display: 'Time', type: 'text', value: lcl_str_Time, displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Appearance', display: 'Appearance ?', type: 'checkbox', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'ChipLocation', display: 'Chip Location ?', type: 'checkbox', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Status', display: 'Status', type: 'select', displayCss: { 'text-align': 'center' }, ctrlOptions: { 0: 'Rejected', 1: 'Accepted' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],

        hideRowNumColumn: false,
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            lcl_dt_Date = new Date($.now());
            var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
            // Copy data of `Year` from parent row to new added rows
            $(caller).appendGrid('setCtrlValue', 'Time', addedRowIndex, lcl_str_Time);
        }
    });
});