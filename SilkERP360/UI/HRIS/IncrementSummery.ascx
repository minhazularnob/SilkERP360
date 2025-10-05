<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementSummery.ascx.cs" Inherits="SilkERP360.UI.HRIS.IncrementSummery" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>

<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.theme.css" rel="stylesheet"
        type="text/css" />
    <link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.js" type="text/javascript"></script>

<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>


<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>


<script src="Scripts/IncrementSummery.js" type="text/javascript"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />
<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:100%; background-color:white; padding:2px; height:40px; text-align:center; margin:2px;">
                <h1>Increment Summary</h1>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td style="width:100%; height:auto;">
                <div id="dvFilter" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <table style="width:60%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Select Employee :</label>
                            </td>
                            <td style="width:85%; text-align:left;">
                                <asp:DropDownList ID="ddlEmployee" runat="server" Width="80%" ClientIDMode="Static">
                                    <asp:ListItem>----- Select Employee</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                <a id="btnShow" href="#" class="command_button_enabled" onclick="DisplayIncrementHistory(event); return false;" style="height:20px; line-height:20px;" >
                                     Show
                                </a>
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
                <div id="dvReportHeader" style="width:100%; height:100%; border-bottom:2px ridge black; text-align:center;">
                    <table style="width:60%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                &nbsp;
                            </td>
                            <td style="width:85%; text-align:left;">
                                
                            </td>
                            <%--<td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                                                
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Designation :</label>
                            </td>
                            <td style="text-align:left;">
                                <asp:TextBox ID="txtDesig" runat="server" style="text-align:left;" CssClass="INC_IP" Width="50%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <%--<td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <%--<label>Current Gross :</label>
                            </td>
                            <td style="width:34%;text-align:center; border: 0px solid black; vertical-align:middle;">
                                <asp:TextBox ID="txtCurrGross" runat="server" style="text-align:center;" CssClass="INC_IP" Width="50%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Department :</label>
                            </td>
                            <td style="text-align:left;">
                                <asp:TextBox ID="txtDepartment" runat="server" style="text-align:left;" CssClass="INC_IP" Width="50%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <%--<td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>Inc House Rent :</label>
                            </td>
                            <td style="width:34%;text-align:center; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtIncHR" runat="server" style="text-align:right;" CssClass="INC_IP" Width="50%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>--%>
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Joining Date :</label>
                            </td>
                            <td style="text-align:left;">
                                <asp:TextBox ID="txtJoiningDate" runat="server" CssClass="wg_read_only INC_IP"  style="text-align:left;" Width="50%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                           <%-- <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Inc. Medical :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtIncMed" runat="server" CssClass="wg_read_only INC_IP" style="text-align:right;" Width="50%" ClientIDMode="Static"></asp:TextBox>
                            </td>--%>
                        </tr>
                        <%--<tr>
                            <td style="width:15%; text-align:left;">
                                <label>Inc. Entertainment :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtIncEnt" runat="server" CssClass="wg_read_only INC_IP" Text="0"  style="text-align:right;" Width="50%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                
                            </td>
                            <td style=" width:34%; text-align:right;">
                               
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td colspan='5' style=" text-align:center;">
                                 <a id="A1" href="#" class="command_button_enabled" onclick="SaveIncrement(event); return false;" style="height:20px; line-height:20px;" >
                                     Save
                                </a>
                            </td>
                        </tr>--%>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                
                            </td>
                            <td style="width:34%; text-align:left;">
                                
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <%--<label>Grand Total :</label>--%>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                
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
                    <table id="tblIncrementSummery">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>