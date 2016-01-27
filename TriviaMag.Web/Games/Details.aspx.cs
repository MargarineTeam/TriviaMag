using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Models;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Web.Games
{
    public partial class Details : System.Web.UI.Page
    {
        private Game game;

        [Inject]
        public IGameService games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.game = GetGameData();
            InitializeGameStatus();
        }

        private void InitializeGameStatus()
        {
            if (this.game.IsFinished)
            {
                this.StatusLabel.Text = "Finished";
                return;
            }

            if (this.game.Receiver.UserName == HttpContext.Current.User.Identity.Name)
            {
                this.StatusLabel.Text = "Your turn";
                return;
            }

            this.StatusLabel.Text = "Opponent's turn";
        }

        public Game GetGameData()
        {
            var currentGameId = int.Parse(Request.QueryString["id"]);
            var game = this.games.GetById(currentGameId);
            return game;
        }
    }
}