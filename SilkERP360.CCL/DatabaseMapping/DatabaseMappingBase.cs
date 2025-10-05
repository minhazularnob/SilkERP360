using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SilkERP360.CCL.DatabaseMapping
{

    public enum DateTimeFormat
    {
        None = 0,
        DateOnly = 1,
        DateAndTime = 2
    }

    /// <summary>
    /// Any Class which wish to generate Sql SELECT/INSERT statements, must be derived from this class
    /// </summary>
    public abstract class DatabaseMappingBase
    {
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData;

        /// <summary>
        /// Gets the Oracle sequence Name created for an entity
        /// </summary>
        /// <returns></returns>
        public virtual System.String GetSequence()
        {
            try
            {
                System.String lcl_str_Sequence = System.String.Empty;
                System.Attribute[] lcl_objLst_ClassAttributes = System.Attribute.GetCustomAttributes(this.GetType());
                if (lcl_objLst_ClassAttributes.Length == 0)
                {
                    //No attribute Found.Class not marked with DatabaseEntityMapping class
                    throw new System.Exception("This class is not marked to generate it's own Sql statements!!!");
                }
                //Attribute [0] is the DatabaseEntityMapping instance
                SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping lcl_obj_EntityMapping = (SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping)lcl_objLst_ClassAttributes[0];
                lcl_str_Sequence = lcl_obj_EntityMapping.DatabaseSequence;
                return lcl_str_Sequence;
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="IP_str_WhereCondition">If No Condition required, will contain System.String.Empty Else the WHERE clause.
        /// The condition clause must contain the key word WHERE.</param>
        /// <returns></returns>
        public virtual string GenerateSqlSelect(System.String IP_str_WhereCondition)
        {
            try
            {

                System.Attribute[] lcl_objLst_ClassAttributes = System.Attribute.GetCustomAttributes(this.GetType());
                if (lcl_objLst_ClassAttributes.Length == 0)
                {
                    //No attribute Found.Class not marked with DatabaseEntityMapping class
                    throw new System.Exception("This class is not marked to generate it's own Sql statements!!!");
                }
                //Attribute [0] is the DatabaseEntityMapping instance
                SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping lcl_obj_EntityMapping = (SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping)lcl_objLst_ClassAttributes[0];

                System.Text.StringBuilder lcl_obj_SqlColumnsListing = new System.Text.StringBuilder();
                System.Text.StringBuilder lcl_obj_SqlQueryBuilder = new System.Text.StringBuilder();
                lcl_obj_SqlQueryBuilder.Append("SELECT ");


                foreach (System.Reflection.FieldInfo lcl_obj_FieldInfo in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    /* Get property value assigned to property */
                    object lcl_obj_Data = lcl_obj_FieldInfo.GetValue(this);

                    /* Check if property value is required */
                    foreach (System.Object lcl_obj_CustomAttribute in
                        lcl_obj_FieldInfo.GetCustomAttributes(typeof(CCL.DatabaseMapping.DatabaseColumnMapping), true))// .GetCustomAttributes(typeof(RequiredAttribute), true))
                    {
                        CCL.DatabaseMapping.DatabaseColumnMapping lcl_obj_DatabaseColumnMapping
                            = lcl_obj_CustomAttribute as SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping;
                        if (lcl_obj_SqlColumnsListing.ToString().Trim().Length == 0)
                        {
                            lcl_obj_SqlColumnsListing.Append(" ");
                            lcl_obj_SqlColumnsListing.Append(lcl_obj_DatabaseColumnMapping.DatabaseColumnName);
                        }
                        else
                        {
                            lcl_obj_SqlColumnsListing.Append(",");
                            lcl_obj_SqlColumnsListing.Append(lcl_obj_DatabaseColumnMapping.DatabaseColumnName);
                        }
                    }
                }

                lcl_obj_SqlQueryBuilder.Append(" ");
                lcl_obj_SqlQueryBuilder.Append(lcl_obj_SqlColumnsListing.ToString());
                lcl_obj_SqlQueryBuilder.Append(" FROM ");
                lcl_obj_SqlQueryBuilder.Append(lcl_obj_EntityMapping.DatabaseTableName);

                if (IP_str_WhereCondition != System.String.Empty)
                {
                    lcl_obj_SqlQueryBuilder.Append(" ");
                    lcl_obj_SqlQueryBuilder.Append(IP_str_WhereCondition);
                }

                return lcl_obj_SqlQueryBuilder.ToString();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GenerateSqlInsert()
        {
            //System.String lcl_str_SqlInsertQuery = this.ExceptionManager.Process<System.String>(() =>
            try
            {
                System.Text.StringBuilder lcl_sb_SqlInsertQueryTmp = new System.Text.StringBuilder();
                System.Attribute[] lcl_objLst_ClassAttributes = System.Attribute.GetCustomAttributes(this.GetType());
                if (lcl_objLst_ClassAttributes.Length == 0)
                {
                    //No attribute Found.Class not marked with DatabaseEntityMapping class
                    throw new System.Exception("This class is not marked to generate it's own Sql statements!!!");
                }
                //Attribute [0] is the DatabaseEntityMapping instance
                SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping lcl_obj_EntityMapping = (SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping)lcl_objLst_ClassAttributes[0];

                System.Text.StringBuilder lcl_obj_SqlInsertColumnsListing = new System.Text.StringBuilder(); //Format: (Column1,Column2,Column3...)
                System.Text.StringBuilder lcl_obj_SqlInsertColumnsValues = new System.Text.StringBuilder();  //Format: (Value1,Value2,Value3...)
                System.Text.StringBuilder lcl_obj_SqlInsertQueryBuilder = new System.Text.StringBuilder();
                lcl_obj_SqlInsertQueryBuilder.Append("INSERT INTO ");
                lcl_obj_SqlInsertQueryBuilder.Append(lcl_obj_EntityMapping.DatabaseTableName);

                lcl_obj_SqlInsertColumnsListing.Append("(");
                lcl_obj_SqlInsertColumnsValues.Append("VALUES(");
                System.Reflection.FieldInfo[] lcl_objLst_Fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (System.Reflection.FieldInfo lcl_obj_FieldInfo in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                                        
                    /* Get property value assigned to property */
                    object lcl_obj_Data = lcl_obj_FieldInfo.GetValue(this);
                    if (lcl_obj_Data == null)
                    {
                        continue;
                    }
                    System.String lcl_str_Data = lcl_obj_Data.ToString();

                    /* Check if property value is required */
                    foreach (System.Object lcl_obj_CustomAttribute in
                        lcl_obj_FieldInfo.GetCustomAttributes(typeof(CCL.DatabaseMapping.DatabaseColumnMapping), true))// .GetCustomAttributes(typeof(RequiredAttribute), true))
                    {
                        if (lcl_obj_SqlInsertColumnsListing[lcl_obj_SqlInsertColumnsListing.Length - 1] != '(')
                        {
                            //If the last added character is not ( then add ,
                            lcl_obj_SqlInsertColumnsListing.Append(",");
                            lcl_obj_SqlInsertColumnsValues.Append(",");
                        }

                        CCL.DatabaseMapping.DatabaseColumnMapping lcl_obj_DatabaseColumnMapping 
                            = lcl_obj_CustomAttribute as SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping;
                        //if (lcl_obj_DatabaseColumnMapping.IsPrimaryKey)
                        //{
                        //    if (lcl_obj_EntityMapping.DatabaseSequence.Trim().Length == 0)
                        //    {
                        //        throw new System.Exception("No Database Sequence defined for the PrimaryKey!!!");
                        //    }
                        //    lcl_obj_SqlInsertColumnsListing.Append(lcl_obj_DatabaseColumnMapping.DatabaseColumnName);
                        //    //lcl_obj_SqlInsertColumnsValues.Append(lcl_obj_EntityMapping.DatabaseSequence);
                        //    //lcl_obj_SqlInsertColumnsValues.Append(".NEXTVAL");
                        //    continue;
                        //}

                        lcl_obj_SqlInsertColumnsListing.Append(lcl_obj_DatabaseColumnMapping.DatabaseColumnName);
                        if (lcl_obj_DatabaseColumnMapping.DataType == typeof(System.String))
                        {
                            lcl_obj_SqlInsertColumnsValues.Append("'");
                            lcl_obj_SqlInsertColumnsValues.Append(lcl_str_Data);
                            lcl_obj_SqlInsertColumnsValues.Append("'");
                            continue;
                        }
                        if (lcl_obj_DatabaseColumnMapping.DataType == typeof(System.DateTime))
                        {
                            if (lcl_obj_DatabaseColumnMapping.DateTimeFormat == DateTimeFormat.DateAndTime)
                            {
                                System.DateTime lcl_obj_TmpDT = System.DateTime.Parse(lcl_str_Data);
                                lcl_obj_SqlInsertColumnsValues.Append("TO_DATE('");
                                lcl_obj_SqlInsertColumnsValues.Append(lcl_obj_TmpDT.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                lcl_obj_SqlInsertColumnsValues.Append("','DD/MM/YYYY HH:MI:SS AM')");
                                continue;
                            }
                            else
                            {
                                System.DateTime lcl_obj_TmpDT = System.DateTime.Parse(lcl_str_Data);
                                lcl_obj_SqlInsertColumnsValues.Append("TO_DATE('");
                                lcl_obj_SqlInsertColumnsValues.Append(lcl_obj_TmpDT.ToString("dd/MM/yyyy"));
                                lcl_obj_SqlInsertColumnsValues.Append("','DD/MM/YYYY')");
                                continue;
                            }
                        }
                        if (lcl_obj_DatabaseColumnMapping.DataType.IsEnum)
                        {
                            System.Enum lcl_enm_Data = System.Enum.Parse(lcl_obj_DatabaseColumnMapping.DataType, lcl_obj_Data.ToString()) as Enum;
                            System.Int32 lcl_i32_Data = Convert.ToInt32(lcl_enm_Data); // 
                            lcl_obj_SqlInsertColumnsValues.Append(lcl_i32_Data.ToString());
                            continue;
                        }
                        if (lcl_obj_DatabaseColumnMapping.DataType == typeof(System.Double))
                        {
                            lcl_obj_SqlInsertColumnsValues.Append(System.Double.Parse(lcl_str_Data.ToString()));
                            continue;
                        }
                        if (lcl_obj_DatabaseColumnMapping.DataType == typeof(System.Decimal))
                        {
                            lcl_obj_SqlInsertColumnsValues.Append(System.Decimal.Parse(lcl_str_Data.ToString()));
                            continue;
                        }
                        if (lcl_obj_DatabaseColumnMapping.DataType == typeof(System.UInt32))
                        {
                            lcl_obj_SqlInsertColumnsValues.Append(System.UInt32.Parse(lcl_str_Data.ToString()));
                            continue;
                        }

                        lcl_obj_SqlInsertColumnsValues.Append(System.UInt64.Parse(lcl_str_Data.ToString()));
                    }
                }
                lcl_obj_SqlInsertColumnsListing.Append(")");
                lcl_obj_SqlInsertColumnsValues.Append(")");

                lcl_obj_SqlInsertQueryBuilder.Append(lcl_obj_SqlInsertColumnsListing.ToString());
                lcl_obj_SqlInsertQueryBuilder.Append(lcl_obj_SqlInsertColumnsValues.ToString());

                return lcl_obj_SqlInsertQueryBuilder.ToString();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            
        }
    }
}
