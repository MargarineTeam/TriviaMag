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
                this.CategoryDropdown.DataSource = categoriesList;
                this.CategoryDropdown.DataBind();
            }
        }

        public IQueryable<User> GetUsers()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            return this.UserService.GetAll().Where(x=> x.UserName != currentUser).OrderBy(x=>x.UserName);
        }
    }
}