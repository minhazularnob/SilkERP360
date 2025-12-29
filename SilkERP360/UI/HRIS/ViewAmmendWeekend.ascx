<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewAmmendWeekend.ascx.cs" Inherits="SilkERP360.UI.HRIS.ViewAmmendWeekend" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" />
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" />

<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js"></script>

<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js"></script>
<%--<link href="../../Globals/jQuery/jquery-ui-1.10.3/themes/base/jquery-ui.css" rel="stylesheet" />
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery-ui.js"></script>--%>

<script src="Scripts/ViewAmmendWeekend.js"></script>

<div id="dvWorkGroupMaster" class="container-fluid border p-3">

    <!-- Header -->
    <div class="row mb-3">
        <div class="col-12 text-center">
            <h2 class="mb-3 fontSerif">WEEKEND VIEW / AMENDMENT</h2>
            <hr />
        </div>
    </div>

    <!-- Filters -->
    <div class="row justify-content-center mb-4">
        <div class="col-md-8">

            <div class="form-group row align-items-center mb-3">
                <label class="col-sm-3 col-form-label text-end">
                    Date :
                </label>


                <div class="col-sm-5">
                    <asp:TextBox
                        ID="txtWeekendDate"
                        runat="server"
                        CssClass="form-control text-center"
                        ReadOnly="true"
                        ClientIDMode="Static">
                    </asp:TextBox>
                </div>

                <div class="col-sm-4 text-sm-left mt-2 mt-sm-0">
                    <button
                        id="lnkWeekendList"
                        type="button"
                        class="btn btn-primary"
                        onclick="GetWeekendList(event);">
                        Get Weekend List
                    </button>
                </div>
            </div>

        </div>
    </div>

    <!-- Employee List -->
    <div class="row">
        <div class="col-12">
            <div id="dvEmployeeList" class="table-responsive">
                <table id="tblEmployees" class="table table-bordered table-striped">
                    <!-- Filled dynamically -->
                </table>
            </div>
        </div>
    </div>

</div>
