<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DepartmentwiseManagement.ascx.cs" Inherits="SilkERP360.UI.HRIS.DepartmentwiseManagement" %>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js" type="text/javascript"></script>

<script src="Scripts/DepartmentwiseManagement.js" type="text/javascript"></script>
<style type="text/css">
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
        width: 99%;
        height: 1024px;
        top: -800px;
        z-index: 101;
    }
</style>
<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {
            $("#dvSubForm").css("top", "-800px");
        });
        $("#dvNotification").html('');
    });
</script>

<div id="dvBody" class="ui_control_wrapper" style="width: 100%; height: auto; margin: 0 auto; text-align: left;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width: 100%;">
        <tr style="padding: 5px;">
            <td style="width: 100%; background-color: white; padding: 2px; height: 40px; text-align: center; margin: 2px;">
                <!-- Page Header -->
                <div id="cmd" style="width: 100%; text-align: center; padding: 10px 0;">
                    <h1 style="font-family: serif !important;">DEPARTMENTWISE HRIS MANAGEMENT</h1>
                </div>

                <!-- Scrollable Content Container -->
                <div id="dDeptMgmtContent" class="flex-grow-1 overflow-auto px-3 pb-3" style="min-height: 0;">
                    <div class="container-fluid">

                        <!-- Sub Form Section -->
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <div id="dvDepartmentList" style="width: 100%; position: relative;">

                                    <div id="dvSubForm" class="sub_form ui_control_wrapper" style="height: auto; min-height: 1024px;">
                                        <a class="boxclose" id="boxclose"></a>
                                        <h2 id="hdrSubForm">Important message</h2>
                                        <div id="dvSubFormContainer">
                                            <br />
                                        </div>
                                    </div>

                                    <!-- Department List Table -->
                                    <div class="row mt-3">
                                        <div class="col-md-12">
                                            <div class="table-responsive">
                                                <asp:Table ID="tblDepartmentList" runat="server" ClientIDMode="Static" CellPadding="0" CellSpacing="0" CssClass="table custom-table fontSerif w-100">
                                                </asp:Table>
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
