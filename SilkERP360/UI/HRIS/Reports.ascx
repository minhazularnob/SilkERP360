<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reports.ascx.cs" Inherits="SilkERP360.UI.HRIS.Reports" %>

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

<script src="Scripts/Reports.js" type="text/javascript"></script>


<div id="dvWorkGroupMaster" class="container-fluid my-4">
    <div class="card shadow-sm border-0">
        <!-- Header -->
        <div class="card shadow-sm">
            <h2 class="mb-0 fontSerif">Download Report</h2>
        </div>

        <div class="card-body p-4">

            <div class="row g-2 align-items-center mt-2">
                <div class="col-md-3 text-md-end">
                    <label for="ddlNewDesignation" class="form-label">Report Name:</label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="reportName" runat="server"
                        CssClass="js-example-basic-multiple" ClientIDMode="Static">
                        <asp:ListItem Value="0">------ Select Report ------</asp:ListItem>
                        <asp:ListItem Value="0001">EmployeeList</asp:ListItem>
                        <asp:ListItem Value="0002">Attendance</asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <button id="downLoadReport" type="button" class="btn btn-primary">Download</button>
                </div>
            </div>
            <div id="datepickerDiv"  style="display: none">
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col-3">
                        <label for="rptTxtStartDateTime" class="form-label">Start Date & Time :</label>
                        <asp:TextBox ID="rptTxtStartDateTime"
                            CssClass="form-control QI_EMPLOYEE_MOVEMENT_CTRL"
                            runat="server"
                            ClientIDMode="Static" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3"></div>
                    <div class="col-3">
                        <label for="rptTxtEndDateTime" class="form-label">End Date & Time :</label>
                        <asp:TextBox ID="rptTxtEndDateTime"
                            CssClass="form-control QI_EMPLOYEE_MOVEMENT_CTRL"
                            runat="server"
                            ClientIDMode="Static" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
