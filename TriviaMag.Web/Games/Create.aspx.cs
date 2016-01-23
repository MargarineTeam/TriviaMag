using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TriviaMag.Services.Contracts;

namespace TriviaMag.Web.Games
{
    public partial class Create : System.Web.UI.Page
    {
        [Inject]
        public IGameService GameService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GameService.GetAll();
        }
    }
}