using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class PantoneColorManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>
    {
        public PantoneColorManager()
        {
            this.Initialize();
        }
        public ulong Save(CCL.BusinessEntities.WPMS.PantoneColor IP_obj_PantoneColor, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_PantoneColorCode = 0;
            System.String lcl_str_Sequence = IP_obj_PantoneColor.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_PantoneColorCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_PantoneColor.PantoneColorCode = lcl_ui64_ID;
                System.String lcl_str_SqlInsert = IP_obj_PantoneColor.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);
                lcl_obj_DBManager.CommitTransaction();
                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_PantoneColorCode;
        }

        public ulong Save(CCL.BusinessEntities.WPMS.PantoneColor IP_obj_PantoneColor)
        {
            System.UInt64 lcl_ui64_PantoneColorCode = 0;
            System.String lcl_str_Sequence = IP_obj_PantoneColor.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_str_Sequence);
            lcl_ui64_PantoneColorCode = this.ExceptionManager.Process<System.UInt64>(() =>
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

                    IP_obj_PantoneColor.PantoneColorCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_PantoneColor.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_PantoneColorCode;
        }

        public CCL.BusinessEntities.WPMS.PantoneColor Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColor = null;

            lcl_obj_PantoneColor = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("Select * From WPMS_PANTONE_COLOR Where PANTONE_COLOR_CODE = {0}", IP_ui64_Code, (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerRManager.Get(Customer_Code,DBManger)) : Error Retrieving Buyer Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                lcl_obj_PantoneColorTmp.PantoneColorCode = IP_ui64_Code;
                lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                
                lcl_obj_Reader.Close();
                return lcl_obj_PantoneColorTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_PantoneColor;
        }

        public CCL.BusinessEntities.WPMS.PantoneColor Get(ulong IP_ui64_Code)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantonColor = null;
            lcl_obj_PantonColor = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(System.String.Format("Select * From WPMS_BUYER Where BUYER_CODE = {0}", IP_ui64_Code, SilkERP360.CCL.Enums.Status.Active));
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (BuyerManager.Get(ID)) : No Buyer Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                    lcl_obj_PantoneColorTmp.PantoneColorCode = IP_ui64_Code;
                    lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                    lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                    lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                    return lcl_obj_PantoneColorTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PantonColor;
        }

        public CCL.BusinessEntities.WPMS.PantoneColor Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColor = null;

            lcl_obj_PantoneColor = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);

                if (lcl_obj_Reader.HasRows == false)
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerManager.Get(SqlQuery,DBManger)) : Error Retrieving Buyer Data!");
                }
                lcl_obj_Reader.Read();
                SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                lcl_obj_PantoneColorTmp.PantoneColorCode = System.UInt64.Parse(lcl_obj_Reader["PANTONE_COLOR_CODE"].ToString());
                lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                return lcl_obj_PantoneColorTmp;
            }, "BMLExceptionPolicy");
            return lcl_obj_PantoneColor;
        }

        public CCL.BusinessEntities.WPMS.PantoneColor Get(string IP_str_SqlQuery)
        {
            SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColor = null;
            lcl_obj_PantoneColor = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (BuyerManager.Get(SqlQuery)) : No Company Data Found In The Database!!!");
                    }
                    SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                    lcl_obj_PantoneColorTmp.PantoneColorCode = System.UInt64.Parse(lcl_obj_Reader["PANTONE_COLOR_CODE"].ToString());
                    lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                    lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                    lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_Reader.Close();
                    return lcl_obj_PantoneColorTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_PantoneColor;
        }

        public List<CCL.BusinessEntities.WPMS.PantoneColor> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor> lcl_objLst_PantoneColor = null;

            lcl_objLst_PantoneColor = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_Reader.HasRows))
                {
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error BuyerManager.GetList(SqlQuery,DBManager)) : No Company Data Found In The Database!!!");
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor> lcl_objLst_PantoneColorTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                    lcl_obj_PantoneColorTmp.PantoneColorCode = System.UInt64.Parse(lcl_obj_Reader["PANTONE_COLOR_CODE"].ToString());
                    lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                    lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                    lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                    lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                    lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_objLst_PantoneColorTmp.Add(lcl_obj_PantoneColorTmp);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_PantoneColorTmp;

            }, "BMLExceptionPolicy");
            return lcl_objLst_PantoneColor;
        }

        public List<CCL.BusinessEntities.WPMS.PantoneColor> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PantoneColor> lcl_objlist_PantoneColor = null;
            lcl_objlist_PantoneColor = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PantoneColor>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PantoneColor> lcl_objlist_PantoneColorTmp = new
                    System.Collections.Generic.List<CCL.BusinessEntities.WPMS.PantoneColor>();
                    System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_Reader.HasRows))
                    {
                        return lcl_objlist_PantoneColorTmp;
                    }

                    while (lcl_obj_Reader.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor lcl_obj_PantoneColorTmp = new SilkERP360.CCL.BusinessEntities.WPMS.PantoneColor();
                        lcl_obj_PantoneColorTmp.PantoneColorCode = System.UInt64.Parse(lcl_obj_Reader["PANTONE_COLOR_CODE"].ToString());
                        lcl_obj_PantoneColorTmp.PantoneColorName = lcl_obj_Reader["PANTONE_COLOR_NAME"].ToString();
                        lcl_obj_PantoneColorTmp.Pantone = lcl_obj_Reader["PANTONE_COLOR"].ToString();
                        lcl_obj_PantoneColorTmp.RGB = lcl_obj_Reader["RGB"].ToString();
                        lcl_obj_PantoneColorTmp.Hex = lcl_obj_Reader["HEX"].ToString();
                        lcl_obj_PantoneColorTmp.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_Reader["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_objlist_PantoneColorTmp.Add(lcl_obj_PantoneColorTmp);
                    }
                    lcl_obj_Reader.Close();
                    return lcl_objlist_PantoneColorTmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_PantoneColor;
        }
    }
}
