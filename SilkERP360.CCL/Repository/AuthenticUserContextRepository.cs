using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace SilkERP360.CCL.Repository
{
    public static class AuthenticUserContextRepository 
    {
        private static Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.ExceptionManager m_obj_ExceptionManager = null;
        private static Microsoft.Practices.Unity.UnityContainer m_obj_UnityContainer = null;
        private static System.Collections.Generic.List<SilkERP360.CCL.Repository.AuthenticUserContext> m_obj_Repository;
        static AuthenticUserContextRepository()
        {
            SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_UnityContainer = new Microsoft.Practices.Unity.UnityContainer();
            SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_UnityContainer.AddNewExtension<EnterpriseLibraryCoreExtension>();
            SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_ExceptionManager = SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_UnityContainer.Resolve<ExceptionManager>();
            AuthenticUserContextRepository.m_obj_Repository = new System.Collections.Generic.List<SilkERP360.CCL.Repository.AuthenticUserContext>();
        }

        public static System.Boolean IsSessionAlreadyLoggedIn(System.String IP_str_SessionID, System.String IP_str_SecurityToken)
        {
            System.Boolean lcl_b_Response = true;
            lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
                {
                    foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
                    {
                        if ((lcl_obj_AuthenticUserContext.SessionID.ToUpper().Equals(IP_str_SessionID.ToUpper())) &&
                            (lcl_obj_AuthenticUserContext.SecurityToken.ToUpper().Equals(IP_str_SecurityToken.ToUpper())))
                        {
                            return true;
                        }
                    }
                    return false;
                },"UIExceptionPolicy");
            return lcl_b_Response;
        }

        /// <summary>
        /// Removes UserContext from Repository which ever match the SessionID
        /// </summary>
        /// <param name="IP_str_SessionID">Session ID to remove</param>
        /// <returns>Returns true if removed successfully else false</returns>
        public static System.Boolean RemoveSession(System.String IP_str_SessionID)
        {
            System.Boolean lcl_b_Response = true;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = null;
            lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
            {
                foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContextTmp in AuthenticUserContextRepository.m_obj_Repository)
                {
                    if (lcl_obj_AuthenticUserContextTmp.SessionID.Trim().ToUpper().Equals(IP_str_SessionID.Trim().ToUpper()))
                        //(lcl_obj_AuthenticUserContext.SecurityToken.ToUpper().Equals(IP_str_SecurityToken.ToUpper())))
                    {
                        lcl_obj_AuthenticUserContext = lcl_obj_AuthenticUserContextTmp;
                        break;
                    }
                }
                if (lcl_obj_AuthenticUserContext != null)
                {
                    System.Boolean lcl_b_Removed = false;
                    lcl_b_Removed = AuthenticUserContextRepository.m_obj_Repository.Remove(lcl_obj_AuthenticUserContext);
                    return lcl_b_Removed;
                }
                return false;
            }, "UIExceptionPolicy");
            return lcl_b_Response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_str_SessionID"></param>
        /// <returns></returns>
        public static System.Boolean CheckIfSessionExists(System.String IP_str_SessionID)
        {
             System.Boolean lcl_b_Response = true;
             lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
                 {
                     foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
                     {
                         if (lcl_obj_AuthenticUserContext.SessionID.ToLower().Equals(IP_str_SessionID.ToLower()))
                         {
                             return true;
                         }
                     }
                     return false;
                 }, "FLExceptionPolicy");
             return lcl_b_Response;
        }

        public static System.Boolean CheckIfSecurityTokenExists(System.String IP_str_SecurityToken)
        {
            System.Boolean lcl_b_Response = true;
            lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
                {
                    foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
                    {
                        if (lcl_obj_AuthenticUserContext.SecurityToken.ToLower().Equals(IP_str_SecurityToken.ToLower()))
                        {
                            return true;
                        }
                    }
                    return false;
                }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public static System.Boolean CheckIfUserExists(System.String IP_str_UserName)
        {
            System.Boolean lcl_b_Response = true;
            lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
                {
                    foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
                    {
                        if (lcl_obj_AuthenticUserContext.UserProfile.UserName.ToLower().Equals(IP_str_UserName.ToLower()))
                        {
                            return true;
                        }
                    }
                    return false;
                }, "FLExceptionPolicy");
            return lcl_b_Response;
        }

        public static System.Boolean CheckIfIPExists(System.String IP_str_IPAddress)
        {
            System.Boolean lcl_b_Response = true;
            lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
            {
                foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
                {
                    if (lcl_obj_AuthenticUserContext.IPAddress.ToLower().Equals(IP_str_IPAddress.ToLower()))
                    {
                        return true;
                    }
                }
                return false;
            }, "FLExceptionPolicy");
            return lcl_b_Response;
        }
        public static void Add(SilkERP360.CCL.Repository.AuthenticUserContext IP_obj_AuthenticUserContext)
        {
            
            m_obj_ExceptionManager.Process(() =>
                {
                    //Check If SessionID,SecurityToken and User already Exists
                    //foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContextTmp in AuthenticUserContextRepository.m_obj_Repository)
                    //{
                    //    if (AuthenticUserContextRepository.CheckIfSessionExists(IP_obj_AuthenticUserContext.SessionID) == true)
                    //    {
                    //        return lcl_obj_AuthenticUserContextTmp;
                    //    }
                    //    if (AuthenticUserContextRepository.CheckIfSecurityTokenExists(IP_obj_AuthenticUserContext.SecurityToken) == true)
                    //    {
                    //        return lcl_obj_AuthenticUserContextTmp;
                    //    }
                    //    if (AuthenticUserContextRepository.CheckIfUserExists(IP_obj_AuthenticUserContext.UserProfile.UserName) == true)
                    //    {
                    //        return lcl_obj_AuthenticUserContextTmp;
                    //    }
                    //}
                    AuthenticUserContextRepository.m_obj_Repository.Add(IP_obj_AuthenticUserContext);
                    
                },"FLExceptionPolicy");
                       
        }

        public static System.Boolean Remove(SilkERP360.CCL.Repository.AuthenticUserContext IP_obj_AuthenticUserContext)
        {
            System.Boolean lcl_b_Return = false;
            lcl_b_Return = SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_ExceptionManager.Process<System.Boolean>(() =>
                {
                    try
                    {
                        System.Boolean lcl_b_Response = SilkERP360.CCL.Repository.AuthenticUserContextRepository.m_obj_Repository.Remove(IP_obj_AuthenticUserContext);
                        return lcl_b_Response;
                    }
                    catch (System.Exception Ex)
                    {
                        throw Ex;
                    }
                },"FLExceptionPolicy");
            return lcl_b_Return;
        }

        public static SilkERP360.CCL.Repository.AuthenticUserContext GetAuthenticatedUserContextBySession(System.String IP_str_SessionID)
        {
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = null;
            lcl_obj_AuthenticUserContext = m_obj_ExceptionManager.Process<SilkERP360.CCL.Repository.AuthenticUserContext>(() =>
            {
                //Check If SessionID,SecurityToken and User already Exists
                foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContextTmp in AuthenticUserContextRepository.m_obj_Repository)
                {
                    if (AuthenticUserContextRepository.CheckIfSessionExists(IP_str_SessionID) == true)
                    {
                        return lcl_obj_AuthenticUserContextTmp;
                    }
                }
                return null;
            }, "FLExceptionPolicy");
            return lcl_obj_AuthenticUserContext;
        }

        public static SilkERP360.CCL.Repository.AuthenticUserContext GetAuthenticatedUserContextBySecurityToken(System.String IP_str_SecurityToken)
        {
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = null;
            lcl_obj_AuthenticUserContext = m_obj_ExceptionManager.Process<SilkERP360.CCL.Repository.AuthenticUserContext>(() =>
            {
                //Check If SessionID,SecurityToken and User already Exists
                foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContextTmp in AuthenticUserContextRepository.m_obj_Repository)
                {
                    if (AuthenticUserContextRepository.CheckIfSecurityTokenExists(IP_str_SecurityToken) == true)
                    {
                        return lcl_obj_AuthenticUserContextTmp;
                    }
                }
                return null;
            }, "FLExceptionPolicy");
            return lcl_obj_AuthenticUserContext;
        }

        //public static System.Boolean DoModuleExistsInModulePermission(System.UInt64 IP_ui64_ModuleCode)
        //{
        //    System.Boolean lcl_b_Response = true;
        //    lcl_b_Response = m_obj_ExceptionManager.Process<System.Boolean>(() =>
        //    {
        //        foreach (SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext in AuthenticUserContextRepository.m_obj_Repository)
        //        {
        //            if (lcl_obj_AuthenticUserContext.SessionID.ToLower().Equals(IP_str_SessionID.ToLower()))
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }, "FLExceptionPolicy");
        //    return lcl_b_Response;
        //}
    }
}
