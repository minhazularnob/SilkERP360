<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MedicalInfo.ascx.cs" Inherits="SilkERP360.UI.HRIS.MedicalInfo" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>

<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet" type="text/css" />
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

<script src="../../Globals/Scripts/SilkERP360/HRIS/MedicalInfo.js" type="text/javascript"></script>


<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    
                    <h1>Medical Information</h1>
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
                                <a id="lnkGetLeaveProfile" href="#" class="command_button_enabled" onclick="GetEmployeeMedicalInfoProfile(event);LoadMedicalInfo();return false;" style=" height:20px; line-height:20px; width:40px;">
                                        -->>
                                </a>
                                 </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <%--<table style="width:80%; margin:0 auto;" class="ip_control_container" >
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
                        
                        
                       
                     </table>--%>
                    <%--<div style="max-height:400px; overflow:scroll;">
                        <table style="width:100%; margin:0 auto;" class="ip_control_container" >
                            <tr>
                                <td style=" text-align:center;">
                                    <table id="tblEmpLeaveAppList">
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>--%>
                    <br />
                    <br />
                    <div style="">
                        <table style="width:80%; margin:0 auto;" class="ip_control_container" >
                             
                            <tr>
                             <td style="width:15%; text-align:left;">
                Visite Date</td>
                                <td style="width:34%; text-align:center;">
                <asp:TextBox ID="txt_VisitedDate" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Visited Date" ReadOnly="true">
                </asp:TextBox>
                                </td>
                                 <td style="width:15%;text-align:left; ">
                Blood Group</td>
                                <td style=" width:34%; text-align:center;">
                <%--<asp:TextBox ID="txt_BloodGroup" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Blood Group" ReadOnly="false">
                </asp:TextBox>--%>
                <asp:DropDownList ID="ddlBloodGroup" runat="server" ClientIDMode="Static" PlaceHolder="Blood Group" CssClass="input-required">
                                            <asp:ListItem Value="0">-----Select Blood Group</asp:ListItem>
                                            <asp:ListItem>A (+ve)</asp:ListItem>
                                            <asp:ListItem>A (-ve)</asp:ListItem>
                                            <asp:ListItem>B (+ve)</asp:ListItem>
                                            <asp:ListItem>B (-ve)</asp:ListItem>
                                            <asp:ListItem>O (+ve)</asp:ListItem>
                                            <asp:ListItem>O (-ve)</asp:ListItem>
                                            <asp:ListItem>AB (+ve)</asp:ListItem>
                                            <asp:ListItem>AB (-ve)</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                                
                               
                                
                            </tr>
                            <tr><td style="width:15%; text-align:left;">
            Age</td>
                                <td style="width:34%; text-align:center;">
                <asp:TextBox ID="txt_Age" CssClass="input required" ClientIDMode="Static" runat="server" Placeholder="Age" ReadOnly="false">
                </asp:TextBox>
                                </td>
                               
                                <td style="width:15%;text-align:left; ">
                 Sex</td>
                                <td style=" width:34%; text-align:center;">
                <%--<asp:TextBox ID="txt_Sex" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Sex" ReadOnly="false">
                </asp:TextBox>--%>
                <asp:DropDownList ID="ddlSex" runat="server" ClientIDMode="Static" PlaceHolder="Gender" CssClass="input-required">
                                        <asp:ListItem Value="0">-----Select Gender</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:15%; text-align:left;">
                Diagnosis<o:p></o:p></td>
                                <td style="width:34%; text-align:center;">
                <asp:TextBox ID="txt_Diagnosis" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Diagnosis" ReadOnly="false" TextMode="MultiLine">
               </asp:TextBox>
                                </td>
                               
                                <td style="width:15%;text-align:left; ">
                Remarks
                                </td>
                                <td style=" width:34%; text-align:center;">
                <asp:TextBox ID="txt_Remarks" ClientIDMode="Static" runat="server" CssClass="input required" 
                                        Placeholder="Remarks" ReadOnly="false" TextMode="MultiLine">
                </asp:TextBox>
                                </td>
                            </tr>
                             
                            
                            <tr>
                                <td colspan="5" style="width:100%; text-align:right;">
                                    <div>
                                        <a id="lnkSave" href="#" class="command_button_enabled" onclick="Save(); return false;" style="height:25px; line-height:25px;" >
                                            Save
                                        </a>
                                       
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>

      <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblMdcnInfoList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    <%--</div>--%>
     </div>