<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyThroughputVisual.ascx.cs" Inherits="SilkERP360.Reports.SCPM.DailyThroughputVisual" %>
<link href="../Globals/widgets/jqwidgets/jqwidgets/styles/jqx.base.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxcore.js" type="text/javascript"></script>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxdata.js" type="text/javascript"></script>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxchart.js" type="text/javascript"></script>
<script src="../Reports/SCPM/Scripts/DailyThroughputVisual.js" type="text/javascript"></script>


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
   
    <div class="control_container1" style="text-align:center; margin:0 auto;">
        <table style="width:95%; margin:0 auto;">
            <tr>
                <td style="width:10%; text-align:left;">
                    <label>Select Date :</label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:TextBox ID="txtDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="width:10%; text-align:center;">
                     <p class="login button"> 
                        <asp:Button ID="btnGenerateChart" runat="server" CssClass="button" Text="Get Chart" ClientIDMode="Static" OnClientClick="GetDailyThroughputAllSections(); return false;" style="width:100px;" />&nbsp;
                     </p>
                </td>
            </tr>
        </table>
        
    </div>
    &nbsp;
    <div id="dvReport" class="control_container1" style="text-align:center; visibility:visible; margin:0 auto; width:100%;">
        <div id="dvChart" style="width:99%; margin:0 auto;">
            <table id="tblChart" style="width:100%; margin:0 auto;">
                
            </table>
        </div>
    </div>
   
</div>