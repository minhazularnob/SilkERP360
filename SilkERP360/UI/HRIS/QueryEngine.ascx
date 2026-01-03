<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QueryEngine.ascx.cs" Inherits="SilkERP360.UI.HRIS.QueryEngine" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />

<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.theme.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/jQuery/jquery-ui-1.11.2.custom/jquery-ui.js" type="text/javascript"></script>

<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/moment-develop/moment.js" type="text/javascript"></script>


<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>

<script src="Scripts/QueryEngine.js" type="text/javascript"></script>


<div id="dvWorkGroupMaster" class="container-fluid my-4">
    <div class="card shadow-sm border-0">
        <!-- Header -->
        <div class="card shadow-sm">
            <h2 class="mb-0 fontSerif fw-bold">Silkways Group HRIS Query Engine (Employeewise Query)</h2>
        </div>

        <div class="card-body p-4">

            <!-- Query Type Selection -->
            <div class="row mb-4">
                <div class="col-4"></div>
                <div class="col-4">
                    <label for="ddlQueryType" class="form-label fw-bold">Select Query Type :</label>
                    <asp:DropDownList ID="ddlQueryType" runat="server" CssClass="form-select form-select-lg" ClientIDMode="Static">
                        <asp:ListItem Value="0">----- Select Report Type</asp:ListItem>
                        <asp:ListItem Value="1">Employee Movement Tracker</asp:ListItem>
                        <asp:ListItem Value="2">Employeewise Attendance By Date Range</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-4"></div>

            </div>

            <!-- Employee Selection -->
            <div class="row mb-4">
                <div class="col-4"></div>

                <div class="col-4">
                    <label for="ddlEmployeeId" class="form-label fw-bold">Select Employee :</label>
                    <asp:DropDownList ID="ddlEmployeeId" runat="server" CssClass="form-select form-select-lg" ClientIDMode="Static">
                        <asp:ListItem>----- Select Employee</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-4"></div>

            </div>

            <hr class="my-5 border-secondary">

            <!-- Date Inputs & Buttons -->
            <div id="dvQueryInputEmployeeMovement" class="DV_QI_EMPLOYEE_MOVEMENT">
                <div class="row justify-content-center mb-5">
                    <div class="col-md-8 col-lg-6">
                        <div class="row g-3">
                            <div class="col-12">
                                <label for="txtStartDateTime" class="form-label">Start Date & Time :</label>
                                <asp:TextBox ID="txtStartDateTime"
                                    CssClass="form-control QI_EMPLOYEE_MOVEMENT_CTRL"
                                    Enabled="false"
                                    ReadOnly="true"
                                    runat="server"
                                    ClientIDMode="Static" />
                            </div>
                            <div class="col-12">
                                <label for="txtEndDateTime" class="form-label">End Date & Time :</label>
                                <asp:TextBox ID="txtEndDateTime"
                                    CssClass="form-control QI_EMPLOYEE_MOVEMENT_CTRL"
                                    Enabled="false"
                                    ReadOnly="true"
                                    runat="server"
                                    ClientIDMode="Static" />
                            </div>
                        </div>

                        <div class="text-end mt-4">
                            <a id="lnkGetEmployeeMovement" style="min-width:179px; padding: 1px"
                                href="#"
                                class="btn btn-success btn-lg me-3 QI_EMPLOYEE_MOVEMENT_CTRL command_button_disabled">
                                <i class="fas fa-route me-2"></i>Get Movement
                            </a>

                            <a id="lnkGetEmployeewiseAttendance" style="min-width:179px; padding: 1px"
                                href="#"
                                class="btn btn-primary btn-lg QI_EMPLOYEE_MOVEMENT_CTRL command_button_disabled">
                                <i class="fas fa-calendar-check me-2"></i>Get Attendance
                            </a>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Data Display Area -->
            <div id="dvDataDisplay">

                <!-- Employee Movement Table -->
                <div id="dvMovementData" class="my-5" style="display: none;">
                    <h2 class="text-center text-primary mb-4 fw-bold fontSerif">Employee Movement Tracker</h2>
                    <div class="table-responsive">
                        <table id="tblMovementData" class="table custom-table fontSerif w-100">
                        </table>
                    </div>
                </div>

                <!-- Employee Attendance Details -->
                <div id="dvEmployeewiseAttendance" style="display: none;">
                    <h2 class="text-center mb-5 text-primary fw-bold fontSerif">Employee Attendance Details</h2>

                    <!-- Employee Info Card (Compact & Beautiful) -->
                    <div class="row justify-content-center mb-5 fontSerif">
                        <div class="col-lg-11 col-xl-10">
                            <div class="card shadow-lg border-0 rounded-4 overflow-hidden">
                                <div class="card-body p-4 p-md-5">
                                    <div class="row g-4 align-items-start">

                                        <!-- Left: Employee Photo -->
                                        <div class="col-md-2 text-center">
                                            <asp:Image ID="imgEmployeeImage"
                                                runat="server"
                                                ClientIDMode="Static"
                                                CssClass="img-fluid rounded-4 shadow border"
                                                Height="180px"
                                                Width="160px"
                                                Style="object-fit: cover; border: 4px solid #fff;" />
                                        </div>

                                        <!-- Middle: Personal & Organizational Info -->
                                        <div class="col-md-5">
                                            <div class="row g-2">
                                                <div class="col-5 col-sm-4 fw-semibold text-secondary">Company :</div>
                                                <div class="col-7 col-sm-8">
                                                    <asp:TextBox ID="txtEACompany" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-5 col-sm-4 fw-semibold text-secondary">Employee Id :</div>
                                                <div class="col-7 col-sm-8">
                                                    <asp:TextBox ID="txtEAEmployeeId" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-5 col-sm-4 fw-semibold text-secondary">Employee Name :</div>
                                                <div class="col-7 col-sm-8">
                                                    <asp:TextBox ID="txtEAEmployeeName" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-5 col-sm-4 fw-semibold text-secondary">Department :</div>
                                                <div class="col-7 col-sm-8">
                                                    <asp:TextBox ID="txtEADepartment" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-5 col-sm-4 fw-semibold text-secondary">Designation :</div>
                                                <div class="col-7 col-sm-8">
                                                    <asp:TextBox ID="txtEADesignation" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>

                                        <!-- Right: Attendance Summary (Highlighted) -->
                                        <div class="col-md-5">
                                            <div class="row g-2">
                                                <div class="col-6 col-sm-5 fw-semibold text-secondary">Tot M.Hour Committed :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtEATotalManHourCommitted" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-6 col-sm-5 fw-semibold text-secondary">Tot M.Hour Served :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtEATotalManHourServed" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-6 col-sm-5 fw-semibold text-success">Tot Overtime :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtEATotalOvertime" runat="server" CssClass="form-control form-control-sm bg-success text-white fw-bold wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-6 col-sm-5 fw-semibold text-warning">Total Absent % :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtTotalAbsentPercentage" runat="server" CssClass="form-control form-control-sm bg-warning text-dark fw-bold wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-6 col-sm-5 fw-semibold text-info">Total Late % :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtTotalLatePercentage" runat="server" CssClass="form-control form-control-sm bg-info text-white fw-bold wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>

                                                <div class="col-6 col-sm-5 fw-semibold text-secondary">Att Date Range :</div>
                                                <div class="col-6 col-sm-7">
                                                    <asp:TextBox ID="txtEAAttendanceDateRange" runat="server" CssClass="form-control form-control-sm bg-secondary text-white wg_read_only" ReadOnly="true" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Attendance Table -->
                    <div class="table-responsive mt-5">
                        <table id="tblEmployeewiseAttendance" class="table custom-table fontSerif w-100">
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
