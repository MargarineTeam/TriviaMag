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
        private ICollection<Question> wrongQuestions;
        private ICollection<Question> answeredQuestions;

        public User()
            : base()
        {
            this.games = new HashSet<Game>();
            this.wrongQuestions = new HashSet<Question>();
            this.answeredQuestions = new HashSet<Question>();
            this.Score = 0;
        }

        public string PicturePath { get; set; }

        public Rank Rank { get; set; }

        public int Score { get; set; }

        public virtual ICollection<Question> WrongQuestions
        {
            get
            {
                return this.wrongQuestions;
            }

            set
            {
                this.wrongQuestions = value;
            }
        }

        public virtual ICollection<Question> AnsweredQuestions
        {
            get
            {
                return this.answeredQuestions;
            }

            set
            {
                this.answeredQuestions = value;
            }
        }

        public virtual ICollection<Game> Games
        {
            get
            {
                return this.games;
            }

            set
            {
                this.games = value;
            }
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
