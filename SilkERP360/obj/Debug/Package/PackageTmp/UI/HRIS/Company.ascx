<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Company.ascx.cs" Inherits="SilkERP360.UI.HRIS.Company" %>

<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/Company.js" type="text/javascript"></script>

<div id="dvCompany" style="width:100%">
    <h1>COMPANY</h1>
    <p class="login button">
        <asp:Button ID="btnSave" ClientIDMode="Static" Text="Save" runat="server" CssClass="button" OnClientClick="Save(); return false;"  style="width:70px;" />
         <asp:Button ID="btnClose" ClientIDMode="Static" Text="Close" runat="server" CssClass="button" OnClientClick="return false;" style="width:70px;" />
    
    </p>
</div>
<br />
<br />

<div id="dCompany" style=" border-color: inherit; font-family:Verdana; font-size:12px;">
    <table id="tblCompany" style="width:100%; height:auto; table-layout:fixed">
        <tr>
        <td style="width:15%">
             <asp:Label ID="Label12" runat="server">Company Name : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompanyName" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Company Name" ReadOnly="false">
                </asp:TextBox>
            </td>
             <td style="width:15%">
             <asp:Label ID="Label2" runat="server">Short Name : </asp:Label>
             </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompShortName" CssClass="input required" ClientIDMode="Static" runat="server" Placeholder="Company Short Name" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
                <asp:Label ID="Label10" runat="server">Address : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompAddress" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Address" ReadOnly="false">
                </asp:TextBox>
            </td>
            <td style="width:15%">
            <asp:Label ID="Label11" runat="server">Phone No : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompPhoneNo" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Phone No" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
        <asp:Label ID="Label3" runat="server">Fax No : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompFaxNo" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Fax No" ReadOnly="false">
                </asp:TextBox>
            </td>
            <td style="width:15%">
        <asp:Label ID="Label5" runat="server">Email : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_Email" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Email" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
            <asp:Label ID="Label6" runat="server">Web Site : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_CompWebSite" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Web Site" ReadOnly="false">
                </asp:TextBox>
            </td>
            <td style="width:15%">
                &nbsp;</td>
            <td style="width:35%">
                &nbsp;</td>
        </tr>
       
    </table>

    <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblCompanyList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    </div>


</div>

