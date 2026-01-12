<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Fixed.ascx.cs" Inherits="SilkERP360.UI.WPMS.RawMaterial" %>
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

                            <div id="Relationcuspro" style=" width:98%; height:100%;"align="left">
                            <div style="width:80%; height:auto;" >
                                            <table class="table_ip_control_container" style="width:50%;">
                                                <tr>
                                                    <td style=" width:30%;">
                                                        <label>Company</label>
                                                    </td>
                                                    <td style=" width:70%;">
                                                    <asp:DropDownList ID="ddlCustomerName0" runat="server" Width="99%" 
                                                            Font-Bold="False" Font-Size="Medium" ClientIDMode="Static"
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
                                                    <asp:DropDownList ID="ddlProductName1" runat="server" Width="99%" Font-Bold="False" Font-Size="Medium" ClientIDMode="Static"
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
                                                    <asp:DropDownList ID="ddlItem" runat="server" Width="99%" Font-Bold="False" Font-Size="Medium" ClientIDMode="Static"
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


                    <br />

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
