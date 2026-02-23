<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmpLeaveApp.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmpLeaveApp" %>

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
<link href="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/auto-complete/auto-complete.js" type="text/javascript"></script>
<script src="Scripts/EmpLeaveApp.js" type="text/javascript"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div class="container-fluid my-4" id="dvWorkGroupMaster">
                <div class="card shadow-sm">

                    <!-- Page Header -->
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">Silkways Group Leave Management App</h2>
                    </div>

                    <div class="card-body">

                        <!-- Employee Selection -->
                        <div class="border-bottom pb-3 mb-4">
                            <div class="row align-items-center g-3">
                                <div class="col-md-3 text-md-end">
                                    <label class="form-label mb-0">Select Employee:</label>
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlEmployeeId" runat="server"
                                        CssClass="form-select"
                                        ClientIDMode="Static">
                                        <asp:ListItem>----- Select Employee -----</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    <a id="lnkGetLeaveProfile" href="#"
                                        class="btn btn-primary" style="font-size: inherit"
                                        onclick="GetEmployeeLeaveProfile(event);Clear(event); return false;">
                                        <i class="fa fa-search me-1"></i>Search
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="border-bottom pb-3 mb-4">
                            <div class="row g-2 align-items-center">

                                <!-- Employee Name -->
                                <div class="col-md-4 d-flex align-items-center">
                                    <label class="form-label mb-0 me-2">Employee Name:</label>
                                    <asp:TextBox ID="txtEmpName" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>

                                <%--<!-- Designation -->
                                <div class="col-md-4 d-flex align-items-center">
                                    <label class="form-label mb-0 me-2">Designation:</label>
                                    <asp:TextBox ID="txtDesignation" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>--%>

                                <!-- Department -->
                                <div class="col-md-4 d-flex align-items-center">
                                    <label class="form-label mb-0 me-2">Designation:</label>
                                    <asp:TextBox ID="leaveDesignation" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>

                                <!-- Department -->
                                <div class="col-md-4 d-flex align-items-center">
                                    <label class="form-label mb-0 me-2">Department:</label>
                                    <asp:TextBox ID="txtDepartment" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>

                            </div>
                        </div>


                        <!-- Leave Balance -->
                        <div class="border-bottom pb-3 mb-4">
                            <div class="row g-2 text-center">
                                <div class="col-md-3">
                                    <label>Casual Leave (CL)</label>
                                    <asp:TextBox ID="txtCL" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>
                                <div class="col-md-3">
                                    <label>Sick Leave (SL)</label>
                                    <asp:TextBox ID="txtSL" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>
                                <div class="col-md-3">
                                    <label>Maternity Leave (ML)</label>
                                    <asp:TextBox ID="txtML" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>
                                <div class="col-md-3">
                                    <label>Earned Leave (EL)</label>
                                    <asp:TextBox ID="txtEL" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>
                            </div>
                        </div>

                        <!-- Leave Application List -->
                        <div class="table-responsive mb-4" style="max-height: 350px;">
                            <table id="tblEmpLeaveAppList" class="table table-bordered w-100"></table>
                        </div>

                        <!-- Leave Application Form -->
                        <div class="border-top pt-3">

                            <div class="row g-2 align-items-center">
                                <div class="col-md-2 text-md-end">
                                    <label>Leave Type:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlLeaveType" runat="server"
                                        CssClass="form-select"
                                        ClientIDMode="Static">
                                        <asp:ListItem Value="0">None</asp:ListItem>
                                        <asp:ListItem Value="1">Casual Leave (CL)</asp:ListItem>
                                        <asp:ListItem Value="2">Sick Leave (SL)</asp:ListItem>
                                        <asp:ListItem Value="3">Maternity Leave (ML)</asp:ListItem>
                                        <asp:ListItem Value="4">Earned Leave (EL)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label>Category:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlLeaveCategory" runat="server"
                                        CssClass="form-select"
                                        ClientIDMode="Static">
                                        <asp:ListItem Value="1">Paid</asp:ListItem>
                                        <asp:ListItem Value="2">Unpaid</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-2 text-md-end">
                                    <label>Date From:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtStartDate" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label>Date Upto:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtEndDate" runat="server"
                                        CssClass="form-control text-center"
                                        ClientIDMode="Static" />
                                </div>
                            </div>

                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-2 text-md-end">
                                    <label>Num of Days:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtNumOfDays" runat="server"
                                        CssClass="form-control text-center"
                                        ReadOnly="true" ClientIDMode="Static" />
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label>Rejoin Date:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtRejoinDate" runat="server"
                                        CssClass="form-control text-center"
                                        ClientIDMode="Static" />
                                </div>
                            </div>

                            <div class="row g-2 align-items-center mt-2">
                                <div class="col-md-2 text-md-end">
                                    <label>Reason:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtReason" runat="server"
                                        CssClass="form-control"
                                        ClientIDMode="Static" />
                                </div>

                                <div class="col-md-2 text-md-end">
                                    <label>Remarks:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtRemarks" runat="server"
                                        CssClass="form-control"
                                        ClientIDMode="Static" />
                                </div>
                            </div>

                            <div class="d-flex justify-content-end mt-3 gap-2">
                                <!-- Clear Button -->
                                <button class="btn btn-info" onclick="Clear(event); return false;">
                                    <i class="fa fa-eraser me-1"></i>Clear
                                </button>

                                <!-- Save Button -->
                                <button class="btn btn-success" onclick="SaveLeaveApplication(event); return false;">
                                    <i class="fa fa-save me-1"></i>Save
                                </button>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
