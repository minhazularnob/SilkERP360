<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrder.ascx.cs" Inherits="SilkERP360.UI.WPMS.PurchaseOrder" %>
<link href="CSS/PurchaseOrder.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<script src="Scripts/PurchaseOrder.js" type="text/javascript"></script>
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
        .ListControl
        {
            font-size: medium;
        }
            .style44
            {
                width: 100%;
                height: 170px;
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
            .style38
            {
                width: 100%;
            }
            .style28
            {
                width: 18%;
            }
            .style30
            {
                width: 20%;
                height: 28px;
            }
            .style29
            {
                height: 28px;
            }
                    
                .style21
        {
            font-size: small;
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
             
            .MasterBatchInk
            {
                width: 40%;
                }
            .style22
        {
            font-size: x-small;
            font-weight: bold;
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
                <div id="dvQCHead" style="width:100%; height:auto; border-bottom:2px ridge black;">
               <br />


                        <div id="Div8" style=" width:99%; margin:0 auto;">

                            <table style="width:50%">
                            <tr>
                           <td>
                            
                                <asp:CheckBox ID="QuotationChkforPo" runat="server" Text="Quotation" 
                                    CssClass="ListControl" Font-Bold="True" Font-Size="X-Large" ClientIDMode="Static" />
                            
                                </td>

                                <td></td>
                            </tr></table>

                            <table id="SelectQuotationforPO"style="width:60%">

                            <tr>
                                        <td style="width:35%">
                                         <label>Quotation Code</label></td>
                                        
                                        <td>
                                                    <asp:DropDownList ID="ddlCustomerName2" runat="server" Width="99%" 
                                                        ClientIDMode="Static">
                                                    <asp:ListItem Value="0">.....Select The Quotation Code.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td></tr>
                            </table><br />
                            <table style="width:30%">
                            <tr>
                             <td style="width:40%">
                                <a class='command_button_enabled' id='A2' href='#' 
                                    onclick="POSave(); return false; ">Save PO</a>
                            </td>
                            <td>
                             <a class='command_button_enabled' id='A13' href='#' 
                                    onclick="AllClear(); return false; ">Clear All</a>
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
                                                    <label>Buyer :</label>
                                                </td>
                                                <td class="style27">
                                                    <asp:DropDownList ID="ddlBuyer" runat="server" Width="99%" 
                                                        ClientIDMode="Static">
                                                    <asp:ListItem Value="0">.....Select The Buyer.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="POSelectContactPerson">
                                                <td style=" width:30%;">
                                                    <label>CataGory :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:DropDownList ID="ddlCatagory" runat="server" Width="99%" 
                                                        ClientIDMode="Static">
                                                    <asp:ListItem Value="0">.....Select The CataGory.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr id="POStakeAddress">
                                                <td style=" width:30%;">
                                                    <label>Specification :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                    <asp:DropDownList ID="ddlBuyer1" runat="server" Width="99%" 
                                                        ClientIDMode="Static">
                                                    <asp:ListItem Value="0">.....Select Item Specification.....</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                          
                                             <tr id="POTakeCustomerReq">
                                                <td class="style33">
                                                        <label>Customer Req:</label>
                                                    </td>
                                                <td class="style33">
                                                        <asp:TextBox ID="txtCustomeReq0" runat="server" Width="99%" 
                                                            TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                </tr>
                                        </table>
                                    </td>

                                </tr>
                                <tr>
                                    <td></td>
                                      
                                </tr>
                                
                                <tr>
                                    <td style="width:100%; height:auto; text-align:center;">
                                        <div style="border:1px solid black; width:100%; height:auto;">
                                            <table cellpadding="2px"  style="width:100%;margin:0 auto;">
                                               
                                                
                                                <tr>
                                             
                                    <td colspan="1"style="text-align:center;width:100%;">
                                        <div style="border:1px solid black; width:100%; height:auto;">
                                            <table style="width:100%; height:auto;">
                                                <tr>
                                                    <td style="width:100%;">
                                                        <h1>Raw Materials</h1>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="width:99%;">
                                                        <div style="height:auto;">
                                                            <table cellpadding="1px" style="width:95%; margin:0 auto; padding:1px;">
                                                                <tr style="width:100%;">
                                                                    <td style="width:30%; padding:1px; text-align:left;">
                                                                       <table style=" width:100%">
                                                                       <tr>
                                                                       <td colspan="2">
                                                                       <label>Main Product :</label>
                                                                       </td>
                                                                       </tr>
                                                                      
                                                                       <tr>
                                                                       <td style="width:50%;">
                                                                           <asp:CheckBox ID="HD0" runat="server" Text="HD" CssClass="ListControl" ClientIDMode="Static" />
                                                                       </td>

                                                                       <td style="width:50%;">
                                                                           <asp:CheckBox ID="LD0" runat="server" Text="LD" CssClass="ListControl"  ClientIDMode="Static"/>
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
                                                                        Oct,2014 ($/MT)
                                                                    </td>
                                                                </tr>
                                                                <tr >
                                                                    <td style="padding:1px; text-align:left;" >
                                                                        <%--<asp:CheckBox ID="chkHDPE_NPQ" CssClass="chk_box" runat="server" Text="     HDPE" ClientIDMode="Static" />--%>
                                                                        <asp:CheckBox ID="HDPE0" runat="server" Text="HDPE" CssClass="ListControl" ClientIDMode="Static" />
                                                                      
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
                                                                        <asp:CheckBox ID="LLDPE0" runat="server" Text="LLDPE" CssClass="ListControl" ClientIDMode="Static" />
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                        <asp:CheckBox ID="chkblue0" runat="server" Text="Blue" CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                        <asp:CheckBox ID="chkRed0" runat="server" Text="Red" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                        <asp:CheckBox ID="chkLory0" runat="server" Text="Lory" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                        <asp:CheckBox ID="chkPink0" runat="server" Text="Pink" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                        <asp:CheckBox ID="chkInk0" runat="server" Text="Ink" CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
                                                                                       
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                            CssClass="ListControl" ClientIDMode="Static" />
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
                                                                        <asp:CheckBox ID="D2W0" runat="server" Text="D-2-W" CssClass="ListControl" ClientIDMode="Static" />
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
                                                                            <asp:CheckBox ID="EPI0" runat="server" Text="EPI" CssClass="ListControl" ClientIDMode="Static"/></span>
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
                                                                            CssClass="ListControl" ClientIDMode="Static" /></span>
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

                                                               
                                                               
                                                                
                                                               
                                                              
                                                               
                                                                                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td style="width:33%;">
                                        &nbsp;</td>
                            </tr>
                           
                        </table>
                        <div id="Quotationfade0">
                        
                                        <div style="border:1px solid black; width:100%; height:450px;" align="left">
                            <div style="width:100%;  text-align:center; ">
                            
                                <table style="width:100%; height: 493px;">
                                
                                    <tr>
                                        <td style="width:100%">
                                            <table style="width:100%;">
                                              
                                              <tr>
                                                    <td style=" width:11%;">
                                                        <label>Item No :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="ItemNo0" runat="server" Width="90%" ClientIDMode="Static">1</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                      <label>Product Ref :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductRef1" runat="server" Width="90%" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                              

                                                    <td style=" width:11%;">
                                                        <label>Quantity (PCS) :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="txtQuantity1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                        <label>Description :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductDec1" runat="server" Width="90%" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                        </td>
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                         <label>Pcs per carton :</label>
                                                    </td>
                                                    <td style="">
                                                       
                                                        <asp:TextBox ID="totalpcspercarton1" runat="server" Width="90%" ClientIDMode="Static"
                                                          >0</asp:TextBox>
                                                       
                                                    </td>
                                               
                                                    <td>
                                                       
                                                      <label>Block Per Carton :</label>  </td>
                                                    <td>
                                                    
                                                     <asp:TextBox ID="txtbpc0" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    
                                                       </td>
                                                    <td>
                                                    
                                                         <label>Pcs Per Block :</label></td>

                                                    <td>
                                                        <asp:TextBox ID="txtppb0" runat="server" Width="90%" ClientIDMode="Static"
                                                          >0</asp:TextBox>
                                                        </td>
                                                        <td><label>Outer Bag :</label></td>
                                                        <td>
                                                        <asp:TextBox ID="txtOuterBag0" runat="server" Width="90%" ClientIDMode="Static"
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
                                                        <asp:CheckBox ID="Digit3" runat="server" Text="2 Digit" ClientIDMode="Static" />
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
                                                        <asp:TextBox ID="Processingcost1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                               
                                                    <td style="">
                                                        <label>Printing Charge :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="printingCharge1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Freight Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Freightcost1" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td><label>Cylinder :</label></td>
                                                <td><asp:TextBox ID="Cylinder1" runat="server" Width="90%" Enabled="True" ClientIDMode="Static">0</asp:TextBox></td>
                                                    <td style="">
                                                         <label>
                                                        Carton Length:</label>
                                                    </td>
                                                    <td style="">
                                                <asp:TextBox ID="Length0" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                               
                                                <td>
                                                    <label>
                                                    Carton Height:</label></td>
                                                <td>
                                                <asp:TextBox ID="Height0" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                  <td>
                                                    <label>
                                                    Carton Width:</label></td>
                                                <td>
                                                <asp:TextBox ID="Width0" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    </tr>                                                  
                                                    
                                                <tr>
                                                    <td style="">
                                                      <label>Insurance :</label> 
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="insurance1" runat="server" Width="90%" Enabled="False" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                    <td style="">
                                                       
                                                        <label>
                                                        FOB Price :</label></td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_FobPrice1" runat="server" Width="90%" Enabled="False" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                
                                                <td style="">
                                                       
                                                      <label>
                                                      Total Price :</label>
                                                       
                                                      </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_totalPrice1" runat="server" Width="90%" Enabled="False" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                <td>
                                             <label>Kgs :</label>
                                                
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="Kgs1" runat="server" Width="90%" Enabled="False" ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                                                                      
                                                </tr>
                                                <tr>
                                                <td>
                                                
                                                    <label>
                                                    Carton :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="Carton1" runat="server" Width="90%" Enabled="False" ClientIDMode="Static"></asp:TextBox>
                                                
                                                </td>
                                                <td>
                                                
                                                    <label>
                                                    CBM :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="CBM0" runat="server" Width="90%" Enabled="False" ClientIDMode="Static"></asp:TextBox>
                                                
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='command_button_enabled' id='lnkCalculateWeight1' href='#' 
                                                            onclick="CalculateNetWeightPO(); return false;">Cal. Wgt.</a>
                                                    </td>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='command_button_enabled' id='A22'
                                                            onclick="CalculateTotalPricePO(); return false;" href='#'>Cal. Price</a>
                                                    </td>
                                                    <td colspan="2"> <br />
                                                     <a class='command_button_enabled' id='A20' href='#' 
                                    onclick="addProduct(); return false; ">Add Product</a>
                                                    </td>
                                                <td colspan="2">
                                                <br />
                                                    <a id="A21" class="command_button_enabled" href="#" 
                                                        onclick="AllclearPO(); return false; ">Clear</a></td>
                                                </tr>
                                                <tr>
                                                <td colspan="8">
                                                <div id="Restricted"style="width:100%;height:120px; overflow:scroll; border:1px solid blue;">
<table id="tblProductDetails1" style="width:150%; ">
                                        <thead>
                                        </thead>
                                        <tbody style="height:auto;">
                                            
                                        </tbody>
                                    </table>

       </div>
                                                </td>
                                                </tr>
                                                
                                              </table>
</td></tr></table>
    
       
                    </div>
</div>
</div></div></div></div>

