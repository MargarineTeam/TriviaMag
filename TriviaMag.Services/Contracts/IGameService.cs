using System.Linq;
using TriviaMag.Models;

namespace TriviaMag.Services.Contracts
{
    public interface IGameService
    {
        IQueryable<User> GetAll();

    }
}
