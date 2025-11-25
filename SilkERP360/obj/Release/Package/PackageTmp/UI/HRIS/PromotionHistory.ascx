<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PromotionHistory.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.PromotionHistory" %>

<!-- Styles -->
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" />
<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet" />
<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.theme.css" rel="stylesheet" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" />
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" />

<!-- Scripts -->
<script src="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js"></script>

<script src="Scripts/PromotionHistory.js"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />

<div class="container-fluid my-4" id="dvWorkGroupMaster">
    <div class="card shadow-sm">

        <!-- Page Header -->
        <div class="card-header text-center bg-white">
            <h2 class="fontSerif mb-0">Promotion History</h2>
        </div>

        <div class="card-body">

            <!-- Filter Section (Same as Increment Page) -->
            <div id="dvFilter" class="border-bottom pb-3 mb-4">
                <div class="row align-items-center g-3">

                    <div class="col-md-3 text-md-end">
                        <label for="ddlEmployeePromotion" class="form-label mb-0">Select Employee:</label>
                    </div>

                    <div class="col-md-6 d-flex align-items-center">
                        <asp:DropDownList ID="ddlEmployeePromotion" runat="server"
                            CssClass="form-select select2" ClientIDMode="Static">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <!-- Promotion Input Section -->
            <div id="dvReportHeader" class="border-bottom pb-3 mb-4">

                <!-- Row 1: Current Designation -->
                <div class="row g-2 align-items-center">
                    <div class="col-md-3 text-md-end">
                        <label for="txtCurrentDesignation" class="form-label">Current Designation:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtCurrentDesignation" runat="server"
                            CssClass="form-control" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-2 text-md-end">
                        <label for="ddlNewDesignation" class="form-label">New Designation:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlNewDesignation" runat="server"
                            CssClass="form-select" ClientIDMode="Static">
                            <asp:ListItem Value="">-- Select Designation --</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <!-- Row 2: Remarks + Effective From -->
                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label for="txtRemarks" class="form-label">Remarks:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtRemarks" runat="server"
                            CssClass="form-control"
                            TextMode="MultiLine" Rows="2" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-2 text-md-end">
                        <label for="txtEffectiveFrom" class="form-label">Effective From:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtEffectiveFrom" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Effective From"></asp:TextBox>
                    </div>
                </div>
                <!-- Row 3: Approvers multi select -->
                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label for="ddlNewDesignation" class="form-label">Approvers:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:DropDownList ID="promotion_approvers" runat="server"
                            CssClass="js-example-basic-multiple" ClientIDMode="Static" multiple="multiple">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="d-flex justify-content-center mt-3 gap-2">
                    <!-- Save Button -->
                    <button type="button" class="btn btn-success flex-fill" style="max-width: 150px;" onclick="SavePromotion(event);">Save</button>

                    <!-- Clear Button (ASP.NET) -->
                    <asp:Button ID="Button1"
                        ClientIDMode="Static"
                        Text="Clear"
                        runat="server"
                        CssClass="btn btn-secondary flex-fill"
                        Style="max-width: 150px;"
                        OnClientClick="clearFields(); return false;" />
                </div>

                <!-- Buttons Container -->

            </div>
            <!-- Table Section (Same as Increment Page) -->
            <div id="dvReportBody" class="table-responsive">
                <table id="tblPromotionHistory" class="table custom-table fontSerif w-100"></table>
            </div>
        </div>
    </div>
</div>
