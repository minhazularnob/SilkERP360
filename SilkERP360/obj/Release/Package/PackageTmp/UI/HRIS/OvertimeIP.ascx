<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OvertimeIP.ascx.cs" Inherits="SilkERP360.UI.HRIS.OvertimeIP" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/OvertimeIP.js" type="text/javascript"></script>

<div id="dvQCMaster" style="width:100%; border:0px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <!--QC HEAD-->
            <td style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Department :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:HiddenField ID="hdnDepartmentCode" runat="server" ClientIDMode="Static" />
                                <asp:TextBox ID="txtDepartment" runat="server" style=" text-align:center;"  ClientIDMode="Static" CssClass="" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left;">
                               <%-- <label>Batch No:</label>--%>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <%--<asp:TextBox ID="txtBatchNo1" runat="server" CssClass="ProductTypeIndexChange_0 lock_qc_master" Width="100%" ClientIDMode="Static"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>O.T Period From :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtOTDate" runat="server" style=" text-align:center;"  ClientIDMode="Static" CssClass="" Width="100%" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                           <%-- <td style="width:15%;text-align:left;">
                                <label>O.T Period To :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtOTDateTo" runat="server" CssClass="" style=" text-align:center;" Width="100%" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width:100%; text-align:right;">
                                <div>
                                    <asp:Button ID="btnClear" runat="server" Width="100px" Text="Clear" OnClientClick="Clear(event); return false;" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnRefresh" runat="server" Width="100px" Text="Refresh" OnClientClick="Refresh(event);return false;" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" Width="100px" Text="Update" OnClientClick="UpdateOT(event);return false;" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnSave" runat="server"  ClientIDMode="Static" Width="100px" Text="Save" OnClientClick="Save(event); return false;" />
                                </div>
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
                &nbsp;
                
            </td>
        </tr>
        
        <tr>
            <!--QC Test Body-->
            <td style="width:100%; height:auto;">
                <div id="dvOvertime" class="qc_test_form_container" style="width:100%; height:100%; border:0px ridge black; display:none;">
                    <table id="tblOvertime">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>
