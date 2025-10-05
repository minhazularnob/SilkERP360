using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.ErrorsExceptions
{
    public class ValidationError : SilkERP360.CCL.Validation.Interfaces.IValidationError
    {
        private System.Int32 m_i32_ErrorNo;
        public System.Int32 ErrorNo
        {
            get { return this.m_i32_ErrorNo; }
        }

        private System.String m_str_ErrorMessage;
        public System.String ErrorMessage
        {
            get { return this.m_str_ErrorMessage; }
        }

        private System.String m_str_TargetName;
        public System.String TargetName
        {
            get { return this.m_str_TargetName; }
        }

        /// <summary>
        /// Value of the Property which was validated
        /// </summary>
        private System.Object m_obj_ValidatedValue;
        public System.Object ValidatedValue
        {
            get { return this.m_obj_ValidatedValue; }
        }

        #region CONSTRUCTORS
        public ValidationError(System.Int32 IP_i32_ErrorNo, System.String IP_str_ErrorMessage, System.String IP_str_TargetName,
                               System.Object IP_obj_ValidatedValue)
        {
            this.m_i32_ErrorNo = IP_i32_ErrorNo;
            this.m_str_ErrorMessage = IP_str_ErrorMessage;
            this.m_str_TargetName = IP_str_TargetName;
            //this.m_str_PropertyName = IP_str_PropertyName;
            this.m_obj_ValidatedValue = IP_obj_ValidatedValue;
        }
        #endregion
    }
}
