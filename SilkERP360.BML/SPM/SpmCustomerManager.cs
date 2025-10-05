using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.SPM
{
    public class SpmCustomerManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
    SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer>
    {
        public SpmCustomerManager()
       {
           this.Initialize();
       }


        public ulong Save(CCL.BusinessEntities.SPM.SpmCustomer IP_obj_SpmCustomer, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_CustomerCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmCustomer.GetSequence());
            lcl_ui64_CustomerCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_SpmCustomer.CustomerCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_SpmCustomer.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_CustomerCode;
        }

        public ulong Save(CCL.BusinessEntities.SPM.SpmCustomer IP_obj_SpmCustomer)
        {
            System.UInt64 lcl_ui64_CustomerCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_SpmCustomer.GetSequence());
            lcl_ui64_CustomerCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_SpmCustomer.CustomerCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_SpmCustomer.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_CustomerCode;
        }

        public CCL.BusinessEntities.SPM.SpmCustomer Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_SpmCustomer = null;
            lcl_obj_SpmCustomer = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SpmCustomer>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_CUSTOMER WHERE CUSTOMER_CODE = {0}", IP_ui64_Code);
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new CCL.BusinessEntities.SPM.SpmCustomer();
                lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());

                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmCustomer;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmCustomer;
        }

        public CCL.BusinessEntities.SPM.SpmCustomer Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_SpmCustomer = null;
            lcl_obj_SpmCustomer = this.ExceptionManager.Process<CCL.BusinessEntities.SPM.SpmCustomer>(() =>
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
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SPM_CUSTOMER WHERE CUSTOMER_CODE = {0}", IP_ui64_Code);
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new CCL.BusinessEntities.SPM.SpmCustomer();
                    lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                    lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmCustomer;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmCustomer;
        }

        public CCL.BusinessEntities.SPM.SpmCustomer Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_SpmCustomer = null;
            lcl_obj_SpmCustomer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer>(() =>
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
                SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer();
                lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpSpmCustomer;
            }, "BMLExceptionPolicy");
            return lcl_obj_SpmCustomer;
        }

        public CCL.BusinessEntities.SPM.SpmCustomer Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_MedicalInfo = null;
            lcl_obj_MedicalInfo = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer>(() =>
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
                    SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new SilkERP360.CCL.BusinessEntities.SPM.SpmCustomer();
                    lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                    lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpSpmCustomer;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_MedicalInfo;
        }

        public List<CCL.BusinessEntities.SPM.SpmCustomer> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer> lcl_objlist_SpmCustomerList = null;
            lcl_objlist_SpmCustomerList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer> lcl_objlist_TmpSpmCustomerList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer>();
                System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpSpmCustomerList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new CCL.BusinessEntities.SPM.SpmCustomer();
                    lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                    lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                    lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                    lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                    lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                    lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                    lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                    lcl_objlist_TmpSpmCustomerList.Add(lcl_obj_TmpSpmCustomer);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpSpmCustomerList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmCustomerList;
        }

        public List<CCL.BusinessEntities.SPM.SpmCustomer> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer> lcl_objlist_SpmCustomerList = null;
            lcl_objlist_SpmCustomerList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer> lcl_objlist_TmpSpmCustomerList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.SPM.SpmCustomer>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpSpmCustomerList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_TmpSpmCustomer = new CCL.BusinessEntities.SPM.SpmCustomer();
                        lcl_obj_TmpSpmCustomer.CustomerCode = System.UInt64.Parse(lcl_obj_dr["CUSTOMER_CODE"].ToString());
                        lcl_obj_TmpSpmCustomer.CompanyName = lcl_obj_dr["COMPANY_NAME"].ToString();
                        lcl_obj_TmpSpmCustomer.Address = lcl_obj_dr["ADDRESS"].ToString();
                        lcl_obj_TmpSpmCustomer.DeliveryAddress = lcl_obj_dr["ADDRESS"].ToString();
                        lcl_obj_TmpSpmCustomer.ContactPerson = lcl_obj_dr["CONTACT_PERSON"].ToString();
                        lcl_obj_TmpSpmCustomer.Phone = lcl_obj_dr["CONTACT_PERSON"].ToString();
                        lcl_obj_TmpSpmCustomer.Mobile = lcl_obj_dr["MOBILE"].ToString();
                        lcl_obj_TmpSpmCustomer.ShortName = lcl_obj_dr["SHORT_NAME"].ToString();
                        lcl_obj_TmpSpmCustomer.ScJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SC_JOB_ORDER_SEED"].ToString());
                        lcl_obj_TmpSpmCustomer.SmJobOrderSeed = System.UInt64.Parse(lcl_obj_dr["SM_JOB_ORDER_SEED"].ToString());
                        lcl_obj_TmpSpmCustomer.IsActive = (SilkERP360.CCL.Enums.YesNo)System.UInt16.Parse(lcl_obj_dr["IS_ACTIVE"].ToString());
                        lcl_objlist_TmpSpmCustomerList.Add(lcl_obj_TmpSpmCustomer);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpSpmCustomerList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_SpmCustomerList;
        }
    }
}
