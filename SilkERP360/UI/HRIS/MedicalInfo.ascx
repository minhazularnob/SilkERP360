<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MedicalInfo.ascx.cs" Inherits="SilkERP360.UI.HRIS.MedicalInfo" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />

<script src="../../Globals/Scripts/SilkERP360/HRIS/MedicalInfo.js" type="text/javascript"></script>

<div class="container-fluid">
    <div class="card shadow-sm">
        <div class="card-header text-center border-bottom">
            <h4 class="mb-0">Medical Information</h4>
        </div>
        <div class="card-body">
            <div class="row mb-4 justify-content-center">
                <div class="col-md-8 text-center">

                    <label class="form-label fw-bold d-block mb-2">
                        Select Employee
                    </label>

                    <asp:DropDownList ID="ddlEmployeeId" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-select mb-3">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    <div></div>

                    <button class="btn btn-primary px-4 mt-2"
                        onclick="GetEmployeeMedicalInfoProfile(event);LoadMedicalInfo(); return false;">
                        Show
                    </button>

                </div>
            </div>

            <!-- Medical Form -->
            <div class="row g-3">

                <div class="col-md-6">
                    <label class="form-label">Visit Date</label>
                    <asp:TextBox ID="txt_VisitedDate" runat="server"
                        ClientIDMode="Static"
                        ReadOnly="true"
                        CssClass="form-control text-primary"
                        Placeholder="Visited Date">
                    </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label">Blood Group</label>
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

                <div class="col-md-6">
                    <label class="form-label">Age</label>
                    <asp:TextBox ID="txt_Age" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-control"
                        Placeholder="Age">
                    </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label">Sex</label>
                    <asp:DropDownList ID="ddlSex" runat="server"
                        ClientIDMode="Static"
                        CssClass="form-select">
                        <asp:ListItem Value="0">Select Gender</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-6">
                    <label class="form-label">Diagnosis</label>
                    <asp:TextBox ID="txt_Diagnosis" runat="server"
                        ClientIDMode="Static"
                        TextMode="MultiLine"
                        Rows="3"
                        CssClass="form-control"
                        Placeholder="Diagnosis" style="width: 94%">
                    </asp:TextBox>
                </div>

                <div class="col-md-6">
                    <label class="form-label">Remarks</label>
                    <asp:TextBox ID="txt_Remarks" runat="server"
                        ClientIDMode="Static"
                        TextMode="MultiLine"
                        Rows="3"
                        CssClass="form-control"
                        Placeholder="Remarks" style="width: 94%">
                    </asp:TextBox>
                </div>
            </div>

            <!-- Save Button -->
            <div class="text-center mt-4">
                <button class="btn btn-success px-5"
                    onclick="Save(); return false;">
                    Save
                </button>
            </div>

        </div>
    </div>

    <!-- Medical Info List -->
    <div id="dvReportBody" class="card mt-4 d-none">
        <div class="card-body">
            <table id="tblMdcnInfoList"
                class="table table-bordered table-striped">
            </table>
        </div>
    </div>
</div>