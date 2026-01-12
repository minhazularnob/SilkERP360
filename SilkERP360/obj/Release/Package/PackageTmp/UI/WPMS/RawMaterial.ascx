<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RawMaterial.ascx.cs" Inherits="SilkERP360.UI.WPMS.RawMaterial1" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
 <script src="../../Globals/jQuery/jquery-ui-1.9.1/ui/minified/jquery.ui.datepicker.min.js" type="text/javascript"></script>
<script src="Scripts/RawMaterial.js" type="text/javascript"></script>
<style type="text/css">

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
        </style>

<div id="dvItemConfig" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="width:0%;padding:2px; height:40px; text-align:center;margin:2px;">
                &nbsp;
            </td>
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center;margin-left:1px;">
                <div id="dvData" style="display:none; color:White;">
                    <%--<span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>--%>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />


                        <div id="Div1" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:80%; height:auto; text-align:center; margin:0 auto;">
                           
                                                       
                                            <table class="table_ip_control_container" 
                                                style="width:50%; margin:0 auto;">
                                               <caption>
                                               <h1>Raw Materials Prices</h1>
                                               </caption>
                                            <tr>

                                                    <td style=" width:30%;">
                                                        <label>
                                                        Name :</label>
                                                    </td>
                                                    <td style=" width:70%;">

                                                    <asp:DropDownList ID="ddlProductSelect" runat="server" Width="99%" 
                                                            Font-Size="Medium" ClientIDMode="Static" 
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
                                                        <asp:TextBox ID="Month" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
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
                                                        <asp:TextBox ID="newPrice" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox> 
                                                        
                                                    </td>
                                                </tr>

                                                <tr>
                                              
                                                    <td colspan="2" style=" width:100%; text-align:center;" align="left">
                                                        <a id="A4" class="command_button_enabled" href="#" 
                                                            onclick="ProductPriceCreate(); return false;">
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
                                              
                                                    <td style=" width:100%; text-align:left;" align="left">
                                                    
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
                                                                                        
                                                       
                                                                                        
                                    <div style="width:100%; height:400px; overflow:scroll; border:1px solid blue;">
                                    <div></div>
                                    <table id="Listofproduct" class="CSSTableGenerator" width="100%" cellspacing="0">
                                        
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

                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="dvItems" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <table id="tblItems">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>

