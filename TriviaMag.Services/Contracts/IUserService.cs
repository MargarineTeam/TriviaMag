namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(int id);

        IQueryable<Statistics> getUserStatsById(string id);

        User GetByUsername(string username);
    }
}