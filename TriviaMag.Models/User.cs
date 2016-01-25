namespace TriviaMag.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Game> games;

        public User()
        {
            this.games = new HashSet<Game>();
        }

        public string PicturePath { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Role { get; set; }

        public int Score { get; set; }

        public ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
