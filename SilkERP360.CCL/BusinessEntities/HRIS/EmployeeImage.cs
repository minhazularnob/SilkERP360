using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [System.Serializable]
    public class EmployeeImage : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore, System.Runtime.Serialization.ISerializable
    {
        private System.UInt64 m_ui64_EmployeeImageCode;
        public System.UInt64 EmployeeImageCode
        {
            get { return m_ui64_EmployeeImageCode; }
            set { this.m_ui64_EmployeeImageCode = value; }
        }
       

        private System.String m_str_ImageData;
        public System.String ImageData
        {
            get { return m_str_ImageData; }
            set
            {
                //System.Byte[] lcl_b_ImageBytes = System.Convert.FromBase64String(value);
                //System.IO.MemoryStream lcl_obj_ImageInMemory = new System.IO.MemoryStream(lcl_b_ImageBytes);
                //this.m_img_Image = System.Drawing.Image.FromStream(lcl_obj_ImageInMemory);
                this.m_str_ImageData = value;
            }
        }

        private System.String m_str_ImageType;
        /// <summary>
        /// Must be initialized before initializing Image property
        /// </summary>
        public System.String ImageType
        {
            get { return m_str_ImageType; }
            set { this.m_str_ImageType = value; }
        }

        private System.Int32 m_i32_ImageSize;
        public System.Int32 ImageSize
        {
            get { return m_i32_ImageSize; }
            set { this.m_i32_ImageSize = value; }
        }

       // for test
        private System.String m_img_Image1;

        public System.String Image1
        {
            get { return m_img_Image1; }
            set
            {   System.Byte[] lcl_b_ImageBytes = System.Convert.FromBase64String(value);
                System.IO.MemoryStream lcl_obj_ImageInMemory = new System.IO.MemoryStream(lcl_b_ImageBytes);
                this.m_img_Image = System.Drawing.Image.FromStream(lcl_obj_ImageInMemory);

                this.m_img_Image1 = value;
            }
        }


        private System.Drawing.Image m_img_Image;

        public System.Drawing.Image Image
        {
            get { return m_img_Image; }
            set { this.m_img_Image = value; }
        }

           
        public EmployeeImage()
        { 
        }


        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            //throw new NotImplementedException();
            info.AddValue("EmployeeCode", this.m_ui64_EmployeeCode);
            info.AddValue("EmployeeImageCode", this.m_ui64_EmployeeImageCode);
            info.AddValue("ImageData", this.m_str_ImageData);
            //info.AddValue("Image", this.m_img_Image);
            info.AddValue("ImageType", this.m_str_ImageType);
            info.AddValue("ImageSize", this.m_i32_ImageSize);
        }
    }
}
