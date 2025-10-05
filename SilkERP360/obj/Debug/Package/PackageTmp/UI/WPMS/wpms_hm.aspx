<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wpms_hm.aspx.cs" Inherits="SilkERP360.UI.WPMS.wpms_hm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>SilkERP360-Wellpac Management System v.1.0-WPMS</title>

<link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />

   <script src="../../Globals/jQuery/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.core.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.widget.min.js" type="text/javascript"></script>
     <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.effect.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.effect-fade.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.tabs.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.button.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.slider.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.draggable.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.droppable.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.position.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.resizable.min.js" type="text/javascript"></script>
    
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.dialog.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.menu.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.datepicker.min.js" type="text/javascript"></script>
   
    <%--<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />--%>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.tooltip.js" type="text/javascript"></script>
    <%--<script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.dialog.js" type="text/javascript"></script>--%>

    <link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-development.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-development.js" type="text/javascript"></script>

    <script src="Scripts/Script.js" type="text/javascript"></script>


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
    <script src="Scripts/wpms_menu_functions.js" type="text/javascript"></script>
    <link href="../../Globals/Scripts/menus/Horizontal/menu.css" rel="stylesheet" type="text/css" />

    <script src="Scripts/wpms_hm.js" type="text/javascript"></script>

      
<%-- ***************************************Conmmon js method *****************************************--%>
    <link href="../../Globals/Styles/SilkERP_Theme_3/demo.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/SilkERP_Theme_3/animate-custom.css" rel="stylesheet"
        type="text/css" />
    <script src="../../Globals/Scripts/Common.js" type="text/javascript"></script>

    <!--****************************************************************************************************************************-->
    <%--//Menu--%>
    <link rel="stylesheet" type="text/css" href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" />
    <%--<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js" type="text/javascript"></script>--%>
    <link href="../../Globals/jQuery/jquery-ui-1.10.3/demos/demos.css" rel="stylesheet" type="text/css" />

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
    
    <link href="../../Globals/Styles/ImageStyles.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="txtSignedInEmployeeCode" runat="server" Value='' ClientIDMode="Static" />
        <asp:HiddenField ID="txtSecurityToken" runat="server" Value='' ClientIDMode="Static" /> <%--This Value will be set in page_load method of hris_hm.aspx--%>
    <div id="dvBody" class="body" style=" font-family:Verdana;  margin:0 auto; width:100%; height:800px; border:0px; border-style:solid;">
        <table id="Table4" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%; border:0px; border-style:solid; margin:0 auto;">
            <tr>
                <td align="center" style="width:100%; height:5%;">
                    <!-- HORIZONTAL MENU-->
                    <div id="dvHMenu" style="border:0px; border-style:none;width:100%; height:100%; background-color:#ffffff;">
                        <ul id='menu'>
                            <li class='current'>
                                <a href='#' onclick='Logout();return false;'>Logout</a>
                            </li>
                            <li>
                                <a href='#'>Configuration</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadBuyer()(); return false;'>Customer Registration</a>
                                        <a href='#' onclick='LoadRawMaterial();return false;'>Raw Material Prices</a>
                                        <a href='#' onclick='LoadItemConfiguration(); return false;'>Items Master</a>
                                        <a href='#' onclick='LoadPantoneConfiguration(); return false;'>Pantone Color Configuration</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#'>Quotation</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadQuotation();return false;'>New Quotation</a>
                                        <a href='#' onclick='LoadQuotation();return false;'>Edit Quotation</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#'>Purchase Order (P.O)</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadPurchaseOrder();return false;'>New Purchase Order (P.O)</a>
                                        <a href='#' onclick='LoadPurchaseOrder();return false;'>Edit Purchase Order (P.O)</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#'>Sales Contract</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadSalesContract();return false;'>New Sales Contract</a>
                                        <a href='#' onclick='LoadSalesContract();return false;'>Edit Sales Contract</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#'>Job Order</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadFactoryOrderSheet();return false;'>New Job Order</a>
                                        <a href='#' onclick='LoadFactoryOrderSheet();return false;'>Edit Job Order</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#'>Invoice and Packing List</a>
                                <ul>
                                    <li>
                                        <a href='#' onclick='LoadInvoice();return false;'>Invoice</a>
                                        <a href='#' onclick='LoadPackingList();return false;'>Packing List</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href='#' onclick='newTab();return false;'>Reports</a>
                                <ul>
                                    <li>
                                        
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>     
                </td>
            </tr>
            <tr>
                <td align="center" style="width:100%; height:auto; text-align:center; padding-bottom:5px;">
                    <div id="Div4"  class="div_bg_gradient_gray" style="width:100%; height:auto; text-align:center;">
                        <%--<img src="../../Globals/Images/hris_logo_v_1.png" />--%>
                        <div id="Div5" style="width:100%;" >
                            <table style="width:100%;">
                                <tr>
                                    <td style="width:67%;">
                                        <table style="width:100%;">
                                            <tr>
                                                <td>
                                                    <span class="silkerp_logo">Silkways Enterprise Resource Planner (SilkERP360)</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="module_title">Wellpac Management System v.1.0</span><br />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:20%; font-size:12px;">
                                        Name : <asp:Label ID="txtName" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label><br />
                                        Username : <asp:Label ID="txtUserName" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label><br />
                                        Designation : <asp:Label ID="txtDesignation" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label><br />
                                        IP : <asp:Label ID="txtIP" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label><br />
                                        Acc Lvl :<asp:Label ID="txtAccessLevel" runat="server" Font-Bold="true" ClientIDMode="Static"></asp:Label>            
                                    </td>
                                    <td style="width:5%; border:0px ridge black; text-align:right; padding-right:13px;">
                                        <asp:Image ID='imgEmpImage' runat="server" Width="80px" Height="80px" />
                                    </td>
                                    <td style="width:auto; border:0px solid black; text-align:right; padding-right:13px;">
                                        <div class="silkerp-date">
                                          <asp:Label ID="lblDay" runat="server" CssClass="day" ClientIDMode="Static"></asp:Label>
                                          <asp:Label ID="lblMonth" runat="server" CssClass="month" ClientIDMode="Static"></asp:Label>
                                          <asp:Label ID="lblYear" runat="server" CssClass="year" ClientIDMode="Static"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                                
                                <tr>
                                   <td colspan="1" style="text-align:left;">
                                        &nbsp;&nbsp;&nbsp;
                                        <label><b>1 Dollar = </b></label>
                                        <asp:TextBox ID="txtDollarBDT" runat="server" Text="77.30" Width="60px" ReadOnly="true" style="background-color:Yellow; text-align:center;"></asp:TextBox><label><b>BDT. | </b></label>
                                        <%--&nbsp;&nbsp;&nbsp;--%>
                                        <label><b>1 Pound = </b></label>
                                        <asp:TextBox ID="txtPoundBDT" runat="server"  Text="124.51"  Width="60px" ReadOnly="true" style="background-color:Yellow; text-align:center;"></asp:TextBox><label><b>BDT. | </b></label>
                                        <%--&nbsp;&nbsp;&nbsp;--%>
                                        <label><b>1 Euro = </b></label>
                                        <asp:TextBox ID="txtEuroBDT" runat="server"  Text="98.63"  Width="60px" ReadOnly="true" style="background-color:Yellow; text-align:center;"></asp:TextBox><label><b>BDT. | </b></label>
                                    </td>
                                    <td colspan="3" style="text-align:right;">
                                        

                                        <label for="name"><em class="required"></em>  <b>Operational Company :</b></label>
					                    <asp:DropDownList ID="ddlCompany" runat="server" Width="60%" ClientIDMode="Static">
                                            <asp:ListItem Value="110000000002">Wellpac Polymers Ltd</asp:ListItem>
                                        </asp:DropDownList>
                                                
                                        <%--<div id="dvMessageBoard" style=" width:30%; border:1px solid black;">
                                            &nbsp;
                                        </div>--%>
                                        
                                    </td>
                                </tr>
                                 <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                                <tr>
                                     <td colspan="4" style="text-align:center;">
                                         <div id="dvMessageBoard" style="display:none; min-height:20px; background-color:Green;">
                                            <span id="spnMessage" style=" font-size:14px; font-weight:bold; color:White;">
                                                Silk ERP Message Board
                                            </span>
                                        </div>
                                     </td>
                                </tr>
                               
                                <tr>
                                    <td colspan="4">
                                        <hr />
                                    </td>
                                </tr>
                            </table>
                            
                            
                            <%--<div id="mnuHorizontalContainer"  class="div_bg_gradient_gray1" style=" width:100%; margin:0 auto; z-index:10000000000000;">
                            </div>--%>
                            <%--<header>
                                <div id="dvHead">
                                    <h1>Silkways Solutions Ltd<span> SilkERP360</span></h1>
                                </div>
                            </header>--%>
                        </div>
                        <%--<div id="wrapper" style="float:right;">
                            <asp:DropDownList ID="ddlCompany" runat="server" Width="500px" Height="20px">
                              <asp:ListItem>-----Select Company</asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </div>
                </td>
            </tr>
            <tr style="width:100%;">
                <td align="center" style="width:100%; height:auto; text-align:center;padding-top:5px;">
                    <div id="Div6" class="div_bg_gradient_gray" style="width:100%; height:100%;">
                        <table id="Table5" cellpadding="0px" cellspacing="0px" style="width:100%;height:100%;">
                            <tr>
                                <td align="center" style="width:80%; height:auto;text-align:center;">
                                    <!--BODY RIGHT-->
                                    <div class="div_bg_gradient_gray" style=" text-align:center; width:100%; height:100%; margin:0px auto; border-left:2px #a9a9a9 outset; z-index:0;">
                                        <table  id="Table6" cellpadding="0px" cellspacing="0px" style="width:99%;height:auto; margin:0 auto;">
                                            <tr style="height:800px;">
                                                <td style="width:100%; height:100%; background-color:inherit; vertical-align:top;">
                                                    <div class="ui_control_wrapper1" style=" text-align:left; width:auto; height:auto; background-color:inherit;">
                                                        <div id="dvUIContainer" style=" visibility:hidden; height:100%; padding:5px;">
                                                            <br />
                                                        </div>
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
