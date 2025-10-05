$(document).ready(function () {

    GBL_PF_ACCOUNT_LIST_TABLE = $('#tblPFAccountSummery').dataTable({
        "bJQueryUI": true,
        "bAutoWidth": false,
        /*"sScrollY": "600px",
        "sScrollX": "150%",
        "sScrollXInner": "150%",*/
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>ID</b>', sWidth: '8%', sClass: 'alignCenter' },
                    { sTitle: '<b>Emp Name</b>', sWidth: '20%', sClass: 'alignLeft' },
                    { sTitle: '<b>Designation</b>', sWidth: '12%', sClass: 'alignLeft' },
                    { sTitle: '<b>J.Date</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>P.F Acc.</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Emp. Cont. (+)</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Office Cont. (+)</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Profit (+)</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Interest (+)</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Expense (-)</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Total</b>', sWidth: '6%', sClass: 'alignRight' },
                    { sTitle: '<b>Status</b>', sWidth: '4%', sClass: 'alignCenter' },
                  ]

    });


    //    $('#tblPFAccountSummery').appendGrid({
    //        caption: 'P.F Account Summery',
    //        initRows: 0,
    //        columns: [
    //                        { name: 'txtEmployeeId', display: 'Emp. Id', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtEmployeeName', display: 'Emp. Name', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtDesignation', display: 'Degn.', type: 'text', value: '', displayCss: { 'width': '15%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtJoiningDate', display: 'J.Date', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtPFAccountNumber', display: 'P.F Acc.', type: 'text', value: '', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtEmployeeDeposit', display: 'Emp. Depo', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtEmployerDeposit', display: 'Off. Depo', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtProfit', display: 'Profit', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtInterest', display: 'Interest', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtExpense', display: 'Expense', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtGrandTotal', display: 'G.Total', type: 'text', value: '', displayCss: { 'width': '5%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'right' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'txtStatus', display: 'Status', type: 'text', value: '', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
    //                        { name: 'RecordId', type: 'hidden', value: 0 },
    //                        { name: 'txtEmployeeCode', type: 'hidden', value: 0 }
    //                        ],
    //        hideButtons: {
    //            remove: true,
    //            removeLast: true,
    //            insert: true,
    //            append: true
    //        },
    //        hideRowNumColumn: false,
    //        afterRowAppended: function (caller, parentRowIndex, addedRowIndex) {
    //            /*********************************************************************************************************************/
    //            //DISABLE THE ASSESSMENT STATUS OF THE EMPLOYEE
    //            var lcl_ctrl_AssessmentStatus = $(caller).appendGrid('getCellCtrl', 'ddlAssessmentStatus', addedRowIndex);
    //            var lcl_ctrl_EmployeeId = $(caller).appendGrid('getCellCtrl', 'txtEmployeeId', addedRowIndex);
    //            //                                    $(lcl_ctrl_EmployeeId).css('background-color', 'gray');
    //            $(lcl_ctrl_EmployeeId).css('border', '1px solid gray');
    //            $(lcl_ctrl_AssessmentStatus).prop("disabled", true);

    //            /*********************************************************************************************************************/
    //        }
    //    });


    /*************************************************************************************************************************/
    //Call Web Service

    var lcl_ui32_CompanySelectedIndex = $('#ddlCompany option:selected').index();
    if (lcl_ui32_CompanySelectedIndex <= 0) {
        //No Company Selected
        DisplayError("A Company Must Be Selected Before Enrolling an Employee!!!");
        return;
    }
    var lcl_str_CompanyCode = $.trim($('#ddlCompany option:selected').val().toString());
    if (lcl_str_CompanyCode == '') {
        return;
    }

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/ProvidentFundServices.asmx/GetPFAccountProfileForAllByAllDuration";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode:" + lcl_str_CompanyCode + "}"; // JSON.stringify(lcl_obj_LogFile);
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode < 0) {
            //SYSTEM EXCEPTION
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //SYSTEM EXCEPTION
            DisplayInformation(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {


            var lcl_objLst_PFAccountProfileList = lcl_obj_WSResponse.Data;

            var lcl_i32_TotalAccountNumber = 0;

            var lcl_obj_PFAccountSummery = new Array();

            var lcl_dbl_GTPFAccount = 0;
            var lcl_dbl_GTEmployeeContribution = 0;
            var lcl_dbl_GTEmployerContribution = 0;
            var lcl_dbl_GTProfit = 0;
            var lcl_dbl_GTInterest = 0;
            var lcl_dbl_GTExpense = 0;
            var lcl_dbl_GT = 0;


            $.each(lcl_objLst_PFAccountProfileList, function (index, lcl_obj_PFAccountProfile) {
                lcl_dbl_GTPFAccount++;


                lcl_obj_PFAccountSummery[index] = new Object();
                lcl_i32_TotalAccountNumber++;

                var lcl_dbl_TotalEmployeeContribution = 0;
                var lcl_dbl_TotalEmployerContribution = 0;
                var lcl_dbl_TotalProfit = 0;
                var lcl_dbl_TotalInterest = 0;
                var lcl_dbl_TotalExpense = 0;
                var lcl_dbl_GrandTotal = 0;

                $.each(lcl_obj_PFAccountProfile.EmployeePFAccountTransactionList, function (index, lcl_obj_EmployeePFAccountTransaction) {
                    switch (lcl_obj_EmployeePFAccountTransaction.PFTransactionType) {
                        case 0:
                            break;
                        case 1:
                            lcl_dbl_TotalEmployeeContribution += lcl_obj_EmployeePFAccountTransaction.Amount;
                            break;
                        case 2:
                            lcl_dbl_TotalEmployerContribution += lcl_obj_EmployeePFAccountTransaction.Amount;
                            break;
                        case 3:
                            lcl_dbl_TotalInterest += lcl_obj_EmployeePFAccountTransaction.Amount;
                            break;
                        case 4:
                            lcl_dbl_TotalProfit += lcl_obj_EmployeePFAccountTransaction.Amount;
                            break;
                        case 5:
                            lcl_dbl_TotalExpense += lcl_obj_EmployeePFAccountTransaction.Amount;
                            break;
                    }
                });
                var lcl_dbl_AccountGrandTotal = ((lcl_dbl_TotalEmployeeContribution + lcl_dbl_TotalEmployerContribution + lcl_dbl_TotalInterest + lcl_dbl_TotalProfit) - (lcl_dbl_TotalExpense));

                var lcl_dt_JoiningDate = new Date(lcl_obj_PFAccountProfile.JoiningDate.match(/\d+/)[0] * 1);
                var lcl_str_JoiningDate = lcl_dt_JoiningDate.getDate() + "/" + (lcl_dt_JoiningDate.getMonth() + 1).toString() + "/" + lcl_dt_JoiningDate.getFullYear();
                // alert(myDate.getDate());

                lcl_dbl_GTEmployeeContribution += lcl_dbl_TotalEmployeeContribution;
                lcl_dbl_GTEmployerContribution += lcl_dbl_TotalEmployerContribution;
                lcl_dbl_GTProfit += lcl_dbl_TotalProfit;
                lcl_dbl_GTInterest += lcl_dbl_TotalInterest;
                lcl_dbl_GTExpense += lcl_dbl_TotalExpense;



                lcl_obj_PFAccountSummery[index][0] = lcl_obj_PFAccountProfile.EmployeeID.toString();
                lcl_obj_PFAccountSummery[index][1] = lcl_obj_PFAccountProfile.EmployeeName.toString();
                lcl_obj_PFAccountSummery[index][2] = lcl_obj_PFAccountProfile.Designation.Name.toString();
                lcl_obj_PFAccountSummery[index][3] = lcl_str_JoiningDate;
                lcl_obj_PFAccountSummery[index][4] = lcl_obj_PFAccountProfile.PFAccountNumber.toString();
                lcl_obj_PFAccountSummery[index][5] = $('#hdnCurrencyFormatter').val(lcl_dbl_TotalEmployeeContribution).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();
                lcl_obj_PFAccountSummery[index][6] = $('#hdnCurrencyFormatter').val(lcl_dbl_TotalEmployerContribution).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();
                lcl_obj_PFAccountSummery[index][7] = $('#hdnCurrencyFormatter').val(lcl_dbl_TotalInterest).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();
                lcl_obj_PFAccountSummery[index][8] = $('#hdnCurrencyFormatter').val(lcl_dbl_TotalProfit).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();
                lcl_obj_PFAccountSummery[index][9] = $('#hdnCurrencyFormatter').val(lcl_dbl_TotalExpense).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();
                lcl_obj_PFAccountSummery[index][10] = $('#hdnCurrencyFormatter').val(lcl_dbl_AccountGrandTotal).formatCurrency({ groupDigits: true, positiveFormat: '%n' }).val();

                lcl_obj_PFAccountSummery[index][11] = (lcl_obj_PFAccountProfile.PFAccountStatus == 1) ? 'Active' : 'Settled';

                //                $('#tblPFAccountSummery').appendGrid('appendRow', [
                //                    {
                //                        txtEmployeeId: lcl_obj_PFAccountProfile.EmployeeID.toString(),
                //                        txtEmployeeName: lcl_obj_PFAccountProfile.EmployeeName.toString(),
                //                        txtDesignation: lcl_obj_PFAccountProfile.Designation.Name.toString(),
                //                        txtDepartment: lcl_obj_PFAccountProfile.Department.Name.toString(),
                //                        txtJoiningDate: lcl_obj_PFAccountProfile.JoiningDate.toString(),
                //                        txtPFAccountNumber: lcl_obj_PFAccountProfile.PFAccountNumber.toString(),
                //                        txtEmployeeDeposit: lcl_dbl_TotalEmployeeContribution,
                //                        txtEmployerDeposit: lcl_dbl_TotalEmployerContribution,
                //                        txtTotalInterest: lcl_dbl_TotalInterest,
                //                        txtTotalProfit: lcl_dbl_TotalProfit,
                //                        txtTotalExpense: lcl_dbl_TotalExpense,
                //                        txtGrandTotal: lcl_dbl_AccountGrandTotal,
                //                        txtStatus: 0,
                //                        txtEmployeeCode: lcl_obj_PFAccountProfile.EmployeeCode

                //                    }]);
            });
            lcl_dbl_GT = (lcl_dbl_GTEmployeeContribution + lcl_dbl_GTEmployerContribution + lcl_dbl_GTInterest + lcl_dbl_GTProfit) - (lcl_dbl_GTExpense);

            $('#txtTotalPFAccounts').val(lcl_dbl_GTPFAccount);
            $('#txtTotalEmployeeContribution').val(lcl_dbl_GTEmployeeContribution).formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            $('#txtTotalOfficeContribution').val(lcl_dbl_GTEmployerContribution).formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            $('#txtTotalProfit').val(lcl_dbl_GTProfit).formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            $('#txtTotalInterest').val(lcl_dbl_GTInterest).formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            $('#txtTotalExpense').val(lcl_dbl_GTExpense).formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            $('#txtGrandTotal').val(lcl_dbl_GT).formatCurrency({ groupDigits: true, positiveFormat: '%n' }); 

            GBL_PF_ACCOUNT_LIST_TABLE.fnAddData(lcl_obj_PFAccountSummery);
            /* DisplaySuccess(lcl_obj_WSResponse.Message);*/
        }
    };

    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);

    /*************************************************************************************************************************/


    $("#dvReportBody").show('slow');
});