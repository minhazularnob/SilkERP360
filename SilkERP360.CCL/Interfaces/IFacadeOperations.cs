using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Interfaces
{
    public interface IFacadeOperations<T>
    {
        /// <summary>
        /// Saves the Implementer Object in the Database
        /// and returns the newly created PK of the
        /// underlying entity
        /// </summary>
        /// <param name="IP_obj_Object"></param>
        /// <returns>PK</returns>
        System.UInt64 Save(T IP_obj_T);

        /// <summary>
        /// Gets an Instance of the Implementer Object
        /// Based on the underlying entities primary key.
        /// </summary>
        /// <param name="IP_ui64_Code">PK</param>
        /// <returns>Implementer Object</returns>
        T Get(System.UInt64 IP_ui64_Code);

        /// <summary>
        /// Gets an Instance of the Implementer Object
        /// Based on the query prvided
        /// </summary>
        /// <param name="IP_ui64_Code">PK</param>
        /// <returns>Implementer Object</returns>
        T Get(System.String IP_str_SqlQuery);

        /// <summary>
        /// Gets a list of the Implementer Object
        /// Based on the query prvided
        /// </summary>
        /// <param name="IP_ui64_Code">PK</param>
        /// <returns>Implementer Object</returns>
        System.Collections.Generic.List<T> GetList(System.String IP_str_SqlQuery);

        /// <summary>
        /// Update the Implementer Object
        /// </summary>
        /// <param name="IP_obj_Object"></param>
        /// <returns>Number Of Rows Effected</returns>
        System.Int32 Update(T IP_obj_T);

        /// <summary>
        /// Runs the Update Query on the underlying entity
        /// </summary>
        /// <param name="IP_str_SqlUpdateQuery"></param>
        /// <returns>Number Of Rows Affected</returns>
        System.Int32 Update(System.String IP_str_SqlUpdateQuery);
    }
}
