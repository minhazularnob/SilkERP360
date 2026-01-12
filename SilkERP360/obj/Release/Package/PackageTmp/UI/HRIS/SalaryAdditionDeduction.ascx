<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="SalaryAdditionDeduction.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.SalaryAdditionDeduction" %>

<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/SalaryAdditionDeduction.js"></script>

<div class="container-fluid">
    
    <!-- SalAddDEduc Placeholder -->
    <div id="SalAddDEduc" class="mb-3" style="width: 100%;"></div>

    <!-- ================= Employee Image ================= -->
    <div id="ImagTab" class="row justify-content-center my-3">
        <div class="col-md-4"></div>
        <div class="col-md-4 text-end">
            <asp:Image ID="imgEmployeeImage" runat="server"
                ClientIDMode="Static"
                class="img-fluid rounded shadow-sm"
                style="max-height: 160px; max-width: 160px;" />
        </div>
        <div class="col-md-4"></div>
    </div>

    <!-- ================= Employee Info ================= -->
    <div id="tblBod" class="p-3 mb-3" style="border:1px solid #ccc;">
        <div class="row mb-2">
            <div class="col-2">Employee ID</div>
            <div class="col-4">
                <asp:TextBox ID="txt_EmpID" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" />
            </div>

            <div class="col-2">Employee Name</div>
            <div class="col-4">
                <asp:TextBox ID="txt_Sal_AddDed_EmpName" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-2">Designation</div>
            <div class="col-4">
                <asp:TextBox ID="txt_Sal_AddDed_Designation" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" />
            </div>

            <div class="col-2">Department</div>
            <div class="col-4">
                <asp:TextBox ID="txt_Sal_AddDed_Department" runat="server" ClientIDMode="Static" ReadOnly="true" class="form-control" />
            </div>
        </div>
    </div>

    <!-- ================= Salary Add/Ded Section ================= -->
    <div id="dvBody" class="p-3 mb-3" style="border:1px solid #ccc;">
        <!-- Header -->
        <div class="row fw-bold text-center">
            <div class="col-1">Date</div>
            <div class="col-1">Add/Ded</div>
            <div class="col-2">Add/Ded Type</div>
            <div class="col-1">Eff. Month</div>
            <div class="col-1">Eff. Year</div>
            <div class="col-1">Amount</div>
            <div class="col-5">Remarks</div>
        </div>

        <!-- Input Row -->
        <div class="row text-center mt-2">
            <div class="col-1">
                <asp:TextBox ID="txt_AddDed_Date" runat="server" ClientIDMode="Static" class="form-control text-center" />
            </div>

            <div class="col-1">
                <asp:DropDownList ID="ddl_sal_AddOrDed" runat="server" ClientIDMode="Static" class="form-select">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                    <asp:ListItem Value="1">Addition</asp:ListItem>
                    <asp:ListItem Value="2">Deduction</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-2">
                <asp:DropDownList ID="ddl_sal_Addition" runat="server" ClientIDMode="Static" class="form-select mb-1">
                    <asp:ListItem Value="0">Select Addition</asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList ID="ddl_sal_Deduction" runat="server" ClientIDMode="Static" class="form-select">
                    <asp:ListItem Value="0">Select Deduction</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-1">
                <asp:DropDownList ID="ddl_sal_EffectMonth" runat="server" ClientIDMode="Static" class="form-select">
                    <asp:ListItem Value="1">January</asp:ListItem>
                    <asp:ListItem Value="2">February</asp:ListItem>
                    <asp:ListItem Value="3">March</asp:ListItem>
                    <asp:ListItem Value="4">April</asp:ListItem>
                    <asp:ListItem Value="5">May</asp:ListItem>
                    <asp:ListItem Value="6">June</asp:ListItem>
                    <asp:ListItem Value="7">July</asp:ListItem>
                    <asp:ListItem Value="8">August</asp:ListItem>
                    <asp:ListItem Value="9">September</asp:ListItem>
                    <asp:ListItem Value="10">October</asp:ListItem>
                    <asp:ListItem Value="11">November</asp:ListItem>
                    <asp:ListItem Value="12">December</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-1">
                <asp:DropDownList ID="ddl_sal_EffectYear" runat="server" ClientIDMode="Static" class="form-select">
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                    <asp:ListItem Value="2025">2025</asp:ListItem>
                    <asp:ListItem Value="2026">2026</asp:ListItem>
                    <asp:ListItem Value="2027">2027</asp:ListItem>
                    <asp:ListItem Value="2028">2028</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-1">
                <asp:TextBox ID="txt_Sal_AddDed_Amount" runat="server" ClientIDMode="Static" class="form-control text-end" />
            </div>

            <div class="col-5">
                <asp:TextBox ID="txt_Sal_AddDedRemarks" runat="server" ClientIDMode="Static" class="form-control" />
            </div>
        </div>

        <!-- Buttons -->
        <div class="row mt-2">
            <div class="col-12 text-end">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" Style="width:120px;" OnClientClick="Save();return false;" />
                <asp:Button ID="btnLoad" runat="server" Text="Show Detail" CssClass="btn btn-secondary" Style="width:120px;" OnClientClick="LoadSalaryAddition();return false;" />
            </div>
        </div>
    </div>

    <!-- ================= Employee List ================= -->
    <div id="dvRoosterEmployees" class="mb-3">
        <table id="tblEmployeeList" class="table custom-table fontSerif w-100" style="border:1px solid #999;"></table>
    </div>

</div>
