using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.Interfaces
{
    /// <summary>
    /// Every Class that wishes to be validated must implement this interface
    /// </summary>
    public interface IEntityValidation
    {
        void Validate();//object sender, SilkERP360.CrossCuttingLayer.Validation.Events.ValidationEventArgs e);
        bool Save();
    }
}
