using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VisaApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logincontent.Text = "";
            if (Session["Admin"]!=null)
            {
                logincontent.Text = "Logout";
            }
            else if (Session["UserId"]!=null)
            {
                logincontent.Text = "Logout";
            }
        }
    }
}