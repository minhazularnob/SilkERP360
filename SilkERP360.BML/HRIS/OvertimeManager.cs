using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class OvertimeManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Overtime>
    {
        public OvertimeManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Overtime IP_obj_Overtime, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_OvertimeCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_OVERTIME.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_OvertimeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Overtime.OvertimeCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_Overtime.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_OvertimeCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Overtime IP_obj_Overtime)
        {
            System.UInt64 lcl_ui64_OvertimeCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_OVERTIME.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_OvertimeCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_Overtime.OvertimeCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_Overtime.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_OvertimeCode;
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime = null;
            lcl_obj_Overtime = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Overtime>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From OVERTIME WHERE OVERTIME_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Overtime lcl_obj_TmpOvertime = new CCL.BusinessEntities.HRIS.Overtime();
                lcl_obj_TmpOvertime.OvertimeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_CODE"].ToString());
                lcl_obj_TmpOvertime.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpOvertime.OvertimeDate = System.DateTime.Parse(lcl_obj_dr["OT_DATE"].ToString());
                lcl_obj_TmpOvertime.OvertimeHour = System.Double.Parse(lcl_obj_dr["OT_HOUR"].ToString());
                lcl_obj_TmpOvertime.IsProcessed = (CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PROCESSED"].ToString());
                lcl_obj_TmpOvertime.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpOvertime.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpOvertime;
            }, "BMLExceptionPolicy");
            return lcl_obj_Overtime;
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime = null;
            lcl_obj_Overtime = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Overtime>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(@"Select * From SCPM_SM_PEEL_OFF_QC SM_PEEL_OFF_CODE= {0} and STATUS = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Overtime lcl_obj_TmpOvertime = new CCL.BusinessEntities.HRIS.Overtime();
                    lcl_obj_TmpOvertime.OvertimeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_CODE"].ToString());
                    lcl_obj_TmpOvertime.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpOvertime.OvertimeDate = System.DateTime.Parse(lcl_obj_dr["OT_DATE"].ToString());
                    lcl_obj_TmpOvertime.OvertimeHour = System.Double.Parse(lcl_obj_dr["OT_HOUR"].ToString());
                    lcl_obj_TmpOvertime.IsProcessed = (CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PROCESSED"].ToString());
                    lcl_obj_TmpOvertime.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpOvertime.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpOvertime;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Overtime;
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Overtime Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Overtime> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime> lcl_objlist_OvertimeList = null;
            lcl_objlist_OvertimeList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime> lcl_objlist_TmpOvertimeList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery); 
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpOvertimeList;
                }
               
                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Overtime lcl_obj_TmpOvertime = new CCL.BusinessEntities.HRIS.Overtime();
                    lcl_obj_TmpOvertime.OvertimeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_CODE"].ToString());
                    lcl_obj_TmpOvertime.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpOvertime.OvertimeDate = System.DateTime.Parse(lcl_obj_dr["OT_DATE"].ToString());
                    lcl_obj_TmpOvertime.OvertimeHour = System.Double.Parse(lcl_obj_dr["OT_HOUR"].ToString());
                    lcl_obj_TmpOvertime.IsProcessed = (CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PROCESSED"].ToString());
                    lcl_obj_TmpOvertime.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpOvertime.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_objlist_TmpOvertimeList.Add(lcl_obj_TmpOvertime);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpOvertimeList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_OvertimeList;
        }

        public List<CCL.BusinessEntities.HRIS.Overtime> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime> lcl_objlist_OvertimeList = null;
            lcl_objlist_OvertimeList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime> lcl_objlist_TmpOvertimeList = new
                     System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Overtime>();
                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.Overtime lcl_obj_TmpOvertime = new CCL.BusinessEntities.HRIS.Overtime();
                        lcl_obj_TmpOvertime.OvertimeCode = System.UInt64.Parse(lcl_obj_dr["OVERTIME_CODE"].ToString());
                        lcl_obj_TmpOvertime.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpOvertime.OvertimeDate = System.DateTime.Parse(lcl_obj_dr["OT_DATE"].ToString());
                        lcl_obj_TmpOvertime.OvertimeHour = System.Double.Parse(lcl_obj_dr["OT_HOUR"].ToString());
                        lcl_obj_TmpOvertime.IsProcessed = (CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_PROCESSED"].ToString());
                        lcl_obj_TmpOvertime.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_obj_TmpOvertime.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_objlist_TmpOvertimeList.Add(lcl_obj_TmpOvertime);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpOvertimeList;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_OvertimeList;
        }
    }
}
