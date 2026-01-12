<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewLeveRecommendation.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewLeveRecommendation" %>

<script src="../../Globals/Scripts/SilkERP360/HRIS/NewLeveRecommendation.js" type="text/javascript"></script>

<div id="cmdSave" style="width:100%;">
       
       <h1>&nbsp;EMPLOYEE LEAVE RECOMMENDED FORM</h1>
        <p class="login button"> 
           
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="SaveLeaveRecommended();return false;" style="width:70px;" />
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
            
        </p>
            
    </div>


<div id="LveCategory">

<table id="tblLevApplicition" style="width:100%; height:auto; table-layout: fixed;">
<tr><td>
<table id="tbl_lveCategory" style="height:auto; width:100%; height:auto; table-layout: fixed;">
    
    <tr>
        <td style="width:15%; text-align:left">
     <asp:Label ID="Label102" runat="server" Text="Recommended Category">
     </asp:Label> 
     </td>
            <td style="width:35%; text-align:left">
               <asp:DropDownList ID="ddl_Lev_Recommended" runat="server" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Shift" >
                <asp:ListItem Value="0">----- Select Recommended Category</asp:ListItem>
                    <asp:ListItem Value="1">Paid</asp:ListItem>
                     <asp:ListItem Value="2">Unpaid</asp:ListItem>
            </asp:DropDownList></td>
            <td style="width:15%; text-align:left">
     <asp:Label ID="Label103" runat="server" Text="Recommended Mode">
     </asp:Label> 
        </td>
            <td style="width:35%; text-align:left">
               <asp:DropDownList ID="ddl_Lev_RecommendedMode" runat="server" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Shift" >
                <asp:ListItem Value="0">----- Select Recommended Mode</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                     <asp:ListItem Value="2">Rejected</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
</table>
</td>
</tr>

<tr><td>


<table id="tblLeaveDetails" cellspacing="2px" style="border:2px; border-color:Blue; width:100%;">

                                <caption style="width:100%; text-align:center">                       
                                <h2>Leave History</h2>                           
                                </caption>

    <tr style="font-weight:bold;">
        <td align="center" width="25%">
            Type Of Leave</td>
        <td align="center" width="25%">
            From Date</td>
        <td align="center" width="25%">
            To Date</td>
        <td align="center" width="25%">
            Number Of Days</td>
    </tr>
    <tr>
        <td align="center" style="width:10%;">
            &nbsp;</td>
        <td align="center" class="style12">
            &nbsp;</td>
        <td align="center" class="style13">
            &nbsp;</td>
        <td align="center" style="width:10%;">
            &nbsp;</td>
    </tr>
     <tr>
        <td align="center" style="width:10%;">
            &nbsp;</td>
        <td align="center" class="style12">
            &nbsp;</td>
        <td align="center" class="style13">
            &nbsp;</td>
        <td align="center" style="width:10%;">
            &nbsp;</td>
    </tr>
</table>
</td></tr>
</table>



    <table id="tblLeaveApplication"  style="width:100%; height:auto; table-layout:fixed">
    <tr style="width:100%; height:auto">
    <td style="width:15%">
    
                 <asp:Label ID="Label11" runat="server" Text="Company">
                 </asp:Label> 
    
    </td>
    <td style="width:85%">
            <asp:TextBox ID="txt_Lve_Company" runat="server" ClientIDMode="Static" PlaceHolder="Company Name" ReadOnly="True" >
            </asp:TextBox>

    </td>
    </tr>
    <tr>
    <td>
        <asp:Label ID="Label7" runat="server" Text="Department"></asp:Label> 
    </td>
    <td>
            <asp:TextBox ID="txt_Lve_Department" runat="server" ClientIDMode="Static" PlaceHolder="Department" ReadOnly="True" >
            </asp:TextBox>
    </td>
    </tr>


    <tr>
    <td colspan="2">  
    <table id="tblEmp" style="width:98%; height:auto; table-layout: fixed; border:1px;">

       <tr>
                <td style="width:15%">
                    
                <asp:Label ID="Label93" runat="server" Text="EmployeeID">
                </asp:Label> </td>
                 <td style="width:35%">
                    
                <asp:TextBox ID="txt_Lve_EmpID" runat="server" ReadOnly="True" 
                ClientIDMode="Static" PlaceHolder="Employee ID" 
                CssClass="input-required">
                </asp:TextBox>
                </td>
                 <td style="width:15%">
                    
                <asp:Label ID="Label3" runat="server" Text="Name">
                </asp:Label>
                </td>
                 <td style="width:35%">
                    
            <asp:TextBox ID="txt_Lve_EmpName" runat="server" ReadOnly="True" ClientIDMode="Static" PlaceHolder="Employee Name" CssClass="input-required"></asp:TextBox>
                </td>
              </tr>            
              <tr>
                <td style="width:15%">
                    
                <asp:Label ID="Label4" runat="server" Text="Designation">
                </asp:Label></td>
                 <td style="width:35%">                    
            
            <asp:TextBox ID="txt_Lve_Designation" runat="server" ReadOnly="True" ClientIDMode="Static" PlaceHolder="Designation" CssClass="input-required">
            </asp:TextBox>
            
                  </td>
                 <td style="width:15%">
                    
                    <asp:Label ID="Label5" runat="server" Text="Joining Date">
                    </asp:Label>
                  </td>
                 <td style="width:35%">
                    
            <asp:TextBox ID="txt_Lve_JoinDate" runat="server" ReadOnly="True" 
                ClientIDMode="Static" PlaceHolder="Joining Date">
                </asp:TextBox>
           
             </td>
              </tr>            
               
                                    
              <tr>
                <td style="width:15%">
                    
    <asp:Label ID="Label94" runat="server" Text="Leave Type">
    </asp:Label></td>
                 <td style="width:35%">                    
            
                            <asp:TextBox ID="txt_LeaveType" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" 
                                        PlaceHolder="Leave Type"></asp:TextBox>
            
                  </td>
                 <td style="width:15%">
                    
            <asp:Label ID="Label95" runat="server" Text="Leave Category">
            </asp:Label>
                  </td>
                 <td style="width:35%">
                    
                            <asp:TextBox ID="txt_lve_Category" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Leave Category">
                                </asp:TextBox>
                            
             </td>
              </tr>            
               
                                    
              <tr>
                <td style="width:15%">
                    
    <asp:Label ID="Label101" runat="server" Text="Leave From Date">
    </asp:Label>
                  </td>
                 <td style="width:35%">                    
            
                            <asp:TextBox ID="txt_Leave_from_date" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Leave From Date">
                                </asp:TextBox>
            
                  </td>
                 <td style="width:15%">
                    
        <asp:Label ID="Label96" runat="server" Text="Leave Up To Date">
        </asp:Label>
                  </td>
                 <td style="width:35%">
                    
                            <asp:TextBox ID="txt_Leave_to_date" runat="server" ClientIDMode="Static" 
                                PlaceHolder="Leave Up To Date" ReadOnly="true" >
                                </asp:TextBox>
                            
             </td>
              </tr>            
               
                                    
              <tr>
                <td style="width:15%">
                    
    <asp:Label ID="Label100" runat="server" Text="Joining Date">
    </asp:Label>
                  </td>
                 <td style="width:35%">                    
            
                           <asp:TextBox ID="txt_join_date" runat="server"  ReadOnly="true" 
                            ClientIDMode="Static" PlaceHolder="Joining Date">
                            </asp:TextBox> 
            
                  </td>
                 <td style="width:15%">
                    
        <asp:Label ID="Label97" runat="server" Text="Total Leaves">
        </asp:Label>
                  </td>
                 <td style="width:35%">
                    
                            <asp:TextBox ID="txt_lve_total_days" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Total Leaves">
                                </asp:TextBox>
           
             </td>
              </tr>            
               
                                    
              <tr>
                <td style="width:15%">
                    
    <asp:Label ID="Label99" runat="server" Text="Leave Reason">
    </asp:Label>
                  </td>
                 <td style="width:35%">                    
            
                            <asp:TextBox ID="txt_leave_reason" runat="server" CssClass="input-required" 
                            ReadOnly="true" ClientIDMode="Static"
                            PlaceHolder="Leave Reason"></asp:TextBox>
            
                  </td>
                 <td style="width:15%">
                    
        <asp:Label ID="Label98" runat="server" Text="Employee Replacement ID">
        </asp:Label></td>
                 <td style="width:35%">
                    
                            <asp:TextBox ID="txt_lve_ReplcID" runat="server" ReadOnly="true" 
                                ClientIDMode="Static" PlaceHolder="Employee Replacement ID">
                                </asp:TextBox>
           
             </td>
              </tr>            
               
                                    
    </table>   
    </td>
    </tr>
    </table>


<asp:HiddenField ID="txtLeaveCode" runat="server" Value="0" ClientIDMode="Static" />
</div>

