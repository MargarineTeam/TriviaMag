namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IGameService
    {
        IQueryable<Game> GetAll();

    }
}
