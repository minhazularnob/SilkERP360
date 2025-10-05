using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML
{
    public class SecurityManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SecurityManager()
        {
            this.Initialize();
        }
        public System.String GenerateSecurityToken()
        {
            System.String lcl_str_Token = System.String.Empty;
            lcl_str_Token = this.ExceptionManager.Process<System.String>(() =>
                {
                    System.Guid lcl_obj_GUID = System.Guid.NewGuid();
                    System.String lcl_str_Input = lcl_obj_GUID.ToString();
                    System.Security.Cryptography.MD5 lcl_obj_MD5 = System.Security.Cryptography.MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(lcl_str_Input);
                    byte[] hash = lcl_obj_MD5.ComputeHash(inputBytes);

                    // step 2, convert byte array to hex string
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString().ToUpper();
                }, "BMLExceptionPolicy");

            // step 1, calculate MD5 hash from input
            return lcl_str_Token;
        }
    }
}
