<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuPermission.ascx.cs" Inherits="SilkERP360.UI.HRIS.MenuPermission" %>


<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/MenuPermission.js" type="text/javascript"></script>

<div class="container-fluid my-4">

    <h1 class="mb-4 fontSerif">Menu Permission</h1>

    <div class="card shadow-sm mb-4">
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-2">
                    <asp:Label ID="Label3" runat="server" CssClass="form-label">User ID :</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddl_MenuUserID" runat="server" ClientIDMode="Static" CssClass="form-control select2">
                        <asp:ListItem Value="0">------ Select Menu User ID ------</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="Label7" runat="server" CssClass="form-label">Module Name :</asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddl_ModuleName" runat="server" CssClass="form-control select2" ClientIDMode="Static">
                        <asp:ListItem Value="0"> ------ Select Module Name  ------</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
    </div>

    <!-- Table Section -->
    <div class="card shadow-sm">
        <div class="card-body">
            <h5 class="card-title fontSerif">Menu Permission List</h5>
            <div class="table-responsive" style="width: 20%; margin: 0 auto;">
                <button id="toggleMenuId" type="button" title="Click to toggle menu"><i class="fas fa-plus"></i></button>
                <label class="checkbox-label">
                    <input type="checkbox" id="saveAllMenusCheckBoxId" class="checkbox-input" checked="checked">
                    Save Together
                </label>
                <button type="button" id="saveBtnId" class="btn btn-primary">Save</button>
                <table id="tblMenuPermissionList">
                    <!-- Table rows will be dynamically loaded -->
                </table>
            </div>
        </div>
    </div>
</div>



