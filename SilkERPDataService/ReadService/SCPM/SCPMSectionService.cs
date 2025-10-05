using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;

namespace SilkERPDataService.ReadService.SCPM
{
    public class SCPMSectionService
    {

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> GetList(System.String IP_str_SqlQuery)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SCPMSection>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_SectionReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                        lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_SectionList.Add(lcl_obj_SCPMSection);
                    }
                    lcl_obj_SectionReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SqlQuery"></param>
        /// <param name="IP_obj_DBManager">Initialised & Open DBManager</param>
        /// <returns></returns>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> GetList(System.String IP_str_SqlQuery, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SCPMSection>();
                System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = IP_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (lcl_obj_SectionReader.HasRows == false)
                {
                    throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                }
                while (lcl_obj_SectionReader.Read())
                {
                    SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                    lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                    lcl_objList_SectionList.Add(lcl_obj_SCPMSection);
                }
                lcl_obj_SectionReader.Close();
                
                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }


        public SilkERPDataService.Containers.SCPM.SCPMSection GetSectionBySectionCode(System.UInt64 IP_ui64_SectionCode)
        {
            try
            {
                SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SCPMSection();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data for Section Code " + IP_ui64_SectionCode.ToString() +  " Not Found in the SilkERP database!!!");
                    }
                    lcl_obj_SectionReader.Read();
                    
                    SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                    lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                    lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                    lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                    //Inactive Sections will not come in the result set
                    lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                    
                    lcl_obj_SectionReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_obj_Section;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public SilkERPDataService.Containers.SCPM.SCPMSection GetSectionBySectionCode(System.UInt64 IP_ui64_SectionCode,SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                //SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_Section = new SilkERPDataService.Containers.SCPM.SCPMSection();
               
                System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE SECTION_CODE = {0} AND STATUS = {1}", IP_ui64_SectionCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_SectionReader.HasRows == false)
                {
                    throw new System.Exception("Section Data for Section Code " + IP_ui64_SectionCode.ToString() + " Not Found in the SilkERP database!!!");
                }
                lcl_obj_SectionReader.Read();

                SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                //Inactive Sections will not come in the result set
                lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;

                lcl_obj_SectionReader.Close();

                return lcl_obj_SCPMSection;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> GetSectionListByCompany(System.UInt64 IP_ui64_CompanyCode)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SCPMSection>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPDataService.Globals.SilkERPDatabaseConnectionString))
                {
                    lcl_obj_DBManager.Open();
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE COMPANY_CODE = {0} AND STATUS = {1}", IP_ui64_CompanyCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_SectionReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                        lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_SectionList.Add(lcl_obj_SCPMSection);
                    }
                    lcl_obj_SectionReader.Close();
                    lcl_obj_DBManager.CloseReader();
                    lcl_obj_DBManager.Close();
                }
                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> GetSectionListByCompany(System.UInt64 IP_ui64_CompanyCode, SilkERP360.DAL.DBManager IP_obj_DBManager)
        {
            try
            {
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCPMSection> lcl_objList_SectionList = new System.Collections.Generic.List<Containers.SCPM.SCPMSection>();
                using (SilkERP360.DAL.DBManager lcl_obj_DBManager = IP_obj_DBManager)
                {
                    System.String lcl_str_SqlQuery = System.String.Format("SELECT * FROM SCPM_SECTION WHERE COMPANY_CODE = {0} AND STATUS = {1}", IP_ui64_CompanyCode.ToString(), (System.UInt32)SilkERP360.CCL.Enums.Status.Active);
                    System.Data.OracleClient.OracleDataReader lcl_obj_SectionReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_SectionReader.HasRows == false)
                    {
                        throw new System.Exception("Section Data Not Found in the SilkERP database!!!");
                    }
                    while (lcl_obj_SectionReader.Read())
                    {
                        SilkERPDataService.Containers.SCPM.SCPMSection lcl_obj_SCPMSection = new Containers.SCPM.SCPMSection();
                        lcl_obj_SCPMSection._SectionCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["SECTION_CODE"].ToString());
                        lcl_obj_SCPMSection._CompanyCode_UI64 = System.UInt64.Parse(lcl_obj_SectionReader["COMPANY_CODE"].ToString());
                        lcl_obj_SCPMSection._Name_STR = lcl_obj_SectionReader["NAME"].ToString();
                        //Inactive Sections will not come in the result set
                        lcl_obj_SCPMSection._Status_ENM = SilkERP360.CCL.Enums.Status.Active;
                        lcl_objList_SectionList.Add(lcl_obj_SCPMSection);
                    }
                    lcl_obj_SectionReader.Close();
                    IP_obj_DBManager.CloseReader();
                }
                return lcl_objList_SectionList;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
