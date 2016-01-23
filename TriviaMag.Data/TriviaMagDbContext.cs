namespace TriviaMag.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using TriviaMag.Models;

    public class TriviaMagDbContext : IdentityDbContext<User>, ITriviaMagDbContext
    {
        public TriviaMagDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public override IDbSet<User> Users { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Question> Questions { get; set; }

        public virtual IDbSet<Answer> Answers { get; set; }
        
        public static TriviaMagDbContext Create()
        {
            return new TriviaMagDbContext();
        }
    }
}
