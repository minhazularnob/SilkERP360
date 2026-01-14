<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="EmployeeEdit.ascx.cs" Inherits="SilkERP360.UI.HRIS.EmployeeEdit" %>
<script src="../../Globals/Scripts/SilkERP360/HRIS/EditEmployee.js" type="text/javascript"></script>

<asp:HiddenField ID="txtUserEmployeeCode" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtEducationCount" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtExperienceCount" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtLeaveCounter" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtCompanyCode" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtref1" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtref2" runat="server" Value="0" ClientIDMode="Static" />

<div id="dvBody" class="ui_control_wrapper" style='z-index: 1000; height: 900px'>
    <div id="cmd" style="width: 99%; z-index: 1001;">
        <p class="login button">
            <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save"
                ClientIDMode="Static" OnClientClick="Save(); return false;" Style="width: 70px;" />&nbsp;
        </p>
    </div>

    <div id="tabs" style="width: 99%; height: 900px; overflow-y: auto; position: relative; z-index: 12; top: 0px; left: 1px; z-index: 1002; font-size: small" class="fontSerif fontBold">
        <ul>
            <li><a href="#ImageTab">Image</a></li>
            <li><a href="#OfficialTab">Official</a></li>
            <li><a href="#PersonalTab">Personal</a></li>
            <li><a href="#SalaryTab">Salary Leaves & Reference</a></li>
            <li><a href="#EducationExperienceTab">Education , Experiance </a></li>
            <li><a href="#CertificateTab">Certificate </a></li>

        </ul>
        <div id="ImageTab" class="position-relative p-3" style="z-index: 1003;">
            <div class="container">

                <h3 class="fontSerif mb-4">Image Information</h3>

                <!-- Image Preview -->
                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4 text-center">
                        <asp:Image ID="imgEmployeeImage" runat="server"
                            ClientIDMode="Static"
                            CssClass="img-fluid rounded"
                            Style="max-width: 160px; height: auto;" />
                    </div>
                </div>

                <!-- File Upload -->
                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4">
                        <input id="fileBrowser"
                            type="file"
                            class="form-control"
                            onchange="return LoadImage();" />
                    </div>
                </div>

                <!-- File Type -->
                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="txt_EI_ImageType"
                            runat="server"
                            ClientIDMode="Static"
                            CssClass="form-control"
                            PlaceHolder="File Type"
                            ReadOnly="true">
                        </asp:TextBox>
                    </div>
                </div>

                <!-- File Size -->
                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4">
                        <asp:TextBox ID="txt_EI_ImageSize"
                            runat="server"
                            ClientIDMode="Static"
                            CssClass="form-control"
                            PlaceHolder="File Size"
                            ReadOnly="true">
                        </asp:TextBox>
                    </div>
                </div>

                <!-- Delete Button -->
                <div class="row justify-content-center">
                    <div class="col-md-4">
                        <button id="btnDeleteImage"
                            type="button"
                            class="btn btn-danger w-100"
                            onclick="return DeleteImage();">
                            Delete
                        </button>
                    </div>
                </div>

            </div>
        </div>
        <div id="OfficialTab" class="position-relative p-3" style="z-index: 1004; height: 900px; overflow-y: auto">
            <div class="container-fluid">

                <h2 class="fontSerif">Official Information</h2>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Department</label>
                    <div class="col-sm-11">
                        <asp:DropDownList ID="ddl_Off_Department" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Department">
                            <asp:ListItem Value="0">-----Select Department-----</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Employee Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_Name" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required width-100" PlaceHolder="Emp. Name">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Shift Code</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_Shift_Code" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Shift">
                            <asp:ListItem Value="0">-----Select Shift-----</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">ACS Code</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_ACSCode" runat="server" ClientIDMode="Static" ReadOnly="true"
                            CssClass="form-control input-required width-100" PlaceHolder="ACS Code" Enabled="false" >
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Designation</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_Designation" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Designation">
                            <asp:ListItem Value="0">----Select Designation----</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Ref. Employee</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_RefEmployee" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Ref. Employee">
                            <asp:ListItem Value="0">----- Select REF. Employee -----</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <label class="col-sm-1 col-form-label">Search Ref. Employee</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_AutoRefEmployee" runat="server" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Search RefEmployee">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Supervisor</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_Supervisor" runat="server" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Supervisor">
                            <asp:ListItem Value="0">----- Select Supervisor -----</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <label class="col-sm-1 col-form-label">Search Supervisor</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_AutoSuperVisor" runat="server" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Search Super Visor">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Join Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_JoiningDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control input-required width-100" PlaceHolder="Joining Date" Enabled="false">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Confirmation Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_ConfirmationDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Conf. Date">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Retirement Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_RetirementDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Ret. Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Settlement Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_SettlementDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control Settlement Date width-100" PlaceHolder="Settlement Date">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Official File No</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_OfficialFileNo" runat="server" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Off. File No">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Bond Reference</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_BondRefference" runat="server" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Bond Reference">
                        </asp:TextBox>
                    </div>
                </div>


                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Bond Issue Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_BondIssueDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Bond Issue Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Bond Year</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_BondYear" runat="server" ClientIDMode="Static"
                            CssClass="form-select input-required" PlaceHolder="Bond Year">
                            <asp:ListItem Value="0">-----Select Bond Year-----</asp:ListItem>
                            <asp:ListItem Value="1">1 Year</asp:ListItem>
                            <asp:ListItem Value="2">2 Years</asp:ListItem>
                            <asp:ListItem Value="3">3 Years</asp:ListItem>
                            <asp:ListItem Value="4">4 Years</asp:ListItem>
                            <asp:ListItem Value="5">5 Years</asp:ListItem>
                            <asp:ListItem Value="6">6 Years</asp:ListItem>
                            <asp:ListItem Value="7">7 Years</asp:ListItem>
                            <asp:ListItem Value="8">8 Years</asp:ListItem>
                            <asp:ListItem Value="9">9 Years</asp:ListItem>
                            <asp:ListItem Value="10">10 Years</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Bond Expiry Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_BondValidityDate" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Bond Expiry Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Remarks</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_Remarks" runat="server" ClientIDMode="Static" Style="width: 97%" CssClass="form-control"
                            PlaceHolder="Remarks" TextMode="MultiLine" Rows="2">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">e-TIN Eligible</label>
                    <div class="col-sm-5 d-flex align-items-center">
                        <asp:CheckBox ID="chk_eTIN_Eligible" runat="server" Text="e-TIN Eligible" ClientIDMode="Static" />
                    </div>

                    <label class="col-sm-1 col-form-label">e-TIN No</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_Tin" runat="server" ClientIDMode="Static" CssClass="form-control width-100"
                            PlaceHolder="e-TIN No">
                        </asp:TextBox>
                    </div>
                </div>


                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Bank</label>
                    <div class="col-sm-5 d-flex align-items-center">
                        <asp:CheckBox ID="chkBankSalary" runat="server" Text=" Bank Salary" ClientIDMode="Static" />
                    </div>

                    <label class="col-sm-1 col-form-label">Bank Account Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_BankAccountCode" runat="server" ClientIDMode="Static"
                            CssClass="form-control width-100" PlaceHolder="Bank Account number">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Eligible</label>
                    <div class="col-sm-5 d-flex flex-wrap gap-2">
                        <asp:CheckBox Style='margin: 6px' ID="chkOTEligable" runat="server" Text="OT Eligible" ClientIDMode="Static" />
                        <asp:CheckBox Style='margin: 6px' ID="chkPFEligable" runat="server" Text="PF Eligible" ClientIDMode="Static" />
                        <asp:CheckBox Style='margin: 6px' ID="chkRoster" runat="server" Text="Roster Eligible" ClientIDMode="Static" />
                        <asp:CheckBox Style='margin: 6px' ID="checNightBill" runat="server" Text="Night Bill Eligible" ClientIDMode="Static" />
                        <asp:CheckBox Style='margin: 6px' ID="Check_ComUniform" runat="server" Text="Uniform Eligible" ClientIDMode="Static" />
                    </div>

                    <label class="col-sm-1 col-form-label">Bank Name</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="txtBankName" runat="server" ClientIDMode="Static"
                            CssClass="form-select" PlaceHolder="Select Bank">
                            <asp:ListItem Value="0">------Select Bank-----</asp:ListItem>
                            <asp:ListItem>Agrani Bank Ltd.</asp:ListItem>
                            <asp:ListItem>Dhaka Bank Ltd.</asp:ListItem>
                            <asp:ListItem>Prime Bank Ltd.</asp:ListItem>
                            <asp:ListItem>National Bank Ltd.</asp:ListItem>
                            <asp:ListItem>IFIC Bank Ltd.</asp:ListItem>
                            <asp:ListItem>The City Bank Ltd.</asp:ListItem>
                            <asp:ListItem>Trust Bank Ltd.</asp:ListItem>
                            <asp:ListItem>JAMUNA BANK LTD</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Weekend</label>
                    <div class="col-sm-5 d-flex flex-wrap gap-2" id="chkbox">
                        <asp:CheckBox ID="chk1" Style='margin: 6px' runat="server" Text="Saturday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk2" Style='margin: 6px' runat="server" Text="Sunday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk3" Style='margin: 6px' runat="server" Text="Monday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk4" Style='margin: 6px' runat="server" Text="Tuesday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk5" Style='margin: 6px' runat="server" Text="Wednesday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk6" Style='margin: 6px' runat="server" Text="Thursday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk7" Style='margin: 6px' runat="server" Text="Friday" ClientIDMode="Static" onclick="CheckBoxCount();" />
                    </div>

                    <label class="col-sm-1 col-form-label">Job Location</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_JobLocation" runat="server" ClientIDMode="Static"
                            CssClass="form-select input-required" PlaceHolder="Job Location">
                            <asp:ListItem Value="0">-----Select Job Location-----</asp:ListItem>
                            <asp:ListItem>Corporate</asp:ListItem>
                            <asp:ListItem>Silkcard Factory</asp:ListItem>
                            <asp:ListItem>Wellpac Factory</asp:ListItem>
                            <asp:ListItem>Chandpur</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
        </div>
        <div id="PersonalTab" class="position-relative p-3" style="z-index: 1006; max-height: 900px; overflow-y: auto;">
            <div class="container-fluid">
                <h3 class="fontSerif">Personal Information</h3>
            </div>

            <!-- Father / Mother -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Father Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_FatherName" runat="server" ClientIDMode="Static"
                        PlaceHolder="Father Name" CssClass="form-control input-required width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Mother Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_MotherName" runat="server" ClientIDMode="Static"
                        PlaceHolder="Mother Name" CssClass="form-control input-required width-100" />
                </div>
            </div>

            <!-- Spouse / DOB -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Spouse Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_SpouseName" runat="server" ClientIDMode="Static"
                        PlaceHolder="Spouse Name" CssClass="form-control width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Date Of Birth</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_DateOfBirth" runat="server" ClientIDMode="Static"
                        ReadOnly="true" PlaceHolder="Date Of Birth"
                        CssClass="form-control input-required width-100" />
                </div>
            </div>

            <!-- Marital / Gender -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Marital Status</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_MaritalStatus" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="0">-----Select Marital Status-----</asp:ListItem>
                        <asp:ListItem>Married</asp:ListItem>
                        <asp:ListItem>Unmarried</asp:ListItem>
                        <asp:ListItem>Divorced</asp:ListItem>
                        <asp:ListItem>Separated</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Gender</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_Sex" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Religion / Nationality -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Religion</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_Religion" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="0">----- Select Religion -----</asp:ListItem>
                        <asp:ListItem>Islam</asp:ListItem>
                        <asp:ListItem>Hinduism</asp:ListItem>
                        <asp:ListItem>Christian</asp:ListItem>
                        <asp:ListItem>Buddhist</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Nationality</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Nationality" runat="server" ClientIDMode="Static"
                        ReadOnly="true" Text="Bangladeshi"
                        CssClass="form-control input-required width-100" />
                </div>
            </div>

            <!-- Blood / Height -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Blood Group</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_BloodGroup" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="0">-----Select Blood Group-----</asp:ListItem>
                        <asp:ListItem>A (+ve)</asp:ListItem>
                        <asp:ListItem>A (-ve)</asp:ListItem>
                        <asp:ListItem>B (+ve)</asp:ListItem>
                        <asp:ListItem>B (-ve)</asp:ListItem>
                        <asp:ListItem>O (+ve)</asp:ListItem>
                        <asp:ListItem>O (-ve)</asp:ListItem>
                        <asp:ListItem>AB (+ve)</asp:ListItem>
                        <asp:ListItem>AB (-ve)</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Height</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Height" runat="server" ClientIDMode="Static"
                        PlaceHolder="Height" CssClass="form-control width-100" />
                </div>
            </div>

            <!-- Weight / Identification -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Weight</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Weight" runat="server" ClientIDMode="Static"
                        PlaceHolder="Weight" CssClass="form-control width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Identification</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Identification" runat="server" ClientIDMode="Static"
                        PlaceHolder="Identification" CssClass="form-control width-100" />
                </div>
            </div>

            <!-- Mobile / Home -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Mobile No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_MobileNo" runat="server" ClientIDMode="Static"
                        PlaceHolder="Mobile No" CssClass="form-control input-required width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Home Phone</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_HomePhone" runat="server" ClientIDMode="Static"
                        PlaceHolder="Home Phone" CssClass="form-control width-100" />
                </div>
            </div>

            <!-- Fax / Email -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Fax No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_FaxNo" runat="server" ClientIDMode="Static"
                        PlaceHolder="Fax No" CssClass="form-control width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Email</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Email" runat="server" ClientIDMode="Static"
                        PlaceHolder="Email" CssClass="form-control width-100" />
                </div>
            </div>

            <!-- Addresses -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present Address</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentAddress" runat="server" Style="width: 97%" ClientIDMode="Static"
                        TextMode="MultiLine" CssClass="form-control input-required" />
                </div>

                <label class="col-sm-1 col-form-label">Permanent Address</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentAddress" runat="server" Style="width: 97%" ClientIDMode="Static"
                        TextMode="MultiLine" CssClass="form-control input-required" />
                </div>
            </div>

            <!-- District -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present District</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_PresentDistrict" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="0">-----Select District-----</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Permanent District</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_PermanentDistrict" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required">
                        <asp:ListItem Value="0">-----Select District-----</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <!-- PO / PC -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present PO</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentPO" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Off." CssClass="form-control width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Permanent PO</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentPO" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Off." CssClass="form-control width-100" />
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present PC</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentPC" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Code." CssClass="form-control width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Permanent PC</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentPC" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Code" CssClass="form-control width-100" />
                </div>
            </div>

            <!-- NID / Passport -->
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">National ID No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_VoterCardNo" runat="server" ClientIDMode="Static"
                        PlaceHolder="Voter Card No" CssClass="form-control input-required width-100" />
                </div>

                <label class="col-sm-1 col-form-label">Passport No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PassportNo" runat="server" ClientIDMode="Static"
                        PlaceHolder="Passport No" CssClass="form-control width-100" />
                </div>
            </div>
        </div>
        <div id="EducationExperienceTab" style="z-index: 1007;">

            <!-- ===================== Education Section ===================== -->
            <div id="Education" style="height: auto; z-index: 1008;">
                <div class="table-responsive">
                    <h3 class="fontSerif">Education Details</h3>

                    <table id="tblEducation" ClientIDMode="Static"  runat="server" class="table table-bordered w-100">
                        <thead class="table-light text-center">
                            <tr>
                                <th style="width: 15%">
                                    <asp:Label ID="Label95" runat="server" Text="Exam" /></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label96" runat="server" Text="Board/University" /></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label97" runat="server" Text="Ins. Name" /></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label98" runat="server" Text="Major Subject" /></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label99" runat="server" Text="Division/Class" /></th>
                                <th style="width: 8%">
                                    <asp:Label ID="Label100" runat="server" Text="CGPA" /></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label101" runat="server" Text="Passing Year" /></th>
                                <th style="width: 2%"></th>
                            </tr>
                        </thead>

                        <tbody class="text-center">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_Edu_ExamName" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Exam" CssClass="form-control input-required" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_BoardUniversity" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Board/Uni" CssClass="form-control input-required" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_InstituteName" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Inst. Name" CssClass="form-control input-required" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_MajorSubject" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Major Sub." CssClass="form-control input-required" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_DivisionClass" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Division/Class" CssClass="form-control input-required" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_CGPA" runat="server" ClientIDMode="Static"
                                        PlaceHolder="CGPA" CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Edu_PassingYear" runat="server" ClientIDMode="Static"
                                        PlaceHolder="Passing Year" CssClass="form-control input-required" /></td>

                                <td class="text-center">
                                    <a href="#" onclick="addEducation(); return false;">
                                        <img id="btnAddNewRow" src="../../Globals/Images/add-2.png"
                                            alt="Add" title="Add New Row" style="cursor: pointer;" />
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <!-- ===================== Experience Section ===================== -->
            <div id="Experience" style="height: 225px; z-index: 1009; margin-top: 20px;">
                <div class="table-responsive">
                    <h3 class="fontSerif">Experience Details</h3>

                    <table id="tblExperience" runat="server" class="table table-bordered w-100">
                        <thead class="table-light text-center">
                            <tr>
                                <th style="width: 15%">
                                    <asp:Label ID="Label102" runat="server" Text="Organization Name" /></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label103" runat="server" Text="Address" /></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label104" runat="server" Text="Responsibility" /></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label105" runat="server" Text="Nature Of Job" /></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label106" runat="server" Text="Contact No" /></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label107" runat="server" Text="Date From" /></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label108" runat="server" Text="Date To" /></th>
                                <th style="width: 5%"></th>
                            </tr>
                        </thead>

                        <tbody class="text-center">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_Exp_OrganizationName" runat="server"
                                        ClientIDMode="Static" PlaceHolder="Organization"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_Address" runat="server"
                                        ClientIDMode="Static" PlaceHolder="Address"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_Responsibility" runat="server"
                                        ClientIDMode="Static" PlaceHolder="Responsibility"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_NatureOfJob" runat="server"
                                        ClientIDMode="Static" PlaceHolder="Nature Of Job"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_ContactNo" runat="server"
                                        ClientIDMode="Static" PlaceHolder="Contact No"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_DateFrom" runat="server"
                                        ClientIDMode="Static" ReadOnly="true"
                                        PlaceHolder="Date From"
                                        CssClass="form-control" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Exp_DateTo" runat="server"
                                        ClientIDMode="Static" ReadOnly="true"
                                        PlaceHolder="Date To"
                                        CssClass="form-control" /></td>

                                <td class="text-center">
                                    <a href="#" onclick="addExperience(); return false;">
                                        <img id="Img1" src="../../Globals/Images/add-2.png"
                                            alt="Add" title="Add New Row" style="cursor: pointer;" />
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

        </div>
        <div id="SalaryTab" class="position-relative p-3" style="z-index: 1010; max-height: 900px; overflow-y: auto;">
            <div class="container-fluid">

                <!-- Salary Information -->
                <h3 class="fontSerif mb-3">Salary Information</h3>

                <div class="table-responsive">
                    <table id="tblSalaryMain" class="table table-bordered text-center w-100">
                        <thead class="table-light">
                            <tr>
                                <th></th>
                                <th>Basic</th>
                                <th>House Rent</th>
                                <th>Medical</th>
                                <th>Entertainment</th>
                                <th>Conveyance</th>
                                <th>Phone Bill</th>
                                <th>Others</th>
                                <th>Gross</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Standard -->
                            <tr>
                                <td>
                                    <asp:Label ID="Label59" runat="server" Text="Standard" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Basic" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_HouseRent" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Medical" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Entertainment" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Conveyence" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_PhoneBill" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Others" runat="server" class="currency_field form-control text-end" ReadOnly="false" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Gross" runat="server" class="currency_field form-control text-end" ReadOnly="false" ClientIDMode="Static" /></td>
                            </tr>

                            <!-- Approved -->
                            <tr>
                                <td>
                                    <asp:Label ID="Label60" runat="server" Text="Approved" /></td>

                                <td>
                                    <asp:TextBox ID="txt_Sal_Basic" runat="server" class="input-required salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_HouseRent" runat="server" class="currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Medical" runat="server" class="input-required salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Entertainment" runat="server" class="salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Conveyence" runat="server" class="input-required salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_PhoneBill" runat="server" class="salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Others" runat="server" class="salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Gross" runat="server" class="input-required gross_salary currency_field form-control text-end" ReadOnly="false" Text="0.00" ClientIDMode="Static" onkeypress="return IsDouble(event)" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- Leave Information -->
                <h3 class="fontSerif mt-4 mb-3">Leave Information</h3>

                <div class="table-responsive">
                    <table id="tblLeave" runat="server" class="table table-bordered w-100" style="background-color: #CCCCCC;">
                        <thead>
                            <tr class="text-center">
                                <th style="width: 20%;">
                                    <asp:CheckBox ID="chkLeave" runat="server" Text="Action" AutoPostBack="false" OnClick="return SelectLeaveALL();" />
                                </th>
                                <th style="width: 30%;">Leave</th>
                                <th style="width: 30%;">Number Of Days</th>
                                <th style="width: 20%;">Carry Forwarded</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Dynamic rows -->
                        </tbody>
                    </table>
                </div>

                <!-- Reference Information -->
                <h3 class="fontSerif mt-4 mb-3">Reference Information</h3>

                <div class="table-responsive">
                    <table id="tblReference" class="table table-bordered w-100">
                        <thead class="table-light text-center">
                            <tr>
                                <th></th>
                                <th>Name</th>
                                <th>Address</th>
                                <th>Phone / Mobile</th>
                                <th>Organization</th>
                                <th>Designation</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk_Ref_Reference_1" runat="server" Text="Reference 1"
                                        ClientIDMode="Static" AutoPostBack="false" OnClick="return toogleReference1Controls();" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Name1" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Address1" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_ContactNo1" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Organization1" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Designation1" runat="server" ClientIDMode="Static" class="form-control" /></td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk_Ref_Reference_2" runat="server" Text="Reference 2"
                                        ClientIDMode="Static" AutoPostBack="false" OnClick="return toogleReference2Controls();" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Name2" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Address2" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_ContactNo2" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Organization2" runat="server" ClientIDMode="Static" class="form-control" /></td>
                                <td>
                                    <asp:TextBox ID="txt_Ref_Designation2" runat="server" ClientIDMode="Static" class="form-control" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
        <div id="CertificateTab" class="position-relative p-3" style="z-index: 1015;">
            <div class="container">
                <h3 class="fontSerif">Add Certificates</h3>
                <input type="file" id="fileInput" multiple
                    accept=".pdf,.jpg,.jpeg,.png"
                    onchange="handleFileSelect(this)">
                <br>
                <br>

                <table id="fileTable" class="table table-bordered table-striped table-hover mt-3" style="display: none;">
                    <thead class="table-light">
                        <tr>
                            <th style="width: 5%">#</th>
                            <th>File Name</th>
                            <th>File Type</th>
                            <th style="width: 15%">File Size (KB)</th>
                            <th style="width: 10%">Action</th>
                        </tr>
                    </thead>
                    <tbody id="fileTableBody"></tbody>
                </table>


                <asp:GridView ID="gvCertificates" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped table-hover mt-3">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="File Name" />
                        <asp:BoundField DataField="FileType" HeaderText="File Type" />
                        <asp:BoundField DataField="FileSize" HeaderText="Size (KB)" />

                        <asp:TemplateField HeaderText="Download">
                            <ItemTemplate>
                                <button type="button"
                                    class="btn btn-primary btn-sm"
                                    onclick="downloadCertificate(<%# Eval("EmployeeCertificateCode") %>)">
                                    Download
                                </button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
