<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BonusMaster.ascx.cs" Inherits="SilkERP360.UI.HRIS.BonusMaster" %>
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

<script src="Scripts/BonusMaster.js" type="text/javascript"></script>


<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <h1>BONUS MASTER</h1>
                    <br />
                    <br />
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:100%; padding:2px; height:25px; text-align:center; margin:2px;">
                <label>Select Bonus Master :  </label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlBonusMaster" runat="server" Width="50%" ClientIDMode="Static">
                    <asp:ListItem Value="0">----- Select Bonus Master</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <a id="lnkGetBonusMaster" href="#" class="command_button_enabled QI_EMPLOYEE_MOVEMENT_CTRL" style=" height:20px; line-height:20px; width:220px;">
                    Get Bonus
                </a>
            </td>
        </tr>
        <tr>
            <td  style="width:100%; padding:2px; height:25px; text-align:center; margin:2px;">
                <br /><br />
                <table id='tblBonusList'>
                </table>
            </td>
        </tr>
    </table>
</div>