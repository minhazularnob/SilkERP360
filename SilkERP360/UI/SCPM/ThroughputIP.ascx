<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThroughputIP.ascx.cs" Inherits="SilkERP360.UI.SCPM.ThroughputIP" %>
<script src="../../Globals/Scripts/plug-ins/jquery.numeric.js" type="text/javascript"></script>
<script src="Scripts/ThroughputIP.js" type="text/javascript"></script>
<style type="text/css">
   .box{
    position:relative;
    /*float:right;*/
    background:#eee;
    /*width:200px;*/
    padding:15px;
    margin:10px;
  }
  .close_box{
    background:fuchsia;
    color:#fff;
    padding:2px 5px;
    display:inline;
    position:absolute;
    right:15px;
    border-radius:3px;
    cursor:pointer;
  }
</style>

 <script type="text/javascript">
     $('#boxclose').click(function () {
         $("#dvSubForm").fadeOut(1000, function () {
             $("#dvSubForm").css("top", "-800px");
         });
     });
     $('.close_box').click(function () {
         $(this).parent().fadeOut(1000, 0, function () {
             $(this).remove();
         });
     });
</script>

<div id="dvBody" class="ui_control_wrapper box" style="Width:80%;height:auto; margin:0 auto;">
    <div class="close_box">X</div>
    <h1>Silkcard Production Throughput</h1>
    <p class="login button"> 
        <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick=" SaveThroughput(); return false;" style="width:70px;" />&nbsp;
    </p>
    <div id="dvThroughputForm" style="width:99%; position:relative; margin:0 auto;">
        <table class="ip_cntrl_cntnr1" style="width:70%; table-layout:fixed;margin:0 auto;">
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Production Section :
                </td>
                <td colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Production Section</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Production Processes :
                </td>
                <td  colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlProcess" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Production Process</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Machines :
                </td>
                <td  colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlMachine" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Machine</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Shift :
                </td>
                <td  colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Shift</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Daily Status :
                </td>
                <td  colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlDailyStatus" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%" Enabled="false">
                        <asp:ListItem Value="0">Machine Up</asp:ListItem>
                        <asp:ListItem Value="1">Shift Off</asp:ListItem>
                        <asp:ListItem Value="2">Machine Down Due To Mechanical Error</asp:ListItem>
                        <asp:ListItem Value="3">Machine Down Due To Material Shortage</asp:ListItem>
                        <asp:ListItem Value="4">Machine Down Due To Deficient Order</asp:ListItem>
                        <asp:ListItem Value="5">Machine Down Due To Spare Part Shortage</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Date :
                </td>
                <td  colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:TextBox ID="txtDate" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Target Throughput :
                </td>
                <td style="width:65%; text-align:center; padding:2px;">
                    <asp:TextBox ID="txtTargetThroughput" runat="server" CssClass="input_required clear  numeric_only" ClientIDMode="Static" Width="99%" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="width:5%; text-align:left; padding:2px; font-size:14px; font-weight:bold; padding-left:5px">
                    <asp:Label ID="lblTargetThroughputMeasurementUnit" runat="server" ClientIDMode="Static" Width="99%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Throughput :
                </td>
                <td style="width:65%; text-align:center; padding:2px;">
                    <asp:TextBox ID="txtThroughput" runat="server" CssClass="input_required clear  numeric_only" ClientIDMode="Static" Width="99%"></asp:TextBox>
                </td>
                <td style="width:5%; text-align:left; padding:2px; font-size:14px; font-weight:bold; padding-left:5px">
                    <asp:Label ID="lblThroughputMeasurementUnit" runat="server" ClientIDMode="Static" Width="99%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Wastage :
                </td>
                <td style="width:65%; text-align:center; padding:2px;">
                    <asp:TextBox ID="txtWastage" runat="server" CssClass="input_required clear numeric_only" ClientIDMode="Static" Width="99%" ReadOnly="false"></asp:TextBox>
                </td>
                <td style="width:5%; text-align:left; padding:2px; font-size:14px; font-weight:bold; padding-left:5px">
                    <asp:Label ID="lblWastageMeasurementUnit" runat="server" ClientIDMode="Static" Width="99%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:30%; text-align:left; padding:2px;">
                    Remarks :
                </td>
                <td colspan="2" style="width:70%; text-align:center; padding:2px;">
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="" ClientIDMode="Static" TextMode="MultiLine" Width="99%" ReadOnly="false"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div style="height:10px;">
        <br />
    </div>

    <div id="dvEmployeeList" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>
           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <table id="tblEmployeeList" cellpadding="0px" cellspacing="0px" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>
    </div>
    
    

    
</div>
