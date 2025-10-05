<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InOut.ascx.cs" Inherits="SilkERP360.UI.HRIS.InOut" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/InOut.js" type="text/javascript"></script>



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

<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {
            $("#dvSubForm").css("top", "-800px");
        });
    });
</script>


   

     <div id="dvBody" class="ui_control_wrapper" style="Width:99%;height:1024px; margin:0 auto;" >

     <div id="cmd" style="width:99%;">
        
       <h1>In Time & Out Time Information</h1>      
    </div>

<div id="dvRoosterForm" style="width:99%; position:relative;">
        <div id="dvSubForm" class="sub_form ui_control_wrapper" >
            <a class="boxclose" id="boxclose"></a>
                <h2 id="hdrSubForm">Important message</h2>
                <div id="dvSubFormContainer">
                    <br />
                </div>
        </div>
        <table class="tbl_In_Out" style="width:98%; table-layout:fixed;margin:0 auto;">

          <tr>
                <td style="width:100%; text-align:left;">
                    <table cellspacing="1px" cellpadding="1px" id="tblInOut" style="width:100%;">
                        <tr>
                            <td style="width:15%;">
                                <asp:Label ID="Label1" runat="server">Date : </asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtDate" CssClass="input_required" PlaceHolder="Date"  runat="server" ReadOnly="true" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                            <td style="width:15%;">
                                &nbsp;</td>
                            <td style="width:35%;">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:15%;">
                                <asp:Label ID="Label2" runat="server">Department : </asp:Label>
                            </td>
                            <td style="width:35%;">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input_required clear" ClientIDMode="Static">
                        <asp:ListItem Value="0">Select The Department For Which the Rooster is to be created</asp:ListItem>
                    </asp:DropDownList>
                            </td>
                            <td style="width:15%;">
                                &nbsp;</td>
                            <td style="width:35%;">
                                &nbsp;</td>
                        </tr>                   
                        
                    </table>
                </td>
            </tr>
            
        </table>
   
   </div>

    <div style="height:10px;">
        <br />
    </div>

    

 <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>           
           <table id="tblAttendanceList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>
        </div>        
    </div>


     </div>