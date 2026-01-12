

$(document).ready(function () {
    $('#tblPantoneColors').appendGrid({
        caption: 'Pantone Colors',
        initRows: 1,
        columns: [
        //                                 { name: 'Image', display: 'img', type: 'image'},
                {name: 'txtPantoneColorCode', display: 'Code', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtPantonColorName', display: 'Color Name', displayCss: { 'text-align': 'center', 'width': '15%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtPantoneColor', display: 'Pantone Code', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlCss: { width: '100%', 'text-align': 'center'} },
                { name: 'txtHex', display: 'Hex', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center' },
                    onChange: function (evt, rowIndex) {
                        var lcl_strHexColor = '#' + $('#tblPantoneColors').appendGrid('getCtrlValue', 'txtHex', rowIndex);
                        var lcl_ctrl_Preview = $('#tblPantoneColors').appendGrid('getCellCtrl', 'txtColorPreview', rowIndex);
                        //$(lcl_ctrl_EmployeeId).css('background-color', 'red');
                        $(lcl_ctrl_Preview).css('background-color', lcl_strHexColor);
                        alert(lcl_strHexColor);
                    }
                },
                { name: 'txtRGB', display: 'RGB', displayCss: { 'text-align': 'center', 'width': '10%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center' },
                    onChange: function (evt, rowIndex) {
                        var lcl_strRGBColor = 'RGB(' + $('#tblPantoneColors').appendGrid('getCtrlValue', 'txtRGB', rowIndex) + ')';
                        var lcl_ctrl_Preview = $('#tblPantoneColors').appendGrid('getCellCtrl', 'txtColorPreview', rowIndex);
                        //$(lcl_ctrl_EmployeeId).css('background-color', 'red');

                        $(lcl_ctrl_Preview).css('background-color', lcl_strRGBColor);
                    }
                },
                { name: 'txtColorPreview', display: 'Preview', displayCss: { 'text-align': 'center', 'width': '40%' }, type: 'text', ctrlClass: 'required', ctrlCss: { width: '100%', 'text-align': 'center', readonly: 'readonly'} },
                { name: 'RecordId', type: 'hidden', value: 0 }
            ],
        hideButtons: {
            remove: false,
            removeLast: true,
            insert: true,
            append: false
        },
        hideRowNumColumn: false,
        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
            /*********************************************************************************************************************/
            //Check If The row is a new inclusion in the grid
            var lcl_ui64_WorkGroupOperationHistoryCode = $(caller).appendGrid('getCtrlValue', 'txtWorkGroupOperationHistoryCode', addedRowIndex);
            if (lcl_ui64_WorkGroupOperationHistoryCode == 0) {
                //New Employee Inclusion to WorkGroup
                //Mark Employee ID red
                var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                //$(lcl_ctrl_EmployeeId).css('background-color', 'red');
                $(lcl_ctrl_EmployeeId).css('border', '1px solid red');
            }
            else {
                //Display only
                var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
                //$(lcl_ctrl_EmployeeId).css('background-color', 'green');
                $(lcl_ctrl_EmployeeId).css('border', '1px solid green');
            }
            /*********************************************************************************************************************/
        }

    });
});