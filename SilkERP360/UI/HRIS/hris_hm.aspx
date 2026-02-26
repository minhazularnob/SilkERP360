<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hris_hm.aspx.cs" Inherits="SilkERP360.UI.HRIS.hris_hm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SilkERP360-Human Resource Management System v.1.0-HRIS</title>
    <link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .alignRight
        {
            text-align:right;
        }
    </style>

    <script src="../../Globals/jQuery/jquery-1.9.1.min.js" type="text/javascript"></script>
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
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.effect-fade.js" type="text/javascript"></script>

    

    <script src="../../Globals/Scripts/plug-ins/blockui-master/jquery.blockUI.js" type="text/javascript"></script>
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
   
    <script src="../../Globals/Scripts/SilkERP360/globals.js" type="text/javascript"></script>
    
    <script src="../../Globals/Scripts/plug-ins/auto-logout/jquery.idle-timer.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/auto-logout/timeout-dialog.js" type="text/javascript"></script>
    <link href="../../Globals/Scripts/plug-ins/auto-logout/timeout-dialog.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/plug-ins/auto-logout/auto-logout.js" type="text/javascript"></script>




    <link href="../../Globals/Scripts/menus/Horizontal/menu.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/SilkERP360/HRIS/HRISMenuFunctions.js" type="text/javascript"></script>
   <script src="../../Globals/Scripts/SilkERP360/HRIS/hris_hm.js" type="text/javascript"></script>
    
<%-- ***************************************Conmmon js method *****************************************--%>
    <link href="../../Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/Common.js" type="text/javascript"></script>
    <script src="../../Globals/bootstrap-5.3.8-dist/js/bootstrap.min.js"></script>

    <!--****************************************************************************************************************************-->
    <%--//Menu--%>
   
    <%--<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../Globals/jQuery/jquery-ui-1.10.3/demos/demos.css" rel="stylesheet" type="text/css" />
    <!--****************************************************************************************************************************-->
    <style type="text/css" title="currentStyle">
            @import "../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/css/demo_table_jui.css";
			
		</style>
    <script src="../../Globals/Scripts/plug-ins/DataTables-1.9.4/media/js/jquery.dataTables.js" type="text/javascript"></script>
    <link href="../../Globals/Styles/scpm.cs" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/ImageStyles.css" rel="stylesheet" type="text/css" />
  

    <link href="../../Globals/bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Globals/Styles/master.css" rel="stylesheet" />
    
    <link href="../../Globals/Select2/select2_min_4_1_0.css" rel="stylesheet" />
    <script src="../../Globals/Select2/select2_min_4.1.0.js" type="text/javascript"></script>
    <link href="../../Globals/fontawesome-free-7.1.0-web/css/all.min.css" rel="stylesheet" />
     <script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>

 <link rel="stylesheet" type="text/css" href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="txtSignedInEmployeeCode" runat="server" Value='' ClientIDMode="Static" />
        <asp:HiddenField ID="txtSecurityToken" runat="server" Value='' ClientIDMode="Static" />
        <asp:HiddenField ID="companyIdHidden" runat="server" Value='' ClientIDMode="Static" />

        <%--*************************************************************************************************************************************--%>
        <div class="container-fluid" style="font-family: serif; height: 800px; padding: 0;">
            <div class="row">
                <div class="col-auto p-0 silkways_solid_Blue" id="sidebar">
                    <img src="/Globals/Images/sidebar.png" id="sideBarIcon" style="margin-top:5%; cursor:pointer;" class="sidebar-image" onclick="expandSidebar()" />
    
                    <style>
                        .sidebar-header {
                            display: flex;
                            justify-content: flex-end;
                            padding: 8px;
                        }

                        .close-btn {
                            width: 22px;
                            height: 22px;
                            display: flex;
                            align-items: center;
                            justify-content: center;
                            font-size: 13px;
                            color: #666;
                            background: #f2f2f2;
                            border-radius: 50%;
                            cursor: pointer;
                            transition: all 0.2s ease;
                        }

                            .close-btn:hover {
                                background: #ff4d4d;
                                color: #fff;
                                transform: rotate(90deg);
                            }
                    </style>

                    <div class="sidebar-header">
                        <i class="fa-solid fa-xmark close-btn" onclick="collapseSidebar()"></i>
                    </div>
                    <div id="dvHMenu" class="">
                    </div>
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
                        <div class="row align-items-center g-1 compact-bar">

                            <!-- Company -->
                            <div class="col-md-3 align-items-center">
                                <asp:DropDownList
                                    ID="ddlCompany"
                                    runat="server"
                                    CssClass="form-select form-select-sm"
                                    onchange="changeCompanyLogo();"
                                    ClientIDMode="Static">
                                    <asp:ListItem />
                                </asp:DropDownList>
                            </div>

                            <!-- Message -->
                            <div id="dvMessageBoard"
                                class="col-md-7 alert alert-info text-center master_color_liener_gradient py-1 px-2 mb-0 d-flex align-items-center justify-content-center">

                                <span id="spnMessage" class="fw-bold text-white small text-truncate">Silk ERP Message Board
                                </span>
                            </div>

                            <!-- Refresh -->
                            <div class="col-md-1 text-center text-md-start">
                                <a id="lnkRefresh" href="#" onclick="Refresh(event); return false;">
                                    <img src="../../Globals/Images/icons8-refresh-128.png"
                                        alt="Refresh"
                                        style="height: 50px;" />
                                </a>
                            </div>
                            <div class="col-md-1 text-center text-md-start">
                                <!-- Notification Button -->
                                <button type="button" class="notification-btn" data-bs-target="#notificationModal"  onclick="loadNotifications()">
                                    <i class="fa-solid fa-bell"></i>
                                    <span class="" id="notificationCount">0
                                    </span>
                                    <!-- unread count -->
                                </button>
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

<footer class="footer_master_color_liener_gradient text-white fontSerif"
        style="padding:6px 10px; font-size:11px; line-height:1.3; border-top:1px solid rgba(255,255,255,0.2);">

    <div class="container" style="display:flex; flex-wrap:wrap; justify-content:space-between; align-items:flex-start; max-width:1200px; margin:0 auto;">

        <!-- Factory Info (Left) -->
        <div style="flex:1 1 45%; min-width:200px; padding:2px 5px;">
            <strong style="font-size:12px;">Factory</strong><br>
            158/C, Tejgaon Industrial Area, Dhaka – 1208, Bangladesh<br>
            Tel: <a href="tel:+8802222288211" style="color:#fff; text-decoration:underline;">+8802 222288211-17</a> | 
            <a href="mailto:info.silkcard@silkways.net" style="color:#fff; text-decoration:underline;">info.silkcard@silkways.net</a>
        </div>

        <!-- Corporate Office (Center) -->
        <div style="flex:1 1 45%; min-width:200px; padding:2px 5px; text-align:center;">
            <strong style="font-size:12px;">Corporate Office</strong><br>
            Plot No. SW (I) 4, 25 Gulshan Avenue, Gulshan-1, Dhaka-1212<br>
            Tel: <a href="tel:+8802222288211" style="color:#fff; text-decoration:underline;">+8802 222288211-17</a> | 
            <a href="mailto:info.silkcard@silkways.net" style="color:#fff; text-decoration:underline;">info.silkcard@silkways.net</a>
        </div>

    </div>

    <div style="text-align:center; font-size:10px; margin-top:4px;">
        © 2026 Silkways. All rights reserved.
    </div>

</footer>     </div>

    </form>


    <div class="modal fade" id="notificationModal" tabindex="-1" aria-labelledby="notificationModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="notificationModalLabel">Notifications</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <table id="notificationTable" class="table custom-table fontSerif w-100""></table>
            </div>

            <div class="modal-footer">
                <%--<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="submit" form="departmentForm" class="btn btn-primary" onclick="UpdateDept()">Save changes</button>--%>
            </div>

        </div>
    </div>
</div>


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

    initializeSelect2('ddlCompany', "Select Company" , 'resolve');

    function initializeSelect2(dropdownId, placeholderText, width) {
        $('#' + dropdownId).select2({
            placeholder: placeholderText,
            allowClear: true,
            width: width
        });
    }

        GBL_NOTIFICATION_LIST_TABLE = $('#notificationTable').dataTable({
            "bJQueryUI": false,
            "bFilter": true,
            "bPaginate": true,
            "bLengthChange": true,
            "bSearch": true,
            "oLanguage": {
                "sEmptyTable": "No Notification Data Available",
                "sZeroRecords": "No Notification Data Found For Your Specified Criteria"
            },
            "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
            },
            "aoColumns": [
                { "mData": "SL", "sTitle": "Sl.", "sClass": "alignCenter", "bVisible": true },
                { "mData": "EmployeeID", "sTitle": "EmployeeID", "sClass": "alignCenter" },
                { "mData": "EmployeeName", "sTitle": "EmployeeName", "sClass": "alignCenter" },
                { "mData": "JoiningDate", "sTitle": "JoiningDate", "sClass": "alignCenter" },
                { "mData": "ConfirmationDate", "sTitle": "ConfirmationDate", "sClass": "alignCenter" }
            ]
        });
</script>