<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCPOTest.ascx.cs" Inherits="SilkERP360.UI.SCPM.QCDMTest" %>
<script src="Scripts/QCPOTest.js" type="text/javascript"></script>
<div id="dvQCMaster" style="width:90%; border:0px ridge black; margin:0 auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <td>
                <div>
                    <h2>Peel Off Test</h2>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width:100%; text-align:center;">
                <div>
                    <asp:Button ID="btnClear" runat="server" Width="100px" Text="Clear" OnClientClick="Clear(event); return false;" ClientIDMode="Static" />&nbsp;
                    <asp:Button ID="btnSetup" runat="server" Width="100px" Text="Setup Test" OnClientClick="SetupPOTest(event);return false;" ClientIDMode="Static" />&nbsp;
                    <asp:Button ID="btnEvaluateTest" runat="server" Width="100px" Text="Evaluate" OnClientClick="EvaluateTest();return false;" ClientIDMode="Static" />&nbsp;
                    <asp:Button ID="btnSave" runat="server"  ClientIDMode="Static" Width="100px" Text="Save" OnClientClick="Save(); return false;" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table class="ip_control_container"  style="">
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            <label><b>Mstr. Batch</b></label> 
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtMasterBatch" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:15%; text-align:left;">
                            <label><b>Mstr. Batch Qty.</b></label>
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtMasterBatchQuantity" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            <label><b>Qty Dispatched :</b></label> 
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtMasterBatchQuantityDispatched" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:15%; text-align:left;">
                            <label><b>Remaining Qty :</b></label>
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtMasterBatchQuantityRemaining" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:34%; text-align:center;">
                            &nbsp;
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:15%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:34%; text-align:center;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            <label>Total Sub Batch Qty :</label> 
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtSubBatchQuantity" CssClass="numeric_only ip_required" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:15%; text-align:left;">
                            <label>Wastage</label>
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtWastage" CssClass="numeric_only ip_required" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            <label>Sheet Vendor : </label>
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:DropDownList ID="ddlSheetVendor" runat="server" ClientIDMode="Static" style="width:100%;">
                                <asp:ListItem>-----Select Sheet Vendor</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                         <td style=" width:15%; text-align:left;">
                            <label>Sub-Batch Status : </label>
                        </td>
                        <td style=" width:34%; text-align:center;">
                            <asp:TextBox ID="txtBatchStatus" runat="server" ClientIDMode="Static" Width="100%" CssClass="qc_not_evaluated" ReadOnly="true" Text="Not Evaluated"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style=" width:15%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:34%; text-align:center;">
                            &nbsp;
                        </td>
                        <td style=" width:2%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:15%; text-align:left;">
                            &nbsp;
                        </td>
                        <td style=" width:34%; text-align:center;">
                            &nbsp;
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align:center;">
                <div style="width:100%; margin:0 auto;">
                    <table id="tblDMTest">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>