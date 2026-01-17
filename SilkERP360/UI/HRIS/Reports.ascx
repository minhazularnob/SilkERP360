<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reports.ascx.cs" Inherits="SilkERP360.UI.HRIS.Reports" %>
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
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <button id="downLoadReport" type="button" class="btn btn-primary">Download</button>
                </div>
            </div>

        </div>
    </div>
</div>