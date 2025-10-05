<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Department.ascx.cs" Inherits="SilkERP360.UI.HRIS.Department" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/Department.js" type="text/javascript"></script>

<div id="Department" style="width:100%;">
        
        <h1> DEPARTMENT</h1>
        <p class="login button">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false" style="width:70px;" />
             </p>

</div>
<br />


    <div id="DvDepartment" style="Width:99%;height:1024px; margin:0 auto;">
        <table id="tblDepartment" style="width:100%; height:auto; table-layout:fixed;" >
            <tr>
                    <td style="width:15%">    
                        <asp:Label ID="Label1" runat="server">Department Name : </asp:Label>
    
                    </td>
                    <td style="width:85%">
                        <asp:TextBox ID="txt_DptName" runat="server" ClientIDMode="Static" CssClass="input required" PlaceHolder="Department Name" ReadOnly="false">
                        </asp:TextBox>

                    </td>
    </tr>


    <tr>
    <td colspan="2">  
    <table style="width:98%; height:auto; table-layout: fixed; border:1px;">

       <tr>
                <td style="width:15%">
                    
                        <asp:Label ID="Label2" runat="server">Short Name : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_ShortName" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Short Name" ReadOnly="false">
                        </asp:TextBox>
                 </td>
                 <td style="width:15%">
                    
                        <asp:Label ID="Label4" runat="server">Head Employee ID : </asp:Label>
                       </td>
                 <td style="width:35%">
                    
                        <asp:TextBox ID="txt_HdEmpCode" runat="server" ClientIDMode="Static" 
                            CssClass="input required" PlaceHolder="Head Employee Code" ReadOnly="false">
                        </asp:TextBox>
                                </td>
              </tr>            
              
                                    
    </table>   
    </td>
    </tr>
    </table> 

         <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblDepartmentList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    </div>
    </div>


