using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
   public class RawSubBML : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
       SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>
    {

       public RawSubBML()

       { 
       }

       public ulong Save(CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterials, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_RawMaterialsCode = 0;

           lcl_ui64_RawMaterialsCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

               OracleParameter lcl_obj_RMSubCode = new OracleParameter("v_RMSUB_CODE", OracleDbType.Int64);
               lcl_obj_RMSubCode.Direction = System.Data.ParameterDirection.Output;
               //lcl_obj_ProductUpdateCode.Value = lcl_obj_RawMaterials.ProductUpdateCode;

               OracleParameter lcl_obj_RMCode = new OracleParameter("v_RM_CODE", OracleDbType.Int64);
               lcl_obj_RMCode.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_RMCode.Value = lcl_obj_RawMaterials.RMCode;

               OracleParameter lcl_obj_RMSubName = new OracleParameter("v_RM_SUB_NAME", OracleDbType.NVarchar2,150);
               lcl_obj_RMSubName.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_RMSubName.Value = lcl_obj_RawMaterials.RMSubName;

               OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
               lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
               lcl_obj_Status.Value = lcl_obj_RawMaterials.Status;

               OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RMCode, lcl_obj_RMSubCode, lcl_obj_RMSubName, lcl_obj_Status };
               lcl_obj_DBManager.ExecuteStoredProcedure("WPMS_RAWSUB_INSERT", lcl_obj_SP_Parameters);
               return System.UInt64.Parse(lcl_obj_RMCode.Value.ToString());
           }, "BMLExceptionPolicy");

           return lcl_ui64_RawMaterialsCode;
        }

       public ulong Save(CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawLIST)
        {

            {
                System.UInt64 lcl_ui64_RawMaterialsCode = 0;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    OracleParameter lcl_obj_RMSubCode = new OracleParameter("v_RMSUB_CODE", OracleDbType.Int64);
                    lcl_obj_RMSubCode.Direction = System.Data.ParameterDirection.Output;
                    //lcl_obj_ProductUpdateCode.Value = lcl_obj_RawMaterials.ProductUpdateCode;

                    OracleParameter lcl_obj_RMCode = new OracleParameter("v_RM_CODE", OracleDbType.Int64);
                    lcl_obj_RMCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RMCode.Value = lcl_obj_RawLIST.RMCode;

                    OracleParameter lcl_obj_RMSubName = new OracleParameter("v_RM_SUB_NAME", OracleDbType.NVarchar2, 150);
                    lcl_obj_RMSubName.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RMSubName.Value = lcl_obj_RawLIST.RMSubName;

                    OracleParameter lcl_obj_Status = new OracleParameter("v_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_RawLIST.Status;

                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RMCode, lcl_obj_RMSubCode, lcl_obj_RMSubName, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("WPMS_RAWSUB_INSERT", lcl_obj_SP_Parameters);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();
                    return System.UInt64.Parse(lcl_obj_RMCode.Value.ToString());
                }

                return lcl_ui64_RawMaterialsCode;
            }
        }

        public CCL.BusinessEntities.WPMS.RawLIST Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterials = null;

            lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_RMSUB Where RMSUB_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.Get(SALES_CONTRACT_CODE,DBManger)) : Error Retrieving RawMaterials Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();
             
                lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                lcl_obj_Reader.Close();
                return lcl_obj_RawMaterialsTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_RawMaterials;
        }

        public CCL.BusinessEntities.WPMS.RawLIST Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterials = null;
            lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_SALES_CONTRACT Where SALES_CONTRACT_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RawMaterialsManager.Get(ID)) : No RawMaterials Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                    lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();

                    lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_obj_Reader.Close();
                    return lcl_obj_RawMaterialsTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RawMaterials;
        }

        public CCL.BusinessEntities.WPMS.RawLIST Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterials = null;

            lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.Get(SqlQuery,DBManger)) : Error Retrieving RawMaterials Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();
                lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                lcl_obj_Reader.Close();
                return lcl_obj_RawMaterialsTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_RawMaterials;
        }

        public CCL.BusinessEntities.WPMS.RawLIST Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterials = null;
            lcl_obj_RawMaterials = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RawMaterialsManager.Get(SqlQuery)) : No RawMaterials Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                    lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();
                    lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_obj_Reader.Close();
                    return lcl_obj_RawMaterialsTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RawMaterials;
        }

        public List<CCL.BusinessEntities.WPMS.RawLIST> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_objLst_RawMaterials = null;

            lcl_objLst_RawMaterials = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_Reader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RawMaterialsManager.GetList(SqlQuery,DBManager)) : No RawMaterials Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_objLst_RawMaterialsTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                    lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();
                    lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());
                    lcl_objLst_RawMaterialsTmp.Add(lcl_obj_RawMaterialsTmp);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_RawMaterialsTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_RawMaterials;
        }

        public List<CCL.BusinessEntities.WPMS.RawLIST> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_objLst_Quotation = null;
        
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                  
                   System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> lcl_objLst_Items2Tmp = new
                       System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST>();
                   while (lcl_obj_Reader.Read())
                   {
                       SilkERP360.CCL.BusinessEntities.WPMS.RawLIST lcl_obj_RawMaterialsTmp = new SilkERP360.CCL.BusinessEntities.WPMS.RawLIST();
                      lcl_obj_RawMaterialsTmp.RMSubCode = System.UInt64.Parse(lcl_obj_Reader["RMSUB_CODE"].ToString());
                    lcl_obj_RawMaterialsTmp.RMSubName = lcl_obj_Reader["RM_SUB_NAME"].ToString();
                    lcl_obj_RawMaterialsTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_RawMaterialsTmp.RMCode = System.UInt64.Parse(lcl_obj_Reader["RM_CODE"].ToString());

                       lcl_objLst_Items2Tmp.Add(lcl_obj_RawMaterialsTmp);
                   }
                   lcl_obj_Reader.Close();
                   return lcl_objLst_Items2Tmp;
               }
                     return lcl_objLst_Quotation;
       }
        }
    }

