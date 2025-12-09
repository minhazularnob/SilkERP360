using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class RoosterMasterManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>
    {

       public RoosterMasterManager()
        {
            
            this.Initialize();
        }    
                       
     

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster IP_obj_RoosterMaster, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_RoosTerMaseterCode = 0;

            lcl_ui64_RoosTerMaseterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                OracleParameter lcl_obj_RoosTerMaseterCode = new OracleParameter("v_RoosTerMaseterCode", OracleDbType.Int64);
                lcl_obj_RoosTerMaseterCode.Direction = System.Data.ParameterDirection.Output;
                //lcl_obj_RoosTerMaseterCode.Value = lcl_obj_RoosterMaster.RoosterMaseterCode;

                OracleParameter lcl_obj_ShiftCode = new OracleParameter("v_ShiftCode", OracleDbType.Int64);
                lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ShiftCode.Value = IP_obj_RoosterMaster.ShiftCode;

                OracleParameter lcl_obj_DepartmentCode = new OracleParameter("v_DepartmentCode", OracleDbType.Int64);
                lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_DepartmentCode.Value = IP_obj_RoosterMaster.DepartmentCode;

                OracleParameter lcl_obj_RosterDateFrom = new OracleParameter("v_RosterDateFrom", OracleDbType.Date);
                lcl_obj_RosterDateFrom.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterDateFrom.Value = IP_obj_RoosterMaster.RosterDateFrom;

                OracleParameter lcl_obj_RosterDateTo = new OracleParameter("v_RosterDateTo", OracleDbType.Date);
                lcl_obj_RosterDateTo.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterDateTo.Value = IP_obj_RoosterMaster.RosterDateTo;

                OracleParameter lcl_obj_RosterChangeDate = new OracleParameter("v_RosterChangeDate", OracleDbType.Date);
                lcl_obj_RosterChangeDate.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_RosterChangeDate.Value = IP_obj_RoosterMaster.RosterChangeDate;


                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RoosTerMaseterCode, lcl_obj_ShiftCode, lcl_obj_DepartmentCode, lcl_obj_ShiftCode, lcl_obj_RosterDateFrom, lcl_obj_RosterDateTo, lcl_obj_RosterChangeDate };
                IP_obj_DBManager.ExecuteStoredProcedure("HRIS_INSERT_RoosterMaster", lcl_obj_SP_Parameters);


                

                return System.UInt64.Parse(lcl_obj_RoosTerMaseterCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_RoosTerMaseterCode;
        }

        public ulong Save(SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster IP_obj_RoosterMaster)
        {
            System.UInt64 lcl_ui64_RoosTerMaseterCode = 0;

            lcl_ui64_RoosTerMaseterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
               // using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                using (var lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource ) 
            
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.Open();
                    }

                    OracleParameter lcl_obj_RoosTerMaseterCode = new OracleParameter("p_ROOSTER_MASTER_CODE", OracleDbType.Int64);
                    lcl_obj_RoosTerMaseterCode.Direction = System.Data.ParameterDirection.Output;
                    //lcl_obj_RoosTerMaseterCode.Value =IP_obj_RoosterMaster.EmployeeRooster;

                    OracleParameter lcl_obj_ShiftCode = new OracleParameter("p_SHIFT_CODE", OracleDbType.Int64);
                    lcl_obj_ShiftCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ShiftCode.Value = IP_obj_RoosterMaster.ShiftCode ;

                    OracleParameter lcl_obj_DepartmentCode = new OracleParameter("p_DEPARTMENT_CODE", OracleDbType.Int64);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DepartmentCode.Value = IP_obj_RoosterMaster.DepartmentCode;

                    OracleParameter lcl_obj_RosterDateFrom = new OracleParameter("p_ROOSTER_DATE_FROM", OracleDbType.Date);
                    lcl_obj_RosterDateFrom.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterDateFrom.Value = IP_obj_RoosterMaster.RosterDateFrom;

                    OracleParameter lcl_obj_RosterDateTo = new OracleParameter("p_ROOSTER_DATE_TO", OracleDbType.Date);
                    lcl_obj_RosterDateTo.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterDateTo.Value = IP_obj_RoosterMaster.RosterDateTo;

                    OracleParameter lcl_obj_RosterChangeDate = new OracleParameter("p_SHIFT_CHANGE_DATE", OracleDbType.Date);
                    lcl_obj_RosterChangeDate.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_RosterChangeDate.Value = IP_obj_RoosterMaster.RosterChangeDate ;


                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_RoosTerMaseterCode, lcl_obj_ShiftCode, lcl_obj_DepartmentCode,  lcl_obj_RosterDateFrom, lcl_obj_RosterDateTo, lcl_obj_RosterChangeDate };
                   
                  


                    lcl_obj_DBManager.ExecuteStoredProcedure("ROOSTER_MASTER_IU", lcl_obj_SP_Parameters);

                    UInt64 TmpRosterMastercode = System.UInt64.Parse(lcl_obj_RoosTerMaseterCode.Value.ToString());

                    int dtDiff = Convert.ToInt16((IP_obj_RoosterMaster.RosterDateTo - IP_obj_RoosterMaster.RosterDateFrom).Days);
                    

                    //save Employee Rooster
                    SilkERP360.BML.HRIS.EmployeeRoosterManager lcl_obj_EmployeeRoosterManager = new SilkERP360.BML.HRIS.EmployeeRoosterManager();
                    
                        foreach (SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster in IP_obj_RoosterMaster.EmployeeRooster)
                        {
                            for (int i = 0; i <= dtDiff; i++)
                            {

                            lcl_obj_EmployeeRooster.EmployeeRoosterMasterCode = TmpRosterMastercode;
                            lcl_obj_EmployeeRooster.DutyDate = IP_obj_RoosterMaster.RosterDateFrom.AddDays(i);

                            lcl_obj_EmployeeRoosterManager.Save(lcl_obj_EmployeeRooster, lcl_obj_DBManager);
                        }


           
                     }
                    
                    
                   lcl_obj_DBManager.CommitTransaction();


                   return TmpRosterMastercode;
                   
                }
                
            }, "BMLExceptionPolicy");

            return lcl_ui64_RoosTerMaseterCode;
        }
        public ulong AddToRooster(System.UInt64 IP_ui64_RoosterMasterCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 lcl_ui64_RoosTerMaseterCode = 0;

            lcl_ui64_RoosTerMaseterCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                // using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                using (var lcl_obj_DBManager = (SilkERP360.DAL.DBManager)SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject().InternalResource)
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format("Select ROOSTER_DATE_FROM,ROOSTER_DATE_TO from rooster_master Where rooster_master_code={0}", IP_ui64_RoosterMasterCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_RoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RoosterMasterManager.AddToRooster(IP_ui64_RoosterMasterCode,DBManger)) : Error Retrieving RoosterMasterManager Data!");
                }
                lcl_obj_RoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMaster = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMaster.RosterDateFrom = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                lcl_obj_RoosterMaster.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());


                    UInt64 TmpRosterMastercode = IP_ui64_RoosterMasterCode;

                    int dtDiff = Convert.ToInt16((lcl_obj_RoosterMaster.RosterDateTo -lcl_obj_RoosterMaster.RosterDateFrom).Days);


                    //save Employee Rooster
                    SilkERP360.BML.HRIS.EmployeeRoosterManager lcl_obj_EmployeeRoosterManager = new SilkERP360.BML.HRIS.EmployeeRoosterManager();
                    SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster lcl_obj_EmployeeRooster = new SilkERP360.CCL.BusinessEntities.HRIS.EmployeeRooster();

                        for (int i = 0; i <= dtDiff; i++)
                        {

                            lcl_obj_EmployeeRooster.EmployeeRoosterMasterCode = TmpRosterMastercode;
                            lcl_obj_EmployeeRooster.EmployeeCode = IP_ui64_EmployeeCode;
                            lcl_obj_EmployeeRooster.DutyDate = lcl_obj_RoosterMaster.RosterDateFrom.AddDays(i);

                            lcl_obj_EmployeeRoosterManager.Save(lcl_obj_EmployeeRooster, lcl_obj_DBManager);
                        }


                    lcl_obj_DBManager.CommitTransaction();


                    return TmpRosterMastercode;

                }

            }, "BMLExceptionPolicy");

            return lcl_ui64_RoosTerMaseterCode;
        }
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
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_RoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RoosterMasterManager.Get(ID,DBManger)) : Error Retrieving RoosterMasterManager Data!");
                }
                lcl_obj_RoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosterMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
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
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From ROOSTER_MASTER Where ROOSTER_MASTER_CODE = {0} and STATUS = {1} and IS_DELETED = 1", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_RoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMasterManager.Get(ID)) : No RoosterMasterManager Data Found In The Database!!!");
                    }

                    SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                    lcl_obj_RoosterMasterTmp.RoosterMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterDateFrom = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                    lcl_obj_RoosterMasterReader.Close();
                    return lcl_obj_RoosterMasterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }


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
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_RoosterMasterReader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error RoosterMasterManager.Get(SqlQuery,DBManger)) : Error Retrieving RoosterMasterManager Data!");
                }
                lcl_obj_RoosterMasterReader.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                lcl_obj_RoosterMasterTmp.RoosterMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
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
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_RoosterMasterReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format(IP_str_SqlQuery));
                    if (!(lcl_obj_RoosterMasterReader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (RoosterMasterManager.Get(SqlQuery)) : No RoosterMasterManager Data Found In The Database!!!");
                    }

                    SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster lcl_obj_RoosterMasterTmp = new SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster();
                    lcl_obj_RoosterMasterTmp.RoosterMaseterCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["ROOSTER_MASTER_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.ShiftCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["SHIFT_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.DepartmentCode = System.UInt64.Parse(lcl_obj_RoosterMasterReader["DEPARTMENT_CODE"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterDateFrom = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_FROM"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterDateTo = System.DateTime.Parse(lcl_obj_RoosterMasterReader["ROOSTER_DATE_TO"].ToString());
                    lcl_obj_RoosterMasterTmp.RosterChangeDate = System.DateTime.Parse(lcl_obj_RoosterMasterReader["SHIFT_CHANGE_DATE"].ToString());
                    lcl_obj_RoosterMasterReader.Close();
                    return lcl_obj_RoosterMasterTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_RoosterMaster;
        }
       
        public List<CCL.BusinessEntities.HRIS.RoosterMaster> GetList(string IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster> lcl_objLst_RoosterMaster = null;
            lcl_objLst_RoosterMaster = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.RoosterMaster>>(() =>
            {
                if (IP_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    IP_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
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
                    lcl_obj_RossterMaster.RoosterMaseterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
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
                    Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
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
                        lcl_obj_RossterMaster.RoosterMaseterCode = System.UInt64.Parse(dr["ROOSTER_MASTER_CODE"].ToString());
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

        public ulong Save(CCL.BusinessEntities.HRIS.RoosterMaster IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.RoosterMaster Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.RoosterMaster Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.RoosterMaster> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong RemoveFromRooster(System.UInt64 IP_ui64_RoosterMasterCode, System.UInt64 IP_ui64_EmployeeCode)
        {
            System.UInt64 IP_ui64_holidayMstCodeTemp = 0;
            IP_ui64_holidayMstCodeTemp = this.ExceptionManager.Process<System.UInt64>(() =>
            {

                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_SqlQuery = System.String.Format(@"Update EMPLOYEE_ROOSTER Set  IS_DELETED=0 where ROOSTER_MASTER_CODE={0} And EMPLOYEE_CODE={1}", IP_ui64_RoosterMasterCode, IP_ui64_EmployeeCode);
                    lcl_obj_DBManager.InternalResource.ExecuteNonQuery(lcl_str_SqlQuery);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();

                    return IP_ui64_holidayMstCodeTemp = IP_ui64_RoosterMasterCode;
                }
            }, "BMLExceptionPolicy");
            return IP_ui64_holidayMstCodeTemp;
        }
    }
}
