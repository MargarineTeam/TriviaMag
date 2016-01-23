using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Common;
using TriviaMag.Models;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Web
{
    public partial class CreateQuestion : Page
    {
        [Inject]
        protected IQuestionService questions { get; set; }

        //public CreateQuestion(IQuestionService questions)
        //{
        //    this.questions = questions;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new HashSet<string>();
            list.Add(Categories.Art);
            list.Add(Categories.Entertainment);
            list.Add(Categories.History);
            list.Add(Categories.Science);
            list.Add(Categories.Sport);
            this.categoryDropdown.DataSource = list;
            this.categoryDropdown.DataBind();
        }

        protected void SubmitQuestion(object sender, EventArgs e)
        {
            var questionText = this.textTextbox.Text;
            var correctAnswer = this.correctAnswerTextbox.Text;
            var wrongAnswerOne = this.FirstWrongAnswerTextbox.Text;
            var wrongAnswerTwo = this.SecondWrongAnswerTextbox.Text;
            var wrongAnswerThree = this.ThirdWrongAnswerTextbox.Text;
            var category = this.categoryDropdown.Text;

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

            Response.Redirect("~/Default");
        }
    }
}