using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.UI
{
    public class UserManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public UserManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }

        public System.Boolean ChangePassword(System.String IP_str_UserName, System.String IP_str_NewPassword)
        {
            System.Boolean lcl_b_PasswordChanged = false;
            lcl_b_PasswordChanged = this.ExceptionManager.Process<System.Boolean>(() =>
            {
                //SilkERP360.DAL.DBManager lcl_obj_DBManager = new DAL.DBManager(
                //get the permitted modules
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    lcl_obj_DBManager.InternalResource.Initialize();
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Update Users Set Password = '{0}' Where User_Name = '{1}'", IP_str_NewPassword,IP_str_UserName );
                    System.Object lcl_obj_Response = lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    if (System.UInt32.Parse(lcl_obj_Response.ToString()) == 0)
                    {
                        //password change failed
                        return false;
                    }
                    
                }
                //password change succedded
                return true;
            }, "BMLExceptionPolicy");
            return lcl_b_PasswordChanged;
        }
        /// <summary>
        /// 1. Gets DBManager object from DALObjectPoolManager
        /// 2. Checks if User is Authentic
        /// </summary>
        /// <param name="IP_str_UserName"></param>
        /// <param name="IP_str_Password"></param>
        /// <param name="OP_ui64_UserCode"></param>
        /// <returns>
        /// 1.If User Authentic, returns true and the UserCode in OP_ui64_UserCode
        /// 2. If Not, returns false and 0 in OP_ui64_UserCode
        /// </returns>
        public System.Boolean Authenticate(System.String IP_str_UserName, System.String IP_str_Password,out System.UInt64 OP_ui64_UserCode)
        {
            System.Boolean lcl_b_Response = false;
            OP_ui64_UserCode = 0;
            System.UInt64 lcl_ui64_UserCode = 0;
            lcl_b_Response= this.ExceptionManager.Process<System.Boolean>(() =>
            {
                //SilkERP360.DAL.DBManager lcl_obj_DBManager = new DAL.DBManager(
                //get the permitted modules
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    lcl_obj_DBManager.InternalResource.Initialize();
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From USERS Where UPPER(USER_NAME) = UPPER('{0}') AND PASSWORD = '{1}' AND STATUS = 1",IP_str_UserName,IP_str_Password);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserDataReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_UserDataReader.HasRows == false)
                    {
                        //Invalid User
                        return false;
                    }
                    lcl_obj_UserDataReader.Read();
                    
                    //User Authenticated, get UserCode
                    lcl_ui64_UserCode = System.UInt64.Parse(lcl_obj_UserDataReader["USER_CODE"].ToString());
                    lcl_obj_UserDataReader.Close();
                    lcl_obj_DBManager.InternalResource.Close();
             }

                return true;

            }, "BMLExceptionPolicy");
            OP_ui64_UserCode = lcl_ui64_UserCode;
            return lcl_b_Response;
        }

       

        /// <summary>
        /// /
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>If Successful returns User object else null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.User getUser(System.UInt64 IP_ui64_UserCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.UI.User lcl_obj_User = null;
            lcl_obj_User = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.User>(() =>
                {
                    SilkERP360.CCL.BusinessEntities.UI.User lcl_obj_UserTmp = new SilkERP360.CCL.BusinessEntities.UI.User();
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From USERS Where USER_CODE = {0} And STATUS = {1} AND IS_DELETED = 1", IP_ui64_UserCode, (System.Int32)SilkERP360.CCL.Enums.Status.Active);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_UserReader.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_UserReader.Read();
                    lcl_obj_UserTmp.UserCode = IP_ui64_UserCode;
                    lcl_obj_UserTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_UserReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_UserTmp.UserName = lcl_obj_UserReader["USER_NAME"].ToString();
                    lcl_obj_UserTmp.Password = lcl_obj_UserReader["PASSWORD"].ToString();
                    lcl_obj_UserTmp.AccessLevel = System.UInt16.Parse(lcl_obj_UserReader["ACCESS_LEVEL"].ToString());
                    return lcl_obj_UserTmp;
                }, "BMLExceptionPolicy");
            return lcl_obj_User;
        }

        /// <summary>
        /// Gets its own DBManager
        /// </summary>
        /// <param name="IP_ui64_UserCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns>If Successful returns User object else null</returns>
        public SilkERP360.CCL.BusinessEntities.UI.User getUser(System.UInt64 IP_ui64_UserCode)
        {
            SilkERP360.CCL.BusinessEntities.UI.User lcl_obj_User = null;
            lcl_obj_User = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.UI.User>(() =>
                {
                    using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                    {
                        SilkERP360.CCL.BusinessEntities.UI.User lcl_obj_UserTmp = new SilkERP360.CCL.BusinessEntities.UI.User();
                        System.String lcl_str_SqlQuery = System.String.Format("Select * From USERS Where USER_CODE = {0} And STATUS = {1}", IP_ui64_UserCode, SilkERP360.CCL.Enums.Status.Active);
                        Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_UserReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                        if (lcl_obj_UserReader.HasRows == false)
                        {
                            return null;
                        }
                        lcl_obj_UserTmp.UserCode = IP_ui64_UserCode;
                        lcl_obj_UserTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_UserReader["EMPLOYEE_CODE"].ToString());
                        lcl_obj_UserTmp.UserName = lcl_obj_UserReader["USER_NAME"].ToString();
                        lcl_obj_UserTmp.Password = lcl_obj_UserReader["PASSWORD"].ToString();
                        lcl_obj_UserTmp.AccessLevel = System.UInt16.Parse(lcl_obj_UserReader["ACCESS_LEVEL"].ToString());
                        return lcl_obj_UserTmp;
                    }
                }, "BMLExceptionPolicy");
            return lcl_obj_User;
        }
    }
}
