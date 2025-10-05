<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpLeaveApp.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmpLeaveApp" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>

<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.theme.css" rel="stylesheet"
        type="text/css" />
    <link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.js" type="text/javascript"></script>

<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>



<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>


<script src="Scripts/EmpLeaveApp.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <%--<tr style="padding:5px;">
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="width:0%;padding:2px; height:40px; text-align:center;margin:2px;">
                &nbsp;
            </td>
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center;margin-left:1px;">
                <div id="dvData" style="display:none; color:White;">
                    <span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>
                </div>
            </td>
        </tr>--%>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    
                    <h1>Silkways Group Leave Management App</h1>
                    <br />
                    <br />
                    <table style="width:80%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style=" text-align:center;">
                                <div class='ui-widget'>
                                    <label>Select Employee :</label>
                                    <%--<asp:TextBox ID="txtSearchEmployee" runat="server" ClientIDMode="Static" Width="20%" style="text-align:center;"></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="70%" ClientIDMode="Static">
                                        <asp:ListItem>Select Employee...</asp:ListItem>
                                    </asp:DropDownList>
                               &nbsp;&nbsp;&nbsp;
                                <a id="lnkGetLeaveProfile" href="#" class="command_button_enabled" onclick="GetEmployeeLeaveProfile(event);return false;" style=" height:20px; line-height:20px; width:40px;">
                                        -->>
                                </a>
                                 </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table style="width:80%; margin:0 auto;" class="ip_control_container" >
                         <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Employee Name :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtEmpName" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Designation :</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtDesignation" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"   Width="100%" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Department :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtDepartment" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
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
                                <label>Casual Leave (CL) :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtCL" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Sick Leave (SL) ::</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtSL" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%"  ReadOnly="true"  ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Maternity Leave (ML) :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:TextBox ID="txtML" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left; ">
                                <label>Earned Leave (EL) ::</label>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <asp:TextBox ID="txtEL" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
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
                     </table>
                    <div style="max-height:400px; overflow:scroll;">
                        <table style="width:100%; margin:0 auto;" class="ip_control_container" >
                            <tr>
                                <td style=" text-align:center;">
                                    <table id="tblEmpLeaveAppList">
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div style="">
                        <table style="width:80%; margin:0 auto;" class="ip_control_container" >
                             
                            <tr>
                                <td style="width:15%; text-align:left;">
                                    <label>Leave Type :</label>
                                </td>
                                <td style="width:34%; text-align:center;">
                                     <asp:DropDownList ID="ddlLeaveType" CssClass="wg_read_only wg_day_attribute" runat="server"  Width="100%" ClientIDMode="Static">
                                        <asp:ListItem Value="0">None</asp:ListItem>
                                        <asp:ListItem Value="1">Casual Leave (CL)</asp:ListItem>
                                        <asp:ListItem Value="2">Sick Leave (SL)</asp:ListItem>
                                        <asp:ListItem Value="3">Maternity Leave (ML)</asp:ListItem>
                                        <asp:ListItem Value="4">Earned Leave (EL)</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:15%;text-align:left; ">
                                    <label>Leave Category :</label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:DropDownList ID="ddlLeaveCategory" CssClass="wg_read_only wg_operational_status"  runat="server" Width="100%" ClientIDMode="Static">
                                        <asp:ListItem Value="1">Paid</asp:ListItem>
                                        <asp:ListItem Value="2">Unpaid</asp:ListItem>
                                        <%--<asp:ListItem Value="2">Unpaid</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; text-align:left;">
                                    <label>Date From :</label>
                                </td>
                                <td style="width:34%; text-align:center;">
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="wg_read_only ip_required"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:15%;text-align:left; ">
                                    <label>Date Upto :</label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="wg_read_only ip_required" style="text-align:center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; text-align:left;">
                                    <label>Num. Of Days :</label>
                                </td>
                                <td style="width:34%; text-align:center;">
                                    <asp:TextBox ID="txtNumOfDays" runat="server" CssClass="wg_read_only ip_required"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:15%;text-align:left; ">
                                    <label>Rejoin Date :</label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtRejoinDate" runat="server" CssClass="wg_read_only ip_required" style="text-align:center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                             <tr>
                                <td style="width:15%; text-align:left;">
                                    <label>Leave Reason :</label>
                                </td>
                                <td style="width:34%; text-align:center;">
                                    <asp:TextBox ID="txtReason" runat="server" CssClass="wg_read_only ip_required"  style="text-align:center;" Width="100%" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:15%;text-align:left; ">
                                    <label>Remarks :</label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="width:100%; text-align:right;">
                                    <div>
                                        <a id="lnkSave" href="#" class="command_button_enabled" onclick="SaveLeaveApplication(event); return false;" style="height:25px; line-height:25px;" >
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
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>
