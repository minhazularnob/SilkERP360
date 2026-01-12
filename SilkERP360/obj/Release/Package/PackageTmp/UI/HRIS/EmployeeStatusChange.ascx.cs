using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SilkERP360.UI.HRIS
{
    public partial class EmployeeStatusChange : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

         try
            {
                System.String lcl_str_SqlQuery = System.String.Empty;
                System.String lcl_str_CompanyCode = this.Session["comp_c"].ToString();
                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(lcl_str_CompanyCode);
                this.Session.Remove("comp_c");

                System.String lcl_str_EmployeeCode = this.Session["Emp_c"].ToString();
                System.UInt64 lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_str_EmployeeCode);
                System.UInt16 lcl_ui16_currentStatuc=0;
                this.Session.Remove("Emp_c");


                System.Text.StringBuilder lcl_obj_HTMLBuilder = new System.Text.StringBuilder();
                lcl_obj_HTMLBuilder.Append("var gbl_ui64_EmployeeCode = ");
                lcl_obj_HTMLBuilder.Append(lcl_str_EmployeeCode);
                lcl_obj_HTMLBuilder.Append(" ;");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "EMP_CODE", lcl_obj_HTMLBuilder.ToString(), true);
                lcl_obj_HTMLBuilder.Clear();

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

                //Show Personal Information
                lcl_str_SqlQuery = System.String.Format(@"select EMPLOYEE_ID,employee_name,d.degn_name,dp.DEPT_NAME,EMPLOYEE_STATUS,c.name From employee E 
inner join DESIGNATION D on e.designation_code=d.designation_code
inner join DEPARTMENT Dp on e.department_code=dp.department_code
inner join COMPANY C on e.company_code=c.company_code
where EMPLOYEE_CODE = {0} ", lcl_ui64_EmployeeCode);

                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeInfoReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                if ((lcl_obj_EmployeeInfoReader.HasRows))
                {


                    lcl_obj_EmployeeInfoReader.Read();

                    txt_emp_ID.Text = lcl_obj_EmployeeInfoReader["EMPLOYEE_ID"].ToString();
                    txt_emp_Name.Text = lcl_obj_EmployeeInfoReader["employee_name"].ToString();
                    txt_Designation.Text = lcl_obj_EmployeeInfoReader["degn_name"].ToString();
                    txt_Department.Text = lcl_obj_EmployeeInfoReader["DEPT_NAME"].ToString();
                    lcl_ui16_currentStatuc = System.UInt16.Parse(lcl_obj_EmployeeInfoReader["EMPLOYEE_STATUS"].ToString());
                    txt_Currnt_status.Text = ((SilkERP360.CCL.Enums.EmployeeStatus)System.UInt16.Parse(lcl_obj_EmployeeInfoReader["EMPLOYEE_STATUS"].ToString())).ToString();                                       
                    lcl_obj_SqlFacade.CloseReader();
                }

                System.Text.StringBuilder lcl_obj_HTMLBuilderCStatus = new System.Text.StringBuilder();
                lcl_obj_HTMLBuilderCStatus.Append("var gbl_ui16_CurrentStatus = ");
                lcl_obj_HTMLBuilderCStatus.Append(lcl_ui16_currentStatuc);
                lcl_obj_HTMLBuilderCStatus.Append(" ;");
                System.Web.UI.ScriptManager.RegisterStartupScript(this, this.GetType(), "Current_EmpStatus", lcl_obj_HTMLBuilderCStatus.ToString(), true);
                lcl_obj_HTMLBuilder.Clear();

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }

        }


    }
}