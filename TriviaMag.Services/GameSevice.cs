namespace TriviaMag.Services
{
    using System.Linq;

    using Models;
    using Contracts;
    using Data.Repositories;

    public class GameSevice : IGameService
    {
        private IRepository<Game> games;

        public GameSevice(IRepository<Game> games)
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
    }
}
