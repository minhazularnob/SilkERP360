<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewEmployee.ascx.cs" Inherits="SilkERP360.UI.HRIS.NewEmployee" %>
<script src="../../Globals/Scripts/SilkERP360/HRIS/NewEmployee.js" type="text/javascript"></script>

<asp:HiddenField ID="txtUserEmployeeCode" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtEducationCount" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtExperienceCount" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtLeaveCounter" runat="server" Value="0" ClientIDMode="Static" />
<asp:HiddenField ID="txtCompanyCode" runat="server" Value="0" ClientIDMode="Static" />

<div id="dvBody" class="ui_control_wrapper fontSerif" style='z-index: 1000;'>
    <div id="cmd" style="width: 99%; z-index: 1001;">
        <div class="row">
            <div class="col-10">
                <h3 class="fontSerif" style="margin-left:20%">New Appoinment</h3>
            </div>
            <div class="col-2">
                <p class="login button">
                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ClientIDMode="Static" OnClientClick="Save(); return false;" Style="width: 70px;" />&nbsp;
                </p>
            </div>
        </div>
    </div>
    <div id="tabs" style="width: 99%; height: 900px; overflow-y: auto; position: relative; z-index: 12; top: 0px; left: 1px; z-index: 1002; font-size: small" class="fontSerif fontBold">
        <ul>
            <li><a href="#ImageTab">Image</a></li>
            <li><a href="#OfficialTab">Official</a></li>
            <li><a href="#PersonalTab">Personal</a></li>
            <li><a href="#SalaryTab">Salary  Leaves & Reference</a></li>
            <li><a href="#EducationExperienceTab">Education  Experiance  </a></li>
            <li><a href="#CertificateTab">Certificate </a></li>
        </ul>

        <div id="ImageTab" class="position-relative p-3" style="z-index: 1003;">
            <div class="container">
                <h3 class="fontSerif mb-4">Image Information</h3>

                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4 text-center">
                        <img id="imgEmployeeImage" src="../../Globals/Images/images.jpg"
                            alt="Employee Image" class="img-fluid rounded"
                            style="max-width: 160px; height: auto;">
                    </div>
                </div>

                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4">
                        <input id="fileBrowser" type="file" class="form-control" onchange="return LoadImage();">
                    </div>
                </div>

                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4 mb-2">
                        <input id="txt_EI_ImageType" class="form-control" placeholder="File Type" readonly>
                    </div>
                </div>

                <div class="row mb-3 justify-content-center">
                    <div class="col-md-4 mb-2">
                        <input id="txt_EI_ImageSize" class="form-control" placeholder="File Size" readonly>
                    </div>
                </div>

                <div class="row justify-content-center">
                    <div class="col-md-4">
                        <button id="btnDeleteImage" class="btn btn-danger w-100" type="button" onclick="return DeleteImage();">
                            Delete
                        </button>
                    </div>
                </div>
            </div>
        </div>
        <div id="OfficialTab" class="position-relative p-3" style='z-index: 1004; max-height: 900px; overflow-y: auto'>
            <div class="container-fluid">
                <h3 class="fontSerif">Official Information</h3>
                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Department</label>
                    <div class="col-sm-11">
                        <asp:DropDownList ID="ddl_Off_Department" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Department">
                            <asp:ListItem Value="0">----Select Department----</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Employee Name</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_Name" Style="width: 100%" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Emp. Name">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Shift Code</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_Shift_Code" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Shift">
                            <asp:ListItem>----- Select Shift -----</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">ACS Code</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_ACSCode" Style="width: 100%" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="ACS Code">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Designation</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_Off_Designation" runat="server" ClientIDMode="Static"
                            CssClass="form-control input-required" PlaceHolder="Designation">
                            <asp:ListItem Value="0">----Select Designation -----</asp:ListItem>
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
                        <asp:TextBox ID="txt_Off_AutoRefEmployee" Style="width: 100%" runat="server" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Search RefEmployee">
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
                        <asp:TextBox ID="txt_Off_AutoSuperVisor" Style="width: 100%" runat="server" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Search Super Visor">
                        </asp:TextBox>
                    </div>
                </div>


                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Join Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_JoiningDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Joining Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Confirmation Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_ConfirmationDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Conf. Date">
                        </asp:TextBox>
                    </div>
                </div>


                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Retirement Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_RetirementDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Ret. Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Settlement Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_SettlementDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Settlement Date">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Official File No</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_OfficialFileNo" Style="width: 100%" runat="server" ReadOnly="false" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Off. File No">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Bond Reference</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_BondRefference" Style="width: 100%" runat="server" ReadOnly="false" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Bond Reference">
                        </asp:TextBox>
                    </div>
                </div>


                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Bond Issue Date</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_BondIssueDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Bond Issue Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Bond Year</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_BondYear" runat="server" ClientIDMode="Static" CssClass="form-select">
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
                        <asp:TextBox ID="txt_BondValidityDate" Style="width: 100%" runat="server" ReadOnly="true" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Bond Expiry Date">
                        </asp:TextBox>
                    </div>

                    <label class="col-sm-1 col-form-label">Remarks</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_Remarks" Style="width: 97%" runat="server" ClientIDMode="Static" CssClass="form-control"
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
                        <asp:TextBox ID="txt_Off_Tin" Style="width: 100%" runat="server" ReadOnly="false" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="e-TIN No">
                        </asp:TextBox>
                    </div>
                </div>



                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Bank</label>
                    <div class="col-sm-5 d-flex align-items-center">
                        <asp:CheckBox ID="chkBankSalary" runat="server" Text="Bank Salary" ClientIDMode="Static" />
                    </div>

                    <label class="col-sm-1 col-form-label">Bank Account Number</label>
                    <div class="col-sm-5">
                        <asp:TextBox ID="txt_Off_BankAccountCode" Style="width: 100%" runat="server" ReadOnly="false" ClientIDMode="Static"
                            CssClass="form-control" PlaceHolder="Bank Account number">
                        </asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <label class="col-sm-1 col-form-label">Eligible</label>
                    <div class="col-sm-5 d-flex flex-wrap gap-2 align-items-center">
                        <asp:CheckBox ID="chkOTEligable" runat="server" Text="OT Eligible" ClientIDMode="Static" />
                        <asp:CheckBox ID="chkPFEligable" runat="server" Text="PF Eligible" ClientIDMode="Static" />
                        <asp:CheckBox ID="chkRoster" runat="server" Text="Roster Eligible" ClientIDMode="Static" />
                        <asp:CheckBox ID="checNightBill" runat="server" Text="Night Bill Eligible" ClientIDMode="Static" />
                        <asp:CheckBox ID="Check_ComUniform" runat="server" Text="Uniform Eligible" ClientIDMode="Static" />
                    </div>

                    <label class="col-sm-1 col-form-label">Bank Name</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="txtBankName" runat="server" ClientIDMode="Static" CssClass="form-select">
                            <asp:ListItem Value="0">----- Select Bank -----</asp:ListItem>
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
                    <!-- Weekend Checkboxes -->
                    <label class="col-sm-1 col-form-label">Weekend</label>
                    <div class="col-sm-5 d-flex flex-wrap gap-2" id="chkbox" style="z-index: 1005;">
                        <asp:CheckBox ID="chk1" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Saturday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk2" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Sunday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk3" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Monday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk4" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Tuesday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk5" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Wednesday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk6" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Thursday" onclick="CheckBoxCount();" />
                        <asp:CheckBox ID="chk7" Style="margin: 5px" runat="server" AutoPostBack="false" ClientIDMode="Static" Text="Friday" onclick="CheckBoxCount();" />
                    </div>

                    <!-- Job Location Dropdown -->
                    <label class="col-sm-1 col-form-label">Job Location</label>
                    <div class="col-sm-5">
                        <asp:DropDownList ID="ddl_JobLocation" runat="server" ClientIDMode="Static" CssClass="form-select input-required">
                            <asp:ListItem Value="0">----- Select Job Location -----</asp:ListItem>
                            <asp:ListItem>Corporate</asp:ListItem>
                            <asp:ListItem>Silkcard Factory</asp:ListItem>
                            <asp:ListItem>Wellpac Factory</asp:ListItem>
                            <asp:ListItem>Chandpur</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                </div>
            </div>
        </div>
        <div id="PersonalTab" class="position-relative p-3" style='z-index: 1006; max-height: 900px; overflow-y: auto'>
            <div class="container-fluid">
                <h3 class="fontSerif">Personal Information</h3>

            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Father Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_FatherName" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Father Name" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Mother Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_MotherName" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Mother Name" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Spouse Name</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_SpouseName" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Spouse Name" CssClass="form-control">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Date Of Birth</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_DateOfBirth" Style="width: 100%" runat="server" ClientIDMode="Static"
                        ReadOnly="true" PlaceHolder="Date Of Birth" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Marital Status</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_MaritalStatus" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required" PlaceHolder="Marital Status">
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
                        CssClass="form-control input-required" PlaceHolder="Gender">
                        <asp:ListItem Value="0">-----Select Gender-----</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Religion</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_Religion" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required" PlaceHolder="Religion">
                        <asp:ListItem Value="0">----- Select Religion -----</asp:ListItem>
                        <asp:ListItem>Islam</asp:ListItem>
                        <asp:ListItem>Hinduism</asp:ListItem>
                        <asp:ListItem>Christian</asp:ListItem>
                        <asp:ListItem>Buddhist</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Nationality</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Nationality" Style="width: 100%" Text="Bangladeshi" runat="server"
                        ReadOnly="true" ClientIDMode="Static" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Blood Group</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_BloodGroup" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required" PlaceHolder="Blood Group">
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
                    <asp:TextBox ID="txt_Pers_Height" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Height" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Weight</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Weight" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Weight" CssClass="form-control">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Identification</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Identification" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Identification" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>


            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Mobile No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_MobileNo" onkeypress="return /[0-9+\-]/.test(event.key)" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Mobile No" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Home Phone</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_HomePhone" onkeypress="return /[0-9+\-]/.test(event.key)" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Home Phone" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Fax No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_FaxNo" onkeypress="return /[0-9+\-]/.test(event.key)" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Fax No" CssClass="form-control">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Email</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_Email" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Email" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>


            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present Address</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentAddress" Style="width: 97%" runat="server" ClientIDMode="Static"
                        TextMode="MultiLine" PlaceHolder="Present Address" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Permanent Address</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentAddress" Style="width: 97%" runat="server" ClientIDMode="Static"
                        TextMode="MultiLine" PlaceHolder="Permanent Address" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present District</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_PresentDistrict" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required" PlaceHolder="District">
                        <asp:ListItem Value="0">-----Select District-----</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <label class="col-sm-1 col-form-label">Permanent District</label>
                <div class="col-sm-5">
                    <asp:DropDownList ID="ddl_Pers_PermanentDistrict" runat="server" ClientIDMode="Static"
                        CssClass="form-control input-required" PlaceHolder="District">
                        <asp:ListItem Value="0">----- Select District -----</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present PO</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentPO" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Off." CssClass="form-control">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Permanent PO</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentPO" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Off." CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">Present PC</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PresentPC" onkeypress="return /[0-9]/.test(event.key)" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Code." CssClass="form-control">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Permanent PC</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PermanentPC" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Post Code" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <label class="col-sm-1 col-form-label">National ID No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_VoterCardNo" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Voter Card No" CssClass="form-control input-required">
                    </asp:TextBox>
                </div>

                <label class="col-sm-1 col-form-label">Passport No</label>
                <div class="col-sm-5">
                    <asp:TextBox ID="txt_Pers_PassportNo" Style="width: 100%" runat="server" ClientIDMode="Static"
                        PlaceHolder="Passport No" CssClass="form-control">
                    </asp:TextBox>
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
                            <tr>
                                <td>
                                    <asp:Label ID="Label59" runat="server" Text="Standard"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Basic" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_HouseRent" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Medical" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Entertainment" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Conveyence" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_PhoneBill" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Others" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Stan_Sal_Gross" runat="server" class="currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label60" runat="server" Text="Approved"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Basic" runat="server" class="input-required salary_field currency_field form-control text-end" ReadOnly="true" ClientIDMode="Static" Text="0.00" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_HouseRent" runat="server" class="currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Medical" runat="server" class="input-required salary_field currency_field form-control text-end" ReadOnly="true" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Entertainment" runat="server" class="salary_field currency_field form-control text-end" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Conveyence" runat="server" class="input-required salary_field currency_field form-control text-end" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_PhoneBill" runat="server" class="salary_field currency_field form-control text-end" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Others" runat="server" class="salary_field currency_field form-control text-end" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Sal_Gross" runat="server" class="input-required gross_salary currency_field form-control text-end" ReadOnly="false" Text="0.00" ClientIDMode="Static" onkeypress='return IsDouble(event)'></asp:TextBox></td>
                            </tr>
                        </tbody>
                    </table>
                </div>

                <!-- Leave Information -->
                <h3 class="fontSerif mt-4 mb-3">Leave Information</h3>

                <div class="table-responsive">
                    <table id="tblLeave" class="table table-bordered w-100" style="background-color: #CCCCCC;">
                        <thead>
                            <tr class="text-center">
                                <th style="width: 20%;">
                                    <asp:CheckBox ID="chkLeave" OnClick="return SelectLeaveALL();" AutoPostBack="false" runat="server" Text="Action" />
                                </th>
                                <th style="width: 30%;">Leave</th>
                                <th style="width: 30%;">Number Of Days</th>
                                <th style="width: 20%;">Carry Forwarded</th>
                            </tr>
                        </thead>
                        <tbody>
                            <!-- Dynamic Leave Rows will go here -->
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
        <div id="EducationExperienceTab" style="z-index: 1007;">
            <div id="mm" style="height: auto; z-index: 1008;">
                <!-- Education Section -->
                <div class="table-responsive">
                    <h3 class="fontSerif">Education Details</h3>
                    <table id="tblEducation" class="table table-bordered w-100">

                        <thead class="table-light text-center">
                            <tr>
                                <th style="width: 15%">
                                    <asp:Label ID="Label95" runat="server" Text="Exam"></asp:Label></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label96" runat="server" Text="Board/University"></asp:Label></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label97" runat="server" Text="Ins. Name"></asp:Label></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label98" runat="server" Text="Major Subject"></asp:Label></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label99" runat="server" Text="Division/Class"></asp:Label></th>
                                <th style="width: 8%">
                                    <asp:Label ID="Label100" runat="server" Text="CGPA"></asp:Label></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label101" runat="server" Text="Passing Year"></asp:Label></th>
                                <th style="width: 2%"></th>
                            </tr>
                        </thead>
                        <tbody class="text-center">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_Edu_ExamName" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Exam" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_BoardUniversity" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Board/Uni" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_InstituteName" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Inst. Name" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_MajorSubject" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Major Sub." CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_DivisionClass" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Division/Class" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_CGPA" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="CGPA" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Edu_PassingYear" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Passing Year" CssClass="form-control"></asp:TextBox></td>
                                <td class="text-center">
                                    <a href="#" onclick="addEducation(); return false;">
                                        <img id="btnAddNewRow" alt="New Row" title="Add New Row" style="cursor: pointer" src="../../Globals/Images/add-2.png" />
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <div id="Experience" style="height: 225px; z-index: 1009; margin-top: 20px;">
                <!-- Experience Section -->
                <div class="table-responsive">
                    <h3 class="fontSerif">Experience Details</h3>
                    <table id="tblExperience" class="table table-bordered w-100">
                        <thead class="table-light text-center">
                            <tr>
                                <th style="width: 15%">
                                    <asp:Label ID="Label102" runat="server" Text="Organization Name"></asp:Label></th>
                                <th style="width: 20%">
                                    <asp:Label ID="Label103" runat="server" Text="Address"></asp:Label></th>
                                <th style="width: 10%">
                                    <asp:Label ID="Label104" runat="server" Text="Responsibility"></asp:Label></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label105" runat="server" Text="Nature Of Job"></asp:Label></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label106" runat="server" Text="Contact No"></asp:Label></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label107" runat="server" Text="Date From"></asp:Label></th>
                                <th style="width: 15%">
                                    <asp:Label ID="Label108" runat="server" Text="Date To"></asp:Label></th>
                                <th style="width: 5%"></th>
                            </tr>
                        </thead>
                        <tbody class="text-center">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txt_Exp_OrganizationName" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Organization" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_Address" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Address" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_Responsibility" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Responsibility" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_NatureOfJob" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Nature Of Job" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_ContactNo" runat="server" ReadOnly="false" ClientIDMode="Static" PlaceHolder="Contact No" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_DateFrom" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Date From" CssClass="form-control"></asp:TextBox></td>
                                <td>
                                    <asp:TextBox ID="txt_Exp_DateTo" runat="server" ReadOnly="true" ClientIDMode="Static" PlaceHolder="Date To" CssClass="form-control"></asp:TextBox></td>
                                <td class="text-center">
                                    <a href="#" onclick="addExperience(); return false;">
                                        <img id="Img1" alt="New Row" title="Add New Row" style="cursor: pointer" src="../../Globals/Images/add-2.png" />
                                    </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div id="CertificateTab" style="z-index: 1007;">
            <div id="mm" style="height: auto; z-index: 1008;">
                <div class="table-responsive">
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
                </div>
            </div>
        </div>

    </div>
</div>