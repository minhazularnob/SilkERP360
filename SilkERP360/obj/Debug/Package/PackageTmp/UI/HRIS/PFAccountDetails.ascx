<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PFAccountDetails.ascx.cs" Inherits="SilkERP360.UI.HRIS.PFAccountDetails" %>
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
<script src="../../Globals/widgets/NumericCurrencyFormatter/min/numeral.min.js" type="text/javascript"></script>
<script src="Scripts/PFAccountDetails.js" type="text/javascript"></script>


<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <h1>P.F Account Details</h1>
                    <br />
                    <br />
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
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
        <tr style="padding:5px;">
            <td style="width:100%; padding:2px; height:40px; text-align:center; margin:2px;">
                <a id="lnkGetPFAccountDetails" href="#" class="command_button_enabled QI_EMPLOYEE_MOVEMENT_CTRL" style=" height:20px; line-height:20px; width:220px;">
                    Get PF Account Details
                </a>
            </td>
        </tr>
        <tr>
            <td>
                <hr style="width:100%;" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvDataDisplay" style="width:100%;">
                    <div id="dvEmployeewiseAttendance" style="width:100%;">
                        <br />
                        <br />
                        <%--<h2>P.F Account Details</h2>--%>
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
                                    <asp:Image ID="imgEmployeeImage" runat="server" ClientIDMode="Static" Height="100px" Width="100px" style=" border:1px;" />
                                </td>
                                <td style="width:15%; text-align:left;">
                                    <label>Company :</label>
                                </td>
                                <td style="width:28%; text-align:center;">
                                    <asp:TextBox ID="txtCompany" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="width:2%;">
                                        &nbsp;
                                </td>
                                <td style="width:15%;text-align:left; ">

                                </td>
                                <td style=" width:28%; text-align:center;">

                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>Employee Id :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left; ">
                                    <label>Department :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>Employee Name :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left; ">
                                    <label>Designation :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtDesignation1" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%"  ReadOnly="true"  ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:left;">
                                    <label>P.F Acc. No :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtPFAccountNumber" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style="">
                                        &nbsp;
                                </td>
                                <td style="text-align:left;">
                                    <label>Tot P.F Amount :</label>
                                </td>
                                <td style="text-align:center;">
                                    <asp:TextBox ID="txtTotalPFAmount" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="padding:5px;">
                                <td style="text-align:left;">
                                    <label>Account Status : </label>
                                </td>
                                <td style="text-align:left;">
                                    <asp:DropDownList ID="ddlAccountStatus" runat="server" Width="100%" ClientIDMode="Static">
                                        <asp:ListItem Value="0">None</asp:ListItem>
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Settled</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table id="tblPFDetails" style='width:70%;'>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>