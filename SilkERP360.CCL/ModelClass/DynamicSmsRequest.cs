using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ModelClass
{
    public class DynamicSmsRequest
    {
        public IEnumerable<DynamicMessage> Messages { get; set; }
    }
    public class DynamicMessage
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
