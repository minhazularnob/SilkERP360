<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Shift.ascx.cs" Inherits="SilkERP360.UI.HRIS.Shift" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>


<script src="../../Globals/Scripts/SilkERP360/HRIS/Shift.js" type="text/javascript"></script>


<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div id="Department" style="width: 100%;">

                <h2 class="fontSerif">SHIFT</h2>
                <p class="login button">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save();return false;" Style="width: 70px;" />
                    <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false" Style="width: 70px;" />
                </p>

            </div>
            <br />


            <div id="divShift" style="border-color: inherit; font-family: Verdana; font-size: 12px;">

                <table id="tblShift" style="width: 100%; height: auto; table-layout: fixed">
                    <tr>
                        <td style="width: 15%">
                            <asp:Label ID="Label1" runat="server">Shift Name : </asp:Label>
                        </td>
                        <td style="width: 35%">
                            <asp:TextBox ID="txt_ShiftName" runat="server" ReadOnly="false" ClientIDMode="Static" CssClass="input-required" placeHolder="Shift Name">
                            </asp:TextBox>
                        </td>
                        <td style="width: 15%">
                            <asp:Label ID="Label10" runat="server">Start Time : </asp:Label>
                        </td>
                        <td style="width: 35%">
                            <asp:TextBox ID="txt_StartTime" runat="server" ReadOnly="false" ClientIDMode="Static" CssClass="input-required" PlaceHolder="Start Time">
                            </asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                            <asp:Label ID="Label12" runat="server">End Time : </asp:Label>
                        </td>
                        <td style="width: 35%">

                            <asp:TextBox ID="txt_EndTime" runat="server" ReadOnly="false" ClientIDMode="Static" placeHolder="End Time" CssClass="input-required">
                            </asp:TextBox>

                        </td>
                        <td style="width: 15%">
                            <asp:Label ID="Label11" runat="server">Tolerance Time : </asp:Label>
                        </td>
                        <td style="width: 35%">
                            <asp:TextBox ID="txt_ToleranceTime" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Tolerance Time" CssClass="input-required">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%">
                            <asp:Label ID="Label3" runat="server">Sort Order : </asp:Label>
                        </td>
                        <td style="width: 35%">
                            <asp:TextBox ID="txt_SortOrder" runat="server" ReadOnly="false" ClientIDMode="Static" CssClass="input-required" placeHolder="Sort Order">
                            </asp:TextBox>
                        </td>
                        <td style="width: 15%">
                            <asp:Label ID="Label5" runat="server">Regular Duty Hour : </asp:Label>
                        </td>
                        <td style="width: 35%">
                            <asp:TextBox ID="txt_RgrDutyHour" ClientIDMode="Static" runat="server" CssClass="input required" Placeholder="Regular Duty Hour" ReadOnly="false">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div id="dvRoosterEmployees" style="width: 100%; height: auto; border: 0px; border-style: ridge;">
                    <div id="dvSelectedEmployees" style="width: 100%; float: left;">
                        <table id="tblShiftList" class="table custom-table fontSerif w-100">
                        </table>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
