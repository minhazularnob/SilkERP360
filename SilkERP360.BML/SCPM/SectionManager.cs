using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class SectionManger : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.Section>
    {
        public SectionManger()
        {
            this.Initialize();
        }
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_list_details = null;
            lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    dr.Close();
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Section Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.Section();
                    lcl_obj.SectionCode = System.UInt64.Parse(dr["SECTION_CODE"].ToString());
                    lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj.Name = dr["NAME"].ToString();
                    lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_list_details;
        }

        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        //{
        //    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_list_details = null;
        //    lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Section>>(() =>
        //    {
        //        SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
        //        if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
        //        {
        //            lcl_obj_DBManager.Open();
        //        }
        //        Oracle.ManagedDataAccess.Client.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
        //        if (!(dr.HasRows))
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (EmployeeWeekendManager.GetList(SqlQuery,DBManager)) : No Section Data Found In The Database!!!");
        //        }
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Section> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Section>();
        //        while (dr.Read())
        //        {
        //            SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj = new SilkERP360.CCL.BusinessEntities.HRIS.Section();
        //            lcl_obj.SectionCode = System.UInt64.Parse(dr["SECTION_CODE"].ToString());
        //            lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
        //            lcl_obj.Name = dr["NAME"].ToString();
        //            lcl_obj.Status = System.UInt16.Parse(dr["STATUS"].ToString());
        //            lcl_obj_ListTmp.Add(lcl_obj);
        //        }
        //        dr.Close();
        //        return lcl_obj_ListTmp;
        //    }, "BMLExceptionPolicy");
        //    return lcl_list_details;
        //}
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj_Section, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_Section = 0;
            lcl_ui64_Section = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                OracleParameter lcl_obj_SectionCode = new OracleParameter("p_SECTION_CODE", OracleDbType.Int64);
                lcl_obj_SectionCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_SectionCode.Value = lcl_obj_Section.SectionCode;
                OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_CompanyCode.Value = lcl_obj_Section.CompanyCode;
                OracleParameter lcl_obj_Name = new OracleParameter("p_NAME", OracleDbType.NVarchar2, 512);
                lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Name.Value = lcl_obj_Section.Name;
                OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_Status.Value = lcl_obj_Section.Status;
                OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SectionCode, lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_Status };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.Section_IU", lcl_obj_SP_Parameters);
                return System.UInt64.Parse(lcl_obj_SectionCode.Value.ToString());
            }, "BMLExceptionPolicy");
            return lcl_ui64_Section;
        }
        public ulong Save(SilkERP360.CCL.BusinessEntities.SCPM.Section lcl_obj_Section)
        {
            System.UInt64 lcl_ui64_Section = 0;
            lcl_ui64_Section = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    OracleParameter lcl_obj_SectionCode = new OracleParameter("p_SECTION_CODE", OracleDbType.Int64);
                    lcl_obj_SectionCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_SectionCode.Value = lcl_obj_Section.SectionCode;
                    OracleParameter lcl_obj_CompanyCode = new OracleParameter("p_COMPANY_CODE", OracleDbType.Int64);
                    lcl_obj_CompanyCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_CompanyCode.Value = lcl_obj_Section.CompanyCode;
                    OracleParameter lcl_obj_Name = new OracleParameter("p_NAME", OracleDbType.NVarchar2, 512);
                    lcl_obj_Name.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Name.Value = lcl_obj_Section.Name;
                    OracleParameter lcl_obj_Status = new OracleParameter("p_STATUS", OracleDbType.Int64);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj_Section.Status;
                    OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_SectionCode, lcl_obj_CompanyCode, lcl_obj_Name, lcl_obj_Status };
                    lcl_obj_DBManager.InternalResource.ExecuteStoredProcedure("HRIS.Section_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_SectionCode.Value.ToString());
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_Section;
        }


        public CCL.BusinessEntities.SCPM.Section Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Section Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Section Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Section Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.Section> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
