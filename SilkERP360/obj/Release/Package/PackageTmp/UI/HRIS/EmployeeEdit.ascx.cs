using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class EmployeeEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                this.Session.Remove("comp_c");

                System.String lcl_str_EmployeeCode = this.Session["Emp_c"].ToString();
                System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_str_EmployeeCode);
                this.Session.Remove("Emp_c");

                //select image,image_type,image_size from employee_image where employee_code=101000000333
                txtUserEmployeeCode.Value = lcl_str_EmployeeCode;


                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();


                //System.Text.StringBuilder lcl_obj_HTMLBuilder = new System.Text.StringBuilder();
                //lcl_obj_HTMLBuilder.Append("var gbl_ui64_EmployeeCode = ");
                //lcl_obj_HTMLBuilder.Append(lcl_str_EmployeeCode);
                //lcl_obj_HTMLBuilder.Append(" ;");
                //System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "EMP_CODE", lcl_obj_HTMLBuilder.ToString(), true);
                //lcl_obj_HTMLBuilder.Clear();
                //lcl_obj_SqlFacade.CloseReader();


                //setup ddlDepartment
                System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format("Select DEPARTMENT_CODE,DEPT_NAME From Department Where Company_Code = {0} AND Status = {1} AND Is_Deleted = 1 order by DEPT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DepartmentReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_DepartmentReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Departments for The Selected Company Was Not Found!!!");
                }
                System.Int32 lcl_i32_j = 1;
                while (lcl_obj_DepartmentReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_DepartmentItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_DepartmentItem.Value = lcl_obj_DepartmentReader["DEPARTMENT_CODE"].ToString();
                    lcl_obj_DepartmentItem.Text = lcl_obj_DepartmentReader["DEPT_NAME"].ToString();
                    this.ddl_Off_Department.Items.Insert(lcl_i32_j++, lcl_obj_DepartmentItem);
                }
                lcl_obj_SqlFacade.CloseReader();

               

                //setup ddlShift
                lcl_str_SqlQuery = System.String.Format(@"Select SHIFT_CODE,SHIFT_NAME||' ('||to_char(START_TIME, 'hh24:mi:ss')||'-To-'||
                to_char(END_TIME, 'hh24:mi:ss')||')'SHIFT_NAME From Shift Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by SHIFT_NAME", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ShiftReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_ShiftReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Shift for The Selected Company Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_ShiftReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_ShiftItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_ShiftItem.Value = lcl_obj_ShiftReader["SHIFT_CODE"].ToString();
                    lcl_obj_ShiftItem.Text = lcl_obj_ShiftReader["SHIFT_NAME"].ToString();
                    this.ddl_Off_Shift_Code.Items.Insert(lcl_i32_j++, lcl_obj_ShiftItem);
                }
                lcl_obj_SqlFacade.CloseReader();


                //setup ddlDesignation
                lcl_str_SqlQuery = System.String.Format(@" SELECT DESIGNATION_CODE, DEGN_NAME FROM DESIGNATION Where COMPANY_CODE = {0} AND Status = {1} AND Is_Deleted = 1 order by DEGN_NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_DesignationReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_DesignationReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Designation for The Selected Company Was Not Found!!!");

                    lcl_i32_j = 1;
                    while (lcl_obj_DesignationReader.Read())
                    {
                        System.Web.UI.WebControls.ListItem lcl_obj_DesignationItem = new System.Web.UI.WebControls.ListItem();
                        lcl_obj_DesignationItem.Value = lcl_obj_DesignationReader["DESIGNATION_CODE"].ToString();
                        lcl_obj_DesignationItem.Text = lcl_obj_DesignationReader["DEGN_NAME"].ToString();
                        this.ddl_Off_Designation.Items.Insert(lcl_i32_j++, lcl_obj_DesignationItem);
                    }
                    lcl_obj_SqlFacade.CloseReader();
                }
                //setup ddlRefEpmloyee
                lcl_str_SqlQuery = System.String.Format(@"select EMPLOYEE_CODE,EmpName From
                (select EMPLOYEE_CODE,EMPLOYEE_NAME||'('||EMPLOYEE_ID||')' AS EmpName,IS_DELETED,EMPLOYEE_STATUS
                From EMPLOYEE )X  Where  EMPLOYEE_STATUS ={1} AND IS_DELETED = 1 Order by EmpName  ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RefEpmloyeeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if( (lcl_obj_RefEpmloyeeReader.HasRows)==true)
                {
                   // throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("RefEmployee Was Not Found!!!");

                    lcl_i32_j = 1;
                    while (lcl_obj_RefEpmloyeeReader.Read())
                    {
                        System.Web.UI.WebControls.ListItem lcl_obj_RefEpmloyeItem = new System.Web.UI.WebControls.ListItem();
                        lcl_obj_RefEpmloyeItem.Value = lcl_obj_RefEpmloyeeReader["EMPLOYEE_CODE"].ToString();
                        lcl_obj_RefEpmloyeItem.Text = lcl_obj_RefEpmloyeeReader["EmpName"].ToString();
                        this.ddl_Off_RefEmployee.Items.Insert(lcl_i32_j++, lcl_obj_RefEpmloyeItem);
                    }
               
                lcl_obj_SqlFacade.CloseReader();
                }
                //setup ddl_Pers_PresentDistrict
                lcl_str_SqlQuery = System.String.Format(@"Select DISTRICT_CODE,NAME From district Where is_deleted=1 And status={1}Order by NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_PresentDistrictReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_PresentDistrictReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("PresentDistrict Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_PresentDistrictReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_PresentDistrictItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_PresentDistrictItem.Value = lcl_obj_PresentDistrictReader["DISTRICT_CODE"].ToString();
                    lcl_obj_PresentDistrictItem.Text = lcl_obj_PresentDistrictReader["NAME"].ToString();
                    this.ddl_Pers_PresentDistrict.Items.Insert(lcl_i32_j++, lcl_obj_PresentDistrictItem);
                }
                lcl_obj_SqlFacade.CloseReader();
                //setup ddl_Pers_PermanentDistrict
                lcl_str_SqlQuery = System.String.Format(@"Select DISTRICT_CODE,NAME From district Where is_deleted=1 And status={1}Order by NAME ", lcl_str_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_PermanentDistrictReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_PermanentDistrictReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("PermanentDistrict Was Not Found!!!");
                }
                lcl_i32_j = 1;
                while (lcl_obj_PermanentDistrictReader.Read())
                {
                    System.Web.UI.WebControls.ListItem lcl_obj_PermanentDistrictItem = new System.Web.UI.WebControls.ListItem();
                    lcl_obj_PermanentDistrictItem.Value = lcl_obj_PermanentDistrictReader["DISTRICT_CODE"].ToString();
                    lcl_obj_PermanentDistrictItem.Text = lcl_obj_PermanentDistrictReader["NAME"].ToString();
                    this.ddl_Pers_PermanentDistrict.Items.Insert(lcl_i32_j++, lcl_obj_PermanentDistrictItem);
                }
                lcl_obj_SqlFacade.CloseReader();

                //Image show
                lcl_str_SqlQuery = System.String.Format(@"select image,image_type,image_size from employee_image where employee_code={0} ", lcl_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IamgeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_IamgeReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Image Not Found!!!");
               
                lcl_i32_j = 1;
                while (lcl_obj_IamgeReader.Read())
                {
                    System.Web.UI.WebControls.Image lcl_obj_ImageItem = new System.Web.UI.WebControls.Image();
                    byte[] photoByte = null;
                    int ArraySize;
                    photoByte = (byte[])lcl_obj_IamgeReader["image"];
                    ArraySize = photoByte.GetUpperBound(0);
                    MemoryStream ms = new MemoryStream(ArraySize + 1);
                    ms.Write(photoByte, 0, ArraySize + 1);
                    photoByte = ms.ToArray();
                    Convert.ToBase64String(photoByte);
                    txt_EI_ImageSize.Text = lcl_obj_IamgeReader["image_size"].ToString();
                    txt_EI_ImageType.Text = lcl_obj_IamgeReader["image_type"].ToString();
                    string data = "data:" + lcl_obj_IamgeReader["image_type"].ToString() + ";base64,";
                    lcl_obj_ImageItem.ImageUrl = data + Convert.ToBase64String(photoByte);
                               
                    imgEmployeeImage.ImageUrl = data + Convert.ToBase64String(photoByte);
                }
                lcl_obj_SqlFacade.CloseReader();
                }




               




                //Show week end
                lcl_str_SqlQuery = System.String.Format(@"select nvl(day,0) day from employee_weekend where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_weekEndReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_weekEndReader.HasRows))
                {
                    lcl_i32_j = 1;

                    while (lcl_obj_weekEndReader.Read())
                    {
                        if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 1)
                        {
                            chk1.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 2)
                        {
                            chk2.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 3)
                        {
                            chk3.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 4)
                        {
                            chk4.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 5)
                        {
                            chk5.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 6)
                        {
                            chk6.Checked = true;
                        }
                        else if (Convert.ToInt32(lcl_obj_weekEndReader["day"].ToString()) == 7)
                        {
                            chk7.Checked = true;
                        }

                    }
                    lcl_obj_SqlFacade.CloseReader();
                
                }
                

                //Show Employee
                lcl_str_SqlQuery = System.String.Format(@"select EMPLOYEE_CODE,EMPLOYEE_ID,EMPLOYEE_ACS_CODE,EMPLOYEE_NAME,DESIGNATION_CODE,DEPARTMENT_CODE
                                   ,COMPANY_CODE,nvl(REF_EMPLOYEE_CODE,0)REF_EMPLOYEE_CODE,nvl(SUPERVISOR_CODE,0)SUPERVISOR_CODE,JOINING_DATE,CONFIRMATION_DATE,RETIREMENT_DATE,SETTLEMENT_DATE,OFFICIAL_FILE_NO
                                   ,TIN,REMARKS,nvl(IS_PF_ELIGIBLE,0) IS_PF_ELIGIBLE,PF_CODE,nvl(IS_OT_ELIGIBLE,0)IS_OT_ELIGIBLE,nvl(SALARY_PAYABLE_AT_BANK,0)SALARY_PAYABLE_AT_BANK,nvl(BANK_ACCOUNT_NO,0)BANK_ACCOUNT_NO
                                    ,BANK_NAME,IS_DELETED,EMPLOYEE_STATUS,nvl(IS_ON_ROSTER,0) IS_ON_ROSTER,nvl(NIGHT_BILL_ELIGIBLE,0) NIGHT_BILL_ELIGIBLE,JOB_LOCATION,BOND_VALIDITY_DATE,BOND_REFERENCE,BOND_ISSUE_DATE,BOND_YEAR
                                   ,nvl(SHIFT_CODE,0)SHIFT_CODE,nvl(IS_UNIFORM_ELIGIBLE,0)IS_UNIFORM_ELIGIBLE,nvl(E_TIN_ELIGIBLE,0)E_TIN_ELIGIBLE from employee where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_officiallReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_officiallReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("official Information Not Found!!!");

                    lcl_i32_j = 1;
                    while (lcl_obj_officiallReader.Read())
                    {
                        ddl_Off_Department.Items.FindByValue(lcl_obj_officiallReader["DEPARTMENT_CODE"].ToString()).Selected = true;
                        txt_Off_Name.Text = lcl_obj_officiallReader["EMPLOYEE_NAME"].ToString();
                        ddl_Off_Shift_Code.Items.FindByValue(lcl_obj_officiallReader["SHIFT_CODE"].ToString()).Selected = true;
                        txt_Off_ACSCode.Text = lcl_obj_officiallReader["EMPLOYEE_ACS_CODE"].ToString();
                        ddl_Off_Designation.Items.FindByValue(lcl_obj_officiallReader["DESIGNATION_CODE"].ToString()).Selected = true;
                        ddl_Off_RefEmployee.Items.FindByValue(lcl_obj_officiallReader["REF_EMPLOYEE_CODE"].ToString()).Selected = true;
                        ddl_Off_Supervisor.Items.FindByValue(lcl_obj_officiallReader["SUPERVISOR_CODE"].ToString()).Selected = true;
                        txt_Off_JoiningDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["JOINING_DATE"]);
                        txt_Off_ConfirmationDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["CONFIRMATION_DATE"]);
                        txt_Off_RetirementDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["RETIREMENT_DATE"]);
                        txt_Off_SettlementDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["SETTLEMENT_DATE"]);
                        txt_Off_OfficialFileNo.Text = lcl_obj_officiallReader["OFFICIAL_FILE_NO"].ToString();
                        txt_Off_Tin.Text = lcl_obj_officiallReader["TIN"].ToString();
                        //txt_BondValidityDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["BOND_VALIDITY_DATE"]);
                        ddl_JobLocation.Items.FindByValue(lcl_obj_officiallReader["JOB_LOCATION"].ToString()).Selected = true;
                        txt_Off_Remarks.Text = lcl_obj_officiallReader["REMARKS"].ToString();
                        txtBankName.Text = lcl_obj_officiallReader["BANK_NAME"].ToString();
                       // txt_BondRefference.Text = lcl_obj_officiallReader["BOND_REFERENCE"].ToString();
                        txt_BondIssueDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["BOND_ISSUE_DATE"]);
                        txt_BondValidityDate.Text = String.Format("{0:dd/MMMM/yyyy}", lcl_obj_officiallReader["BOND_VALIDITY_DATE"]);
                        txt_BondRefference.Text = lcl_obj_officiallReader["BOND_REFERENCE"].ToString();
                        ddl_BondYear.Items.FindByValue(lcl_obj_officiallReader["BOND_YEAR"].ToString()).Selected = true;

                        if (Convert.ToInt32(lcl_obj_officiallReader["IS_PF_ELIGIBLE"].ToString()) == 1)
                        {
                            chkPFEligable.Checked = true;
                        }

                        if (Convert.ToInt32(lcl_obj_officiallReader["IS_OT_ELIGIBLE"].ToString()) == 1)
                        {
                            chkOTEligable.Checked = true;
                        }
                        if (Convert.ToInt32(lcl_obj_officiallReader["IS_ON_ROSTER"].ToString()) == 1)
                        {
                            chkRoster.Checked = true;
                        }

                        if (Convert.ToInt32(lcl_obj_officiallReader["NIGHT_BILL_ELIGIBLE"].ToString()) == 1)
                        {
                            checNightBill.Checked = true;
                        }

                        if (Convert.ToInt32(lcl_obj_officiallReader["IS_UNIFORM_ELIGIBLE"].ToString()) == 1)
                        {
                            Check_ComUniform.Checked = true;
                        }
                        if (Convert.ToInt32(lcl_obj_officiallReader["SALARY_PAYABLE_AT_BANK"].ToString()) == 1)
                        {
                            chkBankSalary.Checked = true;
                            txt_Off_BankAccountCode.Text = lcl_obj_officiallReader["BANK_ACCOUNT_NO"].ToString();

                        }
                        if (Convert.ToInt32(lcl_obj_officiallReader["E_TIN_ELIGIBLE"].ToString()) == 1)
                        {
                            chk_eTIN_Eligible.Checked = true;
                            txt_Off_Tin.Text = lcl_obj_officiallReader["TIN"].ToString();
                        }

                    }
                    lcl_obj_SqlFacade.CloseReader();

                }


       

                //Show Personal
                lcl_str_SqlQuery = System.String.Format(@"select  EMPLOYEE_CODE,FATHER_NAME,MOTHER_NAME,SPOUSE_NAME,DATE_OF_BIRTH,MARITAL_STATUS
                                    ,SEX,RELIGION,NATIONALITY,BLOOD_GROUP,HEIGHT,WEIGHT,IDENTIFICATION,MOBILE_NO,HOME_PHONE_NO,FAX_NO,EMAIL,PRESENT_ADDRESS
                                    ,PRESENT_PO,PRESENT_PC,PRESENT_DISTRICT_CODE,PERMANENT_ADDRESS,PERMANENT_PO,PERMANENT_PC,PERMANENT_DISTRICT_CODE,CITIZEN_CARD_ID
                                    ,PASSPORT_NO,IS_DELETED,STATUS from EMPLOYEE_PERSONAL where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_PersonalReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_PersonalReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Personal Information Not Found!!!");
               
                lcl_i32_j = 1;
                while (lcl_obj_PersonalReader.Read())
                {

                    txt_Pers_FatherName.Text = lcl_obj_PersonalReader["FATHER_NAME"].ToString();
                    txt_Pers_MotherName.Text = lcl_obj_PersonalReader["MOTHER_NAME"].ToString();
                    txt_Pers_SpouseName.Text = lcl_obj_PersonalReader["SPOUSE_NAME"].ToString();

                    txt_Pers_DateOfBirth.Text =String.Format("{0:dd/MMMM/yyyy}",  lcl_obj_PersonalReader["DATE_OF_BIRTH"]);
                    ddl_Pers_MaritalStatus.Items.FindByValue( lcl_obj_PersonalReader["MARITAL_STATUS"].ToString()).Selected = true;
                    ddl_Pers_Sex.Items.FindByValue(lcl_obj_PersonalReader["SEX"].ToString()).Selected = true;
                    ddl_Pers_Religion.Items.FindByValue(lcl_obj_PersonalReader["RELIGION"].ToString()).Selected = true;
                    txt_Pers_Nationality.Text = lcl_obj_PersonalReader["NATIONALITY"].ToString();
                    ddl_Pers_BloodGroup.Items.FindByValue(lcl_obj_PersonalReader["BLOOD_GROUP"].ToString()).Selected = true;
                    txt_Pers_Height.Text = lcl_obj_PersonalReader["HEIGHT"].ToString();
                    txt_Pers_Weight.Text = lcl_obj_PersonalReader["WEIGHT"].ToString();
                    txt_Pers_Identification.Text = lcl_obj_PersonalReader["IDENTIFICATION"].ToString();
                    txt_Pers_MobileNo.Text = lcl_obj_PersonalReader["MOBILE_NO"].ToString();
                    txt_Pers_HomePhone.Text = lcl_obj_PersonalReader["HOME_PHONE_NO"].ToString();
                    txt_Pers_FaxNo.Text = lcl_obj_PersonalReader["FAX_NO"].ToString();
                    txt_Pers_Email.Text = lcl_obj_PersonalReader["EMAIL"].ToString();
                    txt_Pers_PresentAddress.Text = lcl_obj_PersonalReader["PRESENT_ADDRESS"].ToString();
                    txt_Pers_PresentPO.Text = lcl_obj_PersonalReader["PRESENT_PO"].ToString();
                    txt_Pers_PresentPC.Text = lcl_obj_PersonalReader["PRESENT_PC"].ToString();
                    ddl_Pers_PresentDistrict.Items.FindByValue(lcl_obj_PersonalReader["PRESENT_DISTRICT_CODE"].ToString()).Selected = true;
                    txt_Pers_PermanentAddress.Text = lcl_obj_PersonalReader["PERMANENT_ADDRESS"].ToString();
                    txt_Pers_PermanentPO.Text = lcl_obj_PersonalReader["PERMANENT_PO"].ToString();
                    txt_Pers_PermanentPC.Text = lcl_obj_PersonalReader["PERMANENT_PC"].ToString();
                    ddl_Pers_PermanentDistrict.Items.FindByValue(lcl_obj_PersonalReader["PERMANENT_DISTRICT_CODE"].ToString()).Selected = true;
                    txt_Pers_VoterCardNo.Text = lcl_obj_PersonalReader["CITIZEN_CARD_ID"].ToString();
                    txt_Pers_PassportNo.Text = lcl_obj_PersonalReader["PASSPORT_NO"].ToString();
                }
                lcl_obj_SqlFacade.CloseReader();

                }
                 //Show Salary
                lcl_str_SqlQuery = System.String.Format(@"select SALARY_STRUCTURE_CODE,EMPLOYEE_CODE,BASIC,HOUSE_RENT,MEDICAL,ENTERTAINMENT,CONVEYENCE,PHONE_BILL,OTHERS
                                   ,GROSS,EFFECTIVE_FROM,EFFECTIVE_UPTO,IS_DELETED,STATUS from employee_salary_structure where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_SalaryReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_SalaryReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Salary Information Not Found!!!");
                
                lcl_i32_j = 1;
                while (lcl_obj_SalaryReader.Read())
                {
                    txt_Sal_Basic.Text = lcl_obj_SalaryReader["BASIC"].ToString();
                    txt_Sal_HouseRent.Text = lcl_obj_SalaryReader["HOUSE_RENT"].ToString();
                    txt_Sal_Medical.Text = lcl_obj_SalaryReader["MEDICAL"].ToString();
                    txt_Sal_Entertainment.Text = lcl_obj_SalaryReader["ENTERTAINMENT"].ToString();
                    txt_Sal_PhoneBill.Text = lcl_obj_SalaryReader["PHONE_BILL"].ToString();
                    txt_Sal_Others.Text = lcl_obj_SalaryReader["OTHERS"].ToString();
                    txt_Sal_Conveyence.Text = lcl_obj_SalaryReader["CONVEYENCE"].ToString();
                    txt_Sal_Gross.Text = lcl_obj_SalaryReader["GROSS"].ToString();

              }
                lcl_obj_SqlFacade.CloseReader();
                }
                //Show Leave

                lcl_str_SqlQuery = System.String.Format(@"Select Leave_Name,No_Of_Days,leave.leave_code,company_code,short_name,is_carry_forwarded from leave inner join
                                                    employee_entitle_leave on leave.leave_code=employee_entitle_leave.leave_code
                                                    where Employee_code={0} and company_code={1} ", lcl_ui64_EmployeeCode, lcl_ui64_CompanyCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_LeaveReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_LeaveReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Leave Information Not Found!!!");

                    Int32 i = 1;
                    Int32 j = 0;

                while (lcl_obj_LeaveReader.Read())
                {
                    System.Web.UI.HtmlControls.HtmlTableRow lcl_obj_LD_Row = new System.Web.UI.HtmlControls.HtmlTableRow();
                   
                    System.Web.UI.HtmlControls.HtmlInputCheckBox lcl_obj_check = new System.Web.UI.HtmlControls.HtmlInputCheckBox();

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_check = new System.Web.UI.HtmlControls.HtmlTableCell();

                    lcl_obj_check.Checked = true;
                    
                        
                    lcl_obj_check.ID = ("chkLeave-" + i.ToString());
                    lcl_obj_check.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_check.Controls.Add(lcl_obj_check);
                    lcl_obj_LD_check.Align = "center";
                    lcl_obj_LD_check.Width = "20%";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveTypeCell = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveTypeCell.InnerText = lcl_obj_LeaveReader["Leave_Name"].ToString();
                    lcl_obj_LD_LeaveTypeCell.Align = "center";
                    lcl_obj_LD_LeaveTypeCell.Width = "30%";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveDue = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveDue.InnerText = lcl_obj_LeaveReader["No_Of_Days"].ToString();
                    lcl_obj_LD_LeaveDue.Align = "center";
                    lcl_obj_LD_LeaveDue.Width = "30%";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveCode = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.HiddenField txt_obj_LeaveCode = new System.Web.UI.WebControls.HiddenField();
                    txt_obj_LeaveCode.Value = lcl_obj_LeaveReader["leave_code"].ToString();
                    txt_obj_LeaveCode.ID = ("txtLeaveCode-" + i.ToString());
                    txt_obj_LeaveCode.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_LeaveCode.Align = "center";
                    lcl_obj_LD_LeaveCode.Controls.Add(txt_obj_LeaveCode);                    

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_LeaveTaken = new System.Web.UI.HtmlControls.HtmlTableCell();
                    lcl_obj_LD_LeaveTaken.InnerText = lcl_obj_LeaveReader["is_carry_forwarded"].ToString();
                    lcl_obj_LD_LeaveTaken.Align = "center";
                    lcl_obj_LD_LeaveTaken.Width = "20%";

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_Days = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.HiddenField txt_obj_Leavedays = new System.Web.UI.WebControls.HiddenField();
                    txt_obj_Leavedays.Value = lcl_obj_LeaveReader["No_Of_Days"].ToString();
                    txt_obj_Leavedays.ID = ("txtBalance-" + i.ToString());
                    txt_obj_Leavedays.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_Days.Align = "center";
                    lcl_obj_LD_Days.Controls.Add(txt_obj_Leavedays);


                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_check);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveTypeCell);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveDue);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveTaken);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_LeaveCode);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_Days);
                   
                    this.tblLeave.Rows.Add(lcl_obj_LD_Row);
                    i++;
                    j++;

                }
                txtLeaveCounter.Value = j.ToString();
                lcl_obj_SqlFacade.CloseReader();

                }
                //show Education

                lcl_str_SqlQuery = System.String.Format(@"select EDUCATION_CODE,EXAM_NAME,INST_NAME,BOARD_UNIVERSITY,MAJOR_SUBJECT,DIVISION_CLASS,CGPA,
                	   						   	PASS_YEAR,EMPLOYEE_CODE from employee_education where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_ob_EducationReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_ob_EducationReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Education Information Not Found!!!");

                    Int32 i = 1;
                    Int32 j = 0;
                    
                while (lcl_ob_EducationReader.Read())
                {
                    System.Web.UI.HtmlControls.HtmlTableRow lcl_obj_LD_Row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    System.Web.UI.HtmlControls.HtmlInputCheckBox lcl_obj_check = new System.Web.UI.HtmlControls.HtmlInputCheckBox();




                    //System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_check = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //lcl_obj_check.Checked = true;
                    //lcl_obj_LD_check.Controls.Add(lcl_obj_check);

                    

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellExam = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Exam = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Exam.Text = lcl_ob_EducationReader["EXAM_NAME"].ToString();
                    txt_obj_Exam.ID = ("txt_Edu_ExamName-" + i.ToString());
                    txt_obj_Exam.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellExam.Align = "center";
                    lcl_obj_LD_CellExam.Controls.Add(txt_obj_Exam);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellBoard = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Board = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Board.Text = lcl_ob_EducationReader["BOARD_UNIVERSITY"].ToString();
                    txt_obj_Board.ID = ("txt_Edu_BoardUniversity-" + i.ToString());
                    txt_obj_Board.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellBoard.Align = "center";
                    lcl_obj_LD_CellBoard.Controls.Add(txt_obj_Board);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellInst = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Ints = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Ints.Text = lcl_ob_EducationReader["INST_NAME"].ToString();//
                    txt_obj_Ints.ID = ("txt_Edu_InstituteName-" + i.ToString());
                    txt_obj_Ints.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellInst.Align = "center";
                    lcl_obj_LD_CellInst.Controls.Add(txt_obj_Ints);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellMajor = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Major = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Major.Text = lcl_ob_EducationReader["MAJOR_SUBJECT"].ToString();
                    txt_obj_Major.ID = ("txt_Edu_MajorSubject-" + i.ToString());
                    txt_obj_Major.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellMajor.Align = "center";
                    lcl_obj_LD_CellMajor.Controls.Add(txt_obj_Major);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellDivision = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Division = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Division.Text = lcl_ob_EducationReader["DIVISION_CLASS"].ToString();
                    txt_obj_Division.ID = ("txt_Edu_DivisionClass-" + i.ToString());
                    txt_obj_Division.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellDivision.Align = "center";
                    lcl_obj_LD_CellDivision.Controls.Add(txt_obj_Division);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellGPA = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_GPA = new System.Web.UI.WebControls.TextBox();
                    txt_obj_GPA.Text = lcl_ob_EducationReader["CGPA"].ToString();
                    txt_obj_GPA.ID = ("txt_Edu_CGPA-" + i.ToString());
                    txt_obj_GPA.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellGPA.Align = "center";
                    lcl_obj_LD_CellGPA.Controls.Add(txt_obj_GPA);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellPass = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Pass = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Pass.Text = lcl_ob_EducationReader["PASS_YEAR"].ToString();
                    txt_obj_Pass.ID = ("txt_Edu_PassingYear-" + i.ToString());
                    txt_obj_Pass.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellPass.Align = "center";
                    lcl_obj_LD_CellPass.Controls.Add(txt_obj_Pass);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellEduCode = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.HiddenField txt_obj_Code = new System.Web.UI.WebControls.HiddenField();
                    txt_obj_Code.Value = lcl_ob_EducationReader["EDUCATION_CODE"].ToString();
                    txt_obj_Code.ID = ("txt_Edu_CODE-" + i.ToString());
                    txt_obj_Code.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellEduCode.Align = "center";
                    lcl_obj_LD_CellEduCode.Controls.Add(txt_obj_Code);

                    //lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_check);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellExam);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellBoard);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellInst);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellMajor);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellDivision);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellGPA);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellPass);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellEduCode);
                    this.tblEducation.Rows.Add(lcl_obj_LD_Row);
                    i++;
                    j++;

                }
                txtEducationCount.Value = j.ToString();
                    
                lcl_obj_SqlFacade.CloseReader();

                }
                //show experience

                lcl_str_SqlQuery = System.String.Format(@"select EXPERIENCE_CODE,EMPLOYER_NAME,ADDRESS,CONTACT_NO,NATURE_OF_JOB,RESPONSIBILITY,
                	 			 					  FROM_DATE,TO_DATE,EMPLOYEE_CODE from employee_experience where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_ExprienceReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_ExprienceReader.HasRows))
                {
                      //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Exprience Information Not Found!!!");

                    Int32 i = 1;
                    Int32 j = 0;
                while (lcl_obj_ExprienceReader.Read())
                {
                    System.Web.UI.HtmlControls.HtmlTableRow lcl_obj_LD_Row = new System.Web.UI.HtmlControls.HtmlTableRow();

                    System.Web.UI.HtmlControls.HtmlInputCheckBox lcl_obj_check = new System.Web.UI.HtmlControls.HtmlInputCheckBox();




                    //System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_check = new System.Web.UI.HtmlControls.HtmlTableCell();
                    //lcl_obj_check.Checked = true;
                    //lcl_obj_LD_check.Controls.Add(lcl_obj_check);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellOrganization = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Organization = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Organization.Text = lcl_obj_ExprienceReader["EMPLOYER_NAME"].ToString();
                    txt_obj_Organization.ID = ("txt_Exp_OrganizationName-" + i.ToString());
                    txt_obj_Organization.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellOrganization.Align = "center";
                    lcl_obj_LD_CellOrganization.Controls.Add(txt_obj_Organization);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellAddress = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Address = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Address.Text = lcl_obj_ExprienceReader["ADDRESS"].ToString();
                    txt_obj_Address.ID = ("txt_Exp_Address-" + i.ToString());
                    txt_obj_Address.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellAddress.Align = "center";
                    lcl_obj_LD_CellAddress.Controls.Add(txt_obj_Address);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellContact = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Contact = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Contact.Text = lcl_obj_ExprienceReader["CONTACT_NO"].ToString();
                    txt_obj_Contact.ID = ("txt_Exp_ContactNo-" + i.ToString());
                    txt_obj_Contact.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellContact.Align = "center";
                    lcl_obj_LD_CellContact.Controls.Add(txt_obj_Contact);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellNature = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Nature = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Nature.Text = lcl_obj_ExprienceReader["NATURE_OF_JOB"].ToString();
                    txt_obj_Nature.ID = ("txt_Exp_NatureOfJob-" + i.ToString());
                    txt_obj_Nature.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellNature.Align = "center";
                    lcl_obj_LD_CellNature.Controls.Add(txt_obj_Nature);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellResponsibility = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Responsibility = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Responsibility.Text = lcl_obj_ExprienceReader["RESPONSIBILITY"].ToString();
                    txt_obj_Responsibility.ID = ("txt_Exp_Responsibility-" + i.ToString());
                    txt_obj_Responsibility.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellResponsibility.Align = "center";
                    lcl_obj_LD_CellResponsibility.Controls.Add(txt_obj_Responsibility);

                   

                    



                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellDateto = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Dateto = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Dateto.Text = String.Format("{0:MM/dd/yyyy}", lcl_obj_ExprienceReader["TO_DATE"]);
                    txt_obj_Dateto.ID = ("txt_Exp_DateTo-" + i.ToString());
                    txt_obj_Dateto.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellDateto.Align = "center";
                    lcl_obj_LD_CellDateto.Controls.Add(txt_obj_Dateto);


                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellDatefrom = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.TextBox txt_obj_Datefrom = new System.Web.UI.WebControls.TextBox();
                    txt_obj_Datefrom.Text = String.Format("{0:MM/dd/yyyy}", lcl_obj_ExprienceReader["FROM_DATE"]);
                    txt_obj_Datefrom.ID = ("txt_Exp_DateFrom-" + i.ToString());
                    txt_obj_Datefrom.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellDatefrom.Align = "center";
                    lcl_obj_LD_CellDatefrom.Controls.Add(txt_obj_Datefrom);

                    System.Web.UI.HtmlControls.HtmlTableCell lcl_obj_LD_CellCode = new System.Web.UI.HtmlControls.HtmlTableCell();
                    System.Web.UI.WebControls.HiddenField txt_obj_RefCode = new System.Web.UI.WebControls.HiddenField();
                    txt_obj_RefCode.Value = lcl_obj_ExprienceReader["EXPERIENCE_CODE"].ToString();
                    txt_obj_RefCode.ID = ("txt_Exp_CODE-" + i.ToString());
                    txt_obj_RefCode.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                    lcl_obj_LD_CellCode.Align = "center";
                    lcl_obj_LD_CellCode.Controls.Add(txt_obj_RefCode);

                    //lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_check);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellOrganization);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellAddress);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellResponsibility);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellNature);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellContact);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellDateto);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellDatefrom);
                    lcl_obj_LD_Row.Cells.Add(lcl_obj_LD_CellCode);

                    this.tblExperience.Rows.Add(lcl_obj_LD_Row);
                    i++;
                    j++;

                }

                txtExperienceCount.Value = j.ToString();

                lcl_obj_SqlFacade.CloseReader();
                }


                //show REFERENCE

                lcl_str_SqlQuery = System.String.Format(@"select REFERENCE_CODE,NAME,ADDRESS,CONTACT_NO,DESIGNATION,COMPANY_ORGANIZATION
                                                 ,EMPLOYEE_CODE from EMPLOYEE_REFERENCE where Employee_code={0}", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_REFERENCEReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_REFERENCEReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Exprience Information Not Found!!!");
                
               

                while (lcl_obj_REFERENCEReader.Read())
                {
                    if (chk_Ref_Reference_1.Checked == false)
                    {
                        txtref1.Value = lcl_obj_REFERENCEReader["REFERENCE_CODE"].ToString();
                        txt_Ref_Name1.Text = lcl_obj_REFERENCEReader["NAME"].ToString();
                        txt_Ref_Address1.Text = lcl_obj_REFERENCEReader["ADDRESS"].ToString();
                        txt_Ref_ContactNo1.Text = lcl_obj_REFERENCEReader["CONTACT_NO"].ToString();
                        txt_Ref_Organization1.Text = lcl_obj_REFERENCEReader["COMPANY_ORGANIZATION"].ToString();
                        txt_Ref_Designation1.Text = lcl_obj_REFERENCEReader["DESIGNATION"].ToString();

                        chk_Ref_Reference_1.Checked = true;
                    }
                    else if( chk_Ref_Reference_2.Checked == false)
                    {
                        txtref2.Value = lcl_obj_REFERENCEReader["REFERENCE_CODE"].ToString();
                        txt_Ref_Name2.Text = lcl_obj_REFERENCEReader["NAME"].ToString();
                        txt_Ref_Address2.Text = lcl_obj_REFERENCEReader["ADDRESS"].ToString();
                        txt_Ref_ContactNo2.Text = lcl_obj_REFERENCEReader["CONTACT_NO"].ToString();
                        txt_Ref_Organization2.Text = lcl_obj_REFERENCEReader["COMPANY_ORGANIZATION"].ToString();
                        txt_Ref_Designation2.Text = lcl_obj_REFERENCEReader["DESIGNATION"].ToString();
                        chk_Ref_Reference_2.Checked = true;
                    }

                }

                }

                lcl_obj_SqlFacade.CloseReader();

                //certificate show
                DataTable dtCertificates = new DataTable();
                dtCertificates.Columns.Add("FileName", typeof(string));
                dtCertificates.Columns.Add("EmployeeCertificateCode", typeof(long));
                dtCertificates.Columns.Add("FileSize", typeof(long));
                dtCertificates.Columns.Add("FileType", typeof(string));

                // SQL Query
                string lcl_str_certificateQuery = @"SELECT employee_certificate_code, certificate, employee_code, file_size, file_type, is_deleted, status, File_Name 
                                                                  FROM employee_certificate
                                                                  WHERE employee_code = " + lcl_ui64_EmployeeCode;

                // Execute reader
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_certificateReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_certificateQuery);

                if (lcl_obj_certificateReader.HasRows)
                {
                    while (lcl_obj_certificateReader.Read())
                    {
                        DataRow dr = dtCertificates.NewRow();
                        dr["FileName"] = lcl_obj_certificateReader["File_Name"].ToString();
                        dr["EmployeeCertificateCode"] = Convert.ToInt64(lcl_obj_certificateReader["employee_certificate_code"]);
                        dr["FileSize"] = Convert.ToInt64(lcl_obj_certificateReader["file_size"]);
                        dr["FileType"] = lcl_obj_certificateReader["file_type"].ToString();

                        dtCertificates.Rows.Add(dr);
                    }
                }

                // Bind to GridView
                gvCertificates.DataSource = dtCertificates;
                gvCertificates.DataBind();

                // Close reader
                lcl_obj_SqlFacade.CloseReader();

                lcl_obj_SqlFacade.Close();

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void txt_Ref_Organization2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnDownload_Command(object sender, CommandEventArgs e)
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();

            if (e.CommandName == "Download")
            {
                string fileName = e.CommandArgument.ToString();

                // Fetch the certificate from the database
                string lcl_str_certificateQuery = @"SELECT certificate, file_type FROM employee_certificate WHERE file_name = :FileName";

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_certificateReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_certificateQuery);

                    if (lcl_obj_certificateReader.HasRows)
                    {
                        lcl_obj_certificateReader.Read();

                        byte[] certificateData = (byte[])lcl_obj_certificateReader["certificate"];
                        string fileType = lcl_obj_certificateReader["file_type"].ToString();

                        // Send the file as a download
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = fileType;
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.BinaryWrite(certificateData);
                        Response.End();
                    }

            }
        }
    }
}