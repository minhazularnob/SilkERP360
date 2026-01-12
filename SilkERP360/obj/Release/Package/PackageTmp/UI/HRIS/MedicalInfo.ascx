<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MedicalInfo.ascx.cs" Inherits="SilkERP360.UI.HRIS.MedicalInfo" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />

<script src="../../Globals/Scripts/SilkERP360/HRIS/MedicalInfo.js" type="text/javascript"></script>

<div class="container-fluid">
    <div class="card shadow-sm">
        <div class="card-header text-center border-bottom">
            <h2 class="mb-0 fontSerif">Medical Information</h2>
        </div>
        <div class="card-body">
            <div class="row mb-4">
                <div class="col-3"></div>
                <div class="col-md-4 text-start">
                    <asp:DropDownList ID="ddlEmployeeId" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-select mb-3">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <div></div>
                </div>
                <div class="col-2">
                    <button class="btn btn-primary"
                        onclick="GetEmployeeMedicalInfoProfile(event);LoadMedicalInfo(); return false;">
                        <i class="fa fa-search me-2"></i>
                    </button>
                </div>
            </div>

            <!-- Medical Form -->
            <div class="row g-3 align-items-center">

                <!-- Visit Date -->
                <div class="col-md-3 text-end">
                    <label class="form-label fw-bold" for="txt_VisitedDate">Visit Date</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txt_VisitedDate" runat="server"
                        ClientIDMode="Static"
                        ReadOnly="true"
                        CssClass="form-control text-primary"
                        Placeholder="Visited Date">
                    </asp:TextBox>
                </div>

                <!-- Blood Group -->
                <div class="col-md-1 text-end">
                    <label class="form-label fw-bold" for="ddlBloodGroup">Blood Group</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlBloodGroup" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-select">
                        <asp:ListItem Value="0">Select Blood Group</asp:ListItem>
                        <asp:ListItem>A (+ve)</asp:ListItem>
                        <asp:ListItem>A (-ve)</asp:ListItem>
                        <asp:ListItem>B (+ve)</asp:ListItem>
                        <asp:ListItem>B (-ve)</asp:ListItem>
                        <asp:ListItem>O (+ve)</asp:ListItem>
                        <asp:ListItem>O (-ve)</asp:ListItem>
                        <asp:ListItem>AB (+ve)</asp:ListItem>
                        <asp:ListItem>AB (-ve)</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- Age -->
                <div class="col-md-3 text-end">
                    <label class="form-label fw-bold" for="txt_Age">Age</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txt_Age" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-control"
                        Placeholder="Age">
                    </asp:TextBox>
                </div>

                <!-- Sex -->
                <div class="col-md-1 text-end">
                    <label class="form-label fw-bold" for="ddlSex">Sex</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddlSex" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-select">
                        <asp:ListItem Value="0">Select Gender</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- Diagnosis -->
                <div class="col-md-3 text-end">
                    <label class="form-label fw-bold" for="txt_Diagnosis">Diagnosis</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txt_Diagnosis" runat="server"
                        ClientIDMode="Static"
                        TextMode="MultiLine"
                        Rows="3"
                        CssClass="form-control"
                        Placeholder="Diagnosis">
                    </asp:TextBox>
                </div>

                <!-- Remarks -->
                <div class="col-md-1 text-end">
                    <label class="form-label fw-bold" for="txt_Remarks">Remarks</label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txt_Remarks" runat="server"
                        ClientIDMode="Static"
                        TextMode="MultiLine"
                        Rows="3"
                        CssClass="form-control"
                        Placeholder="Remarks">
                    </asp:TextBox>
                </div>

            </div>

            <!-- Save Button -->
            <div class="text-center mt-4">
                <button class="btn btn-primary px-5" onclick="Save(); return false;">
                    <i class="fa fa-save me-2"></i>Save
                </button>

            </div>

        </div>
    </div>

    <!-- Medical Info List -->
    <div id="dvReportBody" class="card mt-4 d-none">
        <div class="card-body">
            <table id="tblMdcnInfoList"
                class="table custom-table fontSerif w-100">
            </table>
        </div>
    </div>
</div>
