using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Interfaces
{
    /// <summary>
    /// Every class that wish to have database operation func,
    /// must implement this interface
    /// </summary>
    public interface IManagerOperations<T>
    {
        System.UInt64 Save(T IP_obj_A, System.Object IP_obj_DBManager);
        System.UInt64 Save(T IP_obj_A);
        T Get(System.UInt64 IP_ui64_Code, System.Object IP_obj_DBManager);
        T Get(System.UInt64 IP_ui64_Code);
        T Get(System.String IP_str_SqlQuery, System.Object IP_obj_DBManager);
        T Get(System.String IP_str_SqlQuery);
        System.Collections.Generic.List<T> GetList(System.String IP_str_SqlQuery, System.Object IP_obj_DBManager);
        System.Collections.Generic.List<T> GetList(System.String IP_str_SqlQuery);
    }
}
