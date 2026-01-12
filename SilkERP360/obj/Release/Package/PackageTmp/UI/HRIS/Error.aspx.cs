using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilkERP360.UI.HRIS
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.txtError.Text = this.Session["Err"].ToString();
            this.txtStTrace.Text = this.Session["StTrace"].ToString();
            //this.txtTerS.Text = this.Session["TarS"].ToString();

        }
    }
}