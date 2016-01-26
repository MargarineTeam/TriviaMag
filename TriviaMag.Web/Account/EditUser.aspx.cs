using Microsoft.AspNet.Identity.Owin;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Web.Account
{
    public partial class EditUser : System.Web.UI.Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var currentUser = this.UserService.GetByUsername(HttpContext.Current.User.Identity.Name);
            //this.username.Text = currentUser.UserName;
            //this.firstName.Text = currentUser.Firstname;
            //this.lastName.Text = currentUser.Lastname;

            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Account/Login");
            }
        }

        public void UpdateUser(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<UserManager>();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            var user = this.UserService.GetByUsername(HttpContext.Current.User.Identity.Name);
            var username = this.username.Text;
            if (username == string.Empty)
            {
                username = user.UserName;
            }
            var firstname = this.firstName.Text;
            if (firstname == string.Empty)
            {
                firstname = user.Firstname;
            }
            var lastname = this.lastName.Text;
            if (lastname == string.Empty)
            {
                lastname = user.Lastname;
            }
            this.UserService.UpdateUser(user.Id, username, firstname, lastname);
            var result = signinManager.PasswordSignIn(username, this.password.Text, true, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    break;

                default:
                    this.Response.Redirect("~/");

                    break;
            }
            this.Response.Redirect("~/");
        }
    }
}