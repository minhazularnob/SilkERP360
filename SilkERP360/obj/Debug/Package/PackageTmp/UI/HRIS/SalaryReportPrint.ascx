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

<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <%--<tr style="padding:5px;">
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="width:0%;padding:2px; height:40px; text-align:center;margin:2px;">
                &nbsp;
            </td>
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center;margin-left:1px;">
                <div id="dvData" style="display:none; color:White;">
                    <%--<span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>
                </div>
            </td>
        </tr>--%>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Salary Month :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlSalaryMonth" runat="server" Width="100%" ClientIDMode="Static">
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
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>Select Salary Year :</label>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:DropDownList ID="ddlSalaryYear" runat="server" Width="100%" ClientIDMode="Static">
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
                            </td>
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
    
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="5" style="width:100%; text-align:center;">
                                <div>
                                    <a id="lnkSalaryGenerationSetup" href="#" class="command_button_enabled" onclick="GetSalaryMaster(event); return false;" style="width:180px;">
                                        Get Salary Master
                                    </a>
                                    <a id="A1" href="#" class="command_button_enabled" onclick="PrintSalaryMaster(event); return false;" style="width:180PX;">
                                        Print Salary Sheet
                                    </a>
                                    <a id="A2" href="#" class="command_button_enabled" onclick="PrintSalarySlip(event); return false;" style="width:180px;">
                                        Print Salary Slip
                                    </a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        
                     </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="dvGeneratedSalary" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <h1>H.R.I.S Salary Master</h1>
                    <table id="tblSalaryMaster" class="ip_control_container" style="width:70%; margin:0 auto;">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width:29%; text-align:left;">
                                <label>Total Gross Salary :</label>
                            </td>
                            <td style="width:20%; text-align:center;">
                                <asp:TextBox ID="txtTGross" runat="server" style="text-align:right;" CssClass="currency_field addition" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:29%; text-align:left;">
                                <label>Total P.F (-) :</label>
                            </td>
                            <td style="width:20%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTProvidentFund" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Total Overtime (Hr) :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtTOvertime" runat="server" style="text-align:center;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Total Tax (-) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTTax" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Total Overtime Amount (+) :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtTOvertimeAmount" runat="server" style="text-align:right;" CssClass="currency_field addition" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Total Absent Deduction (-) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTAbsent" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Total Allowance (+)  :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtTAllowance" runat="server" style="text-align:right;" CssClass="currency_field addition" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Total Late Deduction (-) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTLate" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Total Others (+) :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtTAdditionOthers" runat="server" style="text-align:right;" CssClass="currency_field addition" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                             <td style="text-align:left;">
                                <label>Total Loan (-) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTAdvance" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td style="text-align:left;">
                                <label>Total N.Allowance (+) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTNightAllowance" runat="server" style="text-align:right;" CssClass="currency_field addition" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Total Others (-) :</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTDeductionOthers" runat="server" style="text-align:right;" CssClass="currency_field deduction" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <%--<label>Total Payable (Hr) :</label>--%>
                            </td>
                            <td style="text-align:center;">
                                <%--<asp:TextBox ID="TextBox1" runat="server" style="text-align:right;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>--%>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Total Amount Payable:</label>
                            </td>
                            <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTPayable" runat="server" style="text-align:right;" CssClass="currency_field payable" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div style="">
                        <table id="tblSalary">
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
