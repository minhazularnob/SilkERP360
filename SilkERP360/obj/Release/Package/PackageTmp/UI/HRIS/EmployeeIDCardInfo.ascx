<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeIDCardInfo.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmployeeIDCardInfo" %>

<script src="../../UI/HRIS/Scripts/EmployeeIdCardInfo.js" type="text/javascript"></script>

<table>
    <tr>
        <td>
            <div class="container-fluid">
                <div class="card shadow-sm">
                    <div class="card-header text-center border-bottom">
                        <h2 class="mb-0 fontSerif">Employee ID Card Info</h2>
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
                        </div>

                        <div class="card p-3 mb-3 border border-dark">
                            <div class="table-responsive">
                                <table class="table table-bordered mb-0" id="tblEmployeeInfo">
                                    <tbody>
                                        <tr>
                                            <th style="width: 30%;">Employee ID</th>
                                            <td>
                                                <asp:Label ID="lblEmployeeId" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Name</th>
                                            <td>
                                                <asp:Label ID="lblEmployeeName" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Designation</th>
                                            <td>
                                                <asp:Label ID="lblDesignation" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Date of Join</th>
                                            <td>
                                                <asp:Label ID="lblJoiningDate" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Mobile No</th>
                                            <td>
                                                <asp:Label ID="lblMobileNo" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Citizen Card No</th>
                                            <td>
                                                <asp:Label ID="lblCitizenCardId" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Blood Group</th>
                                            <td>
                                                <asp:Label ID="lblBloodGroup" runat="server" CssClass="form-control bg-light fw-bold text-danger" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Department</th>
                                            <td>
                                                <asp:Label ID="lblDepartment" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Employee Picture</th>
                                            <td>
                                                <asp:Image ID="imgEmployeePhoto" runat="server" ImageUrl="~/Globals/Images/images.jpg" Width="100px" Height="100px" ClientIDMode="Static" /></td>
                                        </tr>
                                        <tr>
                                            <th>Company</th>
                                            <td>
                                                <asp:Label ID="lblCompanyName" runat="server" CssClass="form-control bg-light" ClientIDMode="Static" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>


                        <!-- Download Photo Button -->
                        <div class="text-end mt-3">
                            <button type="button" id="btnCopyTable" class="btn btn-outline-primary me-2">
                                <i class="fa fa-copy"></i>Copy Info
                            </button>
                            <button type="button" id="btnDownloadPhoto" class="btn btn-outline-success">
                                <i class="fa fa-download"></i>Download Photo
                            </button>
                        </div>

                    </div>
                </div>

                <div id="dvReportBody" class="card mt-4 d-none">
                    <div class="card-body">
                    </div>
                </div>
            </div>

        </td>
    </tr>
</table>

<style>
    th {
        font-size: large;
    }
</style>
