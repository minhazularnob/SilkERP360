using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class ModuleManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Module>
    {
       public ModuleManager()
       {
           this.Initialize();
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Module lcl_obj_Module, System.Object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ModuleCode = 0;

           lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_Module.Validate() == false)
               {
                   System.Text.StringBuilder lcl_objSB_Msg = new System.Text.StringBuilder();
                   SilkERP360.CCL.Validation.Collections.ValidationErrorCollection lcl_obj_ValidationErrors = lcl_obj_Module.ValidationErrorsCollection;
                   foreach (SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError lcl_obj_ValidationError in lcl_obj_ValidationErrors)
                   {
                       lcl_objSB_Msg.Append(lcl_obj_ValidationError.ErrorMessage);
                       lcl_objSB_Msg.Append("<br/>");
                   }
                   throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException(lcl_objSB_Msg.ToString());
               }
               OracleParameter lcl_obj_ModuleCode = new OracleParameter("v_ModuleCode", OracleDbType.Int64);
               lcl_obj_ModuleCode.Direction = System.Data.ParameterDirection.Output;
               lcl_obj_ModuleCode.Value = lcl_obj_Module.ModuleCode;

               OracleParameter lcl_obj_ModuleName = new OracleParameter("v_ModuleName", OracleDbType.Int64);
               lcl_obj_ModuleName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_ModuleName.Value = lcl_obj_Module.ModuleName;

               OracleParameter lcl_obj_Shortname = new OracleParameter("v_Shortname", OracleDbType.Int64);
               lcl_obj_Shortname.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Shortname.Value = lcl_obj_Module.Shortname;

               OracleParameter lcl_obj_HomeLink = new OracleParameter("v_HomeLink", OracleDbType.Int64);
               lcl_obj_HomeLink.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_HomeLink.Value = lcl_obj_Module.HomeLink;

               OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IsDeleted", OracleDbType.Int64);
               lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_IsDeleted.Value = lcl_obj_Module.IsDeleted;

               OracleParameter lcl_obj_status = new OracleParameter("v_Status", OracleDbType.Int64);
               lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_status.Value = lcl_obj_Module.Status;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ModuleCode, lcl_obj_ModuleName, lcl_obj_Shortname, lcl_obj_HomeLink, lcl_obj_IsDeleted, lcl_obj_status };
               lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_MODULE", lcl_obj_SP_Parameters);

               return System.UInt64.Parse(lcl_obj_ModuleCode.Value.ToString());
           }, "BMLExceptionPolicy");

           return lcl_ui64_ModuleCode;
       }

       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.Module lcl_obj_Module)
       {
           System.UInt64 lcl_ui64_ModuleCode = 0;

           lcl_ui64_ModuleCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   OracleParameter lcl_obj_ModuleCode = new OracleParameter("v_ModuleCode", OracleDbType.Int64);
                   lcl_obj_ModuleCode.Direction = System.Data.ParameterDirection.Output;
                  // lcl_obj_ModuleCode.Value = lcl_obj_Module.ModuleCode;

                   OracleParameter lcl_obj_ModuleName = new OracleParameter("v_ModuleName", OracleDbType.NVarchar2,256);
                   lcl_obj_ModuleName.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_ModuleName.Value = lcl_obj_Module.ModuleName;

                   OracleParameter lcl_obj_Shortname = new OracleParameter("v_Shortname", OracleDbType.NVarchar2,32);
                   lcl_obj_Shortname.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_Shortname.Value = lcl_obj_Module.Shortname;

                   OracleParameter lcl_obj_HomeLink = new OracleParameter("v_HomeLink", OracleDbType.NVarchar2,512);
                   lcl_obj_HomeLink.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_HomeLink.Value = lcl_obj_Module.HomeLink;

                   OracleParameter lcl_obj_IsDeleted = new OracleParameter("v_IsDeleted", OracleDbType.Int64);
                   lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_IsDeleted.Value = 1;

                   OracleParameter lcl_obj_status = new OracleParameter("v_Status", OracleDbType.Int64);
                   lcl_obj_status.Direction = System.Data.ParameterDirection.Input;
                   lcl_obj_status.Value = 1;

                   OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ModuleCode, lcl_obj_ModuleName, lcl_obj_Shortname, lcl_obj_HomeLink, lcl_obj_IsDeleted, lcl_obj_status };
                   lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INS_MODULE", lcl_obj_SP_Parameters);

                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   lcl_obj_DBManager.InternalResource.Close();

                   return System.UInt64.Parse(lcl_obj_ModuleCode.Value.ToString());
               }
           }, "BMLExceptionPolicy");

           return lcl_ui64_ModuleCode;
       }


       public CCL.BusinessEntities.HRIS.Module Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.Module Get(ulong IP_ui64_Code)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.Module Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public CCL.BusinessEntities.HRIS.Module Get(string IP_str_SqlQuery)
       {
           throw new NotImplementedException();
       }

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> lcl_objlist_Module = null;
           lcl_objlist_Module = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                   {
                       throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Module.GetList(SqlQuery)) : No Module Data Found In The Database!!!");
                   }
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module> lcl_objlist_Tmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Module>();
                   while (lcl_obj_dr.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.HRIS.Module lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.Module();
                       lcl_obj_Tmp.ModuleCode = System.UInt64.Parse(lcl_obj_dr["MODULE_CODE"].ToString());
                       lcl_obj_Tmp.ModuleName = lcl_obj_dr["MODULE_NAME"].ToString();
                       lcl_obj_Tmp.Shortname = lcl_obj_dr["SHORT_NAME"].ToString();
                       //lcl_obj_Tmp.HomeLink = lcl_obj_dr["HOME_LINK"].ToString();                       
                       // lcl_obj_Tmp.IsDeleted = System.UInt16.Parse(lcl_obj_dr["IS_DELETED"].ToString());
                       lcl_obj_Tmp.Status = System.UInt16.Parse(lcl_obj_dr["Status"].ToString());
                       lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_Tmp;
               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_Module;
       }

       public List<CCL.BusinessEntities.HRIS.Module> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           throw new NotImplementedException();
       }

       public ulong AddModule(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
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

                   System.String lcl_str_SqlQuery = System.String.Format(@"insert into USER_MODULES(USER_CODE,module_code,IS_DELETED,STATUS) Values({1},{0},1,1)", IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                   lcl_obj_DBManager.ExecuteNonQuery(lcl_str_SqlQuery);

                   lcl_obj_DBManager.CommitTransaction();
                   lcl_obj_DBManager.Close();

                   return lcl_ui64_ModuleCode;

               }

           }, "BMLExceptionPolicy");

           return lcl_ui64_ModuleCode;
       }


       public ulong RemoveModule(System.UInt64 IP_ui64_ModuleCode, System.UInt64 IP_ui64_EmployeeCode)
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

                   System.String lcl_str_SqlQuery = System.String.Format(@"Delete From  USER_MODULES  Where USER_CODE={1} AND module_code={0}", IP_ui64_ModuleCode, IP_ui64_EmployeeCode);
                   lcl_obj_DBManager.ExecuteNonQuery(lcl_str_SqlQuery);

                   lcl_obj_DBManager.CommitTransaction();
                   lcl_obj_DBManager.Close();

                   return lcl_ui64_ModuleCode;

               }

           }, "BMLExceptionPolicy");

           return lcl_ui64_ModuleCode;
       }


    }
}
