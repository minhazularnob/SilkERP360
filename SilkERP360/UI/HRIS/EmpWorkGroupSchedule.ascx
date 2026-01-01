<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpWorkGroupSchedule.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmpWorkGroupSchedule" %>

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
<script src="Scripts/EmployeeWorkGroupSchedule.js" type="text/javascript"></script>

<div class="container-fluid my-4" id="dvWorkGroupMaster">
    <div class="card shadow-sm">

        <!-- Page Header -->
        <div class="card-header text-center bg-white border-bottom">
            <h1 class=" fontSerif mb-0">Silkways Group Employee WorkGroup Schedule</h1>
        </div>

        <!-- Body -->
        <div class="card-body">

            <!-- Filter Section -->
            <div class="mb-4">
                <div class="row justify-content-center align-items-center g-2">

                    <div class="col-md-4 d-flex align-items-center">
                        <label for="txtScheduleDate" class="form-label mb-0 me-2">Select Date:</label>
                        <asp:TextBox ID="txtScheduleDate" runat="server"
                            CssClass="form-control text-center wg_read_only"
                            Style="width: 60%;" ReadOnly="true" ClientIDMode="Static" />
                        <a id="lnkGetSchedule" href="#" class="btn btn-primary ms-2" style="font-size: small"
                            onclick="GetEmployeeSchedule(event); return false;">
                            <i class="fa fa-search me-1"></i> Search
                        </a>
                    </div>

                </div>
            </div>

            <!-- WorkGroup Schedule Table -->
            <div id="dvWorkGroupSchedule" class="table-responsive">
                <table id="tblWorkGroupSchedule" class="table table-bordered table-striped w-100">
                    <!-- Schedule content will be dynamically loaded here -->
                </table>
            </div>

        </div>
    </div>
</div>

