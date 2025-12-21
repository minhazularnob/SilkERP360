<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BonusMaster.ascx.cs" Inherits="SilkERP360.UI.HRIS.BonusMaster" %>
<script src="Scripts/BonusMaster.js" type="text/javascript"></script>

<!-- Bootstrap container and grid layout -->
<table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
    <tr style="padding: 5px;">
        <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
            <div class="container-fluid" style="border: 1px ridge black;">
                <h1 class="text-center fontSerif">BONUS MASTER</h1>

                <!-- Row for form elements -->
                <div class="row align-items-center">
                    <!-- Dropdown -->
                    <div class="col-md-5">
                        <asp:DropDownList
                            ID="ddlBonusMaster"
                            runat="server"
                            CssClass="form-control"
                            ClientIDMode="Static">
                            <asp:ListItem Value="0">----- Select Bonus Master</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Button -->
                    <div class="col-md-2">
                        <a id="lnkGetBonusMaster"
                            href="#"
                            onclick="GetBonusMaster()"
                            class="btn btn-primary fontSerif w-100"
                            style="height: 36px;">Get Bonus
                        </a>
                    </div>
                </div>
                <!-- Table displaying bonus list -->
                <div class="row" style="margin-top: 1%">
                    <div class="col-12">
                        <div class="table-responsive">
                            <!-- Small text size for table and its contents -->
                            <table id="tblBonusList" class="table table-bordered table-sm fontSerif">
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </td>
    </tr>
</table>