<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewLeaveApplication.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewLeaveApplication" %>

<script src="../../Globals/Scripts/SilkERP360/HRIS/NewLeaveApplication.js" type="text/javascript"></script>


    <div id="cmd" style="width:99%;">
         <p class="login button"> 
           
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="SaveLeaveApplication(); return false;" style="width:70px;" />&nbsp;
            <%--<asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />--%>
        </p>
            
    </div>
    </br>

<div id="tblLevApplication">
<center>
<table id="tblLeaveApplication"  style="width:100%; height:auto; table-layout: fixed;">
    <tr><td style="text-align:left; width:15%;">
    <asp:Label ID="Label59" runat="server" Text="EmployeeID"></asp:Label> </td>
        <td style="width:35%; text-align:left">
            <asp:TextBox ID="txt_Lve_EmpID" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Employee ID" CssClass="input-required">
            </asp:TextBox>
        </td>
        <td style="text-align:left; width:15%;">
        <asp:Label ID="Label1" runat="server" Text="Employee Name">
        </asp:Label>
        </td>
        <td style="width:35%; text-align:left">
            <asp:TextBox ID="txt_Lve_EmpName" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Employee Name" CssClass="input-required">
            </asp:TextBox>
        </td>
    </tr>

    <tr>
    <td style="text-align:left; width:15%;"><asp:Label ID="Label2" runat="server" Text="Department"></asp:Label></td>
        <td style="width:35%; text-align:left">
            <asp:TextBox ID="txt_Lve_Department" runat="server" ClientIDMode="Static" PlaceHolder="Department" ReadOnly="true" >
            </asp:TextBox>
        </td>
        <td style="text-align:left; width:15%;"> <asp:Label ID="Label3" runat="server" Text="Designation"></asp:Label></td>
        <td style="width:35%; text-align:left">
            
            <asp:TextBox ID="txt_Lve_Designation" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Designation" CssClass="input-required">
            </asp:TextBox>
            
        </td>
    </tr>
                       
    <tr>
    <td style="text-align:left; width:25%;"><asp:Label ID="Label4" runat="server" Text="Company Name"></asp:Label></td>
        <td style="width:35%; text-align:left">
            <asp:TextBox ID="txt_Lve_Company" runat="server" ClientIDMode="Static" PlaceHolder="Company Name" ReadOnly="true">
            </asp:TextBox>
        </td>
        <td style="text-align:left; width:25%;">
        <asp:Label ID="Label5" runat="server" Text="Joining Date">
        </asp:Label>
        </td>
        <td style="text-align:left; width:35%;">
           
            <asp:TextBox ID="txt_Lve_JoinDate" runat="server" ReadOnly="true" ClientIDMode="Static" onkeypress='return IsDouble(event)' PlaceHolder="Joining Date">
            </asp:TextBox>
           
        </td>
    </tr>
</table>
</center>
</div>

                        </br></br>

<div id="tblLeave" style="width:100%; height:auto;">
<center>
<caption style="width:100%; text-align:center">                       
                                <h2>Leave Details</h2>                           
                                </caption>
<table id="tblLeaveDetails" runat="server"  style="border:2px; border-color:Blue; width:100%;">

                                

    <tr style="font-weight:bold;">
        <td align="center" width="25%">
            Type Of Leave</td>
        <td align="center" width="25%">
            Due</td>
        <td align="center" width="25%">
            Taken</td>
        <td align="center" width="25%">
            Balance</td>
    </tr>
    </table>
</center>
</div>
                            </br>

<div id="tldLeave" style="width:100%; height:auto;">
<center>
<table style="width:100%; height:auto; table-layout:fixed;">
<tr>
<td style="width:15%" align="left">                    
                    
                    <asp:Label ID="Label60" runat="server" Text="Leave Type"></asp:Label>
                       </td>
                     <td style="width:35%" align="left">                    
                                    <asp:DropDownList ID="ddl_LeaveType_id" runat="server" 
                                        ClientIDMode="Static" PlaceHolder="Leave Type" 
                                        CssClass="input-required">
                                        <asp:ListItem Value="0">----- Select Leave Type</asp:ListItem>
                                    </asp:DropDownList>
                     </td>
                     <td style="width:15%" align="left">                    
                         <asp:Label ID="Label7" runat="server" Text="Leave Category">
                         </asp:Label>
                     </td>
                     <td style="width:35%" align="left">                    
                            <asp:DropDownList ID="ddl_Lev_Category" runat="server"
                                ClientIDMode="Static" CssClass="input-required" PlaceHolder="Shift" >                                
                                <asp:ListItem Value="0">----- Select Leave Category</asp:ListItem>
                                <asp:ListItem Value="1">Paid</asp:ListItem>
                                <asp:ListItem Value="2">Unpaid</asp:ListItem>
                            </asp:DropDownList>
                                 </td>
              </tr>
             <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label8" runat="server" Text="Leave From Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                            <asp:TextBox ID="txt_Leave_from_date" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Leave From Date"></asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label9" runat="server" Text="Leave Upt To Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                            <asp:TextBox ID="txt_Leave_to_date" runat="server" ClientIDMode="Static" 
                                PlaceHolder="Leave Up To Date" ReadOnly="true" ></asp:TextBox>
                </td>
              </tr>            
              <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label10" runat="server" Text="Joining Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">                    
                           <asp:TextBox ID="txt_join_date" runat="server" CssClass="input-required" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Joining Date">
                            </asp:TextBox> 
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label11" runat="server" Text="Total Leaves"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                            <asp:TextBox ID="txt_lve_total_days" runat="server" ReadOnly="true" ClientIDMode="Static" style="margin-left: 0px" PlaceHolder="Total Leaves"></asp:TextBox>
                                </td>
              </tr>            
               <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label12" runat="server" Text="Leave Reason"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                            <asp:TextBox ID="txt_leave_reason" runat="server" cssClass="input-required" 
                            ReadOnly="false" ClientIDMode="Static"
                            PlaceHolder="Leave Reason"></asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label13" runat="server" Text="Replacement ID"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">                    
                                <asp:DropDownList ID="ddl_emp_Replacmnt" runat="server" ClientIDMode="Static" PlaceHolder="Replacement ID" CssClass="input-required">
                                        <asp:ListItem Value="0">----- Employee Replacement ID</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
              
</table>
</center>
</div>




