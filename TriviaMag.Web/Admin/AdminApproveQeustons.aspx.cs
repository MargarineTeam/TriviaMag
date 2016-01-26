using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Models;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Web.Admin
{
    public partial class AdminApproveQeustons : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IQuestionService QuestionService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var user = this.UserService.GetByUsername(HttpContext.Current.User.Identity.Name);
                if (user.Role != "Admin")
                {
                    this.Response.Redirect("~/Unauthorized/Unauthorized");
                }

            }
            else
            {
                this.Response.Redirect("~/Account/Login");
            }
        }

        public IQueryable<Question> GetAllToBeApproved()
        {
            var questionsToBeApproved = this.QuestionService.GetAllToBeApproved();
            return questionsToBeApproved.AsQueryable();
        }
    }
}