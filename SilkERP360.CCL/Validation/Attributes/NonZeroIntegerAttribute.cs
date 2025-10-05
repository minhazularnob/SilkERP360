using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    /// <summary>
    /// Validates if the integer value contains 0.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class NonZeroIntegerAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        /// <summary>
        /// Determines if the integer value contains 0.
        /// </summary>
        /// <param name="item">Value to be determined</param>
        /// <returns>
        /// <c>true</c> if the integer value > 0; otherwise,Contains 0 <c>false</c>.
        /// </returns>

        public override bool IsValid(System.Object IP_obj_Value)
        {
            try
            {
                //UInt64 datatype choosen as it will cover all integer types to validate for the value 0
                System.UInt64 lcl_ui64_Value = System.UInt64.Parse(IP_obj_Value.ToString());
                if (lcl_ui64_Value == 0)
                {
                    this.Message = System.String.Format("{0} : Cannot Accept 0 (Zero)!!!", this.FieldName);
                    return false;
                }
                return true;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
