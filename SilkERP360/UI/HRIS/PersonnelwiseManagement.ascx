<%@ Control Language="C#" AutoEventWireup="true"
    CodeBehind="PersonnelwiseManagement.ascx.cs"
    Inherits="SilkERP360.UI.HRIS.PersonnelwiseManagement" %>

<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/lib/Super-Theme-Switcher/jquery.themeswitcher.js"
    type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery-ui-contextmenu-master/jquery.ui-contextmenu.js"
    type="text/javascript"></script>
<script src="Scripts/PersonnelwiseManagement.js" type="text/javascript"></script>

<style type="text/css">
    .overlay {
        background: transparent url(images/overlay.png) repeat top left;
        position: fixed;
        inset: 0;
        z-index: 100;
    }

    .box {
        position: fixed;
        top: 200px;
        left: 30%;
        right: 30%;
        background-color: #fff;
        padding: 20px;
        border: 2px solid #ccc;
        border-radius: 20px;
        box-shadow: 0 1px 5px #333;
        z-index: 101;
    }

    a.boxclose {
        float: right;
        width: 26px;
        height: 26px;
        background: transparent url(../../Globals/Images/cancel.png) no-repeat;
        cursor: pointer;
    }

    .sub_form {
        display: none;
        position: absolute;
        width: 100%;
        top: 0;
        z-index: 101;
    }
</style>

<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(300);
    });
</script>

<!-- MAIN WRAPPER -->
<div id="dvBody" class="ui_control_wrapper"
     style="width:100%; margin:0 auto; text-align:left;">

    <table id="tblBody"
           style="width:100%; border-collapse:collapse;">
        <tr>
            <!-- IMPORTANT FIX -->
            <td style="
                width:100%;
                height:2000px;
                vertical-align:top;
                padding:10px;
                background:#fff;

            ">

                <!-- HEADER -->
                <div id="cmd" style="text-align:center; padding:10px 0;">
                    <h1 class="fontSerif m-0">
                        Personnelwise HRIS Management
                    </h1>
                </div>

                <!-- CONTENT AREA -->
                <div id="dRoosterFormContent"
                     style="max-height:auto; padding-top:10px;">

                    <div class="container-fluid">

                        <!-- SUB FORM -->
                        <div id="dvRoosterForm" style="width:100%; position:relative;">

                            <div id="dvSubForm"
                                 class="sub_form ui_control_wrapper"
                                 style="min-height:768px;">
                                <a class="boxclose" id="boxclose"></a>
                                <h2 id="hdrSubForm">Important message</h2>
                                <div id="dvSubFormContainer"></div>
                            </div>

                            <!-- DEPARTMENT DROPDOWN -->
                            <div class="row mb-3">
                                <div class="col-md-12">
                                    <table class="table w-100">
                                        <tr>
                                            <td class="text-center p-2">
                                                <asp:DropDownList ID="ddlDepartment"
                                                    runat="server"
                                                    CssClass="input_required clear w-100"
                                                    ClientIDMode="Static">
                                                    <asp:ListItem Value="0">
                                                        -----Select The Department For Which the Rooster is to be created
                                                    </asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                            <!-- EMPLOYEE LIST -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <table id="tblEmployeeList"
                                               class="table custom-table fontSerif w-100"
                                               style="font-size:12px; border:1px ridge;">
                                        </table>
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
