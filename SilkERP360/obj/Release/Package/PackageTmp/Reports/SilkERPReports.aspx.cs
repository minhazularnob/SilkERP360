using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace SilkERP360.Reports.SCPM
{
    public partial class SilkERPReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.Session["USR_CNTXT"] == null)
                {
                    //session not marked.
                    //intrusion detected
                    System.String lcl_str_URL = HttpContext.Current.Request.ApplicationPath + "index.aspx";
                    Response.Redirect(lcl_str_URL, false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = (SilkERP360.CCL.Repository.AuthenticUserContext)this.Session["USR_CNTXT"];
                //if (lcl_obj_AuthenticUserContext.UserProfile.AccessLevel < 5)
                //{
                //    //session not marked.
                //    //intrusion detected
                //    System.String lcl_str_URL = HttpContext.Current.Request.ApplicationPath + "index.aspx";
                //    Response.Redirect(lcl_str_URL, false);
                //    Context.ApplicationInstance.CompleteRequest();
                //}

                this.lblName.Text = lcl_obj_AuthenticUserContext.UserProfile.EmployeeName;
                this.lblUsername.Text = lcl_obj_AuthenticUserContext.UserProfile.UserName;
                this.lblDesignation.Text = lcl_obj_AuthenticUserContext.UserProfile.Designation.Name;
                this.lblIP.Text = this.Request.UserHostAddress;
                //System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(lcl_obj_AuthenticUserContext.UserProfile.Image.Image);
                
                //System.IO.MemoryStream  ms = new System.IO.MemoryStream();
                //lcl_obj_AuthenticUserContext.UserProfile.Image.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                //System.Byte[] lcl_bt_Image = ms.ToArray();

                //System.Drawing.Bitmap bit = new System.Drawing.Bitmap(ms, true);
                //bit.Save(Server.MapPath("abc.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                this.imgUser.Src = "data:" + lcl_obj_AuthenticUserContext.UserProfile.Image.ImageType + ";base64," + lcl_obj_AuthenticUserContext.UserProfile.Image.ImageData;

                //this.dvEmpImage.Controls.Add(.Controls.Add((lcl_obj_AuthenticUserContext.UserProfile.Image.Image);
                //lcl_obj_AuthenticUserContext.UserProfile.Image.Image
            }
            catch (System.Exception Ex)
            {
                System.String lcl_str_URL = HttpContext.Current.Request.ApplicationPath + "index.aspx";
                Response.Redirect(lcl_str_URL, false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
    }
}