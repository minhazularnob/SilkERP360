<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Designation.ascx.cs" Inherits="SilkERP360.UI.HRIS.Designation" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/Designation.js" type="text/javascript"></script>

<div id="dDesignation" style="width:100%">
    <h1>DESIGNATION</h1>
    <p class="login button">
        <asp:Button ID="btnSave" ClientIDMode="Static" Text="Save" runat="server" CssClass="button" OnClientClick="Save(); return false;"  style="width:70px;" />
         <asp:Button ID="btnClose" ClientIDMode="Static" Text="Close" runat="server" CssClass="button" OnClientClick="return false;" style="width:70px;" />
    
    </p>
</div>
<br />
<br />
<center>
<div id="dDesignationn" style=" border-color: inherit; font-family:Verdana; font-size:12px;">
    <table id="tblDesination" style="width:100%; height:auto; table-layout:fixed">
        <tr>
        <td style="width:15%">
        <asp:Label ID="Label1" runat="server">Designation Name : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DesName" CssClass="input required" ClientIDMode="Static" runat="server" Placeholder="Designation Name" ReadOnly="false">
                </asp:TextBox>
            </td>
             <td style="width:15%">
             <asp:Label ID="Label2" runat="server">Short Name : </asp:Label>
             </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DesShortName" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Short Name" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
                <asp:Label ID="Label10" runat="server">Gross : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegGross" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Gross" ReadOnly="false">
                </asp:TextBox>
            </td>
            <td style="width:15%">
            <asp:Label ID="Label11" runat="server">Effective From : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegEffectiveFrom" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Effective From" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
        <asp:Label ID="Label3" runat="server">Basic : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegBasic" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Basic" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td style="width:15%">
        <asp:Label ID="Label5" runat="server">Medical : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegMedical" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Medical" ReadOnly="true">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
            <asp:Label ID="Label6" runat="server">Entertaiment : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegEntertaiment" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Entertaiment" ReadOnly="false">
                </asp:TextBox>
            </td>
            <td style="width:15%">
            <asp:Label ID="Label7" runat="server">Conveyence : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegConveyence" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Conveyence" ReadOnly="true">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
            <asp:Label ID="Label4" runat="server">House Rent : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_houseRent" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="House Rent" ReadOnly="true">
                </asp:TextBox>
            </td>
            <td style="width:15%">
                <asp:Label ID="Label8" runat="server">Phone Bill : </asp:Label>
            </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegPhoneBill" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Phone Bill" ReadOnly="false">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
        <td style="width:15%">
            <asp:Label ID="Label9" runat="server">Others : </asp:Label>
        </td>
            <td style="width:35%">
                <asp:TextBox ID="txt_DegOthers" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Others" ReadOnly="false">
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
           <table id="tblDesignationList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    </div>


</div>
</center>