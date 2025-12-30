<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AttendanceSummery.ascx.cs" Inherits="SilkERP360.UI.HRIS.AttendanceSummery" %>
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

<script src="Scripts/AttendanceSummery.js" type="text/javascript"></script>

<table>
    <tr>
        <td>
            <div class="container-fluid my-4 border rounded p-3" id="dvWorkGroupMaster">
                <div class="text-center border-bottom pb-3 mb-4" id="dvQCHead">
                    <h2 class="fontSerif">Silkways Group Attendance Summary App</h2>
                </div>

                <!-- Attendance Date Selection -->
                <div class="row justify-content-center mb-4">
                    <div class="col-md-4 mb-3 text-center">
                        <label for="txtAttendanceDateFrom" class="form-label">Attendance Date (From)</label>
                        <input type="text" id="txtAttendanceDateFrom" class="form-control text-center" readonly>
                    </div>
                    <div class="col-md-4 mb-3 text-center">
                        <label for="txtAttendanceDateUpto" class="form-label">Attendance Date (Upto)</label>
                        <input type="text" id="txtAttendanceDateUpto" class="form-control text-center" readonly>
                    </div>
                    <div class="col-12 text-center">
                        <button class="btn btn-primary" id="lnkGetAttendanceSummery" onclick="GetAttendanceSummeryMaster(event); return false;">
                            Get Summary
                        </button>
                    </div>
                </div>

                <!-- Summary Information -->
                <div class="row justify-content-center mb-4">
                    <div class="col-md-6">
                        <div class="row mb-2">
                            <label class="col-6 col-form-label text-end">Total Employees:</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalEmployees" class="form-control text-center" readonly>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label class="col-6 col-form-label text-end">Total Expected Work Hour:</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalExpectedWorkHour" class="form-control text-center" readonly>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label class="col-6 col-form-label text-end">Total Overtime (Auto):</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalOvertimeAuto" class="form-control text-center" readonly>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label class="col-6 col-form-label text-end">Total Overtime:</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalOvertime" class="form-control text-center" readonly>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row mb-2">
                            <label class="col-2 col-form-label">Total Work Hour Served:</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalWorkHourServed" class="form-control text-center" readonly>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label class="col-2 col-form-label">Total Overtime Adj. (Manual):</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalOvertimeManual" class="form-control text-center" readonly>
                            </div>
                        </div>
                        <div class="row mb-2">
                            <label class="col-2 col-form-label">Total N. Allowance:</label>
                            <div class="col-6">
                                <input type="text" id="txtTotalNightAllowance" class="form-control text-center" readonly>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="dvReportBody" class="table-responsive">
                    <table id="tblAttendanceSummery" class="table custom-table fontSerif w-100">
                        <!-- Dynamic content will go here -->
                    </table>
                </div>
            </div>

        </td>
    </tr>
</table>


