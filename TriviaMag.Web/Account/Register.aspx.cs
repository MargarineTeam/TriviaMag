namespace TriviaMag.Web.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using TriviaMag.Models;
    using System.IO;
    public partial class Register : Page
    {
        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/");
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
        //    if (FileUploadControl.HasFile)
        //    {
        //        //string filename = Path.GetFileName(FileUploadControl.FileName);
        //        //FileUploadControl.SaveAs(Server.MapPath("~/Uploaded_Files/") + filename);
        //        //StatusLabel.Text = "Upload status: File uploaded!";
        //    }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<UserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            // var test = FileUploadControl.FileName;
            string filePathAndName = string.Empty;

            try
            {
                filePathAndName = FileUploadControl.Upload();
            }
            catch (InvalidOperationException ex)
            {
                //this.DivLabelErrorMessage.Visible = true;
                //this.LabelErrorMessage.Text = ex.Message;

                return;
            }

            //if (string.IsNullOrEmpty(filePathAndName))
            //{
            //    user.ImageID = this.data.Images.Find(1).ID;
            //}
            //else
            //{
            //    user.Image = new Image { Path = filePathAndName };
            //}
            var user = new User()
            {
                UserName = Username.Text,
                Email = Email.Text,
                Role = "Private",
                Firstname = FirstName.Text,
                Lastname = LastName.Text,
                Score = 0,
                PicturePath = filePathAndName
            };

            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}