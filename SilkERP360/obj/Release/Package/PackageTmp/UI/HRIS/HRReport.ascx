<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRReport.ascx.cs" Inherits="SilkERP360.UI.HRIS.HRReport" %>

<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="../../Globals/Scripts/SilkERP360/HRIS/AttendanceReport.js" type="text/javascript"></script>




<style type="text/css">
    .overlay{
            background:transparent url(images/overlay.png) repeat top left;
            position:fixed;
            top:0px;
            bottom:0px;
            left:0px;
            right:0px;
            z-index:100;
        }
        .box{
            position:fixed;
            top:200px;
            left:30%;
            right:30%;
            background-color:#fff;
            color:#7F7F7F;
            padding:20px;
            border:2px solid #ccc;
            -moz-border-radius: 20px;
            -webkit-border-radius:20px;
            -khtml-border-radius:20px;
            -moz-box-shadow: 0 1px 5px #333;
            -webkit-box-shadow: 0 1px 5px #333;
            z-index:101;
        }
        a.boxclose{
            float:right;
            width:26px;
            height:26px;
            background:transparent url(../../Globals/Images/cancel.png) repeat top left;
            cursor:pointer;
        }
        
        .sub_form
        {
            opacity: 0;
            display: none;
            position: absolute;
            width: 100%;
            height:800px;
            top:-800px;
            z-index:101;
            

        }
</style>
<!--[if lt IE 7]>
<style>
  div.apple_overlay {
    background-image:url(/media/img/overlay/overlay_IE6.gif);
    color:#fff;
  }
 
  /* default close button positioned on upper right corner */
  div.apple_overlay div.close {
    background-image:url(/media/img/overlay/overlay_close_IE6.gif);
  }
</style>
<![endif]-->
<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {
            $("#dvSubForm").css("top", "-800px");
        });
    });
</script>
<div id="dvBody" class="ui_control_wrapper" style="Width:99%;height:1024px; margin:0 auto;">
    <div id="cmd" style="width:99%;">
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" Width="40px" />--%>
       <h1>Attendance Report </h1>
        <%--<p class="login button"> 
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" style="width:70px;" />&nbsp;
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>--%>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="40px" onclick="btnClose_Click" />--%>
    </div>
    <div id="dvRoosterForm" style="width:99%; position:relative;">
        <div id="dvSubForm" class="sub_form ui_control_wrapper" >
            <a class="boxclose" id="boxclose"></a>
                <h2 id="hdrSubForm">Important message</h2>
                <div id="dvSubFormContainer">
                    <br />
                </div>
        </div>
        



            <table class="ip_cntrl_cntnr1" style="width:98%; table-layout:fixed;margin:0 auto;"><tbody>
<tr>
<td>                
                         <asp:Label ID="Label" runat="server" Text="Department"></asp:Label>
                    </td><td colspan="3">
                     <asp:DropDownList ID="ddl_Off_Department" runat="server" ClientIDMode="Static" 
                             CssClass="input-required" PlaceHolder="Department" Width="98.5%">
                             <asp:ListItem Value="0">----Select Department</asp:ListItem>
                         </asp:DropDownList>                 
</td></tr>
<tr id="spnDept">
<td>Date</td><td>
    <asp:TextBox ID="toDate" ClientIDMode="Static" CssClass="text ui-widget-content ui-corner-all datePick" runat="server"></asp:TextBox>
    </td><td>
    <asp:Button ID="reportSubmit" OnClientClick="reportSubmit(); return false;" runat="server" Text="Preview" />
    </td><td>
    &nbsp;</td></tr>
<tr id="spnEmp">
<td>&nbsp;</td><td>
    &nbsp;</td><td>&nbsp;</td><td>
    &nbsp;</td></tr>
<tr id="spnFrom"><td>&nbsp;</td><td>
    &nbsp;</td>
<td>&nbsp;</td><td>
    &nbsp;</td></tr>
<tr><td></td><td>
    
</td><td></td><td>
    &nbsp;</td></tr>
</tbody>
</table>
    </div>
    <div style="height:10px;">
        <br />
    </div>
    <div id="dvEmployeeList" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <table id="tblEmployeeList" cellpadding="0px" cellspacing="0px" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>
        
    </div>
</div>