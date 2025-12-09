using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class MedicalInfoManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>
    {
        public MedicalInfoManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.HRIS.MedicalInfo IP_obj_MedicalInfo, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_MedicalInfoCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_MedicalInfo.GetSequence());
            lcl_ui64_MedicalInfoCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_MedicalInfo.MedicalInfoCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_MedicalInfo.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_MedicalInfoCode;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.MedicalInfo IP_obj_MedicalInfo)
        {
            System.UInt64 lcl_ui64_MedicalInfoCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_MedicalInfo.GetSequence());
            lcl_ui64_MedicalInfoCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_MedicalInfo.MedicalInfoCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_MedicalInfo.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_MedicalInfoCode;
        }

        public CCL.BusinessEntities.HRIS.MedicalInfo Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_Medicine = null;
            lcl_obj_Medicine = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From MEDICALE_INFO WHERE MDCN_INFO_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new CCL.BusinessEntities.HRIS.MedicalInfo();
                lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
               

                lcl_obj_dr.Close();
                return lcl_obj_TmpMedicalInfo;
            }, "BMLExceptionPolicy");
            return lcl_obj_Medicine;
        }

        public CCL.BusinessEntities.HRIS.MedicalInfo Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_Medicine = null;
            lcl_obj_Medicine = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From MEDICALE_INFO WHERE MDCN_INFO_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new CCL.BusinessEntities.HRIS.MedicalInfo();
                    lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                    lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                    lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpMedicalInfo;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Medicine;
        }

        public CCL.BusinessEntities.HRIS.MedicalInfo Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
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
                SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo();
                lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
                lcl_obj_dr.Close();
                return lcl_obj_TmpMedicalInfo;
            }, "BMLExceptionPolicy");
            return lcl_obj_MedicalInfo;
        }

        public CCL.BusinessEntities.HRIS.MedicalInfo Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo>(() =>
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
                    SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new SilkERP360.CCL.BusinessEntities.HRIS.MedicalInfo();
                    lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                    lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                    lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpMedicalInfo;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_MedicalInfo;
        }

        public List<CCL.BusinessEntities.HRIS.MedicalInfo> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objlist_MedicalInfoList = null;
            lcl_objlist_MedicalInfoList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objlist_TmpMedicalInfoList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpMedicalInfoList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new CCL.BusinessEntities.HRIS.MedicalInfo();
                    lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                    lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                    lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                    lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                    lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                    lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                    lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
                    lcl_objlist_TmpMedicalInfoList.Add(lcl_obj_TmpMedicalInfo);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpMedicalInfoList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_MedicalInfoList;
        }

        public List<CCL.BusinessEntities.HRIS.MedicalInfo> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objlist_MedicalInfoList = null;
            lcl_objlist_MedicalInfoList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo> lcl_objlist_TmpMedicalInfoList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.MedicalInfo>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpMedicalInfoList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.MedicalInfo lcl_obj_TmpMedicalInfo = new CCL.BusinessEntities.HRIS.MedicalInfo();
                        lcl_obj_TmpMedicalInfo.MedicalInfoCode = System.UInt64.Parse(lcl_obj_dr["MDCN_INFO_CODE"].ToString());
                        lcl_obj_TmpMedicalInfo.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpMedicalInfo.Age = lcl_obj_dr["AGE"].ToString();
                        lcl_obj_TmpMedicalInfo.Sex = lcl_obj_dr["SEX"].ToString();
                        lcl_obj_TmpMedicalInfo.VisitedDate = System.DateTime.Parse(lcl_obj_dr["VISITED_DATE"].ToString());
                      //  lcl_obj_TmpMedicalInfo.Status = System.UInt16.Parse(lcl_obj_dr["STATUS"].ToString());
                        lcl_obj_TmpMedicalInfo.Remarks = lcl_obj_dr["REMARKS"].ToString();
                        lcl_obj_TmpMedicalInfo.BloodGroup = lcl_obj_dr["BLOOD_GROUP"].ToString();
                        lcl_obj_TmpMedicalInfo.Diagnosis = lcl_obj_dr["DIAGNOSIS"].ToString();
                        lcl_objlist_TmpMedicalInfoList.Add(lcl_obj_TmpMedicalInfo);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpMedicalInfoList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_MedicalInfoList;
        }
    }
}
