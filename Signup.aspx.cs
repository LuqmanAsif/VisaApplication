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
    public partial class Signup : System.Web.UI.Page
    {
        VisaDBLayer context = new VisaDBLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignupBtn_Click(object sender, EventArgs e)
        {
            var userName = email.Text;
            var pass = password.Text;
            if (userNameAlreadyExist(userName))
            {
                //Display Error Message
            }
            else
            {
                User user = new User();
                user.UserName = userName;
                user.Password = pass;
                var res = context.CreateUser(user);
                if (res)
                {
                    //Success Message
                }
                else
                {
                    //Error Message
                }
            }
        }
        public bool userNameAlreadyExist(string username)
        {
            var res = context.CheckAlreadyUserExistorNot(username);
            return res;
        }
    }
}