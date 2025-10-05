using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Misc
{
    public static class SilkWebServiceCollection
    {
        private static System.Collections.Generic.List<SilkERP360.CCL.Misc.SilkWebService> m_obj_Collections = new List<SilkERP360.CCL.Misc.SilkWebService>();

        //static SilkWebServiceCollection()
        //{
        //    SilkWebServiceCollection.m_obj_Collections = 
        //}

        public static void Add(SilkERP360.CCL.Misc.SilkWebService IP_obj_SilkWebService)
        {
            SilkWebServiceCollection.m_obj_Collections.Add(IP_obj_SilkWebService);
        }

        public static System.String getPhysicalPath(System.UInt64 IP_ui64_WebServiceCode)
        {
            try
            {
                return "";
            }
            catch (System.Exception Ex)
            {
                return "";
            }
        }

        public static System.String getVirtualPath(System.UInt64 IP_ui64_WebServiceCode)
        {
            try
            {
                System.String lcl_str_VirtualPath = System.String.Empty;
                foreach (SilkERP360.CCL.Misc.SilkWebService lcl_obj_SilkWebService in SilkERP360.CCL.Misc.SilkWebServiceCollection.m_obj_Collections)
                {
                    //if (lcl_obj_SilkWebService.WebServiceCode == IP_ui64_WebServiceCode)
                    //{
                    //    lcl_str_VirtualPath = lcl_obj_SilkWebService.VirtualPath;
                    //    break;
                    //}
                }
                if (lcl_str_VirtualPath == System.String.Empty)
                {
                    //VirtualPath not found or Provided WebServiceCode is not correct
                    System.String lcl_str_ErrMsg = System.String.Format("Virtual Path For Provided WebService {0} Not Found in The Collection!!!", IP_ui64_WebServiceCode.ToString());
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.SilkERPApplicationException(lcl_str_ErrMsg);
                }
                return "";
            }
            catch (SilkERP360.CCL.ExceptionManagement.Exceptions.SilkERPApplicationException Ex1)
            {
                return "";
            }
            catch (System.Exception Ex2)
            {
                return "";
            }
        }
    }
}
