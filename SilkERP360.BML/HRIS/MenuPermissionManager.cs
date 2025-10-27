using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class MenuPermissionManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>
    {
        public MenuPermissionManager()
        {
            this.Initialize();
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_MenuPermissionCode = 0;

            lcl_ui64_MenuPermissionCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_MenuPermission.Validate() == false)
                {
                    System.Text.StringBuilder lcl_objSB_Msg = new System.Text.StringBuilder();
                    SilkERP360.CCL.Validation.Collections.ValidationErrorCollection lcl_obj_ValidationErrors = lcl_obj_MenuPermission.ValidationErrorsCollection;
                    foreach (SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError lcl_obj_ValidationError in lcl_obj_ValidationErrors)
                    {
                        lcl_objSB_Msg.Append(lcl_obj_ValidationError.ErrorMessage);
                        lcl_objSB_Msg.Append("<br/>");
                    }
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_objSB_Msg.ToString());
                }
                System.Data.OracleClient.OracleParameter lcl_obj_UserModuleMenusCode = new System.Data.OracleClient.OracleParameter("v_UserModuleMenusCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_UserModuleMenusCode.Direction = System.Data.ParameterDirection.Output;
                lcl_obj_UserModuleMenusCode.Value = lcl_obj_MenuPermission.UserModuleMenusCode;

                System.Data.OracleClient.OracleParameter lcl_obj_ModuleCode = new System.Data.OracleClient.OracleParameter("v_ModuleCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ModuleCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ModuleCode.Value = lcl_obj_MenuPermission.ModuleCode;

                System.Data.OracleClient.OracleParameter lcl_obj_UserCode = new System.Data.OracleClient.OracleParameter("v_UserCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_UserCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_UserCode.Value = lcl_obj_MenuPermission.UserCode;

                System.Data.OracleClient.OracleParameter lcl_obj_MenuCode = new System.Data.OracleClient.OracleParameter("v_MenuCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_MenuCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MenuCode.Value = lcl_obj_MenuPermission.MenuCode;                         

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_MenuPermission.IsDeleted;

                System.Data.OracleClient.OracleParameter lcl_obj_status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
                lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_status.Value = lcl_obj_MenuPermission.Status;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_UserModuleMenusCode, lcl_obj_ModuleCode, lcl_obj_UserCode, lcl_obj_MenuCode, lcl_obj_IsDeleted, lcl_obj_status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_USER_MODULES_MENUS", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_UserModuleMenusCode.Value.ToString());
            }, "BMLExceptionPolicy");

            return lcl_ui64_MenuPermissionCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission)
       {
          System.UInt64 lcl_ui64_MenuPermissionCode = 0;

           lcl_ui64_MenuPermissionCode = this.ExceptionManager.Process<System.UInt64>(() =>
               {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_UserModuleMenusCode = new System.Data.OracleClient.OracleParameter("v_UserModuleMenusCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_UserModuleMenusCode.Direction = System.Data.ParameterDirection.Output;
                lcl_obj_UserModuleMenusCode.Value = lcl_obj_MenuPermission.UserModuleMenusCode;

                System.Data.OracleClient.OracleParameter lcl_obj_ModuleCode = new System.Data.OracleClient.OracleParameter("v_ModuleCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ModuleCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ModuleCode.Value = lcl_obj_MenuPermission.ModuleCode;

                System.Data.OracleClient.OracleParameter lcl_obj_UserCode = new System.Data.OracleClient.OracleParameter("v_UserCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_UserCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_UserCode.Value = lcl_obj_MenuPermission.UserCode;

                System.Data.OracleClient.OracleParameter lcl_obj_MenuCode = new System.Data.OracleClient.OracleParameter("v_MenuCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_MenuCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_MenuCode.Value = lcl_obj_MenuPermission.MenuCode;                         

                System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IsDeleted", System.Data.OracleClient.OracleType.Number);
                lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_IsDeleted.Value = lcl_obj_MenuPermission.IsDeleted;

                System.Data.OracleClient.OracleParameter lcl_obj_status = new System.Data.OracleClient.OracleParameter("v_Status", System.Data.OracleClient.OracleType.Number);
                lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_status.Value = lcl_obj_MenuPermission.Status;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_UserModuleMenusCode, lcl_obj_ModuleCode, lcl_obj_UserCode, lcl_obj_MenuCode, lcl_obj_IsDeleted, lcl_obj_status };
                lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_USER_MODULES_MENUS", lcl_obj_SP_Parameters);

                lcl_obj_DBManager.InternalResource.CommitTransaction();
                lcl_obj_DBManager.InternalResource.Close();

                return System.UInt64.Parse(lcl_obj_UserModuleMenusCode.Value.ToString());
                }
               }, "BMLExceptionPolicy");

           return lcl_ui64_MenuPermissionCode;
        }

        public object Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission = null;

            lcl_obj_MenuPermission = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From USER_MODULE_MENUS Where USER_MODULE_MENUS_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_MenuPermissionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_MenuPermissionReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error CompanyManager.Get(USER_MODULE_MENUS_CODE,DBManger)) : Error Retrieving USER_MODULE_MENUS Data!");
                }
                lcl_obj_MenuPermissionReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermissionTmp = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                lcl_obj_MenuPermissionTmp.UserModuleMenusCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["USER_MODULE_MENUS_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.ModuleCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["MODULE_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.UserCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["USER_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.MenuCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["MENU_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.IsDeleted = System.UInt16.Parse(lcl_obj_MenuPermissionReader["IS_DELETED"].ToString());
                lcl_obj_MenuPermissionTmp.Status = System.UInt16.Parse(lcl_obj_MenuPermissionReader["STATUS"].ToString());

                lcl_obj_MenuPermissionReader.Close();
                return lcl_obj_MenuPermissionTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_MenuPermission;
        }

        public CCL.BusinessEntities.HRIS.MenuPermission Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission = null;
            lcl_obj_MenuPermission = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>(() =>
             {
                 using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                 {
                     if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                     {
                         lcl_obj_DBManager.InternalResource.Open();
                     }
                     System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From USER_MODULE_MENUS Where USER_MODULE_MENUS_CODE = {0} and STATUS = {1} IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                     if (!(dr.HasRows))
                     {
                         throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (MenuPermissionManager.Get(ID)) : No USER_MODULE_MENUS Data Found In The Database!!!");
                     }
                     SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermissionTmp = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                     lcl_obj_MenuPermissionTmp.UserModuleMenusCode = System.UInt64.Parse(dr["USER_MODULE_MENUS_CODE"].ToString());
                     lcl_obj_MenuPermissionTmp.ModuleCode = System.UInt64.Parse(dr["MODULE_CODE"].ToString());
                     lcl_obj_MenuPermissionTmp.UserCode = System.UInt64.Parse(dr["USER_CODE"].ToString());
                     lcl_obj_MenuPermissionTmp.MenuCode = System.UInt64.Parse(dr["MENU_CODE"].ToString());
                     lcl_obj_MenuPermissionTmp.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                     lcl_obj_MenuPermissionTmp.Status = System.UInt16.Parse(dr["STATUS"].ToString());

                     dr.Close();
                     return lcl_obj_MenuPermissionTmp;
                 }
             }, "BMLExceptionPolicy");
            return lcl_obj_MenuPermission;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_objLst_MenuPermission = null;

            lcl_objLst_MenuPermission = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (MenuPermissionManager.GetList(SqlQuery,DBManager)) : No USER_MODULE_MENUS Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_objLst_MenuPermissionTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                    lcl_obj_MenuPermission.UserModuleMenusCode = System.UInt64.Parse(dr["USER_MODULE_MENUS_CODE"].ToString());
                    lcl_obj_MenuPermission.ModuleCode = System.UInt64.Parse(dr["MODULE_CODE"].ToString());
                    lcl_obj_MenuPermission.UserCode = System.UInt64.Parse(dr["USER_CODE"].ToString());
                    lcl_obj_MenuPermission.MenuCode = System.UInt64.Parse(dr["MENU_CODE"].ToString());
                    lcl_obj_MenuPermission.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                    lcl_obj_MenuPermission.Status = System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_objLst_MenuPermissionTmp.Add(lcl_obj_MenuPermission);
                }
                dr.Close();
                return lcl_objLst_MenuPermissionTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_MenuPermission;
        }

      
        public CCL.BusinessEntities.HRIS.MenuPermission Get(string IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission = null;

            lcl_obj_MenuPermission = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_MenuPermissionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_MenuPermissionReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error MenuPermissionManager.Get(SqlQuery,DBManger)) : Error Retrieving USER_MODULE_MENUS Data!");
                }
                lcl_obj_MenuPermissionReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermissionTmp = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                lcl_obj_MenuPermissionTmp.UserModuleMenusCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["USER_MODULE_MENUS_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.ModuleCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["MODULE_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.UserCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["USER_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.MenuCode = System.UInt64.Parse(lcl_obj_MenuPermissionReader["MENU_CODE"].ToString());
                lcl_obj_MenuPermissionTmp.IsDeleted = System.UInt16.Parse(lcl_obj_MenuPermissionReader["IS_DELETED"].ToString());
                lcl_obj_MenuPermissionTmp.Status = System.UInt16.Parse(lcl_obj_MenuPermissionReader["STATUS"].ToString());

                lcl_obj_MenuPermissionReader.Close();
                return lcl_obj_MenuPermissionTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_MenuPermission;
        }

        public CCL.BusinessEntities.HRIS.MenuPermission Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermission = null;
            lcl_obj_MenuPermission = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (MenuPermissionManager.Get(SqlQuery)) : No USER_MODULE_MENUS Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_MenuPermissionTmp = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                    lcl_obj_MenuPermissionTmp.UserModuleMenusCode = System.UInt64.Parse(dr["USER_MODULE_MENUS_CODE"].ToString());
                    lcl_obj_MenuPermissionTmp.ModuleCode = System.UInt64.Parse(dr["MODULE_CODE"].ToString());
                    lcl_obj_MenuPermissionTmp.UserCode = System.UInt64.Parse(dr["USER_CODE"].ToString());
                    lcl_obj_MenuPermissionTmp.MenuCode = System.UInt64.Parse(dr["MENU_CODE"].ToString());
                    lcl_obj_MenuPermissionTmp.IsDeleted = System.UInt16.Parse(dr["IS_DELETED"].ToString());
                    lcl_obj_MenuPermissionTmp.Status = System.UInt16.Parse(dr["STATUS"].ToString());

                    dr.Close();
                    return lcl_obj_MenuPermissionTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_MenuPermission;
        }


        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_objlist_MenuPermission = null;
            lcl_objlist_MenuPermission = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (MenuPermission.GetList(SqlQuery)) : No MenuPermission Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.MenuPermission();
                        lcl_obj_Tmp.MenuCode = System.UInt64.Parse(lcl_obj_dr["menu_code"].ToString());
                        lcl_obj_Tmp.MenuName = lcl_obj_dr["menu_name"].ToString();
                        lcl_obj_Tmp.MenuType = lcl_obj_dr["ManuType"].ToString();
                        lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["Status"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_MenuPermission;
        }



        //Add Menu
        public ulong AddMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = 0;
            lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                using (var lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource)
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format(@"insert into USER_MODULE_MENUS(MODULE_CODE,USER_CODE,MENU_CODE,IS_DELETED,STATUS) Values({0},{2},{1},1,1)", IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                    lcl_obj_DBManager.ExecuteNonQuery(lcl_str_SqlQuery);

                    lcl_obj_DBManager.CommitTransaction();
                    lcl_obj_DBManager.Close();

                    return lcl_ui64_ModuleCode;

                }

            }, "BMLExceptionPolicy");

            return lcl_ui64_ModuleCode;
        }

        // Remove Menu
        public ulong RemoveMenu(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_MenuCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_ModuleCode = 0;
            lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                using (var lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource)
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format(@"Delete From  USER_MODULE_MENUS  Where MODULE_CODE={0} AND MENU_CODE={1} And USER_CODE={2}", IP_ui64_ModuleCode, IP_ui64_MenuCode, IP_ui64_EmployeeCode);
                    lcl_obj_DBManager.ExecuteNonQuery(lcl_str_SqlQuery);

                    lcl_obj_DBManager.CommitTransaction();
                    lcl_obj_DBManager.Close();

                    return lcl_ui64_ModuleCode;

                }

            }, "BMLExceptionPolicy");

            return lcl_ui64_ModuleCode;
        }

        public ulong SaveMenuPermissionList(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode, List<MenuPermissionItem> menuList)
        {
            return this.ExceptionManager.Process<ulong>(() =>
            {
                using (var dbManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource)
                {
                    if (dbManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        dbManager.Open();  // Opens connection and begins transaction
                    }

                    foreach (var item in menuList)
                    {
                        string sql;

                        if (item.IsChecked)
                        {
                            sql = string.Format(
                                @"INSERT INTO USER_MODULE_MENUS (MODULE_CODE, USER_CODE, MENU_CODE, IS_DELETED, STATUS) VALUES ({0}, {2}, {1}, 1, 1)",IP_ui64_ModuleCode, item.MenuCode, IP_ui64_EmployeeCode);
                        }
                        else
                        {
                            sql = string.Format(
                                @"DELETE FROM USER_MODULE_MENUS WHERE MODULE_CODE = {0} AND MENU_CODE = {1} AND USER_CODE = {2}",IP_ui64_ModuleCode, item.MenuCode, IP_ui64_EmployeeCode
                            );
                        }

                        dbManager.ExecuteNonQuery(sql);
                    }

                    dbManager.CommitTransaction();
                    dbManager.Close();

                    return IP_ui64_ModuleCode;
                }

            }, "BMLExceptionPolicy");
        }



        CCL.BusinessEntities.HRIS.MenuPermission CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.MenuPermission Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Save(CCL.BusinessEntities.HRIS.MenuPermission IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        ulong CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Save(CCL.BusinessEntities.HRIS.MenuPermission IP_obj_A)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.MenuPermission CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.MenuPermission CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.MenuPermission CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.MenuPermission> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.MenuPermission>.GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }
    }
}
