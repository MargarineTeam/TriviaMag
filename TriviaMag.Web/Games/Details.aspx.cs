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
        [Inject]
        public IGameService games { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Game GetGameData()
        {
            var currentGameId = int.Parse(Request.QueryString["id"]);
            var game = this.games.GetById(currentGameId);
            return game;
        }
    }
}