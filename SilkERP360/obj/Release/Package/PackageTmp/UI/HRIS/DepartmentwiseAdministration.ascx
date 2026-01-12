<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentwiseAdministration.ascx.cs" Inherits="SilkERP360.UI.HRIS.DepartmentwiseAdministration" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="Scripts/DepartmentwiseAdministration.js" type="text/javascript"></script>

<div id="dvBody" class="ui_control_wrapper" style="width:100%; height:auto; margin:0 auto; text-align:left;">
    <!-- Page Header -->
    <div id="cmd" style="width:100%; text-align:center; padding:10px 0; background-color:white;">
        <h1 style="font-family: serif !important;">DEPARTMENTWISE HRIS ADMINISTRATION</h1>
    </div>

    <!-- Scrollable Content Container -->
    <div id="dDeptAdminContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height:0;">
        <div class="container-fluid">

            <!-- Department List Section -->
            <div class="row mb-3">
                <div class="col-md-12">
                    <div id="dvDepartmentList" style="width:100%; position:relative;">

                        <!-- Department List Table -->
                        <div class="row mt-3">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <asp:Table ID="tblDepartmentList" runat="server" ClientIDMode="Static" CellPadding="0" CellSpacing="0" CssClass="table custom-table fontSerif w-100">
                                        <asp:TableHeaderRow Width="100%">
                                            <asp:TableHeaderCell Width="60%" style="text-align:center;">Department</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="35%">Strength</asp:TableHeaderCell>
                                            <asp:TableHeaderCell Width="5%">Action</asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                    </asp:Table>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>

        </div>
    </div>
</div>

