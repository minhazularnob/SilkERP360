<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PFAccountSummery.ascx.cs" Inherits="SilkERP360.UI.HRIS.PFAccountSummery" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatCurrency-1.4.2/jquery.formatCurrency-1.4.0.min.js"
    type="text/javascript"></script>

<script src="Scripts/PFAccountSummery.js" type="text/javascript"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />
<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:100%; background-color:white; padding:2px; height:40px; text-align:center; margin:2px;">
                <h1>PF Account Summary</h1>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td style="width:100%; height:auto;">
                <div id="dvFilter" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>PF Account Status :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlPFAccountStatus" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>----- All</asp:ListItem>
                                    <asp:ListItem>Active Accounts</asp:ListItem>
                                    <asp:ListItem>Settled Accounts</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvReportHeader" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>T. PF Account :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalPFAccounts" runat="server" style="text-align:center;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <%--<label>Work Date :</label>--%>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 
                                
                            </td>
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>T. Emp. Contribution :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalEmployeeContribution" runat="server" style="text-align:right;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>T. Office Contibution :</label>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtTotalOfficeContribution" runat="server" style="text-align:right;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>T. Profile :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalProfit" runat="server" CssClass="wg_read_only WG_IP"  style="text-align:right;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>T. Interest :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalInterest" runat="server" CssClass="wg_read_only WG_IP" style="text-align:right;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>T. Expense :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalExpense" runat="server" CssClass="wg_read_only WG_IP" Text="0"  style="text-align:right;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Grand Total :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtGrandTotal" runat="server" style="text-align:right;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="dvReportBody" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black; display:none;">
                    <table id="tblPFAccountSummery">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>