using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    [System.AttributeUsage(AttributeTargets.Field,AllowMultiple=false)]
    public class RequiredAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        /// <summary>
        /// Determines whether the value of the underlying property (passed in as the <paramref name="item"/> parameter)
        /// is not null or an empty string.
        /// </summary>
        /// <param name="item">The underlying value of the propery that is being validated.</param>
        /// <returns>
        /// <c>true</c> if the specified item is not null or an empty string; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(object item)
        {
            if (item is System.String)
            {
                System.Boolean lcl_b_NullOrEmpty = System.String.IsNullOrEmpty(item as System.String);
                if (lcl_b_NullOrEmpty == true)
                {
                    this.Message = System.String.Format("{0} : Cannot Accept Empty or Null Values!!!", this.FieldName);
                    return false;
                }
                //return !string.IsNullOrEmpty(item as String);
                System.Boolean lcl_b_NullOrSpace = System.String.IsNullOrWhiteSpace(item as System.String);
                if (lcl_b_NullOrSpace == true)
                {
                    this.Message = System.String.Format("{0} : Cannot Accept Null or White Spaces as Values!!!", this.FieldName);
                    return false;
                }
                return true;
            }
            return item != null;
        }
    }
}
