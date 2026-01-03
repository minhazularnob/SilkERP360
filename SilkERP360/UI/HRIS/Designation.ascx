<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Designation.ascx.cs" Inherits="SilkERP360.UI.HRIS.Designation" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/Designation.js" type="text/javascript"></script>

<div id="designationWrapper" style="width: 100%; margin: 0 auto; height: auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <!-- Page Header -->
                <div id="dDesignation" class="container-fluid">
                    <h1 style="font-family: serif !important">DESIGNATION</h1>
                </div>

                <!-- Scrollable Content Container -->
                <div id="dDesignationContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height: 0;">
                    <div class="container-fluid">

                        <!-- Row 1: Designation Name and Short Name -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="txt_DesName">Designation Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DesName" CssClass="form-control" ClientIDMode="Static" runat="server" Placeholder="Designation Name"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label2" runat="server" AssociatedControlID="txt_DesShortName">Short Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DesShortName" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Short Name"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 2: Gross and Effective From -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label10" runat="server" AssociatedControlID="txt_DegGross">Gross:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegGross" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Gross" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label11" runat="server" AssociatedControlID="txt_DegEffectiveFrom">Effective From:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegEffectiveFrom" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Effective From"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 3: Basic and Medical -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label3" runat="server" AssociatedControlID="txt_DegBasic">Basic:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegBasic" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Basic" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label5" runat="server" AssociatedControlID="txt_DegMedical">Medical:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegMedical" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Medical" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 4: Entertainment and Conveyance -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label6" runat="server" AssociatedControlID="txt_DegEntertaiment">Entertainment:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegEntertaiment" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Entertainment" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label7" runat="server" AssociatedControlID="txt_DegConveyence">Conveyance:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegConveyence" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Conveyance" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 5: House Rent and Phone Bill -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label4" runat="server" AssociatedControlID="txt_houseRent">House Rent:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_houseRent" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="House Rent" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label8" runat="server" AssociatedControlID="txt_DegPhoneBill">Phone Bill:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegPhoneBill" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Phone Bill" TextMode="Number"></asp:TextBox>
                            </div>
                        </div>

                        <!-- Row 6: Others -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="Label9" runat="server" AssociatedControlID="txt_DegOthers">Others:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DegOthers" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Others" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label12" runat="server" AssociatedControlID="txt_DegOthers">Rank:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_degRank" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Rank" TextMode="Number"></asp:TextBox>
                            </div>

                        </div>

                        <!-- Row 7: Save and Clear Buttons -->
                        <div class="row mb-3">
                            <div class="col-md-4"></div>
                            <div class="col-md-2 text-end">
                                <button class="btn btn-primary" onclick="SaveDesignation(); return false;">
                                    <i class="fa fa-save me-1"></i>Save
                                </button>
                            </div>
                            <div class="col-md-2 text-start">
                                <button class="btn btn-secondary" onclick="clearFields(); return false;">
                                    <i class="fa fa-eraser me-1"></i>Clear
                                </button>
                            </div>
                            <div class="col-md-4">
                            </div>
                        </div>

                        <!-- Row 8: Designation List Table -->
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="tblDesignationList" class="table custom-table fontSerif w-100">
                                        <!-- Table content (headers and rows) will be dynamically injected -->
                                    </table>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>


<div class="modal fade" id="designationModal" tabindex="-1" aria-labelledby="designationModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="designationModalLabel">Update Designation Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <form id="designationForm">

                    <!-- Row 0: Designation ID and Company Name -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DesIdModal" class="form-label">Designation Code</label>
                            <input type="text" class="form-control" id="txt_DesIdModal" readonly style="background-color: #e4ebf1;">
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DesShortNameModal" class="form-label">Company</label>
                            <asp:DropDownList ID="comIdModal" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Row 1: Designation Name and Short Name -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DesNameModal" class="form-label">Designation Name</label>
                            <input type="text" class="form-control" id="txt_DesNameModal" name="txt_DesName" required>
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DesShortNameModal" class="form-label">Short Name</label>
                            <input type="text" class="form-control" id="txt_DesShortNameModal" name="txt_DesShortName" required>
                        </div>
                    </div>

                    <!-- Row 2: Gross and Effective From -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DegGrossModal" class="form-label">Gross</label>
                            <input type="number" class="form-control" id="txt_DegGrossModal" name="txt_DegGross" required>
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DegEffectiveFromModal" class="form-label">Effective From</label>
                            <input type="text" class="form-control" id="txt_DegEffectiveFromModal" name="txt_DegEffectiveFrom" required>
                        </div>
                    </div>

                    <!-- Row 3: Basic and Medical -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DegBasicModal" class="form-label">Basic</label>
                            <input type="number" class="form-control" id="txt_DegBasicModal" name="txt_DegBasic" readonly>
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DegMedicalModal" class="form-label">Medical</label>
                            <input type="number" class="form-control" id="txt_DegMedicalModal" name="txt_DegMedical" readonly>
                        </div>
                    </div>

                    <!-- Row 4: Entertainment and Conveyance -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DegEntertaimentModal" class="form-label">Entertainment</label>
                            <input type="number" class="form-control" id="txt_DegEntertaimentModal" name="txt_DegEntertaiment">
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DegConveyenceModal" class="form-label">Conveyance</label>
                            <input type="number" class="form-control" id="txt_DegConveyenceModal" name="txt_DegConveyence" readonly>
                        </div>
                    </div>

                    <!-- Row 5: House Rent and Phone Bill -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_houseRentModal" class="form-label">House Rent</label>
                            <input type="number" class="form-control" id="txt_houseRentModal" name="txt_houseRent" readonly>
                        </div>
                        <div class="col-md-6">
                            <label for="txt_DegPhoneBillModal" class="form-label">Phone Bill</label>
                            <input type="number" class="form-control" id="txt_DegPhoneBillModal" name="txt_DegPhoneBill">
                        </div>
                    </div>

                    <!-- Row 6: Others -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="txt_DegOthersModal" class="form-label">Others</label>
                            <input type="number" class="form-control" id="txt_DegOthersModal" name="txt_DegOthers">
                        </div>
                        <div class="col-md-6">
                            <label for="degStatusModal" class="form-label">Status</label>
                            <asp:DropDownList ID="degStatusModal" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Row 6: Others -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="isOtEligibleModal" class="form-label">Is OT Eligible</label>
                            <asp:DropDownList ID="isOtEligibleModal" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label for="degRankModal" class="form-label">Rank</label>
                            <input type="number" class="form-control" id="degRankModal">
                        </div>

                    </div>

                </form>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" form="designationForm" class="btn btn-primary" onclick="UpdateDesignation()">Save changes</button>
            </div>
        </div>
    </div>
</div>
