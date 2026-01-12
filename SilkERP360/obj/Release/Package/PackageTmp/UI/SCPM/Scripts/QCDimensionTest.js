var lcl_dt_Date;
$(document).ready(function () {

    lcl_dt_Date = new Date($.now());
    //var lcl_str_Time = $.formatDateTime('dd/mm/yy g:ii a', lcl_dt_Date);
    var lcl_str_Time = $.formatDateTime('g:ii a', lcl_dt_Date);
    //alert("a");
    $('#tblDimensionTest').appendGrid({
        caption: 'Quality Control Test Data',
        initRows: 1,
        columns: [
                { name: 'CardNo', display: 'Card No', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'Time', display: 'Time', type: 'text', value: lcl_str_Time, displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'TopLength', display: 'Top Len.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'LeftLength', display: 'Left Len.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'BottomLength', display: 'Bottom Len.', type: 'text', displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
                { name: 'DieType', display: 'Die Type', type: 'select', ctrlOptions: { 0: '2FF', 1: '3FF',2:'4FF' }, displayCss: { 'text-align': 'center' }, ctrlCss: { 'text-align': 'center'} },
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