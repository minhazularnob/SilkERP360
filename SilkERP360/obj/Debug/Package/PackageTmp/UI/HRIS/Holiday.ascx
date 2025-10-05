<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Holiday.ascx.cs" Inherits="SilkERP360.UI.HRIS.Holiday" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/Holiday.js" type="text/javascript"></script>


<div id="Empholiday" style="width:100%;">
       
       <h1>EMPLOYEE HOLIDAY FORM</h1>
        <p class="login button"> 
           
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>
            
    </div>

    <br />

  
    <div id="divHoliday" class="ui_control_wrapper" style="Width:99%;height:1024px; margin:0 auto;">
    
    <table id="tblHolid" style="width:100%; height:auto; table-layout:fixed">
    <tr style="width:100%; height:auto">
    <td style="width:15%">
    
        <asp:Label ID="Label60" runat="server" Text="Holiday Name">
                    </asp:Label>
    
    </td>
    <td style="width:85%">
    <asp:DropDownList ID="ddl_holidayName" runat="server" class="input-required" Width="98.5%"
                                   ClientIDMode="Static" PlaceHolder="Holiday Name">
                                    <asp:ListItem Value="0">----- Select Holiday Name</asp:ListItem>
                                    <asp:ListItem>Eid Milad un-Nabi</asp:ListItem>
                                    <asp:ListItem>Lailatul Barat</asp:ListItem>
                                    <asp:ListItem>Jumatul Wida/</asp:ListItem>
                                    <asp:ListItem>Shab-e-Qadar</asp:ListItem>
                                    <asp:ListItem>Shab-e-Miraj</asp:ListItem>
                                    <asp:ListItem>Eid Ul Fitr (Rojar Eid)</asp:ListItem>
                                    <asp:ListItem>Eid Ul Azha (Korbani Eid)</asp:ListItem>
                                    <asp:ListItem>Muharram(Ashura)</asp:ListItem>                                    
                                    <asp:ListItem>Shahid Dibash (Language Martyrs' Day)</asp:ListItem>
                                    <asp:ListItem>Independence Day</asp:ListItem>
                                    <asp:ListItem>Islamic New Year</asp:ListItem>
                                    <asp:ListItem>Bangla New Year's Day</asp:ListItem>
                                    <asp:ListItem>New Year’s Day</asp:ListItem>
                                    <asp:ListItem>May Day</asp:ListItem>
                                    <asp:ListItem>Bijoy Dibosh (Victory Day)</asp:ListItem>
                                    <asp:ListItem>National Revolution Day</asp:ListItem>
                                    <asp:ListItem>Bank Holiday</asp:ListItem>
                                    <asp:ListItem>Krishna Janmashtami</asp:ListItem>
                                    <asp:ListItem>Durga Puja (Vijaya Dasami)</asp:ListItem>
                                    <asp:ListItem>National Mourning Day</asp:ListItem>
                                    <asp:ListItem>Buddha Purnima (Buddha's Birthday)</asp:ListItem>
                                    <asp:ListItem>Christmas</asp:ListItem>

                                </asp:DropDownList>

    </td>
    </tr>


    <tr>
    <td colspan="2">  
    <table style="width:100%; height:auto; table-layout: fixed; border:1px;">

       <tr>
                <td style="width:15%">
                    
                    <asp:Label ID="Label62" runat="server" Text="Declaration Date"></asp:Label>
                       </td>
                 <td style="width:35%">
                    
           <asp:TextBox ID="txt_DecDateTime" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Declaration DateTime" CssClass="input-required">
           </asp:TextBox>
                 </td>
                 <td style="width:15%">
                    
                    <asp:Label ID="Label63" runat="server" Text="Start Date"></asp:Label>
                       </td>
                 <td style="width:35%">
                    
           <asp:TextBox ID="txt_StartDate" runat="server" ClientIDMode="Static" ReadOnly="true" PlaceHolder="Start Date" CssClass="input-required">
           </asp:TextBox>
                                </td>
              </tr>            
              <tr>
                <td style="width:15%">
                    
                    <asp:Label ID="Label66" runat="server" Text="End Date"></asp:Label>
                       </td>
                 <td style="width:35%">                    
              <asp:TextBox ID="txt_EndDate" runat="server" ClientIDMode="Static" ReadOnly="true" PlaceHolder="End Date" CssClass="input-required">
              </asp:TextBox>
                  </td>
                 <td style="width:15%">
                    
                    <asp:Label ID="Label64" runat="server" Text="Number Of Days"></asp:Label>
                       </td>
                 <td style="width:35%">
                    
             <asp:TextBox ID="txt_NumDays" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Number Of Days" CssClass="input-required">
             </asp:TextBox>
             </td>
              </tr>            
               <tr>
                <td style="width:15%">
                    
                    <asp:Label ID="Label67" runat="server" Text="Remarks"></asp:Label>
                       </td>
                 <td colspan="3">
                    
                <asp:TextBox ID="txt_Remarks" runat="server" ClientIDMode="Static" Width="98.5%" PlaceHolder="Remarks" TextMode="MultiLine" Height="30px" >
                </asp:TextBox>
                   </td>
          </tr>
                                    
    </table>   
    </td>
    </tr>
    </table> 





    <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblHolidayList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    </div>
    </div>
 