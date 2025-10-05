<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericUI.aspx.cs" Inherits="SilkERP360.UI.WPMS.GenericUI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<link href="Style/media-css-jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <link href="../../Globals/Styles/Common.css" rel="stylesheet" type="text/css" />
     <link href="../../Globals/Styles/menu.css" rel="stylesheet" type="text/css" />
     <link href="Style/wpms.css" rel="stylesheet" type="text/css" />
     <link href="Style/jquery.appendGrid-1.3.5.css" rel="stylesheet" type="text/css" />
     <link href="Style/jquery.appendGrid-1.3.5.min.css" rel="stylesheet" type="text/css" />
     <link href="Style/jquery.appendGrid-development.css" rel="stylesheet" type="text/css" />
     <link href="../../Globals/jQuery/jquery-ui-1.9.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-1.9.1.min.js" type="text/javascript"></script>   
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.core.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.appendGrid-1.3.5.js" type="text/javascript"></script>
    <script src="Scripts/jquery.appendGrid-1.3.5.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.appendGrid-development.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.widget.min.js" type="text/javascript"></script>
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
    <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.tooltip.min.js" type="text/javascript"></script>
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
    <script src="../../Globals/Scripts/plug-ins/jquery.formatCurrency-1.4.0.min.js" type="text/javascript"></script>
    <script src="../../Globals/Scripts/SilkERP360/globals.js" type="text/javascript"></script>
    <script src="Scripts/Generic_UI.js" type="text/javascript"></script>

        <style type="text/css">
         
      .style10
        {
            height: 33px;
        }
        .ListControl
        {
            font-size: medium;
        }
        .style16
        {
            width: 100%;
            height: 29px;
        }
        .style17
        {
            width: 100%;
            height: 23px;
        }
        .style18
        {
            width: 30%;
            height: 24px;
        }
        .style19
        {
            width: 70%;
            height: 24px;
        }
        
                .style21
        {
            font-size: small;
        }
        .style22
        {
            font-size: x-small;
            font-weight: bold;
        }
            .style26
            {
                width: 30%;
                height: 23px;
            }
            .style27
            {
                width: 70%;
                height: 23px;
            }
            .style28
            {
                width: 18%;
            }
            .style29
            {
                height: 28px;
            }
            .style30
            {
                width: 20%;
                height: 28px;
            }
            .style31
            {
                width: 30%;
                height: 22px;
            }
            .style32
            {
                width: 70%;
                height: 22px;
            }
            .style33
            {
                height: 40px;
            }
            .style38
            {
                width: 100%;
            }
            .style39
            {
                height: 24px;
                text-align: left;
            }
            .style41
            {
                width: 13px;
            }
            
            .MasterBatchInk
            {
                width: 40%;
                }
            .style44
            {
                width: 100%;
                height: 170px;
            }
            .style45
            {
                width: 17%;
            }
            
            .style50
            {
                width: 17%;
            }
            
            
            .style51
            {
                width: 11%;
            }
 .Table
{
    border: 1px solid blue;
    text-align: left;
}
            </style>

            

    <title>Wellpac Management System-WPMS</title>
  
    
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function radioaddbutton_onclick() {

        }

// ]]>
    </script>
</head>
    <body>
        <form id="form1" runat="server">
    <asp:HiddenField id="txtProductCount" runat="server" value="0" clientidmode="Static" />
    <asp:HiddenField id="ImageCount" runat="server" value="0" clientidmode="Static" />
    <asp:HiddenField ID="txtEmployeeCode" runat="server" />
        <asp:HiddenField ID="OutFrom" runat="server" />
        <asp:HiddenField ID="OutTo" runat="server" />
        <asp:HiddenField ID="OutSub" runat="server" />
        <asp:HiddenField ID="OutBody" runat="server" />
    <center>
        <div style="width:100%; height:900px;">
        <table cellspacing="0px" cellpadding="0px" id="tblForm" style=" width:100%; height:100%;">
            <tr style="width:100%; height:auto;">
                <!-- Menu Bar Row-->
                <td colspan="2"  style="width:100%; height:auto;">
                    <!-- H1 Block -->
                    <div id="dvHMenu" style="border:0px; border-style:none;width:100%; height:100%; background-color:#ffffff;">
                        <ul id="mnuSCPM">
                            <li><a href="#">E-Mail</a></li>
                            <li><a href="#" onclick="SaveQuotaion(); return false;">Save Quotation</a></li>
                            <li><a href="#" onclick="newTab(); return false;">Report</a></li>
                           <li><a href="SalesContractUI.aspx" onclick="LogOut();return false;">LogOut</a></li>
                          
	                    </ul>
                        
                    </div>   
                </td>
            </tr>
            <tr style="width:100%; height:auto; background-color:white;">
                <td  style="width:auto; height:auto; background-color:white;">
                    <!-- LOGO-->
                    <table style="width:100%;height:100%; ">
                        <tr>
                            <td>
                                <!--SilkERP360 Logo-->
                                <img src="../../Globals/Images/SilkERP_Header-1_H180PX.jpg" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                <!--WPMS Logo-->
                                <div class="wpms_logo">
                                Wellpac Management System - WPMS v.1.0
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td  style=" height:auto;">
                    <!-- H3 Block -->
                    <table cellspacing="0px" style=" table-layout:fixed; width:100%; height:auto;">
                        <tr style="width:100%;">
                            <td style="width:100%; height:100%;">
                                <table cellspacing="0px" cellpadding="0px" style=" table-layout:fixed; width:100%; height:100%; border-left:1px solid black;">
                                    <tr style="width:100%; height:50%;">
                                        <td style="width:100%; height:50%;">
                                            <!--FOREX TODAY-->
                                            <table style="width:100%;">
                                                <tr>
                                                    <td colspan="6" style="width:100%; text-align:center;">
                                                        <b>FOREX TODAY</b>
                                                        <hr />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align:left;">
                                                        1 Dollar
                                                    </td>
                                                    <td style="text-align:left;">
                                                        80.08 BDT.
                                                    </td>
                                                    <td style="text-align:left;">
                                                        1 Pound
                                                    </td>
                                                    <td style="text-align:left;">
                                                        175.89 BDT.
                                                    </td>
                                                     <td style="text-align:left;">
                                                        1 Euro
                                                    </td>
                                                    <td style="text-align:left;">
                                                        102.32 BDT.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" style="width:100%; text-align:center;">
                                                        <%-- <hr />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align:left;">
                                                        Select Currency :
                                                    </td>
                                                    <td colspan="4" style="text-align:center;">
                                                        <asp:DropDownList ID="ddlSelectCurrency" runat="server" Width="95%">
                                                            <asp:ListItem>------Select Currency</asp:ListItem>
                                                            <asp:ListItem>Dollar ($)</asp:ListItem>
                                                            <asp:ListItem>Pound ($)</asp:ListItem>
                                                            <asp:ListItem>Euro ($)</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" style="width:100%; text-align:center;">
                                                        <hr />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="width:100%;">
                                        <td style="width:100%; height:50%;">
                                            <table cellspacing="0px" cellpadding="1px" style=" table-layout:fixed; width:100%; height:100%; border:1px;">
                                                <tr style="width:100%; height:50%;">
                                                    <td style="width:20%;">
                                                        <b>Username :</b>
                                                    </td>
                                                    <td style="width:30%;">
                                                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="width:20%;">
                                                        <b>IP :</b>
                                                    </td>
                                                    <td style="width:30%;">
                                                        <asp:Label ID="lblIP" runat="server" ClientIDMode="Static"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr style="width:100%; height:50%;">
                                                    <td style="width:20%;">
                                                        <b>Name :</b>
                                                    </td>
                                                    <td colspan="3" style="width:80%;">
                                                        <asp:Label ID="lblEmployeeName" runat="server" ClientIDMode="Static"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="width:100%; height:50%;">
                                                    <td style="width:20%;">
                                                        <b>Designation :</b>
                                                    </td>
                                                    <td colspan="3" style="width:80%;">
                                                        <asp:Label ID="Label1" runat="server" ClientIDMode="Static"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="width:100%; height:50%; padding-bottom:0px;">
                                                    <td colspan="4" style=" text-align:center;">
                                                        <b>Today :</b> <asp:Label ID="lblTodayDate" runat="server" clientidmode="Static"></asp:Label>
                                                        <asp:TextBox ID="txtTodayDate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="width:100%; height:auto; background-color:white;">
                <td colspan="2" style="width:100%;">
                    <hr />
                </td>
            </tr>
            <tr style="width:100%; height:auto;">
                <td colspan="2"  style="width:100%; height:auto;">
                    <!-- dvHeadContainer Block -->
                    <div id="Div6" style=" background-color:white; width:100%; height:auto;">
                        <table style="width:90%; margin:0 auto; table-layout:fixed;">
                            
                                <td colspan="4" style="width:100%">
                                <div> 
                                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
          
            <tr style="width:100%; height:auto;">
                <td colspan="2"  style="width:100%; height:auto; background-color:white;">
                    <!-- dvBody Block -->
                    <div id="dvTabBody" style="height: 1800px; width:95%; background-color:white; margin:0 auto; border:1px solid black;">
                        <ul>
                            <li><a href="#tbpCustomerRegistration">Customer Registration</a></li>
                            <li><a href="#Div1">Raw Materials Price</a></li>
                            <li><a href="#Relationcuspro">Fixed</a></li>
                            <li><a href="#tbpPriceQuotation">Price Quotation</a></li> 
                            <li><a href="#Div4">Purchase Order</a></li>                           
                            <li><a href="#Div3">Sales Contract</a></li>                            
                            <li><a href="#Div2">Factory Order Sheet</a></li>
                            <li><a href="#DivInvoice">Invoice</a></li>                            
                            <li><a href="#DivPackingList">Packing List</a></li>
                        </ul>
                        <p>
                           </p>

                            <div id="Relationcuspro" style=" width:98%; height:100%;"align="left">
                            <div style="width:80%; height:auto;" >
                                            <table class="table_ip_control_container" style="width:50%;">
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Company</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                    <asp:DropDownList ID="ddlCustomerName0" runat="server" Width="99%" 
                                                            Font-Bold="False" Font-Size="Medium" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Company.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td class="style42">
                                                        <label>Product Name</label>
                                                    </td>
                                                    <td class="style43">
                                                    <asp:DropDownList ID="ddlProductName1" runat="server" Width="99%" Font-Bold="False" Font-Size="Medium" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Product.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="style42">
                                                        <label>Item Name</label>
                                                    </td>
                                                    <td class="style43">
                                                    <asp:DropDownList ID="ddlItem" runat="server" Width="99%" Font-Bold="False" Font-Size="Medium" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Item.....</asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                    </td>
                                                   
                                                </tr>

                                                </table>
                                                <table>
                                                <tr>
                                                <td></td>
                                                </tr>
                                                <tr><td>
                                                
                                                </td></tr>
                                                </table>
                                           <div style="width:120%; height:400px; overflow:scroll; border:1px solid blue;">
                                           <table id="Spacification" style="width:120%">
                                           
                                           </table>
                                                </div>
                                                <table style="width:50%;">
                                                <tr>
                                                <td></td>
                                                    <td  style=" width:100%; text-align:left;">
                                                        <a class='secondary_button' id='A16'onclick="ProductBuyerRelation(); return false;" 
                                                            href='#'>Save</a>
                                                            
                                                        <a class='secondary_button' id='A17'onclick="resetFixed(); return false;" href='#'>New</a>
                                                  </td>
                                                </tr>
                                            </table>


                            </div>
                            
                            </div>


                        <div id="tbpCustomerRegistration" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:100%; height:auto; text-align:center; margin:0 auto;">
                                <table style="width:95%; margin-top:10px;">
                                    <tr>
                                        <td style="text-align:center;">
                                            <table class="table_ip_control_container" cellpadding="2px" cellspacing="2px" style="width:50%; margin:0 auto;">
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Country :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="Country" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Company :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtCompany_NC" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style=" width:30%;">
                                                        <label>Contact Person :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtContactPerson_NC" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Address :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtAddress_NC" runat="server" TextMode="MultiLine" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Phone :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="txtPhone_NC" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                    <td style=" width:30%;">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="Email" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;"><br />
                                                        <a class='secondary_button' id='A3'onclick="CustomerSave(); return false;" href='#'>Save Customer</a>
                                                    <a class='secondary_button' id='A6'onclick="Newcustomer(); return false;" href='#'>New Customer</a>
                                                    
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>
                                </table><br />
                                <br />

                                <div>
                                <a class='secondary_button' id='A7'onclick="LoadCustomerLoad(); return false;" href='#'>All Customer</a>
                                </div>

                                <div>
                                 
                                <div style="width:95%; height:400px; overflow:scroll; border:1px solid blue;">
                                    <div></div>
                                     <table id="CustomerList" class="CSSTableGenerator" width="100%" cellspacing="0">
                                        <thead>
                                        <tr>
                                                       <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                           Company Name</th>   
                                                
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Contact Person</th>
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Email</th>
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Address</th>

                                                <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Country</th>
                                        </tr>
                                        </thead>
                                        <tbody style="height:auto;border:1px solid blue;border-right:1px solid blue;">
                                        </tbody>
                                    </table>
                                </div>
                                 
                                </div>
                            </div>
                            
                        </div>
                        <div id="DivInvoice" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:100%; height:auto; text-align:center; margin:0 auto;">
                                <table style="width:95%; margin-top:10px;">
                                    <tr>
                                        <td style="text-align:center;">
                                            <table class="table_ip_control_container" cellpadding="2px" cellspacing="2px" style="width:50%; margin:0 auto;">
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Country :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox44" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Company :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox45" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td style=" width:30%;">
                                                        <label>Contact Person :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox46" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Address :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox47" runat="server" TextMode="MultiLine" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Phone :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox48" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                    <td style=" width:30%;">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="TextBox49" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;"><br />
                                                        <a class='secondary_button' id='A8'onclick="CustomerSave(); return false;" href='#'>Save Customer</a>
                                                    <a class='secondary_button' id='A9'onclick="Newcustomer(); return false;" href='#'>New Customer</a>
                                                    
                                                    </td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>
                                </table><br />
                                <br />

                                <div>
                                <a class='secondary_button' id='A19'onclick="LoadCustomerLoad(); return false;" href='#'>All Customer</a>
                                </div>

                                <div>
                                 
                                <div style="width:95%; height:400px; overflow:scroll; border:1px solid blue;">
                                    <div></div>
                                     <table id="Table5" class="CSSTableGenerator" width="100%" cellspacing="0">
                                        <thead>
                                        <tr>
                                                       <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                           Company Name</th>   
                                                
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Contact Person</th>
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Email</th>
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Address</th>

                                                <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Country</th>
                                        </tr>
                                        </thead>
                                        <tbody style="height:auto;border:1px solid blue;border-right:1px solid blue;">
                                        </tbody>
                                    </table>
                                </div>
                                 
                                </div>
                            </div>
                            
                        </div>


                        <div id="Div1" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:80%; height:auto; text-align:center; margin:0 auto;">
                           
                                                       
                                            <table class="table_ip_control_container" 
                                                style="width:50%; margin:0 auto;">
                                               <caption>
                                               <h1>Raw Materials</h1>
                                               </caption>
                                            <tr>

                                                    <td style=" width:30%;">
                                                        <label>
                                                        Name :</label>
                                                    </td>
                                                    <td style=" width:70%;">

                                                    <asp:DropDownList ID="ddlProductSelect" runat="server" Width="99%" Font-Size="Medium" 
                                                       >
                                                        <asp:ListItem Value="0">.....Select Raw Materials.....</asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                                   
                                                    </td>
                                                </tr>

                                               <tr>

                                                    <td style=" width:30%;">
                                                        <label>
                                                        Month :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="Month" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td style=" width:30%;">
                                                        <label>
                                                        Present
                                                        Price :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="Price" runat="server" Width="100%">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td class="style31">
                                                        <label>
                                                        Price :</label>
                                                    </td>
                                                    <td class="style32">
                                                        <asp:TextBox ID="newPrice" runat="server" Width="100%">
                                                        </asp:TextBox> 
                                                        
                                                    </td>
                                                </tr>

                                                <tr>
                                              
                                                    <td colspan="2" style=" width:100%; text-align:center;" align="left">
                                                        <a id="A4" class="secondary_button" href="#" onclick="ProductPriceCreate(); return false;">
                                                        Save Price</a>
                                                    
                                                    </td>
                                        </tr>
                                   </table>
                          
                            <div>
                            
                            
                            </div>
                                <table style="width:95%; margin-top:50px;">
                                    <tr>
                                        <td style="text-align:center;">
                                            <br />
                                             <div style="border:1px solid black; width:99%; height:auto;">
                                            <table style="width:99%;">
                                                <tr>
                                                    <td class="style16">
                                                        <h1>Last Update Price</h1>
                                                    </td>
                                                </tr>

                                                
                                        <tr>
                                              
                                                    <td colspan="2" style=" width:100%; text-align:left;" align="left">
                                                    
                                                    &nbsp;</td>
                                        </tr>
                                                <tr>
                                                    <td style="text-align: left;" class="style17">
                                            
                                                        <asp:Label ID="Label2" runat="server" Text="Last Update :"></asp:Label>
&nbsp;<asp:Label ID="Date" runat="server"></asp:Label>
                                            
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width:100%;" align="center">
                                                                                        
                                                       
                                                                                        
                                    <div style="width:90%; height:400px; overflow:scroll; border:1px solid blue;">
                                    <div></div>
                                    <table id="Listofproduct" class="CSSTableGenerator" width="100%" cellspacing="0">
                                        <thead>
                                        <tr>
                                                       <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                           Product Name</th>   
                                                
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Date</th>
                                            <th style="width:20%; text-align:center; border:1px solid blue;border-right:1px solid blue;">
                                                Price</th>
                                            
                                        </tr>
                                        </thead>
                                        <tbody style="height:auto;border:1px solid blue;border-right:1px solid blue;">
                                            
                                        </tbody>
                                    </table>
                                    </div>
                                                                                        
                                                       
                                                                                        
                                                    </td>

                                                </tr>

                                                <tr>
                                                <td>&nbsp;</td>
                                                </tr>
                                        </div>
                                    
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>

                        <div id="Div3" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:80%; height:auto; text-align:center; margin:0 auto;">
                    <div id="Div7" style=" background-color:white; width:100%; height:auto;">
                            <div style="width:98%; height:500px; text-align:center; ">
                            <div>
                             <a class='secondary_button' id='A11' href='#' 
                                    onclick="Save(); return false; ">Save</a>
                             <a class='secondary_button' id='A12' href='#' onclick="Allclear(); return false; ">New</a>
                           
                            </div>
                                <table style="width:100%; height: 493px;">
                                
                                    <tr>
                                        <td >
                                            <table class="table_ip_control_container" style="width:100%;">
                                               
                                                <tr>
                                                    <td style=" width:20%;">
                                                        <label>Quotation No:</label>
                                                    </td>
                                                    <td style=" width:30%;">
                                    <asp:DropDownList ID="ddlQuotationCode" runat="server" Font-Bold="False"
                                        Font-Size="Medium" Height="25px">
                                        <asp:ListItem Value="0">.....Select Quotation Code.....</asp:ListItem>
                                    </asp:DropDownList>
                                                    </td>
                                                    <td style=" width:20%;">
                                                        <label>Port of Delivary/Loading :</label>
                                                    </td>
                                                    <td  style=" width:30%;">
                                   
                                    <asp:TextBox ID="PortofDelivert" runat="server" Width="95%" TextMode="SingleLine"></asp:TextBox>
                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Sales Contract No :</label>
                                                    </td>
                                                    <td>
                                    <asp:TextBox ID="txtSalesContrctNo" runat="server" Width="95%" TextMode="SingleLine"></asp:TextBox>
                                                    </td>
                                                        <td><label>Port of Destination : </label>
                                </td>
                                                    <td colspan="3" style="">
                                    
                                    <asp:TextBox ID="DestinationPort" runat="server" Width="95%" TextMode="SingleLine"></asp:TextBox>
                                    
                                                    </td>

                                                    
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                        <label>Country Origin :</label>
                                                    </td>
                                                    <td>
                                    <asp:TextBox ID="LoadingCountry" runat="server" TextMode="SingleLine" 
                                        Width="95%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Pkg. Specification:</label>
                                                    </td>
                                                    <td style=" width:18%;">
                                    <asp:TextBox ID="PkgSpecification" runat="server" Width="95%" TextMode="Multiline" Rows="2"></asp:TextBox>
                                                    </td>
                                                                                                       
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                                                        <label>Payment Terms :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                    <asp:TextBox ID="PaymensTerms" runat="server" Width="95%" TextMode="Multiline" Rows="2"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                                                        <label>Advising Bank :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                    <asp:TextBox ID="AdvisingBank" runat="server" Width="95%" TextMode="Multiline" Rows="2"></asp:TextBox>
                                                    </td>
                                               
                                                </td>
                                                </tr>

                                               <tr>
                                                                                           
                                                      <td colspan="4" style="text-align:center;" class="style20">
                                    <h1>Terms & Conditions</h1>
                                </td>
                                                   

                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>L.C Validity :</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="LcValidity" runat="server" Width="95%" TextMode="Singleline"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Delivery :</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="DestinationCountry" runat="server" Width="95%" 
                                        TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Trans Shipment :</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="Transhipment" runat="server" Width="95%" Rows="2"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>H.S Code;:</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="HsCode" runat="server" Width="95%" TextMode="Singleline"></asp:TextBox>
                                                    </td>
                                                    
                                                <tr>
                                                    <td style="">
                                                        <label>Description:</label> 
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="Description" runat="server" Width="95%" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>                                     

                                                 </table><br />
                                               

                                                 <div align="left">
                                                  <table style="width:50%; margin:0 auto;" align="left">

                                                 
                                      <tr>
                                                                                           
                                                      <td colspan="4" style="text-align:center;" class="style20">
                                    <h1>Company Information</h1>
                                </td>
                                                 

                                                </tr>

                                                <tr>
                                                <td class="style26">
                                                    <label>Buyer Code :</label>
                                                </td>
                                                <td class="style27">
                                                    <asp:TextBox ID="txtsBuyerCode" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style26">
                                                    <label>Customer :</label>
                                                </td>
                                                <td class="style27">
                                                    <asp:TextBox ID="ResCustomerName" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Contact Person :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="resContactPerson" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Address :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="resAddres" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td class="style18">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td class="style19">
                                                        <asp:TextBox ID="resEmail" runat="server" Width="99%">
                                                        </asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                <td class="style33">
                                                        <label>Customer Req:</label>
                                                    </td>
                                                <td class="style33">
                                                        <asp:TextBox ID="resCustomerReq" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </table>
                                               

                                               </div>
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                 <div style="width:100%; height:400px; overflow:scroll; border:1px solid blue;">                     
                                    <table id="tblProductDetails0" style="border-style: groove; width:170%; ">
                                        
                                    </table>
                                    </div>
                                </div>
                                </div></div>
                                <div> 
                                                    </div>


                                </div></div>

                                <div id="Div2" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:80%; height:594px; text-align:center; margin:0 auto;">
                               <div align="left">
                                    <asp:Label ID="Label7" runat="server" 
                                       Text="Wellpac Polymers Limited (Order Sheet)" Font-Bold="True" 
                                       Font-Size="X-Large"></asp:Label></div>
                              
                                <table class="style38">
                                
                                    <tr>
                                        <td style="width:40%;">
                                            <table class="style38">
                                              <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label11" runat="server" Text="SC Code"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                    <asp:DropDownList ID="ddlSalesContractCode" runat="server" Font-Bold="False"
                                        Font-Size="Medium" Height="25px">
                                        <asp:ListItem Value="0">.....Select SalesContract Code.....</asp:ListItem>
                                    </asp:DropDownList> 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label3" runat="server" Text="OrderDate"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="OrderDate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label4" runat="server" Text="Order Ref"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label5" runat="server" Text="SC"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left" class="style39">
                                                        <asp:Label ID="Label6" runat="server" Text="PR"></asp:Label>
                                                    </td>
                                                    <td class="style39">
                                                        <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                    <div style="width:98%; height:200px; overflow:scroll; border:1px solid blue;">
                                   
                                    <table id="Table1" style="width:150%; ">
                                        <thead>
                                        </thead>
                                        <tbody style="height:auto;">
                                            
                                        </tbody>
                                    </table>
                                    </div>
                                        </td>
                                    </tr>

                                </table>
                                
                              
                                <table class="style38">
                                    <tr>
                                        <td>
                                            <div style="width:100%; height:200px; overflow:scroll; border:1px solid blue;">
                                                <table id="Table2" style="width:100%; ">
                                                    <thead>
                                                    </thead>
                                                    <tbody style="height:auto;">
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <table class="style38">
                                    <tr>
                                        <td>
                                            <div style="width:100%; height:200px; overflow:scroll; border:1px solid blue;">
                                                <table id="Table3" style="width:100%; ">
                                                    <thead>
                                                    </thead>
                                                    <tbody style="height:auto;">
                                                </table>
                                            </div>
                                        </td>
                                        <td>
                                            <div style="width:100%; height:200px; overflow:scroll; border:1px solid blue;">
                                                <table id="Table4" style="width:100%; ">
                                                    <thead>
                                                    </thead>
                                                    <tbody style="height:auto;">
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                
                              <table style="border-style: solid">
                              <tr>
                              <td>
                              
                                  <asp:Label ID="Label8" runat="server" Text="Material Mix"></asp:Label>
                              
                              </td>

                              <td class="style41">
                              
                                  <asp:Label ID="Label9" runat="server" Text="%"></asp:Label>
                              
                              </td>

                              <td>
                              
                                  <asp:Label ID="Label10" runat="server" Text="Ton"></asp:Label>
                              
                              </td>
                              </tr>
                              </table>
                            </div>
                        </div>

<div id="Div4" style=" width:100%;">
                            <!--New Customer Registration Form-->
       

                        <div id="Div8" style=" width:99%; margin:0 auto;">
                            <!--Price Quotation-->

                            <div>
                            <table style="width:50%">
                            <tr>
                           <td>
                            
                                <asp:CheckBox ID="QuotationChkforPo" runat="server" Text="Quotation" 
                                    CssClass="ListControl" Font-Bold="True" Font-Size="X-Large" />
                            
                                </td>

                                <td></td>
                            </tr></table>

                            <table id="SelectQuotationforPO"style="width:60%">

                            <tr>
                                        <td style="width:35%">
                                         <label>Quotation Code</label></td>
                                        
                                        <td>
                                                    <asp:DropDownList ID="ddlCustomerName2" runat="server" Width="99%">
                                                    <asp:ListItem Value="0">.....Select The Quotation Code.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td></tr>
                            </table><br />
                            <table style="width:30%">
                            <tr>
                             <td style="width:40%">
                                <a class='secondary_button' id='A2' href='#' 
                                    onclick="POSave(); return false; ">Save PO</a>
                            </td>
                            <td>
                             <a class='secondary_button' id='A13' href='#' 
                                    onclick="addProduct(); return false; ">Clear All</a>
                            </td>
                            </tr>
                            </table>
                            </div>
                            <table id="POCustomerInfo"style="width:99%; margin:0 auto;">
                           
                                <tr>
                                    <td colspan="3" class="style44">
                                      <table style="width:50%; margin:0 auto;">
                               
                                            <tr id ="POSelctCustomer">
                                                <td class="style26">
                                                    <label>Customer :</label>
                                                </td>
                                                <td class="style27">
                                                    <asp:DropDownList ID="ddlCustomerName1" runat="server" Width="99%" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Customer.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="POSelectContactPerson">
                                                <td style=" width:30%;">
                                                    <label>Contact Person :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="txtContactPerson_NPQ0" runat="server" Width="99%" 
                                                        ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="POStakeAddress">
                                                <td style=" width:30%;">
                                                    <label>Address :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="txtAddress0" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr id="POtakeEmail">
                                                    <td class="style18">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td class="style19">
                                                        <asp:TextBox ID="txtEmail0" runat="server" Width="99%">
                                                        </asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr id="POTakeCustomerReq">
                                                <td class="style33">
                                                        <label>Customer Req:</label>
                                                    </td>
                                                <td class="style33">
                                                        <asp:TextBox ID="txtCustomeReq0" runat="server" Width="99%" 
                                                            TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                      
                                </tr>
                                
                                <tr>
                                    <td style="width:45%; height:auto; text-align:center;">
                                        <div style="border:1px solid black; width:99%; height:480px;">
                                            <table cellpadding="2px"  style="width:99%;margin:0 auto;">
                                                <tr>
                                                    <td class="style38">
      <h1>Product Name</h1>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="width:99%; text-align:left;" >
                                                            <asp:RadioButtonList ID="radLstProductCatalog_NPQ0" CssClass="ListControl" 
                                                                RepeatLayout="Flow" ClientIDMode="Static" Width="100%"  runat="server" 
                                                                Height="313px" Font-Size="Medium">
                                                            <asp:ListItem Text="T-Shirt Bag" Value="1010000001"></asp:ListItem>
                                                            <asp:ListItem Text="Block Bag" Value="1010000002"></asp:ListItem>
                                                            <asp:ListItem Text="Knot Bag" Value="1010000003"></asp:ListItem>
                                                            <asp:ListItem Text="Die-Cut Bag" Value="1010000004"></asp:ListItem>
                                                            <asp:ListItem Text="Soft Loop Handle Bag" Value="1010000005"></asp:ListItem>
                                                            <asp:ListItem Text="Garbage Bag on Roll" Value="1010000006"></asp:ListItem>
                                                            <asp:ListItem Text="Flat Bag on Roll" Value="1010000007"></asp:ListItem>
                                                            <asp:ListItem Text="T-Shirt Bag on Roll" Value="1010000008"></asp:ListItem>
                                                            <asp:ListItem Text="Heat Seal Patch Handle Bag / Patch Handle Diecut Bag" 
                                                                    Value="1010000009"></asp:ListItem>
                                                            <asp:ListItem Text="Star Seal Bag on Roll with Core" Value="1010000010"></asp:ListItem>
                                                            <asp:ListItem Text="Star Seal Bag on Roll without Core" Value="1010000011"></asp:ListItem>
                                                            <asp:ListItem Text="Handgloves" Value="1010000012"></asp:ListItem>
                                                            <asp:ListItem Text="Ice Bag" Value="1010000013"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                        <div>
                                                        <table style="width:99%">
                                                        <tr>
                                                        <td style="text-align: left; width:30%;">
                                                        
                                                            <asp:Label ID="Label29" runat="server" Text="Size Spec"></asp:Label>
                                                        
                                                        </td>
                                                        <td>
                                                        
                                                            <asp:DropDownList ID="ddlSizeSpecification0" runat="server">
                                                                <asp:ListItem Value="0">....Select Specification....</asp:ListItem>
                                                            </asp:DropDownList>
                                                        
                                                        </td>
                                                        </tr>
                                                        </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="text-align:center;width:50%;">
                                        <div style="border:1px solid black; width:99%; height:auto;">
                                            <table style="width:99%; height:auto;">
                                                <tr>
                                                    <td style="width:100%;">
                                                        <h1>Raw Materials</h1>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="width:99%;">
                                                        <div">
                                                            <table cellpadding="1px" style="width:95%; margin:0 auto; padding:1px;">
                                                                <tr style="width:100%;">
                                                                    <td style="width:30%; padding:1px; text-align:left;">
                                                                       <table style=" width:100%">
                                                                       <caption><label>Main Product :</label></caption>
                                                                       <tr>
                                                                       <td style="width:50%;">
                                                                           <asp:CheckBox ID="HD0" runat="server" Text="HD" CssClass="ListControl" />
                                                                       </td>

                                                                       <td style="width:50%;">
                                                                           <asp:CheckBox ID="LD0" runat="server" Text="LD" CssClass="ListControl" />
                                                                           </td>
                                                                       </tr>
                                                                       </table>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td style="width:25%; padding:1px; text-align:center;">
                                                                        Price
                                                                    </td>
                                                                    <td style="width:25%; padding:1px; text-align:center; font-size:12px; font-weight:bold;">
                                                                        Sep,2014 ($/MT)
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td style="padding:1px; text-align:left;" >
                                                                        <%--<asp:CheckBox ID="chkHDPE_NPQ" CssClass="chk_box" runat="server" Text="     HDPE" ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="HDPE0" runat="server" Text="HDPE" CssClass="ListControl" />
                                                                      
                                                                    </td>
                                                                   
                                                                         <td style="padding:1px; text-align:left;" class="style30">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Percentage0" runat="server" 
                                                                                 CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                                 ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>

                                                                    <td style="padding:1px; text-align:center;" class="style29">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Price0" runat="server" CssClass="raw_mat_prc" 
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;" class="style29">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Standard_Price0" runat="server" Width="70%" 
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkLLDPE_NPQ" CssClass="chk_box" runat="server" Text="     LLDPE"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="LLDPE0" runat="server" Text="LLDPE" CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Percentage0" runat="server"  
                                                                            CssClass="raw_mat_prcntge1 float_only1" Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                     <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Price0" runat="server" Width="70%" 
                                                                             CssClass="raw_mat_prc"  Text="" ReadOnly="true"   style="text-align:center;"  
                                                                             ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Standard_Price0" runat="server" Width="70%" 
                                                                            ReadOnly="true"   style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                      
                                                                            <asp:CheckBox ID="COCO0" runat="server" Text="COCO" 
                                                                            CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txt_coco3" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txt_coco4" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txt_coco5" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                       
                                                                            <asp:CheckBox ID="LDPE0" runat="server" Text="LDPE" 
                                                                            CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="TextBox50" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox51" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox52" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkPunchOut_NPQ" CssClass="chk_box" runat="server" Text="     Punch Out"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="PunchOut0" runat="server" Text="Recycle" 
                                                                            CssClass="ListControl" />
                                                                       </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Percentage2" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Price2" runat="server" CssClass="raw_mat_prc"  
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Standard_Price0" runat="server" Width="70%"  
                                                                            ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="leftrow0">
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkPunchOut_NPQ" CssClass="chk_box" runat="server" Text="     Punch Out"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="RecycleOut0" runat="server" Text="Recycle Out" 
                                                                            CssClass="ListControl" />
                                                                      </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Percentage3" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Price3" runat="server" CssClass="raw_mat_prc"  
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox53" runat="server" Width="70%"  
                                                                            ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                        <asp:CheckBox ID="MasterBase0" runat="server" Text="MasterBatch" 
                                                                            CssClass="ListControl" />
                                                                        <span class="style21"></span></td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                </tr>

                                                                <tr>
                                                                <td colspan="4">
                                                                <div id ="checkMasterbatch0" style="border-style: dotted;">
                                                                                                                                  
                                                                        <div style=" margin-top:5px;  text-align: left;">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td style="width:30%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkwhite0" runat="server" Text="White" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtMWIn0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label></td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtMWOu0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtMWPr0" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox54" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkblue0" runat="server" Text="Blue" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtBlueIn0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtBlueOu0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtBluePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox55" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkgreen0" runat="server" Text="Green" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtGreenin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtGreenou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtGreenPr0" runat="server" ClientIDMode="Static" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%" Enabled="False"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox56" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkRed0" runat="server" Text="Red" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRedin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtRedou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRedPr0" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox57" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkYellow0" runat="server" Text="Yellow" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtyellowin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtyellowou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtyellowPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox58" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLory0" runat="server" Text="Lory" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtLoryin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtLoryou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtLoryPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox59" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBeige0" runat="server" Text="Beigendy" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtBeigein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtBeigeou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtBeigePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox60" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkPink0" runat="server" Text="Pink" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtPinkin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtPinkou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtPinkPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox61" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBgendy0" runat="server" Text="Bgendy" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtbgendyin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtbgendyou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtbgendyPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox62" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLgrass0" runat="server" Text="Lemon Grass" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtLgrassin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtLgrassou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtLgrassPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox63" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBlack0" runat="server" Text="Black" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="Blackin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="Blackou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="BlackPr0" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox64" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkOrange0" runat="server" Text="Orange" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtOrangein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtOrangeou1" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;width:18%;">
                                                                                        <asp:TextBox ID="txtOrangePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="txtOrangeou2" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                                                                                 </td>
                                                                
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21"></span>
                                                                        <asp:CheckBox ID="chkInk0" runat="server" Text="Ink" CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                       
                                                                               
                                                                             
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr id="chkInkOpen0">
                                                                <td colspan="4">
                                                                <div id ="forcheckbox0" style="border-style: dotted;">
                                                                                                                                  
                                                                        <div style=" margin-top:5px;  text-align: left;">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td style="text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkgeranium0" runat="server" Text="Geranium" 
                                                                                            CssClass="ListControl" />
                                                                                       
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtgeraniumin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                            
                                                                             <label>
                                                                                        %</label>
                                                                            </td>
                                                                                    <td style="padding:1px; text-align:center; " class="style51">
                                                                        <asp:TextBox ID="txtgeraniumou0" runat="server"  CssClass="raw_mat_prc"  Width="90%" 
                                                                            Text=""  ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:14%;">
                                                                        <asp:TextBox ID="txtgeraniumPr0" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox65" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkyellow0" runat="server" Text="Lemon Yellow" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtlyellowin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtlyellowou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtlyellowPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox66" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkmYellow0" runat="server" Text="Mid Yellow" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtmyellowin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtmyellowou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtmyellowPr0" runat="server" ClientIDMode="Static" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox67" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkrblue0" runat="server" Text="Royal Blue" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRBluein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtRBlueou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRBluePr0" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox68" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkblue0" runat="server" Text="Blue" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkBluein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkBlueou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkBluePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox69" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkmdorange0" runat="server" Text="MolibDate Orange" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtmdorangein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtmdorangeou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtmdorangePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox70" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkgreen0" runat="server" Text="Green" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkgreenin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkgreenou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkgreenPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox71" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkgrassgreen0" runat="server" Text="Grass Green" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkggreenin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkggreenou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkggreenPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox72" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkPBlue0" runat="server" Text="Peacock Blue" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkpbluein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkpblueou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkpbluePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox73" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                               
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkBlack0" runat="server" Text="Black" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkBlackin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkBlackou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkBlackPr0" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox74" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkAMRed0" runat="server" Text="AJinomoto Red" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtAMRedin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtAMRedou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtAMRedPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox75" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkrfbluec0" runat="server" Text="Reflex Blue C" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRFBluein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtRFBlueou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRFBluePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox76" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkWhite0" runat="server" Text="White" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkWhitein0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkWhiteou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkWhitePr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox77" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr> 
                                                                                <tr>
                                                                                    <td style="text-align:left;width:25%;"  class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkSilver0" runat="server" Text="Silver" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkSilverin0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge1 float_only1" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkSilverou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkSilverPr0" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox78" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                                                                                 </td>
                                                                
                                                                </tr>
                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21"></span>
                                                                        <asp:CheckBox ID="Thinner0" runat="server" Text="Thinner" 
                                                                            CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="TextBox79" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox80" runat="server"  CssClass="raw_mat_prc"  Width="70%" 
                                                                            Text=""  ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox81" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkD2W_NPQ" CssClass="chk_box" runat="server" Text="D-2-W" />--%>
                                                                        <asp:CheckBox ID="D2W0" runat="server" Text="D-2-W" CssClass="ListControl" />
                                                                        <span class="style21"></span></td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Percentage0" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Price0" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_StandardPrice0" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="EPI0" runat="server" Text="EPI" CssClass="ListControl" /></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Percentage0" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Price0" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Standard_Price0" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="chkEntiSlip0" runat="server" Text="Anti Slip" 
                                                                            CssClass="ListControl" /></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="EntiSlipin0" runat="server" 
                                                                            CssClass="raw_mat_prcntge1 float_only1"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="EntiSlipout0" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="EntiSlippr0" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                               
                                                                <tr>
                                                                    <td style="padding:2px; text-align:right;">
                                                                        <br />
                                                                    </td>
                                                                    <td style="padding:2px; text-align:left;">
                                                                        <label>&nbsp;   <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></label>
                                                                    </td>
                                                                </tr>
                                                                
                                                               
                                                              
                                                               
                                                                                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width:33%;">
                                        &nbsp;</td>
                            </tr></div>
                           
                        </table>
                        <div id="Quotationfade0">
                        
                                        <div style="border:1px solid black; width:97%; height:450px;" align="left">
                            <div style="width:98%;  text-align:center; ">
                            
                                <table style="width:100%; height: 493px;">
                                
                                    <tr>
                                        <td >
                                            <table class="table_ip_control_container" style="width:100%;">
                                              
                                              <tr>
                                                    <td style=" width:11%;">
                                                        <label>Item No :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="ItemNo0" runat="server" Width="90%">1</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                      <label>Product Ref :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductRef1" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                              

                                                    <td style=" width:11%;">
                                                        <label>Quantity (PCS) :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="txtQuantity1" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                        <label>Description :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductDec1" runat="server" Width="90%" 
                                                            TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                         <label>Pcs per carton :</label>
                                                    </td>
                                                    <td style="">
                                                       
                                                        <asp:TextBox ID="totalpcspercarton1" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                       
                                                    </td>
                                               
                                                    <td>
                                                       
                                                      <label>Block Per Carton :</label>  </td>
                                                    <td>
                                                    
                                                     <asp:TextBox ID="txtbpc0" runat="server" Width="90%">0</asp:TextBox>
                                                    
                                                       </td>
                                                    <td>
                                                    
                                                         <label>Pcs Per Block :</label></td>

                                                    <td>
                                                        <asp:TextBox ID="txtppb0" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                        </td>
                                                        <td><label>Outer Bag :</label></td>
                                                        <td>
                                                        <asp:TextBox ID="txtOuterBag0" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td style="">
                                                       
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td style="">
                                                        
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>

                                                
                                                <tr>
                                                    <td colspan="8" style=" text-align:center;">
                                                      <h1>Size Spec.</h1>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Width :</label>
                                                    </td>
                                                    <td style=" width:18%;">
                                                        <asp:TextBox ID="txtWidth1" runat="server" Width="90%" ClientIDMode="Static" 
                                                            >0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Length :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtLength1" runat="server" Width="90%"  ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    
                                              
                                                    <td style=" width:28%;">
                                                        <label>Gusset :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtGusset1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:28%;">
                                                        <label>Density :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtDensity1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                            <label>Thickness :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtThickness1" runat="server" Width="90%" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                      <td style=" width:28%;">
                                                
                                                          <label>Punch Out :</label>
                                                
                                                </td>

                                                <td style=" width:25%;">
                                                
                                                        <asp:TextBox ID="Cutout1" runat="server" Width="90%" 
                                                        ClientIDMode="Static">0</asp:TextBox>
                                                
                                                </td>
                                               
                                                <td style=" width:28%;">
                                                      <label class="style22">Wgt(Kg/1000pcs):</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txtNetWeight1" runat="server" Width="90%" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                    <td style=" width:28%;">
                                                        <asp:CheckBox ID="Digit3" runat="server" Text="2 Digit" />
                                                    </td>
                                                    <td style="">
                                                       </td>

                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Raw Mat. Price :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txtRawMaterialPrice1" runat="server" ReadOnly="true" Text="0" 
                                                            Width="90%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Processing Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Processingcost1" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                               
                                                    <td style="">
                                                        <label>Printing Charge :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="printingCharge1" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Freight Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Freightcost1" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td><label>Cylinder :</label></td>
                                                <td><asp:TextBox ID="Cylinder1" runat="server" Width="90%" Enabled="True">0</asp:TextBox></td>
                                                    <td style="">
                                                         <label>
                                                        Carton Length:</label>
                                                    </td>
                                                    <td style="">
                                                <asp:TextBox ID="Length0" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                               
                                                <td>
                                                    <label>
                                                    Carton Height:</label></td>
                                                <td>
                                                <asp:TextBox ID="Height0" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                  <td>
                                                    <label>
                                                    Carton Width:</label></td>
                                                <td>
                                                <asp:TextBox ID="Width0" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    </tr>                                                  
                                                    
                                                <tr>
                                                    <td style="">
                                                      <label>Insurance :</label> 
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="insurance1" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>

                                                    </td>
                                                    <td style="">
                                                       
                                                        <label>
                                                        FOB Price :</label></td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_FobPrice1" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>
                                                
                                                <td style="">
                                                       
                                                      <label>
                                                      Total Price :</label>
                                                       
                                                      </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_totalPrice1" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>

                                                <td>
                                             <label>Kgs :</label>
                                                
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="Kgs1" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                    </td>
                                                                                                      
                                                </tr>
                                                <tr>
                                                <td>
                                                
                                                    <label>
                                                    Carton :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="Carton1" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                
                                                </td>
                                                <td>
                                                
                                                    <label>
                                                    CBM :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="CBM0" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='secondary_button' id='lnkCalculateWeight1' href='#' 
                                                            onclick="CalculateNetWeightPO(); return false;">Cal. Wgt.</a>
                                                    </td>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='secondary_button' id='A22'
                                                            onclick="CalculateTotalPricePO(); return false;" href='#'>Cal. Price</a>
                                                    </td>
                                                    <td colspan="2"> <br />
                                                     <a class='secondary_button' id='A20' href='#' 
                                    onclick="addProduct(); return false; ">Add Product</a>
                                                    </td>
                                                <td colspan="2">
                                                <br />
                                                    <a id="A21" class="secondary_button" href="#" 
                                                        onclick="AllclearPO(); return false; ">Another Product</a></td>
                                                </tr>
                                                
                                                
                                              </table>
                                        </td>
                                    </tr>
                                </table>
                                </div> 
                                </div>

    <div id="Restricted0"style="width:95%; height:200px; overflow:scroll; border:1px solid blue;">
                                   
                                    <table id="tblProductDetails1" style="width:150%; ">
                                        <thead>
                                        </thead>
                                        <tbody style="height:auto;">
                                            
                                        </tbody>
                                    </table>
                                    </div>
                              <br />
                            
        </div>
               
       </div>    
                            </div>


                        <div id="tbpPriceQuotation" style=" width:99%; margin:0 auto;">
                            <!--Price Quotation-->
                            <table style="width:99%; margin:0 auto;">
                                <tr>
                                    <td colspan="3" class="style44">
                                        <table style="width:50%; margin:0 auto;">
                                        <tr><td colspan="2">
                                            &nbsp;</td></tr>
                                            <tr>
                                                <td class="style26">
                                                    <label>Customer :</label>
                                                </td>
                                                <td class="style27">
                                                    <asp:DropDownList ID="ddlCustomerName" runat="server" Width="99%" 
                                                       >
                                                    <asp:ListItem Value="0">.....Select The Customer.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Contact Person :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="txtContactPerson_NPQ" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Address :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="99%" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                    <td class="style18">
                                                        <label>Email :</label>
                                                    </td>
                                                    <td class="style19">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="99%">
                                                        </asp:TextBox>
                                                    </td>

                                                </tr>
                                                <tr>
                                                <td class="style33">
                                                        <label>Customer Req:</label>
                                                    </td>
                                                <td class="style33">
                                                        <asp:TextBox ID="txtCustomeReq" runat="server" Width="99%" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <br />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td style="width:45%; height:auto; text-align:center;">
                                        <div style="border:1px solid black; width:99%; height:480px;">
                                            <table cellpadding="2px"  style="width:99%;margin:0 auto;">
                                                <tr>
                                                    <td class="style38">
      <h1>Product Name</h1>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="width:99%; text-align:left;" >
                                                            <asp:RadioButtonList ID="radLstProductCatalog_NPQ" CssClass="ListControl" 
                                                                RepeatLayout="Flow" ClientIDMode="Static" Width="100%"  runat="server" 
                                                                Height="313px" Font-Size="Medium">
                                                            <asp:ListItem Text="T-Shirt Bag" Value="1010000001"></asp:ListItem>
                                                            <asp:ListItem Text="Block Bag" Value="1010000002"></asp:ListItem>
                                                            <asp:ListItem Text="Knot Bag" Value="1010000003"></asp:ListItem>
                                                            <asp:ListItem Text="Die-Cut Bag" Value="1010000004"></asp:ListItem>
                                                            <asp:ListItem Text="Soft Loop Handle Bag" Value="1010000005"></asp:ListItem>
                                                            <asp:ListItem Text="Garbage Bag on Roll" Value="1010000006"></asp:ListItem>
                                                            <asp:ListItem Text="Flat Bag on Roll" Value="1010000007"></asp:ListItem>
                                                            <asp:ListItem Text="T-Shirt Bag on Roll" Value="1010000008"></asp:ListItem>
                                                            <asp:ListItem Text="Heat Seal Patch Handle Bag / Patch Handle Diecut Bag" 
                                                                    Value="1010000009"></asp:ListItem>
                                                            <asp:ListItem Text="Star Seal Bag on Roll with Core" Value="1010000010"></asp:ListItem>
                                                            <asp:ListItem Text="Star Seal Bag on Roll without Core" Value="1010000011"></asp:ListItem>
                                                            <asp:ListItem Text="Handgloves" Value="1010000012"></asp:ListItem>
                                                            <asp:ListItem Text="Ice Bag" Value="1010000013"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </div>
                                                        <div>
                                                        <table style="width:99%">
                                                        <tr>
                                                        <td style="text-align: left; width:30%;">
                                                        
                                                            <asp:Label ID="Label27" runat="server" Text="Size Spec"></asp:Label>
                                                        
                                                        </td>
                                                        <td>
                                                        
                                                            <asp:DropDownList ID="ddlSizeSpecification" runat="server">
                                                                <asp:ListItem Value="0">....Select Specification....</asp:ListItem>
                                                            </asp:DropDownList>
                                                        
                                                        </td>
                                                        </tr>
                                                        </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="text-align:center;width:50%;">
                                        <div style="border:1px solid black; width:99%; height:auto;">
                                            <table style="width:99%; height:auto;">
                                                <tr>
                                                    <td style="width:100%;">
                                                        <h1>Raw Materials</h1>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="width:99%;">
                                                        <div">
                                                            <table cellpadding="1px" style="width:95%; margin:0 auto; padding:1px;">
                                                               
                                                               
                                                                <tr style="width:100%;">
                                                                    <td style="width:30%; padding:1px; text-align:left;">
                                                                       <table style=" width:100%">
                                                                       <caption><label>Main Product :</label></caption>
                                                                       <tr>
                                                                       <td style="width:50%;">
                                                                       
                                                                          
                                                                       
                                                                           <asp:CheckBox ID="HD" runat="server" Text="HD" CssClass="ListControl" />
                                                                       
                                                                          
                                                                       
                                                                       </td>

                                                                       <td style="width:50%;">
                                                                       
                                                                          
                                                                       
                                                                           <asp:CheckBox ID="LD" runat="server" Text="LD" CssClass="ListControl" />
                                                                           </td>
                                                                       </tr>
                                                                       </table>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td style="width:25%; padding:1px; text-align:center;">
                                                                        Price
                                                                    </td>
                                                                    <td style="width:25%; padding:1px; text-align:center; font-size:12px; font-weight:bold;">
                                                                        Sep,2014 ($/MT)
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td style="padding:1px; text-align:left;" >
                                                                        <%--<asp:CheckBox ID="chkHDPE_NPQ" CssClass="chk_box" runat="server" Text="     HDPE" ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="HDPE" runat="server" Text="HDPE" CssClass="ListControl" />
                                                                      
                                                                    </td>
                                                                   
                                                                         <td style="padding:1px; text-align:left;" class="style30">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Percentage" runat="server" 
                                                                                 CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                                 ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>

                                                                    <td style="padding:1px; text-align:center;" class="style29">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Price" runat="server" CssClass="raw_mat_prc" 
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;" class="style29">
                                                                        <asp:TextBox ID="txtHDPE_NPQ_Standard_Price" runat="server" Width="70%" 
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False" ></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkLLDPE_NPQ" CssClass="chk_box" runat="server" Text="     LLDPE"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="LLDPE" runat="server" Text="LLDPE" CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Percentage" runat="server"  
                                                                            CssClass="raw_mat_prcntge float_only" Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox></asp:TextBox><label>%</label>
                                                                    </td>
                                                                     <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Price" runat="server" Width="70%" 
                                                                             CssClass="raw_mat_prc"  Text="" ReadOnly="true"   style="text-align:center;"  
                                                                             ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtLLDPE_NPQ_Standard_Price" runat="server" Width="70%" 
                                                                            ReadOnly="true"   style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                      
                                                                            <asp:CheckBox ID="COCO" runat="server" Text="COCO" CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txt_coco" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txt_coco1" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txt_coco2" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                       
                                                                            <asp:CheckBox ID="LDPE" runat="server" Text="LDPE" CssClass="ListControl" /></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="TextBox4" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox5" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox6" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkPunchOut_NPQ" CssClass="chk_box" runat="server" Text="     Punch Out"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="PunchOut" runat="server" Text="Recycle" 
                                                                            CssClass="ListControl" />
                                                                       </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Percentage" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Price" runat="server" CssClass="raw_mat_prc"  
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Standard_Price" runat="server" Width="70%"  
                                                                            ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr id="leftrow">
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkPunchOut_NPQ" CssClass="chk_box" runat="server" Text="     Punch Out"  ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="RecycleOut" runat="server" Text="Recycle Out" 
                                                                            CssClass="ListControl" />
                                                                      </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Percentage1" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtPunchOut_NPQ_Price1" runat="server" CssClass="raw_mat_prc"  
                                                                            Width="70%" Text="" ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox14" runat="server" Width="70%"  
                                                                            ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                        <asp:CheckBox ID="MasterBase" runat="server" Text="MasterBatch" 
                                                                            CssClass="ListControl" />
                                                                        <span class="style21"></span></td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                </tr>

                                                                <tr>
                                                                <td colspan="4">
                                                                <div id ="checkMasterbatch" style="border-style: dotted;">
                                                                                                                                  
                                                                        <div style=" margin-top:5px;  text-align: left;">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td style="width:30%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkwhite" runat="server" Text="White" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtMWIn" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label></td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtMWOu" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtMWPr" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox29" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkblue" runat="server" Text="Blue" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtBlueIn" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtBlueOu" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtBluePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox28" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkgreen" runat="server" Text="Green" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtGreenin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtGreenou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtGreenPr" runat="server" ClientIDMode="Static" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%" Enabled="False"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox27" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkRed" runat="server" Text="Red" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRedin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtRedou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRedPr" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox26" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkYellow" runat="server" Text="Yellow" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtyellowin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtyellowou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtyellowPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox25" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLory" runat="server" Text="Lory" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtLoryin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtLoryou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtLoryPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox24" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBeige" runat="server" Text="Beigendy" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtBeigein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtBeigeou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtBeigePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox23" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkPink" runat="server" Text="Pink" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtPinkin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtPinkou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtPinkPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox22" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBgendy" runat="server" Text="Bgendy" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtbgendyin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtbgendyou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtbgendyPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox21" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLgrass" runat="server" Text="Lemon Grass" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtLgrassin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtLgrassou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtLgrassPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox20" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBlack" runat="server" Text="Black" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="Blackin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="Blackou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="BlackPr" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>

                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="TextBox8" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkOrange" runat="server" Text="Orange" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style28" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtOrangein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style45">
                                                                                        <asp:TextBox ID="txtOrangeou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;width:18%;">
                                                                                        <asp:TextBox ID="txtOrangePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="60%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    
                                                                                        <asp:TextBox ID="txtOrangeou0" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                                                                                 </td>
                                                                
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21"></span>
                                                                        <asp:CheckBox ID="chkInk" runat="server" Text="Ink" CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                       
                                                                               
                                                                             
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        &nbsp;</td>
                                                                </tr>
                                                                <tr id="chkInkOpen">
                                                                <td colspan="4">
                                                                <div id ="forcheckbox" style="border-style: dotted;">
                                                                                                                                  
                                                                        <div style=" margin-top:5px;  text-align: left;">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td style="text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkgeranium" runat="server" Text="Geranium" 
                                                                                            CssClass="ListControl" />
                                                                                       
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtgeraniumin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                            
                                                                             <label>
                                                                                        %</label>
                                                                            </td>
                                                                                    <td style="padding:1px; text-align:center; " class="style51">
                                                                        <asp:TextBox ID="txtgeraniumou" runat="server"  CssClass="raw_mat_prc"  Width="90%" 
                                                                            Text=""  ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:14%;">
                                                                        <asp:TextBox ID="txtgeraniumPr" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox30" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkyellow" runat="server" Text="Lemon Yellow" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtlyellowin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtlyellowou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtlyellowPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox31" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkmYellow" runat="server" Text="Mid Yellow" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtmyellowin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtmyellowou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtmyellowPr" runat="server" ClientIDMode="Static" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%" Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox32" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkrblue" runat="server" Text="Royal Blue" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRBluein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtRBlueou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRBluePr" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox33" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkblue" runat="server" Text="Blue" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkBluein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkBlueou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkBluePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox34" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkmdorange" runat="server" Text="MolibDate Orange" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtmdorangein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtmdorangeou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtmdorangePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox35" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkinkgreen" runat="server" Text="Green" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkgreenin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkgreenou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkgreenPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox36" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkgrassgreen" runat="server" Text="Grass Green" CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkggreenin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkggreenou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkggreenPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox37" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkPBlue" runat="server" Text="Peacock Blue" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkpbluein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkpblueou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkpbluePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox38" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                               
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkBlack" runat="server" Text="Black" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkBlackin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkBlackou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkBlackPr" runat="server" ClientIDMode="Static" Enabled="False" 
                                                                                            ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox39" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkAMRed" runat="server" Text="AJinomoto Red" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtAMRedin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtAMRedou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtAMRedPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox40" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkrfbluec" runat="server" Text="Reflex Blue C" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtRFBluein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtRFBlueou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtRFBluePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox41" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="text-align:left;" class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkWhite" runat="server" Text="White" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkWhitein" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkWhiteou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkWhitePr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox42" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr> 
                                                                                <tr>
                                                                                    <td style="text-align:left;width:25%;"  class="MasterBatchInk">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkInkSilver" runat="server" Text="Silver" 
                                                                                            CssClass="ListControl" />
                                                                                        <span class="style21"></span>
                                                                                    </td>
                                                                                    <td class="style50" style="padding:1px; text-align:left;">
                                                                                        <asp:TextBox ID="txtInkSilverin" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prcntge float_only" Enabled="False" 
                                                                                            style="text-align:center;" Width="50%"></asp:TextBox>
                                                                                        <label>
                                                                                        %</label>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;" class="style51">
                                                                                        <asp:TextBox ID="txtInkSilverou" runat="server" ClientIDMode="Static" 
                                                                                            CssClass="raw_mat_prc" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center;">
                                                                                        <asp:TextBox ID="txtInkSilverPr" runat="server" ClientIDMode="Static" 
                                                                                            Enabled="False" ReadOnly="true" style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="padding:1px; text-align:center; width:18%;">
                                                                        <asp:TextBox ID="TextBox43" runat="server" Width="90%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                                                                                 </td>
                                                                
                                                                </tr>
                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21"></span>
                                                                        <asp:CheckBox ID="Thinner" runat="server" Text="Thinner" 
                                                                            CssClass="ListControl" />
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="TextBox1" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox2" runat="server"  CssClass="raw_mat_prc"  Width="70%" 
                                                                            Text=""  ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox3" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkD2W_NPQ" CssClass="chk_box" runat="server" Text="D-2-W" />--%>
                                                                        <asp:CheckBox ID="D2W" runat="server" Text="D-2-W" CssClass="ListControl" />
                                                                        <span class="style21"></span></td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Percentage" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Price" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_StandardPrice" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="EPI" runat="server" Text="EPI" CssClass="ListControl" /></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Percentage" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Price" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Standard_Price" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="chkEntiSlip" runat="server" Text="Anti Slip" CssClass="ListControl" /></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="EntiSlipin" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="EntiSlipout" runat="server"  CssClass="raw_mat_prc"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="EntiSlippr" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                               
                                                                <tr>
                                                                    <td style="padding:2px; text-align:right;">
                                                                        <br />
                                                                    </td>
                                                                    <td style="padding:2px; text-align:left;">
                                                                        <label>&nbsp;   <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b></label>
                                                                    </td>
                                                                </tr>
                                                                
                                                               
                                                              
                                                               
                                                                                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width:33%;">
                                        &nbsp;</td>
                            </tr></div>
                           
                        </table>
                        <div id="Quotationfade">
                        
                                        <div style="border:1px solid black; width:99%; height:585px;" align="left">
                            <div style="width:98%;  text-align:center; ">
                            <div>
                            

                            </div>
                                <table style="width:100%; height: 493px;">
                                
                                    <tr>
                                        <td >
                                            <table class="table_ip_control_container" style="width:100%;">
                                              
                                              <tr>
                                                    <td style=" width:11%;">
                                                        <label>Item No :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="ItemNo" runat="server" Width="90%">1</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                      <label>Product Ref :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductRef" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                              

                                                    <td style=" width:11%;">
                                                        <label>Quantity (PCS) :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="txtQuantity" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                        <label>Description :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductDec" runat="server" Width="90%" 
                                                            TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                         <label>Pcs of per carton :</label>
                                                    </td>
                                                    <td style="">
                                                       
                                                        <asp:TextBox ID="totalpcspercarton" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                       
                                                    </td>
                                               
                                                    <td>
                                                       
                                                      <label>Block Per Carton :</label>  </td>
                                                    <td>
                                                    
                                                     <asp:TextBox ID="txtbpc" runat="server" Width="90%">0</asp:TextBox>
                                                    
                                                       </td>
                                                    <td>
                                                    
                                                         <label>Pcs of Per Block :</label></td>

                                                    <td>
                                                        <asp:TextBox ID="txtppb" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                        </td>
                                                        <td><label>Outer Bag :</label></td>
                                                        <td>
                                                        <asp:TextBox ID="txtOuterBag" runat="server" Width="90%" 
                                                          >0</asp:TextBox>
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td style="">
                                                       
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                    <td style="">
                                                        
                                                    </td>
                                                    <td>
                                                        &nbsp;</td>
                                                </tr>

                                                
                                                <tr>
                                                    <td colspan="8" style=" text-align:center;">
                                                      <h1>Size Spec.</h1>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Width :</label>
                                                    </td>
                                                    <td style=" width:18%;">
                                                        <asp:TextBox ID="txtWidth" runat="server" Width="90%" ClientIDMode="Static" 
                                                            >0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Length :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtLength" runat="server" Width="90%"  ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    
                                              
                                                    <td style=" width:28%;">
                                                        <label>Gusset :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtGusset" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:28%;">
                                                        <label>Density :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtDensity" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                            <label>Thickness :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                                        <asp:TextBox ID="txtThickness" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                      <td style=" width:28%;">
                                                
                                                          <label>Punch Out :</label>
                                                
                                                </td>

                                                <td style=" width:25%;">
                                                
                                                        <asp:TextBox ID="Cutout" runat="server" Width="90%" 
                                                        ClientIDMode="Static">0</asp:TextBox>
                                                
                                                </td>
                                               
                                                <td style=" width:28%;">
                                                      <label class="style22">Wgt(Kg/1000pcs):</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txtNetWeight" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                    <td style=" width:28%;">
                                                        <asp:CheckBox ID="Digit2" runat="server" Text="2 Digit" />
                                                    </td>
                                                    <td style="">
                                                       </td>

                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Raw Mat. Price :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txtRawMaterialPrice" runat="server" ReadOnly="true" Text="0" 
                                                            Width="90%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Processing Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Processingcost" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                               
                                                    <td style="">
                                                        <label>Printing Charge :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="printingCharge" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Freight Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Freightcost" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td><label>Cylinder :</label></td>
                                                <td><asp:TextBox ID="Cylinder" runat="server" Width="90%" Enabled="True">0</asp:TextBox></td>
                                                    <td style="">
                                                         <label>
                                                        Carton Length:</label>
                                                    </td>
                                                    <td style="">
                                                <asp:TextBox ID="Length" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                               
                                                <td>
                                                    <label>
                                                    Carton Height:</label></td>
                                                <td>
                                                <asp:TextBox ID="Height" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                  <td>
                                                    <label>
                                                    Carton Width:</label></td>
                                                <td>
                                                <asp:TextBox ID="Width" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                    </tr>                                                  
                                                    
                                                <tr>
                                                    <td style="">
                                                      <label>Insurance :</label> 
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="insurance" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>

                                                    </td>
                                                    <td style="">
                                                       
                                                        <label>
                                                        FOB Price :</label></td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_FobPrice" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>
                                                
                                                <td style="">
                                                       
                                                      <label>
                                                      Total Price :</label>
                                                       
                                                      </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_totalPrice" runat="server" Width="90%" Enabled="False">0</asp:TextBox>
                                                    </td>

                                                <td>
                                             <label>Kgs :</label>
                                                
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="Kgs" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                    </td>
                                                                                                      
                                                </tr>
                                                <tr>
                                                <td>
                                                
                                                    <label>
                                                    Carton :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="Carton" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                
                                                </td>
                                                <td>
                                                
                                                    <label>
                                                    CBM :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="CBM" runat="server" Width="90%" Enabled="False"></asp:TextBox>
                                                
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='secondary_button' id='lnkCalculateWeight' href='#' onclick="CalculateNetWeight(); return false;">Cal. Wgt.</a>
                                                    </td>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='secondary_button' id='A1'onclick="CalculateTotalPrice(); return false;" href='#'>Cal. Price</a>
                                                    </td>
                                                    <td colspan="2"><br />
                                                     <a class='secondary_button' id='A10' href='#' onclick="addProduct(); return false; ">Add Product</a>
                                                    </td>

                                                    <td><br />
                                                                                 <a class='secondary_button' id='A5' href='#' onclick="Allclear(); return false; ">New</a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="4" style=" text-align:center;" class="style5">
                                                        <h1>Comission</h1>
                                                    </td>
                                                    
                                                </tr>
                                               <tr>
                                                <td>
                                                 <label>Full Name :</label>
                                                </td>

                                                <td>
                                                        <asp:TextBox ID="txt_ComName" runat="server" Width="90%"></asp:TextBox>
                                                        
                                                </td>
                                               <td>
                                                   <label>Address:</label>
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="txt_ComAddress" runat="server" Width="90%" 
                                                        ClientIDMode="Static"></asp:TextBox>
                                                
                                                </td>                                                                                       
                                           
                                               
                                                <td>
                                                <label>Phone:</label>
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txt_ComPhone" runat="server" Width="90%" 
                                                       ClientIDMode="Static"></asp:TextBox>
                                                </td>
                                              <td>
                                                 <label>Email:</label>
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="txt_ComEmail" runat="server" Width="90%" 
                                                        ClientIDMode="Static"></asp:TextBox>
                                                </td>
                                                </tr>

                                               
                                              <td>
                                                 <label>Amount:</label>
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="txt_ComAmount" runat="server" Width="90%" 
                                                        ClientIDMode="Static">0</asp:TextBox>
                                                </td>
                                              </table>
                                        </td>
                                    </tr>
                                </table>
                                </div> 
                                </div>

    <div id="Restricted"style="width:98%; height:200px; overflow:scroll; border:1px solid blue;">
                                   
                                    <table id="tblProductDetails" style="width:150%; ">
                                        <thead>
                                        </thead>
                                        <tbody style="height:auto;">
                                            
                                        </tbody>
                                    </table>
                                    </div>
                           
                            
        </div>
       <div>
       </div>
       <div>
       

    </center>
    </form>
</body>
</html>
