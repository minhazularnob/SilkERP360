<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupIP.ascx.cs" Inherits="SilkERP360.UI.HRIS.WorkGroupIP" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/WorkGroupIP.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="width:0%;padding:2px; height:40px; text-align:center;margin:2px;">
                &nbsp;
            </td>
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center;margin-left:1px;">
                <div id="dvData" style="display:none; color:White;">
                    <%--<span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>--%>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Work Group :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlWorkGroup" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>----- Select Work Group</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>Work Date :</label>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtWorkDate" runat="server" style="text-align:center;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>
                            <%--<td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Duty Starts At :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtDutyStartsAt" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Duty Hour :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtDutyHour" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Overtime Limit (Minute) :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtOvertimeLimit" runat="server" CssClass="wg_read_only" Text="0"  style="text-align:center;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                
                            </td>
                            <td style=" width:34%; text-align:center;">
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Day Attribute :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                 <asp:DropDownList ID="ddlDayAttribute" CssClass="wg_read_only wg_day_attribute" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Regular Working Day</asp:ListItem>
                                    <%--<asp:ListItem Value="1">Casual Working Day</asp:ListItem>
                                    <asp:ListItem Value="2">General Strike Day</asp:ListItem>
                                    <asp:ListItem Value="3">Rainy Working Day</asp:ListItem>
                                    <asp:ListItem Value="4">Weekend</asp:ListItem>
                                    <asp:ListItem Value="5">GovernmentHoliday</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Operational Status :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlOperationalStatus" CssClass="wg_read_only wg_operational_status"  runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value="1">On</asp:ListItem>
                                    <asp:ListItem Value="2">Off</asp:ListItem>
                                    <asp:ListItem Value="3">Holiday Off</asp:ListItem>
                                    <asp:ListItem Value="4">Weekend Off</asp:ListItem>
                                    <asp:ListItem Value="5">Scheduled Off</asp:ListItem>
                                    <asp:ListItem Value="6">Duty On Holiday</asp:ListItem> 
                                    <asp:ListItem Value="7">Shift Change Duty (SC)</asp:ListItem>
                                    <asp:ListItem Value="8">Shift Change Off (SC)</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label><b>Upload CSV File : </b></label>
                            </td>
                            <td style="width:100%; vertical-align:middle;">
                                 <asp:FileUpload ID="fuUploadFile"  runat="server" Enabled="false"  CssClass="wg_read_only" onchange ="EmployeeListFileSelected(event);return false;"  AllowMultiple="false" Width="100%" ClientIDMode="Static" />
                                 
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Include Employee :</label>
                            </td>
                            <td style="width:34%;">
                                 <asp:TextBox ID="txtNewEmployee" runat="server" Text=""  CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                                 
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                
                            </td>
                            <td style=" width:34%; text-align:center;">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Total Present :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                 <asp:TextBox ID="txtTotalPresent" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Total Absent :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalAbsent" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Total Late :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                 <asp:TextBox ID="txtTotalLate" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Total Leave :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalLeave" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Total Man Hour :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                 <asp:TextBox ID="txtTotalManHour" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Total Overtime :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtTotalOvertime" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only"  Width="100%" style="text-align:center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width:100%; text-align:center;">
                                <div>
                                    <a id="lnkManage" href="#" class="command_button_enabled" onclick="GetWorkGroupByDate(event); return false;" style="">
                                        Get Data
                                    </a>
                                    <a id="lnkAddEmployee" href="#" class="command_button_disabled">
                                        Include
                                    </a>
                                    <a id="lnkUploadEmployeeFile" href="#"  class="command_button_disabled" >
                                        Upload File
                                    </a>
                                    <%--<a id="lnkUpdateOperationalStatus" href="#" class="command_button_disabled" >
                                        Updt Op Status
                                    </a>
                                    <a id="lnkUpdateDayAttribute" href="#" class="command_button_disabled" >
                                        Updt Day Attrb
                                    </a>--%>
                                    <a id="lnkSyncInclusion" href="#" class="command_button_disabled" >
                                        Sync. Inclusion
                                    </a>
                                    <a id="lnkSyncRemoval" href="#"  class="command_button_disabled" >
                                        Sync. Removal
                                    </a>
                                    <a id="lnkSyncAssessmentStatus" href="#" class="command_button_disabled SyncAssessmentStatus" >
                                        Sync. Ass. Status
                                    </a>
                                    <a id="lnkSave" href="#" class="command_button_disabled" >
                                        Save
                                    </a>
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
                <div id="dvWorkgroupEmployee" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black; display:none;">
                    <table id="tblWorkgroupEmployee">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>

