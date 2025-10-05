using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    //[System.Serializable]
    public class ItemImage : SilkERP360.CCL.Validation.ValidationBase//, System.Runtime.Serialization.ISerializable
    {
        public ItemImage()
        {
            
        }

        private System.UInt64 m_ui64_ItemImageCode;
        public System.UInt64 ItemImageCode
        {
            get { return m_ui64_ItemImageCode; }
            set { this.m_ui64_ItemImageCode = value; }
        }

        private System.UInt64 m_ui64_ItemCode;
        public System.UInt64 ItemCode
        {
            get { return m_ui64_ItemCode; }
            set { this.m_ui64_ItemCode = value; }
        }
                
        private System.String m_str_ImageB64String;
        public System.String ImageB64String
        {
            get { return m_str_ImageB64String; }
            set
            {
                System.Byte[] lcl_b_ImageBytes = System.Convert.FromBase64String(value);
                System.IO.MemoryStream lcl_obj_ImageInMemory = new System.IO.MemoryStream(lcl_b_ImageBytes);
                this.m_img_Image = System.Drawing.Image.FromStream(lcl_obj_ImageInMemory);
                //this.m_bytArr_Image = System.Convert.FromBase64String(value);
                this.m_str_ImageB64String = value;
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

        private System.UInt32 m_ui32_ImageSize;
        public System.UInt32 ImageSize
        {
            get { return m_ui32_ImageSize; }
            set { this.m_ui32_ImageSize = value; }
        }

        private System.Drawing.Image m_img_Image;
        public System.Drawing.Image Image
        {
            get { return m_img_Image; }
            set { this.m_img_Image = value; }
        }

        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }

        private System.String m_str_Note;
        /// <summary>
        /// Must be initialized before initializing Image property
        /// </summary>
        public System.String Note
        {
            get { return m_str_Note; }
            set { this.m_str_Note = value; }
        }

       // for test
        //private System.String m_img_Image1;
        //public System.String Image1
        //{
        //    get { return m_img_Image1; }
        //    set
        //    {   System.Byte[] lcl_b_ImageBytes = System.Convert.FromBase64String(value);
        //        System.IO.MemoryStream lcl_obj_ImageInMemory = new System.IO.MemoryStream(lcl_b_ImageBytes);
        //        this.m_img_Image = System.Drawing.Image.FromStream(lcl_obj_ImageInMemory);

        //        this.m_img_Image1 = value;
        //    }
        //}


        //private System.Drawing.Image m_img_Image;

        //public System.Drawing.Image Image
        //{
        //    get { return m_img_Image; }
        //    set { this.m_img_Image = value; }
        //}


        


        //public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        //{
        //    //throw new NotImplementedException();
        //    info.AddValue("ItemImageCode", this.m_ui64_ItemImageCode);
        //    info.AddValue("ItemCode", this.m_ui64_ItemCode);
        //    info.AddValue("ImageB64String", this.m_str_ImageB64String);
        //    info.AddValue("Image", this.m_img_Image);
        //    info.AddValue("ImageType", this.m_str_ImageType);
        //    info.AddValue("ImageSize", this.m_ui32_ImageSize);
        //}
    }
}
