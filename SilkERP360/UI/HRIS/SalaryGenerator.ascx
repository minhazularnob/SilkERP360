<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalaryGenerator.ascx.cs" Inherits="SilkERP360.UI.HRIS.SalaryGenerator" %>




<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>


<script src="Scripts/SalaryGenerator.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width: 100%; margin: 0 auto; height: auto;">
    <h2 class="fontSerif">H.R.I.S Salary Generation</h2>
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr>
            <!--QC HEAD-->
            <td colspan="3" style="width: 100%; height: auto;">
                <div id="dvQCHead" style="width: 100%; height: 100%; border-bottom: 1px ridge black;">
                    <br />
                    <br />
                    <table style="width: 90%; margin: 0 auto;" class="ip_control_container">
                        <tr class="align-middle" style="line-height: 1.2;">
                            <td style="width: 15%; padding: 4px 6px;">
                                <label class="form-label fw-semibold mb-0">Salary Month :</label>
                            </td>

                            <td style="width: 34%; padding: 4px 6px;">
                                <asp:DropDownList ID="ddlSalaryMonth"
                                    runat="server"
                                    Width="100%"
                                    ClientIDMode="Static"
                                    CssClass="form-select form-select-sm shadow-sm">
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
                            </td>

                            <td style="width: 2%; padding: 0;"></td>

                            <td style="width: 15%; padding: 4px 6px;">
                                <label class="form-label fw-semibold mb-0">Select Salary Year :</label>
                            </td>

                            <td style="width: 34%; padding: 4px 6px;">
                                <asp:DropDownList ID="ddlSalaryYear"
                                    runat="server"
                                    Width="100%"
                                    ClientIDMode="Static"
                                    CssClass="form-select form-select-sm shadow-sm">
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
                                    <asp:ListItem Value="2026">2026</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr class="align-middle" style="line-height: 1.2;">
                            <td style="width: 15%; padding: 4px 6px;">
                                <label class="form-label fw-semibold mb-0">Salary Cycle From :</label>
                            </td>

                            <td style="width: 34%; padding: 4px 6px;">
                                <asp:TextBox ID="txtSalaryCycleFrom"
                                    runat="server"
                                    Width="100%"
                                    ReadOnly="true"
                                    ClientIDMode="Static"
                                    CssClass="form-control form-control-sm text-center bg-light shadow-sm">
                                </asp:TextBox>
                            </td>

                            <td style="width: 2%; padding: 0;"></td>

                            <td style="width: 15%; padding: 4px 6px;">
                                <label class="form-label fw-semibold mb-0">Salary Cycle Upto :</label>
                            </td>

                            <td style="width: 34%; padding: 4px 6px;">
                                <asp:TextBox ID="txtSalaryCycleUpto"
                                    runat="server"
                                    Width="100%"
                                    ReadOnly="true"
                                    ClientIDMode="Static"
                                    CssClass="form-control form-control-sm text-center bg-light shadow-sm">
                                </asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td colspan="5" style="width: 100%; text-align: center;">
                                <div class="d-flex justify-content-center gap-2 flex-wrap">

                                    <a id="lnkSalaryGenerationSetup"
                                        href="#"
                                        class="btn btn-primary"
                                        onclick="SalaryGenerationSetup(event); return false;"
                                        style="width: 220px;">Salary Generation Setup
                                    </a>

                                    <a id="lnkGenerateSalary"
                                        href="#"
                                        class="btn btn-warning"
                                        onclick="GenerateSalary(event); return false;"
                                        style="width: 220px;">Generate Salary
                                    </a>

                                    <a id="lnkSaveSalary"
                                        href="#"
                                        class="btn btn-success"
                                        onclick="SaveSalary(event); return false;"
                                        style="width: 220px;">Save Salary
                                    </a>

                                </div>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <div id="dvDepartmentwiseWaiver" style="width: 100%;">
                                    <table id="tblDepartmentwiseWaiver" class="table table-sm small text-muted">
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <div id="dvEmployeewiseWaiver" style="width: 100%; height: auto; overflow: scroll;">
                                    <table id="tblEmployeewiseWaiver">
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3">
                <div id="dvGeneratedSalary" class="p-3 bg-light rounded" style="width: 100%;">

                    <!-- Salary Summary Table -->
                    <table class="table table-borderless " style="width: 60%;margin-left:20%">
                        <tbody>
                            <tr>
                                <td class="text-end">Total Gross Salary :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTGross" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td class="text-end">Total P.F :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTProvidentFund" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="text-end">Total Overtime (Hr) :</td>
                                <td class="text-center">
                                    <asp:TextBox ID="txtTOvertime" runat="server" CssClass="form-control form-control-sm text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td class="text-end">Total Tax :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTTax" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="text-end">Total Overtime Amount :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTOvertimeAmount" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td class="text-end">Total Absent Deduction :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTAbsent" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="text-end">Total Allowance :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTAllowance" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td class="text-end">Total Late Deduction :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTLate" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="text-end">Total Others (+) :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTAdditionOthers" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td class="text-end">Total Loan (-) :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTAdvance" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="text-end">Total Others (-) :</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTDeductionOthers" runat="server" CssClass="form-control form-control-sm text-end currency_field" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td class="text-end fw-bold">Total Amount Payable:</td>
                                <td class="text-end">
                                    <asp:TextBox ID="txtTPayable" runat="server" CssClass="form-control form-control-sm text-end currency_field fw-bold" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>

                    <!-- Generated Salary Details Table -->
                    <div class="mt-3">
                        <table id="tblSalary" class="table table-sm small table-striped text-muted">
                            <!-- Data will be populated here -->
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>