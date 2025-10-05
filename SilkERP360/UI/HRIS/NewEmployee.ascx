<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewEmployee" %>


<script src="../../Globals/Scripts/SilkERP360/HRIS/NewEmployee.js" type="text/javascript"></script>

<asp:HiddenField ID="txtUserEmployeeCode" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtEducationCount" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtExperienceCount" runat="server" Value="0" ClientIDMode="Static"/>
<asp:HiddenField ID="txtLeaveCounter" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtCompanyCode" runat="server" Value="0" ClientIDMode="Static" />

<div id="dvBody" class="ui_control_wrapper" style='z-index:1000;' >
    <div id="cmd" style="width:99%; z-index: 1001;">
        <h1>New Appoinment</h1>
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" style="width:40px" />--%>       <%--<h1>New Employee Appoinment</h1>--%>
        <p class="login button"> 
            <%--<input type="button" value="Save" class="button" /> --%>
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />&nbsp;
            <%-- <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />--%>
        </p>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" style="width:40px" onclick="btnClose_Click" />--%>
    </div>
     
    <div id="tabs" style="width:99%; height:500px; position: relative; z-index: 12; top: 49px; left: 1px; z-index: 1002;" >
	    <ul>
            <li><a href="#ImageTab" >Image</a></li>
		    <li><a href="#OfficialTab" >Official</a></li>
		    <li><a href="#PersonalTab">Personal</a></li>
            <li><a href="#SalaryTab">Salary  Leaves & Reference</a></li>
            <li><a href="#EducationExperienceTab">Education  Experiance  </a></li>
		        <%--<li><a href="#EducationTab">Education & Experience</a></li>--%>
            <%--<li><a href="#ReferenceTab">Reference</a></li>--%>
	    </ul>
    
    <div id="ImageTab" style='z-index:1003;'>
    <center>
    <table id="tblphoto" >
    
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
        
            <h2>
                Image Information</h2>
        </td>
        </tr>

        <tr>
        <td align="center" colspan="3">
                        &nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td style="width:30%" align="right">
                    <img id="imgEmployeeImage" alt="" src="../../Globals/Images/images.jpg" style=" width:160px; height:159px;" align="middle" />
                    </td>
        <td style="width:30%">&nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td style="width:30%" align="right">
                    &nbsp;</td>
        <td style="width:30%">&nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td align="right" colspan="2">
                        <input id="fileBrowser" onchange="return LoadImage() ;" 
                            style="width: 100%" type="file" align="middle"  /></td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td style="width:30%" align="right">
                    <asp:TextBox ID="txt_EI_ImageType" runat="server" ClientIDMode="Static" placeHolder="File Type" ReadOnly="true"  style="width:150px" >
                    </asp:TextBox>
                </td>
        <td style="width:30%">&nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td align="right" style="width:30%">
                    <asp:TextBox ID="txt_EI_ImageSize" runat="server" ClientIDMode="Static" 
                        placeHolder="File Size" ReadOnly="true" style="width:150px" ></asp:TextBox>
                </td>
        <td style="width:30%">&nbsp;</td>
        </tr>

        <tr>
        <td style="width:40%">&nbsp;</td>
        <td align="right" style="width:30%">
                    <input id="btnDeleteImage" onclick="return DeleteImage();" 
                        style="width:45px; height:auto" type="button" value="Delete" /></td>
        <td style="width:30%">&nbsp;</td>
        </tr>

        </table>
        </center>
    </div>
    <div id="OfficialTab" style='z-index:1004;' ><!-- OFFICIAL TAB CONFIGURATION  class="center_div" -->
        <%--<center>--%>
        <table id="tblOfficial" class="ip_control_container" style="width:100%; height:auto; table-layout: fixed;">
        <caption style="width:100%; text-align:center">
                            
                                <h2>Official Information</h2>
                           
                        </caption>
                   <tr>
                    <td style="width:15%" align="left">                
                         <asp:Label ID="Label" runat="server" Text="Department"></asp:Label>
                    </td>
                     <td style="width:85%" align="left">
                     <asp:DropDownList ID="ddl_Off_Department" runat="server" ClientIDMode="Static" 
                             CssClass="input-required" PlaceHolder="Department" Width="98.5%">
                             <asp:ListItem Value="0">----Select Department</asp:ListItem>
                         </asp:DropDownList>                 
                        </td>                     
              </tr>
              <tr>
                      <td colspan="2">
                      <table id="tblOffice" style="width:100%; height:auto; table-layout: fixed;">
                      <tr>
                    <td style="width:15%" align="left">                    
                        <asp:Label ID="Label69" runat="server" Text="Employee Name"> </asp:Label>
                    </td>
                     <td style="width:35%" align="left">                    
                         <asp:TextBox ID="txt_Off_Name" runat="server" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Emp. Name" > </asp:TextBox>
                     </td>
                     <td style="width:15%" align="left">                    
                         <asp:Label ID="Label70" runat="server" Text="Shift Code"> </asp:Label>
                     </td>
                     <td style="width:35%" align="left">                    
                        <asp:DropDownList ID="ddl_Off_Shift_Code" runat="server"  ClientIDMode="Static" PlaceHolder="Shift" CssClass="input-required">
                         <asp:ListItem>----- Select Shift</asp:ListItem>
                        </asp:DropDownList>
                     </td>
              </tr>
             <tr>
                    <td style="width:15%" align="left">
                    <asp:Label ID="Label71" runat="server" Text="ACS Code"></asp:Label>
                   </td>
                  <td style="width:35%" align="left">                    
                        <asp:TextBox ID="txt_Off_ACSCode" runat="server" ClientIDMode="Static" PlaceHolder="ACS Code" CssClass="input-required"> </asp:TextBox>
                  </td>
                 <td style="width:15%" align="left">                    
                         <asp:Label ID="Label72" runat="server" Text="Designation"> </asp:Label>
                 </td>
                 <td style="width:35%" align="left">                                    
                        <asp:DropDownList ID="ddl_Off_Designation" runat="server" ClientIDMode="Static" PlaceHolder="Designation" CssClass="input-required">
                        <asp:ListItem Value="0">----Select Designation</asp:ListItem>
                        </asp:DropDownList>         
                 </td>
              </tr>
              <tr>
                <td style="width:15%" align="left">                    
                        <asp:Label ID="Label73" runat="server" Text="Ref. Employee"> </asp:Label>
                </td>
                 <td style="width:35%" align="left">                    
                        <asp:DropDownList ID="ddl_Off_RefEmployee" runat="server" ClientIDMode="Static" PlaceHolder="Ref. Employee" CssClass="input-required">
                        <asp:ListItem Value="0">----- Select REF. Employee</asp:ListItem>
                        </asp:DropDownList>
                       </td>
                 <td style="width:15%" align="left">                    
                        <asp:Label ID="Label74" runat="server" Text="Search Ref. Employee"> </asp:Label>
                  </td>
                 <td style="width:35%" align="left">                    
                        <asp:TextBox ID="txt_Off_AutoRefEmployee" runat="server" ClientIDMode="Static" PlaceHolder="Search RefEmployee" > </asp:TextBox>                                        
                  </td>
            </tr>
            
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label75" runat="server" Text="Supervisor"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:DropDownList ID="ddl_Off_Supervisor" runat="server" ClientIDMode="Static" PlaceHolder="Supervisor">
                        <asp:ListItem Value="0">----- Select Supervisor</asp:ListItem>
                    </asp:DropDownList>
                       </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label76" runat="server" Text="Search Supervisor"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_AutoSuperVisor" runat="server" ClientIDMode="Static" PlaceHolder="Search Super Visor" > </asp:TextBox>                                        
                       </td>
              </tr>

            
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label77" runat="server" Text="Join Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_JoiningDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Joining Date" CssClass="input-required"> </asp:TextBox>
                       </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label78" runat="server" Text="Confirmation Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_ConfirmationDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Conf. Date" CssClass="input-required"> </asp:TextBox>
                    
                       </td>
              </tr>

            
                  <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label79" runat="server" Text="Retirement Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_RetirementDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Ret. Date">
                    </asp:TextBox>
                       </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label80" runat="server" Text="Settlement Date"></asp:Label>
                       </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_SettlementDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Settlement Date">
                    </asp:TextBox>
                       </td>
              </tr>
            
             <tr>
                    <td style="width:15%" align="left">                    
                        <asp:Label ID="Label81" runat="server" Text="Official File No">
                        </asp:Label>
                   </td>
                 <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_OfficialFileNo" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Off. File No">
                    </asp:TextBox>
                 </td>
                  <td style="width:15%" align="left"> 
                    
                     <asp:Label ID="Label21" runat="server" Text="Bond Refference"></asp:Label>
                    
                    </td>
                  <td style="width:15%" align="left"> 
                    
                     <asp:TextBox ID="txt_BondRefference" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Bond Refference">
                    </asp:TextBox>
                     
                    </td>

                 
              </tr>

                               <tr>
                    <td style="width:15%" align="left"> Bond Issue Date</td>
                    
                  
                 <td style="width:35%" align="left">
                 <asp:TextBox ID="txt_BondIssueDate" runat="server" ReadOnly="true" 
                         ClientIDMode="Static" PlaceHolder="Bond Issue Date"> </asp:TextBox>                   
                    </td>
                
                 <td style="width:15%" align="left">
                    
                     Bond Year</td>
                 <td style="width:35%" align="left">
                    
                                    <asp:DropDownList ID="ddl_BondYear" runat="server" ClientIDMode="Static" PlaceHolder="Gender" CssClass="input-required">
                                       <asp:ListItem Value="0">-----Select Bond Year</asp:ListItem>
                                       <asp:ListItem Value="1">1 Year</asp:ListItem>
                                       <asp:ListItem Value="2">2 Years</asp:ListItem>
                                       <asp:ListItem Value="3">3 Years</asp:ListItem>
                                       <asp:ListItem Value="4">4 Years</asp:ListItem>
                                       <asp:ListItem Value="5">5 Years</asp:ListItem>
                                       <asp:ListItem Value="6">6 Years</asp:ListItem>
                                       <asp:ListItem Value="7">7 Years</asp:ListItem>
                                       <asp:ListItem Value="8">8 Years</asp:ListItem>
                                       <asp:ListItem Value="9">9 Years</asp:ListItem>
                                       <asp:ListItem Value="10">10 Years</asp:ListItem>                                        
                                    </asp:DropDownList>
                     
                </td>
              </tr>

               <tr>
                    <td style="width:15%" align="left"> 
                    
                     <asp:Label ID="Label18" runat="server" Text="Bond Expiry Date"></asp:Label>
                    
                       </td>
                    
                  
                 <td style="width:35%" align="left">
                    
                 <asp:TextBox ID="txt_BondValidityDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Bond Expiry Date"> </asp:TextBox>                   
                    </td>
                
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label20" runat="server" Text="Remarks"></asp:Label>
                    
                       </td>
                 <td style="width:35%" align="left">
                    
                        <asp:TextBox ID="txt_Off_Remarks" runat="server" ClientIDMode="Static" PlaceHolder="Remarks" TextMode="MultiLine" Height="30px" >
                        </asp:TextBox> 
                     
                </td>
              </tr>
                  

               <tr>
                     <td style="width:15%" align="left">
                    <asp:Label ID="Label22" runat="server" Text="e-TIN Eligible"></asp:Label>
                         </td>
                 <td style="width:35%" align="left">
                     <asp:CheckBox ID="chk_eTIN_Eligible" runat="server" Text="e-TIN Eligible" ClientIDMode="Static" />   
                        </td>
                        <td style="width:15%" align="left">                    
                     <asp:Label ID="Label82" runat="server" Text="e-TIN No">
                     </asp:Label>
                </td>
                <td style="width:35%" align="left">
                    
                    <asp:TextBox ID="txt_Off_Tin" runat="server" ReadOnly="false"  ClientIDMode="Static" PlaceHolder="e-TIN No">
                    </asp:TextBox>
                    
                       </td>
              </tr>
                      
                      
             <tr>
                     <td>
                    
                    <asp:Label ID="Label115" runat="server" Text="Bank"></asp:Label>
                    
                       </td>
                 <td align="left" >
                    
                    
                    <asp:CheckBox ID="chkBankSalary" runat="server" Text=" Bank Salary" 
                            ClientIDMode="Static" />
                    
                    
                    
                       </td>
                     <td>
                    
                            <asp:Label ID="Label116" runat="server" Text="Bank Account Number">
                            </asp:Label>
                       </td>
                     <td>                    
                    
                    <asp:TextBox ID="txt_Off_BankAccountCode" runat="server" ReadOnly="false" PlaceHolder="Bank Account number" 
                            ClientIDMode="Static" ></asp:TextBox>
                    
                    
                    
                     </td>
              </tr>  
               <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label83" runat="server" Text="Eligable"></asp:Label>
                    
                       </td>
                 <td style="width:40%" align="left">
                     <asp:CheckBox ID="chkOTEligable" runat="server" Text=" OT Eligible"  ClientIDMode="Static" />
                    <asp:CheckBox ID="chkPFEligable" runat="server" Text=" PF Eligible" ClientIDMode="Static" />
                    <asp:CheckBox ID="chkRoster" runat="server" Text=" Roster Eligible" ClientIDMode="Static" />
                    <asp:CheckBox ID="checNightBill" runat="server" Text=" Night Bill Eligible" ClientIDMode="Static" />
                    <asp:CheckBox ID="Check_ComUniform" runat="server" Text="Uniform Eligible" ClientIDMode="Static" />
                    
                    </td>
                     <td>
                    
                    <asp:Label ID="Label17" runat="server" Text="Bank Name"></asp:Label>
                    
                       </td>
                     <td>             
                    
                    
                    <%--<asp:TextBox ID="txtBankName" runat="server" ClientIDMode="Static" PlaceHolder="Bank Name" >
                         </asp:TextBox>--%>
                           <asp:DropDownList ID="txtBankName" runat="server" ClientIDMode="Static" PlaceHolder="Supervisor">
                        <asp:ListItem Value="0">----- Select Bank</asp:ListItem>
                        <asp:ListItem>Agrani Bank Ltd.</asp:ListItem>
                        <asp:ListItem>Dhaka Bank Ltd.</asp:ListItem>
                        <asp:ListItem>Prime Bank Ltd.</asp:ListItem>
                        <asp:ListItem>National Bank Ltd.</asp:ListItem>
                        <asp:ListItem>IFIC Bank Ltd.</asp:ListItem>
                        <asp:ListItem>The City Bank Ltd.</asp:ListItem>
                        <asp:ListItem>Trust Bank Ltd.</asp:ListItem>
                        <asp:ListItem>JAMUNA BANK LTD</asp:ListItem>
                    </asp:DropDownList>
                    
                       </td>
              </tr>                             
                      
                      
             <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label114" runat="server" Text="Weekend"></asp:Label>
                       </td>
                 <%--<td align="left" colspan="3">--%>
                 <td>
                 <div id="chkbox" style='z-index:1005;'>
                     <asp:CheckBox ID="chk1"  runat="server" AutoPostBack="false"  ClientIDMode="Static" Text="Saturday"   onclick="CheckBoxCount();" />
                     <asp:CheckBox ID="chk2" runat="server" AutoPostBack="false"   ClientIDMode="Static" Text="Sunday"  onclick="CheckBoxCount();" />
                     <asp:CheckBox ID="chk3" runat="server" AutoPostBack="false"   ClientIDMode="Static" Text="Monday"   onclick="CheckBoxCount();" />
                     <asp:CheckBox ID="chk4" runat="server" AutoPostBack="false"   ClientIDMode="Static" Text="Tuesday"  onclick="CheckBoxCount();"/>
                     <asp:CheckBox ID="chk5" runat="server" AutoPostBack="false"   ClientIDMode="Static" Text="Wednesday"  onclick="CheckBoxCount();"/>
                     <asp:CheckBox ID="chk6" runat="server" AutoPostBack="false"    ClientIDMode="Static" Text="Thusday"   onclick="CheckBoxCount();"/>
                     <asp:CheckBox ID="chk7" runat="server" AutoPostBack="false"    ClientIDMode="Static" Text="Friday"  onclick="CheckBoxCount();"/>
                     </div>
                     </td>
                     <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label19" runat="server" Text="Job Location"></asp:Label>
                       </td>
                 <td>
                    
                                    <asp:DropDownList ID="ddl_JobLocation" runat="server"  
                                        ClientIDMode="Static" PlaceHolder="Gender" CssClass="input-required">
                                         <asp:ListItem Value="0">----- Select Job Location</asp:ListItem>
                                    <asp:ListItem>Corporate</asp:ListItem>
                                    <asp:ListItem>Silkcard Factory</asp:ListItem>
                                    <asp:ListItem>Wellpac Factory</asp:ListItem>
                                    <asp:ListItem>Chandpur</asp:ListItem>                                   
                                    </asp:DropDownList>
                                </td>
              </tr>                               
                      
  </table>
                 </td>
              
              </tr>                   
                      
  </table>
                 </td>
              
              </tr>
                          
    </table>
        
    </div>

    <div id="PersonalTab" style='z-index:1006;'>
   
    <center>

	<table id="tblPersonal"  class="ip_control_container"  style="width:100%; ">
                            <caption style="width:100%; text-align:center">
                                <h2>Personal Information</h2>
                            </caption>
                <tr>
                    <td style="width:15%" align="left">                    
                            <asp:Label ID="Label1" runat="server" Text="Father Name">
                            </asp:Label>
                   </td>
                   <td style="width:40%" align="left">                    
                             <asp:TextBox ID="txt_Pers_FatherName" runat="server" ClientIDMode="Static" PlaceHolder="Father Name" CssClass="input-required">
                             </asp:TextBox>
                    </td>
                     <td style="width:15%" align="left">                    
                         <asp:Label ID="Label2" runat="server" Text="Mother Name">
                         </asp:Label>
                     </td>
                     <td style="width:40%" align="left">                    
                              <asp:TextBox ID="txt_Pers_MotherName" runat="server" ClientIDMode="Static" PlaceHolder="Mother Name" CssClass="input-required">
                              </asp:TextBox>
                                 </td>
              </tr>
             <tr>
                    <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label3" runat="server" Text="Spouse Name"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                       <asp:TextBox ID="txt_Pers_SpouseName" runat="server" ClientIDMode="Static" PlaceHolder="Spouse Name">
                        </asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label4" runat="server" Text="Date Of Birth"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                       <asp:TextBox ID="txt_Pers_DateOfBirth" runat="server"  ReadOnly="true" ClientIDMode="Static" PlaceHolder="Date Of Birth" CssClass="input-required">
                        </asp:TextBox>
                 </td>
           </tr>
          <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label5" runat="server" Text="Marital Status"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                    <asp:DropDownList ID="ddl_Pers_MaritalStatus" runat="server"  
                                       ClientIDMode="Static"
                                        PlaceHolder="Marital Status" CssClass="input-required">
                                        <asp:ListItem Value="0">-----Select Marital Status</asp:ListItem>
                                        <asp:ListItem>Married</asp:ListItem>
                                        <asp:ListItem>Unmarried</asp:ListItem>
                                        <asp:ListItem>Divorced</asp:ListItem>
                                        <asp:ListItem>Separated</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                    <asp:DropDownList ID="ddl_Pers_Sex" runat="server"  
                                        ClientIDMode="Static"
                                        PlaceHolder="Gender" CssClass="input-required">
                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
              </tr>            
              <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label7" runat="server" Text="Religion"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                <asp:DropDownList ID="ddl_Pers_Religion" runat="server" Cssclass="input-required" 
                                     ClientIDMode="Static" PlaceHolder="Religion">
                                    <asp:ListItem Value="0">----- Select Religion</asp:ListItem>
                                    <asp:ListItem>Islam</asp:ListItem>
                                    <asp:ListItem>Hinduism</asp:ListItem>
                                    <asp:ListItem>Christian</asp:ListItem>
                                    <asp:ListItem>Buddhist</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label8" runat="server" Text="Nationality"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                <asp:TextBox ID="txt_Pers_Nationality" Text="Bangladeshi" runat="server" 
                                     ReadOnly="true" ClientIDMode="Static"
                                    CssClass="input-required"></asp:TextBox>
                                    </td>
              </tr>            
              <tr>
                <td style="width:15%" align="left">                    
                    <asp:Label ID="Label9" runat="server" Text="Blood Group"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:DropDownList ID="ddl_Pers_BloodGroup" runat="server" 
                                             ClientIDMode="Static" 
                                            PlaceHolder="Blood Group" CssClass="input-required">
                                            <asp:ListItem Value="0">-----Select Blood Group</asp:ListItem>
                                            <asp:ListItem>A (+ve)</asp:ListItem>
                                            <asp:ListItem>A (-ve)</asp:ListItem>
                                            <asp:ListItem>B (+ve)</asp:ListItem>
                                            <asp:ListItem>B (-ve)</asp:ListItem>
                                            <asp:ListItem>O (+ve)</asp:ListItem>
                                            <asp:ListItem>O (-ve)</asp:ListItem>
                                            <asp:ListItem>AB (+ve)</asp:ListItem>
                                            <asp:ListItem>AB (-ve)</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label10" runat="server" Text="Height"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_Height" runat="server"  ReadOnly="false" 
                                            ClientIDMode="Static" PlaceHolder="Height"></asp:TextBox>
                                    </td>
              </tr>            
              <tr>
                <td style="width:15%" align="left">                    
                    <asp:Label ID="Label11" runat="server" Text="Weight"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                 <asp:TextBox ID="txt_Pers_Weight" runat="server"  ReadOnly="false" ClientIDMode="Static" PlaceHolder="Weight">
                 </asp:TextBox>
              </td>
                 <td style="width:15%" align="left">                    
                     <asp:Label ID="Label12" runat="server" Text="Identification">
                     </asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                              <asp:TextBox ID="txt_Pers_Identification" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Identification">
                              </asp:TextBox>
                </td>
              </tr>
            
              <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label13" runat="server" Text="MobileNo"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                    <asp:TextBox ID="txt_Pers_MobileNo" runat="server"  ReadOnly="false" ClientIDMode="Static" PlaceHolder="Mobile No" CssClass="input-required">
                     </asp:TextBox>
                 </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label14" runat="server" Text="Home Phone"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_HomePhone" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Home Phone"></asp:TextBox>
                                    </td>
              </tr>
              <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label15" runat="server" Text="Fax No"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                  <asp:TextBox ID="txt_Pers_FaxNo" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Fax No">
                    </asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                     <asp:Label ID="Label16" runat="server" Text="Email"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                     <asp:TextBox ID="txt_Pers_Email" runat="server"  ReadOnly="false" ClientIDMode="Static" PlaceHolder="Email">
                      </asp:TextBox>
                                    </td>
              </tr>                            
                                
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label85" runat="server" Text="Present Address"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                 <asp:TextBox ID="txt_Pers_PresentAddress" runat="server" ReadOnly="false" TextMode="MultiLine" ClientIDMode="Static" PlaceHolder="Present Addrs" CssClass="input-required" Height="30px">
                  </asp:TextBox>
             </td>
                 <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label86" runat="server" Text="Permanent Address"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                 <asp:TextBox ID="txt_Pers_PermanentAddress" runat="server" ReadOnly="false" TextMode="MultiLine" ClientIDMode="Static" PlaceHolder="Permanent Addrs" CssClass="input-required" Height="30px">
                 </asp:TextBox>
                                         </td>
              </tr>                           
                                
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label87" runat="server" Text="Present District"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:DropDownList ID="ddl_Pers_PresentDistrict" runat="server" ClientIDMode="Static" PlaceHolder="District" CssClass="input-required">
                                            <asp:ListItem Value="0">-----Select District</asp:ListItem>
                                        </asp:DropDownList>

                                         </td>
                 <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label88" runat="server" Text="Permanent District"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:DropDownList ID="ddl_Pers_PermanentDistrict" 
                                            runat="server"  ClientIDMode="Static"
                                            PlaceHolder="District" CssClass="input-required">

                                            <asp:ListItem Value="0">----- Select District</asp:ListItem>
                                        </asp:DropDownList>
                                         </td>
              </tr>                          
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label94" runat="server" Text="Present PO"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_PresentPO" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Post Off."></asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label89" runat="server" Text="Permanent PO"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_PermanentPO" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Post Off."></asp:TextBox>
                                    </td>
              </tr>                               
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label93" runat="server" Text="Present PC"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_PresentPC" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Post Code."></asp:TextBox>
                                    </td>
                 <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label90" runat="server" Text="Permanent PC"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_PermanentPC" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Post Code"></asp:TextBox>
                                    </td>
              </tr>
                   
                   <tr>
                <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label92" runat="server" Text="National ID No"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_VoterCardNo" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static"
                                            PlaceHolder="Voter Card No" CssClass="input-required"></asp:TextBox>
                                         </td>
                 <td style="width:15%" align="left">
                    
                    <asp:Label ID="Label91" runat="server" Text="Passport No"></asp:Label>
                       </td>
                 <td style="width:40%" align="left">
                    
                                        <asp:TextBox ID="txt_Pers_PassportNo" runat="server"  
                                            ReadOnly="false" ClientIDMode="Static" PlaceHolder="Passport No"></asp:TextBox>
                                    </td>
              </tr>
                            
                  </table></center>

    </div>
 
    <div id="EducationExperienceTab" style='z-index:1007;'>
    <div id ="mm" style="height:225px; z-index: 1008;">
    <center>
        <table id="tblEducationExperienceTabContent"  class="ip_control_container"  >
            <tr style="width:100%; height:50%; border:0px; border-style:ridge;">
                <td  style="width:100%; height:100%;">
                    <!-- Table for Education Controls-->
                    <table id="tblEducation" style="height:auto;">
                        <caption style="width:100%; text-align:center">
                            <h2>Education Details</h2>
                        </caption>

                        <tr style="width:100%; text-align:center; height:auto;">
                                <th scope="col" abbr="Exam" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label95" runat="server" Text="Exam"></asp:Label>
                                </th>
                                <th scope="col" abbr="Uni" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label96" runat="server" Text="Board/University"></asp:Label>
                                </th>
                                <th scope="col" abbr="Business" style="width:20%; text-align:center">
                    
                    <asp:Label ID="Label97" runat="server" Text="Ins. Name"></asp:Label>
                                </th>
                                <th scope="col" abbr="Deluxe" style="width:20%; text-align:center">
                    
                    <asp:Label ID="Label98" runat="server" Text="Major Subject"></asp:Label>
                                </th>
                                <th scope="col" abbr="Uni" style="width:10%; text-align:center">
                    
                    <asp:Label ID="Label99" runat="server" Text="Division/Class"></asp:Label>
                                </th>
                                <th scope="col" abbr="Business" style="width:8%; text-align:center">
                    
                    <asp:Label ID="Label100" runat="server" Text="CGPA"></asp:Label>
                                </th>
                                <th scope="col" abbr="Deluxe" style="width:10%; text-align:center">
                    
                    <asp:Label ID="Label101" runat="server" Text="Passing Year"></asp:Label>
                                </th>                                
                            </tr>                        
                            <tr style="width:100%; text-align:center; ">
                                <th scope="col" abbr="Exam" style="text-align:center" class="style1">
                                    <asp:TextBox ID="txt_Edu_ExamName" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Exam" CssClass=""> </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Uni" style="text-align:center" class="style2">
                                    <asp:TextBox ID="txt_Edu_BoardUniversity" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Board/Uni" CssClass="">
                                    </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Business" style="text-align:center;" class="style2">
                                    <asp:TextBox ID="txt_Edu_InstituteName" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Inst. Name" CssClass="">
                                    </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" style="text-align:center" class="style2">
                                    <asp:TextBox ID="txt_Edu_MajorSubject" runat="server" ReadOnly="false" 
                                        ClientIDMode="Static" PlaceHolder="Major Sub." CssClass="" 
                                        style="margin-right: 0px">
                                    </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Uni" style="text-align:center" class="style3">
                                    <asp:TextBox ID="txt_Edu_DivisionClass" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Division/Class" CssClass="">
                                    </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Business" style="text-align:center" class="style3">
                                    <asp:TextBox ID="txt_Edu_CGPA" runat="server" ReadOnly="false" 
                                        ClientIDMode="Static" PlaceHolder="CGPA"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" style="text-align:center" class="style3">
                                    <asp:TextBox ID="txt_Edu_PassingYear" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Passing Year" CssClass="">
                                    </asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" 
                                    style="text-align:center; border:1px ridge #efefef;" class="style4">
                                    <a href="#" onclick="addEducation(); return false;" shape="poly">
                                        <img id="btnAddNewRow" alt="New Row" style="cursor:pointer" title="Add New Row" name="btnAddNewRow" src="../../Globals/Images/add-2.png"/>
                                    </a>
                                </th>
                            </tr>
                        
                    </table>
                </td>
            </tr>
            <tr style="width:100%; height:50%;">
                <td  style="width:100%; height:100%;">
                    <br />
                </td>
            </tr>
        </table>
    </center>
    </div>
    <div id ="Experience" style="height:225px; z-index: 1009;">
    <center>
        <table id="tblEducationExperienceTabContent123"  class="ip_control_container"   style="width:100%;">
            <tr style="width:100%; height:50%; border:0px; border-style:ridge;">
                <td  style="width:100%; height:100%;">
                    <!-- Table for Experience Controls-->
                    <table id="tblExperience" style="height:auto;">
                        <caption style="width:100%; text-align:center">
                            <h2>Experience Details</h2>
                           
                        </caption>

                        
                            <tr style="width:100%; text-align:center; height:auto;">
                                <th scope="col" abbr="Exam" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label102" runat="server" Text="Organization Name"></asp:Label>
                                    </th>
                                <th scope="col" abbr="Uni" style="width:20%; text-align:center">
                    
                    <asp:Label ID="Label103" runat="server" Text="Address"></asp:Label>
                                    </th>
                                <th scope="col" abbr="Business" style="width:10%; text-align:center">
                    
                    <asp:Label ID="Label104" runat="server" Text="Responsibility"></asp:Label>
                                    </th>
                                <th scope="col" abbr="Deluxe" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label105" runat="server" Text="Nature Of Job"></asp:Label>
                                    </th>
                                <th scope="col" abbr="Uni" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label106" runat="server" Text="Contact No"></asp:Label>
                                    </th>
                                <th scope="col" abbr="Business" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label107" runat="server" Text="Date From"></asp:Label>
                                   </th>
                                <th scope="col" abbr="Deluxe" style="width:15%; text-align:center">
                    
                    <asp:Label ID="Label108" runat="server" Text="Date To"></asp:Label>
                                    </th>
                                </tr>
                            <tr style="width:100%; text-align:center; height:auto;">
                                <th scope="col" abbr="Exam" style="width:17%; text-align:center">
                                    <asp:TextBox ID="txt_Exp_OrganizationName" runat="server" 
                                        ReadOnly="false" ClientIDMode="Static"
                                        PlaceHolder="Organization"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Uni" style="width:20%; text-align:center">
                                    <asp:TextBox ID="txt_Exp_Address" runat="server" ReadOnly="false" 
                                        ClientIDMode="Static" PlaceHolder="Address"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Business" style="width:20%; text-align:center">
                                    <asp:TextBox ID="txt_Exp_Responsibility" runat="server"  
                                        ReadOnly="false"  ClientIDMode="Static" 
                                        PlaceHolder="Responsibility"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" style="width:20%; text-align:center">
                                    <asp:TextBox ID="txt_Exp_NatureOfJob" runat="server"  
                                        ReadOnly="false"  ClientIDMode="Static"
                                        PlaceHolder="Nature Of Job"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Uni" style="width:15%; text-align:center">
                                    <asp:TextBox ID="txt_Exp_ContactNo" runat="server" 
                                        ReadOnly="false"  ClientIDMode="Static"
                                        PlaceHolder="Contact No"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Business" style="width:14%" "text-align:center">
                                    <asp:TextBox ID="txt_Exp_DateFrom" runat="server" ReadOnly="true"  
                                        ClientIDMode="Static" PlaceHolder="Date From"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" style="width:14%" "text-align:center">
                                    <asp:TextBox ID="txt_Exp_DateTo" runat="server" ReadOnly="true"  
                                        ClientIDMode="Static" PlaceHolder="Date To"></asp:TextBox>
                                </th>
                                <th scope="col" abbr="Deluxe" style="width:5%; text-align:center; border:1px ridge #efefef;">

                                 <a href="#" onclick="addExperience(); return false;" shape="poly">
                                   
                                        <img id="Img1" alt="New Row" style="cursor:pointer" title="Add New Row" name="btnAddNewRow" src="../../Globals/Images/add-2.png"/>
                                    </a>
                                </th>
                            </tr>
                        
                    </table>
                </td>
            </tr>
            <tr style="width:100%; height:50%;">
                <td  style="width:100%; height:100%;">
                    <br />
                </td>
            </tr>
        </table>
    </center>
    </div>
    </div>

      

    <div id="SalaryTab" style='z-index:1010;'>
    <center>
    <div id="SL" style="height:150px; z-index:1011;">
        <table id="tblSalaryMain"  class="ip_control_container"  style="width:100%;">
        <caption style="width:100%; text-align:center">
                            
                                <h2>Salary Information</h2>
                           
                        </caption>
            <tr>
                <td>
                    </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label61" runat="server" Text="Basic "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label62" runat="server" Text="House Rent "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label63" runat="server" Text="Medical "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label64" runat="server" Text="Entertainment "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label65" runat="server" Text="Conveyance "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label66" runat="server" Text="Phone Bill"></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label67" runat="server" Text="Others "></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="Label68" runat="server" Text="Gross "></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label59" runat="server" Text="Standard"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txt_Stan_Sal_Basic" runat="server" style="text-align:right;" class="currency_field" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                </td>
                <td>
                      <asp:TextBox ID="txt_Stan_Sal_HouseRent" runat="server" style="text-align:right;" class="currency_field" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                </td>
                <td>
                  <asp:TextBox ID="txt_Stan_Sal_Medical" runat="server" style="text-align:right;" class="currency_field" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                 </td>
                <td>
                       <asp:TextBox ID="txt_Stan_Sal_Entertainment" runat="server" style="text-align:right;" class="currency_field" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                </td>
                <td>
                       <asp:TextBox ID="txt_Stan_Sal_Conveyence" class="currency_field" runat="server" style="text-align:right;" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                </td>
                <td>
                       <asp:TextBox ID="txt_Stan_Sal_PhoneBill" class="currency_field" runat="server" style="text-align:right;" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                </td>
                <td>
                      <asp:TextBox ID="txt_Stan_Sal_Others" class="currency_field" runat="server" style="text-align:right;" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                 </td>
                <td>
                      <asp:TextBox ID="txt_Stan_Sal_Gross" runat="server" style="text-align:right;" class="currency_field" ReadOnly="true" ClientIDMode="Static"> </asp:TextBox>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label60" runat="server" Text="Approved"></asp:Label>
                </td>
                <td>
                     <asp:TextBox ID="txt_Sal_Basic" runat="server" style="text-align:right;" ReadOnly="true" class="input-required salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> </asp:TextBox>
                 </td>
                <td>
                      <asp:TextBox ID="txt_Sal_HouseRent" runat="server" style="text-align:right;" class="currency_field" Text="0.00" ReadOnly="true" ClientIDMode="Static"> 
                      </asp:TextBox>
                                        </td>
                <td>
                      <asp:TextBox ID="txt_Sal_Medical" runat="server" style="text-align:right;" ReadOnly="true" class="input-required salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> 
                      </asp:TextBox>
                                        </td>
                <td>
                                            <asp:TextBox ID="txt_Sal_Entertainment" style="text-align:right;" runat="server" class="salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> </asp:TextBox>
                                        </td>
                <td>
                                            <asp:TextBox ID="txt_Sal_Conveyence" runat="server" style="text-align:right;" class="input-required salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> </asp:TextBox>
                                        </td>
                <td>
                                            <asp:TextBox ID="txt_Sal_PhoneBill" runat="server" style="text-align:right;" class="salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> </asp:TextBox>
                                        </td>
                <td>
                                            <asp:TextBox ID="txt_Sal_Others" runat="server" style="text-align:right;" class="salary_field currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" Text="0.00"> </asp:TextBox>
                                        </td>
                <td>
                                            <asp:TextBox ID="txt_Sal_Gross" runat="server" style="text-align:right;" class="input-required gross_salary currency_field" onkeypress='return IsDouble(event)' ClientIDMode="Static" ReadOnly="false" Text="0.00"> </asp:TextBox>
                                        </td>
            </tr>
        </table>
    <br /><br />
    
    </div>
    <caption style="width:100%; text-align:center">
                            
                                <h2>Leave Information</h2>
                           
                        </caption>
    
                        <table id="tblLeave"  style="width:80%" bgcolor="#CCCCCC" 
            border="1">
                        
                        <tr >
                                <td align="center" style="width:20%; text-align:center;">
                    <asp:CheckBox ID="chkLeave" OnClick="return SelectLeaveALL(); " AutoPostBack="false" runat="server" Text="Action"  />
                                </td>
                                <td align="center" style="width:30%; text-align:center;">
                                    Leave
                                </td>
                                <td align="center" style="width:30%; text-align:center;">
                                    Number Of Days
                                </td>
                                <td align="center" style="width:20%; text-align:center;">
                                    Carry Forwarded
                                </td>
                            </tr>
                        </table>
                        </center>
              

   
    <%--<div id="ReferenceTab">--%>
     <center>
		    <br />    
    <div id="ReferenceTab" style='z-index:1012;'> 
     <table id="tblReference"  style="width:100%;">
                            <caption style="width:100%; text-align:center">                            
                                <h2>Reference Information</h2>                           
                        </caption>
             <tr>
                <td>
                </td>
                <td style="text-align:center">
                   
                    <asp:Label ID="Label109" runat="server" Text="Name"></asp:Label>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="Label110" runat="server" Text="Address "></asp:Label>
                </td>
                <td style="text-align:center">
                  
                    <asp:Label ID="Label111" runat="server" Text="Phone/Mobile "></asp:Label>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="Label112" runat="server" Text="Organization "></asp:Label>
                </td>
                <td style="text-align:center">
                    <asp:Label ID="Label113" runat="server" Text="Designation"></asp:Label>
                </td>
            </tr>


            <tr>
                <td>
                        <asp:CheckBox ID="chk_Ref_Reference_1" runat="server" AutoPostBack="false" ClientIDMode="Static" OnClick="return toogleReference1Controls();" Text="Reference 1"/>
                </td>
                <td>                   
                                                <asp:TextBox ID="txt_Ref_Name1" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Name">
                                                </asp:TextBox>
                </td>
                <td>
                                               <asp:TextBox ID="txt_Ref_Address1" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Address">
                                                </asp:TextBox>
                </td>
                <td>                  
                                                <asp:TextBox ID="txt_Ref_ContactNo1" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Phone / Mobile">
                                                </asp:TextBox>
                </td>
                <td>
                                                <asp:TextBox ID="txt_Ref_Organization1" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Organization">
                                                </asp:TextBox>
                </td>
                <td>
                                                <asp:TextBox ID="txt_Ref_Designation1" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Designation">
                                                </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>                   
                                                <asp:CheckBox ID="chk_Ref_Reference_2"  runat="server"  AutoPostBack="false" ClientIDMode="Static" OnClick="return toogleReference2Controls();" Text="Reference 2 "/>
                </td>
                <td>
                                      <asp:TextBox ID="txt_Ref_Name2" runat="server" Enabled="true" ClientIDMode="Static" PlaceHolder="Name">
                                      </asp:TextBox>
                </td>
                <td>
                                                <asp:TextBox ID="txt_Ref_Address2" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Address">
                                                </asp:TextBox>
                                            </td>
                <td>                   
                                                <asp:TextBox ID="txt_Ref_ContactNo2" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Phone / Mobile">
                                                </asp:TextBox>
                </td>
                <td>
                                                <asp:TextBox ID="txt_Ref_Organization2" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Organization" ontextchanged="txt_Ref_Organization2_TextChanged">
                                                </asp:TextBox>
                                            </td>
                <td>
                                                <asp:TextBox ID="txt_Ref_Designation2" runat="server" Enabled="false" ClientIDMode="Static" PlaceHolder="Designation">
                                                </asp:TextBox>
                                            </td>
            </tr>
            
        </table>
    
    </div>
               
                           
    </center>

    </div>
    </div>
    </div>