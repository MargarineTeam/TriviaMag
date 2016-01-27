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

        public ICollection<Question> QuestionsToBeApproved
        {
            get; set;
        }

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

        public void ApproveQuestion_Click(object sender, CommandEventArgs e)
        {
            var questionId = int.Parse(e.CommandArgument.ToString());

            var question = this.QuestionService.GetById(questionId);
            question.IsApproved = true;
            this.QuestionService.UpdateQuestion(question);

            Response.Redirect("~/Admin/AdminApproveQeustons");
        }
    }
}