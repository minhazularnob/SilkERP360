using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace SilkERP360.CCL.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ValidationBase : SilkERP360.CCL.DatabaseMapping.DatabaseMappingBase
    {
        protected SilkERP360.CCL.Validation.Collections.ValidationErrorCollection m_obj_ValidationErrorsCollection =
            new SilkERP360.CCL.Validation.Collections.ValidationErrorCollection();

        public SilkERP360.CCL.Validation.Collections.ValidationErrorCollection ValidationErrorsCollection
        {
            get { return this.m_obj_ValidationErrorsCollection; }
        }

        
        /// <summary>
        /// Determines whether the current instance meets all validation rules. It always clears the ValidationErrorsCollection
        /// first before adding new BrokenRule instances.
        /// </summary>
        /// <overloads>
        /// Determines whether the current instance meets all validation rules.
        /// </overloads>
        /// <returns>Returns <c>true</c> if the instance is valid, <c>false</c> otherwise.</returns>
        /// <remarks>This method automatically clears the internal BrokenRules collection.</remarks>
        public virtual bool Validate()
        {
            return Validate(true);
        }

        /// <summary>
        /// Determines whether the current instance meets all validation rules. You can optionally determine
        /// whether the BrokenRules collection should be cleared or not.
        /// </summary>
        /// <param name="clearBrokenRules">If set to <c>true</c> the BrokenRules collection is cleared first.</param>
        /// <returns>
        /// Returns <c>true</c> if the instance is valid, <c>false</c> otherwise.
        /// </returns>
        public virtual bool Validate(bool clearBrokenRules)
        {
            System.Boolean lcl_b_Return = true;
            this.m_obj_ValidationErrorsCollection.Clear();
            foreach (System.Reflection.FieldInfo lcl_obj_FieldInfo in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
            {
                /* Get property value assigned to property */
                object lcl_obj_Data = lcl_obj_FieldInfo.GetValue(this);

                /* Check if property value is required */
                foreach (System.Object lcl_obj_CustomAttribute in 
                    lcl_obj_FieldInfo.GetCustomAttributes(typeof(SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase), true))// .GetCustomAttributes(typeof(RequiredAttribute), true))
                {
                    SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase lcl_obj_ValidationAttribute
                        = lcl_obj_CustomAttribute as SilkERP360.CCL.Validation.Attributes.Base.ValidationAttributeBase;
                    if (lcl_obj_ValidationAttribute.IsValid(lcl_obj_Data))
                    {
                        continue;
                    }
                    lcl_b_Return = false;
                    this.m_obj_ValidationErrorsCollection.Add(new ErrorsExceptions.ValidationError(-100, lcl_obj_ValidationAttribute.Message,lcl_obj_FieldInfo.Name, lcl_obj_Data));

                    /*if (lcl_obj_ValidationAttribute is SilkERP360.CrossCuttingLayer.Validation.Attributes.RequiredAttribute)
                    {
                        SilkERP360.CrossCuttingLayer.Validation.Attributes.RequiredAttribute lcl_obj_RequiredAttribute = (SilkERP360.CrossCuttingLayer.Validation.Attributes.RequiredAttribute)lcl_obj_ValidationAttribute;
                        //System.String lcl_str_Message = System.String.Format("Field {0} Error : Empty or Null Value Not Allowed!!!", ().FieldName);
                        this.m_obj_ValidationErrorsCollection.Add(new ErrorsExceptions.ValidationError(-100, lcl_obj_RequiredAttribute.Message, "", lcl_obj_FieldInfo.Name, lcl_obj_Data));
                    }*/
                }
            }
            if (true)
            {
                throw new System.Exception("Fatal Error");
            }
            //return lcl_b_Return;
        }

    }
}
