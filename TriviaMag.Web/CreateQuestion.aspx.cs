using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Models;

namespace TriviaMag.Web
{
    public partial class CreateQuestion : Page
    {
        //private IQuestionService questions;

        public CreateQuestion()
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitQuestion(object sender, EventArgs e)
        {
            var questionText = this.textTextbox.Text;
            var correctAnswer = this.correctAnswerTextbox.Text;
            var wrongAnswerOne = this.FirstWrongAnswerTextbox.Text;
            var wrongAnswerTwo = this.SecondWrongAnswerTextbox.Text;
            var wrongAnswerThree = this.ThirdWrongAnswerTextbox.Text;

            Question createQuestion = new Question()
            {
                Text = questionText,
                TrueAnswer = correctAnswer,
                WrongAnswerOne = wrongAnswerOne,
                WrongAnswerTwo = wrongAnswerTwo,
                WrongAnswerThree = wrongAnswerThree
            };
        }
    }
}