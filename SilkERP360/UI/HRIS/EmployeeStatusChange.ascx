<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeStatusChange.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.EmployeeStatusChange" %>

<script src="../../Globals/Scripts/SilkERP360/HRIS/EmployeeStatusChange.js" type="text/javascript"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
    <tr>
        <td>
            <div class="container-fluid my-4" id="dvEmployeeStatusChange">
                <div class="card shadow-sm">

                    <!-- Page Header -->
                    <div class="card-header text-center bg-white">
                        <h3 class="fontSerif mb-0">Employee Status Change</h3>
                    </div>

                    <div class="card-body">

                        <!-- Employee Image Section -->
                        <div class="row mb-4">
                            <div class="col-md-12 text-center">
                                <asp:Image ID="imgEmployeeImage" runat="server"
                                    ClientIDMode="Static"
                                    CssClass="img-thumbnail"
                                    Height="160px"
                                    Width="160px" />
                            </div>
                        </div>

                        <!-- Employee Information -->
                        <div class="border-bottom pb-3 mb-4">

                            <!-- Row 1 -->
                            <div class="row g-2 align-items-center">
                                <div class="col-md-3 text-md-end">
                                    <label for="txt_emp_ID" class="form-label">Employee ID:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_emp_ID" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        ReadOnly="true" />
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label for="txt_emp_Name" class="form-label">Employee Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_emp_Name" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        ReadOnly="true" />
                                </div>
                            </div>

                            <!-- Row 2 -->
                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-3 text-md-end">
                                    <label for="txt_Designation" class="form-label">Designation:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_Designation" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        ReadOnly="true" />
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label for="txt_Department" class="form-label">Department:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_Department" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        ReadOnly="true" />
                                </div>
                            </div>

                            <!-- Row 3 -->
                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-3 text-md-end">
                                    <label for="txt_Currnt_status" class="form-label">Current Status:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_Currnt_status" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        ReadOnly="true" />
                                </div>
                            </div>
                        </div>

                        <!-- Status Change Section -->
                        <div class="border-bottom pb-3 mb-4">

                            <div class="row g-2 align-items-center">
                                <div class="col-md-3 text-md-end">
                                    <label for="ddl_Off_ChangeStatus" class="form-label">Change Status To:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="ddl_Off_ChangeStatus" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-select">
                                        <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                                        <asp:ListItem Value="3">Resigned</asp:ListItem>
                                        <asp:ListItem Value="5">Terminated</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label for="txt_Efct_Date" class="form-label">Effective Date:</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txt_Efct_Date" runat="server"
                                        ClientIDMode="Static"
                                        CssClass="form-control"
                                        Placeholder="Effective Date" />
                                </div>
                            </div>
                        </div>

                        <!-- Action Buttons -->
                        <div class="d-flex justify-content-center gap-2 mt-3">
                            <button type="button"
                                class="btn btn-success flex-fill"
                                style="max-width:150px;"
                                onclick="Save();">
                                Save
                            </button>

                            <asp:Button ID="btnClear"
                                runat="server"
                                Text="Clear"
                                CssClass="btn btn-secondary flex-fill"
                                Style="max-width:150px;"
                                OnClientClick="return false;" />
                        </div>

                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
