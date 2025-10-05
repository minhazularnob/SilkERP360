<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SPMNewPO.ascx.cs" Inherits="SilkERP360.UI.SCPM.SPMNewPO" %>
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="Scripts/SPMNewPO.js" type="text/javascript"></script>
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
     //alert('a');
</script>

<div id="dvBody" class="ui_control_wrapper1 body box" style="Width:98%;height:auto; margin:0 auto;">
    <div class="close_box">X</div>
    <h1>New Purchase Order</h1><br />
   
    <div class="control_container" style="text-align:center; margin:0 auto; width:98%;">
        <table style="width:90%; margin:0 auto;" class="ip_control_container">
            <tr>
                <td style="width:15%; text-align:left;">
                    <label>Select Telco :</label>
                </td>
                <td style="width:34%; text-align:center;">
                    <asp:DropDownList ID="ddlTelco" runat="server" Width="100%" ClientIDMode="Static">
                        <asp:ListItem>----- Select Telco</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:2%;">
                        &nbsp;
                </td>
                <td style="width:15%; text-align:left;">
                    <label>P.O Date :</label>
                </td>
                <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                    <asp:TextBox ID="txtPODate" runat="server" style="text-align:center;" CssClass="PO_IP TELCO_INDEX_CHANGED" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                </td>
            </tr>
            <%--<tr>
                <td style="text-align:left;">
                    <label>Contact Person :</label>
                </td>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtContactPerson" runat="server" style="text-align:center;" CssClass="PO_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="">
                        &nbsp;
                </td>
                <td style="text-align:left;">
                    <label>Contact Phone :</label>
                </td>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtContactPhone" runat="server" style="text-align:center;" CssClass="PO_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>--%>
            <%--<tr>
                <td style="text-align:left;">
                    <label>Address :</label>
                </td>
                <td colspan='4' style="text-align:center;">
                    <asp:TextBox ID="txtAddress" runat="server" style="text-align:center;" CssClass="PO_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td style="text-align:left;">
                    <label>P.O Ref. No. :</label>
                </td>
                <td style="text-align:center;">
                    <asp:TextBox ID="txtPOReferenceNo" runat="server" style="text-align:center;" CssClass="PO_IP TELCO_INDEX_CHANGED" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="">
                        &nbsp;
                </td>
                <td style="text-align:left;">
                    <label>P.O Issue Date :</label>
                </td>
                <td style="text-align:left; border: 0px solid black; vertical-align:middle;">
                    <asp:TextBox ID="txtPOIssueDate" runat="server" style="text-align:center;" CssClass="PO_IP TELCO_INDEX_CHANGED" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                </td>
            </tr>
            <tr>
                <td style="text-align:left;">
                    <%--<label>Remarks :</label>--%>
                </td>
                <td colspan='4' style="text-align:center;">
                    <%--<asp:TextBox ID="txtRemarks" runat="server" style="text-align:center;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan='5' style="text-align:center; border: 0px solid black; vertical-align:middle;">
                    <div>
                        <a id="lnkManage" href="#" class="command_button_enabled" onclick="DisplayScratchcardPO(event); return false;" style="width:220px;">
                            Scratchcard P.O
                        </a>
                        <a id="A1" href="#" class="command_button_enabled" onclick="DisplaySIMPO(event); return false;" style="width:220px;">
                            SIM Card P.O
                        </a>
                    </div>
                </td>
            </tr>
        </table>
        
    </div>
    &nbsp;
    <div id="dvReport" class="control_container" style="text-align:center; width:98%; visibility:visible; margin:0 auto; border:0px;">
        <div id="dvScratchCardPO" style="width:100%; margin:0 auto; border:0px solid black; display:none;">
            <table style="width:100%; margin:0 auto;" class="ip_control_container">
                <tr>
                    <td style="width:15%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Scratch Card Item :
                    </td>
                    <td style="width:20%;text-align:left; background-color:Olive;">
                        <asp:DropDownList ID="ddlSCItem" runat="server" CssClass='SC_IP' Width="98%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- Select Scratchcard Item</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:10%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Deno. :
                    </td>
                    <td style="width:10%;text-align:left; background-color:Olive;">
                        <asp:DropDownList ID="ddlSCItemDenomination" runat="server" CssClass='SC_IP' Width="98%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- Select Deno</asp:ListItem>
                            <asp:ListItem Value='1'>1x1</asp:ListItem>
                            <asp:ListItem Value='2'>2x1</asp:ListItem>
                            <asp:ListItem Value='3'>3x1</asp:ListItem>
                            <asp:ListItem Value='4'>4x1</asp:ListItem>
                            <asp:ListItem Value='5'>5x1</asp:ListItem>
                            <asp:ListItem Value='6'>6x1</asp:ListItem>
                            <asp:ListItem Value='7'>7x1</asp:ListItem>
                            <asp:ListItem Value='8'>8x1</asp:ListItem>
                            <asp:ListItem Value='9'>9x1</asp:ListItem>
                            <asp:ListItem Value='10'>10x1</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td style="width:10%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Del. Date :
                    </td>
                    <td style="width:10%;text-align:left; background-color:Olive;">
                        <asp:TextBox ID="txtSCDeliveryDate" runat="server" style="text-align:center;" CssClass="SC_IP" Width="99%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:10%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Exp. Date :
                    </td>
                    <td style="width:10%;text-align:left; background-color:Olive;">
                        <asp:TextBox ID="txtSCExpiryDate" runat="server" style="text-align:center;" CssClass="SC_IP" Width="99%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:5%;text-align:center; background-color:Olive;">
                        <a id='lnkInsertSCItem' href='#' class="command_button_enabled_small" onclick='InsertSCItemToGrid();' style='font-size:16px;'>+</a>
                    </td>
                </tr>
            </table>
            <div>
                <table id='tblScratchcardPO' style=''>
                
                </table>
            </div>
            <br />
            <table style="width:90%; margin:0 auto;" class="ip_control_container">
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Paper Weight :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSCPaperWeight" runat="server" style="text-align:center;" CssClass="SC_IP  TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        <label>Art Work :</label>
                    </td>
                    <td style="width:34%; text-align:left;">
                        <asp:TextBox ID="txtSCArtWork" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Version :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSCVersion" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        
                    </td>
                    <td style="width:34%; text-align:left;">
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Notes :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSCNotes" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        
                    </td>
                    <td style="width:34%; text-align:right;">
                        <br />
                        <a id="A2" href="#" class="command_button_enabled" onclick="SaveScratchCardPurchaseOrder(event); return false;" style="width:220px;">
                            Save Scratchcard P.O
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
        
        <div id="dvSIMCardPO" style="width:100%; margin:0 auto; border:0px solid black; display:none;">
            <table style="width:100%; margin:0 auto;" class="ip_control_container">
                <tr>
                    <td style="width:20%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Select Item For SIM Card :
                    </td>
                    <td style="width:25%;text-align:left; background-color:Olive;">
                        <asp:DropDownList ID="ddlSIMItem" runat="server" CssClass='SIM_IP' Width="98%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- Select SIM Item</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:10%; text-align:right; background-color:Olive; color:White; font-size:12px; font-weight:bold; font-family:Verdana;">
                        Del. Date :
                    </td>
                    <td style="width:15%;text-align:left; background-color:Olive;">
                        <asp:TextBox ID="txtSIMDeliveryDate" runat="server" style="text-align:center;" CssClass="SIM_IP" Width="99%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:5%;text-align:center; background-color:Olive;">
                        <a id='lnkInsertSIMItem' href='#' class="command_button_enabled_small" onclick='InsertSIMItemToGrid();' style='font-size:16px;'>+</a>
                    </td>
                </tr>
            </table>
            <div>
                <table id='tblSIMPO' style=''>
                
                </table>
            </div>
            <br />
             <table style="width:90%; margin:0 auto;" class="ip_control_container">
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Material Density :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSIMMaterialDensity" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        
                    </td>
                    <td style="width:34%; text-align:left;">
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Varnish (Front) :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:DropDownList ID="ddlSIMVarnishFront" runat="server" CssClass='SIM_IP TELCO_INDEX_CHANGED' Width="99%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- None</asp:ListItem>
                            <asp:ListItem>Spot</asp:ListItem>
                            <asp:ListItem>Solid</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        <label>Varnish (Back) :</label>
                    </td>
                    <td style="width:34%; text-align:left;">
                        <asp:DropDownList ID="ddlSIMVarnishBack" runat="server" CssClass='SIM_IP' Width="99%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- None</asp:ListItem>
                            <asp:ListItem>Spot</asp:ListItem>
                            <asp:ListItem>Solid</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Lamination (Front) :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:DropDownList ID="ddlSIMLaminationFront" runat="server" CssClass='SIM_IP' Width="99%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- None</asp:ListItem>
                            <asp:ListItem>Spot</asp:ListItem>
                            <asp:ListItem>Solid</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        <label>Lamination (Back) :</label>
                    </td>
                    <td style="width:34%; text-align:left;">
                        <asp:DropDownList ID="ddlSIMLaminationBack" runat="server" CssClass='SIM_IP' Width="99%" ClientIDMode="Static" style=''>
                            <asp:ListItem>----- None</asp:ListItem>
                            <asp:ListItem>Spot</asp:ListItem>
                            <asp:ListItem>Solid</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Design :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSIMDesign" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        <label>Art Work :</label>
                    </td>
                    <td style="width:34%; text-align:left;">
                        <asp:TextBox ID="txtSIMArtWork" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:15%; text-align:left;">
                        <label>Notes :</label>
                    </td>
                    <td style="width:34%; text-align:center;">
                        <asp:TextBox ID="txtSIMNotes" runat="server" style="text-align:center;" CssClass="SC_IP TELCO_INDEX_CHANGED" Width="99%" ReadOnly="false" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="width:2%; text-align:left;">
                        &nbsp;
                    </td>
                    <td style="width:15%; text-align:left;">
                        
                    </td>
                    <td style="width:34%; text-align:right;">
                        <br />
                        <a id="A3" href="#" class="command_button_enabled" onclick="SaveSimCardPurchaseOrder(event); return false;" style="width:220px;">
                            Save SIM P.O
                        </a>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>