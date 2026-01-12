<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SilkERP360.UI.HRIS.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> Error Message</div>
    <div>
        <asp:TextBox ID="txtError" runat="server" TextMode="MultiLine"></asp:TextBox>
        </div>
    
    <div> Call Trace</div>
        <div><asp:TextBox ID="txtStTrace" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div> Thrown By</div>
        <div><asp:TextBox ID="txtTerS" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    </form>
</body>
</html>
