namespace TriviaMag.Web.Games
{
    using Services.Contracts;
    using System;
    using System.Linq;

    using Ninject;

    using TriviaMag.Models;
    using System.Web.ModelBinding;
    public partial class Play : System.Web.UI.Page
    {
        private Game currentGame;
        private int currentGameId;

        [Inject]
        public IGameService games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFirstQuestion(currentGameId);
        }

        private void LoadFirstQuestion([QueryString("id")]int gameID)
        {
            this.QuestionLabel.Text = this.games.GetById(gameID).Questions.FirstOrDefault().Text;
        }

        private string NextQuestion()
        {
            throw new NotImplementedException();
        }

        public object GetGameData([QueryString("id")]int gameID)
        {
            currentGameId = gameID;
            return this.games.GetById(gameID);
        }
    }
}