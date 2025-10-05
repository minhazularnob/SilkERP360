using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes
{
    /// <summary>
    /// Determines if the provided date value is not older than the specified
    /// number of days from current date.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class BackDateAttribute : SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase
    {
        public System.UInt32 Days { get; set; }

        /// <summary>
        /// Determines if the date provided in IP_obj_Value is not older by the 
        /// number of Days(Provided through Days Member Variable) from current date
        /// /// If null provded as value, it assumes the datetime to be nullable.Doesn't Validate
        /// If value is more than current date
        /// </summary>
        /// <param name="item">Value to be determined</param>
        /// <returns>
        /// <c>true</c> if IP_obj_Value == CurrentDate - Days; otherwise, <c>false</c>.
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
                //check if date is a date in the future
                if(lcl_dt_Value.Value.Date > System.DateTime.Now.Date)
                {
                    this.Message = System.String.Format("{0} : Cannot Accept A Date In The Future!!!Value Provided : {1}", this.FieldName, lcl_dt_Value.Value.ToString());
                    return false;
                }

                if((System.DateTime.Now.Date.Subtract(System.TimeSpan.FromDays(this.Days)) == lcl_dt_Value.Value.Date))
                {
                    return true;
                }
                this.Message = System.String.Format("{0} : Cannot Accept Any Date Older Than {1} Days From Today!!!Value Provided : {2}", this.FieldName,this.Days, lcl_dt_Value.Value.ToString());
                return false;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
