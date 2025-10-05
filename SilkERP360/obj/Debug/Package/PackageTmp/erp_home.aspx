<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="erp_home.aspx.cs" Inherits="SilkERP360.erp_home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
    </title>
    <script src="Globals/jQuery/jquery-1.9.0-min/jquery-1.9.0.min.js" type="text/javascript"></script>
    <link href="Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/ip_frm_ctrl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="dvBody" class="body" style="float:left; margin:0px auto; width:100%; height:750px; border:0px; border-style:solid;">
        <table id="tblBody" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%; border:0px; border-style:solid;">
            <tr>
                <td align="center" style="width:100%; height:5%;">
                    <!-- HORIZONTAL MENU-->
                    <div id="dvHMenu" style="border:0px; border-style:none;width:100%; height:100%; background-color:#ffffff;">
                        <ul id="h_nav">
	                        <li><a href="./HRIS/hris_hm.aspx">H.R.I.S</a>                          
                            </li>
                            <li><a href="#">S.J.M</a></li>
                            <li><a href="#">Accounts</a></li>
                            <li><a href="#">Inventory</a></li>
                            <li><a href="#">Reports</a></li>
	                    </ul>
                    </div>     
                </td>
            </tr>
            <tr>
                <td align="center" style="width:100%; height:auto; text-align:center; padding-bottom:10px;">
                    <div id="dvUserInfo"  class="div_bg_gradient_gray" style="width:100%; height:auto; text-align:left;">
                        
                        <img src="Globals/Images/hris_logo_v_2.png" />
                       <%-- <div id="Div2" class="ip_cntrl_cntnr" style="width:60%; height:auto; border:0px; border-style:solid; margin:0px auto;">
                            <table cellpadding="0px" cellspacing="3px" style="width:100%; height:auto">
                                <tr>
                                    <td colspan="4" style="width:100%;">
                                        INFO
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20%;">
                                        <label>Selected Company :</label>
                                    </td>
                                    <td colspan="3" style="width:30%;">
                                        <asp:DropDownList ID="ddlCompanyName" runat="server" Width="100%">
                                            <asp:ListItem>Silkways Card & Printing Ltd</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20%;">
                                        <label>User Name :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td style="width:20%;">
                                        <label>Employee Id :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtEmployeeId" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20%;">
                                        <label>Name :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td style="width:20%;">
                                        <label>Department :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtDepartmentName" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20%;">
                                        <label>Designation :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                    <td style="width:20%;">
                                        <label>Last Login :</label>
                                    </td>
                                    <td style="width:30%;">
                                        <asp:TextBox ID="txtLastLoginTime" runat="server" CssClass="txt_style1" ReadOnly="false"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>--%>
                    </div>
                </td>
            </tr>
            <tr style="width:100%;">
                <td align="center" style="width:100%; height:100%; text-align:center;padding-top:5px;">
                    <div id="Div1" class="div_bg_gradient_gray" style="width:100%; height:100%;">
                        <table id="Table1" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%;">
                            <tr>
                                <td align="center" style="width:25%; height:100%;background-color:White;">
                                    <!--BODY LEFT-->
                                    <div style="width:99.5%; height:100%; margin:0px auto; border-right:2px #a9a9a9 outset;margin:0px auto;">
                                        <table id="Table2" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%;">
                                            <tr style="width:100%">
                                                <td align="center" style="width:100%; height:15%; text-align:center;">
                                                    <!--ERP LOGO-->
                                                    <div class="div_bg_gradient_gray" style="width:100%; height:98%;border-bottom:2px #a9a9a9 outset;">
                                                        <!--<img src="Globals/Images/hris_logo-400_100.jpg" style="max-width:99%; max-height:100%;" />-->
                                                        <table cellpadding="0px" cellspacing="2px" style="width:100%; height:auto">
                                                            <tr style="100%;">
                                                                <td align="center" colspan="4" style="width:100%;">
                                                                    <img src="Globals/Images/SilkERP_Txt_Logo_v_4.png" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width:25%;">
                                                                    <label>User :</label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <asp:Label ID="txtUserNamea" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <label>Level :</label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <asp:Label ID="txtAccessLevel" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width:25%;">
                                                                    <label>IP :</label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <asp:Label ID="txtIP" runat="server"></asp:Label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <label>Last Login :</label>
                                                                </td>
                                                                <td style="width:25%;">
                                                                    <asp:Label ID="txtLastLogin" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                
                                                </td>
                                            </tr>
                                            <!--<tr>
                                                <td style="width:100%; height:5%;border:0px; border-style:solid;">
                                                    <!--SELECTED MODULE NAME AND CODE-->
                                                    <!--<div style="width:100%; height:100%;">
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>-->
                                            <tr>
                                                <td style="width:100%; height:85%;border:0px; border-style:solid;">
                                                    <!--MENU-->
                                                    <div style=" width:100%; height:100%;background-color:White;">
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </div>
                                </td>
                                <td align="center" style="width:75%; height:100%;background-color:white;">
                                    <!--BODY RIGHT-->
                                    <div style="width:100%; height:100%; margin:0px auto; border-left:2px #a9a9a9 outset;">
                                        <table  id="Table3" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%;">
                                            <tr style="width:100%;">
                                                <td align="center" style="width:100%; height:15%;text-align:center;">
                                                    <div  class="div_bg_gradient_gray" style="width:100%; height:98%;border-bottom:2px #a9a9a9 outset;">
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width:100%; height:85%;">
                                                    <div style="width:100%; height:100%; background-color:White;">
                                                        <br />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
