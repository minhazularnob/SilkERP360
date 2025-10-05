using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public class EmployeeImageCore : SilkERP360.CCL.Validation.ValidationBase
    {
        private System.UInt64 m_ui64_EmployeeImageCode;
        public System.UInt64 EmployeeImageCode
        {
            get { return m_ui64_EmployeeImageCode; }
            //set { m_ui64_EmployeeImageCode = value; }
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
                m_str_ImageData = value;
            }
        }

        private System.String m_str_ImageType;
        /// <summary>
        /// Must be initialized before initializing Image property
        /// </summary>
        public System.String ImageType
        {
            get { return m_str_ImageType; }
            //set { m_str_ImageType = value; }
        }

        private System.Int32 m_i32_ImageSize;
        public System.Int32 ImageSize
        {
            get { return m_i32_ImageSize; }
            //set { m_i32_ImageSize = value; }
        }

        private System.Drawing.Image m_img_Image;
        public System.Drawing.Image Image
        {
            get { return m_img_Image; }
            //set { m_img_Image = value; }
        }

        public EmployeeImageCore(System.UInt64 IP_ui64_ImageCode,System.String IP_str_ImageType,System.Int32 IP_i32_ImageSize,
                                 System.String IP_str_ImageData)
        {
            this.m_ui64_EmployeeImageCode = IP_ui64_ImageCode;
            this.m_str_ImageType = IP_str_ImageType;
            this.m_i32_ImageSize = IP_i32_ImageSize;
            this.m_str_ImageData = IP_str_ImageData;
        }

    }
}
