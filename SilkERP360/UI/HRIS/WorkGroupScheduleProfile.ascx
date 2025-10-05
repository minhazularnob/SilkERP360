<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupScheduleProfile.ascx.cs" Inherits="SilkERP360.UI.HRIS.WorkGroupScheduleProfile" %>



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

<script src="Scripts/WorkGroupScheduleProfile.js" type="text/javascript"></script>
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
                    
                    <h1>Silkways Group WorkGroup Schedule</h1>
                    <br />
                    <br />
                    <table style="width:80%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style=" text-align:center;">
                                <label>Select Date :</label>
                                <asp:TextBox ID="txtScheduleDate" runat="server" CssClass="wg_read_only"  style="text-align:center;" Width="60%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                <a id="lnkGetSchedule" href="#" class="command_button_enabled" onclick="GetWorkGroupSchedule(event);return false;" style=" height:20px; line-height:20px; width:40px;">
                                        -->>
                                </a>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    
                    <div id="dvWorkGroupSchedule" style="">
                        <table style="width:100%; margin:0 auto;" class="ip_control_container" >
                            <tr>
                                <td style=" text-align:center;">
                                    <table id="tblWorkGroupSchedule">
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                </div>
            </td>
        </tr>
    </table>
</div>