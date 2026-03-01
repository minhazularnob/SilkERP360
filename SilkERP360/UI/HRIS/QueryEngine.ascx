<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QueryEngine.ascx.cs" Inherits="SilkERP360.UI.HRIS.QueryEngine" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />

<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/QueryEngine.js" type="text/javascript"></script>

<table  id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div id="dvWorkGroupMaster" class="container-fluid">
                <div class="card shadow-sm border-0">
                    <!-- Header -->
                    <div class="card shadow-sm">
                        <h3 class="mb-0 fontSerif">Silkways Group HRIS Query Engine (Employeewise Query)</h3>
                    </div>

                    <div class="card-body p-4">

                        <!-- Query Type + Employee Side by Side -->
                        <div class="row mb-3 justify-content-center">

                            <div class="col-md-5 col-lg-4">
                                <label for="ddlQueryType" class="form-label fw-bold small">
                                    Select Query Type
                                </label>

                                <asp:DropDownList ID="ddlQueryType"
                                    runat="server"
                                    CssClass="form-select form-select-sm"
                                    ClientIDMode="Static">

                                    <asp:ListItem Value="0">Select Report Type</asp:ListItem>
                                    <asp:ListItem Value="1">Employee Movement Tracker</asp:ListItem>
                                    <asp:ListItem Value="2">Employeewise Attendance</asp:ListItem>

                                </asp:DropDownList>
                            </div>

                            <div class="col-md-5 col-lg-4">
                                <label for="ddlEmployeeId" class="form-label fw-bold small">
                                    Select Employee
                                </label>

                                <asp:DropDownList ID="ddlEmployeeId"
                                    runat="server"
                                    CssClass="form-select form-select-sm"
                                    ClientIDMode="Static">

                                    <asp:ListItem>Select Employee</asp:ListItem>

                                </asp:DropDownList>
                            </div>

                        </div>

                        <%--<hr class="my-5 border-secondary">--%>

                        <!-- Date Inputs & Buttons -->
                        <div id="dvQueryInputEmployeeMovement" class="DV_QI_EMPLOYEE_MOVEMENT">
                            <div class="row justify-content-center mb-2" style="padding-left:16%">
                                <div class="col-12 col-xl-10">

                                    <div class="row g-2 align-items-center flex-nowrap">

                                        <!-- Start -->
                                        <div class="col-auto d-flex align-items-center">
                                            <label for="txtStartDateTime"
                                                class="me-2 small fw-semibold mb-0">
                                                Start:
                                            </label>

                                            <asp:TextBox ID="txtStartDateTime"
                                                CssClass="form-control form-control-sm QI_EMPLOYEE_MOVEMENT_CTRL"
                                                Style="width: 160px;"
                                                Enabled="false"
                                                ReadOnly="true"
                                                runat="server"
                                                ClientIDMode="Static" />
                                        </div>

                                        <!-- End -->
                                        <div class="col-auto d-flex align-items-center">
                                            <label for="txtEndDateTime"
                                                class="me-2 small fw-semibold mb-0">
                                                End:
                                            </label>

                                            <asp:TextBox ID="txtEndDateTime"
                                                CssClass="form-control form-control-sm QI_EMPLOYEE_MOVEMENT_CTRL"
                                                Style="width: 160px;"
                                                Enabled="false"
                                                ReadOnly="true"
                                                runat="server"
                                                ClientIDMode="Static" />
                                        </div>

                                        <!-- Buttons -->
                                        <div class="col-auto">
                                            <a id="lnkGetEmployeeMovement"
                                                href="#" class="btn btn-success btn-sm me-1 QI_EMPLOYEE_MOVEMENT_CTRL command_button_disabled">Movement
                                            </a>

                                            <a id="lnkGetEmployeewiseAttendance"
                                                href="#" class="btn btn-primary btn-sm QI_EMPLOYEE_MOVEMENT_CTRL command_button_disabled">Attendance
                                            </a>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Data Display Area -->
                        <div id="dvDataDisplay">

                            <!-- Employee Movement Table -->
                            <div id="dvMovementData" class="my-5" style="display: none;">
                                <div class="table-responsive">
                                    <table id="tblMovementData" class="table custom-table fontSerif w-100">
                                    </table>
                                </div>
                            </div>

                            <!-- Employee Attendance Details -->
                            <div id="dvEmployeewiseAttendance" style="display: none;">

                                <!-- Employee Info Card (Compact & Beautiful) -->
                                <div class="row justify-content-center fontSerif">
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
                                                                <asp:TextBox ID="txtEACompany" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-5 col-sm-4 fw-semibold text-secondary">Employee Id :</div>
                                                            <div class="col-7 col-sm-8">
                                                                <asp:TextBox ID="txtEAEmployeeId" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-5 col-sm-4 fw-semibold text-secondary">Employee Name :</div>
                                                            <div class="col-7 col-sm-8">
                                                                <asp:TextBox ID="txtEAEmployeeName" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-5 col-sm-4 fw-semibold text-secondary">Department :</div>
                                                            <div class="col-7 col-sm-8">
                                                                <asp:TextBox ID="txtEADepartment" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-5 col-sm-4 fw-semibold text-secondary">Designation :</div>
                                                            <div class="col-7 col-sm-8">
                                                                <asp:TextBox ID="txtEADesignation" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <!-- Right: Attendance Summary (Highlighted) -->
                                                    <div class="col-md-5">
                                                        <div class="row g-2">
                                                            <div class="col-6 col-sm-5 fw-semibold text-secondary">Tot M.Hour Committed :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtEATotalManHourCommitted" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-6 col-sm-5 fw-semibold text-secondary">Tot M.Hour Served :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtEATotalManHourServed" runat="server" CssClass="form-control form-control-sm bg-light wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-6 col-sm-5 fw-semibold text-success">Tot Overtime :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtEATotalOvertime" runat="server" CssClass="form-control form-control-sm bg-success text-white fw-bold wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-6 col-sm-5 fw-semibold text-warning">Total Absent % :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtTotalAbsentPercentage" runat="server" CssClass="form-control form-control-sm bg-warning text-dark fw-bold wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-6 col-sm-5 fw-semibold text-info">Total Late % :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtTotalLatePercentage" runat="server" CssClass="form-control form-control-sm bg-info text-white fw-bold wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>

                                                            <div class="col-6 col-sm-5 fw-semibold text-secondary">Att Date Range :</div>
                                                            <div class="col-6 col-sm-7">
                                                                <asp:TextBox ID="txtEAAttendanceDateRange" runat="server" CssClass="form-control form-control-sm bg-secondary text-white wg_read_only font-10" ReadOnly="true" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- Attendance Table -->
                                <div class="table-responsive">
                                    <table id="tblEmployeewiseAttendance" class="table custom-table fontSerif w-100">
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </td>
    </tr>
</table>

<style>
    .font-10 {
        font-size: 10px !important;
    }
</style>