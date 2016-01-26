namespace TriviaMag.Web
{
    using System;
    using System.Web;
    using System.Web.UI;

    using Ninject;

    using TriviaMag.Common;
    using TriviaMag.Models;
    using TriviaMag.Services.Contracts;

    public partial class CreateQuestion : Page
    {
        private Categories categoriesConstants;

        [Inject]
        public IQuestionService questions { get; set; }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Unauthorized/Unauthorized.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.categoriesConstants = new Categories();
            var categoriesList = this.categoriesConstants.GetCategories();
            this.categoryDropdown.DataSource = categoriesList;
            this.categoryDropdown.DataBind();
            //  this.DivLabelErrorMessage.Visible = false;
        }

        protected void SubmitQuestion(object sender, EventArgs e)
        {
            var questionText = this.textTextbox.Text;
            var correctAnswer = this.correctAnswerTextbox.Text;
            var wrongAnswerOne = this.FirstWrongAnswerTextbox.Text;
            var wrongAnswerTwo = this.SecondWrongAnswerTextbox.Text;
            var wrongAnswerThree = this.ThirdWrongAnswerTextbox.Text;
            var category = this.categoryDropdown.Text;

            if (correctAnswer != wrongAnswerOne && correctAnswer != wrongAnswerTwo && correctAnswer != wrongAnswerThree &&
                wrongAnswerOne != wrongAnswerTwo && wrongAnswerOne != wrongAnswerThree &&
                wrongAnswerTwo != wrongAnswerThree && category != "- Select category -")
            {
                Question createQuestion = new Question()
                {
                    Text = questionText,
                    TrueAnswer = correctAnswer,
                    WrongAnswerOne = wrongAnswerOne,
                    WrongAnswerTwo = wrongAnswerTwo,
                    WrongAnswerThree = wrongAnswerThree,
                    Category = category
                };

                this.questions.CreateQuestion(createQuestion);

                Response.Redirect("~/");
            }
            else
            {
                var message = "Answers cannot be repeated!";

                if (category == "- Select category -")
                {
                    message = "You must select category!";
                }
                
                this.DivLabelErrorMessage.Visible = true;
                this.LabelErrorMessage.Text = message;
            }

        }
    }
}