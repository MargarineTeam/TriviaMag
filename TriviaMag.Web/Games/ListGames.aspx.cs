namespace TriviaMag.Web.Games
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using TriviaMag.Models;
    using Services.Contracts;
    using Ninject;
    using System.Web;
    using System.Linq;

    public partial class ListGames : Page
    {
        [Inject]
        public IGameService GameService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public ICollection<Game> GridViewWaitingGames()
        {
            var currentUser = this.UserService.GetAll().Where(x => x.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();
            var userGames = this.GameService.GetAll().Where(x => x.CreatorId == currentUser.Id || x.ReceiverId == currentUser.Id).ToList();
            var waitingGames = new List<Game>();
            foreach (var game in userGames)
            {
                if (!game.IsFinished && game.CreatorId == currentUser.Id)
                {
                    waitingGames.Add(game);
                }
            }

            return waitingGames;
        }

        public ICollection<Game> GridViewPendingGames()
        {
            var currentUser = this.UserService.GetAll().Where(x => x.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();
            var userGames = this.GameService.GetAll().Where(x => x.CreatorId == currentUser.Id || x.ReceiverId == currentUser.Id).ToList();
            var waitingGames = new List<Game>();
            foreach (var game in userGames)
            {
                if (!game.IsFinished && game.ReceiverId == currentUser.Id)
                {
                    waitingGames.Add(game);
                }
            }

            return waitingGames;
        }

        public ICollection<Game> GridViewFinishedGames()
        {
            var currentUser = this.UserService.GetAll().Where(x => x.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();
            var userGames = this.GameService.GetAll().Where(x => x.CreatorId == currentUser.Id || x.ReceiverId == currentUser.Id).ToList();
            var finishedGames = new List<Game>();
            foreach (var game in userGames)
            {
                if (game.IsFinished)
                {
                    finishedGames.Add(game);
                }
            }

            return finishedGames;
        }
    }
}