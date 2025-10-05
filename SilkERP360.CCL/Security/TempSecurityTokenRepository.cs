using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Security
{
    public static class TempSecurityTokenRepository
    {
        private static System.Collections.Generic.List<System.String> m_strList_SecurityTokens;

        static TempSecurityTokenRepository()
        {
            SilkERP360.CCL.Security.TempSecurityTokenRepository.m_strList_SecurityTokens = new System.Collections.Generic.List<string>();
        }

        /// <summary>
        /// 1. Inserts the Temporary Security Token into the Repository
        /// 2. Checks if the provided security token already exists. If it does, throws exception and returns the exception in 
        /// OP_obj_Exception
        /// </summary>
        /// <param name="IP_str_TempSecurityToken">Security Token to Insert</param>
        /// <param name="OP_obj_Exception">If no error generated then null else the Exception object</param>
        /// <returns>Returns true if key successfully Inserted.If fails, returns false and returns the generated
        /// exception in the output parameter OP_obj_Exception</returns>
        //public static System.Boolean Insert(System.String IP_str_TempSecurityToken, out System.Exception OP_obj_Exception)
        //{
        //    //try
        //    //{
        //    //    foreach (System.String lcl_str_SecurityToken in SilkERP360.CCL.Security.TempSecurityTokenRepository.m_strList_SecurityTokens)
        //    //    {
        //    //        if (lcl_str_SecurityToken.Trim().Equals(IP_str_TempSecurityToken.Trim()))
        //    //        {
        //    //            OP_obj_Exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.CCLCustomException(
        //    //            return false;
        //    //        }
        //    //    }
        //    //    SilkERP360.CCL.Security.TempSecurityTokenRepository.m_strList_SecurityTokens.Add(IP_str_TempSecurityToken);
        //    //    OP_obj_Exception = null;
        //    //    return true;
        //    //}
        //    //catch (System.Exception Ex)
        //    //{
        //    //    OP_obj_Exception = Ex;
        //    //    return false;
        //    //}
        //    return true;
        //}

        /// <summary>
        /// 1. Removes the Temporary Security Token from the Repository
        /// 2. Checks if the provided security token exists. If it does not, throws exception and returns the exception in 
        /// OP_obj_Exception(CCLCustomException with ExceptionCode -102
        /// </summary>
        /// <param name="IP_str_TempSecurityToken">Security Token to Insert</param>
        /// <param name="OP_obj_Exception">If no error generated then null else the Exception object</param>
        /// <returns>Returns true if key successfully Inserted.If fails, returns false and returns the generated
        /// exception in the output parameter OP_obj_Exception</returns>
        //public static System.Boolean Remove(System.String IP_str_TempSecurityToken, out System.Exception OP_obj_Exception)
        //{
        //    //try
        //    //{
        //    //    if (SilkERP360.CCL.Security.TempSecurityTokenRepository.m_strList_SecurityTokens.Remove(IP_str_TempSecurityToken))
        //    //    {
        //    //        OP_obj_Exception = null;
        //    //        return true;
        //    //    }
        //    //    OP_obj_Exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.CCLCustomException(-102, "Security Token Not Found In The Repository!!!");
        //    //    return false;
        //    //}
        //    //catch (System.Exception Ex)
        //    //{
        //    //    OP_obj_Exception = Ex;
        //    //    return false;
        //    //}
        //    return false;
        //}

        /// <summary>
        /// Checks if IP_str_SecurityToken exists in the repository. Returns true if exists else false. If any exception generated, returns
        /// the exception in OP_obj_Exception else OP_obj_Exception is null
        /// </summary>
        /// <param name="IP_str_SecurityToken"></param>
        /// <param name="OP_obj_Exception"></param>
        /// <returns></returns>
        public static System.Boolean SecurityKeyExists(System.String IP_str_TempSecurityToken, out System.Exception OP_obj_Exception)
        {
            try
            {
                foreach (System.String lcl_str_SecurityToken in SilkERP360.CCL.Security.TempSecurityTokenRepository.m_strList_SecurityTokens)
                {
                    if (lcl_str_SecurityToken.ToUpper().Trim().Equals(IP_str_TempSecurityToken.ToUpper().Trim()))
                    {
                        OP_obj_Exception = null;
                        return true;
                    }
                }
                OP_obj_Exception = null;
                return false;
            }
            catch (System.Exception Ex)
            {
                OP_obj_Exception = Ex;
                return false;
            }
        }
    }
}
