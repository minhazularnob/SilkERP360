<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupIPByRange.ascx.cs" Inherits="SilkERP360.UI.HRIS.WorkGroupIPByRange" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/WorkGroupIPByRange.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width:100%; margin:0 auto; height:auto;">
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
                </div>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%;">
                    <h2 class="fontSerif">Work Group Scheduled By Date Range</h2>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Work Group :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlWorkGroup" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>----- Select Work Group -----</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Work Date (From) :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtWorkDateFrom" runat="server" style="text-align:center;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>Work Date (Upto) :</label>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtWorkDateUpto" runat="server" style="text-align:center;" CssClass="WG_IP" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Duty Starts At :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtDutyStartsAt" runat="server" CssClass="wg_read_only WG_IP"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Duty Hour :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtDutyHour" runat="server" CssClass="wg_read_only WG_IP" style="text-align:center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Overtime Limit (Minute) :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtOvertimeLimit" runat="server" CssClass="wg_read_only WG_IP" Text="0"  style="text-align:center;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
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
                                 <asp:FileUpload ID="fuUploadFile"  runat="server" Enabled="true"  CssClass="wg_read_only" onchange ="EmployeeListFileSelected(event);return false;"  AllowMultiple="false" Width="100%" ClientIDMode="Static" />
                                 
                            </td>
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
                            <td colspan="5" style="width:100%; text-align:center;">
                                <div>
                                    <a id="lnkUploadEmployeeFile" href="#" class="command_button_enabled">
                                        <i class="fa fa-upload"></i>Upload File
                                    </a>

                                    <a id="lnkRefresh" href="#"  class="command_button_enabled" onclick="RefreshInput(event);return false;" >
                                        <i class="fa fa-sync-alt me-2"></i>Refresh
                                    </a>
                                    <a id="lnkSave" href="#" class="command_button_enabled" >
                                        <i class="fa fa-save me-2"></i>Save
                                    </a>
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