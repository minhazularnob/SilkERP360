using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Attributes.Base
{
    [System.AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public abstract class ValidationAttributeBase : System.Attribute
    {
        /// <summary>
        /// The name of the Field in the class which is to be validated
        /// </summary>
        private System.String m_str_FieldName;
        private System.String m_str_Message;

        /// <summary>
        /// Determines whether the value of the underlying property (passed in as the <paramref name="item"/> parameter) 
        /// is valid according to the validation rule.
        /// </summary>
        /// <param name="item">The underlying value of the propery that is being validated.</param>
        /// <returns>
        /// <c>true</c> if the specified item is valid; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsValid(object item);

        /// <summary>
        /// Gets the validation message associated with this validation.
        /// </summary>
        /// <value>The validation message.</value>
        public string Message
        {
            get
            {
                return this.m_str_Message;
            }
            set
            {
                this.m_str_Message = value;
            }
        }

        /// <summary>
        /// The name of the field which is to be validated
        /// </summary>
        /// <value>The validation message.</value>
        public string FieldName
        {
            get
            {
                return this.m_str_FieldName;
            }
            set
            {
                this.m_str_FieldName = value;
            }
        }
    }
}
