using SilkERP360.CCL.Enums;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Tokens
    {
        public string TokenId { get; set; }
        public string CreatetedDate { get; set; }
        public bool IsValid { get; set; }
        public string ExpiryAt { get; set; }
    }
}

    
