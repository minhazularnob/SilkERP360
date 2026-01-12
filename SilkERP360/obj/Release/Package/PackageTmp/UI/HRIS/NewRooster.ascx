<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewRooster.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewRooster" %>
<link href="../../Globals/Styles/DataTables.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/SilkERP360/HRIS/NewRooster.js" type="text/javascript"></script>
<style type="text/css">
    a.paginate_button,
a.paginate_active {
    display: inline-block;
    background-color: #608995;
    padding: 2px 6px;
    margin-left: 2px;
    cursor: pointer;
    cursor: hand;
}
 
a.paginate_active {
    background-color: transparent;
    border: 1px solid black;
}
 
a.paginate_button_disabled {
    color: #3d6672;
}
.paging_full_numbers a:active {
    outline: none
}
.paging_full_numbers a:hover {
    text-decoration: none;
}
 
div.dataTables_paginate span>a 
{
    font-size:12px;
    width: 25px;
    text-align: center;
}
 
div.dataTables_info {
    padding: 9px 6px 6px 6px;
}
</style>
<asp:HiddenField ID="txtRoosterDepartmentCode" runat="server" ClientIDMode="Static" />

<%--<div id="dvBody" class="ui_control_wrapper" style="height:900px; margin:0 auto;">--%>
    <div id="cmd" style="width:99%;">
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" Width="40px" />--%>
       <%--<h1>New Rooster</h1>--%>
        <p class="login button"> 
            <%--<input type="button" value="Save" class="button" /> --%>
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="SaveRoster(); return false;" style="width:70px;" />&nbsp;
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="40px" onclick="btnClose_Click" />--%>
    </div>
    <div id="dvRoosterForm" style="width:99%;">
        <table class="ip_cntrl_cntnr1" style="width:98%; table-layout:fixed;margin:0 auto;">
            <tr>
                <td style="width:100%; text-align:left;">
                    <table cellspacing="1px" cellpadding="1px" id="tblDates" style="width:100%;">
                    <tr>
                    <td style="width:15%;">
                                <asp:Label ID="Label6" runat="server">Rooster Name : </asp:Label>
                            </td>
                              <td style="width:35%;">
                                <asp:TextBox ID="txtRoosterName" CssClass="input_required" PlaceHolder="Rooster Name"  runat="server" ReadOnly="false" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                            <td style="width:15%;">
                                &nbsp;</td>
                             <td style="width:35%;">
                             </td>
                    </tr>
                        <tr>
                            <td style="width:15%;">
                                <asp:Label runat="server">Department : </asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtDepartment" CssClass="input_required" PlaceHolder="Creation Date"  runat="server" ReadOnly="true" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                            <td style="width:15%;">
                                <asp:Label ID="Label1" runat="server">Date : </asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtRoosterCreationDate" CssClass="input_required" PlaceHolder="Creation Date"  runat="server" ReadOnly="true" ClientIDMode="Static">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%;">
                                <asp:Label ID="Label2" runat="server">Date From : </asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtRoosterDateFrom" runat="server" CssClass="input_required clear" PlaceHolder="Date From" ClientIDMode="Static" ReadOnly="true">
                                </asp:TextBox>
                            </td>
                            <td style="width:15%;">
                                <asp:Label ID="Label3" runat="server">Date To : </asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtRoosterDateTo" runat="server" CssClass="input_required clear" PlaceHolder="Date To" ClientIDMode="Static" ReadOnly="true">
                                </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:15%;">
                                <asp:Label ID="Label5" runat="server">Shift :</asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:DropDownList ID="ddlShift" runat="server" CssClass="input_required clear" ClientIDMode="Static" >
                                    <asp:ListItem Value="0">Select The Shift For Which the Rooster is to be created</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width:15%;">
                                <asp:Label ID="Label4" runat="server">Shift Chng Dt :</asp:Label>
                            </td>
                            <td style="width:35%;">
                                <asp:TextBox ID="txtShiftChangeDate" runat="server" CssClass="input_required clear" PlaceHolder="Shift Change Date" ClientIDMode="Static" ReadOnly="true">
                                </asp:TextBox>
                            </td>
                         </tr>
                    </table>
                </td>
            </tr>
            <%--<tr>
                <td>
                    <br />
                </td>
            </tr>--%>
            <%--<tr>
                <td style="width:50%; text-align:center; padding:2px;">
                    <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input_required clear" ToolTip="Select The Department For Which the Rooster is to be created" ClientIDMode="Static" Width="99%">
                        <asp:ListItem Value="0">-----Select Department</asp:ListItem>
                    </asp:DropDownList>
                </td>
                
            </tr>--%>
        </table>
    </div>
    <div style="height:10px;">
        <br />
    </div>

    <div id="dvRoosterEmployees" style="width:100%; height:auto; border:0px; border-style:ridge;">
        <div id="dvSelectedEmployees" style="width:100%; float:left;">  <%--margin:0 auto;--%>
           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <table id="tblEmployeeList" cellpadding="0" cellspacing="0" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
                <%--<caption style="text-align:center;">
                    Available Personnel
                </caption>
                <thead>
                <tr style="width:100%;">
                    <td style="width:10%; border:0px; border-style:solid; text-align:center;">
                        Action
                    </td>
                    <td style="width:10%; border:0px; border-style:solid; text-align:center;">
                        Image
                    </td>
                    <td style="width:20%; border:0px; border-style:solid; text-align:center;">
                        Emp. ID
                    </td>
                    <td style="width:40%; border:0px; border-style:solid; text-align:center;">
                        Name
                    </td>
                    <td style="width:20%; border:0px; border-style:solid; text-align:center;">
                        Desig.
                    </td>
                </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="6" style="width:100%;">
                            <div style="width:100%; height:300px; max-height:300px; overflow:auto; background-color:Aqua;">
                                <table id="tblAvailableEmployeeList" style="width:100%;">
                                    <tr style="width:100%;">
                                        <td style="width:10%; border:1px; border-style:solid; text-align:center;">
                                        </td>
                                        <td style="width:10%; border:1px; border-style:solid; text-align:center;">
                                        </td>
                                        <td style="width:20%; border:1px; border-style:solid; text-align:center;">
                                        </td>
                                        <td style="width:40%; border:1px; border-style:solid; text-align:center;">
                                        </td>
                                        <td style="width:20%; border:1px; border-style:solid; text-align:center;">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>--%>
            </table>
        </div>
        <%--<div id="dvAvailableEmployees" style="width:30%; height:500px; float:right; border:1px;">
            <table id="tblRoosterSummery" style="width:100%; table-layout:fixed;">
                <caption style="text-align:center;">
                    Rooster Summery
                </caption>
                <tr style="width:100%;">
                    <th style="width:70%; border:1px; border-style:solid; text-align:center;">
                        Desig.
                    </th>
                    <th style="width:30%; border:1px; border-style:solid; text-align:center;">
                        Pers. Num.
                    </th>
                </tr>
            </table>
        </div>--%>
    </div>
<%--</div>--%>
