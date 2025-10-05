using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeRoosterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>
    {
        public EmployeeRoosterManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="IP_obj_A"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster IP_obj_EmployeeRooster, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_EmployeeRoosterCode = 0;
            SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                  
            lcl_ui64_EmployeeRoosterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeRoosterCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_ROOSTER_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeRoosterCode.Direction = System.Data.ParameterDirection.Output;
              // lcl_obj_EmployeeRoosterCode.Value = IP_obj_EmployeeRooster.EmployyeRoosterCode;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeRoosterMasterCode = new System.Data.OracleClient.OracleParameter("p_ROOSTER_MASTER_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeRoosterMasterCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeRoosterMasterCode.Value = IP_obj_EmployeeRooster.EmployeeRoosterMasterCode;


                System.Data.OracleClient.OracleParameter lcl_obj_DutyDate = new System.Data.OracleClient.OracleParameter("p_DUTY_DATE", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_DutyDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DutyDate.Value = IP_obj_EmployeeRooster.DutyDate;

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("p_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = IP_obj_EmployeeRooster.EmployeeCode;


                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeRoosterCode, lcl_obj_EmployeeRoosterMasterCode, lcl_obj_DutyDate, lcl_obj_EmployeeCode};
                lcl_obj_DBManager.ExecuteStoredProcedure("EMPLOYEE_ROOSTER_IU", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_EmployeeRoosterCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_EmployeeRoosterCode;
        }
        /// <summary>
        /// ///////
        /// </summary>
        /// <param name="IP_obj_A"></param>
        /// <returns></returns>
        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster)
        {
            System.UInt64 lcl_ui64_EmployeeRoosterCode = 0;

            lcl_ui64_EmployeeRoosterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeRoosterCode = new System.Data.OracleClient.OracleParameter("v_EmployeeRoosterCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeRoosterCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_EmployeeRoosterCode.Value = lcl_obj_EmployeeRooster.EmployeeRoosterCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeRoosterMasterCode = new System.Data.OracleClient.OracleParameter("v_EmployeeRoosterMasterCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeRoosterMasterCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeRoosterMasterCode.Value = lcl_obj_EmployeeRooster.EmployeeRoosterMasterCode;


                    System.Data.OracleClient.OracleParameter lcl_obj_DutyDate = new System.Data.OracleClient.OracleParameter("v_DutyDate", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_DutyDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DutyDate.Value = lcl_obj_EmployeeRooster.DutyDate;

                    System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EmployeeCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeRooster.EmployeeCode;


                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_EmployeeRoosterCode, lcl_obj_EmployeeRoosterMasterCode, lcl_obj_DutyDate, lcl_obj_EmployeeCode};
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INSERT_EMPLOYEERooster", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_EmployeeRoosterCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_EmployeeRoosterCode;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeRooster Get(ulong IP_ui64_Code, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster = null;
            SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
            lcl_obj_EmployeeRooster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>(() =>
            {
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From EMPLOYEE_ROOSTER Where EMPLOYEE_ROOSTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeRoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmployeeRoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EmployeeRoosterManager.Get(ID,DBManger)) : Error Retrieving EmployeeRoosterManager Data!");
                }
                lcl_obj_EmployeeRoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_ROOSTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterMasterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.DutyDate = System.DateTime.Parse(lcl_obj_EmployeeRoosterMasterReader["DUTY_DATE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_CODE"].ToString());

                lcl_obj_EmployeeRoosterMasterReader.Close();
                return lcl_obj_EmployeeRoosterTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeRooster;
        }
/// <summary>
/// //
/// </summary>
/// <param name="IP_ui64_Code"></param>
/// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeRooster Get(ulong IP_ui64_Code)
        {
             SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterMaster = null;
            lcl_obj_EmployeeRoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeRoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From EMPLOYEE_ROOSTER Where EMPLOYEE_ROOSTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_EmployeeRoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeRoosterManager.Get(ID)) : No EmployeeRoosterManager Data Found In The Database!!!");
                    }

                
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_ROOSTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterMasterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.DutyDate = System.DateTime.Parse(lcl_obj_EmployeeRoosterMasterReader["DUTY_DATE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmployeeRoosterMasterReader.Close();
                return lcl_obj_EmployeeRoosterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeRoosterMaster;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeRooster Get(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster = null;

            lcl_obj_EmployeeRooster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeRoosterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_EmployeeRoosterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error EmployeeRooster.Get(SqlQuery,DBManger)) : Error Retrieving EmployeeRooster Data!");
                }
                lcl_obj_EmployeeRoosterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterReader["EMPLOYEE_ROOSTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeRoosterMasterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_EmployeeRoosterTmp.DutyDate = System.DateTime.Parse(lcl_obj_EmployeeRoosterReader["DUTY_DATE"].ToString());
                lcl_obj_EmployeeRoosterTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterReader["EMPLOYEE_CODE"].ToString());
                lcl_obj_EmployeeRoosterReader.Close();

                return lcl_obj_EmployeeRoosterTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeRooster;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.EmployeeRooster Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterMaster = null;
            lcl_obj_EmployeeRoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_EmployeeRoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_EmployeeRoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeRoosterManager.SqlQuery(ID)) : No EmployeeRoosterManager Data Found In The Database!!!");
                    }


                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRoosterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();
                    lcl_obj_EmployeeRoosterTmp.EmployeeRoosterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_ROOSTER_CODE"].ToString());
                    lcl_obj_EmployeeRoosterTmp.EmployeeRoosterMasterCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                    lcl_obj_EmployeeRoosterTmp.DutyDate = System.DateTime.Parse(lcl_obj_EmployeeRoosterMasterReader["DUTY_DATE"].ToString());
                    lcl_obj_EmployeeRoosterTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_EmployeeRoosterMasterReader["EMPLOYEE_CODE"].ToString());
                    lcl_obj_EmployeeRoosterMasterReader.Close();
                    return lcl_obj_EmployeeRoosterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_EmployeeRoosterMaster;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public List<CCL.BusinessEntities.HRIS.EmployeeRooster> GetList(string IP_str_SqlQuery, System.Object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> lcl_objLst_EmployeeRooster = null;
            lcl_objLst_EmployeeRooster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeRooster.GetList(SqlQuery,DBManager)) : No EmployeeRooster Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> lcl_objLst_EmployeeRoosterTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();

                    lcl_obj_EmployeeRooster.EmployeeRoosterCode = System.UInt64.Parse(dr["EMPLOYEE_ROOSTER_CODE"].ToString());
                    lcl_obj_EmployeeRooster.EmployeeRoosterMasterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
                    lcl_obj_EmployeeRooster.DutyDate = System.DateTime.Parse(dr["DUTY_DATE"].ToString());
                    lcl_obj_EmployeeRooster.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());

                    lcl_objLst_EmployeeRoosterTmp.Add(lcl_obj_EmployeeRooster);
                }
                dr.Close();
                return lcl_objLst_EmployeeRoosterTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeRooster;
        }
        /// <summary>
        /// ////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <returns></returns>
        public List<CCL.BusinessEntities.HRIS.EmployeeRooster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> lcl_objLst_EmployeeRooster = null;
            lcl_objLst_EmployeeRooster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>>(() =>
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
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMaster.GetList(SqlQuery)) : No RoosterMaster Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster> lcl_objLst_EmployeeRoosterTmp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster>();
                    while (dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();
                        lcl_obj_EmployeeRooster.EmployeeRoosterCode = System.UInt64.Parse(dr["EMPLOYEE_ROOSTER_CODE"].ToString());
                        lcl_obj_EmployeeRooster.EmployeeRoosterMasterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
                        lcl_obj_EmployeeRooster.DutyDate = System.DateTime.Parse(dr["DUTY_DATE"].ToString());
                        lcl_obj_EmployeeRooster.EmployeeCode = System.UInt64.Parse(dr["EMPLOYEE_CODE"].ToString());

                        lcl_objLst_EmployeeRoosterTmp.Add(lcl_obj_EmployeeRooster);
                    }
                    dr.Close();
                    return lcl_objLst_EmployeeRoosterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_EmployeeRooster;
        }

        //public ulong Save(CCL.BusinessEntities.HRIS.EmployeeRooster IP_obj_A, object IP_obj_DBManager)
        //{
        //    throw new NotImplementedException();
        //}

        //public CCL.BusinessEntities.HRIS.EmployeeRooster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        //{
        //    throw new NotImplementedException();
        //}

        //public CCL.BusinessEntities.HRIS.EmployeeRooster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<CCL.BusinessEntities.HRIS.EmployeeRooster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
