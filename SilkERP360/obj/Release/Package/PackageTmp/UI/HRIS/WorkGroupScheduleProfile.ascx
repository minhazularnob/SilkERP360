<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WorkGroupScheduleProfile.ascx.cs" Inherits="SilkERP360.UI.HRIS.WorkGroupScheduleProfile" %>



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

<script src="Scripts/WorkGroupScheduleProfile.js" type="text/javascript"></script>

<div class="container-fluid my-4" id="dvWorkGroupMaster">
    <div class="card shadow-sm">

        <!-- Card Header -->
        <div class="card-header text-center bg-white border-bottom">
            <h2 class=" fontSerif mb-0">Silkways Group WorkGroup Schedule</h2>
        </div>

        <!-- Card Body -->
        <div class="card-body">

            <!-- Filter Section -->
            <div class="mb-4">
                <div class="row justify-content-center align-items-center g-2">

                    <div class="col-md-6 d-flex align-items-center justify-content-center">
                        <label for="txtScheduleDate" class="form-label mb-0 me-2">Select Date:</label>
                        <asp:TextBox ID="txtScheduleDate" runat="server"
                            CssClass="form-control text-center wg_read_only"
                            Style="width: 60%;" ReadOnly="true" ClientIDMode="Static" />
                        <a id="lnkGetSchedule" href="#" class="btn btn-primary ms-2"
                            onclick="GetWorkGroupSchedule(event); return false;">
                            <i class="fa fa-search me-1"></i>
                        </a>
                    </div>

                </div>
            </div>

            <div class="row align-items-end g-2">
                <div class="col-12 col-md-3 mb-1">
                    <label for="authorizationCodeText" class="form-label">
                        Authorization Code:
                    </label>
                    <input
                        type="text"
                        id="authorizationCodeText"
                        class="form-control"
                        placeholder="Enter authorization code to delete workgroup" />
                </div>

                <div class="col-12 col-md-auto mb-1">
                    <button
                        id="btnDeleteWorkGroup" type="button"
                        class="btn btn-danger w-100 w-md-auto fs-6">
                        <i class="fa fa-trash me-2"></i>
                        Delete WorkGroup
                    </button>
                </div>
            </div>

            <!-- WorkGroup Schedule Table -->
            <div id="dvWorkGroupSchedule" class="table-responsive">
                <label>
                    <input type="checkbox" id="chkUncheckAllRows">
                    Select/Deselect All</label>
                <table id="tblWorkGroupSchedule" class="table table-bordered table-striped w-100">
                    <!-- Schedule content will load here dynamically -->
                </table>
            </div>

        </div>
    </div>
</div>

