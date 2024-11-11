using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisaApplication.DataBaseLayer;
using VisaApplication.Modals;

namespace VisaApplication
{
    public partial class Login : System.Web.UI.Page
    {
        VisaDBLayer context = new VisaDBLayer(); 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbutton_Click(object sender, EventArgs e)
        {
            //Two Variables One if is for admin and one if for other user.
            var userName = email.Text;
            var pass = password.Text;
            if (!string.IsNullOrEmpty(userName))
            {
                if (!string.IsNullOrEmpty(pass))
                {
                    if (userName=="admin")
                    {
                        if (pass=="admin@123")
                        {
                            //Admin Dashboard. And Compare Admin to the Database
                            Session["UserName"] = userName;
                            Session["UserRole"] = "Admin";
                        }
                    }
                    else
                    {
                        User user = new User();
                        user.UserName = userName;
                        user.Password = pass;
                        var res = context.validateUser(user);
                        if (res)
                        {
                            //User Dashboard
                            var u = context.GetLoggedUserForSession(userName);
                            Session["UserId"] = u.UserId.ToString();
                            Session["UserRole"] = "User";
                        }
                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}