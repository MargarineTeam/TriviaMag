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

        protected void Page_Load(object sender, EventArgs e)
        {
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
            return this.UserService.GetAll().Where(x => x.UserName != currentUser).OrderBy(x => x.UserName);
        }

        public void GridView1_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            var row = int.Parse(e.CommandArgument.ToString());
            var id = this.GridView1.DataKeys[row].Value.ToString();
            var current = (Game)Session["game"];
            current.ReceiverId = id;
            Session["game"] = current;
            var test = Session["game"];
        }

        public void CreateGame_Click()
        {

        }
    }
}