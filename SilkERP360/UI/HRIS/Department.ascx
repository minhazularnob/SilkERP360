<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Department.ascx.cs" Inherits="SilkERP360.UI.HRIS.Department" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/Department.js" type="text/javascript"></script>

<div id="departmentWrapper" style="width: 100%; margin: 0 auto; height: auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <!-- Page Header -->
                <div id="dvDepartment" class="container-fluid">
                    <h1 style="font-family: serif !important">DEPARTMENT</h1>
                </div>

                <!-- Scrollable Content Container -->
                <div id="dDepartmentContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height: 0;">
                    <div class="container-fluid">

                        <!-- Row 1: Department Name and Short Name -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="LabelDeptName" runat="server" AssociatedControlID="txt_DeptName">Department Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DeptName" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Department Name"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="LabelDeptShort" runat="server" AssociatedControlID="txt_DeptShortName">Short Name:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txt_DeptShortName" ClientIDMode="Static" runat="server" CssClass="form-control" Placeholder="Department Short Name"></asp:TextBox>
                            </div>
                        </div>


                        <!-- Row 3: Email and Head of Department -->
                        <div class="row mb-3">
                            <div class="col-md-2">
                                <asp:Label ID="LabelDeptHead" ClientIDMode="Static" runat="server" AssociatedControlID="departmentHeadId">Head of Department:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="departmentHeadId" runat="server" CssClass="form-control select2" Width="80%" ClientIDMode="Static">
                                    <asp:ListItem Value="">-- Select Employee --</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-2">
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="isRosterable">Is Rosterable:</asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="isRosterable" ClientIDMode="Static" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Yes" Value="True" Selected></asp:ListItem>
                                    <asp:ListItem Text="No" Value="False"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <!-- Row 4: Save and Clear Buttons -->
                        <div class="row mb-3">
                            <div class="col-md-4"></div>
                            <div class="col-md-2 text-end">
                                <button class="btn btn-primary" onclick="Save(); return false;">
                                    <i class="fa fa-save me-1"></i>Save
                                </button>
                            </div>
                            <div class="col-md-2 text-start">
                                <button class="btn btn-secondary" onclick="clearFields(); return false;">
                                    <i class="fa fa-eraser me-1"></i>Clear
                                </button>
                            </div>
                            <div class="col-md-4"></div>
                        </div>

                        <!-- Row 5: Department List Table -->
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <table id="tblDepartmentList" class="table custom-table fontSerif w-100">
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

<div class="modal fade" id="departmentModal" tabindex="-1" aria-labelledby="departmentModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="departmentModalLabel">Update Department Details</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <form id="departmentForm">

                    <!-- Row 1 -->
                    <div class="row mb-3">
                        <div class="col-md-4">
                            <label for="deptCode" class="form-label">Department Code</label>
                            <input type="text" class="form-control" id="deptCode" name="deptCode" readonly style="background-color: #e4ebf1;">
                        </div>
                        <div class="col-md-4">
                            <label for="deptName" class="form-label">Department Name</label>
                            <input type="text" class="form-control" id="deptName" name="deptName" required>
                        </div>
                        <div class="col-md-4">
                            <label for="deptShortName" class="form-label">Short Name</label>
                            <input type="text" class="form-control" id="deptShortName" name="deptShortName">
                        </div>
                    </div>

                    <!-- Row 2 -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="deptCompanyCode" class="form-label">Company Code</label>
                            <asp:DropDownList ID="deptCompanyCode" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label for="deptHeadModal" class="form-label">Department Head</label>
                            <asp:DropDownList ID="deptHeadModal" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Value="">-- Select Department Head --</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Row 3 -->
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <label for="deptStatus" class="form-label">Status</label>
                            <asp:DropDownList ID="deptStatus" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Inactive" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <label for="deptIsRosterableModal" class="form-label">Is Rosterable</label>
                            <asp:DropDownList ID="deptIsRosterableModal" runat="server" CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </form>
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" form="departmentForm" class="btn btn-primary" onclick="UpdateDept()">Save changes</button>
            </div>

        </div>
    </div>
</div>
