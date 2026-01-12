<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceBySection.ascx.cs" Inherits="SilkERP360.UI.HRIS.AttendanceBySection" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>
<script src="Scripts/AttendanceBySection.js" type="text/javascript"></script>

<div class="container-fluid my-4" id="dvWorkGroupMaster">
    <div class="card shadow-sm">

        <!-- Page Header -->
        <div class="card-header text-center bg-white">
            <h2 class="fontSerif mb-0">Attendance By Section</h2>
        </div>

        <div class="card-body">

            <!-- Filter Section -->
            <div id="dvQCHead" class="border-bottom pb-3 mb-4">
                <div class="row align-items-center g-3">
                    
                    <!-- Section -->
                    <div class="col-md-3 text-md-end">
                        <label for="ddlSection" class="form-label">Section:</label>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlSection" runat="server" Width="100%" ClientIDMode="Static" CssClass="form-select">
                            <asp:ListItem Value='0'>----- All Section -----</asp:ListItem>
                            <asp:ListItem Value='1'>Producton Supervision</asp:ListItem>
                            <asp:ListItem Value='2'>Mixing</asp:ListItem>
                            <asp:ListItem Value='3'>Blowing</asp:ListItem>
                            <asp:ListItem Value='4'>Cutting</asp:ListItem>
                            <asp:ListItem Value='5'>Packaging</asp:ListItem>
                            <asp:ListItem Value='6'>Recycle</asp:ListItem>
                            <asp:ListItem Value='7'>Manual Work</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Work Date -->
                    <div class="col-md-1 text-md-end">
                        <label for="txtAttendanceDate" class="form-label">Work Date:</label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="txtAttendanceDate" runat="server" Style="text-align:center;" CssClass="form-control" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <!-- Get Attendance Button -->
                    <div class="col-md-2 text-md-start">
                        <a id="lnkGetAttendance" href="#" class="btn btn-primary" style="font-size: small" 
                           onclick="GetAttendanceByDesignationListAndDate(event); return false;">
                            Get Attendance
                        </a>
                    </div>

                </div>
            </div>

            <!-- Attendance Summary Section -->
            <div class="border-bottom pb-3 mb-4">

                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label>Total Employee:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalEmployee" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-1 text-md-end">
                        <label>Total On Leave:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalOnLeave" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label>Total Holiday:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalOnHoliday" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-1 text-md-end">
                        <label>Total Present:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalPresent" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label>Total Late:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalLate" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-1 text-md-end">
                        <label>Total Absent:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalAbsent" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

                <div class="row g-2 align-items-center mt-2">
                    <div class="col-md-3 text-md-end">
                        <label>Total Overtime:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalOvertime" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div class="col-md-1 text-md-end">
                        <label>Total Night Allowance:</label>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtTotalNightAllowance" runat="server" CssClass="wg_read_only form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>

            </div>

            <!-- Attendance Table -->
            <div id="dvAttendance" class="table-responsive">
                <table id="tblAttendance" class="table table-bordered w-100"></table>
            </div>

            <!-- Section Employee Table -->
            <div id="dvSectionEmployee" class="table-responsive mt-4">
                <table id="tblSectionEmployee" class="table table-bordered w-100"></table>
            </div>

        </div>
    </div>
</div>

