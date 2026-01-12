<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Attendance.ascx.cs" Inherits="SilkERP360.UI.HRIS.Attendance" %>

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
<script src="Scripts/Attendance.js" type="text/javascript"></script>

<table>
    <tr>
        <td>
            <div class="container-fluid my-4 border border-2 p-3">
                <!-- Header -->
                <div class="mb-4 border-bottom pb-3 text-center">
                    <h2 class="fontSerif">Silkways Group Attendance Management App</h2>
                </div>

                <!-- Attendance Date -->
                <div class="row justify-content-center mb-4">
                    <div class="col-md-6 text-center">
                        <label for="txtAttendanceDate" class="form-label">Select Attendance Date:</label>
                        <div class="input-group justify-content-center">
                            <asp:TextBox ID="txtAttendanceDate" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static" Style="max-width: 20%;"></asp:TextBox>
                            <a id="lnkGetAttendance" href="#" class="btn btn-primary" onclick="GetAttendanceMaster(event);return false;">
                                <i class="fa fa-search"></i>Search
                            </a>

                        </div>
                    </div>
                </div>

                <!-- Attendance Stats -->
                <div class="container my-4">
                    <!-- Total Processed, Total On Leave, Total Holiday, Total Present -->
                    <div class="row mb-3">
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Processed:</label>
                            <asp:TextBox ID="txtTotalProcessed" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total On Leave:</label>
                            <asp:TextBox ID="txtTotalOnLeave" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Holiday:</label>
                            <asp:TextBox ID="txtTotalOnHoliday" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Present:</label>
                            <asp:TextBox ID="txtTotalPresent" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Total Late, Total Absent, M.Hour [OTH-EXP], M.Hour [OTH-SRVD] -->
                    <div class="row mb-3">
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Late:</label>
                            <asp:TextBox ID="txtTotalLate" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Absent:</label>
                            <asp:TextBox ID="txtTotalAbsent" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">M.Hour [OTH-EXP]:</label>
                            <asp:TextBox ID="txtTotalManHourExpectedOff" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">M.Hour [OTH-SRVD]:</label>
                            <asp:TextBox ID="txtTotalManHourServedOff" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                    <!-- M.Hour [O.T-EXP], M.Hour [O.T SRVD], Total Overtime, Salary Processed -->
                    <div class="row mb-3">
                        <div class="col-md-3">
                            <label class="form-label mb-0">M.Hour [O.T-EXP]:</label>
                            <asp:TextBox ID="txtTotalManHourExpectedOT" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">M.Hour [O.T SRVD]:</label>
                            <asp:TextBox ID="txtTotalManHourServedOT" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Overtime:</label>
                            <asp:TextBox ID="txtTotalOvertime" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Salary Processed:</label>
                            <asp:TextBox ID="txtIsSalaryProcessed" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Authorization Code, Total Night Allowance, Total Overtime Amount, Avg. Cost Of O.T / Hr -->
                    <div class="row mb-3">
                        <div class="col-md-3">
                            <label class="form-label mb-0">Authorization Code:</label>
                            <asp:TextBox ID="txtAuthorizationCode" runat="server" CssClass="form-control text-center" ReadOnly="false" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Night Allowance:</label>
                            <asp:TextBox ID="txtTotalNightAllowance" runat="server" CssClass="form-control text-center" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Total Overtime Amount:</label>
                            <asp:TextBox ID="txtTotalOvertimeAmount" runat="server" CssClass="form-control text-center bg-warning" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label mb-0">Avg. Cost Of O.T / Hr:</label>
                            <asp:TextBox ID="txtAverageCostOfOvertimePerHour" runat="server" CssClass="form-control text-center bg-warning" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </div>

                </div>



                <!-- Attendance Table Placeholder -->
                <div id="dvAttendance" class="table-responsive text-center">
                    <div class="row">
                        <div class="col-1">
                            <label>
                                <input type="checkbox" id="chkSelectAllRows">
                                Select/Deselect All</label>
                        </div>
                        <div class="col-3 text-start mb-2">
                            <select id="ddlBulkAttendanceStatus" class="form-select form-select-sm" style="width: 90% !important" >
                                <option value="">-- Select Status --</option>
                                <option value="2">ABSENT</option>
                                <option value="3">LATE</option>
                                <option value="4">LATE APPROVED</option>
                                <option value="6">ON LEAVE</option>
                                <option value="5">HOLIDAY</option>
                                <option value="8">WORK ON HOLIDAY</option>
                                <option value="9">OUTSIDE DUTY</option>
                                <option value="10">REPLACEMENT DUTY</option>
                                <option value="11">ON FOREIGN TOUR</option>
                                <option value="13">ABSENT OVERRIDDEN PRESENT</option>
                                <option value="14">SHIFT CHANGE HOLIDAY</option>
                            </select>
                        </div>

                        <div class="col-3 text-start mb-2">
                            <button type="button"
                                class="btn btn-primary btn-sm px-4 shadow-sm"
                                onclick="BulkUpdateAttendance()">
                                <i class="fa fa-pencil me-2"></i>
                                Update Selected Attendance
                            </button>
                        </div>
                    </div>
                    <table id="tblAttendance" class="table table-bordered table-striped mx-auto">
                        <!-- Dynamic Attendance Rows -->
                    </table>
                </div>
            </div>

        </td>
    </tr>
</table>

