<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeTax.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmployeeTax" %>

<script src="Scripts/EmployeeTax.js"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div class="container-fluid my-4" id="dvWorkGroupMaster">
                <div class="card shadow-sm">

                    <!-- Page Header -->
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">Employee Tax</h2>
                    </div>

                    <div class="card-body">

                        <button type="button" class="btn btn-primary flex-fill" id="saveTaxBtnId" style="max-width: 150px;" onclick="SaveEmployeeTax(event);">
                            <i class="fa fa-save me-2"></i>Save
                        </button>

                        <div id="dvReportBody" class="table-responsive">
                            <table id="tblEmployeeTaxList" class="table custom-table fontSerif w-100"></table>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
