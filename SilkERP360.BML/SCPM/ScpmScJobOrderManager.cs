using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class ScpmScJobOrderManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>
    {
       public ScpmScJobOrderManager()
        {
            this.Initialize();
        }


       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrder IP_obj_ScpmScJobOrder, object IP_obj_DBManager)
       {
           System.UInt64 lcl_ui64_ScpmScJobOrderCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL",IP_obj_ScpmScJobOrder.GetSequence());
           lcl_ui64_ScpmScJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               lcl_obj_IDReader.Read();
               System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
               lcl_obj_IDReader.Close();

               IP_obj_ScpmScJobOrder.ScJOCode = lcl_ui64_ID;
               System.String lcl_str_SqlInsert = IP_obj_ScpmScJobOrder.GenerateSqlInsert();
               lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);

               //Save JobOrderItem
               SilkERP360.BML.SCPM.ScpmScJobOrderItemManager lcl_obj_ScpmScJobOrderItemManager = new ScpmScJobOrderItemManager();
               lcl_obj_ScpmScJobOrderItemManager.Initialize();
               foreach (SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem in IP_obj_ScpmScJobOrder.JobOrderItems)
               {
                   lcl_obj_ScpmScJobOrderItem.ScJOCode = IP_obj_ScpmScJobOrder.ScJOCode;
                   lcl_obj_ScpmScJobOrderItemManager.Save(lcl_obj_ScpmScJobOrderItem, lcl_obj_DBManager);
               }
               return lcl_ui64_ID;
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScpmScJobOrderCode;
       }

       public ulong Save(CCL.BusinessEntities.SCPM.ScpmScJobOrder IP_obj_ScpmScJobOrder)
       {
           System.UInt64 lcl_ui64_ScpmScJobOrderCode = 0;
           System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_SCPM_SC_JO.NEXTVAL AS ID FROM DUAL", IP_obj_ScpmScJobOrder.GetSequence());
           lcl_ui64_ScpmScJobOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   lcl_obj_IDReader.Read();
                   System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                   lcl_obj_IDReader.Close();

                   IP_obj_ScpmScJobOrder.ScJOCode = lcl_ui64_ID;
                   System.String lcl_str_SqlInsert = IP_obj_ScpmScJobOrder.GenerateSqlInsert();
                   lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                   lcl_obj_DBManager.InternalResource.CommitTransaction();
                   return lcl_ui64_ID;
               }
           }, "BMLExceptionPolicy");
           return lcl_ui64_ScpmScJobOrderCode;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(ulong IP_ui64_Code, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_JOB_ORDER WHERE SC_JO_CODE = {0}", IP_ui64_Code);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new CCL.BusinessEntities.SCPM.ScpmScJobOrder();
               lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
               lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());

               lcl_obj_dr.Close();
               return lcl_obj_TmpScpmScJobOrder;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(ulong IP_ui64_Code)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   System.String lcl_str_SqlQuery = System.String.Format("Select * From SCPM_SC_JOB_ORDER WHERE SC_JO_CODE = {0}", IP_ui64_Code);
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                   if (lcl_obj_dr.HasRows == false)
                   {
                       return null;
                   }
                   lcl_obj_dr.Read();
                   CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new CCL.BusinessEntities.SCPM.ScpmScJobOrder();
                   lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmScJobOrder;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
               if (lcl_obj_dr.HasRows == false)
               {
                   return null;
               }
               lcl_obj_dr.Read();
               SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder();
               lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
               lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
               lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
               lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
               lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
               lcl_obj_dr.Close();

               return lcl_obj_TmpScpmScJobOrder;
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public CCL.BusinessEntities.SCPM.ScpmScJobOrder Get(string IP_str_SqlQuery)
       {
           CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = null;
           lcl_obj_ScpmScJobOrder = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return null;
                   }
                   SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder();
                   lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_obj_dr.Close();
                   return lcl_obj_TmpScpmScJobOrder;
               }
           }, "BMLExceptionPolicy");
           return lcl_obj_ScpmScJobOrder;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_objlist_ScpmScJobOrderList = null;
           lcl_objlist_ScpmScJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder>>(() =>
           {
               SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
               if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
               {
                   lcl_obj_DBManager.Open();
               }
               System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_objlist_TmpScpmScJobOrderList = new
                  System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder>();
               Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
               if (!(lcl_obj_dr.HasRows))
               {
                   return lcl_objlist_TmpScpmScJobOrderList;
               }

               while (lcl_obj_dr.Read())
               {
                   CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new CCL.BusinessEntities.SCPM.ScpmScJobOrder();
                   lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                   lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                   lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                   lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                   lcl_objlist_TmpScpmScJobOrderList.Add(lcl_obj_TmpScpmScJobOrder);
               }
               lcl_obj_dr.Close();


               return lcl_objlist_TmpScpmScJobOrderList;
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmScJobOrderList;
       }

       public List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> GetList(string IP_str_SqlQuery)
       {
           System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_objlist_ScpmScJobOrderList = null;
           lcl_objlist_ScpmScJobOrderList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder>>(() =>
           {
               using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
               {
                   if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                   {
                       lcl_obj_DBManager.InternalResource.Open();
                   }

                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder> lcl_objlist_TmpScpmScJobOrderList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SCPM.ScpmScJobOrder>();
                   Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                   if (!(lcl_obj_dr.HasRows))
                   {
                       return lcl_objlist_TmpScpmScJobOrderList;
                   }

                   while (lcl_obj_dr.Read())
                   {
                       CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_TmpScpmScJobOrder = new CCL.BusinessEntities.SCPM.ScpmScJobOrder();
                       lcl_obj_TmpScpmScJobOrder.ScJOCode = System.UInt64.Parse(lcl_obj_dr["SC_JO_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrder.ScpmPOCode = System.UInt64.Parse(lcl_obj_dr["SCPM_PO_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrder.DeliveryStatus = (SilkERP360.CCL.Enums.SPM.DeliveryStatus)System.UInt16.Parse(lcl_obj_dr["DELIVERY_STATUS"].ToString());
                       lcl_obj_TmpScpmScJobOrder.Status = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                       lcl_obj_TmpScpmScJobOrder.Remarks = lcl_obj_dr["REMARKS"].ToString();
                       lcl_obj_TmpScpmScJobOrder.IsCancelled = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_CANCELLED"].ToString());
                       lcl_obj_TmpScpmScJobOrder.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                       lcl_obj_TmpScpmScJobOrder.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                       lcl_objlist_TmpScpmScJobOrderList.Add(lcl_obj_TmpScpmScJobOrder);
                   }
                   lcl_obj_dr.Close();
                   return lcl_objlist_TmpScpmScJobOrderList;

               }
           }, "BMLExceptionPolicy");
           return lcl_objlist_ScpmScJobOrderList;
       }
    }
}
