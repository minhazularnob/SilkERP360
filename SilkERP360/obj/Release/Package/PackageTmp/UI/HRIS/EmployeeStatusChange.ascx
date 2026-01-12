<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeStatusChange.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmployeeStatusChange" %>



<script src="../../Globals/Scripts/SilkERP360/HRIS/EmployeeStatusChange.js" type="text/javascript"></script>

<div id="dvBody" class="ui_control_wrapper" >
    <div id="cmd" style="width:99%;">
        
        <p class="login button"> 

            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />&nbsp;
            
        </p>
    
        
    </div>


<div id="ImagTab">
<center>
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
        <td style="width:30%">&nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td style="width:30%" align="right">
                    &nbsp;</td>
        <td style="width:30%">&nbsp;</td>
        </tr>        

        </table>
        </center>
    </div>
    <div id="OfficialTab"  ><!-- OFFICIAL TAB CONFIGURATION  class="center_div" -->
        <%--<center>--%>
        <table id="tblOfficial" style="width:100%; height:auto; table-layout: fixed;">
        
                      <tr>
                    <td style="width:25%" align="left">                    
                        &nbsp;</td>
                     <td style="width:15%" align="left">                    
                        <asp:Label ID="Label1" runat="server" Text="Employee ID">
                        </asp:Label>
                          </td>
                     <td style="width:32%" align="left">                    
                         <asp:TextBox ID="txt_emp_ID" runat="server" ClientIDMode="Static" ReadOnly="true" CssClass="input-required" PlaceHolder="Employee ID">
                         </asp:TextBox>
                          </td>
                     <td style="width:28%" align="left">                    
                         &nbsp;</td>
              </tr>
             <tr>
                    <td style="width:15%" align="left">
                        &nbsp;</td>
                  <td style="width:35%" align="left">                    
                        <asp:Label ID="Label2" runat="server" Text="Employee Name">
                        </asp:Label>
                    </td>
                 <td style="width:15%" align="left">                    
                         <asp:TextBox ID="txt_emp_Name" runat="server" ClientIDMode="Static" ReadOnly="true" 
                             CssClass="input-required" PlaceHolder="Emp. Name">
                         </asp:TextBox>
                    </td>
                 <td style="width:35%" align="left">                                    
                        &nbsp;</td>
              </tr>
              <tr>
                <td style="width:15%" align="left">                    
                        &nbsp;</td>
                 <td style="width:35%" align="left">                    
                         <asp:Label ID="Label72" runat="server" Text="Designation">
                         </asp:Label>
                   </td>
                 <td style="width:15%" align="left">                    
                         <asp:TextBox ID="txt_Designation" runat="server" ClientIDMode="Static" ReadOnly="true"
                            CssClass="input-required" PlaceHolder="Designation" >
                         </asp:TextBox>
                    </td>
                 <td style="width:35%" align="left">                    
                        &nbsp;</td>
            </tr>
            
                   <tr>
                <td style="width:15%" align="left">
                    
                    &nbsp;</td>
                 <td style="width:35%" align="left">
                    
                         <asp:Label ID="Label73" runat="server" Text="Department">
                         </asp:Label>
                       </td>
                 <td style="width:15%" align="left">
                    
                         <asp:TextBox ID="txt_Department" runat="server" ClientIDMode="Static" ReadOnly="true"
                             CssClass="input-required" PlaceHolder="Department" >
                         </asp:TextBox>
                       </td>
                 <td style="width:35%" align="left">
                    
                     &nbsp;</td>
              </tr>

            
                   <tr>
                <td style="width:15%" align="left">
                    
                    &nbsp;</td>
                 <td style="width:35%" align="left">
                    
                         <asp:Label ID="Label74" runat="server" Text="Status"></asp:Label>
                       </td>
                 <td style="width:15%" align="left">
                    
                         <asp:TextBox ID="txt_Currnt_status" runat="server" ClientIDMode="Static" ReadOnly="true"
                             CssClass="input-required" PlaceHolder="Current Status" >
                         </asp:TextBox>
                       </td>
                 <td style="width:35%" align="left">
                    
                     &nbsp;</td>
              </tr>

            
                   <tr>
                <td style="width:15%" align="left">
                    
                    &nbsp;</td>
                 <td style="width:35%" align="left">
                    
                         <asp:Label ID="Label76" runat="server" Text="Change Status To :"></asp:Label>
                       </td>
                 <td style="width:15%" align="left">
                    
                     <asp:DropDownList ID="ddl_Off_ChangeStatus" runat="server" ClientIDMode="Static"
                             CssClass="input-required" PlaceHolder="Change Status">
                             <asp:ListItem Value="0">----Select Change Status</asp:ListItem>
                                    <asp:ListItem Value="3">Resigned</asp:ListItem>
                                    <asp:ListItem Value="5">Terminated</asp:ListItem>
                                   
                         </asp:DropDownList>
                       </td>
                 <td style="width:35%" align="left">
                    
                     &nbsp;</td>
              </tr>
            
             <tr>
                    <td style="width:15%" align="left">                    
                        &nbsp;</td>
                 <td style="width:35%" align="left">
                    
                         <asp:Label ID="Label75" runat="server" Text="Effective Date">
                         </asp:Label>
                    </td>
                 <td style="width:15%" align="left">                    
                    
                         <asp:TextBox ID="txt_Efct_Date" runat="server" ClientIDMode="Static" 
                             CssClass="input-required" PlaceHolder="Effective Date" >
                         
                         </asp:TextBox>
                    </td>
                 <td style="width:35%" align="left">
                    
                     &nbsp;</td>
              </tr>
                      
    
    </table>
        <%--</center>--%>
    </div>