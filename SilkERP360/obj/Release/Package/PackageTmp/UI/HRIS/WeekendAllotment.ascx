<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WeekendAllotment.ascx.cs" Inherits="SilkERP360.UI.HRIS.WeekendAllotment" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />

<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" />
<%--<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js"></script>
<link href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" rel="stylesheet" />--%>

<script src="Scripts/WeekendAllotment.js" type="text/javascript"></script>

<div class="container-fluid my-4 border p-3" id="dvWorkGroupMaster">
    <h2 class="text-center mb-4 fontSerif">WEEKEND ALLOTMENT</h2>

    <div class="card mb-4" id="dvQCHead">
        <div class="card-body">
            <div class="row ">

                <!-- Date From -->
                <div class="col-md-3">
                    <label for="txtFromDate" class="form-label">Date From:</label>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control text-center WG_IP" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </div>

                <!-- Date Upto -->
                <div class="col-md-3">
                    <label for="txtUptoDate" class="form-label">Date Upto:</label>
                    <asp:TextBox ID="txtUptoDate" runat="server" CssClass="form-control text-center WG_IP" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                </div>

                <!-- Day Attribute Dropdown -->
                <div class="col-md-3">
                    <label for="ddlWeekday" class="form-label">Day Attribute:</label>
                    <asp:DropDownList ID="ddlWeekday" CssClass="form-select wg_read_only wg_day_attribute" runat="server" ClientIDMode="Static" style="width:80%">
                        <asp:ListItem Value="0">None</asp:ListItem>
                        <asp:ListItem Value="1">Saturday</asp:ListItem>
                        <asp:ListItem Value="2">Sunday</asp:ListItem>
                        <asp:ListItem Value="3">Monday</asp:ListItem>
                        <asp:ListItem Value="4">Tuesday</asp:ListItem>
                        <asp:ListItem Value="5">Wednesday</asp:ListItem>
                        <asp:ListItem Value="6">Thursday</asp:ListItem>
                        <asp:ListItem Value="7">Friday</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <!-- Get All Employees Button -->
                <div class="col-md-3 d-flex align-items-end">
                    <a id="lnkGetAllEmployees" href="#" class="btn btn-primary w-auto" onclick="GetAllEmployees(event); return false;">Get All Employees</a>
                </div>

            </div>
        </div>
    </div>

    <div class="card" id="dvEmployeeList">
        <div class="card-body">
            <table class="table table-bordered table-sm table-striped" id="tblEmployees">
            </table>
        </div>
    </div>
</div>