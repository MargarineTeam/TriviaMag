namespace TriviaMag.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TriviaMag.Models;

    public class TriviaMagDbContext : IdentityDbContext<User>
    {
        public TriviaMagDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TriviaMagDbContext Create()
        {
            return new TriviaMagDbContext();
        }
    }
}
