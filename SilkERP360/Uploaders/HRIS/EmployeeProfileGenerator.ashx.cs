using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace SilkERP360.Uploaders.HRIS
{
    /// <summary>
    /// Summary description for EmployeeProfileGenerator
    /// </summary>
    public class EmployeeProfileGenerator : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> lcl_objLst_EmployeeProfile = null;
            System.Collections.Generic.List<System.String> lcl_objLst_UploadedEmployeeIds = new List<string>();
            System.Web.Script.Serialization.JavaScriptSerializer lcl_obj_JSonSerializer = null;
            SilkERP360.CCL.Misc.WSResponse lcl_obj_Response = null;

            System.String lcl_str_Message = System.String.Empty;
            System.String lcl_str_SqlQuery = System.String.Empty;
            System.Boolean lcl_b_UploadedFileValid = true;
            try
            {
                context.Response.ContentType = "application/json";
                //context.Response.Write("Hello World");

                System.UInt64 lcl_ui64_CompanyCode = System.UInt64.Parse(context.Request["CompanyCode"].ToString());
                System.UInt64 lcl_ui64_WorkGroupCode = System.UInt64.Parse(context.Request["WorkGroupCode"].ToString());
                System.DateTime lcl_dt_WorkDate = System.DateTime.Parse(context.Request["WorkDate"].ToString());
               

                SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                //lcl_obj_SqlFacade.Initialize();


                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    lcl_obj_JSonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        System.IO.StreamReader lcl_obj_EmployeeFileStreamReader = new StreamReader(file.InputStream, System.Text.Encoding.ASCII);
                        lcl_obj_EmployeeFileStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                        //System.Security.Cryptography.MD5CryptoServiceProvider lcl_obj_CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        //System.String lcl_str_UploadedFileHash = BitConverter.ToString(lcl_obj_CryptoServiceProvider.ComputeHash(lcl_obj_EmployeeFileStreamReader.BaseStream));

                        lcl_obj_EmployeeFileStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);

                        System.String lcl_str_EmployeeFileLine = System.String.Empty;

                        //check if uploaded file contains Production Log data for the Selected Batch
                        System.UInt64 lcl_ui64_RecordNumber = 0;

                        while ((lcl_str_EmployeeFileLine = lcl_obj_EmployeeFileStreamReader.ReadLine()) != null)
                        {
                            lcl_ui64_RecordNumber++;
                            //sort the Record
                            if (lcl_str_EmployeeFileLine.Trim() == "")
                            {
                                continue;
                            }
                            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
                            if (!r.IsMatch(lcl_str_EmployeeFileLine))
                            {
                                //If File line contains anything other than only alpha numeric character
                                //Refuse File

                                lcl_str_Message = System.String.Format("Invalid Characters Found In '{0}'!!!Upload Denied!!!", lcl_str_EmployeeFileLine);
                                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, lcl_str_Message, true, null);
                                context.Response.ContentType = "application/json";
                                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                lcl_b_UploadedFileValid = false;
                                //context.Response.End();
                                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                                break;
                            }
                            if (lcl_objLst_UploadedEmployeeIds.Contains(lcl_str_EmployeeFileLine))
                            {
                                //Filter to eliminate duplicate ids in the list
                                //Refuse File

                                lcl_str_Message = System.String.Format("Invalid File Upload : Employee ID '{0}' Found Multiple Times!!!Upload Denied!!!", lcl_str_EmployeeFileLine);
                                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -2, lcl_str_Message, true, null);
                                context.Response.ContentType = "application/json";
                                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                lcl_b_UploadedFileValid = false;
                                //context.Response.End();
                                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                                break;
                            }
                            lcl_objLst_UploadedEmployeeIds.Add(lcl_str_EmployeeFileLine.ToUpper());
                        }
                        //lcl_objLst_EmployeeProfile = new List<CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
                    }
                }

                System.UInt64 lcl_ui64_EmployeeCode = 0;
                if (lcl_b_UploadedFileValid == true)
                {
                    //Check Uploaded Employee Ids
                    if (lcl_objLst_UploadedEmployeeIds.Count == 0)
                    {
                        //No Valid EmployeeID found in file
                        lcl_str_Message = System.String.Format("Invalid File Upload : No Valid Employee Ids exist in the uploaded file!!!Upload Denied!!!");
                        lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -3, lcl_str_Message, true, null);
                        context.Response.ContentType = "application/json";
                        context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                        //context.Response.End();
                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                        HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                    }
                    else
                    {
                        //Check Each Employee Id
                        foreach (System.String lcl_str_EmployeeId in lcl_objLst_UploadedEmployeeIds)
                        {
                            lcl_str_SqlQuery = System.String.Format("SELECT * FROM EMPLOYEE WHERE EMPLOYEE_ID = '{0}'", lcl_str_EmployeeId);
                            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_EmployeeReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);
                            if (!(lcl_obj_EmployeeReader.HasRows))
                            {
                                //Employee ID does not exist in the database
                                //Refuse File Upload
                                lcl_str_Message = System.String.Format(@"Invalid File Upload : Invalid or Incorrect employee id ('{0}') found in the uploaded file!!!Upload Denied!!!", lcl_str_EmployeeId);
                                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -4, lcl_str_Message, true, null);
                                context.Response.ContentType = "application/json";
                                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                lcl_obj_EmployeeReader.Close();
                                //context.Response.End();
                                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                            }
                            else
                            {
                                //Employee ID exist in the database
                                lcl_obj_EmployeeReader.Read();
                                lcl_ui64_EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeReader["EMPLOYEE_CODE"].ToString());
                                //Check if employee belongs to selected company
                                System.UInt64 lcl_ui64_TmpCompanyCode = System.UInt64.Parse(lcl_obj_EmployeeReader["COMPANY_CODE"].ToString());
                                if (lcl_ui64_TmpCompanyCode != lcl_ui64_CompanyCode)
                                {
                                    lcl_str_Message = System.String.Format("Invalid File Upload : Employee ID '{0}' does not belong to selected company!!!Upload Denied!!!");
                                    lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -5, lcl_str_Message, true, null);
                                    context.Response.ContentType = "application/json";
                                    context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                    lcl_obj_EmployeeReader.Close();
                                    //context.Response.End();
                                    HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                    HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                    HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                                }
                                else
                                {
                                    //check if Employee is active
                                    SilkERP360.CCL.Enums.EmployeeStatus lcl_enm_EmployeeStatus = (SilkERP360.CCL.Enums.EmployeeStatus)System.Int16.Parse(lcl_obj_EmployeeReader["EMPLOYEE_STATUS"].ToString());
                                    if (!((lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Regular) || (lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Probation) || (lcl_enm_EmployeeStatus == CCL.Enums.EmployeeStatus.Temporary)))
                                    {
                                        //Inactive Employee Id found in file
                                        lcl_str_Message = System.String.Format("Invalid File Upload : Employee ID '{0}' has either resigned or terminated!!!Upload Denied!!!", lcl_str_EmployeeId);
                                        lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -6, lcl_str_Message, true, null);
                                        context.Response.ContentType = "application/json";
                                        context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                        lcl_obj_EmployeeReader.Close();
                                        //context.Response.End();
                                        HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                        HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                        HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                                    }
                                    else
                                    {
                                        //EmployeeId ok
                                        lcl_obj_EmployeeReader.Close();
                                        //Check if Employee Id already assigned to a WorkGroup for the particular date
                                        lcl_str_SqlQuery = System.String.Format("SELECT WG_OP_MSTR.*, WG_OP_HSTRY.* " +
                                                                                "FROM WORK_GROUP_OPERATION_MASTER WG_OP_MSTR JOIN WORK_GROUP_OPERATION_HISTORY WG_OP_HSTRY " +
                                                                                "ON WG_OP_MSTR.WG_OPERATION_MASTER_CODE = WG_OP_HSTRY.WG_OPERATION_MASTER_CODE " +
                                                                                "WHERE WG_OP_MSTR.WORK_DATE = TO_DATE('{0}','DD/MM/YYYY') AND WG_OP_HSTRY.EMPLOYEE_CODE = {1}", lcl_dt_WorkDate.ToString("dd/M/yyyy"), lcl_ui64_EmployeeCode);

                                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_WorkGroupOperationReader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);

                                        if (lcl_obj_WorkGroupOperationReader.HasRows)
                                        {
                                            //employee already assigned to a WorkGroup 
                                            lcl_str_Message = System.String.Format("Invalid File Upload : Employee ID '{0}' has already been assigned to another Work Group on '{1}'!!!Upload Denied!!!", lcl_str_EmployeeId, lcl_dt_WorkDate.ToString("dd/M/yyyy"));
                                            lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -7, lcl_str_Message, true, null);
                                            context.Response.ContentType = "application/json";
                                            context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                            lcl_obj_EmployeeReader.Close();
                                            //context.Response.End();
                                            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                            HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                                        }
                                        else
                                        {
                                            lcl_obj_WorkGroupOperationReader.Close();
                                            //File OK and all Employee Ids OK.Get EmployeeProfile for employees
                                        }
                                    }
                                }
                            }
                        }
                        //If control comes to point,All Employee Ids ok.
                        //Generate EmployeeProfile for each uploaded employee
                        System.Text.StringBuilder lcl_obj_EmployeeListBuilder = new System.Text.StringBuilder();
                        foreach (System.String lcl_str_EmployeeId in lcl_objLst_UploadedEmployeeIds)
                        {
                            if (lcl_obj_EmployeeListBuilder.Length > 0)
                            {
                                lcl_obj_EmployeeListBuilder.Append(",");
                            }
                            lcl_obj_EmployeeListBuilder.Append("'");
                            lcl_obj_EmployeeListBuilder.Append(lcl_str_EmployeeId);
                            lcl_obj_EmployeeListBuilder.Append("'");
                        }
                        lcl_str_SqlQuery = System.String.Format(@"SELECT EMP.*,COMP.COMPANY_CODE,COMP.NAME,DEPT.DEPARTMENT_CODE,
                                                                        DEPT.DEPT_NAME,DESIG.DESIGNATION_CODE,DESIG.DEGN_NAME,EMP_SAL.GROSS
                                                                        FROM EMPLOYEE EMP 
                                                                        JOIN COMPANY COMP
                                                                        ON EMP.COMPANY_CODE = COMP.COMPANY_CODE
                                                                        JOIN DEPARTMENT DEPT
                                                                        ON EMP.DEPARTMENT_CODE = DEPT.DEPARTMENT_CODE
                                                                        JOIN DESIGNATION DESIG
                                                                        ON EMP.DESIGNATION_CODE = DESIG.DESIGNATION_CODE
                                                                        JOIN EMPLOYEE_SALARY_STRUCTURE EMP_SAL
                                                                        ON EMP.EMPLOYEE_CODE = EMP_SAL.EMPLOYEE_CODE
                                                                        WHERE EMP.EMPLOYEE_ID IN ({0})", lcl_obj_EmployeeListBuilder.ToString());
                        SilkERP360.FL.HRIS.DataStructures.EmployeeProfileFacade lcl_obj_EmployeeProfileFacade = new FL.HRIS.DataStructures.EmployeeProfileFacade();
                        lcl_objLst_EmployeeProfile = lcl_obj_EmployeeProfileFacade.GetListWithoutImage(lcl_str_SqlQuery);
                        if ((lcl_objLst_EmployeeProfile.Count == 0) || (lcl_objLst_EmployeeProfile == null))
                        {
                            //Found no Employee Profile for uploaded employees
                            lcl_str_Message = System.String.Format("Invalid File Upload : 'EmployeeProfile' could not be found for uploaded employees!!!Upload denied!!!");
                            lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -8, lcl_str_Message, true, null);
                            context.Response.ContentType = "application/json";
                            context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                            //context.Response.End();
                            HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                            HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                            HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                        }
                        else
                        {
                            if (lcl_objLst_EmployeeProfile.Count != lcl_objLst_UploadedEmployeeIds.Count)
                            {
                                //EmployeeProfile of all uploaded employees were not found. Some found & Some was not
                                lcl_str_Message = System.String.Format("Invalid File Upload : 'EmployeeProfile' for all uploaded employees was not found. Uploaded Employee Count {0} | Found Profile Count {1}.!!!Upload Denied!!!", lcl_objLst_UploadedEmployeeIds.Count, lcl_objLst_EmployeeProfile.Count);
                                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -9, lcl_str_Message, true, null);
                                context.Response.ContentType = "application/json";
                                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                //context.Response.End();
                                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                            }
                            else
                            {
                                //ALL OK. ALL PROFILE FOUND
                                lcl_str_Message = System.String.Format("Upload Success : Uploaded File Verified and Employee Profile Included!!!");
                                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, lcl_str_Message, true, lcl_objLst_EmployeeProfile);
                                context.Response.ContentType = "application/json";
                                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                                //context.Response.End();
                                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
                            }
                        }

                    }
                }
            }
            catch (System.Exception Ex)
            {
                lcl_str_Message = System.String.Format("Fatal System Error : '{0}'!!!CONTACT R&D INSTANTLY!!!",Ex.Message);
                lcl_obj_Response = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, lcl_str_Message, true, null);
                context.Response.Write(lcl_obj_JSonSerializer.Serialize(lcl_obj_Response));
                HttpContext.Current.Response.Flush(); // Sends all currently buffered output to the client.
                HttpContext.Current.Response.SuppressContent = true;  // Gets or sets a value indicating whether to send HTTP content to the client.
                HttpContext.Current.ApplicationInstance.CompleteRequest(); 
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}