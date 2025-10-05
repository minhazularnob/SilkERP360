<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceBySection.ascx.cs" Inherits="SilkERP360.UI.HRIS.AttendanceBySection" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>
<script src="Scripts/AttendanceBySection.js" type="text/javascript"></script>

<div id="dvWorkGroupMaster" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:95%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Section :</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlSection" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value='0'>----- All Section</asp:ListItem>
                                    <asp:ListItem Value='1'>Producton Supervision</asp:ListItem>
                                    <asp:ListItem Value='2'>Mixing</asp:ListItem>
                                    <asp:ListItem Value='3'>Blowing</asp:ListItem>
                                    <asp:ListItem Value='4'>Cutting</asp:ListItem>
                                    <asp:ListItem Value='5'>Packaging</asp:ListItem>
                                    <asp:ListItem Value='6'>Recycle</asp:ListItem>
                                    <asp:ListItem Value='7'>Manual Work</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%; text-align:left;">
                                <label>Work Date :</label>
                            </td>
                            <td style="width:34%;text-align:left; border: 0px solid black; vertical-align:middle;">
                                 <asp:TextBox ID="txtAttendanceDate" runat="server" style="text-align:center;" CssClass="" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width:100%; text-align:right;">
                                <div>
                                    <a id="lnkGetAttendance" href="#" class="command_button_enabled" onclick="GetAttendanceByDesignationListAndDate(event); return false;" style="">
                                        Get Attendance
                                    </a>
                                 </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width:100%; text-align:left;">
                               <table style="width:100%; margin:0 auto;" class="ip_control_container" >
                                 <tr>
                                    <td style="width:15%; text-align:left;">
                                        <label>Total Employee :</label>
                                    </td>
                                    <td style="width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalEmployee" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                    <td style="width:2%;">
                                            &nbsp;
                                    </td>
                                    <td style="width:15%;text-align:left; ">
                                        <label>Total On Leave :</label>
                                    </td>
                                    <td style=" width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalOnLeave" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"   Width="100%" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:15%; text-align:left;">
                                        <label>Total Holiday :</label>
                                    </td>
                                    <td style="width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalOnHoliday" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                    <td style="width:2%;">
                                            &nbsp;
                                    </td>
                                    <td style="width:15%;text-align:left; ">
                                        <label>Total Present :</label>
                                    </td>
                                    <td style=" width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalPresent" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:15%; text-align:left;">
                                        <label>Total Late :</label>
                                    </td>
                                    <td style="width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalLate" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                    <td style="width:2%;">
                                            &nbsp;
                                    </td>
                                    <td style="width:15%;text-align:left; ">
                                        <label>Total Absent :</label>
                                    </td>
                                    <td style=" width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalAbsent" runat="server" CssClass="wg_read_only" style="text-align:center;" Width="100%"  ReadOnly="true"  ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td style="width:15%;text-align:left; ">
                                        <label>Total Overtime :</label>
                                    </td>
                                    <td style=" width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalOvertime" runat="server" CssClass="wg_read_only" style="text-align:center;"  ReadOnly="true"  Width="100%" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                     <td style="width:2%;">
                                            &nbsp;
                                    </td>
                                    <td style="width:15%; text-align:left;">
                                        <%--<label>Salary Processed :</label>--%>
                                    </td>
                                    <td style="width:34%; text-align:center;">
                                        <%--<asp:TextBox ID="txtIsSalaryProcessed" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:15%;text-align:left; ">
                                        <label>Total Night Allowance :</label>
                                    </td>
                                    <td style=" width:34%; text-align:center;">
                                        <asp:TextBox ID="txtTotalNightAllowance" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </td>
                                     <td style="width:2%;">
                                            &nbsp;
                                    </td>
                                    <td style="width:15%; text-align:left;">
                                        
                                    </td>
                                    <td style="width:34%; text-align:center;">
                                        
                                    </td>
                                </tr>
                        <%--<tr>
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
                        </tr>--%>
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
                                <div id="dvAttendance" style="">
                                    <table style="width:100%; margin:0 auto;" class="ip_control_container" >
                                        <tr>
                                            <td style=" text-align:center;">
                                                <table id="tblAttendance">
                                                </table>
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
                <div id="dvSectionEmployee" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black; ">
                    <table id="tblSectionEmployee">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>

