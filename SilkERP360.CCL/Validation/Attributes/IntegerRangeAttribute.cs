using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
     [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class IntegerRangeAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        public UInt32 Min { get; set; }
        public UInt32 Max { get; set; }

        public override bool IsValid(System.Object IP_obj_Value)
        {
            try
            {
                System.UInt32 lcl_i32_Value = System.UInt32.Parse(IP_obj_Value.ToString());
                if ((lcl_i32_Value >= this.Min) && (lcl_i32_Value <= this.Max))
                {
                    return true;
                }
                this.Message = System.String.Format("{0} : Must Be Between {1} and {2}!!!Provided Value : {3}", this.FieldName, this.Min.ToString(), this.Max.ToString(), lcl_i32_Value.ToString());
                return false;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
