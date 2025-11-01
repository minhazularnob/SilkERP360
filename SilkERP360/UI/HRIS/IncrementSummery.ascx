<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementSummery.ascx.cs" Inherits="SilkERP360.UI.HRIS.IncrementSummery" %>
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


<script src="Scripts/IncrementSummery.js" type="text/javascript"></script>

<asp:HiddenField ID="hdnCurrencyFormatter" runat="server" ClientIDMode="Static" Value="0" />


<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr style="padding: 5px;">
        <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
            <div class="container-fluid my-4" id="dvWorkGroupMaster">
                <div class="card shadow-sm">
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">Increment Summary</h2>
                    </div>

                    <div class="card-body">
                        <!-- Filter Section -->
                        <div id="dvFilter" class="border-bottom pb-3 mb-4">
                            <div class="row align-items-center g-3">
                                <div class="col-md-3 text-md-end">
                                    <label for="ddlEmployee" class="form-label mb-0">Select Employee:</label>
                                </div>
                                <div class="col-md-6 d-flex align-items-center">
                                    <asp:DropDownList ID="ddlEmployee" runat="server"
                                        CssClass="form-select select2" ClientIDMode="Static">
                                        <asp:ListItem>------ Select Employee ------</asp:ListItem>
                                    </asp:DropDownList>
                                    <button id="btnShow" class="btn btn-primary ms-3"
                                        onclick="DisplayIncrementHistory(event); return false;">
                                        Show
                                    </button>
                                </div>
                            </div>
                        </div>

                        <!-- Report Header -->
                        <div id="dvReportHeader" class="border-bottom pb-3 mb-4">
                            <div class="row g-3 mb-3 align-items-center">
                                <div class="col-md-3 text-md-end">
                                    <label for="txtDesig" class="form-label">Designation:</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDesig" runat="server"
                                        CssClass="form-control text-start INC_IP"
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row g-3 mb-3 align-items-center">
                                <div class="col-md-3 text-md-end">
                                    <label for="txtDepartment" class="form-label">Department:</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDepartment" runat="server"
                                        CssClass="form-control text-start INC_IP"
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row g-3 align-items-center">
                                <div class="col-md-3 text-md-end">
                                    <label for="txtJoiningDate" class="form-label">Joining Date:</label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtJoiningDate" runat="server"
                                        CssClass="form-control text-start INC_IP"
                                        ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                        <!-- Report Body -->
                        <div id="dvReportBody" class="table-responsive">
                            <table id="tblIncrementSummery"
                                class="table custom-table fontSerif w-100 table-bordered table-striped align-middle text-center">
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
