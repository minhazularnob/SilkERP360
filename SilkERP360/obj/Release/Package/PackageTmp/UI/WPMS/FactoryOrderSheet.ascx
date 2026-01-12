<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FactoryOrderSheet.ascx.cs" Inherits="SilkERP360.UI.WPMS.FactoryOrderSheet" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
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
                                        Font-Size="Medium" Height="25px" ClientIDMode="Static">
                                        <asp:ListItem Value="0">.....Select SalesContract Code.....</asp:ListItem>
                                    </asp:DropDownList> 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label3" runat="server" Text="OrderDate"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="OrderDate" runat="server" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label4" runat="server" Text="Order Ref"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="TextBox10" runat="server" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left">
                                                        <asp:Label ID="Label5" runat="server" Text="SC"></asp:Label>
                                                    </td>
                                                    <td style="text-align: left">
                                                        <asp:TextBox ID="TextBox11" runat="server" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: left" class="style39">
                                                        <asp:Label ID="Label6" runat="server" Text="PR"></asp:Label>
                                                    </td>
                                                    <td class="style39">
                                                        <asp:TextBox ID="TextBox12" runat="server" ClientIDMode="Static"></asp:TextBox>
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
                                                <table id="Table3" style="width:100%; ">
                                                    <thead>
                                                    </thead>
                                                    <tbody style="height:auto;">
                                                    </tbody>
                                                </table>
                                            </div>
                                        </td>
                                        <td>
                                            <div style="width:100%; height:200px; overflow:scroll; border:1px solid blue;">
                                                <table id="Table4" style="width:100%; ">
                                                    <thead>
                                                    </thead>
                                                    <tbody style="height:auto;">
                                                    </tbody>
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

