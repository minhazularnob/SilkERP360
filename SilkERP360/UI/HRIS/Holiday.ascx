<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Holiday.ascx.cs" Inherits="SilkERP360.UI.HRIS.Holiday" %>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div class="container-fluid mt-4">

                <!-- Employee Holiday Form Header -->
                <div class="mb-4">
                    <h2 class="text-center">Employee Holiday Form</h2>
                    <div class="d-flex justify-content-end gap-2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary w-auto" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" />
                        <asp:Button ID="btnClose" runat="server" CssClass="btn btn-secondary w-auto" Text="Close" ClientIDMode="Static" OnClientClick="return false;" />
                    </div>
                </div>

                <!-- Holiday Selection -->
                <div class="card p-3 mb-4">
                    <div class="mb-3 row">
                        <label for="ddl_holidayName" class="col-sm-1 col-form-label">Holiday Name</label>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="ddl_holidayName" runat="server" class="form-select input-required" ClientIDMode="Static" PlaceHolder="Holiday Name">
                                <asp:ListItem Value="0">----- Select Holiday Name</asp:ListItem>
                                <asp:ListItem>Eid Milad un-Nabi</asp:ListItem>
                                <asp:ListItem>Lailatul Barat</asp:ListItem>
                                <asp:ListItem>Jumatul Wida/</asp:ListItem>
                                <asp:ListItem>Shab-e-Qadar</asp:ListItem>
                                <asp:ListItem>Shab-e-Miraj</asp:ListItem>
                                <asp:ListItem>Eid Ul Fitr (Rojar Eid)</asp:ListItem>
                                <asp:ListItem>Eid Ul Azha (Korbani Eid)</asp:ListItem>
                                <asp:ListItem>Muharram(Ashura)</asp:ListItem>
                                <asp:ListItem>Shahid Dibash (Language Martyrs' Day)</asp:ListItem>
                                <asp:ListItem>Independence Day</asp:ListItem>
                                <asp:ListItem>Islamic New Year</asp:ListItem>
                                <asp:ListItem>Bangla New Year's Day</asp:ListItem>
                                <asp:ListItem>New Year’s Day</asp:ListItem>
                                <asp:ListItem>May Day</asp:ListItem>
                                <asp:ListItem>Bijoy Dibosh (Victory Day)</asp:ListItem>
                                <asp:ListItem>National Revolution Day</asp:ListItem>
                                <asp:ListItem>Bank Holiday</asp:ListItem>
                                <asp:ListItem>Krishna Janmashtami</asp:ListItem>
                                <asp:ListItem>Durga Puja (Vijaya Dasami)</asp:ListItem>
                                <asp:ListItem>National Mourning Day</asp:ListItem>
                                <asp:ListItem>Buddha Purnima (Buddha's Birthday)</asp:ListItem>
                                <asp:ListItem>Christmas</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Date and Remarks Section -->
                    <div class="row g-3">
                        <div class="col-md-3">
                            <label for="txt_DecDateTime" class="form-label">Declaration Date</label>
                            <asp:TextBox ID="txt_DecDateTime" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Declaration DateTime" CssClass="form-control input-required"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="txt_StartDate" class="form-label">Start Date</label>
                            <asp:TextBox ID="txt_StartDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Start Date" CssClass="form-control input-required"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="txt_EndDate" class="form-label">End Date</label>
                            <asp:TextBox ID="txt_EndDate" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="End Date" CssClass="form-control input-required"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label for="txt_NumDays" class="form-label">Number of Days</label>
                            <asp:TextBox ID="txt_NumDays" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Number of Days" CssClass="form-control input-required"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row mt-3">
                        <div class="col-md-7">
                        </div>
                        <label for="txt_Remarks" class="form-label">Remarks</label>

                        <asp:TextBox ID="txt_Remarks" runat="server" ClientIDMode="Static" Width="50%" PlaceHolder="Remarks" TextMode="MultiLine" CssClass="form-control" Rows="3"></asp:TextBox>
                    </div>

                </div>

                <!-- Holiday Employees Table -->
                <div class="card p-3">
                    <h5>Holiday Employees</h5>
                    <div class="table-responsive">
                        <table id="tblHolidayList" class="table table-bordered table-striped table-hover" style="font-size: 12px;">
                        </table>
                    </div>
                </div>

            </div>

        </td>
    </tr>
</table>



<!-- Scripts -->
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/HRIS/Holiday.js" type="text/javascript"></script>
