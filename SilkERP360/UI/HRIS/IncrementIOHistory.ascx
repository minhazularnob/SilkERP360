<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementIOHistory.ascx.cs" Inherits="SilkERP360.UI.HRIS.IncrementIOHistory" %>

<script src="Scripts/IncrementIOHistory.js" type="text/javascript"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />
<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr style="padding: 5px;">
        <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
            <div class="container-fluid my-4" id="dvWorkGroupMaster">
                <div class="card shadow-sm">
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">Increment I/O & History</h2>
                    </div>

                    <div class="card-body">
                        <!-- Filter Section -->
                        <div id="dvFilter" class="border-bottom pb-3 mb-4">
                            <div class="row align-items-center g-3">
                                <div class="col-md-3 text-md-end">
                                    <label for="ddlEmployee" class="form-label mb-0">Select Employee:</label>
                                </div>
                                <div class="col-md-6 d-flex align-items-center">
                                    <asp:DropDownList ID="ddlEmployee" runat="server"
                                        CssClass="form-select select2" ClientIDMode="Static">
                                        <asp:ListItem Value=""></asp:ListItem>
                                    </asp:DropDownList>
                                    <button id="btnShow" class="btn btn-primary ms-3"
                                        onclick="DisplayIncrementHistory(event); return false;">
                                        Show
                                    </button>
                                </div>
                            </div>
                        </div>

                        <!-- Report Header -->
                        <div id="dvReportHeader" class="border-bottom pb-3 mb-4">
                            <div class="row g-3">
                                <!-- Effective Month -->
                                <div class="col-md-3 text-md-end">
                                    <label for="ddlEffectiveMonth" class="form-label">Effective Month:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEffectiveMonth" runat="server"
                                        CssClass="form-select" ClientIDMode="Static">
                                        <asp:ListItem Value="0">------ Select Month ------</asp:ListItem>
                                        <asp:ListItem Value="1">January</asp:ListItem>
                                        <asp:ListItem Value="2">February</asp:ListItem>
                                        <asp:ListItem Value="3">March</asp:ListItem>
                                        <asp:ListItem Value="4">April</asp:ListItem>
                                        <asp:ListItem Value="5">May</asp:ListItem>
                                        <asp:ListItem Value="6">June</asp:ListItem>
                                        <asp:ListItem Value="7">July</asp:ListItem>
                                        <asp:ListItem Value="8">August</asp:ListItem>
                                        <asp:ListItem Value="9">September</asp:ListItem>
                                        <asp:ListItem Value="10">October</asp:ListItem>
                                        <asp:ListItem Value="11">November</asp:ListItem>
                                        <asp:ListItem Value="12">December</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Effective Year -->
                                <div class="col-md-3 text-md-end">
                                    <label for="ddlEffectiveYear" class="form-label">Effective Year:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddlEffectiveYear" runat="server"
                                        CssClass="form-select" ClientIDMode="Static">
                                        <asp:ListItem Value="0">------ Select Year ------</asp:ListItem>
                                        <asp:ListItem Value="2016">2016</asp:ListItem>
                                        <asp:ListItem Value="2017">2017</asp:ListItem>
                                        <asp:ListItem Value="2018">2018</asp:ListItem>
                                        <asp:ListItem Value="2019">2019</asp:ListItem>
                                        <asp:ListItem Value="2020">2020</asp:ListItem>
                                        <asp:ListItem Value="2021">2021</asp:ListItem>
                                        <asp:ListItem Value="2022">2022</asp:ListItem>
                                        <asp:ListItem Value="2023">2023</asp:ListItem>
                                        <asp:ListItem Value="2024">2024</asp:ListItem>
                                        <asp:ListItem Value="2025">2025</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Increment Gross & Current Gross -->
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncGross" class="form-label">Increment Gross:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncGross" runat="server" 
                                        CssClass="form-control text-center INC_IP" 
                                        ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-md-3 text-md-end">
                                    <label for="txtCurrGross" class="form-label">Current Gross:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtCurrGross" runat="server" 
                                        CssClass="form-control text-center INC_IP" 
                                        ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                </div>

                                <!-- Inc. Basic & House Rent -->
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncBasic" class="form-label">Inc. Basic:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncBasic" runat="server" 
                                        CssClass="form-control text-end INC_IP" 
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncHR" class="form-label">Inc. House Rent:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncHR" runat="server" 
                                        CssClass="form-control text-end INC_IP" 
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>

                                <!-- Inc. Conveyance & Medical -->
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncConv" class="form-label">Inc. Conveyance:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncConv" runat="server" 
                                        CssClass="form-control text-end INC_IP" 
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncMed" class="form-label">Inc. Medical:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncMed" runat="server" 
                                        CssClass="form-control text-end INC_IP" 
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>

                                <!-- Inc. Entertainment -->
                                <div class="col-md-3 text-md-end">
                                    <label for="txtIncEnt" class="form-label">Inc. Entertainment:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtIncEnt" runat="server" 
                                        CssClass="form-control text-end INC_IP" 
                                        Text="0" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <!-- Save Button -->
                            <div class="text-center mt-4">
                                <a id="A1" href="#" class="btn btn-success px-4" 
                                    onclick="SaveIncrement(event); return false;">
                                    Save
                                </a>
                            </div>
                        </div>

                        <!-- Report Body -->
                        <div id="dvReportBody" class="table-responsive">
                            <table id="tblIncrementHistory" class="table custom-table fontSerif w-100">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>

