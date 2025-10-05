using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class IncrementManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Increment>
    {
        public IncrementManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.HRIS.Increment IP_obj_Increment, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_IncrementCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Increment.GetSequence());
            lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Increment.IncrementCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_Increment.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Increment IP_obj_Increment)
        {
            System.UInt64 lcl_ui64_IncrementCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Increment.GetSequence());
            lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_Increment.IncrementCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_Increment.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_INCREMENT WHERE INCREMENT_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpIncrement;
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_INCREMENT WHERE INCREMENT_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpIncrement;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new SilkERP360.CCL.BusinessEntities.HRIS.Increment();
                lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
               // lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpIncrement;
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new SilkERP360.CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpIncrement;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public List<CCL.BusinessEntities.HRIS.Increment> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_IncrementList = null;
            lcl_objlist_IncrementList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_TmpIncrementList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpIncrementList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.Decimal.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_objlist_TmpIncrementList.Add(lcl_obj_TmpIncrement);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpIncrementList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementList;
        }

        public List<CCL.BusinessEntities.HRIS.Increment> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_IncrementList = null;
            lcl_objlist_IncrementList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_TmpIncrementList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpIncrementList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                        lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                        //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                        lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                        lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                        lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                        lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                        lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                        lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                        lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                        lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                        //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                        lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                        lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                        lcl_objlist_TmpIncrementList.Add(lcl_obj_TmpIncrement);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpIncrementList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementList;
        }
    }
}
