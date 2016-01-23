namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();
    }
}