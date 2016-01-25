namespace TriviaMag.Web.Statistics
{
    using Ninject;
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using Services.Contracts;
    using System.Collections.Generic;

    public partial class Statistics : Page
    {
        [Inject]
        public IUserService UserService { get; set; }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("~/Account/Login");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public ICollection<Services.Statistics> GetStats()
        {
            var currentUser = this.UserService.GetByUsername(HttpContext.Current.User.Identity.Name);
            var stats = this.UserService.getUserStatsById(currentUser.Id);
            return stats.ToList();
        }
    }
}