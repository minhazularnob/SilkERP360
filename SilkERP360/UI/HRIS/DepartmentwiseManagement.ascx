<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentwiseManagement.ascx.cs" Inherits="SilkERP360.UI.HRIS.DepartmentwiseManagement" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="Scripts/DepartmentwiseManagement.js" type="text/javascript"></script>
<style type="text/css">
        a.boxclose{
            float:right;
            width:26px;
            height:26px;
            background:transparent url(../../Globals/Images/cancel.png) repeat top left;
            cursor:pointer;
        }
        
        .sub_form
        {
            opacity: 0;
            display: none;
            position: absolute;
            width: 99%;
            height:1024px;
            top:-800px;
            z-index:101;
            

        }
</style>
<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {

            $("#dvSubForm").css("top", "-800px");
        });
                $("#dvNotification").html('');
    });
</script>
<div id="dvBody" class="ui_control_wrapper" style="Width:100%;height:auto; min-height:8096px; margin:0 auto; text-align:left;">
    <div id="cmd" style="width:100%;">
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" Width="40px" />--%>
       <h1>Departmentwise HRIS Management</h1>
        <%--<p class="login button"> 
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />&nbsp;
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>--%>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="40px" onclick="btnClose_Click" />--%>
    </div>
    <div style="height:10px;">
        <br />
    </div>
    
    <div id="dvDepartmentList" style="width:100%; height:auto; border:0px; border-style:ridge;">
        
        <div id="dvListedDepartments" style="width:100%; float:left; position:relative;">  <%--margin:0 auto;--%>
            <div id="dvSubForm" class="sub_form ui_control_wrapper" style="height:auto; min-height:1024px;" >
                <a class="boxclose" id="boxclose"></a>
                <h1 id="hdrSubForm">Important message</h1>
                <div id="dvSubFormContainer">
                    <br />
                </div>
            </div>
           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <%--<table id="tblDepartmentList" cellpadding="0px" cellspacing="0px" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>--%>
            <asp:Table ID="tblDepartmentList" runat="server" ClientIDMode="Static" CellPadding="0" CellSpacing="0" style="width:70%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
                <%--<asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Width="60%" style="text-align:center;">Department</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="35%" style="text-align:center;">Strength</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="5%" style="text-align:center;">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>--%>
            </asp:Table>
        </div>
    </div>
</div>