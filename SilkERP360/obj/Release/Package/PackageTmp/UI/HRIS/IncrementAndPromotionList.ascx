<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IncrementAndPromotionList.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.IncrementAndPromotionList" %>


<script src="Scripts/IncrementAndPromotionList.js"></script>

<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr>
        <td>
            <div class="container-fluid my-4" id="dvWorkGroupMaster">
                <div class="card shadow-sm">

                    <!-- Page Header -->
                    <div class="card-header text-center bg-white">
                        <h2 class="fontSerif mb-0">Increment & Promotion History</h2>
                    </div>

                    <div class="card-body">
                        <div id="dvReportBody" class="table-responsive">
                            <asp:TextBox ID="incrementAndpromotionHistory_txtStartDate" runat="server" style="text-align:center;" CssClass="WG_IP" Width="10%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>To
                            <asp:TextBox ID="incrementAndpromotionHistory_txtEndDate" runat="server" style="text-align:center;" CssClass="WG_IP" Width="10%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            <table id="tblIncrementAndPromotionHistory" class="table custom-table fontSerif w-100"></table>
                        </div>
                    </div>
                </div>
            </div>
        </td>
    </tr>
</table>
