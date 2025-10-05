using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SCPM
{
    public class VendorManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SCPM.Vendor>
    {
        public ulong Save(CCL.BusinessEntities.SCPM.Vendor IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.SCPM.Vendor IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Vendor Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Vendor Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Vendor Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.SCPM.Vendor Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.SCPM.Vendor> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Vendor> lcl_objLst_Vendors = null;
            lcl_objLst_Vendors = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Vendor>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(dr.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Vendor.GetList(SqlQuery,DBManager)) : No Section Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Vendor> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Vendor>();
                while (dr.Read())
                {
                    SilkERP360.CCL.BusinessEntities.SCPM.Vendor lcl_obj = new SilkERP360.CCL.BusinessEntities.SCPM.Vendor();
                    lcl_obj.VendorCode = System.UInt64.Parse(dr["VENDOR_CODE"].ToString());
                    lcl_obj.CompanyCode = System.UInt64.Parse(dr["COMPANY_CODE"].ToString());
                    lcl_obj.Name = dr["NAME"].ToString();
                    lcl_obj.Status = (SilkERP360.CCL.Enums.Status)System.UInt16.Parse(dr["STATUS"].ToString());
                    lcl_obj_ListTmp.Add(lcl_obj);
                }
                dr.Close();
                return lcl_obj_ListTmp;
            }, "BMLExceptionPolicy");
            return lcl_objLst_Vendors;
        }

        public List<CCL.BusinessEntities.SCPM.Vendor> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
