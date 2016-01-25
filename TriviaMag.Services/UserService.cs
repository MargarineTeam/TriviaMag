namespace TriviaMag.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;
    using System;
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

        public User GetById(String id)
        {
            return this.users.GetById(id);
        }
        public Statistics getUserStatsById(int id)
        {
            //TODO finish
            var currentUser = this.users.GetById(id);
            var userGames = currentUser.Games;

            return new Statistics(1, 1, 1, 1, 1);
        }
    }
}
