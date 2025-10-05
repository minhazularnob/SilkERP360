<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpms_item_config.ascx.cs" Inherits="SilkERP360.UI.WPMS.wpms_item_config" %>

<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/PgwSlider-master/pgwslider.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/PgwSlider-master/pgwslider.min.js" type="text/javascript"></script>

<script src="Scripts/wpms_item_config.js" type="text/javascript"></script>
<%--<script src="Scripts/Item.js" type="text/javascript"></script>--%>
<div id="dvItemConfig" style="width:100%; border:0px ridge black; margin:0 auto; height:auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <%--<tr style="padding:5px;">
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center; margin:2px;">
                <div id="dvNotification" style="display:none;font-weight:bold; color:white; text-align:left; margin-right:1px;">
               
                </div>
            </td>
            <td style="width:0%;padding:2px; height:40px; text-align:center;margin:2px;">
                &nbsp;
            </td>
            <td style="width:50%; background-color:Gray; padding:2px; height:40px; text-align:center;margin-left:1px;">
                <div id="dvData" style="display:none; color:White;">
                    <%--<span id="spnData" style=" font-family:Times New Roman; font-size:14px; font-weight:500; color:Aqua;"></span>
                </div>
            </td>
        </tr>--%>
        <tr>
            <!--QC HEAD-->
            <td colspan="3"  style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <%--<h1>Overtime Management</h1>--%>
                    <br />
                    <br />
                    <table style="width:50%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:30%; text-align:left;">
                                <label>Buyer :</label>
                            </td>
                            <td style="width:70%; text-align:center;">
                                <asp:DropDownList ID="ddlBuyer" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value="0">----- Select Buyer</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:30%; text-align:left;">
                                <label>Item Category :</label>
                            </td>
                            <td style="width:70%; text-align:center;">
                                <asp:DropDownList ID="ddlItemCategory" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem Value="0">----- Select Item Category</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                       <tr>
                            <td colspan="2">
                                &nbsp;
                            </td>
                       </tr>

                       
                        <tr>
                            <td>
                            </td>
                            <td style="width:100%; text-align:right;">
                                <div>
                                    <a id="lnkAddEmployee" href="#" class="command_button_enabled" onclick="SaveItem();return false;">
                                        Save Item
                                    </a>
                                    <a id="lnkUploadEmployeeFile" href="#"  class="command_button_enabled" onclick="LoadItemListByBuyerAndCatagory();return false;">
                                        Show All
                                    </a>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                     </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td colspan="3" style="width:100%; height:auto;">
                <div id="tbItemsConfig" style="min-height:600px;">
                    <ul>
                        <li><a href="#tbItem">Item Information</a></li>
                        <li><a href="#tbMasterBatchAndInk">Master Batch & Ink</a></li>
                    </ul>
                    <div id="tbItem" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black; overflow:visible;">
                        <div style="width:98%;">
                            <table id="tblItems">
                            </table>
                        </div>
                    </div>
                    <div id="tbMasterBatchAndInk" class="qc_test_form_container" style="width:100%; height:auto; border:0px ridge black;">
                        <br />
                        <div style="width:40%; margin:0 auto;">
                            <table style="width:100%;">
                                <tr>
                                    <td>
                                        <label for="ddlItemSpecificatio"><b>Item Specification :</b></label>
                                        <asp:DropDownList ID="ddlItem" runat="server" Width="98%" ClientIDMode="Static">
                                            <asp:ListItem>----- Select Item Specification</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style=" text-align:right;">
                                        <br />
                                        <a id="lnkSaveMasterBatch" href="#" class="command_button_enabled" onclick="SaveMasterBatch();return false;">
                                            Save M.B
                                        </a>
                                        <a id="lnkSaveInkList" href="#" class="command_button_enabled" onclick="SaveInkList();return false;">
                                            Save Ink
                                        </a>
                                        <a id="lnkShowMasterBatchAndIbk" href="#"  class="command_button_enabled" onclick="ShowMasterBatchAndInkList();return false;">
                                            Show M.B & Ink
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                                               
                        <br />
                        <br />
                        <br />
                        <div  style="width:98%; border:1px solid black;">
                            <table style="width:100%; border:0px solid black;">
                                <tr>
                                    <td style="width:50%; min-height:300px;">
                                        <div style="width:100%; margin:0 auto;border:0px solid black; background-color:white;">
                                            <h3>Master Batch</h3>
                                            <%--<asp:CheckBox ID="chkNoMasterBatch" runat="server" Text="No Master Batch" ClientIDMode="Static" Font-Bold="true" />--%>
                                            <table id="tblMasterBatch">
                                            </table>
                                        </div>
                                    </td>
                                    <td rowspan="2"  style="width:50%;">
                                        <div id="dvImageGallery" style="min-height:360px; width:100%; border:1px solid black;">
                                            <ul class='pgwSlider'>
                                            </ul>  
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="width:100%; margin:0 auto; background-color:white;">
                                            <h3>Ink</h3>
                                            <table id="tblInk">
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</div>


<div id="dlgImageUpload" title="Upload Sample Image" style="display:none;">
    <h3>Sample Image Uploader</h3>
    <table id="tblphoto"  class="ip_control_container"  style="margin:0 auto; border:1px solid black;" >
        <tr>
            <td colspan="4" style="width:100%; text-align:center; line-height:200px;" align="center">
                <img id="imgItemSample" alt="" src="../../Globals/Images/images.jpg" style=" width:250px; height:200px;margin:0 auto;" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:center;">
                <input id="fileBrowser" onchange="return LoadImage() ;" style="width: 98%" type="file"/>
            </td>
        </tr>
        <tr>
            <td style="width:25%;">
                ItemCode :
            </td>
            <td style="width:25%;">
                <asp:TextBox ID="txtImageUploadItemCode" ReadOnly="true" runat="server" ClientIDMode="Static" placeHolder="File Type" style="width:96%" >
                </asp:TextBox>
            </td>
            <td style="width:25%;">
                
            </td>
            <td style="width:25%;">
                
            </td>
        </tr>
        <tr>
            <td style="width:25%;">
                Item Name :
            </td>
            <td colspan="3" style="width:75%;">
                <asp:TextBox ID="txtImageUploadItemName" ReadOnly="true" runat="server" ClientIDMode="Static" placeHolder="Item Name" style="width:98%" >
                </asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
                Image Type :
            </td>
            <td>
                <asp:TextBox ID="txtImageType" runat="server" ClientIDMode="Static" placeHolder="File Type" ReadOnly="true"  style="width:96%" >
                        </asp:TextBox>
            </td>
            <td>
                Image Size :
            </td>
            <td>
                <asp:TextBox ID="txtImageSize" runat="server" ClientIDMode="Static" placeHolder="File Size" ReadOnly="true" style="width:95%" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Notes :
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtNote" runat="server" ClientIDMode="Static" placeHolder="Note" ReadOnly="false"  style="width:96%" >
                        </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align:center;">
                <br />
                <div>
                    <a id="lnkDeleteImage" href="#" class="command_button_enabled" onclick="DeleteImage();return false;">
                        Delete Image
                    </a>
                    <a id="lnkSaveImage" href="#"  class="command_button_enabled" onclick="SaveSampleImage();return false;">
                        Save Image
                    </a>
                    <a id="lnkClose" href="#"  class="command_button_enabled" onclick="CloseImageUploadDialog();return false;">
                        Close
                    </a>
                </div>
                <br />
            </td>
        </tr>
    </table>
</div>

