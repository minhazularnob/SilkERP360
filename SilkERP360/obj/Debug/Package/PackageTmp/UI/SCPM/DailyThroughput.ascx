<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyThroughput.ascx.cs" Inherits="SilkERP360.UI.SCPM.DailyThroughput" %>
<base href="/SILKERP/UI/" />
<script src="SCPM/Scripts/DailyThroughput.js" type="text/javascript"></script>

<style type="text/css">
   .box{
    position:relative;
    /*float:right;*/
    background:#eee;
    /*width:200px;*/
    padding:15px;
    margin:10px;
  }
  .close_box{
    background:fuchsia;
    color:#fff;
    padding:2px 5px;
    display:inline;
    position:absolute;
    right:15px;
    border-radius:3px;
    cursor:pointer;
  }
  
 .scpm_data_grid {
	margin:0px;padding:0px;
	width:100%;
	border:1px solid #969696;
	
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
	
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
	
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
	
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}.scpm_data_grid table{
    border-collapse: collapse;
        border-spacing: 0;
	width:100%;
	height:100%;
	margin:0px;padding:0px;
}.scpm_data_grid table caption{
    background:-o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) );
	background:-moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#cccccc", endColorstr="#b2b2b2");	background: -o-linear-gradient(top,#cccccc,b2b2b2);

	background-color:#cccccc;
	border:1px solid #969696;
	text-align:center;
	/*border-width:0px 0px 1px 1px;*/
	font-size:14px;
	font-family:Verdana;
	font-weight:bold;
	color:#000000;
}
.scpm_data_grid tr:last-child td:last-child {
	-moz-border-radius-bottomright:0px;
	-webkit-border-bottom-right-radius:0px;
	border-bottom-right-radius:0px;
}
.scpm_data_grid table tr:first-child td:first-child {
	-moz-border-radius-topleft:0px;
	-webkit-border-top-left-radius:0px;
	border-top-left-radius:0px;
}
.scpm_data_grid table tr:first-child td:last-child {
	-moz-border-radius-topright:0px;
	-webkit-border-top-right-radius:0px;
	border-top-right-radius:0px;
}.scpm_data_grid tr:last-child td:first-child{
	-moz-border-radius-bottomleft:0px;
	-webkit-border-bottom-left-radius:0px;
	border-bottom-left-radius:0px;
}.scpm_data_grid tr:hover td{
	
}
.scpm_data_grid tr:nth-child(odd){ background-color:#e5e5e5; }
.scpm_data_grid tr:nth-child(even)    { background-color:#ffffff; }.scpm_data_grid td{
	vertical-align:middle;
	
	
	border:1px solid #969696;
	border-width:0px 1px 1px 0px;
	text-align:center;
	padding:5px;
	font-size:12px;
	font-family:Arial;
	font-weight:normal;
	color:#000000;
}.scpm_data_grid tr:last-child td{
	border-width:0px 1px 0px 0px;
}.scpm_data_grid tr td:last-child{
	border-width:0px 0px 1px 0px;
}.scpm_data_grid tr:last-child td:last-child{
	border-width:0px 0px 0px 0px;
}
.scpm_data_grid tr:first-child td{
    background:-o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) );
	background:-moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#cccccc", endColorstr="#b2b2b2");	background: -o-linear-gradient(top,#cccccc,b2b2b2);

	background-color:#cccccc;
	border:0px solid #969696;
	text-align:center;
	border-width:0px 0px 1px 1px;
	font-size:14px;
	font-family:Arial;
	font-weight:bold;
	color:#000000;
}
.scpm_data_grid tr:first-child:hover td{
	background:-o-linear-gradient(bottom, #cccccc 5%, #b2b2b2 100%);	background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #cccccc), color-stop(1, #b2b2b2) );
	background:-moz-linear-gradient( center top, #cccccc 5%, #b2b2b2 100% );
	filter:progid:DXImageTransform.Microsoft.gradient(startColorstr="#cccccc", endColorstr="#b2b2b2");	background: -o-linear-gradient(top,#cccccc,b2b2b2);

	background-color:#cccccc;
}
.scpm_data_grid tr:first-child td:first-child{
	border-width:0px 0px 1px 0px;
}
.scpm_data_grid tr:first-child td:last-child{
	border-width:0px 0px 1px 1px;
}
</style>

 <script type="text/javascript">
     $('#boxclose').click(function () {
         $("#dvSubForm").fadeOut(1000, function () {
             $("#dvSubForm").css("top", "-800px");
         });
     });
     $('.close_box').click(function () {
         $(this).parent().fadeOut(1000, 0, function () {
             $(this).remove();
         });
     });
</script>


<div id="dvBody" class="ui_control_wrapper1 body box" style="Width:98%;height:auto; margin:0 auto;">
    <div class="close_box">X</div>
    <h2>Silkcard Production Throughput</h2>
   
    <div class="control_container" style="text-align:center; margin:0 auto; width:98%;">
        <table style="width:60%; margin:0 auto;">
            <tr>
                <td style="width:10%;">
                    <label>Select Date : </label>
                </td>
                <td style="width:30%; text-align:center;">
                    <asp:TextBox ID="txtDate" runat="server" Width="95%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </td>
                <td style="width:10%; text-align:center;">
                     <p class="login button"> 
                        <asp:Button ID="btnGenerate" runat="server" CssClass="button1" Text="Get Throughput" ClientIDMode="Static" OnClientClick=" GetDailyThroughput(); return false;" style="width:150px;" />&nbsp;
                     </p>
                </td>
            </tr>
           
        </table>
        
    </div>
    &nbsp;
    <div id="dvReport" class="control_container1" style="text-align:center; visibility:visible; margin:0 auto;">
        <div id="dvData" style="width:100%; margin:0 auto;">
            <table id='tblAllSectionThroughput'  style="width:100%; margin:0 auto;">
            <!--EACH ROW OF THIS TABLE WILL CONTAIN DATA FOR EACH SECTION-->
               <%--<tbody>
               </tbody>--%>
            </table>
        </div>
    </div>
</div>