<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MachinewiseThroughputVisualByDateRange.ascx.cs" Inherits="SilkERP360.Reports.SCPM.MachinewiseThroughputVisualByDateRange" %>
<%--<base href="/Reports/" />--%>
<script src="../Reports/SCPM/Scripts/MachinewiseThroughputVisualByDateRange.js" type="text/javascript"></script>

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


<div id="dvBody" class="ui_control_wrapper1 box" style="Width:98%;height:auto; margin:0 auto; z-index:1000000;">
    <%--<asp:ScriptManagerProxy ID="SCRIPT2" runat="server">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference Path= "../../Reports/Scripts/DailyThroughputVisual.js" />
            </Scripts>
        </CompositeScript>
    </asp:ScriptManagerProxy>--%>
    
    <div class="close_box">X</div>
    <h2>Silkcard Production Throughput</h2>
   
    <div style="text-align:center; margin:0 auto;">
        <table style="width:95%; margin:0 auto;">
            <tr>
                <td style="width:15%; text-align:left; padding:1px;">
                    Start Date
                </td>
                <td style="width:30%; text-align:center; padding:1px;">
                    <asp:TextBox ID="txtStartDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="width:10%;">
                    &nbsp;
                </td>
                <td style="width:15%; text-align:left; padding:1px; ">
                    End Date
                </td>
                <td style="width:30%; text-align:center; padding:1px;">
                    <asp:TextBox ID="txtEndDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:15%; text-align:left; padding:1px;">
                    Section :
                </td>
                <td colspan="4" style="width:85%; text-align:center; padding:1px;">
                    <asp:DropDownList ID="ddlSection" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Production Section</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%; text-align:left; padding:1px;">
                    Processes :
                </td>
                <td  colspan="4" style="width:85%; text-align:center; padding:1px;">
                    <asp:DropDownList ID="ddlProcess" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Production Process</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:15%; text-align:left; padding:1px;">
                    Machines :
                </td>
                <td colspan="4" style="width:85%; text-align:center; padding:1px;">
                    <asp:DropDownList ID="ddlMachine" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Machine</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="width:100%; text-align:center;">
                     <p class="login button"> 
                        <asp:Button ID="btnGenerateChart" runat="server" CssClass="button" Text="Get Throughput" ClientIDMode="Static" OnClientClick="GetMachineThroughputByDateRange(); return false;" style="width:100px;" />&nbsp;
                     </p>
                </td>
            </tr>
        </table>
        
    </div>
    &nbsp;
    <div id="dvReport" class="control_container1" style="text-align:center; visibility:visible; margin:0 auto; width:100%;">
        <div id="dvChartContainer" style="width:99%; margin:0 auto;">
            <table id="tblChart" style="width:100%; margin:0 auto;">
                <tr>
                    <td>
                        <div style='height: 700px; width: 100%;'>
                            <div id='host' style="margin: 0 auto; width:100%; height:700px;">
		                        <div id='jqxChart' style="width:100%; height:700px; position: relative; left: 0px; top: 0px;">
		                        </div>
	                        </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
   
</div>