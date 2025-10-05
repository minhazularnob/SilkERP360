<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalesContract.ascx.cs" Inherits="SilkERP360.UI.WPMS.SalesContract" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<script src="Scripts/SalesContract.js" type="text/javascript"></script>
<style type="text/css">

    .style1
    {
        width: 50%;
        height: 40px;
    }
    .style2
    {
        width: 0%;
        height: 40px;
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
        
                .style33
            {
                height: 40px;
            }
            </style>

<div id="dvItemConfig" style="width:100%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr style="padding:5px;">
            <td style="background-color:Gray; padding:2px; text-align:center; margin:2px;" 
                class="style1">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="padding:2px; text-align:center;margin:2px;" class="style2">
                &nbsp;
            </td>
            <td style="background-color:Gray; padding:2px; text-align:center;margin-left:1px;" 
                class="style1">
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

                        <div id="Div3" style=" width:100%; height:100%;">
                            <!--New Customer Registration Form-->
                            <div style="width:80%; height:auto; text-align:center; margin:0 auto;">
                    <div id="Div7" style=" background-color:white; width:100%; height:auto;">
                            <div style="width:98%; height:auto; text-align:center; ">
                            <div>
                             <a class='command_button_enabled' id='A11' href='#' 
                                    onclick="Save(); return false; ">Save</a>
                             <a class='command_button_enabled' id='A12' href='#' 
                                    onclick="Allclear(); return false; ">New</a>
                           
                            </div>
                                <table style="width:100%; height: 493px;">
                                
                                    <tr>
                                        <td >
                                            <table class="table_ip_control_container" style="width:100%;">
                                               
                                                <tr>
                                                    <td style=" width:20%;">
                                                        <label>PO Code:</label>
                                                    </td>
                                                    <td style=" width:30%;">
                                    <asp:DropDownList ID="ddlPOCode" runat="server" Font-Bold="False"
                                        Font-Size="Medium" Height="25px" ClientIDMode="Static">
                                        <asp:ListItem Value="0">.....Select PO Code.....</asp:ListItem>
                                    </asp:DropDownList>
                                                    </td>
                                                    <td style=" width:20%;">
                                                        <label>Port of Delivary/Loading :</label>
                                                    </td>
                                                    <td  style=" width:30%;">
                                   
                                    <asp:TextBox ID="PortofDelivert" runat="server" Width="95%" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Sales Contract No :</label>
                                                    </td>
                                                    <td>
                                    <asp:TextBox ID="txtSalesContrctNo" runat="server" Width="95%" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                        <td><label>Port of Destination : </label>
                                </td>
                                                    <td style="">
                                    
                                    <asp:TextBox ID="DestinationPort" runat="server" Width="95%" TextMode="SingleLine" ClientIDMode="Static"></asp:TextBox>
                                    
                                                    </td>

                                                    
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                        <label>Country Origin :</label>
                                                    </td>
                                                    <td>
                                    <asp:TextBox ID="LoadingCountry" runat="server" TextMode="SingleLine" 
                                        Width="95%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Pkg. Specification:</label>
                                                    </td>
                                                    <td style=" width:18%;">
                                    <asp:TextBox ID="PkgSpecification" runat="server" Width="95%" TextMode="Multiline" Rows="2" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                                                                       
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                                                        <label>Payment Terms :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                    <asp:TextBox ID="PaymensTerms" runat="server" Width="95%" TextMode="Multiline" Rows="2" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>
                                                <tr>
                                                    <td style=" width:28%;">
                                                        <label>Advising Bank :</label>
                                                    </td>
                                                    <td style=" width:25%;">
                                    <asp:TextBox ID="AdvisingBank" runat="server" Width="95%" TextMode="Multiline" Rows="2" ClientIDMode="Static"></asp:TextBox>
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
                                    <asp:TextBox ID="LcValidity" runat="server" Width="95%" TextMode="Singleline" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Delivery :</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="DestinationCountry" runat="server" Width="95%" 
                                        TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                    
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Trans Shipment :</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="Transhipment" runat="server" Width="95%" Rows="2" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>H.S Code;:</label>
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="HsCode" runat="server" Width="95%" TextMode="Singleline" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td style="">
                                                        <label>Description:</label> 
                                                    </td>
                                                    <td style="">
                                    <asp:TextBox ID="Description" runat="server" Width="95%" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                   
                                                </tr>                                     

                                      <%--  Moddle --%>        </table>

                                            <table align="left" style="width:70%; margin:0 auto;">
                                                <tr>
                                                    <td class="style20" colspan="2" style="text-align:center;">
                                                        <h1>
                                                            Company Information</h1>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26">
                                                        <label>
                                                        Buyer Code :</label>
                                                    </td>
                                                    <td class="style27">
                                                        <asp:TextBox ID="txtsBuyerCode" runat="server" ReadOnly="true" Width="99%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style26">
                                                        <label>
                                                        Customer :</label>
                                                    </td>
                                                    <td class="style27">
                                                        <asp:TextBox ID="ResCustomerName" runat="server" ReadOnly="true" Width="99%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>
                                                        Contact Person :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="resContactPerson" runat="server" ReadOnly="true" Width="99%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>
                                                        Address :</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                        <asp:TextBox ID="resAddres" runat="server" ReadOnly="true" Width="99%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style18">
                                                        <label>
                                                        Email :</label>
                                                    </td>
                                                    <td class="style19">
                                                        <asp:TextBox ID="resEmail" runat="server" Width="99%" ClientIDMode="Static">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style33">
                                                        <label>
                                                        Customer Req:</label>
                                                    </td>
                                                    <td class="style33">
                                                        <asp:TextBox ID="resCustomerReq" runat="server" TextMode="MultiLine" 
                                                            Width="99%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                               

                                                 
                                                  
                                        
                                               </div>
                                               </td>
                                               </tr>
                                               </table>


                                               </div>
                                             
                     
                                <div>
                                 <div style="width:100%; height:400px; overflow:scroll; border:1px solid blue;">                     
                                    <table id="tblProductDetails" style="width:200%">
                                        
                                    </table>
                                    </div>
                                </div>
                               
            
             <table>
        
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

     </div></div>
     </div>