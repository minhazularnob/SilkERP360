<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementIOHistory.ascx.cs" Inherits="SilkERP360.UI.HRIS.IncrementIOHistory" %>
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



<%--<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>--%>




<script src="Scripts/IncrementIOHistory.js" type="text/javascript"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />
<div id="dvWorkGroupMaster" style="width:100%; margin:0 auto; height:auto;">
        <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:100%; background-color:white; padding:2px; height:40px; text-align:center; margin:2px;">
                <h2 class="fontSerif">Increment I/O & History</h2>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
           <td style="width:100%; height:auto;">
                <div id="dvFilter" style="width:100%; height:100%; border-bottom:2px ridge;">
                    <table style="width:90%; margin:0 auto;" class="" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label style="display: flex; justify-content: flex-end">Select Employee :</label>
                            </td>
                            <td style="width:34%; text-align:left;">
                                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control select2" Width="80%" ClientIDMode="Static">
                                    <asp:ListItem Value="">-- Select Employee --</asp:ListItem>
                                </asp:DropDownList>
                               
                                &nbsp;&nbsp;&nbsp;
                                <button id="btnShow" href="#" class="btn btn-primary showSaveBtn" onclick="DisplayIncrementHistory(event); return false;" >
                                     Show
                                </button>
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
                <div id="dvReportHeader" style="width:100%; height:100%; border-bottom:2px ridge;">
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                       <table style="width:90%; margin:0 auto;" class="ip_control_container">
    <tr>
        <td style="width:15%;"></td>
        <td style="width:34%;"></td>
        <td style="width:2%;"></td>
        <td style="width:15%;"></td>
        <td style="width:34%; vertical-align:middle;"></td>
    </tr>

    <tr>
        <td style="text-align: right"><label>Effective Month :</label></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlEffectiveMonth" runat="server" Width="100%" ClientIDMode="Static">
                <asp:ListItem Value="0">------ Select Month ------</asp:ListItem>
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
        <td></td>
        <td style="text-align: right"><label>Effective Year :</label></td>
        <td style="text-align:left;">
            <asp:DropDownList ID="ddlEffectiveYear" runat="server" Width="100%" ClientIDMode="Static">
                <asp:ListItem Value="0">------ Select Year ------</asp:ListItem>
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
    </tr>

    <tr>
        <td style="text-align: right"><label>Increment Gross :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncGross" runat="server" style="text-align:center;" CssClass="INC_IP" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
        </td>
        <td></td>
        <td style="text-align: right"><label>Current Gross :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtCurrGross" runat="server" style="text-align:center;" CssClass="INC_IP" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right"><label>Inc. Basic :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncBasic" runat="server" style="text-align:right;" CssClass="INC_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
        </td>
        <td></td>
        <td style="text-align: right"><label>Inc House Rent :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncHR" runat="server" style="text-align:right;" CssClass="INC_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
        </td>
    </tr>

    <tr>
        <td style="text-align: right"><label>Inc. Conveyence :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncConv" runat="server" CssClass="wg_read_only INC_IP" style="text-align:right;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
        </td>
        <td></td>
        <td style="text-align: right"><label>Inc. Medical :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncMed" runat="server" CssClass="wg_read_only INC_IP" style="text-align:right;" Width="100%" ClientIDMode="Static"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right"><label>Inc. Entertainment :</label></td>
        <td style="text-align:left;">
            <asp:TextBox ID="txtIncEnt" runat="server" CssClass="wg_read_only INC_IP" Text="0" style="text-align:right;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
        </td>
        <td></td>
        <td></td>
        <td></td>
    </tr>

    <tr>
        <td colspan="5" style="text-align:center;">
            <a id="A1" href="#" class="btn btn-primary showSaveBtn" onclick="SaveIncrement(event); return false;" style="margin-top: 5px">
                Save
            </a>
        </td>
    </tr>

    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
</table>

                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:60%; height:auto;">
                <div id="dvReportBody" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge; display: none">
                    <table id="tblIncrementHistory" class="table custom-table  fontSerif w-100">
                    </table>    
                </div>
            </td>
            
        </tr>
    </table>
</div>