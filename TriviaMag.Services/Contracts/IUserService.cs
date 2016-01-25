namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;
    using System;
    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(String id);

        Statistics getUserStatsById(int id);
    }
}