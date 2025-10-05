<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAmmendWeekend.ascx.cs" Inherits="SilkERP360.UI.HRIS.ViewAmmendWeekend" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/ViewAmmendWeekend.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <h1>WEEKEND VIEW/AMMENDMENT</h1>
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Date :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtWeekendDate" runat="server" style="text-align:center;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:49%; text-align:left;">
                                <%--<label>Date Upto :</label>--%>
                                 <a id="lnkWeekendList" href="#" class="command_button_enabled" onclick="GetWeekendList(event); return false;" style="width:150px;">
                                        Get Weekend List
                                    </a>
                            </td>
                            
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="width:100%; text-align:center;">
                                <div>
                                    
                                   
                                    <%--<a id="lnkAddEmployee" href="#" class="command_button_disabled">
                                        Include
                                    </a>--%>
                                    
                                    <%--<a id="lnkUpdateOperationalStatus" href="#" class="command_button_disabled" >
                                        Updt Op Status
                                    </a>
                                    <a id="lnkUpdateDayAttribute" href="#" class="command_button_disabled" >
                                        Updt Day Attrb
                                    </a>--%>
                                    <%--<a id="lnkSyncInclusion" href="#" class="command_button_disabled" >
                                        Sync. Inclusion
                                    </a>
                                    <a id="lnkSyncRemoval" href="#"  class="command_button_disabled" >
                                        Sync. Removal
                                    </a>
                                    <a id="lnkSyncAssessmentStatus" href="#" class="command_button_disabled SyncAssessmentStatus" >
                                        Sync. Ass. Status
                                    </a>--%>
                             
                                    <%--<br />
                                    <asp:Button ID="btnUpdateDayAttrb" runat="server"  CssClass="btn_updt_day_attribute operational_command" Width="150px"  Text="Updt Day Attrb." OnClientClick="" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnSyncInclusion" runat="server" CssClass="SyncInclusion operational_command" Width="150px" Text="Sync. Inclusion"  OnClientClick="return false;" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnSyncRemoval" runat="server" CssClass="SyncRemoval operational_command" Width="150px" Text="Sync. Removal"  OnClientClick="return false;" ClientIDMode="Static" />&nbsp;
                                    <asp:Button ID="btnSyncAssessmentStatus" runat="server" CssClass="SyncAssessmentStatus operational_command" ClientIDMode="Static" Width="150px" Text="Sync Status"  OnClientClick="return false;" />
                                    <asp:Button ID="btnSave" runat="server"  CssClass="btn_save operational_command"  ClientIDMode="Static" Width="150px" Text="Save"  OnClientClick="Save(event); return false;" />--%>
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
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="dvEmployeeList" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black; ">
                    <table id="tblEmployees">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>