<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QueryEngine.ascx.cs" Inherits="SilkERP360.UI.HRIS.QueryEngine" %>
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
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>


<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>

<script src="Scripts/QueryEngine.js" type="text/javascript"></script>


<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <h1>Silkways Group HRIS Query Engine (Employeewise Query)</h1>
                    <br />
                    <br />
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:100%; padding:2px; height:25px; text-align:center; margin:2px;">
                <label>Select Query Type :  </label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlQueryType" runat="server" Width="50%" ClientIDMode="Static">
                    <asp:ListItem Value="0">----- Select Report Type</asp:ListItem>
                    <asp:ListItem Value="1">Employee Movement Tracker</asp:ListItem>
                    <asp:ListItem Value="2">Employeewise Attendance By Date Range</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width:100%; padding:0px; height:25px; text-align:center; margin:0px;">
                <div class='ui-widget'>
                    <label>Select Employee :   </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="70%" ClientIDMode="Static">
                        <asp:ListItem>----- Select Employee </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <hr style="width:100%;" />
            </td>
        </tr>
        <tr style="padding:5px;">
            <td style="width:100%; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvQueryInputEmployeeMovement" class="DV_QI_EMPLOYEE_MOVEMENT" style='width:100%;'>
                    <table id="Table1" class="ip_control_container" style="width:30%; border:0px solid green; padding:10px; background-color:inherit; margin:0 auto;">
                        <tr style="width:100%;">
                            <td style='text-align:left; width:40%;'>
                                <label>Start Date & Time :</label>
                            </td>
                            <td style='text-align:left; width:60%; padding-top:5px;'>
                                <asp:TextBox ID="txtStartDateTime" CssClass="QI_EMPLOYEE_MOVEMENT_CTRL" Enabled="false" ReadOnly="true" runat="server" Width="98%" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style='text-align:left;'>
                                <label>End Date & Time :</label>
                            </td>
                            <td style='text-align:left;'>
                                <asp:TextBox ID="txtEndDateTime" CssClass="QI_EMPLOYEE_MOVEMENT_CTRL" Enabled="false" ReadOnly="true"  runat="server" Width="98%" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style='text-align:right; padding:5px; padding-right:0px;'>
                                <a id="lnkGetEmployeeMovement" href="#" class="command_button_disabled QI_EMPLOYEE_MOVEMENT_CTRL" style=" height:20px; line-height:20px; width:120px;">
                                    Get Movement
                                </a>
                                <a id="lnkGetEmployeewiseAttendance" href="#" class="command_button_disabled QI_EMPLOYEE_MOVEMENT_CTRL" style=" height:20px; line-height:20px; width:120px;">
                                    Get Attendance
                                </a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvDataDisplay" style="width:100%;">
                    <div id="dvMovementData" style="width:60%; margin:0 auto; display:none">
                        <table id="tblMovementData">
                        </table>
                    </div>
                    <div id="dvEmployeewiseAttendance" style="width:100%; display:none;">
                        <br />
                        <br />
                        <h2>Employee Attendance Details</h2>
                        <br />
                        <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                            <%--<tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <td rowspan="6" style="width:12%; border:1px;">
                                    <!--Employee Image-->
                                    <asp:Image ID="imgEmployeeImage" runat="server" ClientIDMode="Static" Height="125px" Width="140px" style=" border:1px;" />
                                </td>
                                <td style="width:23%; text-align:left;">
                                    <label>Company :</label>
                                </td>
                                <td style="width:20%; text-align:center;">
                                    <asp:TextBox ID="txtEACompany" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:23%;text-align:left; ">

                                </td>
                                <td style=" width:20%; text-align:center;">

                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>Employee Id :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEAEmployeeId" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left; ">
                                    <label>Department :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEADepartment" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>Employee Name :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEAEmployeeName" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left; ">
                                    <label>Designation :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEADesignation" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%"  ReadOnly="true"  ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>Tot M.Hour Committed :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEATotalManHourCommitted" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left;">
                                    <label>Tot M.Hour Served :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEATotalManHourServed" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left; ">
                                    <label>Tot Overtime :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEATotalOvertime" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                 <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left;">
                                    <label>Total Absent % (Ctx : TotalWorkingDays) :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtTotalAbsentPercentage" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left; ">
                                    <label>Att Date Range :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEAAttendanceDateRange" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left;">
                                    <label>Total Late % (Ctx : TotalWorkingDays) :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtTotalLatePercentage" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>--%>
                        </table>
                        <br />
                        <table id="tblEmployeewiseAttendance">
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>