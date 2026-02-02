<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Loan.ascx.cs" Inherits="SilkERP360.UI.HRIS.Loan" %>
<script src="Scripts/Loan.js"></script>

<div id="loanWrapper" class="container-fluid mt-3">
    <div class="row mb-3">
        <div class="col-md-12 text-center">
            <h1 class="mb-3" style="font-family: serif;">Loan Management</h1>
            <div id="dvReportBody" class="table-responsive">
                <table id="tblEmployeeLoanList" class="table custom-table fontSerif w-100"></table>
            </div>
            <button type="button" class="btn btn-primary" onclick="OpenModal()">Create Loan</button>
        </div>
    </div>
</div>

<!-- Loan Modal -->
<div class="modal fade" id="loanModal" tabindex="-1" aria-labelledby="loanModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-scrollable">
        <div class="modal-content">

            <div class="modal-header bg-primary text-white">
                <h5 class="modal-title" id="loanModalLabel">Create Loan</h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>

            <div class="modal-body">
                <form id="loanForm">
                    <div class="row g-3">

                        <!-- Employee -->
                        <div class="col-md-6">
                            <label class="form-label">Employee</label>
                            <asp:DropDownList ID="employeeIdLoan" runat="server"
                                CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>

                        <!-- Loan Type -->
                        <div class="col-md-6">
                            <label class="form-label">Loan Type</label>
                            <asp:DropDownList ID="loanTypeId" runat="server"
                                CssClass="form-control select2" Width="95%" ClientIDMode="Static">
                                <asp:ListItem Text="Select Loan Type" Value="" />
                                <asp:ListItem Text="Staff Loan" Value="1" />
                                <asp:ListItem Text="Salary Advance" Value="2" />
                                <asp:ListItem Text="Vehicle Loan" Value="3" />
                                <asp:ListItem Text="Housing Loan" Value="4" />
                                <asp:ListItem Text="Medical Loan" Value="5" />
                                <asp:ListItem Text="Education Loan" Value="6" />
                                <asp:ListItem Text="Festival Loan" Value="7" />
                                <asp:ListItem Text="Emergency Loan" Value="8" />
                            </asp:DropDownList>
                        </div>

                        <!-- Loan Amount -->
                        <div class="col-md-6">
                            <label class="form-label">Loan Amount</label>
                            <input type="number" class="form-control" id="loanAmount" placeholder="Enter loan amount" />
                        </div>

                        <!-- Installments -->
                        <div class="col-md-6">
                            <label class="form-label">Installments</label>
                            <input type="number" class="form-control" id="installments" placeholder="Enter number of installments" />
                        </div>

                        <!-- Start Month -->
                        <div class="col-md-3">
                            <label class="form-label">Start Month</label>
                            <select class="form-select" id="month">
                                <option value="0">Jan</option>
                                <option value="1">Feb</option>
                                <option value="2">Mar</option>
                                <option value="3">Apr</option>
                                <option value="4">May</option>
                                <option value="5">Jun</option>
                                <option value="6">Jul</option>
                                <option value="7">Aug</option>
                                <option value="8">Sep</option>
                                <option value="9">Oct</option>
                                <option value="10">Nov</option>
                                <option value="11">Dec</option>
                            </select>
                        </div>

                        <!-- Start Year -->
                        <div class="col-md-3">
                            <label class="form-label">Start Year</label>
                            <select class="form-select" id="startYear">
                                <option value="">Select Year</option>
                            </select>
                        </div>

                    </div>

                    <!-- Generate Schedule Button -->
                    <div class="mt-3">
                        <button type="button" class="btn btn-primary" id="createSchedule">Generate Schedule</button>
                    </div>

                    <hr class="my-3" />

                    <!-- Schedule Table -->
                    <div class="table-responsive">
                        <table class="table table-bordered table-striped custom-table fontSerif w-100">
                            <thead class="table-dark">
                                <tr>
                                    <th>No</th>
                                    <th>Month</th>
                                    <th>Year</th>
                                    <th>Scheduled Amount</th>
                                </tr>
                            </thead>
                            <tbody id="scheduleBody"></tbody>
                        </table>
                    </div>
                </form>
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary" id="loanSaveId" onclick="SaveStaffLoan()">Save</button>
            </div>
        </div>
    </div>
</div>
