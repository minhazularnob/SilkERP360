<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewLeaveApproved.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewLeaveApproved1" %>

<style type="text/css">
    .style1
    {
        height: 23px;
    }
</style>

<script src="../../Globals/Scripts/SilkERP360/HRIS/NewLeaveApproved.js" type="text/javascript"></script>

 <div id="cmdSave" style="width:100%;">
       
       <h1>&nbsp;EMPLOYEE LEAVE APPROVAL FORM</h1>
        <p class="login button"> 
           
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="SaveLeaveApprover();return false;" style="width:70px;" />
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>
            
    </div>

<center>
<div id="LveCategory">

<table id="tblLevApplicition" style="width:100%; height:auto; table-layout: fixed;">
<tr><td>
<table id="tbl_lveCategory" style="height:auto; width:100%">
    <tr>
        <td style="width:15%; text-align:left;">
            <asp:Label ID="Label1" runat="server" Text="Rec.Status :"></asp:Label>
            </td>
            <td style="width:35%; text-align:left;">
                <asp:TextBox ID="txt_Lve_RecStatus" runat="server" ClientIDMode="Static" 
                    PlaceHolder="Rec. Status" ReadOnly="True"></asp:TextBox>
            </td>
            <td style="width:15%; text-align:left;">
               <asp:Label ID="Label2" runat="server" Text="Rec.By :"></asp:Label></td>
            <td style="width:35%; text-align:left;">
                <asp:TextBox ID="txt_Lve_RecBy" runat="server" ClientIDMode="Static" 
                    PlaceHolder="Rec. By" ReadOnly="True" ></asp:TextBox>
                </td>
    </tr>
    <tr>
        <td style="width:15%; text-align:left;">
            <asp:Label ID="Label102" runat="server" Text="Approval Category"></asp:Label></td>
            <td style="width:35%; text-align:left;">
               <asp:DropDownList ID="ddl_Lev_Category" runat="server" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Shift">
                <asp:ListItem Value="0">----- Select Approval Category</asp:ListItem>
                    <asp:ListItem Value="1">Paid</asp:ListItem>
                     <asp:ListItem Value="2">Unpaid</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width:15%; text-align:left;">
                <asp:Label ID="Label103" runat="server" Text="Approval Mode"></asp:Label></td>
            <td style="width:35%;; text-align:left; margin-left: 120px;">
               <asp:DropDownList ID="ddl_Lev_CategoryBMode" runat="server" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Shift">
                <asp:ListItem Value="0">----- Select Approval Mode</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                     <asp:ListItem Value="2">Rejected</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
</td>
</tr>

<tr><td>
<center>
<caption style="width:100%; text-align:center">                    
                                 <h2>Leave History</h2>                          
                                </caption>    
<table id="tblLeaveDetails" runat="server" style="border:2px; border-color:Blue; width:100%;">
          

    <tr style="font-weight:bold;">
        <td align="center" width="25%" class="style1">
            Type Of Leave</td>
        <td align="center" width="25%" class="style1">
            From Date</td>
        <td align="center" width="25%" class="style1">
            To Date</td>
        <td align="center" width="25%" class="style1">
            Number Of Days</td>
    </tr>
    </table>

</center>
</td>
</tr>

<tr><td>
<center>
 
    <table id="tblLeaveApplication"  style="width:100%; height:auto; table-layout: fixed;">

     <tr>
             <td style="text-align:left; width:15%;">
                 <asp:Label ID="Label11" runat="server" Text="Company">
                 </asp:Label> 
             </td>
        <td style="text-align:left; width:85%;">
            <asp:TextBox ID="txt_Lve_Company" runat="server" ClientIDMode="Static" PlaceHolder="Company Name" ReadOnly="True" >
            </asp:TextBox>
        </td>
    </tr>

     <tr><td style="text-align:left; width: 15%" class="style2"><asp:Label ID="Label7" runat="server" Text="Department"></asp:Label> </td>
        <td style="width:85%; text-align:left">
            <asp:TextBox ID="txt_Lve_Department" runat="server" ClientIDMode="Static" PlaceHolder="Department" ReadOnly="True">
            </asp:TextBox>
        </td>
    </tr>

   
    </table>
    <table id="tblEmp" style="width:100%; height:auto; table-layout: fixed;">

        <tr>
            <td style="text-align:left; width: 15%" class="style6">
                <asp:Label ID="Label93" runat="server" Text="EmployeeID">
                </asp:Label> </td>
            <td style="width:35%; text-align:left">
                <asp:TextBox ID="txt_Lve_EmpID" runat="server" ReadOnly="True" 
                ClientIDMode="Static" PlaceHolder="Employee ID" 
                CssClass="input-required">
                </asp:TextBox>
            </td>

            <td style="text-align:left; width: 15%" >
                <asp:Label ID="Label3" runat="server" Text="Name">
                </asp:Label>
            </td>
            <td align="left" width="35%">
            <asp:TextBox ID="txt_Lve_EmpName" runat="server" ReadOnly="True" ClientIDMode="Static" PlaceHolder="Employee Name" CssClass="input-required"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
            <td style="text-align:left; width:15%">
                <asp:Label ID="Label4" runat="server" Text="Designation">
                </asp:Label></td>
            <td style="width:35%; text-align:left">
            
            <asp:TextBox ID="txt_Lve_Designation" runat="server" ReadOnly="True" ClientIDMode="Static" PlaceHolder="Designation" CssClass="input-required">
            </asp:TextBox>
            
        </td>
        <td style="text-align:left; width: 15%" >
                    <asp:Label ID="Label5" runat="server" Text="Joining Date">
                    </asp:Label>
        </td>
        <td style="width:35%; text-align:left">
           
            <asp:TextBox ID="txt_Lve_JoinDate" runat="server" ReadOnly="True" 
                ClientIDMode="Static" PlaceHolder="Joining Date">
                </asp:TextBox>
           
        </td></tr>
    
    <tr>
    <td style="width:15%; text-align:left"> 
    <asp:Label ID="Label94" runat="server" Text="Leave Type">
    </asp:Label></td>
        <td style="width:35%; text-align:left">
            
                            <asp:TextBox ID="txt_LeaveType" runat="server" ReadOnly="true" 
                                ClientIDMode="Static"
                                        PlaceHolder="Leave Type"></asp:TextBox>
            
        </td>
        <td style="width:15%; text-align:left">
            <asp:Label ID="Label95" runat="server" Text="Leave Category">
            </asp:Label>
            </td>
        <td style="width:35%; text-align:left">
           
                            <asp:TextBox ID="txt_lve_Category" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Leave Category">
                                </asp:TextBox>
                            
        </td></tr>
    
    <tr>
    <td style="width:35%; text-align:left"> 
    <asp:Label ID="Label101" runat="server" Text="Leave From Date">
    </asp:Label>
    </td>
        <td style="width:35%; text-align:left">
            
                            <asp:TextBox ID="txt_Leave_from_date" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Leave From Date">
                                </asp:TextBox>
            
        </td>
        <td style="width:35%; text-align:left">
        <asp:Label ID="Label96" runat="server" Text="Leave Up To Date">
        </asp:Label>
        </td>
        <td style="width:35%; text-align:left">
           
                            <asp:TextBox ID="txt_Leave_to_date" runat="server" ClientIDMode="Static" 
                                PlaceHolder="Leave Up To Date" ReadOnly="true" >
                                </asp:TextBox>
                            
        </td></tr>
    
    <tr>
    <td style="width:15%; text-align:left"> 
    <asp:Label ID="Label100" runat="server" Text="Joining Date">
    </asp:Label>
    </td>
        <td style="width:35%; text-align:left">
            
                           <asp:TextBox ID="txt_join_date" runat="server"  ReadOnly="true" 
                            ClientIDMode="Static" PlaceHolder="Joining Date">
                            </asp:TextBox> 
            
        </td>
        <td style="width:15%; text-align:left">
        <asp:Label ID="Label97" runat="server" Text="Total Leaves">
        </asp:Label>
        </td>
        <td style="width:35%; text-align:left">
           
                            <asp:TextBox ID="txt_lve_total_days" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Total Leaves">
                                </asp:TextBox>
           
        </td></tr>
    
    <tr>
    <td style="width:15%; text-align:left"> 
    <asp:Label ID="Label99" runat="server" Text="Leave Reason">
    </asp:Label>
    </td>
        <td style="width:35%; text-align:left">
            
                            <asp:TextBox ID="txt_leave_reason" runat="server" CssClass="input-required" 
                            ReadOnly="true" ClientIDMode="Static"
                            PlaceHolder="Leave Reason"></asp:TextBox>
            
        </td>
        <td style="width:15%; text-align:left">
        <asp:Label ID="Label98" runat="server" Text="Employee Replacement ID">
        </asp:Label></td>
        <td align="left" width="35%">
           
                            <asp:TextBox ID="txt_lve_ReplcID" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Employee Replacement ID">
                                </asp:TextBox>
           
        </td></tr>
    </table>
  </center>

</td>
</tr>
</table>
<asp:HiddenField ID="txtLeaveCode" runat="server" Value="0" ClientIDMode="Static" />
</div>
</center>
