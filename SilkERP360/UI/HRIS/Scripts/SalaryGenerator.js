var GBL_SALARY_MASTER;
var GBL_SALARY_LIST_TABLE;
$(document).ready(function () {
    $("#txtSalaryCycleFrom").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });
    $("#txtSalaryCycleUpto").datepicker({ dateFormat: 'dd/MM/yy', changeMonth: true, changeYear: true, showButtonPanel: true });

    $('#tblDepartmentwiseWaiver').appendGrid({
        caption: 'Departmentwise Waiver',
        initRows: 1,
        columns: [
                                        { name: 'txtDepartmentCode', type: 'hidden', value: 0 },
                                        { name: 'DepartmentName', display: 'Department', type: 'text', displayCss: { 'width': '50%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                                        { name: 'chkDeptWaiveAbsent', display: 'Waive Absent', type: 'checkbox', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required',
                                            onChange: function (evt, rowIndex) {
                                                var lcl_i32_AbsentWaived = $('#tblDepartmentwiseWaiver').appendGrid('getCtrlValue', 'chkDeptWaiveAbsent', rowIndex); //0=NO / 1=YES
                                                if (lcl_i32_AbsentWaived == 0) {
                                                    //NO
                                                }
                                                if (lcl_i32_AbsentWaived == 1) {
                                                }
                                                var lcl_ui64_SelectedDepartmentCode = $('#tblDepartmentwiseWaiver').appendGrid('getCtrlValue', 'txtDepartmentCode', rowIndex);

                                                var lcl_i32_Count = $('#tblEmployeewiseWaiver').appendGrid('getRowCount');
                                                for (var i = 0; i < lcl_i32_Count; i++) {
                                                    var lcl_ui64_EmployeesDepartmentCode = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmpDepartmentCode', i);
                                                    if (lcl_ui64_SelectedDepartmentCode == lcl_ui64_EmployeesDepartmentCode) {
                                                        $('#tblEmployeewiseWaiver').appendGrid('setCtrlValue', 'chkEmpWaiveAbsent', i, lcl_i32_AbsentWaived);
                                                    }
                                                }
                                            }
                                        },
                                        { name: 'chkDeptWaiveLate', display: 'Waive Late', type: 'checkbox', value: '', displayCss: { 'width': '25%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required',
                                            onChange: function (evt, rowIndex) {
                                                var lcl_i32_LateWaived = $('#tblDepartmentwiseWaiver').appendGrid('getCtrlValue', 'chkDeptWaiveLate', rowIndex); //0=NO / 1=YES
                                                if (lcl_i32_LateWaived == 0) {
                                                    //NO
                                                }
                                                if (lcl_i32_LateWaived == 1) {
                                                }
                                                var lcl_ui64_SelectedDepartmentCode = $('#tblDepartmentwiseWaiver').appendGrid('getCtrlValue', 'txtDepartmentCode', rowIndex);

                                                var lcl_i32_Count = $('#tblEmployeewiseWaiver').appendGrid('getRowCount');
                                                for (var i = 0; i < lcl_i32_Count; i++) {
                                                    var lcl_ui64_EmployeesDepartmentCode = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmpDepartmentCode', i);
                                                    if (lcl_ui64_SelectedDepartmentCode == lcl_ui64_EmployeesDepartmentCode) {
                                                        $('#tblEmployeewiseWaiver').appendGrid('setCtrlValue', 'chkEmpWaiveLate', i, lcl_i32_LateWaived);
                                                    }
                                                }
                                            }
                                        },
                                     ],
        hideButtons: {
            remove: true,
            removeLast: true,
            insert: true,
            append: true
        },
        hideRowNumColumn: false

    });

    $('#tblEmployeewiseWaiver').appendGrid({
        caption: 'Employeewise Waiver',
        initRows: 1,
        columns: [
                    { name: 'txtEmpDepartmentCode', type: 'hidden', value: 0 },
                    { name: 'txtEmployeeCode', type: 'hidden', value: 0 },
                    { name: 'txtEmployeeId', display: 'Employee Id', type: 'text', displayCss: { 'width': '10%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtEmployeeName', display: 'Employee Name', type: 'text', displayCss: { 'width': '30%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtEmpDesignation', display: 'Designation', type: 'text', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'txtEmpDepartment', display: 'Department', type: 'text', displayCss: { 'width': '20%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required' },
                    { name: 'chkEmpWaiveAbsent', display: 'W.Absent', type: 'checkbox', displayCss: { 'width': '6%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required',
                        onChange: function (evt, rowIndex) {

                        }
                    },
                    { name: 'chkEmpWaiveLate', display: 'W.Late', type: 'checkbox', value: '', displayCss: { 'width': '6%', 'text-align': 'center' }, ctrlCss: { 'width': '100%', 'text-align': 'center' }, ctrlClass: 'peel_off_ip_required',
                        onChange: function (evt, rowIndex) {

                        }
                    },
                    { name: 'ddlSalaryStatus', type: 'select', display: 'Status', displayCss: { 'width': '8%', 'text-align': 'center' }, ctrlCss: { 'width': '96%', 'text-align': 'center' }, ctrlOptions: { 1: 'Released', 2: 'Help Up'} }
                    ],
        hideButtons: {
            remove: true,
            removeLast: true,
            insert: true,
            append: true
        },
        hideRowNumColumn: false

    });

    GBL_SALARY_LIST_TABLE = $('#tblSalary').dataTable({
        "bJQueryUI": true,
        "bAutoWidth":true,
        "sScrollY": "600px",
        "sScrollX": "150%",
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
//                    { sTitle: '<b>Fxd.Allwnce(+)</b>', sWidth: '4%', sClass: 'alignRight' },
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
});


/*
1. Check If Salary for selected Month and Year has already been generated by checking the SalaryMaster Table

*/
function SalaryGenerationSetup() {

    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_SalaryMonth = $("#ddlSalaryMonth option:selected").val();
    var lcl_ui64_SalaryYear = $("#ddlSalaryYear option:selected").val();

    var options = {};
    options.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/IsSalaryProcessed";
    options.dataType = "json";
    options.type = "POST";
    options.data = "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_ui64_CompanyCode) + ",IP_enm_SalaryMonth:" + JSON.stringify(lcl_ui64_SalaryMonth) + ",IP_ui16_SalaryYear:" + JSON.stringify(lcl_ui64_SalaryMonth) + "}";
    options.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options.success = function (result) {
        var lcl_obj_WSResponse = result.d;

        if (lcl_obj_WSResponse.Data == true) {
            DisplayInformation("SALARY PROCESSED");

        }
        else {
            //DisplayInformation("SALARY not PROCESSED");
            //GET DEPARTMENT LIST
            /**************************************************************************************************************************************************/
            /**************************************************************************************************************************************************/
            var options_dept = {};
            options_dept.url = gbl_URL_Root + "WebServices/HRIS/DepartmentService.asmx/GetDepartmentCoresByCompany";
            options_dept.dataType = "json";
            options_dept.type = "POST";
            options_dept.data = "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_ui64_CompanyCode) + "}";
            options_dept.contentType = "application/json; charset=utf-8";
            //options.processData = false;
            options_dept.success = function (result_dept) {
                var lcl_obj_WSResponseDept = result_dept.d;

                var lcl_objLst_DepartmentList = lcl_obj_WSResponseDept.Data;
                var lcl_i32_Count = $('#tblDepartmentwiseWaiver').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_Count; i++) {
                    $('#tblDepartmentwiseWaiver').appendGrid('removeRow', 0);
                }
                $.each(lcl_objLst_DepartmentList, function (index, lcl_obj_Department) {

                    /****************************************************************************************************************************/
                    $('#tblDepartmentwiseWaiver').appendGrid('appendRow', [
                                    { txtDepartmentCode: lcl_obj_Department.DepartmentCode,
                                        DepartmentName: lcl_obj_Department.Name
                                    }
                                  ]);
                    
                    //lcl_i32_EmployeeNumber++;
                });

            };

            options_dept.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

            $.ajax(options_dept);
            /**************************************************************************************************************************************************/
            /**************************************************************************************************************************************************/
            /**************************************************************************************************************************************************/
            /**************************************************************************************************************************************************/
            //GET Employee List
            var options_emp = {};
            options_emp.url = gbl_URL_Root + "WebServices/HRIS/EmployeeService.asmx/GetEmployeeMiniProfileListByCompany";
            options_emp.dataType = "json";
            options_emp.type = "POST";
            options_emp.data = "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_ui64_CompanyCode) + "}";
            options_emp.contentType = "application/json; charset=utf-8";
            //options.processData = false;
            options_emp.success = function (result_dept) {
                var lcl_obj_WSResponseEmp = result_dept.d;

                var lcl_objLst_EmployeeProfileMiniList = lcl_obj_WSResponseEmp.Data;
                var lcl_i32_Count = $('#tblEmployeewiseWaiver').appendGrid('getRowCount');
                for (var i = 0; i < lcl_i32_Count; i++) {
                    $('#tblEmployeewiseWaiver').appendGrid('removeRow', 0);
                }
                $.each(lcl_objLst_EmployeeProfileMiniList, function (index, lcl_obj_EmployeeProfileMini) {

                    /****************************************************************************************************************************/
                    $('#tblEmployeewiseWaiver').appendGrid('appendRow', [
                                    { txtEmpDepartmentCode: lcl_obj_EmployeeProfileMini.DepartmentCode,
                                        txtEmployeeCode: lcl_obj_EmployeeProfileMini.EmployeeCode,
                                        txtEmployeeId: lcl_obj_EmployeeProfileMini.EmployeeID,
                                        txtEmployeeName:lcl_obj_EmployeeProfileMini.EmployeeName,
                                        txtEmpDesignation:lcl_obj_EmployeeProfileMini.Designation,
                                        txtEmpDepartment: lcl_obj_EmployeeProfileMini.DepartmentName,
                                        ddlSalaryStatus:1
                                    }
                                  ]);

                    //lcl_i32_EmployeeNumber++;
                });

            };

            options_emp.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };
            $.ajax(options_emp);
            /**************************************************************************************************************************************************/
            /**************************************************************************************************************************************************/
        }

    };

    options.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };

    $.ajax(options);

}

function GenerateSalary() {
    var lcl_ui64_CompanyCode = $("#ddlCompany option:selected").val();
    var lcl_ui64_SalaryMonth = $("#ddlSalaryMonth option:selected").val();
    var lcl_ui64_SalaryYear = $("#ddlSalaryYear option:selected").val();
    var lcl_str_SalaryCycleFrom = $("#txtSalaryCycleFrom").val();
    var lcl_str_SalaryCycleUpto = $("#txtSalaryCycleUpto").val();
    var lcl_obj_SalaryMaster = new Object();
    lcl_obj_SalaryMaster.CompanyCode = lcl_ui64_CompanyCode;
    lcl_obj_SalaryMaster.SalaryMonth = lcl_ui64_SalaryMonth;
    lcl_obj_SalaryMaster.SalaryYear = lcl_ui64_SalaryYear;

    lcl_obj_SalaryMaster.SalaryList = new Array();

    var lcl_i32_Count = $('#tblEmployeewiseWaiver').appendGrid('getRowCount');
    for (var i = 0; i < lcl_i32_Count; i++) {
        var lcl_ui64_EmployeeCode = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmployeeCode', i);
        var lcl_i32_AbsentWaived = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'chkEmpWaiveAbsent', i); //0=NO / 1=YES
        var lcl_i32_LateWaived = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'chkEmpWaiveLate', i); //0=NO / 1=YES
        lcl_obj_SalaryMaster.SalaryList[i] = new Object();
        lcl_obj_SalaryMaster.SalaryList[i].EmployeeCode = lcl_ui64_EmployeeCode;
        lcl_obj_SalaryMaster.SalaryList[i]._EmployeeID = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmployeeId', i);
        lcl_obj_SalaryMaster.SalaryList[i]._EmployeeName = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmployeeName', i);
        lcl_obj_SalaryMaster.SalaryList[i]._Designation = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmpDesignation', i);
        lcl_obj_SalaryMaster.SalaryList[i]._Department = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'txtEmpDepartment', i);
        lcl_obj_SalaryMaster.SalaryList[i].SalaryStatus = $('#tblEmployeewiseWaiver').appendGrid('getCtrlValue', 'ddlSalaryStatus', i);

        lcl_obj_SalaryMaster.SalaryList[i].IsAbsentDeductionWaived = lcl_i32_AbsentWaived;
        lcl_obj_SalaryMaster.SalaryList[i].IsLateDeductionWaived = lcl_i32_LateWaived;

    }



    var options_salary = {};
    options_salary.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/GenerateSalary";
    options_salary.dataType = "json";
    options_salary.type = "POST";
    options_salary.data = "{IP_ui64_CompanyCode: " + JSON.stringify(lcl_ui64_CompanyCode) + ",IP_enm_SalaryMonth:" + JSON.stringify(lcl_ui64_SalaryMonth) + ",IP_ui16_SalaryYear:" + JSON.stringify(lcl_ui64_SalaryYear) + ",IP_dt_SalaryCycleFrom:" + JSON.stringify(lcl_str_SalaryCycleFrom) + ",IP_dt_SalaryCycleUpto:" + JSON.stringify(lcl_str_SalaryCycleUpto) + ",IP_obj_SalaryMaster:" + JSON.stringify(lcl_obj_SalaryMaster) + "}";
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



            $("#txtTGross").val(lcl_obj_SalaryMaster._TotalGrossSalary);
            $("#txtTProvidentFund").val(lcl_obj_SalaryMaster._TotalDeductionProvidentFund);
            $("#txtTOvertime").val(lcl_str_TotalOvertimeHour);
            $("#txtTTax").val(lcl_obj_SalaryMaster._TotalDeductionTax);
            $("#txtTOvertimeAmount").val(lcl_obj_SalaryMaster._TotalOvertimeAmount);
            $("#txtTAbsent").val(lcl_obj_SalaryMaster._TotalDeductionAbsent);
            $("#txtTLate").val(lcl_obj_SalaryMaster._TotalDeductionLate);
            $("#txtTAdditionOthers").val(lcl_obj_SalaryMaster._TotalAdditionOthers);
            $("#txtTAllowance").val(lcl_obj_SalaryMaster._TotalAdditionAllowance);
            $("#txtTDeductionOthers").val(lcl_obj_SalaryMaster._TotalDeductionOthers);
            $("#txtTAdvance").val(lcl_obj_SalaryMaster._TotalDeductionAdvance);
            $("#txtTPayable").val(lcl_obj_SalaryMaster._TotalAmountPayable);

            $.each(lcl_obj_SalaryMaster.SalaryList, function (index, lcl_obj_Salary) {

                /****************************************************************************************************************************/
                var lcl_str_OvertimeHour = parseInt((lcl_obj_Salary.OverTimeMinutes / 60).toString()) + ":" + parseInt((lcl_obj_Salary.OverTimeMinutes % 60).toString());
                lcl_objLst_Salary[index] = new Object();

                //lcl_objLst_EmployeeAttendanceSummery[index][0] = AttendanceSummery.EmployeeCode;
                lcl_objLst_Salary[index][0] = lcl_obj_Salary._EmployeeID;
                lcl_objLst_Salary[index][1] = lcl_obj_Salary._EmployeeName + "[" + lcl_obj_Salary._Designation + "] [" + lcl_obj_Salary._Department + "]";
                lcl_objLst_Salary[index][2] = lcl_obj_Salary.Gross;
                lcl_objLst_Salary[index][3] = lcl_str_OvertimeHour;
                lcl_objLst_Salary[index][4] = lcl_obj_Salary.OverTimeAmount;
                lcl_objLst_Salary[index][5] = lcl_obj_Salary.AdditionArrear;
                lcl_objLst_Salary[index][6] = lcl_obj_Salary.AdditionAllowance;
                lcl_objLst_Salary[index][7] = lcl_obj_Salary.AdditionBonus;
                lcl_objLst_Salary[index][8] = lcl_obj_Salary.AdditionIncentive;
                lcl_objLst_Salary[index][9] = lcl_obj_Salary.AdditionNightAllowance;
                //lcl_objLst_Salary[index][10] = lcl_obj_Salary._MonthlyFixedAllowance;
                lcl_objLst_Salary[index][10] = lcl_obj_Salary.AdditionPhoneBill;
                lcl_objLst_Salary[index][11] = lcl_obj_Salary.AdditionOthers;
                lcl_objLst_Salary[index][12] = lcl_obj_Salary.DeductionAbsent;
                lcl_objLst_Salary[index][13] = lcl_obj_Salary.DeductionAdvance;
                lcl_objLst_Salary[index][14] = lcl_obj_Salary.DeductionIncomeTax;
                lcl_objLst_Salary[index][15] = lcl_obj_Salary.DeductionLate;

                lcl_objLst_Salary[index][16] = lcl_obj_Salary.DeductionPenalty;
                lcl_objLst_Salary[index][17] = lcl_obj_Salary.DeductionProvidentFund;
                lcl_objLst_Salary[index][18] = lcl_obj_Salary.DeductionUnpaidLeave;
                lcl_objLst_Salary[index][19] = lcl_obj_Salary.DeductionOthers;
                lcl_objLst_Salary[index][20] = lcl_obj_Salary.GrandTotal;
                if (lcl_obj_Salary.SalaryStatus == 1) {
                    lcl_objLst_Salary[index][21] = "Released";
                }
                else {
                    lcl_objLst_Salary[index][21] = "Help Up";
                }
                lcl_objLst_Salary[index][22] = lcl_obj_Salary.Notes;

                //MUST BE DONE TO AVOID FormatException ON SERVER.STRING DATE MUST BE SET.DATE WILL BE SET ON SERVER
                $.each(lcl_obj_SalaryMaster.SalaryList[index].SalaryAdditionDeductionList, function (index1, lcl_obj_AdditionDeduction) {
                    lcl_obj_SalaryMaster.SalaryList[index].SalaryAdditionDeductionList[index1].AdditionDeductionDate = "01/January/2015";
                    lcl_obj_SalaryMaster.SalaryList[index].SalaryAdditionDeductionList[index1].EntryDate = "01/January/2015";
                });
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

function HideGeneratedSalary() {
    $("#dvGeneratedSalary").hide("slow", function () {
        
    });
}

function ShowGeneratedSalary() {
    $("#dvGeneratedSalary").show("slow");
}

function SaveSalary(event) {
    if (GBL_SALARY_MASTER == NaN || GBL_SALARY_MASTER == null) {
        DisplayError("Operational Error : Salary Has Not Yet Been Generated!!!");
        return;
    }
    GBL_SALARY_MASTER.ProcessDate = "01/January/2015";



    GBL_SALARY_MASTER.PreparationEmployeeCode = $('#txtSignedInEmployeeCode').val();
    var options_salary = {};
    options_salary.url = gbl_URL_Root + "WebServices/HRIS/SalaryService.asmx/SaveSalary";
    options_salary.dataType = "json";
    options_salary.type = "POST";
    options_salary.data = "{IP_obj_SalaryMaster:" + JSON.stringify(GBL_SALARY_MASTER) + "}";
    options_salary.contentType = "application/json; charset=utf-8";
    //options.processData = false;
    options_salary.success = function (result) {
        var lcl_obj_WSResponse = result.d;
        if (lcl_obj_WSResponse.ResponseCode == -1) {
            DisplayError(lcl_obj_WSResponse.Message);
            return;
        }
        if (lcl_obj_WSResponse.ResponseCode == 0) {
           DisplaySuccess("Operational Success : Salary Saved Successfully!!!");
        }
    };

    options_salary.error = function (err) { alert(err.statusText); ShowErrorMessageBoard(err.statusText); };
    $.ajax(options_salary);
}
