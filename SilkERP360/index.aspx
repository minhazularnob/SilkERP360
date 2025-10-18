<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SilkERP360.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SilkERP 360</title>
    <link href="Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/master.css" rel="stylesheet" />
    <script src="Globals/jQuery/jquery-ui-1.10.3/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>
    <script src="Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.core.js" type="text/javascript"></script>
    <script src="Globals/Scripts/plug-ins/blockui-master/jquery.blockUI.js" type="text/javascript"></script>

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
    <script src="Globals/bootstrap-5.3.8-dist/js/bootstrap.min.js"></script>

    
   
    <link href="Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet" type="text/css" />
    <link href="Globals/bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />

    <script src="Globals/Scripts/SilkERP360/globals.js" type="text/javascript"></script>
    <script src="Globals/Scripts/SilkERP360/index.js" type="text/javascript"></script>
</head>
<body class="master_color_liener_gradient" style="min-height:100vh; margin:0;">
  <form runat="server" style="height:100vh; margin:0;">
    <div class="container-fluid h-100 p-0" >
      <div class="row g-0 h-100">
        <div class="col-md-6 d-none d-md-block p-0">
          <img src="Globals/Images/3d-render-secure-login-password-illustration.jpg" alt="Login Image" class="img-fluid h-100 w-100 object-fit-cover" />
        </div>

        <!-- Right Side: Forms -->
        <div class="col-md-6 d-flex flex-column justify-content-center bg-white align-items-center  p-5">

          <!-- Anchors for internal linking -->
          <a class="d-none" id="tologin"></a>
          <a class="d-none" id="toregister"></a>

          <!-- Login Form -->
          <div id="loginForm" class="w-75" >
            <h3 class="text-center text-primary mb-4" style="font-family: serif !important">Log In</h3>

            <div class="mb-3">
              <label for="txtUsername" class="form-label fs-5">Username</label>
              <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control form-control-lg" placeholder="Enter your username" ClientIDMode="Static" />
            </div>

            <div class="mb-4">
              <label for="txtPassword" class="form-label fs-5">Password</label>
              <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Enter your password" ClientIDMode="Static" />
            </div>

            <div class="d-grid mb-3">
              <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg btn-fade" style="height: 2rem; font-size: large"  Text="Sign In" ClientIDMode="Static" OnClientClick="Login();return false;" />
            </div>

            <div class="text-center">
              <a href="javascript:void(0);" class="text-decoration-none fs-5" style="font-family: serif !important" onclick="toggleForms('registerForm')">Forgot Password?</a>
            </div>
          </div>

          <!-- Reset Password Form -->
          <div id="registerForm" class="d-none w-75">
            <h3 class="text-center text-success mb-4" style="font-family: serif !important">Change Password</h3>

            <div class="mb-3">
              <label class="form-label fs-5">Username</label>
              <asp:TextBox ID="txtUserNameResetPassword" runat="server" CssClass="form-control form-control-lg" placeholder="Username" ClientIDMode="Static" />
            </div>

            <div class="mb-3">
              <label class="form-label fs-5">Current Password</label>
              <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control form-control-lg" placeholder="Current Password" TextMode="Password" ClientIDMode="Static" />
            </div>

            <div class="mb-3">
              <label class="form-label fs-5">New Password</label>
              <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control form-control-lg" placeholder="New Password" TextMode="Password" ClientIDMode="Static" />
            </div>

            <div class="mb-4">
              <label class="form-label fs-5">Reconfirm Password</label>
              <asp:TextBox ID="txtReconfirmPassword" runat="server" CssClass="form-control form-control-lg" placeholder="Reconfirm Password" TextMode="Password" ClientIDMode="Static" />
            </div>

            <div class="d-grid mb-3">
              <asp:Button ID="btnChangePasword" runat="server" CssClass="btn btn-success btn-lg btn-fade" style="height: 2rem;  font-size: large" Text="Update" ClientIDMode="Static" OnClientClick="ChangePassword();return false;" />
            </div>

            <div class="text-center">
              <a href="javascript:void(0);" class="text-decoration-none fs-5 btn_height1"  onclick="toggleForms('loginForm')">Back to Login</a>
            </div>
          </div>
        </div>
          
          <div class="position-absolute top-0 start-0 p-3">
              <img src="Globals/Images/Silkways_Group_logo.png" alt="SilkwaysGroupLogo.jpg" style="height: 90px;width:90px object-fit: contain;" />
          </div>

      </div>
    </div>
  </form>
</body>
</html>

<script type="text/javascript">
    function toggleForms(showId) {
        document.getElementById('loginForm').classList.add('d-none');
        document.getElementById('registerForm').classList.add('d-none');
        document.getElementById(showId).classList.remove('d-none');
    }
</script>