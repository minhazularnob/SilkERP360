<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonnelwiseAdministration.ascx.cs" Inherits="SilkERP360.UI.HRIS.PersonnelwiseAdministration" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="Scripts/PersonnelwiseAdministration.js" type="text/javascript"></script>

<div id="dvBody" class="ui_control_wrapper" style="Width:99%;height:1024px; margin:0 auto;">
    <div id="cmd" style="width:99%;">
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" Width="40px" />--%>
       <h1>Personnelwise HRIS Administration</h1>
        <%--<p class="login button"> 
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />&nbsp;
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>--%>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="40px" onclick="btnClose_Click" />--%>
    </div>
    <div id="dvRoosterForm" style="width:99%;">
        <table class="ip_cntrl_cntnr1" style="width:98%; table-layout:fixed;margin:0 auto;">
            <tr>
                <td style="width:50%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">Select The Department For Which the Rooster is to be created</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div style="height:10px;">
        <br />
    </div>

    <div id="dvEmployeeList" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>
           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <table id="tblEmployeeList" cellpadding="0px" cellspacing="0px" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>
    </div>
</div>