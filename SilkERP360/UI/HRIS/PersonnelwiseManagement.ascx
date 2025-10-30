<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonnelwiseManagement.ascx.cs" Inherits="SilkERP360.UI.HRIS.PersonnelwiseManagement" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>
<script src="Scripts/PersonnelwiseManagement.js" type="text/javascript"></script>

<style type="text/css">
    .overlay {
        background: transparent url(images/overlay.png) repeat top left;
        position: fixed;
        top: 0px;
        bottom: 0px;
        left: 0px;
        right: 0px;
        z-index: 100;
    }

    .box {
        position: fixed;
        top: 200px;
        left: 30%;
        right: 30%;
        background-color: #fff;
        color: #7F7F7F;
        padding: 20px;
        border: 2px solid #ccc;
        -moz-border-radius: 20px;
        -webkit-border-radius: 20px;
        -khtml-border-radius: 20px;
        -moz-box-shadow: 0 1px 5px #333;
        -webkit-box-shadow: 0 1px 5px #333;
        z-index: 101;
    }

    a.boxclose {
        float: right;
        width: 26px;
        height: 26px;
        background: transparent url(../../Globals/Images/cancel.png) repeat top left;
        cursor: pointer;
    }

    .sub_form {
        opacity: 0;
        display: none;
        position: absolute;
        width: 100%;
        height: 800px;
        top: -800px;
        z-index: 101;
    }
</style>
<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {
            $("#dvSubForm").css("top", "-800px");
        });
    });
</script>

<div id="dvBody" class="ui_control_wrapper" style="width: 100%; height: auto; margin: 0 auto; text-align: left;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <!-- Page Header -->
                <div id="cmd" style="width: 100%; text-align: center; padding: 10px 0;">
                    <h1 style="font-family: serif !important;">Personnelwise HRIS Management</h1>
                </div>

                <!-- Scrollable Content Container -->
                <div id="dRoosterFormContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height: 0;">
                    <div class="container-fluid">

                        <!-- Sub Form Section -->
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div id="dvRoosterForm" style="width: 100%; position: relative;">

                                    <div id="dvSubForm" class="sub_form ui_control_wrapper" style="height: auto; min-height: 1024px;">
                                        <a class="boxclose" id="boxclose"></a>
                                        <h2 id="hdrSubForm">Important message</h2>
                                        <div id="dvSubFormContainer">
                                            <br />
                                        </div>
                                    </div>

                                    <!-- Department DropDown -->
                                    <div class="row mt-3">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <table class="ip_cntrl_cntnr1 table custom-table fontSerif w-100" style="table-layout: fixed; margin: 0 auto;">
                                                    <tr>
                                                        <td style="width: 100%; text-align: center; padding: 2px;">
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="input_required clear" ClientIDMode="Static" Width="99%">
                                                                <asp:ListItem Value="0">-----Select The Department For Which the Rooster is to be created</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                    <div style="height: 10px;">
                                        <br />
                                    </div>

                                    <!-- Employee List Table -->
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <table id="tblEmployeeList" class="table custom-table fontSerif w-100" cellpadding="0" cellspacing="0" style="table-layout: fixed; margin: 0 auto; font-size: 12px; border: 1px ridge;">
                                                </table>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>

