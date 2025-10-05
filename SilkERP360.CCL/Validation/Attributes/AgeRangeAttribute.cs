using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    /// <summary>
    /// Attribute is Applicable to DOB only.
    /// This Attribute will calculate the age of a person from the DOB and determines if the age
    /// is Age >= MinAge AND Age <= MaxAge
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class AgeRangeAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        public System.UInt32 MinAge;
        public System.UInt32 MaxAge;

        /// <summary>
        /// Determines whether the value of the underlying property (passed in as the <paramref name="item"/> parameter)
        /// is not null or an empty string.
        /// </summary>
        /// <param name="item">The underlying value of the propery that is being validated.</param>
        /// <returns>
        /// <c>true</c> if the specified item is not null or an empty string; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(object IP_obj_Value)
        {
            if (IP_obj_Value.GetType() == typeof(System.DateTime)) //is System.String)
            {
                System.DateTime lcl_dt_Value = System.DateTime.Parse(IP_obj_Value.ToString()).Date;
                System.DateTime lcl_dt_CurrentDate = System.DateTime.Now.Date;
                //check if DOB is > than current date
                if (lcl_dt_Value >= lcl_dt_CurrentDate)
                {
                    this.Message = System.String.Format("{0} : Invalid Date!!!Cannot Accept a Date Later Than Today!!!", this.FieldName);
                    return false;
                }
                System.UInt32 lcl_ui32_Age = (System.UInt32)lcl_dt_CurrentDate.Date.Subtract(lcl_dt_Value.Date).TotalDays / 365;

                if ((lcl_ui32_Age < 14) || (lcl_ui32_Age > 60))
                {
                    this.Message = System.String.Format("{0} : Invalid Date!!!The Age Must Be Between 14 And 60 Years.", this.FieldName);
                    return false;
                }
                return true;
            }
            this.Message = System.String.Format("{0} : Invalid Data!!!", this.FieldName);
            return false;
        }
    }
}
