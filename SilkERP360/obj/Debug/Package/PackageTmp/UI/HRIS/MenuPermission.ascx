<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuPermission.ascx.cs" Inherits="SilkERP360.UI.HRIS.MenuPermission" %>


<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/MenuPermission.js" type="text/javascript"></script>

<div id="Department" style="width:100%;">
        
        <h1> Menu Permission</h1>
        <p class="login button">
            
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false" style="width:70px;" />
             </p>

</div>

<div id="DvMenu" style="Width:100%;height:1024px; margin:0 auto;">
        
    <table style="width:100%; height:auto; table-layout: fixed; border:1px;">

     <tr>
                    <td style="width:15%">    
                        <asp:Label ID="Label3" runat="server">User ID : </asp:Label>
    
                    </td>
                    <td style="width:35%">
                        <asp:DropDownList ID="ddl_MenuUserID" runat="server" ClientIDMode="Static" 
                             CssClass="input-required" PlaceHolder="Menu User ID">
                             <asp:ListItem Value="0">----Select Menu User ID</asp:ListItem>
                         </asp:DropDownList>   

                    </td>
                    <td style="width:15%">
                    
                        <asp:Label ID="Label7" runat="server">Module Name : </asp:Label>
                       </td>
                 <td style="width:35%">                   
                       
                        <asp:DropDownList ID="ddl_ModuleName" runat="server" ClientIDMode="Static" 
                             CssClass="input-required" PlaceHolder="Module Name">
                             <asp:ListItem Value="0">----Select Module Name</asp:ListItem>
                         </asp:DropDownList>
                 </td>
    </tr>

       <tr>
                <td style="width:15%">
                    
                        <asp:Label ID="Label2" runat="server">Company Name : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_CompanyName" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Company Name" ReadOnly="true">
                        </asp:TextBox>
                 </td>
                 <td style="width:15%">
                    
                        <asp:Label ID="Label4" runat="server">Name : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_Name" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Name" ReadOnly="true">
                        </asp:TextBox>
                                </td>
              </tr>            
              
                                    
       <tr>
                <td style="width:15%">
                    
                        <asp:Label ID="Label5" runat="server">Designation : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_Designation" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Designation" ReadOnly="true">
                        </asp:TextBox>
                                </td>
                 <td style="width:15%">
                    
                        <asp:Label ID="Label6" runat="server">Department : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_Department" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Department" ReadOnly="true">
                        </asp:TextBox>
                                </td>
              </tr>            
              
                                    
    </table>   
    

    <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>
          
            <table id="tblMenuPermissionList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
                
            </table>
        </div>
        
    </div>
    </div>



