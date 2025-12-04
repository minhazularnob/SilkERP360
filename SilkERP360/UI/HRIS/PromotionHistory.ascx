<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PromotionHistory.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.PromotionHistory" %>

<script src="Scripts/PromotionHistory.js"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
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
                                        TextMode="MultiLine" Rows="2" ClientIDMode="Static" Width="92%"></asp:TextBox>
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label for="txtEffectiveFromPromotion" class="form-label">Effective From:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtEffectiveFromPromotion" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Effective From"></asp:TextBox>
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



                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-3 text-md-end">
                                    <label for="showIncrementSectionChkBox" class="form-label">With Increment:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="checkbox" id="showIncrementSectionChkBox" style="margin-top: -2%" />
                                </div>
                            </div>

                            <div id="incrementDiv" style="display: none">
                                <div class="row g-2 align-items-center mt-2">
                                    <!-- Increment Gross & Current Gross -->
                                    <div class="col-md-3 text-md-end">
                                        <label for="txtIncGrossWithPromotion" class="form-label">Increment Gross:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIncGrossWithPromotion" TextMode="Number" runat="server"
                                            CssClass="form-control text-center INC_IP"
                                            ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 text-md-end">
                                        <label for="txtCurrGrossWithPromotion" class="form-label">Current Gross:</label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtCurrGrossWithPromotion" runat="server"
                                            CssClass="form-control text-center INC_IP"
                                            ReadOnly="false" ClientIDMode="Static" Width="71%"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="row g-2 align-items-center mt-2">
                                    <!-- Inc. Basic & House Rent -->
                                    <div class="col-md-3 text-md-end">
                                        <label for="txtIncBasicWithPromotion" class="form-label">Inc. Basic:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIncBasicWithPromotion" runat="server"
                                            CssClass="form-control text-end INC_IP"
                                            ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 text-md-end">
                                        <label for="txtIncHRWithPromotion" class="form-label">Inc. House Rent:</label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtIncHRWithPromotion" runat="server"
                                            CssClass="form-control text-end INC_IP"
                                            ReadOnly="true" ClientIDMode="Static" Width="71%"></asp:TextBox>
                                    </div>
                                </div>


                                <div class="row g-2 align-items-center mt-2">
                                    <!-- Inc. Conveyance & Medical -->
                                    <div class="col-md-3 text-md-end">
                                        <label for="txtIncConvWithPromotion" class="form-label">Inc. Conveyance:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIncConvWithPromotion" runat="server"
                                            CssClass="form-control text-end INC_IP"
                                            ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2 text-md-end">
                                        <label for="txtIncMedWithPromotion" class="form-label">Inc. Medical:</label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtIncMedWithPromotion" runat="server"
                                            CssClass="form-control text-end INC_IP"
                                            ReadOnly="true" ClientIDMode="Static" Width="71%"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row g-2 align-items-center mt-2">
                                    <!-- Inc. Entertainment -->
                                    <div class="col-md-3 text-md-end">
                                        <label for="txtIncEntWithPromotion" class="form-label">Inc. Entertainment:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtIncEntWithPromotion" runat="server"
                                            CssClass="form-control text-end INC_IP"
                                            Text="0" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="d-flex justify-content-center mt-3 gap-2">
                                <!-- Save Button -->
                                <button type="button" class="btn btn-success flex-fill" id="saveBtnId" style="max-width: 150px;" onclick="SavePromotion(event);">Save</button>

                                <!-- Clear Button (ASP.NET) -->
                                <asp:Button ID="Button1"
                                    ClientIDMode="Static"
                                    Text="Clear"
                                    runat="server"
                                    CssClass="btn btn-secondary flex-fill"
                                    Style="max-width: 150px;"
                                    OnClientClick="clearFields(); return false;" />
                            </div>
                        </div>
                        <div id="dvReportBody" class="table-responsive">
                            <asp:TextBox ID="promotionHistory_txtStartDate" runat="server" Style="text-align: center;" CssClass="WG_IP" Width="10%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>To
                            <asp:TextBox ID="promotionHistory_txtEndDate" runat="server" Style="text-align: center;" CssClass="WG_IP" Width="10%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            <table id="tblPromotionHistory" class="table custom-table fontSerif w-100"></table>
                            <div id="tblIncrementHistoryDiv" style="display: none">
                                <table id="tblIncrementHistoryFromPromotion" class="table custom-table fontSerif w-100"></table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
