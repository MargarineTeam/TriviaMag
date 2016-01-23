namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using TriviaMag.Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();
    }
}