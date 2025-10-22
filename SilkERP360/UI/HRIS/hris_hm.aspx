<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hris_hm.aspx.cs" Inherits="SilkERP360.UI.HRIS.hris_hm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SilkERP360-Human Resource Management System v.1.0-HRIS</title>
   <%--<%--<script src="../../Globals/jQuery/jquery-1.9.0-min/jquery-1.9.0.min.js" type="text/javascript"></script>
    <link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/ip_frm_ctrl.css" rel="stylesheet" type="text/css" />--%>
   <%-- <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />--%>
    
    <link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .alignRight
        {
            text-align:right;
        }
    </style>
   <%-- <link href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/jquery-1.9.1.js" type="text/javascript"></script>
    
    
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.core.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/i18n/jquery-ui-i18n.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.position.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.menu.js" type="text/javascript"></script>
--%>

<script src="../../Globals/jQuery/jquery-1.9.1.min.js" type="text/javascript"></script>
    <%--<script src="../../Globals/jQuery/jquery-1.8.3.min.js" type="text/javascript"></script>--%>
    <%--<script src="../../Globals/jQuery/jquery-1.7.2.min.js" type="text/javascript"></script>--%>
    <%--<script src="../../Globals/jQuery/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>--%>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/external/globalize.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.core.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.widget.min.js" type="text/javascript"></script>

    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.spinner.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.tabs.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.button.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.draggable.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.droppable.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.position.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.resizable.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.dialog.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.menu.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.datepicker.min.js" type="text/javascript"></script>
    <%--<script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.tooltip.min.js" type="text/javascript"></script>--%>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.effect-fade.js" type="text/javascript"></script>

    <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>
    

    <script src="../../Globals/Scripts/plug-ins/blockui-master/jquery.blockUI.js" type="text/javascript"></script>
       
    <%--<script src="Scripts/plug-ins/tooltip/js/jquery.betterTooltip.js" type="text/javascript"></script>--%>
 
    <%-- <link href="../../Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="../../Globals/Styles/ip_frm_ctrl.css" rel="stylesheet" type="text/css" />--%>
   
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/jquery.noty.js" type="text/javascript"></script>
    
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/bottom.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomCenter.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomLeft.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/bottomRight.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/center.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/centerLeft.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/centerRight.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/inline.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/top.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/topCenter.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/topLeft.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/layouts/topRight.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/notification/js/noty/themes/default.js" type="text/javascript"></script>

    <%--<script src="Globals/jQuery/jquery.blockUI.js" type="text/javascript"></script>--%>
    <!--****************************************************************************************************************************-->
    <!--confirm box plug-in-->
   <%-- <link rel="stylesheet" type="text/css" href="../../Globals/Scripts/plug-ins/confirm-box/css/styles.css" />
    <script src="../../Globals/Scripts/plug-ins/confirm-box/jquery.confirm/jquery.confirm.js" type="text/javascript"></script>--%>
<%--    <script src="../../Globals/Scripts/plug-ins/confirm-box/js/script.js" type="text/javascript"></script>--%>
    <!--****************************************************************************************************************************-->
    <%--<link href="Globals/LoginForm/style.css" rel="stylesheet" type="text/css" />--%>
    <%--<script src="../../Globals/LoginForm/modernizr.custom.63321.js" type="text/javascript"></script>--%>
    <script src="../../Globals/Scripts/SilkERP360/globals.js" type="text/javascript"></script>
    
    <%--<script src="../../Globals/Scripts/plug-ins/auto-logout/CheckBrowserClose.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/auto-logout/jquery.idle-timer.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/auto-logout/timeout-dialog.js" type="text/javascript"></script>
    <link href="../../Globals/Scripts/plug-ins/auto-logout/timeout-dialog.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/plug-ins/auto-logout/auto-logout.js" type="text/javascript"></script>--%>




    <link href="../../Globals/Scripts/menus/Horizontal/menu.css" rel="stylesheet" type="text/css" />
    <%--<script src="../../Globals/Scripts/plug-ins/auto-logout/auto-logout.js" type="text/javascript"></script>--%>
    <script src="../../Globals/Scripts/SilkERP360/HRIS/HRISMenuFunctions.js" type="text/javascript"></script>
   <script src="../../Globals/Scripts/SilkERP360/HRIS/hris_hm.js" type="text/javascript"></script>
  
   <%-- <script src="../../Globals/Scripts/plug-ins/auto-logout_2/jquery.idletimer.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/auto-logout_2/jquery.idletimeout.js" type="text/javascript"></script>
    <link href="../../Globals/Scripts/plug-ins/auto-logout_2/examples.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/plug-ins/auto-logout_2/auto-logout-setup.js" type="text/javascript"></script>--%>
    
<%-- ***************************************Conmmon js method *****************************************--%>
    <link href="../../Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/Common.js" type="text/javascript"></script>
    <script src="../../Globals/bootstrap-5.3.8-dist/js/bootstrap.min.js"></script>

    <!--****************************************************************************************************************************-->
    <%--//Menu--%>
    <link rel="stylesheet" type="text/css" href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" />
    <%--<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../Globals/jQuery/jquery-ui-1.10.3/demos/demos.css" rel="stylesheet" type="text/css" />
    <!--****************************************************************************************************************************-->
    <style type="text/css" title="currentStyle">
            @import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/css/demo_table_jui.css";
            <%--@import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/css/jquery.dataTables.css";--%>
          
            <%--@import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/css/demo_table.css";--%>
            
           	<%--@import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/css/demo_page.css";--%>
			<%--@import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/extras/TableTools/media/css/TableTools.css";--%>
			
		</style>
        <%--<script src="../../Globals/Scripts/plug-ins/overlay/jquery.tools.min.js" type="text/javascript"></script>--%>
    <%--<script src="../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/js/jquery.js" type="text/javascript"></script>--%>
    <script src="../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/js/jquery.dataTables.js" type="text/javascript"></script>
    <link href="../../Globals/Styles/scpm.cs" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/ImageStyles.css" rel="stylesheet" type="text/css" />
  
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">--%>

    <link href="../../Globals/bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Globals/Styles/master.css" rel="stylesheet" />
    
    <link href="../../Globals/Select2/select2_min_4_1_0.css" rel="stylesheet" />
    <script src="../../Globals/Select2/select2_min_4.1.0.js"></script>
    <link href="../../Globals/fontawesome-free-7.1.0-web/css/all.min.css" rel="stylesheet" />
    <%--<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />--%>
</head>
<body>
    <form id="form1" runat="server">
        <%--*************************************************************************************************************************************--%>
        <%--<div id="header" class="module_title">
        <header>
            <div id="dvHead">
                <h1>Silkways Solutions Ltd<span> SilkERP360</span></h1>
            </div>
        </header>
    </div>--%>
        <asp:HiddenField ID="txtSignedInEmployeeCode" runat="server" Value='' ClientIDMode="Static" />
        <asp:HiddenField ID="txtSecurityToken" runat="server" Value='' ClientIDMode="Static" />
        <asp:HiddenField ID="companyIdHidden" runat="server" Value='' ClientIDMode="Static" />

        <%--*************************************************************************************************************************************--%>
        <div class="container-fluid" style="font-family: serif; height: 800px; padding: 0;">
            <div class="row">
                <div class="col-auto p-0 silkways_solid_Blue" id="sidebar" onmouseover="expandSidebar()" onmouseout="collapseSidebar()">
                    <div id="dvHMenu" class="pt-3">
                    </div>

                    <img src="/Globals/Images/sidebar.png" id="sideBarIcon" class="sidebar-image" />
                </div>

                <!-- Main Content Area -->
                <div class="col ps-3">
                    <!-- Optional Top Menu -->
                    <div class="bg-white border-bottom mb-2">
                        <!-- Leave this empty or use for a horizontal top nav -->
                    </div>

                    <!-- Header Info Block -->
                    <div class="bg-light p-3 mb-3 rounded shadow-sm">
                        <div class="row">
                            <div class="col-md-1">
                                <img id="companyLogoForEmployee" src="" alt="logo" style="height: 70px; width: 90px object-fit: contain;" />
                            </div>

                            <div class="col-md-6 ps-5">
                                <span class="silkerp_logo silkways_solid_Blue_font fs-4 fontSerif fontBold">Silkways Enterprise Resource Planner (SilkERP360)</span><br />
                                <span class="module_title silkways_solid_Orange_font fs-4 fontSerif fontBold">Human Resource Information Management System v.1.0</span>
                            </div>

                            <div class="col-md-2 fontSerif silkways_solid_Blue_font" style="font-size: smaller;">
                                <p class="mb-0 ">
                                    <strong>Name:</strong>
                                    <asp:Label ID="txtName" runat="server" CssClass="fw-bold" ClientIDMode="Static" />
                                </p>
                                <p class="mb-0 ">
                                    <strong>Username:</strong>
                                    <asp:Label ID="txtUserName" runat="server" CssClass="fw-bold" ClientIDMode="Static" />
                                </p>
                                <p class="mb-0 ">
                                    <strong>Designation:</strong>
                                    <asp:Label ID="txtDesignation" runat="server" CssClass="fw-bold" ClientIDMode="Static" />
                                </p>
                                <!-- IP and Acc Lvl in one line -->
                                <div class="d-flex mb-0 fontSerif">
                                    <p class="mb-0 me-3">
                                        <strong>IP:</strong>
                                        <asp:Label ID="txtIP" runat="server" CssClass="fw-bold" ClientIDMode="Static" />
                                    </p>
                                    <p class="mb-0">
                                        <strong>Acc Lvl:</strong>
                                        <asp:Label ID="txtAccessLevel" runat="server" CssClass="fw-bold" ClientIDMode="Static" />
                                    </p>
                                </div>
                            </div>

                            <div class="col-md-2 d-flex align-items-center" style="font-family: 'Georgia', serif;">
                                <!-- Image on the left -->
                                <asp:Image ID="imgEmpImage" runat="server" Width="100px" Height="100px" CssClass="img-thumbnail border-0 me-2" />

                                <!-- Date stacked vertically to the right -->
                                <div class="d-flex flex-column justify-content-center small fontSerif silkways_solid_Orange_font" style="line-height: 1.3">
                                    <asp:Label ID="lblDay" runat="server" CssClass="day fw-bold" ClientIDMode="Static" />
                                    <asp:Label ID="lblMonth" runat="server" CssClass="month fw-bold" ClientIDMode="Static" />
                                    <asp:Label ID="lblYear" runat="server" CssClass="year fw-bold" ClientIDMode="Static" />
                                </div>
                            </div>

                            <div id="companyLogoDiv" class="col-md-1" style="padding: 0px; display: none">
                                <img id="comapanyLogo" src="../../Globals/Images/Silkways_Solutions_Logo.png" alt="logo"  />
                            </div>
                        </div>
                        <hr />

                        <div class="row align-items-center height_rem2" style="margin-top: -7px">
                            <div class="col-md-3 d-flex align-items-center" style="margin-top: -17px;">
                                <label for="ddlCompany" class="me-2 mb-0">Company:</label>
                                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-select" ClientIDMode="Static">
                                    <asp:ListItem Text="-----Select Company-----" Value="" />
                                </asp:DropDownList>
                            </div>

                            <div id="dvMessageBoard" style="display: none; min-height: 30px;" class=" col-md-8 alert alert-info text-center master_color_liener_gradient p-2 fontSerif">

                                <span id="spnMessage" style="font-size: 14px; font-weight: bold; color: white;">Silk ERP Message Board
                                </span>
                            </div>

                            <div class="col-md-1 text-start">
                                <a id="lnkRefresh" href="#" onclick="Refresh(event); return false;">
                                    <img src="../../Globals/Images/icons8-refresh-128.png" alt="Refresh" style="height: 50px; margin-top: -17px" />
                                </a>
                            </div>
                        </div>
                        <hr />
                    </div>

                    <!-- Main UI Content Area -->
                    <div class="div_bg_gradient_gray p-3 border rounded" style="min-height: 500px; border-left: 2px #a9a9a9 outset;">
                        <div class="ui_control_wrapper1" style="text-align: left;">
                            <div id="dvUIContainer" style="visibility: hidden; height: 100%; padding: 5px;">
                                <!-- Your dynamic UI content goes here -->
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <footer class="footer_master_color_liener_gradient text-white py-3 border-top fontSerif" style="font-size: 0.95rem; opacity: 0.95;">
                <div class="container">
                    <div class="row">
                        <!-- Company Info -->
                        <div class="col-md-6 mb-2">
                            <h5 id="footerCompanyName" class="mb-1">Silkways</h5>
                            <p id="footerCompanyAddress" class="mb-0">
                                Corporate Office: Plot No. SW(I) 4, 25 Gulshan Avenue 1212, Bangladesh
                            </p>
                        </div>
      
                        <!-- Contact Info -->
                        <div class="col-md-6 mb-2">
                            <h5 class="mb-1">Contact</h5>
                            <p class="mb-1">
                                <strong>Mobile:</strong> <span id="footerCompanyMobile">+88 02 9888211</span>
                            </p>
                            <p class="mb-0">
                                <strong>Email:</strong> <span id="footerCompanyEmail">info@silkways.net</span>
                            </p>
                        </div>
                    </div>

                    <!-- Copyright -->
                    <div class="text-center mt-3 small" style="border-top: 1px solid rgba(255,255,255,0.2); padding-top: 10px;">
                        © 2025 Silkways. All rights reserved.
                    </div>
                </div>
            </footer>
        </div>

    </form>
</body>

<!-- Footer -->
<!-- End Footer -->
</html>


<script type="text/javascript">
     window.addEventListener("DOMContentLoaded", function () {
         const topLevelMenus = document.querySelectorAll("#dvHMenu > ul > li > a");
         const subMenuLinks = document.querySelectorAll("#dvHMenu ul li ul li a");

         // Apply styles to top-level menu items
         topLevelMenus.forEach(menu => {
             menu.classList.add("fontSerif");
             const name = menu.textContent.trim();
             if (name == "LOGOUT") {
                 menu.classList.add("logout-menu");
             }
         });
         // Apply styles to sub-menu items
         subMenuLinks.forEach(subMenu => {
             subMenu.classList.add("fontSerif");
         });
     });
   
    $(document).ready(function () {
        $('#ddlCompany').on('change', changeCompanyLogo);
    });

    initializeSelect2('ddlCompany', '------ Select Company ------', 'resolve');

    function initializeSelect2(dropdownId, placeholderText, width) {
        $('#' + dropdownId).select2({
            placeholder: placeholderText,
            allowClear: true,
            width: width
        });
    }
</script>