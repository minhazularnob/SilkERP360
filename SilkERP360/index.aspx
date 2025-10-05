<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SilkERP360.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SilkERP 360</title>
    <link href="Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Globals/jQuery/jquery-ui-1.10.3/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>
    <script src="Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/blockui-master/jquery.blockUI.js" type="text/javascript"></script>

    <%--<link href="Globals/Styles/Common1.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="Scripts/plug-ins/tooltip/js/jquery.betterTooltip.js" type="text/javascript"></script>--%>
 
    
    <%--<link href="Globals/Styles/ip_frm_ctrl.css" rel="stylesheet" type="text/css" />--%>

    <script src="Globals/Scripts/plug-ins/notification/js/noty/jquery.noty.js" type="text/javascript"></script>
    
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/bottom.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomCenter.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomLeft.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomRight.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/center.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/centerLeft.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/centerRight.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/inline.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/top.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/topCenter.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/topLeft.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/layouts/topRight.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/notification/js/noty/themes/default.js" type="text/javascript"></script>
    <%--<script src="Globals/jQuery/jquery.blockUI.js" type="text/javascript"></script>--%>

    <%--<link href="Globals/LoginForm/style.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="Globals/LoginForm/modernizr.custom.63321.js" type="text/javascript"></script>--%>
    
   
    <link href="Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet" type="text/css" />

    <script src="Globals/Scripts/SilkERP360/globals.js" type="text/javascript"></script>
    <script src="Globals/Scripts/SilkERP360/index.js" type="text/javascript"></script>
    <%--<link href="Globals/Scripts/plug-ins/nailthumb/jquery.nailthumb.1.1.min.css" rel="stylesheet"
        type="text/css" />
    <script src="Globals/Scripts/plug-ins/nailthumb/jquery.nailthumb.1.1.min.js" type="text/javascript"></script>--%>
    <link href="Globals/Styles/ImageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
    <%--<div id="container_demo" class="container_demo" style="background-color:Gray;">--%>
        
        <table style="width:100%;">
            <tr style="width:100%;">
                <td style="line-height:150px;">
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <%--<div id="container_demo" style="background-color:Gray;">--%>
                    <a class="hiddenanchor" id="toregister"></a>
                    <a class="hiddenanchor" id="tologin"></a>
                    <div id="wrapper" style="width: 25%;">
                        <div id="login" class="animate form" >
                            <form action="" autocomplete="on"> 
                                <table style="width:100%;">
                                    <tr style="width:100%;">
                                        <td style="width:100%;">
                                            <h1>Log in</h1> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:100%;">
                                            <label for="username" class="uname" >Username</label>
                                            <asp:TextBox ID="txtUsername" ClientIDMode="Static" CssClass="input-required" placeholder="Username" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:100%;">
                                            <label for="password" class="youpasswd">Password</label>
                                            <asp:TextBox ID="txtPassword" ClientIDMode="Static" CssClass="input-required" TextMode="Password" placeholder="Password" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:100%;">
                                           <p class="login button"> 
                                                <asp:Button ID="btnLogin" runat="server" CssClass="button" Text="Sign In" ClientIDMode="Static" OnClientClick="Login();return false;" />
                                                <%--<input type="submit" value="Login" class="button" /> --%>
				                            </p>
                                        </td>
                                    </tr>
                                 </table>
                                <span class="change_link"  style="padding-top:10px;">  
					                <a href="#toregister" class="to_register" style="padding-right:20px;"> Reset Password </a>
				                </span>
                            </form>
                        </div>

                        <div id="register" class="animate form" style="text-align:center">
                            <form action="" autocomplete="on"> 
                                 <table style="width:100%;">
                                    <tr style="width:100%;">
                                        <td>
                                            <h1>Change Password</h1> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label for="username" class="uname" >Username</label>
                                            <asp:TextBox ID="txtUserNameResetPassword" ClientIDMode="Static" CssClass="input-required c_p_field" placeholder="Username" runat="server"></asp:TextBox>
                                           <%-- <input id="Text1" name="username" required="required" type="text" placeholder="Username"/>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <label for="username" class="uname" >Current Password</label>
                                            <asp:TextBox ID="txtCurrentPassword" ClientIDMode="Static" CssClass="input-required c_p_field" placeholder="Current Password" runat="server" TextMode="Password"></asp:TextBox>
                                           <%-- <input id="Text1" name="username" required="required" type="text" placeholder="Username"/>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <label for="username" class="uname" >New Password</label>
                                            <asp:TextBox ID="txtNewPassword" ClientIDMode="Static" CssClass="input-required c_p_field" placeholder="New Password" runat="server" TextMode="Password"></asp:TextBox>
                                           <%-- <input id="Text1" name="username" required="required" type="text" placeholder="Username"/>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                        </td>
                                    </tr>
                                     <tr>
                                        <td>
                                            <label for="username" class="uname" >Reconfirm Password</label>
                                            <asp:TextBox ID="txtReconfirmPassword" ClientIDMode="Static" CssClass="input-required c_p_field" placeholder="Reconfirm Password" runat="server" TextMode="Password"></asp:TextBox>
                                           <%-- <input id="Text1" name="username" required="required" type="text" placeholder="Username"/>--%>
                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td>
                                           <p class="login button"> 
                                                <p class="login button"> 
                                                <asp:Button ID="btnChangePasword" runat="server" CssClass="button" Text="Update" ClientIDMode="Static" OnClientClick="ChangePassword();return false;" />
                                                <%--<input type="submit" value="Login" class="button" /> --%>
				                            </p>
				                            </p>
                                        </td>
                                    </tr>
                                 </table>
                                <span class="change_link"  style="padding-top:10px;">  
					                <a href="#tologin" class="to_register" style="padding-right:20px;"> Remembered Password?Log In! </a>
				                </span>
                            </form>
                        </div>
		            </div>	
                <%--</div>--%>
                </td>
            </tr>
        </table>
	    </form>
   
</body>
</html>
