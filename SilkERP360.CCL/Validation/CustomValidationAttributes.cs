using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SilkERP360.CCL.Validation
{
    public class CustomValidationAttributes
    {
        // Phone validation using Regex pattern
        public class PhoneAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;

                string phoneNumber = value.ToString();
                // International phone number format (this is just an example, you can adjust as needed)
                string pattern = @"^\+?[1-9]\d{1,14}$";

                return Regex.IsMatch(phoneNumber, pattern);
            }
        }

        // Email validation using the built-in EmailAddress attribute
        public class EmailAttribute : ValidationAttribute
        {
            // Regex pattern for validating email (simplified, you can adjust as needed)
            private static readonly string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;

                string email = value.ToString();

                // Using Regex to validate email format
                return Regex.IsMatch(email, EmailRegex);
            }
        }

        // Fax validation using similar phone validation logic
        public class FaxAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;

                string faxNumber = value.ToString();
                // Example for international fax number format
                string pattern = @"^\+?[1-9]\d{1,14}$";

                return Regex.IsMatch(faxNumber, pattern);
            }
        }

        public class UniqueNameAttribute : ValidationAttribute
        {
            private readonly string _tableName;
            private readonly string _columnName;

            public UniqueNameAttribute(string tableName, string columnName)
            {
                _tableName = tableName;
                _columnName = columnName;
            }
        }

        
        // Fax validation using similar phone validation logic
        public class NoSpecialCharactersAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                    return false;

                string faxNumber = value.ToString();
                // Example for international fax number format
                string pattern = @"^[a-zA-Z0-9\s]+$";

                return Regex.IsMatch(faxNumber, pattern);
            }
        }
    }
}
