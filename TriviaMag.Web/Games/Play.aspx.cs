namespace TriviaMag.Web.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Ninject;

    using Services.Contracts;

    public partial class Play : System.Web.UI.Page
    {
        private int currentQuestion = 1;
        private int currentGameId = 0;

        [Inject]
        public IGameService games { get; set; }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Unauthorized/Unauthorized.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.currentGameId = int.Parse(Request.QueryString["id"]);
            LoadFirstQuestion();
        }

        private void LoadFirstQuestion()
        {
            this.QuestionLabel.Text = this.games.GetById(currentGameId).Questions.FirstOrDefault().Text;
            currentQuestion++;
        }

        private string NextQuestion()
        {
            throw new NotImplementedException();
        }

        public object GetGameData()
        {
            return this.games.GetById(currentGameId);
        }

        public IQueryable<string> GetAnswersData()
        {
            var answers = new List<string>();
            answers.Add(this.games.GetById(currentGameId).Questions.Skip(currentQuestion - 1).Take(1).FirstOrDefault().WrongAnswerOne);
            answers.Add(this.games.GetById(currentGameId).Questions.Skip(currentQuestion - 1).Take(1).FirstOrDefault().WrongAnswerTwo);
            answers.Add(this.games.GetById(currentGameId).Questions.Skip(currentQuestion - 1).Take(1).FirstOrDefault().WrongAnswerThree);
            answers.Add(this.games.GetById(currentGameId).Questions.Skip(currentQuestion - 1).Take(1).FirstOrDefault().TrueAnswer);

            return answers.AsQueryable();
        }

        protected void SubmitAnswerButton_Click(object sender, EventArgs e)
        {
            CheckIfCorrectAnswer();
            currentQuestion++;
            this.RadioButtonList.DataSource = GetAnswersData();
            this.RadioButtonList.DataBind();
        }

        private void CheckIfCorrectAnswer()
        {
            var correctAnswer = this.games.GetById(currentGameId).Questions.Skip(currentQuestion - 1).Take(1).FirstOrDefault().TrueAnswer;
            var userAnswer = this.RadioButtonList.SelectedValue;
            if (userAnswer == correctAnswer)
            {
                UpdatePlayerPoints();
            }
        }

        private void UpdatePlayerPoints()
        {
            if (this.games.GetById(currentGameId).Creator.UserName == HttpContext.Current.User.Identity.Name)
            {
                this.games.GetById(currentGameId).CreatorScore++;
            }
            else
            {
                this.games.GetById(currentGameId).ReceiverScore++;
            }
        }
    }
}