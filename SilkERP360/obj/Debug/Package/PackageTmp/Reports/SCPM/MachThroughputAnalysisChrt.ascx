<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachThroughputAnalysisChrt.ascx.cs" Inherits="SilkERP360.Reports.SCPM.MachThroughputAnalysisChrt" %>
<link href="../../Globals/widgets/jqwidgets/jqwidgets/styles/jqx.base.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>
<script src="../../Globals/widgets/jqwidgets/jqwidgets/jqxcore.js" type="text/javascript"></script>
<script src="../../Globals/widgets/jqwidgets/jqwidgets/jqxdata.js" type="text/javascript"></script>
<script src="../../Globals/widgets/jqwidgets/jqwidgets/jqxchart.js" type="text/javascript"></script>

<script src="SCPM/Scripts/MachThroughputAnalysisChrt.js" type="text/javascript"></script>
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


<div id="dvBody" class="ui_control_wrapper1 box" style="Width:96%;height:auto; margin:0 auto;">
    <div class="close_box">X</div>
    <h1>Silkcard Production Throughput</h1>
   
    <div class="control_container" style="text-align:center; margin:0 auto;">
        <table style="width:95%; margin:0 auto;">
            <tr>
                <td style="width:10%; text-align:left;">
                    <label>Start Date</label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="width:10%; text-align:left;">
                    <label>End Date</label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td rowspan="2" style="width:10%; text-align:center;">
                     <p class="login button"> 
                        <asp:Button ID="btnGenerateChart" runat="server" CssClass="button" Text="Get Chart" ClientIDMode="Static" OnClientClick="GetMachineSTRThroughputChart(); return false;" style="width:100px;" />&nbsp;
                     </p>
                </td>
            </tr>
           <tr>
                <td style="width:10%; text-align:left;">
                    <label>Section :</label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:DropDownList ID="ddlSection" Width="96%" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value='0'>-----Select Production Section</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="width:10%; text-align:left;">
                    <label>Processes</label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:DropDownList ID="ddlProcess" Width="96%" runat="server" ClientIDMode="Static">
                        <asp:ListItem Value='0'>-----Select Production Process</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
    </div>
    &nbsp;
    <div id="dvReport" class="control_container1" style="text-align:center; visibility:visible; margin:0 auto; height:auto;">
        <div id="dvChart" style="width:96%; margin:0 auto;">
            <table id="tblChart" style="width:98%; margin:0 auto;">
                
            </table>
        </div>
    </div>
</div>