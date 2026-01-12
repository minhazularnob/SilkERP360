<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PantoneColor.ascx.cs" Inherits="SilkERP360.UI.WPMS.PantoneColor" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />



<%--<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
--%>
<script src="Scripts/PantoneColor.js" type="text/javascript"></script>
<div id="dvItemConfig" style="width:100%; border:0px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <!--QC Test Body-->
            <td style="width:100%; height:auto;">
                <div id="Div1" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <h3>Pantone Color Database</h3>
                </div>
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td style="width:100%; height:auto;">
                <div id="dvItems" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                    <table id="tblPantoneColors">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>