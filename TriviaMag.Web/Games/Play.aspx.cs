﻿namespace TriviaMag.Web.Games
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Ninject;

    using Services.Contracts;
    using System.Web.Services;
    using System.Web.Script.Services;
    using TriviaMag.Models;
    using System.Collections;
    using System.Web.UI.WebControls;

    public partial class Play : System.Web.UI.Page
    {
        private int currentGameId = 0;
        private static int staticCurrentGameId = 0;
        private Game game;

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
                //TODO:  message and redirect to create game
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
                this.RadioButtonList.DataSource = GetAnswersData(0);
                this.RadioButtonList.DataBind();
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

            return answers;
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
            CheckIfCorrectAnswer();
            var currentQuestionIndex = int.Parse(Session["quetionIndex"].ToString()) + 1;
            var allQuestions = (List<Question>)Session["questions"];

            if (currentQuestionIndex < allQuestions.Count)
            {
                Session["quetionIndex"] = currentQuestionIndex;
                var firstNameTextbox = playGameView.FindControl("QuestionLabel") as Label;
                var currentQuestion = allQuestions[currentQuestionIndex];
                firstNameTextbox.Text = currentQuestion.Text;
                this.RadioButtonList.DataSource = GetAnswersData(currentQuestionIndex);
                this.RadioButtonList.DataBind();
                this.PleaseWorks.Update();
            }
            else
            {
                UpdatePlayerPoints();
                Response.Redirect("~/");
            }
        }

        private void CheckIfCorrectAnswer()
        {
            var correctAnswer = this.game.Questions.Skip(int.Parse(Session["quetionIndex"].ToString()))
                .Take(1)
                .FirstOrDefault()
                .TrueAnswer;

            var userAnswer = this.RadioButtonList.SelectedValue;
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
                //this.game.Creator.Score++;
                this.games.UpdateGame(this.game);

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

                this.games.UpdateGame(this.game);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json, XmlSerializeString = false)]
        public static object GetGameServiceHttpGet(int category)
        {
            return staticGames.GetById(staticCurrentGameId);
        }
    }
}