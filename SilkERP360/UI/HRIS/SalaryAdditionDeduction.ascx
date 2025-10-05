<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SalaryAdditionDeduction.ascx.cs" Inherits="SilkERP360.UI.HRIS.SalaryAdditionDeduction" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/SalaryAdditionDeduction.js" type="text/javascript"></script>


<div id="SalAddDEduc" style="width:100%;">
       
        
            
    </div>
    <center>
     <div id="ImagTab">

    <table id="tblphot" >    
        <tr>
        <td style="width:40%"></td>
        <td style="width:40%"></td>
        <td style="width:20%"></td>
        </tr>

        <tr>
        <td style="width:40%"></td>
        <td style="width:30%"></td>
        <td style="width:30%"></td>
        </tr>

        <tr>
        <td style="width:40%"></td>
        <td style="width:30%"></td>
        <td style="width:30%"></td>
        </tr>
        
        <tr>
        <td style="width:40%"></td>
        <td style="width:30%" height="35px"></td>
        <td style="width:30%"></td>
        </tr>

        <tr>
        <td colspan="3" style="width: 70%">
        
        </td>
        </tr>

        <tr>
        <td align="center" colspan="3">
                        &nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td style="width:30%" align="right">
                    <asp:Image ID="imgEmployeeImage" runat="server" ClientIDMode="Static" 
                        Height="159px" Width="160px" />
                        </td>
        <td style="width:30%">&nbsp;</td>
        </tr>         

        </table>
        </br>
      
        <table id="tblBod" style="width:98%; height:auto; table-layout: fixed; border:1px;">
        <tr>
        <td  style="width:15%" align="left">
                    
                    <asp:Label ID="Label8" runat="server" Text="Employee ID"></asp:Label>
                       </td>
        <td  style="width:25%" align="left">
                    
                                <asp:TextBox ID="txt_EmpID" runat="server" ClientIDMode="Static" ReadOnly="True" PlaceHolder="Employee ID" ></asp:TextBox>
                     
                                    </td>
                                    <td  style="width:15%" align="left">
                    
                    <asp:Label ID="Label10" runat="server" Text="Employee Name"></asp:Label>
                       </td>
        <td  style="width:25%" align="left">                    
                     
                                <asp:TextBox ID="txt_Sal_AddDed_EmpName" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Employee Name" >
                                </asp:TextBox>
                      
                                    </td>
        </tr>        
        
        
        <tr>
        <td  style="width:15%" align="left">
                    
                     <asp:Label ID="Label9" runat="server" Text="Designation"></asp:Label>
                       </td>
        <td  style="width:35%" align="left">
                    
                                <asp:TextBox ID="txt_Sal_AddDed_Designation" runat="server" 
                                    ClientIDMode="Static" PlaceHolder="Designation" ReadOnly="True" >
                                     </asp:TextBox>
                      
                </td>
                <td  style="width:15%" align="left">                    
                         <asp:Label ID="Label7" runat="server" Text="Department"> </asp:Label>
                     </td>
        <td  style="width:25%" align="left">                    
                     
                                <asp:TextBox ID="txt_Sal_AddDed_Department" runat="server" ReadOnly="True" 
                                    ClientIDMode="Static" PlaceHolder="Department"></asp:TextBox>
                      
                                 </td>
        </tr>        
       
        
        </table>
      
   </br>
      
    </div>


  <div id="dvBody" class="ui_control_wrapper" style="Width:99%;height:auto; margin:0 auto;">
        <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%; height:auto; table-layout: fixed; border:1px; margin:0 auto;" >
            <tr style="width:100%; height:auto; font-size:46px; font-weight:bold;">
                <td style="width:10%; text-align:center;">
                   <asp:Label ID="Label2" runat="server" Text="Date"></asp:Label>
                </td>
                <td style="width:10%; text-align:center;">
                   <asp:Label ID="Label62" runat="server" Text="Add/Ded"></asp:Label>
                </td>
                <td style="width:20%; text-align:center;">
                    Add/Ded Type
                </td>
                <td style="width:10%; text-align:center;">
                    <asp:Label ID="Label68" runat="server" Text="Eff. Month"></asp:Label>
                </td>
                <td style="width:10%; text-align:center;">
                    <asp:Label ID="Label1" runat="server" Text="Eff. Year"></asp:Label>
                </td>
                <td style="width:10%; text-align:center;">
                    <asp:Label ID="Label11" runat="server" Text="Amount"></asp:Label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:Label ID="Label67" runat="server" Text="Remarks"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:TextBox ID="txt_AddDed_Date" Width="90%" runat="server" ClientIDMode="Static" PlaceHolder="Date" style="text-align:center;">
                    </asp:TextBox>
                </td>
                <td  style="text-align:center;">
                    <asp:DropDownList ID="ddl_sal_AddOrDed"  Width="90%"  runat="server" class="input-required"
                                    ClientIDMode="Static" CssClass="input-required" PlaceHolder="Select Add/Ded">
                                    <asp:ListItem Value="0">----- Select</asp:ListItem>
                                    <asp:ListItem Value="1">Addition</asp:ListItem>
                                    <asp:ListItem Value="2">Deduction</asp:ListItem>
                                    </asp:DropDownList> 
                </td>
                <td style="text-align:center;">
                    <asp:DropDownList ID="ddl_sal_Addition" runat="server"  Width="94%" 
                                        class="input-required" ClientIDMode="Static" CssClass="input-required" 
                                        PlaceHolder="Addition">
                                            <asp:ListItem Value="0">Select Addition</asp:ListItem>
                    </asp:DropDownList> 
                    <asp:DropDownList ID="ddl_sal_Deduction" runat="server"  Width="94%" 
                                        class="input-required" ClientIDMode="Static" CssClass="input-required" 
                                        PlaceHolder="Deduction">
                                            <asp:ListItem Value="0">Select Deduction</asp:ListItem>                                    
                    </asp:DropDownList> 
                </td>
                <td style="text-align:center;">
                    <asp:DropDownList ID="ddl_sal_EffectMonth" runat="server"  Width="90%" 
                                                        class="input-required" ClientIDMode="Static" CssClass="input-required" 
                                                        PlaceHolder="Effective Month">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList> 
                </td>
                <td style="text-align:center;">
                    <asp:DropDownList ID="ddl_sal_EffectYear" runat="server"  Width="90%" class="input-required" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Effective Year">
                                    <asp:ListItem Value="2014">2014</asp:ListItem>
                                    <asp:ListItem Value="2015">2015</asp:ListItem>
                                    <asp:ListItem Value="2016">2016</asp:ListItem>
                                    <asp:ListItem Value="2017">2017</asp:ListItem>
                                    <asp:ListItem Value="2018">2018</asp:ListItem>
                                    <asp:ListItem Value="2019">2019</asp:ListItem>
                                    <asp:ListItem Value="2020">2020</asp:ListItem>
                                    <asp:ListItem Value="2021">2021</asp:ListItem>
                                    <asp:ListItem Value="2022">2022</asp:ListItem>
                                    <asp:ListItem Value="2023">2023</asp:ListItem>
                                    <asp:ListItem Value="2024">2024</asp:ListItem>
                                    <asp:ListItem Value="2025">2025</asp:ListItem>
                    </asp:DropDownList> 
                </td>
                <td style="text-align:center;">
                    <asp:TextBox ID="txt_Sal_AddDed_Amount" runat="server"  Width="90%" style="text-align:right;" 
                                    ClientIDMode="Static" CssClass="input-required" PlaceHolder="0.0" 
                                    ReadOnly="false">
                    </asp:TextBox>
                </td>
                <td style="text-align:center;">
                    <asp:TextBox ID="txt_Sal_AddDedRemarks" runat="server" ClientIDMode="Static" Width="95%" PlaceHolder="Remarks">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="7" align="right" style="text-align:right;width:100%; padding:5px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ClientIDMode="Static" OnClientClick="Save();return false;" style="width:120px;" />
                    <asp:Button ID="btnLoad" runat="server"  ClientIDMode="Static" OnClientClick="LoadSalaryAddition();return false;" Text="Show Detail"  style="width:120px;"/>
                </td>
            </tr>
        </table>   
            
  </div>
  <br />                    

        <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblEmployeeList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    <%--</div>--%>
     </div>
    </center>
    
   