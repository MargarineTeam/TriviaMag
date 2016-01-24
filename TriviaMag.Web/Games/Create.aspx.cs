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
        public IQuestionService GameService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.categoriesConstants = new Categories();
            var categoriesList = categoriesConstants.GetCategories();
            this.CategoryDropdown.DataSource = categoriesList;
            this.CategoryDropdown.DataBind();
        }
    }
}