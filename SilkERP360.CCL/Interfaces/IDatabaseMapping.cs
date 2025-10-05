using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Interfaces
{
    public interface IDatabaseMapping<T>
    {
        System.String GenerateSqlSelect(T IP_obj_T,System.String IP_str_WhereCondition);
        System.String GenerateSqlInsert(T IP_obj_T);
    }
}
