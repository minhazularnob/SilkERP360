<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCPersoTest.ascx.cs" Inherits="SilkERP360.UI.SCPM.QCPersoTest" %>

<script src="Scripts/QCPersoTest.js" type="text/javascript"></script>

<div id="dvQCMaster" style="width:100%; border:0px ridge black; margin:0 auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <td style="width:100%;">
                <div>
                    <h2>Personalization Test</h2>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width:100%; text-align:right;">
                <div>
                    <asp:Button ID="btnSave" runat="server" Width="100px" Text="Save" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <b>Module Vendor : </b>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlModuleVendor" runat="server" ClientIDMode="Static" style="width:30%;">
                    <asp:ListItem>-----Select Module Vendor</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b>Memory Size : </b>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlMemorySize" runat="server" ClientIDMode="Static" style="width:15%;">
                    <asp:ListItem>-----Select Memory Size</asp:ListItem>
                    <asp:ListItem>32K</asp:ListItem>
                    <asp:ListItem>64K</asp:ListItem>
                    <asp:ListItem>128K</asp:ListItem>
                    <asp:ListItem>256K</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b>Module Type : </b>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlModuleType" runat="server" ClientIDMode="Static" style="width:15%;">
                    <asp:ListItem>-----Select Module Type</asp:ListItem>
                    <asp:ListItem>Native</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <table id="tblPersoTest">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>