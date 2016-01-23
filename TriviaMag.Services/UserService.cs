namespace TriviaMag.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;

    public class UserService : IUserService
    {
        private IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(int id)
        {
            return this.users.GetById(id);
        }

        public Statistics getUserStatsById(int id)
        {
            var currentUser = this.users.GetById(id);

            return new Statistics(1, 1, 1, 1, 1);
        }
    }
}
