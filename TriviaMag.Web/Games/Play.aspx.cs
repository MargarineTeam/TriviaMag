namespace TriviaMag.Web.Games
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.ModelBinding;

    using Ninject;

    using Services.Contracts;

    public partial class Play : System.Web.UI.Page
    {
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
            LoadFirstQuestion(Request.QueryString["id"]);
        }

        private void LoadFirstQuestion(string gameID)
        {
            var id = int.Parse(gameID);
            this.QuestionLabel.Text = this.games.GetById(id).Questions.FirstOrDefault().Text;
        }

        private string NextQuestion()
        {
            throw new NotImplementedException();
        }

        public object GetGameData([QueryString("id")]int gameID)
        {
            return this.games.GetById(gameID);
        }
    }
}