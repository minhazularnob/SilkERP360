var GBL_SALARY_LIST_TABLE;
$(document).ready(function () {

    $(".addition").css("background-color", "#33CC33");
    $(".deduction").css("background-color", "#CCCC33");
    $(".payable").css("background-color", "#FFFF99");

    GBL_SALARY_LIST_TABLE = $('#tblSalary').dataTable({
        "bJQueryUI": true,
        "bAutoWidth": true,
        "sScrollY": "600px",
        "sScrollX": "200%",
        "sScrollXInner": "150%",
        "bFilter": true,
        "bPaginate": false,
        "bLengthChange": false,
        "aoColumns": [
                    { sTitle: '<b>ID</b>', sWidth: '6%', sClass: 'alignCenter' },
                    { sTitle: '<b>Emp Det</b>', sWidth: '20%', sClass: 'alignLeft' },
                    { sTitle: '<b>Gross</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>O.T Hr</b>', sWidth: '3%', sClass: 'alignCenter' },
                    { sTitle: '<b>O.T Amt(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Arr(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Allwnc(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Bonus(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Incentive(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>N.Allwnce(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>P.Bill(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Oth(+)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Abs.(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Adv.(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>I.Tax(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Late(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>MGMT(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>PF(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>U.Leave(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>Oth(-)</b>', sWidth: '3%', sClass: 'alignRight' },
                    { sTitle: '<b>G.Total</b>', sWidth: '5%', sClass: 'alignRight' },
                    { sTitle: '<b>Status</b>', sWidth: '5%', sClass: 'alignCenter' },
                    { sTitle: '<b>Notes</b>', sWidth: '18%', sClass: 'alignCenter' }
                  ]

    });
    initializeSelect2('ddlSalaryMonth', '------ Select Employee ------', '25%');
    initializeSelect2('ddlSalaryYear', '------ Select Employee ------', '25%');
});

function PrintSalaryMaster(event) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_SalaryMonth = $("#ddlSalaryMonth option:selected").val();
    var lcl_ui64_SalaryYear = $("#ddlSalaryYear option:selected").val();

    var lcl_str_URL = './HRISReportViewer.aspx?RptCode=1&Comp=' + lcl_ui64_CompanyCode + '&SalMon=' + lcl_ui64_SalaryMonth + '&SalYr=' + lcl_ui64_SalaryYear;

    window.open(lcl_str_URL, 'a', 'height=300,width=600');
}

function PrintSalarySlip(event) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_SalaryMonth = $("#ddlSalaryMonth option:selected").val();
    var lcl_ui64_SalaryYear = $("#ddlSalaryYear option:selected").val();
}

function GetSalaryMaster(event) {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_SalaryMonth = $("#ddlSalaryMonth option:selected").val();
    var lcl_ui64_SalaryYear = $("#ddlSalaryYear option:selected").val();

    var options_salary = {};
    options_salary.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/GetSalaryMaster";
    options_salary.dataType = "json";
    options_salary.type = "POST";
    options_salary.data = "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_ui64_CompanyCode) + ",IP_enm_SalaryMonth:" + JSON.stringify(lcl_ui64_SalaryMonth) + ",IP_ui16_SalaryYear:" + JSON.stringify(lcl_ui64_SalaryYear) + "}";
    options_salary.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options_salary.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
            var lcl_obj_SalaryMaster = lcl_obj_WSResponse.Data;
            GBL_SALARY_LIST_TABLE.fnClearTable();
            var lcl_objLst_Salary = new Array();
            var lcl_str_TotalOvertimeHour = parseInt((lcl_obj_SalaryMaster._TotalOvertimeMinutes / 60).toString()) + ":" + parseInt((lcl_obj_SalaryMaster._TotalOvertimeMinutes % 60).toString());
            // var lcl_dbl_TotalAllowance = lcl_obj_SalaryMaster._TotalAdditionAllowance + 

            // var lcl_dbl_PFAmountCurrency = numeral(lcl_dbl_PFAmount).format('0,0.00');

            $("#txtTGross").val(numeral(lcl_obj_SalaryMaster._TotalGrossSalary).format('00.00'));
            $("#txtTProvidentFund").val(numeral(lcl_obj_SalaryMaster._TotalDeductionProvidentFund).format('00.00'));
            $("#txtTOvertime").val(lcl_str_TotalOvertimeHour);

            $("#txtTTax").val(numeral(lcl_obj_SalaryMaster._TotalDeductionTax).format('00.00'));
            $("#txtTOvertimeAmount").val(numeral(lcl_obj_SalaryMaster._TotalOvertimeAmount).format('00.00'));
            $("#txtTAbsent").val(numeral(lcl_obj_SalaryMaster._TotalDeductionAbsent).format('00.00'));
            $("#txtTLate").val(numeral(lcl_obj_SalaryMaster._TotalDeductionLate).format('00.00'));
            $("#txtTAdditionOthers").val(numeral(lcl_obj_SalaryMaster._TotalAdditionOthers).format('00.00'));
            $("#txtTAllowance").val(numeral(lcl_obj_SalaryMaster._TotalAdditionAllowance).format('00.00'));
            $("#txtTDeductionOthers").val(numeral(lcl_obj_SalaryMaster._TotalDeductionOthers).format('00.00'));
            $("#txtTAdvance").val(numeral(lcl_obj_SalaryMaster._TotalDeductionAdvance).format('00.00'));
            $("#txtTPayable").val(numeral(lcl_obj_SalaryMaster._TotalAmountPayable).format('00.00'));
            $("#txtTNightAllowance").val(numeral(lcl_obj_SalaryMaster._TotalNightAllowance).format('00.00'));


            $.each(lcl_obj_SalaryMaster.SalaryList, function (index, lcl_obj_Salary) {

                /****************************************************************************************************************************/
                var lcl_str_OvertimeHour = parseInt((lcl_obj_Salary.OverTimeMinutes / 60).toString()) + ":" + parseInt((lcl_obj_Salary.OverTimeMinutes % 60).toString());
                lcl_objLst_Salary[index] = new Object();

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_Salary[index][0] = lcl_obj_Salary._EmployeeID;
                lcl_objLst_Salary[index][1] = lcl_obj_Salary._EmployeeName + "[" + lcl_obj_Salary._Designation + "] [" + lcl_obj_Salary._Department + "]";

                //numeral(lcl_obj_Salary.Gross).format('00.00')
                lcl_objLst_Salary[index][2] = numeral(lcl_obj_Salary.Gross).format('00.00');
                lcl_objLst_Salary[index][3] = lcl_str_OvertimeHour;

                lcl_objLst_Salary[index][4] = numeral(lcl_obj_Salary.OverTimeAmount).format('00.00');
                lcl_objLst_Salary[index][5] = numeral(lcl_obj_Salary.AdditionArrear).format('00.00');
                lcl_objLst_Salary[index][6] = numeral(lcl_obj_Salary.AdditionAllowance).format('00.00');
                lcl_objLst_Salary[index][7] = numeral(lcl_obj_Salary.AdditionBonus).format('00.00');
                lcl_objLst_Salary[index][8] = numeral(lcl_obj_Salary.AdditionIncentive).format('00.00');
                lcl_objLst_Salary[index][9] = numeral(lcl_obj_Salary.AdditionNightAllowance).format('00.00');
                lcl_objLst_Salary[index][10] = numeral(lcl_obj_Salary.AdditionPhoneBill).format('00.00');
                lcl_objLst_Salary[index][11] = numeral(lcl_obj_Salary.AdditionOthers).format('00.00');
                lcl_objLst_Salary[index][12] = numeral(lcl_obj_Salary.DeductionAbsent).format('00.00');
                lcl_objLst_Salary[index][13] = numeral(lcl_obj_Salary.DeductionAdvance).format('00.00');
                lcl_objLst_Salary[index][14] = numeral(lcl_obj_Salary.DeductionIncomeTax).format('00.00');
                lcl_objLst_Salary[index][15] = numeral(lcl_obj_Salary.DeductionLate).format('00.00');
                lcl_objLst_Salary[index][16] = numeral(lcl_obj_Salary.DeductionPenalty).format('00.00');
                lcl_objLst_Salary[index][17] = numeral(lcl_obj_Salary.DeductionProvidentFund).format('00.00');
                lcl_objLst_Salary[index][18] = numeral(lcl_obj_Salary.DeductionUnpaidLeave).format('00.00');
                lcl_objLst_Salary[index][19] = numeral(lcl_obj_Salary.DeductionOthers).format('00.00');
                lcl_objLst_Salary[index][20] = numeral(lcl_obj_Salary.GrandTotal).format('00.00');


                if (lcl_obj_Salary.SalaryStatus == 1) {
                    lcl_objLst_Salary[index][21] = "Released";
                }
                else {
                    lcl_objLst_Salary[index][21] = "Help Up";
                }
                lcl_objLst_Salary[index][22] = lcl_obj_Salary.Notes;



            });
            //            $('.currency_field').formatCurrency({ groupDigits: true, positiveFormat: '%n' });
            GBL_SALARY_LIST_TABLE.fnAddData(lcl_objLst_Salary);
            GBL_SALARY_MASTER = lcl_obj_SalaryMaster;
            //ShowGeneratedSalary();
        }


    };

    options_salary.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };
    $.ajax(options_salary);
}