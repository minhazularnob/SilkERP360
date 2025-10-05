using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Collections
{
    public class ValidationErrorCollection : System.Collections.Generic.List<SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError>,
        System.IDisposable
    {
        internal ValidationErrorCollection(System.Collections.Generic.List<SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError> myList)
			: base(myList)
		{ }
        public ValidationErrorCollection()
            //: base<SilkERP360.CrossCuttingLayer.Validation.ErrorsExceptions.ValidationError>()
        {
        }

        public new void Add(SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError IP_obj_ValidationError)
        {
            base.Add(IP_obj_ValidationError);
        }
        public new void Remove(SilkERP360.CCL.Validation.ErrorsExceptions.ValidationError IP_obj_ValidationError)
        {
            base.Remove(IP_obj_ValidationError);
        }
        public new void Clear()
        {
            base.Clear();
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
