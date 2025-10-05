using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class EmployeeImageManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
        SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage>
    {
        public EmployeeImageManager()
        {
            this.Initialize();
        }



        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImage, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ImageCode = 0;
            
            lcl_ui64_ImageCode=this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

            System.Data.OracleClient.OracleParameter lcl_obj_ImageCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_IMAGE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ImageCode.Direction  = System.Data.ParameterDirection.Output;

                System.Data.OracleClient.OracleParameter lcl_obj_ImageType = new System.Data.OracleClient.OracleParameter("v_IMAGE_TYPE", System.Data.OracleClient.OracleType.NVarChar);
                lcl_obj_ImageType.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ImageType.Value = lcl_obj_EmployeeImage.ImageType;

                System.Data.OracleClient.OracleParameter lcl_obj_ImageSize = new System.Data.OracleClient.OracleParameter("v_IMAGE_SIZE", System.Data.OracleClient.OracleType.Int32);
                lcl_obj_ImageSize.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ImageSize.Value = lcl_obj_EmployeeImage.ImageSize;

                //convert the image to byte[]
                System.Data.OracleClient.OracleParameter lcl_obj_Image = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_IMAGE", System.Data.OracleClient.OracleType.Blob);
                lcl_obj_Image.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_Image.Value =lcl_obj_EmployeeImage.Image ;
                //System.Drawing.Image.FromStream
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    switch (lcl_obj_EmployeeImage.ImageType)
                    {
                        case "image/jpeg":
                        case "image/jpg":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "image/gif":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "image/png":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }
                 
                            

                





                    lcl_obj_Image.Value = ms.ToArray();
                }

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeImage.EmployeeCode;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ImageCode, lcl_obj_ImageType,lcl_obj_ImageSize,lcl_obj_Image,lcl_obj_EmployeeCode     };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_INS_EMPLOYEE_IMAGE", lcl_obj_SP_Parameters);

                return System.UInt64.Parse(lcl_obj_ImageCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_ImageCode;
        }

        public ulong Update(CCL.BusinessEntities.HRIS.EmployeeImage lcl_obj_EmployeeImage, object IP_obj_DBManager)
        {
            System.UInt64 lcl_ui64_ImageCode = 0;

            lcl_ui64_ImageCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                System.Data.OracleClient.OracleParameter lcl_obj_ImageCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_IMAGE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_ImageCode.Direction = System.Data.ParameterDirection.Output;

                System.Data.OracleClient.OracleParameter lcl_obj_ImageType = new System.Data.OracleClient.OracleParameter("v_IMAGE_TYPE", System.Data.OracleClient.OracleType.NVarChar);
                lcl_obj_ImageType.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ImageType.Value = lcl_obj_EmployeeImage.ImageType;

                System.Data.OracleClient.OracleParameter lcl_obj_ImageSize = new System.Data.OracleClient.OracleParameter("v_IMAGE_SIZE", System.Data.OracleClient.OracleType.Int32);
                lcl_obj_ImageSize.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_ImageSize.Value = lcl_obj_EmployeeImage.ImageSize;

                //convert the image to byte[]
                System.Data.OracleClient.OracleParameter lcl_obj_Image = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_IMAGE", System.Data.OracleClient.OracleType.Blob);
                lcl_obj_Image.Direction = System.Data.ParameterDirection.Input;
                //lcl_obj_Image.Value =lcl_obj_EmployeeImage.Image ;
                //System.Drawing.Image.FromStream
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    switch (lcl_obj_EmployeeImage.ImageType)
                    {
                        case "image/jpeg":
                        case "image/jpg":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "image/gif":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "image/png":
                            lcl_obj_EmployeeImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                    }









                    lcl_obj_Image.Value = ms.ToArray();
                }

                System.Data.OracleClient.OracleParameter lcl_obj_EmployeeCode = new System.Data.OracleClient.OracleParameter("v_EMPLOYEE_CODE", System.Data.OracleClient.OracleType.Number);
                lcl_obj_EmployeeCode.Direction = System.Data.ParameterDirection.Input;
                lcl_obj_EmployeeCode.Value = lcl_obj_EmployeeImage.EmployeeCode;

                System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_ImageCode, lcl_obj_ImageType, lcl_obj_ImageSize, lcl_obj_Image, lcl_obj_EmployeeCode };
                lcl_obj_DBManager.ExecuteStoredProcedure("HRIS_UPDT_EMPLOYEE_IMAGE", lcl_obj_SP_Parameters);

                return 11;
                // System.UInt64.Parse(lcl_obj_ImageCode.Value.ToString());

            }, "BMLExceptionPolicy");

            return lcl_ui64_ImageCode;
        }
        public ulong Save(CCL.BusinessEntities.HRIS.EmployeeImage IP_obj_A)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeImage Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeImage Get(ulong IP_ui64_Code)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeImage Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public CCL.BusinessEntities.HRIS.EmployeeImage Get(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeImage> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            throw new NotImplementedException();
        }

        public List<CCL.BusinessEntities.HRIS.EmployeeImage> GetList(string IP_str_SqlQuery)
        {
            throw new NotImplementedException();
        }
    }
}
