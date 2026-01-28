using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SilkERP360.UI.HRIS
{
    public partial class SalaryAdditionDeduction : SilkERP360.UI.Base.SilkWebUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          this.Initialize();
            this.ExceptionManager.Process(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Empty;
                System.String lcl_str_EmployeeCode = this.Session["emp_c"].ToString();
                if (lcl_str_EmployeeCode.Trim().Length == 0)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Required EmployeeCode Could Not Be Retrieved From Session!");
                }
                this.Session.Remove("emp_c");
                System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_str_EmployeeCode);
             
                System.UInt64 lcl_ui64_DepartmentCode = 0;
                System.UInt64 lcl_ui64_CompanyCode = 0;
                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();

                //Image show
                lcl_str_SqlQuery = System.String.Format(@"select image,image_type,image_size from employee_image where employee_code={0} ", lcl_ui64_EmployeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IamgeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_IamgeReader.HasRows))
                {
                    //throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Image Not Found!!!");

                    //lcl_i32_j = 1;
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
                        //txt_EI_ImageSize.Text = lcl_obj_IamgeReader["image_size"].ToString();
                        //txt_EI_ImageType.Text = lcl_obj_IamgeReader["image_type"].ToString();
                        string data = "data:" + lcl_obj_IamgeReader["image_type"].ToString() + ";base64,";
                        lcl_obj_ImageItem.ImageUrl = data + Convert.ToBase64String(photoByte);

                        imgEmployeeImage.ImageUrl = data + Convert.ToBase64String(photoByte);
                    }
                    lcl_obj_SqlFacade.CloseReader();
                }

                //Load Employee Information
               // System.String lcl_str_SqlQuery = System.String.Empty;
                lcl_str_SqlQuery = System.String.Format(@"Select EMPLOYEE_ID,EMPLOYEE_NAME,To_char(JOINING_DATE,'DD-Mon-yyyy')JOINING_DATE,c.COMPANY_CODE,c.name As Company,ds.degn_name,DEPT_NAME, e.department_code 
                from employee E inner join COMPANY C On e.company_code=c.company_code
                inner join DESIGNATION DS on E.DESIGNATION_CODE=ds.designation_code
                Inner join DEPARTMENT Dp on  e.department_code=dp.DEPARTMENT_CODE
                where employee_code={0}", lcl_ui64_EmployeeCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeInfoReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if (!(lcl_obj_EmployeeInfoReader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("Employee information Was Not Found!!!");
                }

                lcl_obj_EmployeeInfoReader.Read();
                txt_EmpID.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_ID"].ToString();
                txt_Sal_AddDed_EmpName.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_NAME"].ToString();
                txt_Sal_AddDed_Department.Text = lcl_obj_EmployeeInfoReader["DEPT_NAME"].ToString();
                txt_Sal_AddDed_Designation.Text = lcl_obj_EmployeeInfoReader["degn_name"].ToString();               
                lcl_ui64_DepartmentCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["department_code"].ToString());
                lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_obj_EmployeeInfoReader["COMPANY_CODE"].ToString());

                System.Text.StringBuilder lcl_obj_HTMLBuilder = new System.Text.StringBuilder();
                lcl_obj_HTMLBuilder.Append("var gbl_ui64_EmployeeCode = ");
                lcl_obj_HTMLBuilder.Append(lcl_str_EmployeeCode);
                lcl_obj_HTMLBuilder.Append(" ;");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "EMP_CODE", lcl_obj_HTMLBuilder.ToString(), true);
                lcl_obj_HTMLBuilder.Clear();

                lcl_obj_SqlFacade.CloseReader();


                /****************************************************************************************************/
              //  Salary Addition Config               

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem1 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem1.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionArrear).ToString();
                lcl_obj_AdditionItem1.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionArrear.ToString();
                this.ddl_sal_Addition.Items.Insert(1, lcl_obj_AdditionItem1);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem2 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem2.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionBonus).ToString();
                lcl_obj_AdditionItem2.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionBonus.ToString();
                this.ddl_sal_Addition.Items.Insert(2, lcl_obj_AdditionItem2);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem3 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem3.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionPhoneBill).ToString();
                lcl_obj_AdditionItem3.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionPhoneBill.ToString();
                this.ddl_sal_Addition.Items.Insert(3, lcl_obj_AdditionItem3);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem4 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem4.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionIncentive).ToString();
                lcl_obj_AdditionItem4.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionIncentive.ToString();
                this.ddl_sal_Addition.Items.Insert(4, lcl_obj_AdditionItem4);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem5 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem5.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance).ToString();
                lcl_obj_AdditionItem5.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionAllowance.ToString();
                this.ddl_sal_Addition.Items.Insert(5, lcl_obj_AdditionItem5);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem6 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem6.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionOthers).ToString();
                lcl_obj_AdditionItem6.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionOthers.ToString();
                this.ddl_sal_Addition.Items.Insert(6, lcl_obj_AdditionItem6);

                System.Web.UI.WebControls.ListItem lcl_obj_AdditionItem7 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_AdditionItem7.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.AdditionNightAllowance).ToString();
                lcl_obj_AdditionItem7.Text = SilkERP360.CCL.Enums.AdditionDeductionType.AdditionNightAllowance.ToString();
                this.ddl_sal_Addition.Items.Insert(7, lcl_obj_AdditionItem7);

                //  Salary Deduction Config

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem1 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem1.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAdvance).ToString();
                lcl_obj_DeductionItem1.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAdvance.ToString();
                this.ddl_sal_Deduction.Items.Insert(1, lcl_obj_DeductionItem1);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem2 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem2.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionPenalty).ToString();
                lcl_obj_DeductionItem2.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionPenalty.ToString();
                this.ddl_sal_Deduction.Items.Insert(2, lcl_obj_DeductionItem2);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem3 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem3.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionIncomeTax).ToString();
                lcl_obj_DeductionItem3.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionIncomeTax.ToString();
                lcl_obj_DeductionItem3.Enabled = false;
                this.ddl_sal_Deduction.Items.Insert(3, lcl_obj_DeductionItem3);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem4 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem4.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionLate).ToString();
                lcl_obj_DeductionItem4.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionLate.ToString();
                this.ddl_sal_Deduction.Items.Insert(4, lcl_obj_DeductionItem4);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem5 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem5.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionUnpaidLeave).ToString();
                lcl_obj_DeductionItem5.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionUnpaidLeave.ToString();
                lcl_obj_DeductionItem5.Enabled = false;
                this.ddl_sal_Deduction.Items.Insert(5, lcl_obj_DeductionItem5);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem6 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem6.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAbsent).ToString();
                lcl_obj_DeductionItem6.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionAbsent.ToString();
                this.ddl_sal_Deduction.Items.Insert(6, lcl_obj_DeductionItem6);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem7 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem7.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionOthers).ToString();
                lcl_obj_DeductionItem7.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionOthers.ToString();
                this.ddl_sal_Deduction.Items.Insert(7, lcl_obj_DeductionItem7);

                System.Web.UI.WebControls.ListItem lcl_obj_DeductionItem8 = new System.Web.UI.WebControls.ListItem();
                lcl_obj_DeductionItem8.Value = ((System.Int32)SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund).ToString();
                lcl_obj_DeductionItem8.Text = SilkERP360.CCL.Enums.AdditionDeductionType.DeductionProvidentFund.ToString();
                this.ddl_sal_Deduction.Items.Insert(8, lcl_obj_DeductionItem8);
                /****************************************************************************************************/

            }, "UIExceptionPolicy");
        }
    }
}