using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Services.Contracts;
using TriviaMag.Common;
using TriviaMag.Models;


namespace TriviaMag.Web.Games
{
    public partial class Create : Page
    {
        private Categories categoriesConstants;
        private Game game;

        [Inject]
        public IGameService GameService { get; set; }

        [Inject]
        public IUserService UserService { get; set; }

        [Inject]
        public IQuestionService QuestionService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Unauthorized/Unauthorized.aspx");
            }

            if (!this.IsPostBack)
            {
                this.categoriesConstants = new Categories();
                var categoriesList = categoriesConstants.GetCategories();
                var currentUser = UserService.GetAll()
                         .Where(x => x.UserName == this.User.Identity.Name)
                         .FirstOrDefault();

                this.game = new Game
                {
                    CreatorId = currentUser.Id,
                    IsFinished = false,
                    CreatorScore = 0,
                    ReceiverScore = 0
                };

                Session["game"] = game;
            }
        }

        public void ChooseCategory(Object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            var category = btn.CommandArgument.ToString();
            var current = (Game)Session["game"];
            current.Category = category;
            Session["game"] = current;
        }

        public IQueryable<User> GetUsers()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var users = this.UserService.GetAll()
                                        .Where(x => x.UserName != currentUser && x.Role != "Admin")
                                        .OrderBy(x => x.UserName);

            return users;
        }

        public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            int row = 0;
            if (int.TryParse(e.CommandArgument.ToString(), out row))
            {
                var id = this.GridView1.DataKeys[row].Value.ToString();
                var current = (Game)Session["game"];
                current.ReceiverId = id;
                Session["game"] = current;
                var test = Session["game"];
            }
        }

        public void CreateGame_Click(Object sender, EventArgs e)
        {
            var currentGame = (Game)Session["game"];
            var questions = this.QuestionService.GetRandomQuestionsByCategory(currentGame.Category);

            if (currentGame.ReceiverId == null && currentGame.Category == null)
            {
                this.DivLabelErrorMessage.Visible = true;
                this.LabelErrorMessage.Text = "Second player and category are required!";
            }
            else if (currentGame.ReceiverId == null)
            {
                this.DivLabelErrorMessage.Visible = true;
                this.LabelErrorMessage.Text = "Second player is required!";
            }
            else if (currentGame.Category == null)
            {
                this.DivLabelErrorMessage.Visible = true;
                this.LabelErrorMessage.Text = "Category is required! ";
            }
            else
            {
                var game = new Game
                {
                    CreatorId = currentGame.CreatorId,
                    ReceiverId = currentGame.ReceiverId,
                    CreatorScore = currentGame.CreatorScore,
                    ReceiverScore = currentGame.ReceiverScore,
                    IsFinished = currentGame.IsFinished,
                    Category = currentGame.Category
                };

                game.Questions = questions;
                GameService.CreateGame(game);
                Session["game"] = "";
                Response.Redirect("~/Games/Play?id=" + game.Id);
            }
        }
    }
}