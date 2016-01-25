namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IGameService
    {
        IQueryable<Game> GetAll();

        Game GetById(int id);

        void CreateGame(Game game);

        void UpdateGame(Game game);

        //IQueryable<Game> GetAllFinishedGamesById(string id);
    }
}
