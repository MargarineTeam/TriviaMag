namespace TriviaMag.Services
{
    using System.Linq;

    using Models;
    using Contracts;
    using Data.Repositories;
    using System;

    public class GameService : IGameService
    {
        private IRepository<Game> games;

        public GameService(IRepository<Game> games)
        {
            this.games = games;
        }

        public IQueryable<Game> GetAll()
        {
            return this.games.All();
        }

        public Game GetById(int id)
        {
            return this.games.GetById(id);
        }
        public void CreateGame(Game game)
        {
            this.games.Add(game);
            this.games.SaveChanges();
        }

        public void UpdateGame(Game game)
        {
            this.games.Update(game);
            this.games.SaveChanges();
        }

        //public IQueryable<Game> GetAllFinishedGamesById(string id)
        //{
            
        //}
    }
}
