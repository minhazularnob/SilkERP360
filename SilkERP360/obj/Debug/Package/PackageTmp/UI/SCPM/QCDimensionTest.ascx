<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCDimensionTest.ascx.cs" Inherits="SilkERP360.UI.SCPM.QCDimensionTest" %>
<script src="Scripts/QCDimensionTest.js" type="text/javascript"></script>

<div id="dvQCMaster" style="width:100%; border:0px ridge black; margin:0 auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <td>
                <div>
                    <h2>Dimension Test</h2>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width:100%; text-align:right;">
                <div>
                    <asp:Button ID="btnSave" runat="server" Width="100px" Text="Save" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <div>
                    <table id="tblDimensionTest">
                    </table>
                </div>
            </td>
        </tr>
    </table>
</div>