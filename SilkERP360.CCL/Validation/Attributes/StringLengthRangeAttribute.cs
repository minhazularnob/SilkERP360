using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    class StringLengthRangeAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        public UInt32 MinLength { get; set; }
        public UInt32 MaxLength { get; set; }
        /// <summary>
        /// Determines whether the value of the underlying property (passed in as the <paramref name="item"/> parameter)
        /// is not null or an empty string.
        /// </summary>
        /// <param name="item">The underlying value of the propery that is being validated.</param>
        /// <returns>
        /// <c>true</c> if the specified item is not null or an empty string; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(System.Object IP_obj_Value)
        {
            try
            {
                System.String lcl_str_Value = IP_obj_Value.ToString();
                if (lcl_str_Value == null)
                {
                    this.Message = System.String.Format("{0} : Cannot Accept NULL Value!!!", this.FieldName);
                    return false;
                }
                if ((lcl_str_Value.Length >= this.MinLength) && (lcl_str_Value.Length <= this.MaxLength))
                {
                    return true;
                }
                this.Message = System.String.Format("{0} : Must Be Between {1} and {2} Characters in Length!!!Provided Value : {3}", this.FieldName,this.MinLength,this.MaxLength,lcl_str_Value);
                return false;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
