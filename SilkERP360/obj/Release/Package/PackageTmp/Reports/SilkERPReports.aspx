<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SilkERPReports.aspx.cs" Inherits="SilkERP360.Reports.SCPM.SilkERPReports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <%--<link href="../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
--%>
    <script src="../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <link href="../Globals/widgets/jqwidgets/jqwidgets/styles/jqx.base.css" rel="stylesheet" type="text/css" />
<%--<script src="../../Globals/jQuery/jquery-1.10.2.min.js" type="text/javascript"></script>--%>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxcore.js" type="text/javascript"></script>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxdata.js" type="text/javascript"></script>
<script src="../Globals/widgets/jqwidgets/jqwidgets/jqxchart.js" type="text/javascript"></script>



    <script src="../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.core.min.js" type="text/javascript"></script>
     <script src="../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.widget.min.js" type="text/javascript"></script>
     <script src="../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.datepicker.min.js" type="text/javascript"></script>
     <script src="../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.tooltip.min.js" type="text/javascript"></script>
     <script src="../Globals/jQuery/jquery-ui-1.9.1/ui/jquery.ui.effect-fade.js" type="text/javascript"></script>
      <link rel="stylesheet" type="text/css" href="../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" />

    <script src="../Globals/Scripts/plug-ins/blockui-master/jquery.blockUI.js" type="text/javascript"></script>

    <script src="../Globals/Scripts/plug-ins/notification/js/noty/jquery.noty.js" type="text/javascript"></script>

    <script src="../Globals/Scripts/plug-ins/notification/js/noty/layouts/top.js" type="text/javascript"></script>
    <script src="../Globals/Scripts/plug-ins/notification/js/noty/layouts/topCenter.js" type="text/javascript"></script>
    <script src="../Globals/Scripts/plug-ins/notification/js/noty/layouts/topLeft.js" type="text/javascript"></script>
    <script src="../Globals/Scripts/plug-ins/notification/js/noty/layouts/topRight.js" type="text/javascript"></script>
    <script src="../Globals/Scripts/plug-ins/notification/js/noty/themes/default.js" type="text/javascript"></script>

    <%--<script src="scripts/reports_globals.js" type="text/javascript"></script>
    <script src="SCPM/Scripts/scpm_ui_loader.js" type="text/javascript"></script>--%>
    <script src="scripts/reports_mod_config.js" type="text/javascript"></script>
    <link href="../Globals/Scripts/menus/rptsmenu/css/style.css" rel="stylesheet" type="text/css" />
    <link href="Styles/SilkERPReports.css" rel="stylesheet" type="text/css" />
    <title>SilkERP 360 Reports</title>
</head>
<body>
    <form id="form1" runat="server">
   
    <div id="dvContent" style="width:90%; margin:0 auto;">
        <div id="dvHeader" style="width:100%; margin:0 auto;">
            <div id="dvHeaderLeft" style="width:50%; float:left;">
                <h1>SilkERP 360</h1>
                <h3>A Complete Resource Management</h3>
            </div>
            <div  id="dvHeaderRight" style="width:50%; float:right; text-align:right;">
                <div style="float:right; width:30%;">
                    <img id='imgUser' runat="server" style='width:100px; height:80px;' />
                </div>
                <table id="tblUserInfo" style="width:50%; float:right;">
                   
                    <tr>
                        <td style="width:20%;">
                            Username :
                        </td>
                        <td style="width:40%;">
                            <asp:Label ID="lblUsername" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="width:30%;">
                            Name :
                        </td>
                        <td style="width:50%;">
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Designation :
                        </td>
                        <td>
                            <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IP :
                        </td>
                        <td>
                            <asp:Label ID="lblIP" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                </table>
                
            </div>
        </div>
        <div id="menu" style="width:100%;float:none;">
            <ul class="menu"><!-- List starts here -->
                <li><a href="#">SC.P.M</a><!-- 2 columns starts here -->
                    <div class="dropdown-2columns"><!-- Container 2 columns starts here -->
                        <div class="col-2">
                        <img src="../../Globals/Scripts/menus/rptsmenu/images/html51.png" />
                            <p>Silkcard Production Manager (SC.P.M) v.1.0</p>
                    </div>
        
                    <div class="col-2">
                        <h2>SC.P.M Available Reports</h2>
                    </div>
                        <div class="col-2">
                            <ul class="grisbox1">
                                <li><a href="#" onclick="LoadThroughputAnalysis();return false;" title="Periodical Machine Throughput">Periodical Machine Throughput</a></li>
                                <li><a href="#" onclick="LoadDailyThroughputAnalysis();return false;" title="Daily Machine Throughput">Daily Machine Throughput</a></li>
                                <li><a href="#" onclick="LoadDailyThroughputVisual(); return false;"title="Machine Throughput">Daily Machine Throughput Chart</a></li>
                                <li><a href="#" onclick="LoadMachinewiseThroughputVisualByDateRange(); return false;"title="Machine Throughput">Throughput Chart By Date Range</a></li>
                            </ul>   
                         </div>
                    </div><!-- 2 columns ends here -->
                </li><!-- Container 2 columns ends here -->
               
              </ul><!-- List ends here -->
        </div>
        <div id="dvContainer" style="width:100%; height:auto; float:none; min-height:800px;">
            
        </div>
    </div>
    </form>
</body>
</html>
