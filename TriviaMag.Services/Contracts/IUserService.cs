namespace TriviaMag.Services.Contracts
{
    using System.Linq;
    using Models;
    using System;
    using System.Collections.Generic;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(String id);

        ICollection<Statistics> getUserStatsById(string id);

        User GetByUsername(string username);

        void  UpdateUser(string id, string username, string firstname, string lastname);
    }
}