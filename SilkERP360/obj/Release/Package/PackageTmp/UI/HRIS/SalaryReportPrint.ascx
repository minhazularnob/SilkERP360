<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalaryReportPrint.ascx.cs" Inherits="SilkERP360.UI.HRIS.SalaryReportPrint" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/widgets/NumericCurrencyFormatter/min/numeral.min.js" type="text/javascript"></script>
<script src="Scripts/SalaryReportPrint.js" type="text/javascript"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div class="container-fluid my-4" id="dvSalaryMaster">
                <div class="card shadow-sm">

                    <!-- Page Header -->
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">H.R.I.S Salary Master</h2>
                    </div>

                    <div class="card-body">

                        <!-- Filter Section: Salary Month & Year -->
                        <div id="dvFilter" class="border-bottom pb-3 mb-4">
                            <div class="row align-items-center g-3">
                                <div class="col-md-2 text-md-end">
                                    <label for="ddlSalaryMonth" class="form-label mb-0">Salary Month:</label>
                                </div>
                                <div class="col-md-4 d-flex align-items-center">
                                    <asp:DropDownList ID="ddlSalaryMonth" runat="server" Width="100%" ClientIDMode="Static" CssClass="form-select">
                                        <asp:ListItem Value="0">----- Select Salary Month</asp:ListItem>
                                        <asp:ListItem Value="1">January</asp:ListItem>
                                        <asp:ListItem Value="2">February</asp:ListItem>
                                        <asp:ListItem Value="3">March</asp:ListItem>
                                        <asp:ListItem Value="4">April</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">August</asp:ListItem>
                                        <asp:ListItem Value="9">September</asp:ListItem>
                                        <asp:ListItem Value="10">October</asp:ListItem>
                                        <asp:ListItem Value="11">November</asp:ListItem>
                                        <asp:ListItem Value="12">December</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label for="ddlSalaryYear" class="form-label mb-0">Salary Year:</label>
                                </div>
                                <div class="col-md-4 d-flex align-items-center">
                                    <asp:DropDownList ID="ddlSalaryYear" runat="server" Width="100%" ClientIDMode="Static" CssClass="form-select">
                                        <asp:ListItem Value="0">----- Select Salary Year</asp:ListItem>
                                        <asp:ListItem Value="2015">2015</asp:ListItem>
                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                        <asp:ListItem Value="2018">2018</asp:ListItem>
                                        <asp:ListItem Value="2019">2019</asp:ListItem>
                                        <asp:ListItem Value="2020">2020</asp:ListItem>
                                        <asp:ListItem Value="2021">2021</asp:ListItem>
                                        <asp:ListItem Value="2022">2022</asp:ListItem>
                                        <asp:ListItem Value="2023">2023</asp:ListItem>
                                        <asp:ListItem Value="2024">2024</asp:ListItem>
                                        <asp:ListItem Value="2025">2025</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <!-- Buttons Section -->
                        <div class="d-flex justify-content-center mt-3 gap-2">
                            <a id="lnkSalaryGenerationSetup" href="#"
                                class="btn btn-primary flex-fill"
                                style="max-width: 180px;"
                                onclick="GetSalaryMaster(event); return false;">
                                <i class="fa fa-search me-2"></i>Get Salary Master
                            </a>

                            <a id="A1" href="#" class="command_button_enabled flex-fill" style="max-width: 180px; display: none;" onclick="PrintSalaryMaster(event); return false;">Print Salary Sheet
                            </a>
                            <a id="A2" href="#" class="command_button_enabled flex-fill" style="max-width: 180px; display: none;" onclick="PrintSalarySlip(event); return false;">Print Salary Slip
                            </a>
                        </div>

                        <!-- Salary Summary Section -->
                        <div class="container mt-4 p-4 border rounded shadow-sm bg-light fontSerif">

                            <!-- Row 1 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total Gross Salary :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTGross" runat="server" CssClass="form-control text-end currency_field addition" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total P.F (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTProvidentFund" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Row 2 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total Overtime (Hr) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTOvertime" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total Tax (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTTax" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Row 3 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total Overtime Amount (+) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTOvertimeAmount" runat="server" CssClass="form-control text-end currency_field addition" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total Absent Deduction (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTAbsent" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Row 4 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total Allowance (+) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTAllowance" runat="server" CssClass="form-control text-end currency_field addition" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total Late Deduction (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTLate" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Row 5 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total Others (+) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTAdditionOthers" runat="server" CssClass="form-control text-end currency_field addition" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total Loan (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTAdvance" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Row 6 -->
                            <div class="row mb-3 align-items-center">
                                <div class="col-3 fw-bold">Total N.Allowance (+) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTNightAllowance" runat="server" CssClass="form-control text-end currency_field addition" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-3 fw-bold">Total Others (-) :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTDeductionOthers" runat="server" CssClass="form-control text-end currency_field deduction" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Total Amount Payable -->
                            <div class="row align-items-center mt-4">
                                <div class="col-6"></div>
                                <div class="col-3 fw-bold">Total Amount Payable :</div>
                                <div class="col-3">
                                    <asp:TextBox ID="txtTPayable" runat="server" CssClass="form-control text-end currency_field payable fw-bold" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!-- Salary Table -->
                        <div id="dvSalaryTable" class="table-responsive mt-3">
                            <table id="tblSalary" class="table table-bordered table-striped table-sm small" style="overflow-x: scroll"></table>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
