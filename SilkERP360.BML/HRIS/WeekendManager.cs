using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class WeekendManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Weekend>
    {

       public WeekendManager()
       {
           this.Initialize();
       }

        public ulong Save(CCL.BusinessEntities.HRIS.Weekend IP_obj_Weekend, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_WeekendCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Weekend.GetSequence());
            lcl_ui64_WeekendCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Weekend.WeekendCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_Weekend.GenerateSqlInsert();
                try
                {
                    lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                }
                catch (System.Exception EX)
                {
                    int H = 0;
                    throw EX;
                }
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_WeekendCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Weekend IP_obj_Weekend)
        {
            System.UInt64 lcl_ui64_WeekendCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Weekend.GetSequence());
            lcl_ui64_WeekendCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_Weekend.WeekendCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_Weekend.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_WeekendCode;
        }

        public CCL.BusinessEntities.HRIS.Weekend Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend = null;
            lcl_obj_Weekend = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Weekend>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From WEEKEND WHERE WEEKEND_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpWeekend;
            }, "BMLExceptionPolicy");
            return lcl_obj_Weekend;
        }

        public CCL.BusinessEntities.HRIS.Weekend Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend = null;
            lcl_obj_Weekend = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Weekend>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From WEEKEND WHERE WEEKEND_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                    lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                    lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                    lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                    lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                    lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                    lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpWeekend;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Weekend;
        }

        public CCL.BusinessEntities.HRIS.Weekend Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend = null;
            lcl_obj_Weekend = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Weekend>(() =>
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
                    lcl_obj_dr.Close();
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpWeekend;
            }, "BMLExceptionPolicy");
            return lcl_obj_Weekend;
        }

        public CCL.BusinessEntities.HRIS.Weekend Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Weekend lcl_obj_Weekend = null;
            lcl_obj_Weekend = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Weekend>(() =>
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
                        lcl_obj_dr.Close();
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                    lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                    lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                    lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                    lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                    lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                    lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpWeekend;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Weekend;
        }

        public List<CCL.BusinessEntities.HRIS.Weekend> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend> lcl_objlist_WeekendList = null;
            lcl_objlist_WeekendList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend> lcl_objlist_TmpWeekendList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpWeekendList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                    lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                    lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                    lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                    lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                    lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                    lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_objlist_TmpWeekendList.Add(lcl_obj_TmpWeekend);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpWeekendList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_WeekendList;
        }

        public List<CCL.BusinessEntities.HRIS.Weekend> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend> lcl_objlist_WeekendList = null;
            lcl_objlist_WeekendList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend> lcl_objlist_TmpWeekendList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Weekend>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        lcl_obj_dr.Close();
                        return lcl_objlist_TmpWeekendList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.Weekend lcl_obj_TmpWeekend = new CCL.BusinessEntities.HRIS.Weekend();
                        lcl_obj_TmpWeekend.WeekendCode = System.UInt64.Parse(lcl_obj_dr["WEEKEND_CODE"].ToString());
                        lcl_obj_TmpWeekend.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpWeekend.WeekendDate = System.DateTime.Parse(lcl_obj_dr["WEEKEND_DATE"].ToString());
                        lcl_obj_TmpWeekend.Weekday = (SilkERP360.CCL.Enums.WeekDay)System.Int32.Parse(lcl_obj_dr["WEEK_DAY"].ToString());
                        lcl_obj_TmpWeekend.WeekNumber = System.Int32.Parse(lcl_obj_dr["WEEK_NUMBER"].ToString());
                        lcl_obj_TmpWeekend.Year = System.Int32.Parse(lcl_obj_dr["YEAR"].ToString());
                        lcl_obj_TmpWeekend.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_obj_TmpWeekend.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_objlist_TmpWeekendList.Add(lcl_obj_TmpWeekend);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpWeekendList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_WeekendList;
        }
    }
}
