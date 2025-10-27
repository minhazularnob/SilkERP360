using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Text.RegularExpressions;
using static SilkERP360.CCL.Validation.CustomValidationAttributes;

namespace SilkERP360.CCL.Validation
{
    public static class ObjectValidator
    {
        public static string ValidateObject(object obj)
        {
            var errors = new List<string>();
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                // Check for RequiredAttribute validation
                var requiredAttribute = property.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault() as RequiredAttribute;
                if (requiredAttribute != null)
                {
                    var value = property.GetValue(obj, null);
                    if (value == null || (value is string str && string.IsNullOrWhiteSpace(str)))
                    {
                        errors.Add(property.Name + " is required");
                    }
                }

                // Check for Phone validation (using Custom Validation Attribute)
                var phoneAttribute = property.GetCustomAttributes(typeof(CustomValidationAttributes.PhoneAttribute), false).FirstOrDefault() as CustomValidationAttributes.PhoneAttribute;
                if (phoneAttribute != null)
                {
                    var value = property.GetValue(obj, null) as string;
                    if (!string.IsNullOrEmpty(value) && !phoneAttribute.IsValid(value))
                    {
                        errors.Add(property.Name + " has an invalid phone number format");
                    }
                }

                // Check for Fax validation (using Custom Validation Attribute)
                var faxAttribute = property.GetCustomAttributes(typeof(CustomValidationAttributes.FaxAttribute), false).FirstOrDefault() as CustomValidationAttributes.FaxAttribute;
                if (faxAttribute != null)
                {
                    var value = property.GetValue(obj, null) as string;
                    if (!string.IsNullOrEmpty(value) && !faxAttribute.IsValid(value))
                    {
                        errors.Add(property.Name + " has an invalid fax number format");
                    }
                }

                // Check for Email validation (using Custom Validation Attribute)
                var emailAttribute = property.GetCustomAttributes(typeof(CustomValidationAttributes.EmailAttribute), false).FirstOrDefault() as CustomValidationAttributes.EmailAttribute;
                if (emailAttribute != null)
                {
                    var value = property.GetValue(obj, null) as string;
                    if (!string.IsNullOrEmpty(value) && !emailAttribute.IsValid(value))
                    {
                        errors.Add(property.Name + " has an invalid email format.");
                    }
                }

                // Check for Email validation (using Custom Validation Attribute)
                var NoSpecialCharactersAttribute = property.GetCustomAttributes(typeof(CustomValidationAttributes.NoSpecialCharactersAttribute), false).FirstOrDefault() as CustomValidationAttributes.NoSpecialCharactersAttribute;
                if (NoSpecialCharactersAttribute != null)
                {
                    var value = property.GetValue(obj, null) as string;
                    if (!string.IsNullOrEmpty(value) && !NoSpecialCharactersAttribute.IsValid(value))
                    {
                        errors.Add(property.Name + " has an special characters.");
                    }
                }
            }

            if (errors.Any())
            {
                return string.Join(", ", errors);
            }

            return string.Empty;
        }
    }
}
