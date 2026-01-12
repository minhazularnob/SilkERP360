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
                         
            .MasterBatchInk
            {
                width: 40%;
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
             
            .style52
    {
        height: 30px;
    }
    .style53
    {
        width: 18%;
        height: 30px;
    }
            .style22
        {
            font-size: x-small;
            font-weight: bold;
        }
            </style>

<div id="dvItemConfig" style="width:90%; border:1px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;height:auto">
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
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />

                        <div id="tbpPriceQuotation" style=" width:100%; margin:0 auto;">
                            <!--Price Quotation-->
                            <table style="width:100%; margin:0 auto;">

                            <tr>
                            <td>
                            
                                                        <a class='command_button_enabled' id='A11'
                                                            onclick="POSave(); return false;" href='#'>Save</a>
                                                            <br />
                                                            <br />
                                                            <br />
                                                            <asp:CheckBox ID="chkQuotation" runat="server" CssClass="ListControl" 
                                                                Text=" Quotation" ClientIDMode="Static" />
                                                        
                                                        </div>
                                                            </td>
                            </tr>
                                <tr>
                                    <td colspan="2" class="style44">
                                    <div>
                                    
                                                        </div>
                                                       
                                                        
                                                            
                                                        <br />
                                                        <div align="center">
                                                        <table id="Quotation"style="width:50%">
                                                        <tr>
                                                        <td style="width:40%">
                                                        
                                                            <asp:Label ID="Label1" runat="server" Text="Quotation Code"></asp:Label>
                                                        
                                                        </td>
                                                        <td>
                                                        
                                                            <asp:DropDownList ID="ddlQuotation" runat="server" ClientIDMode="Static">
                                                                <asp:ListItem>.....Select Quotation Code.....</asp:ListItem>
                                                            </asp:DropDownList>
                                                        
                                                        </td>
                                                        </tr>
                                                        </table></div>
                                        <table style="width:50%; margin:0 auto;" id="tblpoinfo">
                                        <tr><td colspan="2">
                                            &nbsp;</td></tr>
                                            <tr>
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
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Catagory:</label>
                                                </td>
                                                <td style=" width:70%;">
                                                        
                                                            <asp:DropDownList ID="ddlCatagory" runat="server"
                                                                ClientIDMode="Static">
                                                                <asp:ListItem Value="0">....Select Catagory....</asp:ListItem>
                                                            </asp:DropDownList>
                                                        
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style=" width:30%;">
                                                    <label>Specification :</label>
                                                </td>
                                                <td style=" width:70%;">
                                                        
                                                            <asp:DropDownList ID="ddlItemSpec" runat="server" 
                                                                ClientIDMode="Static">
                                                                <asp:ListItem Value="0">....Select Items Specification....</asp:ListItem>
                                                            </asp:DropDownList>
                                                        
                                                </td>
                                            </tr>
                                           <tr>
                                           <td>
                                           <label>Buyer Requirements :</label>
                                           </td>
                                           <td>
                                               <asp:TextBox ID="txtCustomeReq" runat="server" TextMode="MultiLine" 
                                                   ClientIDMode="Static"></asp:TextBox>
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
                                    
                                    <td id="RawMaterialPrice" colspan="2"style="text-align:center;width:100%;">
                                        <div style="border:1px solid black; width:80%; height:auto; margin:0 auto;">
                                            <table style="width:100%; height:auto;">
                                                <tr>
                                                    <td style="width:100%;">
                                                        <h1>Raw Materials</h1>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td style="width:99%;">
                                                        <div>
                                                            <table cellpadding="1px" style="width:100%; margin:0 auto; padding:1px;">
                                                               
                                                               
                                                                <tr style="width:100%;">
                                                                    <td style="width:50%; padding:1px; text-align:left;">
                                                                       <table style=" width:100%">
                                                                     <label>Main Product :</label>
                                                                       <tr>
                                                                       <td style="width:50%;">
                                                                       
                                                                          
                                                                       
                                                                           <asp:CheckBox ID="HD" runat="server" Text="HD" CssClass="ListControl" ClientIDMode="Static"/>
                                                                       
                                                                          
                                                                       
                                                                       </td>

                                                                       <td style="width:50%;">
                                                                       
                                                                          
                                                                       
                                                                           <asp:CheckBox ID="LD" runat="server" Text="LD" CssClass="ListControl " ClientIDMode="Static"/>
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
                                                                        <asp:CheckBox ID="HDPE" runat="server" Text="HDPE" CssClass="ListControl" ClientIDMode="Static" />
                                                                      
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
                                                                        <asp:CheckBox ID="LLDPE" runat="server" Text="LLDPE" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                      
                                                                            <asp:CheckBox ID="COCO" runat="server" Text="COCO" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                       
                                                                            <asp:CheckBox ID="LDPE" runat="server" Text="LDPE" CssClass="ListControl" ClientIDMode="Static"/></span>
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                <div id ="checkMasterbatch" style="border-style: dotted;">
                                                                                                                                  
                                                                        <div style=" margin-top:5px;  text-align: left;">
                                                                            <table style="width:100%;">
                                                                                <tr>
                                                                                    <td style="width:30%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkwhite" runat="server" Text="White" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkblue" runat="server" Text="Blue" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkRed" runat="server" Text="Red" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkYellow" runat="server" Text="Yellow" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLory" runat="server" Text="Lory" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBeige" runat="server" Text="Beigendy" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkPink" runat="server" Text="Pink" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBgendy" runat="server" Text="Bgendy" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkLgrass" runat="server" Text="Lemon Grass" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkBlack" runat="server" Text="Black" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                    
                                                                                        <asp:TextBox ID="TextBox8" runat="server" ClientIDMode="Static" Enabled="False" ReadOnly="true" 
                                                                                            style="text-align:center;" Text="" Width="90%"></asp:TextBox>
                                                                                    
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width:25%; text-align:left;">
                                                                                        <%--<asp:CheckBox ID="chkMasterBase_NPQ" CssClass="chk_box" runat="server" Text="     Master Base" />--%>
                                                                                        <asp:CheckBox ID="chkOrange" runat="server" Text="Orange" 
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            Enabled="False" ReadOnly="true" 
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
                                                                        <asp:CheckBox ID="chkInk" runat="server" Text="Ink" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
                                                                                       
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
                                                                                        <asp:CheckBox ID="chkinkyellow" runat="server" Text="Lemon Yellow" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                        <asp:CheckBox ID="chkinkrblue" runat="server" Text="Royal Blue" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                        <asp:CheckBox ID="chkinkmdorange" runat="server" Text="MolibDate Orange" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                        <asp:CheckBox ID="chkInkgrassgreen" runat="server" Text="Grass Green" CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                                            CssClass="ListControl" ClientIDMode="Static"/>
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
                                                                            CssClass="ListControl" ClientIDMode="Static"/>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="TextBox1" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="TextBox2" runat="server"  Width="70%" 
                                                                            Text=""  ReadOnly="true"  style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False" CssClass="raw_mat_prc"></asp:TextBox>
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
                                                                        <asp:CheckBox ID="D2W" runat="server" Text="D-2-W" CssClass="ListControl" ClientIDMode="Static"/>
                                                                        <span class="style21"></span></td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Percentage" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_Price" runat="server"  
                                                                            Width="70%" Text=""  ReadOnly="true" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False" CssClass="raw_mat_prc"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="txtD2W_NPQ_StandardPrice" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;" class="style52">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="EPI" runat="server" Text="EPI" CssClass="ListControl" ClientIDMode="Static"/></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style53">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Percentage" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;" class="style52">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Price" runat="server"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False" CssClass="raw_mat_prc"></asp:TextBox>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;" class="style52">
                                                                        <asp:TextBox ID="txtEPI_NPQ_Standard_Price" runat="server" Width="70%"  
                                                                            ReadOnly="true" style="text-align:center;"  ClientIDMode="Static" 
                                                                            Enabled="False"></asp:TextBox>
                                                                    </td>
                                                                </tr>

                                                                 <tr>
                                                                    <td style="padding:1px; text-align:left;">
                                                                        <%--<asp:CheckBox ID="chkEPI_NPQ" CssClass="chk_box" runat="server" Text="EPI"  ClientIDMode="Static" />--%>
                                                                        <span class="style21">
                                                                            <asp:CheckBox ID="chkEntiSlip" runat="server" Text="Anti Slip" CssClass="ListControl" ClientIDMode="Static"/></span>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:left;" class="style28">
                                                                        <asp:TextBox ID="EntiSlipin" runat="server" 
                                                                            CssClass="raw_mat_prcntge float_only"  Width="70%" style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False"></asp:TextBox><label>%</label>
                                                                    </td>
                                                                    <td style="padding:1px; text-align:center;">
                                                                        <asp:TextBox ID="EntiSlipout" runat="server"  
                                                                            Width="70%" Text=""  ReadOnly="true"  style="text-align:center;"  
                                                                            ClientIDMode="Static" Enabled="False" CssClass="raw_mat_prc"></asp:TextBox>
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
                                   
                            </tr>
                           
                        </table></div>
                        <br />
                        <div id="Quotationfade">
                       
                                        <div style="border:1px solid black; width:99%; height:585px;" align="left">
                            <div style="width:98%;  text-align:center; ">
                            <div>
                            

                            </div>
                             <br />
                                            <table class="table_ip_control_container" style="width:100%;">
                                              
                                              <tr>
                                                    <td style=" width:11%;">
                                                        <label>Item No :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="ItemNo" runat="server" Width="90%" ClientIDMode="Static">1</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                      <label>Product Ref :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductRef" runat="server" Width="90%" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                              

                                                    <td style=" width:11%;">
                                                        <label>Quantity (PCS) :</label>
                                                    </td>
                                                    <td style=" width:10%;">
                                                        <asp:TextBox ID="txtQuantity" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style=" width:11%;">
                                                        <label>Description :</label>
                                                    </td>
                                                    <td  style=" width:10%;">
                                                        <asp:TextBox ID="txt_ProductDec" runat="server" Width="90%" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                        </td>
                                                </tr>


                                                <tr>
                                                    <td style="">
                                                         <label>Pcs of per carton :</label>
                                                    </td>
                                                    <td style="">
                                                       
                                                        <asp:TextBox ID="totalpcspercarton" runat="server" Width="90%" ClientIDMode="Static" 
                                                          >0</asp:TextBox>
                                                       
                                                    </td>
                                               
                                                    <td>
                                                       
                                                      <label>Block Per Carton :</label>  </td>
                                                    <td>
                                                    
                                                     <asp:TextBox ID="txtbpc" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    
                                                       </td>
                                                    <td>
                                                    
                                                         <label>Pcs of Per Block :</label></td>

                                                    <td>
                                                        <asp:TextBox ID="txtppb" runat="server" Width="90%" ClientIDMode="Static" 
                                                          >0</asp:TextBox>
                                                        </td>
                                                        <td><label>Outer Bag :</label></td>
                                                        <td>
                                                        <asp:TextBox ID="txtOuterBag" runat="server" Width="90%" ClientIDMode="Static" 
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
                                                        <asp:CheckBox ID="Digit2" runat="server" Text="2 Digit" ClientIDMode="Static" />
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
                                                        <asp:TextBox ID="Processingcost" runat="server" Width="90%" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                               
                                                    <td style="">
                                                        <label>Printing Charge :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="printingCharge" runat="server" Width="90%" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    <td style="">
                                                        <label>Freight Cost :</label>
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="Freightcost" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td><label>Cylinder :</label></td>
                                                <td><asp:TextBox ID="Cylinder" runat="server" Width="90%" Enabled="True" 
                                                        ClientIDMode="Static">0</asp:TextBox></td>
                                                    <td style="">
                                                         <label>
                                                        Carton Length:</label>
                                                    </td>
                                                    <td style="">
                                                <asp:TextBox ID="Length" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                               
                                                <td>
                                                    <label>
                                                    Carton Height:</label></td>
                                                <td>
                                                <asp:TextBox ID="Height" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                  <td>
                                                    <label>
                                                    Carton Width:</label></td>
                                                <td>
                                                <asp:TextBox ID="Width" runat="server" Width="90%" ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                    </tr>                                                  
                                                    
                                                <tr>
                                                    <td style="">
                                                      <label>Insurance :</label> 
                                                    </td>
                                                    <td style="">
                                                        <asp:TextBox ID="insurance" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                    <td style="">
                                                       
                                                        <label>
                                                        FOB Price :</label></td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_FobPrice" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>
                                                
                                                <td style="">
                                                       
                                                      <label>
                                                      Total Price :</label>
                                                       
                                                      </td>
                                                    <td style="">
                                                        <asp:TextBox ID="txt_totalPrice" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static">0</asp:TextBox>
                                                    </td>

                                                <td>
                                             <label>Kgs :</label>
                                                
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="Kgs" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                    </td>
                                                                                                      
                                                </tr>
                                                <tr>
                                                <td>
                                                
                                                    <label>
                                                    Carton :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="Carton" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                
                                                </td>
                                                <td>
                                                
                                                    <label>
                                                    CBM :</label></td>
                                                <td>
                                                
                                                        <asp:TextBox ID="CBM" runat="server" Width="90%" Enabled="False" 
                                                            ClientIDMode="Static"></asp:TextBox>
                                                
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='command_button_enabled' id='lnkCalculateWeight' href='#' 
                                                            onclick="CalculateNetWeight(); return false;">Cal. Wgt.</a>
                                                    </td>
                                                    <td colspan="2" style=" width:100%; text-align:center;">
                                                        <br />
                                                        <a class='command_button_enabled' id='A1'
                                                            onclick="CalculateTotalPrice(); return false;" href='#'>Cal. Price</a>
                                                    </td>
                                                    <td colspan="2" align="center"><br />
                                                     <a class='command_button_enabled' id='A10' href='#' 
                                                            onclick="addProduct(); return false; ">Add Product</a>
                                                    </td>

                                                    <td align="center"><br />
                                                                                 <a class='command_button_enabled' id='A5' href='#' 
                                                            onclick="Allclear(); return false; ">New</a>
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
                                                        <asp:TextBox ID="txt_ComName" runat="server" Width="90%" ClientIDMode="Static"></asp:TextBox>
                                                        
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

                                               <tr>
                                              <td>
                                                 <label>Amount:</label>
                                                </td>
                                                <td>
                                                        <asp:TextBox ID="txt_ComAmount" runat="server" Width="90%" 
                                                        ClientIDMode="Static">0</asp:TextBox>
                                                </td>
                                                </tr>                                              
                                                <tr>
                                                <td colspan="8">
                                                <br/>
                                                <div id="Restricted"style="width:100%;height:200px; overflow:scroll; border:1px solid blue;">
                                   
                                    <table id="tblProductDetails" style="width:150%;">
                                        <thead>
                                        </thead>
                                        <tbody style="height:auto;">
                                            
                                        </tbody>
                                    </table>
                                    </div>
                                                </td>
                                                </tr>
                                                </table>
                                     
                                </div> 
                                

    <br />
                                   
                                    
                               
                           <table>      <tr>
            <!--QC Test Body-->
            <td style="width:100%; height:auto;">
                <div id="dvItems" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <table id="tblItems">
                    </table>
                </div>
            </td>
        </tr>
        </table>

       <div>
       </div>
       <div>
       
                    </div>

                            

