<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SC_Fault_Perso_Card_List_Download.ascx.cs" Inherits="SilkERP360.UI.SCPM.SC_Fault_Perso_Card_List_Download" %>
<script src="../../Globals/Scripts/plug-ins/jquery.barcode.0.3.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/SilkERP360/SCPM/SC_Fault_Perso_Card_List_Download.js" type="text/javascript"></script>
<style type="text/css">
        a.boxclose{
            float:right;
            width:26px;
            height:26px;
            background:transparent url(../../Globals/Images/cancel.png) repeat top left;
            cursor:pointer;
        }
        
        .sub_form
        {
            opacity: 0;
            display: none;
            position: absolute;
            width: 99%;
            height:1024px;
            top:-800px;
            z-index:101;
            

        }
</style>
<script type="text/javascript">
    $('#boxclose').click(function () {
        $("#dvSubForm").fadeOut(1000, function () {
            $("#dvSubForm").css("top", "-800px");
        });
    });
</script>
<div id="dvBody" class="ui_control_wrapper" style="Width:99%;height:1024px; margin:0 auto;">
    <div id="cmd" style="width:99%;">
        <%-- <asp:Button ID="btnSave" CssClass="button save" runat="server" Text="Save" Width="40px" />--%>
       <h1>S.C Peronalization Faulty Cards List</h1>
        <p class="login button"> 
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick=" return SavePersoFaultCards();" style="width:70px;" />&nbsp;
            <asp:Button ID="btnClose" runat="server" CssClass="button" Text="Close" ClientIDMode="Static" OnClientClick="return false;" style="width:70px;" />
        </p>
    
        <%--<a id="btnSave" href="" class="button save">Save</a>
        <a id="btnClose" href="" class="button delete">Close</a>--%><%--<asp:Button ID="btnClose" runat="server" Text="Close" Width="40px" onclick="btnClose_Click" />--%>
    </div>
    <div style="height:10px;">
        <br />
    </div>
    
    <div id="dvRecovery" style="width:100%; height:auto; border:0px; border-style:ridge;">
        
        <div id="dvListedDepartments" style="width:100%; float:left; position:relative;">  <%--margin:0 auto;--%>
            <%--<div id="dvSubForm" class="sub_form ui_control_wrapper" >
                <a class="boxclose" id="boxclose"></a>
                <h2 id="hdrSubForm">Important message</h2>
                <div id="dvSubFormContainer">
                    <br />
                </div>
            </div>--%>
           <%-- <div style="height:10px;">
                <br />
            </div>--%>
            <%--<table id="tblDepartmentList" cellpadding="0px" cellspacing="0px" style="width:100%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
            </table>--%>
            <div style="width:60%;margin:0 auto;">
            <table class="ip_cntrl_cntnr1" style="width:70%; table-layout:fixed;margin:0 auto;">
                <tr>
                    <td style="width:30%; text-align:left;">
                        Machine
                    </td>
                    <td style="width:70%; text-align:left;">
                        <asp:DropDownList ID="ddlMachine" runat="server" Width="99%"  ClientIDMode="Static">
                            <asp:ListItem Value='0'>-----Select Machine</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; text-align:left;">
                        Job Order
                    </td>
                    <td style="width:70%; text-align:left;">
                        <asp:DropDownList ID="ddlJobOrder" runat="server" Width="99%" ClientIDMode="Static">
                            <asp:ListItem Value='0'>-----Select Job Order</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%; text-align:left;">
                        Batch
                    </td>
                    <td style="width:70%; text-align:left;">
                        <asp:DropDownList ID="ddlBatch" runat="server" Width="99%"  ClientIDMode="Static"></asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td style="width:30%; text-align:left;">
                        Card Serial
                    </td>
                    <td style="width:70%; text-align:left;">
                        <asp:TextBox ID="txtCardSerial" CssClass="barcode_input" runat="server" Width="99%" ClientIDMode="Static"></asp:TextBox>
                    </td>
                </tr>--%>
            </table>
            </div>
            <br />
            <div style="width:60%; margin:0 auto;">
            <asp:Table ID="tblRecoveredList" runat="server" ClientIDMode="Static" CellPadding="2" CellSpacing="0" style="width:70%;table-layout:fixed; margin:0 auto; font-size:12px; border:1px; border-style:ridge;">
                <%--<asp:TableHeaderRow Width="100%">
                    <asp:TableHeaderCell Width="60%" style="text-align:center;">Department</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="35%" style="text-align:center;">Strength</asp:TableHeaderCell>
                    <asp:TableHeaderCell Width="5%" style="text-align:center;">Action</asp:TableHeaderCell>
                </asp:TableHeaderRow>--%>
            </asp:Table>
            </div>
        </div>
    </div>
</div>