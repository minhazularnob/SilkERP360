using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    /// <summary>
    /// Validates if the date is the current date.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CurrentDateAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        /// <summary>
        /// Determines if the date provided in IP_obj_Value is the current date.
        /// If null provded as value, it assumes the datetime to be nullable.Doesn't Validate
        /// </summary>
        /// <param name="item">Value to be determined</param>
        /// <returns>
        /// <c>true</c> if the specified date is the current date; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid(System.Object IP_obj_Value)
        {
            try
            {
                System.DateTime? lcl_dt_Value = (System.DateTime?)IP_obj_Value;
                if (lcl_dt_Value == null)
                {
                    return true;
                }
                System.DateTime lcl_dt_Today = System.DateTime.Now;
                if ((lcl_dt_Value.Value.Day == lcl_dt_Today.Day) &&
                    (lcl_dt_Value.Value.Month == lcl_dt_Today.Month) &&
                    (lcl_dt_Value.Value.Year == lcl_dt_Today.Year))
                {
                    return true;
                }

                this.Message = System.String.Format("{0} : Cannot Accept Any Date But Today's Date!!!Value Provided : {1}", this.FieldName,lcl_dt_Value.Value.ToString());
                return false;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
