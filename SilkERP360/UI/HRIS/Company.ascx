<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Company.ascx.cs" Inherits="SilkERP360.UI.HRIS.Company" %>

<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/Company.js" type="text/javascript"></script>


<!-- Company.ascx -->

<!-- Outer wrapper for company content -->
<div id="companyWrapper" style="width: 100%; margin: 0 auto; height: auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <!-- Page Header -->
                <div id="dvCompany" class="container-fluid">
                    <h1 style="font-family: serif !important">COMPANY</h1>
                </div>

                <!-- Scrollable Content Container -->
                <div id="dCompanyContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height: 0;">
                    <div class="container-fluid">
                        <!-- Row 1: Company Name and Short Name -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label12" runat="server" AssociatedControlID="txt_CompanyName">Company Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompanyName" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Company Name" ></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="txt_CompShortName">Short Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompShortName" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Company Short Name"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 2: Address and Phone No -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label10" runat="server" AssociatedControlID="txt_CompAddress">Address:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompAddress" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Address"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label11" runat="server" AssociatedControlID="txt_CompPhoneNo">Phone No:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompPhoneNo" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Phone No"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 3: Fax No and Email -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="txt_CompFaxNo">Fax No:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompFaxNo" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Fax No"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label5" runat="server" AssociatedControlID="txt_Email">Email:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_Email" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 4: Website -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label6" runat="server" AssociatedControlID="txt_CompWebSite">Web Site:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_CompWebSite" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Web Site"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 5: Save and Clear Buttons -->
                        <div class="row mb-3">
                            <div class="col-md-4"></div>
                            <div class="col-md-2 d-flex justify-content-center">
                                <asp:Button ID="Button2" ClientIDMode="Static" Text="Save" runat="server"
                                    CssClass="btn btn-primary showSaveBtn" OnClientClick="Save(); return false;" />
                            </div>
                            <div class="col-md-2 d-flex justify-content-center">
                                <asp:Button ID="Button1" ClientIDMode="Static" Text="Clear" runat="server"
                                    CssClass="btn btn-secondary" OnClientClick="clearFields(); return false;" />
                            </div>
                            <div class="col-md-4"></div>
                        </div>

                        <!-- Row 6: Company List Table (Responsive) -->
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="tblCompanyList" class="table custom-table fontSerif w-100">
                                        <!-- Table content (headers and rows) will be dynamically injected -->
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
    </table>

</div>







<!-- Modal -->
<div class="modal fade" id="companyModal" tabindex="-1" aria-labelledby="companyModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="companyModalLabel">Update Company Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <form id="companyForm">
                    <div class="row mb-3">
                        <div class="col-md-4">
                            <label for="companyCode" class="form-label">Company Code</label>
                            <input type="text" class="form-control" id="companyCode" name="companyCode" readonly style="background-color: #e4ebf1">
                        </div>
                        <div class="col-md-4">
                            <label for="name" class="form-label">Name</label>
                            <input type="text" class="form-control" id="name" name="name" required>
                        </div>
                        <div class="col-md-4">
                            <label for="shortName" class="form-label">Short Name</label>
                            <input type="text" class="form-control" id="shortName" name="shortName">
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="address" class="form-label">Address</label>
                        <textarea class="form-control" id="address" name="address" rows="2" cols="2" style="width: 95%"></textarea>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="phoneNo" class="form-label">Phone No.</label>
                            <input type="tel" class="form-control" id="phoneNo" name="phoneNo">
                        </div>
                        <div class="col-md-6">
                            <label for="faxNo" class="form-label">Fax No</label>
                            <input type="text" class="form-control" id="faxNo" name="faxNo">
                        </div>
                    </div>

                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="email" class="form-label">Email</label>
                            <input type="email" class="form-control" id="email" name="email">
                        </div>
                        <div class="col-md-6">
                            <label for="website" class="form-label">Website</label>
                            <input type="url" class="form-control" id="website" name="website">
                        </div>
                    </div>

                </form>
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" form="companyForm" class="btn btn-primary" onclick="Save()">Save changes</button>
            </div>

        </div>
    </div>
</div>




