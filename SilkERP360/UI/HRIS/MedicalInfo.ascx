<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MedicalInfo.ascx.cs" Inherits="SilkERP360.UI.HRIS.MedicalInfo" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />

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

<script src="../../Globals/Scripts/SilkERP360/HRIS/MedicalInfo.js" type="text/javascript"></script>

<div id="dvMedicalInfos" style="width:100%; border:1px ridge; margin:0 auto; height:auto;">

    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">

        <tr>
            <!--QC HEAD-->
            <td colspan="3" style="width: 100%; height: auto;">
                <div id="dvQCHead" style="width: 100%; height: 100%; border-bottom: 2px ridge;">
                    <h2 class="fontSerif">Medical Information</h2>
                    <table style="width: 80%; margin: 0 auto;" class="ip_control_container">
                        <tr>
                            <td style="text-align: center;">
                                <div class='ui-widget'>
                                    <label>Select Employee :</label>
                                    <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="80%" ClientIDMode="Static">
                                        <asp:ListItem>------ Select Employee ------</asp:ListItem>
                                    </asp:DropDownList>
                                    <button id="lnkGetLeaveProfile" href="#" class="btn btn-primary showSaveBtn" onclick="GetEmployeeMedicalInfoProfile(event);LoadMedicalInfo(); return false;" style="width: 8%">
                                        Show
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <table style="width: 60%; margin: 0 auto;" class="ip_control_container">
                            <tr>
                                <td style="width: 15%; text-align: right;">Visit Date</td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:TextBox ID="txt_VisitedDate" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Visited Date" ReadOnly="true" ForeColor="#00ACFF"></asp:TextBox>
                                </td>
                                <td style="width: 15%; text-align: right;">Blood Group</td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:DropDownList ID="ddlBloodGroup" runat="server" ClientIDMode="Static" PlaceHolder="Blood Group" CssClass="input-required">
                                        <asp:ListItem Value="0">------ Select Blood Group ------</asp:ListItem>
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
                            <tr>
                                <td style="width: 15%; text-align: right;">Age</td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:TextBox ID="txt_Age" CssClass="input required" ClientIDMode="Static" runat="server" Placeholder="Age" ReadOnly="false">
                                    </asp:TextBox>
                                </td>

                                <td style="width: 15%; text-align: right;">Sex</td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:DropDownList ID="ddlSex" runat="server" ClientIDMode="Static" PlaceHolder="Gender" CssClass="input-required">
                                        <asp:ListItem Value="0">------ Select Gender ------</asp:ListItem>
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15%; text-align: right;">Diagnosis<o:p></o:p></td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:TextBox ID="txt_Diagnosis" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Diagnosis" ReadOnly="false" TextMode="MultiLine">
                                    </asp:TextBox>
                                </td>

                                <td style="width: 15%; text-align: right;">Remarks
                                </td>
                                <td style="width: 34%; text-align: left;">
                                    <asp:TextBox ID="txt_Remarks" ClientIDMode="Static" runat="server" CssClass="input required"
                                        Placeholder="Remarks" ReadOnly="false" TextMode="MultiLine">
                                    </asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5" style="width: 100%; text-align: right;">
                                    <div class="d-flex justify-content-center">
                                        <button id="lnkSave" href="#" class="btn btn-primary showSaveBtn" onclick="Save(); return false;">Save
                                        </button>

                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="dvReportBody" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge; display: none">
                    <table id="tblMdcnInfoList" class="table custom-table  fontSerif w-100">
                    </table>    
                </div>
            </td>
        </tr>
    </table>
</div>