namespace TriviaMag.Services
{
    using System.Linq;

    using Models;
    using Contracts;
    using Data.Repositories;

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
    }
}
