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

<div id="dvWorkGroupMaster" style="width: 100%; margin: 0 auto; height: auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 50%; background-color: Gray; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <div id="dvNotification" style="display: none; font-weight: bold; color: white; text-align: left; margin-right: 1px;">
                </div>
            </td>
            <td style="width: 0%; padding: 2px; height: 40px; text-align: center; margin: 2px;">&nbsp;
            </td>
            <td style="width: 50%; background-color: Gray; padding: 2px; height: 40px; text-align: center; margin-left: 1px;">
                <div id="dvData" style="display: none; color: White;">
                </div>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td colspan="3" style="width: 100%; height: auto;">
                <div id="dvQCHead" style="width: 100%; height: 100%;">
                    <h2 class="fontSerif">Work Group Operation</h2>
                    <br />
                    <br />
                    <table style="width: 90%; margin: 0 auto;" class="ip_control_container">
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Work Group :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:DropDownList ID="ddlWorkGroup" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>----- Select Work Group -----</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Work Date :</label>
                            </td>
                            <td style="width: 34%; text-align: left; border: 0px solid black; vertical-align: middle;">
                                <asp:TextBox ID="txtWorkDate" runat="server" Style="text-align: center;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Duty Starts At :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtDutyStartsAt" runat="server" CssClass="wg_read_only" Style="text-align: center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Duty Hour :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtDutyHour" runat="server" CssClass="wg_read_only" Style="text-align: center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Overtime Limit (Minute) :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtOvertimeLimit" runat="server" CssClass="wg_read_only" Text="0" Style="text-align: center;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;"></td>
                            <td style="width: 34%; text-align: center;"></td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Day Attribute :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:DropDownList ID="ddlDayAttribute" CssClass="wg_read_only wg_day_attribute" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Regular Working Day</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Operational Status :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:DropDownList ID="ddlOperationalStatus" CssClass="wg_read_only wg_operational_status" runat="server" Width="100%" ClientIDMode="Static">
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
                            <td style="width: 15%; text-align: left;">
                                <label><b>Upload CSV File : </b></label>
                            </td>
                            <td style="width: 100%; vertical-align: middle;">
                                <asp:FileUpload ID="fuUploadFile" runat="server" Enabled="false" CssClass="wg_read_only" onchange="EmployeeListFileSelected(event);return false;" AllowMultiple="false" Width="100%" ClientIDMode="Static" />

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Include Employee :</label>
                            </td>
                            <td style="width: 34%;">
                                <asp:TextBox ID="txtNewEmployee" runat="server" Text="" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>

                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;"></td>
                            <td style="width: 34%; text-align: center;">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Present :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalPresent" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Absent :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalAbsent" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Late :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalLate" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Leave :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalLeave" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Man Hour :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalManHour" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width: 2%;">&nbsp;
                            </td>
                            <td style="width: 15%; text-align: left;">
                                <label>Total Overtime :</label>
                            </td>
                            <td style="width: 34%; text-align: center;">
                                <asp:TextBox ID="txtTotalOvertime" runat="server" Text="0" ReadOnly="true" CssClass="wg_read_only" Width="100%" Style="text-align: center;" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" style="width: 100%; text-align: center;">
                                <div class="d-flex flex-column align-items-center gap-2">
                                    <!-- Row 1 -->
                                    <div class="d-flex gap-2">
                                        <a id="lnkManage" href="#" class="command_button_enabled"
                                            onclick="GetWorkGroupByDate(event); return false;" style="min-width: 120px;">
                                            <i class="fa fa-database me-2"></i>Get Data
                                        </a>

                                        <a id="lnkAddEmployee" href="#" class="command_button_disabled" style="min-width: 100px;">
                                            <i class="fa fa-user-plus me-2"></i>Include
                                        </a>

                                        <a id="lnkUploadEmployeeFile" href="#" class="command_button_disabled" style="min-width: 120px;">
                                            <i class="fa fa-upload me-2"></i>Upload File
                                        </a>

                                        <a id="lnkSyncInclusion" href="#" class="command_button_disabled" style="min-width: 140px;">
                                            <i class="fa fa-sync-alt me-2"></i>Sync. Inclusion
                                        </a>
                                    </div>

                                    <!-- Row 2 -->
                                    <div class="d-flex gap-2">
                                        <a id="lnkSyncRemoval" href="#" class="command_button_disabled" style="min-width: 170px;">
                                            <i class="fa fa-sync-alt me-2"></i>Sync. Removal
                                        </a>

                                        <a id="lnkSyncAssessmentStatus" href="#" class="command_button_disabled SyncAssessmentStatus" style="min-width: 190px;">
                                            <i class="fa fa-tasks me-2"></i>Sync. Ass. Status
                                        </a>

                                        <a id="lnkSave" href="#" class="command_button_disabled" style="min-width: 100px;">
                                            <i class="fa fa-save me-2"></i>Save
                                        </a>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width: 100%; height: auto;">
                <div id="dvWorkgroupEmployee" class="qc_test_form_container" style="width: 100%; height: auto; border: 0px ridge black; display: none;">
                    <table id="tblWorkgroupEmployee">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>

