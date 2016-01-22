namespace TriviaMag.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using TriviaMag.Models;

    public class TriviaMagDbContext : IdentityDbContext<User>
    {
        public TriviaMagDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Answer> Answers { get; set; }

        public static TriviaMagDbContext Create()
        {
            return new TriviaMagDbContext();
        }
    }
}
