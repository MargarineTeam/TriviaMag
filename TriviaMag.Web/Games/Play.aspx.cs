namespace TriviaMag.Web.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Services.Contracts;
    using System.Web.Services;
    using System.Web.Script.Services;

    using Ninject;

    using TriviaMag.Models;
    using System.Web.UI.WebControls;

    public partial class Play : System.Web.UI.Page
    {
        private int currentGameId = 0;
        private Game game;
        private static int displayCounter = 5;
        private static double totalCounter = 0;

        [Inject]
        public IGameService games { get; set; }

        [Inject]
        public static IGameService staticGames { get; set; }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Unauthorized/Unauthorized.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("~/");
            }

            this.currentGameId = int.Parse(Request.QueryString["id"]);
            this.game = this.games.GetById(this.currentGameId);

            if (this.game == null)
            {
                Response.Redirect("~/");
            }

            if (this.game.Receiver == null)
            {
                Response.Redirect("~/Games/Create");
            }

            if (HttpContext.Current.User.Identity.Name == this.game.Creator.UserName && this.game.IsFinished)
            {
                Response.Redirect("~/Games/ListGames");
            }

            if (HttpContext.Current.User.Identity.Name == this.game.Receiver.UserName && this.game.IsFinished)
            {
                Response.Redirect("~/Games/ListGames");
            }

            if (HttpContext.Current.User.Identity.Name != this.game.Creator.UserName && HttpContext.Current.User.Identity.Name != this.game.Receiver.UserName)
            {
                Response.Redirect("~/");
            }

            if (!this.IsPostBack)
            {
                Session["score"] = 0;
                Session["quetionIndex"] = 0;
                Session["questions"] = this.game.Questions.OrderBy(x => Guid.NewGuid()).ToList();
                var data = this.GetAnswersData(0);
                this.Btn1.Text = data[0];
                this.Btn2.Text = data[1];
                this.Btn3.Text = data[2];
                this.Btn4.Text = data[3];
            }
        }

        public Game GetGameData()
        {
            this.game = this.games.GetById(this.currentGameId);
            return this.game;
        }

        public IList<string> GetAnswersData(int index)
        {
            var answers = new List<string>();
            var all = (List<Question>)Session["questions"];
            var test = all[index];

            answers.Add(test.WrongAnswerOne);
            answers.Add(test.WrongAnswerTwo);
            answers.Add(test.WrongAnswerThree);
            answers.Add(test.TrueAnswer);

            return answers.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public string GetQuestion()
        {
            var index = int.Parse(Session["quetionIndex"].ToString());
            var questions = (List<Question>)Session["questions"];
            var question = questions[index];
            return question.Text;
        }

        protected void SubmitAnswerButton_Click(object sender, EventArgs e)
        {
            var text = ((Button)sender).Text;
            SubmitButton(text);
        }

        private void SubmitButton(string text)
        {
            CheckIfCorrectAnswer(text);
            var currentQuestionIndex = int.Parse(Session["quetionIndex"].ToString()) + 1;
            var allQuestions = (List<Question>)Session["questions"];

            if (currentQuestionIndex < allQuestions.Count)
            {
                Session["quetionIndex"] = currentQuestionIndex;
                var firstNameTextbox = playGameView.FindControl("QuestionLabel") as Label;
                var currentQuestion = allQuestions[currentQuestionIndex];
                firstNameTextbox.Text = currentQuestion.Text;
                var data = this.GetAnswersData(currentQuestionIndex);
                this.Btn1.Text = data[0];
                this.Btn2.Text = data[1];
                this.Btn3.Text = data[2];
                this.Btn4.Text = data[3];

                this.TimerLabel.Text = "5";
                displayCounter = 5;
                this.PleaseWorks.Update();
            }
            else
            {
                UpdatePlayerPoints();
                Session["score"] = null;
                Session["quetionIndex"] = null;
                Session["questions"] = null;

                totalCounter = 0;
                displayCounter = 5;

                Response.Redirect("~/Games/Details?id=" + game.Id);
            }
        }

        private void CheckIfCorrectAnswer(string text)
        {
            var index = int.Parse(Session["quetionIndex"].ToString());
            var questions = (List<Question>)(Session["questions"]);
            var correctAnswer = questions.Skip(index)
                                         .Take(1)
                                         .FirstOrDefault()
                                         .TrueAnswer;

            var userAnswer = text;
            if (userAnswer == correctAnswer)
            {
                var score = int.Parse(Session["score"].ToString()) + 1;
                Session["score"] = score;
            }
        }

        private void UpdatePlayerPoints()
        {
            var score = int.Parse(Session["score"].ToString());

            if (this.games.GetById(currentGameId).Creator.UserName == HttpContext.Current.User.Identity.Name)
            {
                this.game.CreatorScore = score;
                this.game.CreatorTime = totalCounter / 10.0;
            }
            else
            {
                this.game.ReceiverScore = score;
                this.game.IsFinished = true;

                if (this.game.CreatorScore > this.game.ReceiverScore)
                {
                    this.game.Creator.Score++;
                }
                else if (this.game.CreatorScore < this.game.ReceiverScore)
                {
                    this.game.Receiver.Score++;
                }
                else
                {
                    this.game.Creator.Score++;
                    this.game.Receiver.Score++;
                }

                this.game.ReceiverTime = totalCounter / 10.0;
            }

            this.games.UpdateGame(this.game);
        }

        protected void gameTimer_Tick(object sender, EventArgs e)
        {
            totalCounter += 1;
            if (totalCounter % 10 == 0)
            {
                displayCounter--;
                this.TimerLabel.Text = displayCounter.ToString();
            }

            if (displayCounter == 0)
            {
                SubmitButton(string.Empty);
                return;
            }
        }
    }
}