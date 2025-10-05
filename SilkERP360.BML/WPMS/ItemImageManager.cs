using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.WPMS
{
    public class ItemImageManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
         SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage>
    {
        public ulong Save(CCL.BusinessEntities.WPMS.ItemImage IP_obj_A, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public ulong Save(CCL.BusinessEntities.WPMS.ItemImage IP_obj_A)
        {
            System.UInt64 lcl_ui64_ItemImageCode = 0;
            //System.String lcl_str_Sequence = IP_obj_A.GetSequence();
            System.String lcl_str_SqlQuery = System.String.Format("SELECT SEQ_ITEM_IMAGE.NEXTVAL AS ID FROM DUAL");
            lcl_ui64_ItemImageCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_A.ItemImageCode = lcl_ui64_ID;
                    //System.String lcl_str_SqlInsert = IP_obj_A.GenerateSqlInsert();
                    //System.String lcl_str_SqlInsert1 = "insert into emp(id,name,photo) values(" + txtid.Text + "," + "'" + txtname.Text + "'," + " :BlobParameter )";
                    System.String lcl_str_SqlInsert = System.String.Format("INSERT INTO WPMS_ITEM_IMAGE (ITEM_IMAGE_CODE,ITEM_CODE,IMAGE_TYPE,IMAGE_SIZE,IMAGE,ENTRY_EMPLOYEE_CODE,NOTE) VALUES({0},{1},'{2}',{3},:ItemImageBLOB,{4},'{5}')", lcl_ui64_ID, IP_obj_A.ItemCode, IP_obj_A.ImageType, IP_obj_A.ImageSize,IP_obj_A.EntryEmployeeCode,IP_obj_A.Note);

                    System.Data.OracleClient.OracleParameter lcl_obj_ItemImageBLOB = new System.Data.OracleClient.OracleParameter();
                    lcl_obj_ItemImageBLOB.OracleType = System.Data.OracleClient.OracleType.Blob;
                    lcl_obj_ItemImageBLOB.ParameterName = "ItemImageBLOB";

                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        switch (IP_obj_A.ImageType)
                        {
                            case "image/jpeg":
                            case "image/jpg":
                                IP_obj_A.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case "image/gif":
                                IP_obj_A.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            case "image/png":
                                IP_obj_A.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        lcl_obj_ItemImageBLOB.Value = ms.ToArray();
                    }

                    //lcl_obj_ItemImageBLOB.Value = IP_obj_A.Image;

                    lcl_obj_DBManager.InternalResource.Command.Parameters.Add(lcl_obj_ItemImageBLOB);
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();


                    lcl_obj_DBManager.InternalResource.Close();

                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_ItemImageCode;
        }

        public CCL.BusinessEntities.WPMS.ItemImage Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.ItemImage Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.ItemImage Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.WPMS.ItemImage Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.WPMS.ItemImage> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage> lcl_objLst_ItemImage = null;

            lcl_objLst_ItemImage = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Data.OracleClient.OracleDataReader lcl_obj_Reader = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_Reader.HasRows))
                {
                    return null;
                }
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage> lcl_objLst_ItemImageTmp = new
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.ItemImage>();
                while (lcl_obj_Reader.Read())
                {
                    SilkERP360.CCL.BusinessEntities.WPMS.ItemImage lcl_obj_ItemImageTmp = new SilkERP360.CCL.BusinessEntities.WPMS.ItemImage();
                    lcl_obj_ItemImageTmp.ItemImageCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_IMAGE_CODE"].ToString());
                    lcl_obj_ItemImageTmp.ItemCode = System.UInt64.Parse(lcl_obj_Reader["ITEM_CODE"].ToString());
                    lcl_obj_ItemImageTmp.ImageType = lcl_obj_Reader["IMAGE_TYPE"].ToString();
                    lcl_obj_ItemImageTmp.ImageSize = System.UInt32.Parse(lcl_obj_Reader["IMAGE_SIZE"].ToString());
                    lcl_obj_ItemImageTmp.Note = lcl_obj_Reader["NOTE"].ToString();
                    //lcl_obj_ItemImageTmp.Image = (System.Byte[])(lcl_obj_Reader["IMAGE"]);
                    lcl_obj_ItemImageTmp.ImageB64String = System.Convert.ToBase64String((System.Byte[])lcl_obj_Reader["IMAGE"]);
                    lcl_objLst_ItemImageTmp.Add(lcl_obj_ItemImageTmp);
                }
                lcl_obj_Reader.Close();
                return lcl_objLst_ItemImageTmp;
            }, "BMLExceptionPolicy");
            return lcl_objLst_ItemImage;
        }

        public List<CCL.BusinessEntities.WPMS.ItemImage> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
