<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataProcess.ascx.cs" Inherits="SilkERP360.UI.HRIS.DataProcess" %>



<style type="text/css">
    .style1
    {
        height: 29px;
    }
</style>



<script src="../../Globals/Scripts/SilkERP360/HRIS/DataProcess.js" type="text/javascript"></script>



<div id="SalAddDEduc" style="width:100%;">
       
       <h1>Attendance Data Processd</h1>
        <p class="login button"> 
           
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>
            
    </div>

<div id="main">
<table id="tblDataProcessed" style="width:100%; height:auto; table-layout: fixed;">
    <tr>
        <td>
            <table id="tblAttenData" style="width:100%; height:auto; table-layout: fixed;">
            <tr>
                <td colspan="2" >
                        <input id="fileBrowser" onchange="return readBlob() ;" style="width: 95%" type="file" align="middle"  /></td>
            </tr>
            <tr>
                <td >
                    <asp:TextBox ID="txt_AttenDate" runat="server"
                        Width="90%" ClientIDMode="Static"
                        PlaceHolder="Select Attendance Date" 
                    CssClass="input-required"></asp:TextBox>
                </td><td>
                        <input id="btnReadData" onclick="ReadData();return false;" 
                        style="width:90%; height:auto" type="button" value="Read Data" /></td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:DropDownList ID="ddl_AttenShift" runat="server" Width="90%" ClientIDMode="Static" PlaceHolder="Select Shift" CssClass="input-required">
                        <asp:ListItem Value="0">----- Select Shift</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                        <input id="btnProcess" onclick="AttendanceProcess();return false;" style="width:90%; height:auto" type="button" value="AttendanceProcess" />
                </td>
            </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <table>
                <tr>
                    <td>
                    </td>
                 </tr>
            </table>
        </td>
    </tr>


</table>

</div>
   
<div id="byte_range"></div>
<div id="byte_content"></div>
