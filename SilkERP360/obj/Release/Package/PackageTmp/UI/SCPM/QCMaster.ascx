<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QCMaster.ascx.cs" Inherits="SilkERP360.UI.SCPM.QCMaster" %>
<link href="../../Globals/Styles/scpm.css" rel="stylesheet" type="text/css" />
<link href="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/jquery.appendGrid-master/jquery.appendGrid-1.4.1.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.formatDateTime-1.1.1/dist/jquery.formatDateTime.min.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/jquery.number.min.js" type="text/javascript"></script>
<script src="../../Globals/jQuery/jquery-ui-1.10.3/ui/jquery.ui.slider.js" type="text/javascript"></script>
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-sliderAccess.js" type="text/javascript"></script>
<link href="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.css" rel="stylesheet" type="text/css" />
<script src="../../Globals/Scripts/plug-ins/time-picker/jquery-ui-timepicker-addon.js" type="text/javascript"></script>

<script src="Scripts/QCMaster.js" type="text/javascript"></script>


<div id="dvQCMaster" style="width:100%; border:0px ridge black; margin:0 auto;">
    <table id="tblBody" cellpadding="5px" cellspacing="5px" style="width:100%;">
        <tr>
            <!--QC HEAD-->
            <td style="width:100%; height:auto;">
                <div id="dvQCHead" style="width:100%; height:100%; border-bottom:2px ridge black;">
                    <h1>Quality Control</h1>
                    <br />
                    <br />
                    <table style="width:90%; margin:0 auto;" class="ip_control_container" >
                        <tr>
                            <td style="width:15%; text-align:left;">
                                <label>Production Section:</label>
                            </td>
                            <td style="width:34%; text-align:center;">
                                <asp:DropDownList ID="ddlSection" runat="server" CssClass="ip_required lock_qc_master" Width="100%" ClientIDMode="Static">
                                    
                                </asp:DropDownList>
                            </td>
                            <td style="width:2%;">
                                    &nbsp;
                            </td>
                            <td style="width:15%;text-align:left;">
                               <%-- <label>Batch No:</label>--%>
                            </td>
                            <td style=" width:34%; text-align:center;">
                                <%--<asp:TextBox ID="txtBatchNo1" runat="server" CssClass="ProductTypeIndexChange_0 lock_qc_master" Width="100%" ClientIDMode="Static"></asp:TextBox>--%>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Process :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:DropDownList ID="ddlProductionProcess" ClientIDMode="Static" CssClass="ProductTypeIndexChange_0" runat="server" Width="100%">
                                    <asp:ListItem>-----Select Production Process</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="txtProductionProcess" runat="server" CssClass="ProductTypeIndexChange_0 lock_qc_master" style="text-align:center;" ClientIDMode="Static" Width="100%" ReadOnly="true"></asp:TextBox>--%>
                            </td>
                            <td style="">
                                    &nbsp;
                            </td>
                            <td style=" text-align:left;">
                                <label>Date :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtDate" runat="server" Width="100%" CssClass="lock_qc_master" ClientIDMode="Static" ReadOnly="true" style="text-align:center;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Job Order No :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:DropDownList ID="ddlJobOrderNo" CssClass="ProductTypeIndexChange_0 ip_required lock_qc_master" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>-----Select Job Order</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                    &nbsp;
                            </td>
                             <td style="text-align:left;">
                                <label>Product Specification :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtProductSpecification" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" Width="100%" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Customer :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtCustomer" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" style="text-align:center;" Width="100%" ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Ordered Quantity :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtOrderedQuantity" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" Width="100%" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Completed Quantity :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtCompletedQuantity" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" Width="100%" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Q.A Engineer :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtQAEngineer" ReadOnly="true" style="text-align:center;" runat="server" ClientIDMode="Static" Width="100%"></asp:TextBox>
                                <asp:HiddenField ID="hdnQAEngineerCode" runat="server" ClientIDMode="Static" />
                            </td>
                            <td>
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Operator :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:DropDownList ID="ddlOperator" CssClass="ProductTypeIndexChange_0 ip_required lock_qc_master" runat="server" Width="100%" ClientIDMode="Static">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <%--<label>Batch Quantity :</label>--%>
                            </td>
                            <td style="text-align:center;">
                                <%--<asp:TextBox ID="txtBatchQuantity" CssClass="ProductTypeIndexChange_0 numeric_only ip_required lock_qc_master" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>--%>
                            </td>
                            <td>
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Shift :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:DropDownList ID="ddlShift" CssClass="ProductTypeIndexChange_0 ip_required lock_qc_master" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>-----Select Shift</asp:ListItem>
                                    <%--<asp:ListItem>Day Shift</asp:ListItem>
                                    <asp:ListItem>Night Shift</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <label>Machine :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:DropDownList ID="ddlMachine" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" Width="100%" ClientIDMode="Static">
                                    <asp:ListItem>-----Select Machine</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                    &nbsp;
                            </td>
                            <td style="text-align:left;">
                                <label>Remarks :</label>
                            </td>
                            <td style="text-align:center;">
                                <asp:TextBox ID="txtRemarks" CssClass="ProductTypeIndexChange_0 lock_qc_master" runat="server" Width="100%"></asp:TextBox>
                            </td>
                            
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align:center;">
                                <asp:Button ID="btnCreateBatch" runat="server" Width="150px" Text="Create Batch" OnClientClick="CreateBatchConfig(event);return false;" ClientIDMode="Static" />&nbsp;&nbsp;
                                <asp:Button ID="btnQCTest" runat="server" Width="150px" Text="Q.C Test" OnClientClick="return false;" ClientIDMode="Static" />&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left;">
                                <br />
                            </td>
                        </tr>

                    </table>
                  
                    
                </div>
            </td>
        </tr>
        <tr>
            <td>
                
                
            </td>
        </tr>
        <tr>
            <!--QC Test Menu-->
            <td style="width:100%; height:auto;">
                <div id="dvQCTestMenu" style="width:100%; border-bottom:2px ridge black;">
                    <div id="dvNewBatch"  style="width:100%; border-bottom:2px ridge black; display:none;">
                        <h2>Master Batch</h2>
                        &nbsp;&nbsp;

                        <table cellspacing="5px" style="width:90%; margin:0 auto;" class="ip_control_container" >
                            <tr>
                                <td colspan="5" style=" width:100%; text-align:center;">
                                     <table id="tblMasterBatch" style="width:100%;">
                                     </table>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Mstr. Batch</b></label> 
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtMasterBatch" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style=" width:2%; text-align:left;">
                                    &nbsp;
                                </td>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Mstr. Batch Qty.</b></label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtMasterBatchQuantity" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Qty Dispatched :</b></label> 
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtMasterBatchQuantityDispatched" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style=" width:2%; text-align:left;">
                                    &nbsp;
                                </td>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Remaining Qty :</b></label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtMasterBatchQuantityRemaining" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Qty on Hold :</b></label> 
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtQuantityOnHold" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style=" width:2%; text-align:left;">
                                    &nbsp;
                                </td>
                                <td style=" width:15%; text-align:left;">
                                    <label><b>Qty Scrapped :</b></label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtQuantityScrapped" runat="server" ReadOnly="true" style=" text-align:center; font-weight:bold;" CssClass="ProductTypeIndexChange_0" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <table id="tblSubBatches">
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:15%; text-align:left;">
                                    <label>Sub Batch :</label> 
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtSubBatch" CssClass="numeric_only ip_required" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" width:15%; text-align:left;">
                                    <label>Total Sub Batch Qty :</label> 
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtSubBatchQuantity" CssClass="numeric_only ip_required" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                                <td style=" width:2%; text-align:left;">
                                    &nbsp;
                                </td>
                                <td style=" width:15%; text-align:left;">
                                    <label>Wastage</label>
                                </td>
                                <td style=" width:34%; text-align:center;">
                                    <asp:TextBox ID="txtWastage" CssClass="numeric_only ip_required" runat="server" Width="100%" ClientIDMode="Static"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>


                    <div id="dvQCSim" class="qc_test_type_container" style="width:100%; display:none;">
                        <h2>Q.C Test Types (SIM)</h2>
                        <table cellspacing="5px" style="width:100%; margin:0 auto;" class="ip_control_container" >
                            <tr style="width:100%;">
                                <td style="width:16%; text-align:center;">
                                    <label><b>PRINTING</b></label><br />
                                    <br />
                                    <asp:Image ID="imgPrinting" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/Printing.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnPeelOff" runat="server" CssClass="qc_test_form_btn" Width="95%" Text= "Peel Off Test" ClientIDMode="Static" OnClientClick="LoadPOTest();return false;" /><br />
                                        <div style='height:3px;'></div>
                                        <asp:Button ID="btnACDC" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Appearance & Color Density" ClientIDMode="Static" OnClientClick="LoadAppearanceColorDensityTest(); return false;" />
                                    </div>
                                    
                                </td>
                                <td style="width:16%; text-align:center;">
                                    <label><b>PUNCHING</b></label><br />
                                    <br />
                                    <asp:Image ID="Image1" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/Punching.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnLWT" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Length Width & Thickness" ClientIDMode="Static" OnClientClick="LoadLWTTest(); return false;" />
                                    </div>
                                </td>
                                <td style="width:16%; text-align:center;">
                                    <label><b>MILLING</b></label><br />
                                    <br />
                                    <asp:Image ID="Image2" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/Milling.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnCDDL" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Cavity Dimension Depth & Location" ClientIDMode="Static" OnClientClick="LoadQCCDDLTest();return false;" />
                                    </div>
                                </td>
                                <td style="width:16%; text-align:center;">
                                    <label><b>EMBEDDING</b></label><br />
                                    <br />
                                    <asp:Image ID="Image3" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/Embedding.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnBending" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Bending Test" ClientIDMode="Static" OnClientClick="LoadQCBendingTest();return false;" /><br />
                                        <div style='height:3px;'></div>
                                        <asp:Button ID="btnTorsion" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Torsion Test" ClientIDMode="Static" OnClientClick="LoadTorsionTest(); return false;" /><br />
                                        <div style='height:3px;'></div>
                                        <asp:Button ID="btnPOC" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Push Out Chip" ClientIDMode="Static" OnClientClick="LoadPOCTest(); return false;" /><br />
                                        <div style='height:3px;'></div>
                                        <asp:Button ID="btnCLA" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Chip Location & Appearance" ClientIDMode="Static" OnClientClick="LoadCLATest();return false;" />
                                    </div>
                                </td>
                                <td style="width:16%; text-align:center;">
                                    <label><b>PLUG-in-PUNCH</b></label><br />
                                    <br />
                                    <asp:Image ID="Image4" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/PlugInPunch.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnBreakOutForce" runat="server" CssClass="qc_test_form_btn" Width="95%" Text= "Break Out Force" ClientIDMode="Static" OnClientClick="LoadBreakOutForce();return false;" /><br />
                                        <div style='height:3px;'></div>
                                        <asp:Button ID="btnDimension" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Dimension" ClientIDMode="Static" OnClientClick="LoadDimensionTest(); return false;" />
                                    </div>
                                </td>
                                <td style="width:16%; text-align:center;">
                                    <label><b>PERSONALIZATION</b></label><br />
                                    <br />
                                    <asp:Image ID="Image5" runat="server" Width="80px" Height="80px" ImageUrl="../../Globals/Images/Personalization.jpg" /><br />
                                    <div style="height:120px; margin-top:10px;">
                                        <asp:Button ID="btnPerso" runat="server" CssClass="qc_test_form_btn"  Width="95%" Text= "Telecapers,Barcode,ICCID & KI" ClientIDMode="Static" OnClientClick="LoadPersoTest(); return false;" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <!--QC Test Body-->
            <td style="width:100%; height:auto;">
                <div id="dvQCTest" class="qc_test_form_container" style="width:100%; height:100%; border:0px ridge black; display:none;">
                </div>
            </td>
        </tr>
    </table>
</div>
