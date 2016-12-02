using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Comp229_TeamProject.Models;
using System.Web.Security;

namespace Comp229_TeamProject.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(Object sender, EventArgs e)
        {

        }
        protected void LogIN(object sender, EventArgs e)
        {
            if (FormsAuthentication.Authenticate(UserName.Text, Password.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, true);
            }
            {

            }
        }
    }
}

   