using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
   public class RooserMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.Attendance>
    {

       public RooserMasterManager()
        {
            //ExceptionManagement Initialization
            this.Initialize();
        }
       /// <summary>
       /// ///////
       /// </summary>
       /// <param name="IP_obj_A"></param>
       /// <param name="IP_obj_DBManager"></param>
       /// <returns></returns>
       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
             System.UInt64 lcl_ui64_RoosTerMaseterCode = 0;

            lcl_ui64_RoosTerMaseterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
 
                System.Data.OracleClient.OracleParameter lcl_obj_RoosTerMaseterCode = new System.Data.OracleClient.OracleParameter("v_RoosTerMaseterCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_RoosTerMaseterCode.Direction = System.Data.ParameterDirection.Output;
                lcl_obj_RoosTerMaseterCode.Value = lcl_obj_RoosterMaster.RoosTerMaseterCode;

                System.Data.OracleClient.OracleParameter lcl_obj_ShiftCode = new System.Data.OracleClient.OracleParameter("v_ShiftCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShiftCode.Value = lcl_obj_RoosterMaster.ShiftCode;

                System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DepartmentCode", System.Data.OracleClient.OracleType.Number);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DepartmentCode.Value = lcl_obj_RoosterMaster.DepartmentCode;

                System.Data.OracleClient.OracleParameter lcl_obj_RosterDateFrom = new System.Data.OracleClient.OracleParameter("v_RosterDateFrom", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_RosterDateFrom.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterDateFrom.Value = lcl_obj_RoosterMaster.RosterDateFrom;

                System.Data.OracleClient.OracleParameter lcl_obj_RosterDateTo = new System.Data.OracleClient.OracleParameter("v_RosterDateTo", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_RosterDateTo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterDateTo.Value = lcl_obj_RoosterMaster.RosterDateTo;

                System.Data.OracleClient.OracleParameter lcl_obj_RosterChangeDate = new System.Data.OracleClient.OracleParameter("v_RosterChangeDatee", System.Data.OracleClient.OracleType.DateTime);
                lcl_obj_RosterChangeDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterChangeDate.Value = lcl_obj_RoosterMaster.RosterChangeDate;


                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RoosTerMaseterCode, lcl_obj_ShiftCode, lcl_obj_DepartmentCode, lcl_obj_ShiftCode, lcl_obj_RosterDateFrom, lcl_obj_RosterDateTo, lcl_obj_RosterChangeDate};
                IP_obj_DBManager.ExecuteStoredProcedure("HRIS_INSERT_RoosterMaster", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_RoosTerMaseterCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_RoosTerMaseterCode;
        }
       /// <summary>
       /// /////////
       /// </summary>
       /// <param name="IP_obj_A"></param>
       /// <returns></returns>
       public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster)
        {
            System.UInt64 lcl_ui64_RoosTerMaseterCode = 0;

            lcl_ui64_RoosTerMaseterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Data.OracleClient.OracleParameter lcl_obj_RoosTerMaseterCode = new System.Data.OracleClient.OracleParameter("v_RoosTerMaseterCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_RoosTerMaseterCode.Direction = System.Data.ParameterDirection.Output;
                    lcl_obj_RoosTerMaseterCode.Value = lcl_obj_RoosterMaster.RoosTerMaseterCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_ShiftCode = new System.Data.OracleClient.OracleParameter("v_ShiftCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShiftCode.Value = lcl_obj_RoosterMaster.ShiftCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DepartmentCode", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DepartmentCode.Value = lcl_obj_RoosterMaster.DepartmentCode;

                    System.Data.OracleClient.OracleParameter lcl_obj_RosterDateFrom = new System.Data.OracleClient.OracleParameter("v_RosterDateFrom", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_RosterDateFrom.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterDateFrom.Value = lcl_obj_RoosterMaster.RosterDateFrom;

                    System.Data.OracleClient.OracleParameter lcl_obj_RosterDateTo = new System.Data.OracleClient.OracleParameter("v_RosterDateTo", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_RosterDateTo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterDateTo.Value = lcl_obj_RoosterMaster.RosterDateTo;

                    System.Data.OracleClient.OracleParameter lcl_obj_RosterChangeDate = new System.Data.OracleClient.OracleParameter("v_RosterChangeDatee", System.Data.OracleClient.OracleType.DateTime);
                    lcl_obj_RosterChangeDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterChangeDate.Value = lcl_obj_RoosterMaster.RosterChangeDate;


                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RoosTerMaseterCode, lcl_obj_ShiftCode, lcl_obj_DepartmentCode, lcl_obj_ShiftCode, lcl_obj_RosterDateFrom, lcl_obj_RosterDateTo, lcl_obj_RosterChangeDate };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS_INSERT_RoosterMaster", lcl_obj_SP_Parameters);

                    return System.UInt64.Parse(lcl_obj_RoosTerMaseterCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_RoosTerMaseterCode;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.RoosterMaster Get(ulong IP_ui64_Code, SilkERP360.DAL.DBManager lcl_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster = null;
            lcl_obj_RoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>(() =>
            {
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From ROOSTER_MASTER Where ROOSTER_MASTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_RoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RoosterMasterManager.Get(ID,DBManger)) : Error Retrieving RoosterMasterManager Data!");
                }
                lcl_obj_RoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosTerMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());     
                lcl_obj_RoosterMasterTmp.RosterDateFrom= System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                lcl_obj_RoosterMasterReader.Close();
                return lcl_obj_RoosterMasterTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }
        /// <summary>
        /// /////
        /// </summary>
        /// <param name="IP_ui64_Code"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.RoosterMaster Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster = null;
            lcl_obj_RoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From ROOSTER_MASTER Where ROOSTER_MASTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_RoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMasterManager.Get(ID)) : No RoosterMasterManager Data Found In The Database!!!");
                    }

                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosTerMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());     
                lcl_obj_RoosterMasterTmp.RosterDateFrom= System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                lcl_obj_RoosterMasterReader.Close();
                return lcl_obj_RoosterMasterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }
        /// <summary>
        /// //////
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="lcl_obj_DBManager"></param>
        /// <returns></returns>
        public CCL.BusinessEntities.HRIS.RoosterMaster Get(string IP_str_SqlQuery, SilkERP360.DAL.DBManager lcl_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster = null;
            lcl_obj_RoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>(() =>
            {
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_RoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RoosterMasterManager.Get(SqlQuery,DBManger)) : Error Retrieving RoosterMasterManager Data!");
                }
                lcl_obj_RoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosTerMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.RosterDateFrom = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                lcl_obj_RoosterMasterReader.Close();
                return lcl_obj_RoosterMasterTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }
/// <summary>
/// ////////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <returns></returns>
        public CCL.BusinessEntities.HRIS.RoosterMaster Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster = null;
            lcl_obj_RoosterMaster = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(lcl_obj_RoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMasterManager.Get(SqlQuery)) : No RoosterMasterManager Data Found In The Database!!!");
                    }

                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosTerMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());     
                lcl_obj_RoosterMasterTmp.RosterDateFrom= System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                lcl_obj_RoosterMasterReader.Close();
                return lcl_obj_RoosterMasterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }
/// <summary>
/// //////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <param name="IP_obj_DBManager"></param>
/// <returns></returns>
        public List<CCL.BusinessEntities.HRIS.RoosterMaster> GetList(string IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster> lcl_objLst_RoosterMaster = null;
            lcl_objLst_RoosterMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>>(() =>
            {
                if (IP_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMaster.GetList(SqlQuery,DBManager)) : No RoosterMaster Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster> lcl_objLst_RosterMasterTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RossterMaster = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();

                    //lcl_obj_Attendance.AtandanceCode = System.UInt64.Parse(dr["ATTENDANCE_CODE"].ToString());
                    lcl_obj_RossterMaster.RoosTerMaseterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
                    lcl_obj_RossterMaster.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
                    lcl_obj_RossterMaster.DepartmentCode = System.UInt64.Parse(dr["DEPARTMENT_CODE"].ToString());
                    lcl_obj_RossterMaster.RosterDateFrom = System.DateTime.Parse(dr["ROOSTER_DATE_FROM"].ToString());
                    lcl_obj_RossterMaster.RosterDateTo = System.DateTime.Parse(dr["ROOSTER_DATE_TO"].ToString());
                    lcl_obj_RossterMaster.RosterChangeDate = System.DateTime.Parse(dr["SHIFT_CHANGE_DATE"].ToString());

                    lcl_objLst_RosterMasterTmp.Add(lcl_obj_RossterMaster);
                }
                dr.Close();
                return lcl_objLst_RosterMasterTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_RoosterMaster;
        }
/// <summary>
/// //////
/// </summary>
/// <param name="IP_str_SqlQuery"></param>
/// <returns></returns>
        public List<CCL.BusinessEntities.HRIS.RoosterMaster> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster> lcl_objLst_RoosterMaster = null;
            lcl_objLst_RoosterMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>>(() =>
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
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster> lcl_objLst_RosterMasterTmp = new
                        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>();
                    while (dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RossterMaster = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();

                        //lcl_obj_Attendance.AtandanceCode = System.UInt64.Parse(dr["ATTENDANCE_CODE"].ToString());
                        lcl_obj_RossterMaster.RoosTerMaseterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
                        lcl_obj_RossterMaster.ShiftCode = System.UInt64.Parse(dr["SHIFT_CODE"].ToString());
                        lcl_obj_RossterMaster.DepartmentCode = System.UInt64.Parse(dr["DEPARTMENT_CODE"].ToString());
                        lcl_obj_RossterMaster.RosterDateFrom = System.DateTime.Parse(dr["ROOSTER_DATE_FROM"].ToString());
                        lcl_obj_RossterMaster.RosterDateTo = System.DateTime.Parse(dr["ROOSTER_DATE_TO"].ToString());
                        lcl_obj_RossterMaster.RosterChangeDate = System.DateTime.Parse(dr["SHIFT_CHANGE_DATE"].ToString());

                        lcl_objLst_RosterMasterTmp.Add(lcl_obj_RossterMaster);
                    }
                    dr.Close();
                    return lcl_objLst_RosterMasterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objLst_RoosterMaster;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Attendance IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.Attendance IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Attendance Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Attendance CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Attendance>.Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.Attendance Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        CCL.BusinessEntities.HRIS.Attendance CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Attendance>.Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.Attendance> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        List<CCL.BusinessEntities.HRIS.Attendance> CCL.Interfaces.IManagerOperations<CCL.BusinessEntities.HRIS.Attendance>.GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
