namespace TriviaMag.Services
{
    using System.Linq;

    using Contracts;
    using Models;
    using Data.Repositories;
    using System;
    using Common;
    using System.Collections.Generic;
	
    public class UserService : IUserService
    {
        private IRepository<User> users;

        private IRepository<Game> games;

        public UserService(IRepository<User> users, IRepository<Game> games)
        {
            this.users = users;
            this.games = games;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(String id)
        {
            return this.users.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return this.users.All().Where(u => u.UserName == username).FirstOrDefault();
        }

        public void UpdateUser(string id, string username, string firstname, string lastname)
        {
            var currentUsr = this.users.GetById(id);
            currentUsr.UserName = username;
            currentUsr.Firstname = firstname;
            currentUsr.Lastname = lastname;
            this.users.Update(currentUsr);
            this.users.SaveChanges();
        }

        public ICollection<Statistics> getUserStatsById(string id)
        {
            var currentUser = this.users.GetById(id);
            var userGames = this.games.All().Where(x => x.CreatorId == currentUser.Id || x.ReceiverId == currentUser.Id).ToList();
            var gamesGrouped = userGames.GroupBy(g => g.Category);
            var result = new SortedSet<Statistics>();

            foreach (var group in gamesGrouped)
            {
                var currentStat = new Statistics();
                currentStat.Games = group.Count();
                currentStat.Name = group.FirstOrDefault().Category.ToLower();
                var winGamesCount = 0;
                foreach (var game in group)
                {
                    if ((game.Creator.Id == currentUser.Id && game.CreatorScore > game.ReceiverScore) ||
                        (game.ReceiverId == currentUser.Id && game.ReceiverScore > game.CreatorScore))
                    {
                        winGamesCount++;
                    }
                }
                decimal percentage = (winGamesCount * 100) / currentStat.Games;
                currentStat.Percentage = percentage;
                result.Add(currentStat);
            }
            return result;
        }
    }
}
