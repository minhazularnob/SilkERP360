using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace SilkERP360.CCL.Security
{
    /// <summary>
    /// This class will act as a repository for the ClientRequest object
    /// </summary>
    public static class ClientRequestRepository
    {
        private static System.Collections.Generic.List<SilkERP360.CCL.Security.ClientRequest> m_obj_Repository = new System.Collections.Generic.List<ClientRequest>();

        //ClientRequestRepository()
        //{
        //    SilkERP360.CCL.Security.ClientRequestRepository.m_obj_Repository = new System.Collections.Generic.List<ClientRequest>();
        //}

        public static void Add(SilkERP360.CCL.Security.ClientRequest IP_obj_ClientRequest)
        {
            SilkERP360.CCL.Security.ClientRequestRepository.m_obj_Repository.Add(IP_obj_ClientRequest);
        }

        //public static SilkERP360.CCL.Misc.FunctionResponse Add(ref System.Web.HttpRequest IP_obj_HTTPRequest)
        //{
        //    try
        //    {
        //        if (IP_obj_HTTPRequest == null)
        //        {
        //            throw new SilkERP360.CCL.ExceptionManagement.Exceptions.SilkERPApplicationException("Invalid HTTPRequest Object Provided!!!");
        //        }
        //        //create the new ClientRequest object
        //        SilkERP360.CCL.Security.ClientRequest lcl_obj_ClientRequest = new ClientRequest(IP_obj_HTTPRequest.UserHostAddress, System.DateTime.Now,
        //                                                                                        IP_obj_HTTPRequest.Path);

        //        //Check if newly created ClientRequest Already exists in terms of IP address. If Exists, remove the existing object and insert the new one
        //        //as we always have to check for the last incoming request
        //        SilkERP360.CCL.Security.ClientRequest lcl_obj_RemovableClientRequest;
        //        foreach (SilkERP360.CCL.Security.ClientRequest lcl_obj_ClientRequestTmp in SilkERP360.CCL.Security.ClientRequestRepository.m_obj_Repository)
        //        {

        //        }
                
        //        SilkERP360.CCL.Security.ClientRequestRepository.m_obj_Repository.Add(lcl_obj_ClientRequest);
        //    }
        //    catch (SilkERP360.CCL.ExceptionManagement.Exceptions.SilkERPApplicationException Ex1)
        //    {
        //    }
        //    catch (System.Exception Ex2)
        //    {
        //    }

        //    //SilkERP360.CCL.Security.ClientRequestRepository.m_obj_Repository.Add(IP_obj_ClientRequest);
        //}
    }
}
