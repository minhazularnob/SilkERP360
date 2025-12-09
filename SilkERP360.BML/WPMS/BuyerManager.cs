using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class BuyerManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>
    {
        public BuyerManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer, System.Object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_BuyerCode = 0;
            System.String lcl_str_Sequence = lcl_obj_Buyer.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                lcl_obj_Buyer.BuyerCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = lcl_obj_Buyer.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_BuyerCode;
        }

        public ulong Save(CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer)
        {
            System.UInt64 lcl_ui64_BuyerCode = 0;
            System.String lcl_str_Sequence = lcl_obj_Buyer.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_BuyerCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    lcl_obj_Buyer.BuyerCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = lcl_obj_Buyer.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_BuyerCode;
        }

        public CCL.BusinessEntities.WPMS.Buyer Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = null;

            lcl_obj_Buyer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_BUYER Where BUYER_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerRManager.Get(Customer_Code,DBManger)) : Error Retrieving Buyer Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_BuyerTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                //lcl_obj_BuyerTmp.CustomerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                lcl_obj_BuyerTmp.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                lcl_obj_BuyerTmp.Address = lcl_obj_Reader["ADDRESS"].ToString();
                lcl_obj_BuyerTmp.Phone = lcl_obj_Reader["PHONE"].ToString();
                lcl_obj_BuyerTmp.ContactPerson = lcl_obj_Reader["CONATACT_PERSON"].ToString();
                lcl_obj_BuyerTmp.Email = lcl_obj_Reader["EMAIL"].ToString();
                //lcl_obj_BuyerTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                lcl_obj_BuyerTmp.Country = lcl_obj_Reader["COUNTRY"].ToString();
                lcl_obj_Reader.Close();
                return lcl_obj_BuyerTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Buyer;
        }

        public CCL.BusinessEntities.WPMS.Buyer Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = null;
            lcl_obj_Buyer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_BUYER Where BUYER_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (BuyerManager.Get(ID)) : No Buyer Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_BuyerTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                    //lcl_obj_BuyerTmp.CustomerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_BuyerTmp.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                    lcl_obj_BuyerTmp.Address = lcl_obj_Reader["ADDRESS"].ToString();
                    lcl_obj_BuyerTmp.Phone = lcl_obj_Reader["PHONE"].ToString();
                    lcl_obj_BuyerTmp.ContactPerson = lcl_obj_Reader["CONATACT_PERSON"].ToString();
                    lcl_obj_BuyerTmp.Email = lcl_obj_Reader["EMAIL"].ToString();
                    //lcl_obj_BuyerTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_BuyerTmp.Country = lcl_obj_Reader["COUNTRY"].ToString();
                    lcl_obj_Reader.Close();
                    return lcl_obj_BuyerTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Buyer;
        }

        public CCL.BusinessEntities.WPMS.Buyer Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = null;

            lcl_obj_Buyer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerManager.Get(SqlQuery,DBManger)) : Error Retrieving Buyer Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_BuyerTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                //lcl_obj_BuyerTmp.CustomerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                lcl_obj_BuyerTmp.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                lcl_obj_BuyerTmp.Address = lcl_obj_Reader["ADDRESS"].ToString();
                lcl_obj_BuyerTmp.Phone = lcl_obj_Reader["PHONE"].ToString();
                lcl_obj_BuyerTmp.ContactPerson = lcl_obj_Reader["CONATACT_PERSON"].ToString();
                lcl_obj_BuyerTmp.Email = lcl_obj_Reader["EMAIL"].ToString();
                //lcl_obj_BuyerTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                lcl_obj_BuyerTmp.Country = lcl_obj_Reader["COUNTRY"].ToString();
                lcl_obj_Reader.Close();
                return lcl_obj_BuyerTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_Buyer;
        }

        public CCL.BusinessEntities.WPMS.Buyer Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = null;
            lcl_obj_Buyer = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (BuyerManager.Get(SqlQuery)) : No Company Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_BuyerTmp = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                    //lcl_obj_BuyerTmp.CustomerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_BuyerTmp.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                    lcl_obj_BuyerTmp.Address = lcl_obj_Reader["ADDRESS"].ToString();
                    lcl_obj_BuyerTmp.Phone = lcl_obj_Reader["PHONE"].ToString();
                    lcl_obj_BuyerTmp.ContactPerson = lcl_obj_Reader["CONATACT_PERSON"].ToString();
                    lcl_obj_BuyerTmp.Email = lcl_obj_Reader["EMAIL"].ToString();
                    //lcl_obj_BuyerTmp.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_BuyerTmp.Country = lcl_obj_Reader["COUNTRY"].ToString();
                    lcl_obj_Reader.Close();
                    return lcl_obj_Buyer;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Buyer;
        }

        public System.Collections.Generic.List<CCL.BusinessEntities.WPMS.Buyer> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Buyer = null;

            lcl_objLst_Buyer = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_Reader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerManager.GetList(SqlQuery,DBManager)) : No Company Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_BuyerTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                    //lcl_obj_Buyer.CustomerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_Buyer.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                    lcl_obj_Buyer.Address = lcl_obj_Reader["ADDRESS"].ToString();
                    lcl_obj_Buyer.Phone = lcl_obj_Reader["PHONE"].ToString();
                    lcl_obj_Buyer.ContactPerson = lcl_obj_Reader["CONATACT_PERSON"].ToString();
                    lcl_obj_Buyer.Email = lcl_obj_Reader["EMAIL"].ToString();
                    //lcl_obj_Buyer.Status = System.UInt16.Parse(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_Buyer.Country = lcl_obj_Reader["COUNTRY"].ToString();
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_BuyerTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_Buyer;
        }

        public List<CCL.BusinessEntities.WPMS.Buyer> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Buyer = null;

            using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            {
                if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.InternalResource.Open();
                }
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
           
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_BuyerTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.Buyer lcl_obj_Buyer = new SilkERP360.CCL.BusinessEntities.WPMS.Buyer();
                    lcl_obj_Buyer.BuyerCode = System.UInt64.Parse(lcl_obj_Reader["BUYER_CODE"].ToString());
                    lcl_obj_Buyer.CompanyName = lcl_obj_Reader["COMPANY_NAME"].ToString();
                    lcl_obj_Buyer.Address = lcl_obj_Reader["ADDRESS"].ToString();
                    lcl_obj_Buyer.Phone = lcl_obj_Reader["PHONE"].ToString();
                    lcl_obj_Buyer.ContactPerson = lcl_obj_Reader["CONTACT_PERSON"].ToString();
                    lcl_obj_Buyer.Email = lcl_obj_Reader["EMAIL"].ToString();
                    //lcl_obj_Buyer.IsActive = SilkERP360.CCL.Enums.YesNo(lcl_obj_Reader["STATUS"].ToString());
                    lcl_obj_Buyer.Country = lcl_obj_Reader["COUNTRY"].ToString();
                   
                    lcl_objLst_BuyerTmp.Add(lcl_obj_Buyer);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_BuyerTmp;
                return lcl_objLst_Buyer;
            }
        }
    }
}

