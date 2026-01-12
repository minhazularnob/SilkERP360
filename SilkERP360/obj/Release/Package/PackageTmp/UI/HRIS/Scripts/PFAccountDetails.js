var GBL_TBL_PF_DETAILS;
$(document).ready(function () {

    GBL_TBL_PF_DETAILS = $('#tblPFDetails').dataTable({
        "bJQueryUI": true,
        "sScrollY": "auto",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "bSearch": false,
        "aoColumns": [
                    { sTitle: '<b>Date</b>', sWidth: '10%', sClass: 'alignCenter' },
                    { sTitle: '<b>Month</b>', sWidth: '20%', sClass: 'alignCenter' },
                    { sTitle: '<b>Year</b>', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: '<b>Tran Type</b>', sWidth: '15%', sClass: 'alignCenter' },
                    { sTitle: '<b>Tran. Amount</b>', sWidth: '10%', sClass: 'alignRight' },
                    { sTitle: '<b>Remarks</b>', sWidth: '30%', sClass: 'alignCenter' }
                  ]

    });
    $("#ddlEmployeeId").combobox();
    $("#lnkGetPFAccountDetails").bind("click", function () { GetPFAccountDetails(); });
});


function GetPFAccountDetails() {
    var lcl_ui64_EmployeeCode = $('#ddlEmployeeId option:selected').val();
    //alert(lcl_ui64_EmployeeCode);
    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/ProvidentFundServices.asmx/GetPFAccountProfileWithTransactionListByEmployeeCode";
    options.type = "POST";
    options.global = true,
    options.data = "{IP_ui64_EmployeeCode: " + lcl_ui64_EmployeeCode + "}", //provide input for the getSM_PO method
    options.contentType = "application/json; charset=utf-8",
    options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.ResponseCode == 1) {
            //Incorrect EmployeeCode provided.No employee id found for provided employee code
            GBL_TBL_PF_DETAILS.fnClearTable();
            DisplayError("Incorrect/Invalid Employee Id Provided!!!");
            return;
        }

        if (lcl_obj_WSResponse.ResponseCode == 0) {
            //ALL OK
            //ShowMessageBoard(lcl_obj_WSResponse.Message);
            var lcl_obj_EmployeeProvidentFundProfile = lcl_obj_WSResponse.Data;
            GBL_TBL_PF_DETAILS.fnClearTable();

            $("#txtCompany").val(lcl_obj_EmployeeProvidentFundProfile.Company.Name);
            $("#txtEmployeeId").val(lcl_obj_EmployeeProvidentFundProfile.EmployeeID);
            $("#txtDepartment").val(lcl_obj_EmployeeProvidentFundProfile.Department.Name);
            $("#txtDesignation1").val(lcl_obj_EmployeeProvidentFundProfile.Designation.Name);
            //$("#txtDesignation1").val("Deshng");
            $("#txtEmployeeName").val(lcl_obj_EmployeeProvidentFundProfile.EmployeeName);
            $("#txtPFAccountNumber").val(lcl_obj_EmployeeProvidentFundProfile.PFAccountNumber);
            $("#ddlAccountStatus").val(lcl_obj_EmployeeProvidentFundProfile.PFAccountStatus);
            var lcl_img_EmployeeImage = 'data' + ':' + lcl_obj_EmployeeProvidentFundProfile.EmployeeImage.ImageType + ';' + 'base64' + ',' + lcl_obj_EmployeeProvidentFundProfile.EmployeeImage.ImageData;
            document.getElementById("imgEmployeeImage").setAttribute("src", lcl_img_EmployeeImage);

            //            var lcl_img_EmployeeImage = 'data' + ':' + lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeImage.ImageType + ';' + 'base64' + ',' + lcl_obj_EmployeewiseAttendanceByDateRange.EmployeeImage.ImageData;
            //            document.getElementById("imgEmployeeImage").setAttribute("src", lcl_img_EmployeeImage);

            var lcl_objLst_PFAccountTransactionList = new Array();
            var lcl_dbl_TotalPFAmount = 0.0;

            $.each(lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList, function (index, lcl_obj_PFAccountTransaction) {


                lcl_objLst_PFAccountTransactionList[index] = new Object();

                var parsedDate = new Date(parseInt(lcl_obj_PFAccountTransaction.TransactionDate.substr(6)));
                var lcl_obj_TranDate = new Date(parsedDate);
                var lcl_str_TranDate = $.datepicker.formatDate("dd/MM/yy", lcl_obj_TranDate);

                var lcl_str_TransactionMonth = '';
                switch (lcl_obj_PFAccountTransaction.TransactionMonth) {
                    case 1:
                        lcl_str_TransactionMonth = 'JANUARY';
                        break;
                    case 2:
                        lcl_str_TransactionMonth = 'FEBRUARY';
                        break;
                    case 3:
                        lcl_str_TransactionMonth = 'MARCH';
                        break;
                    case 4:
                        lcl_str_TransactionMonth = 'APRIL';
                        break;
                    case 5:
                        lcl_str_TransactionMonth = 'MAY';
                        break;
                    case 6:
                        lcl_str_TransactionMonth = 'JUNE';
                        break;
                    case 7:
                        lcl_str_TransactionMonth = 'JULY';
                        break;
                    case 8:
                        lcl_str_TransactionMonth = 'AUGUST';
                        break;
                    case 9:
                        lcl_str_TransactionMonth = 'SEPTEMBER';
                        break;
                    case 10:
                        lcl_str_TransactionMonth = 'OCTOBER';
                        break;
                    case 11:
                        lcl_str_TransactionMonth = 'NOVEMBER';
                        break;
                    case 12:
                        lcl_str_TransactionMonth = 'DECEMBER';
                        break;
                }

                var lcl_str_TransactionType = '';

                switch (lcl_obj_PFAccountTransaction.PFTransactionType) {
                    case 0:
                        lcl_str_TransactionType = 'NONE';
                        break;
                    case 1:
                        lcl_str_TransactionType = 'EMPLOYEE CONTRIBUTION';
                        lcl_dbl_TotalPFAmount += lcl_obj_PFAccountTransaction.Amount;
                        break;
                    case 2:
                        lcl_str_TransactionType = 'OFFICE CONTRIBUTION';
                        lcl_dbl_TotalPFAmount += lcl_obj_PFAccountTransaction.Amount;
                        break;
                    case 3:
                        lcl_str_TransactionType = 'INTEREST';
                        lcl_dbl_TotalPFAmount += lcl_obj_PFAccountTransaction.Amount;
                        break;
                    case 4:
                        lcl_str_TransactionType = 'PROFIT';
                        lcl_dbl_TotalPFAmount += lcl_obj_PFAccountTransaction.Amount;
                        break;
                    case 5:
                        lcl_str_TransactionType = 'EXPENSE DEDUCTION';
                        lcl_dbl_TotalPFAmount -= lcl_obj_PFAccountTransaction.Amount;
                        break;
                }

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_PFAccountTransactionList[index][0] = lcl_str_TranDate;
                lcl_objLst_PFAccountTransactionList[index][1] = lcl_str_TransactionMonth;
                lcl_objLst_PFAccountTransactionList[index][2] = lcl_obj_PFAccountTransaction.TransactionYear;
                lcl_objLst_PFAccountTransactionList[index][3] = lcl_str_TransactionType;
                var lcl_dbl_PFAmount = lcl_obj_PFAccountTransaction.Amount;
                var lcl_dbl_PFAmountCurrency = numeral(lcl_dbl_PFAmount).format('0,0.00');
                lcl_objLst_PFAccountTransactionList[index][4] = lcl_dbl_PFAmountCurrency;
                lcl_objLst_PFAccountTransactionList[index][5] = lcl_obj_PFAccountTransaction.Remarks;
            });
            
            var lcl_dbl_PFTotalAmountCurrency = numeral(lcl_dbl_TotalPFAmount).format('0,0.00');
            $('#txtTotalPFAmount').val(lcl_dbl_PFTotalAmountCurrency);
            GBL_TBL_PF_DETAILS.fnAddData(lcl_objLst_PFAccountTransactionList);
        }
    };
    options.error = function (err) { ShowErrorMessageBoard(err.statusText); };
    $.ajax(options);
    
}

