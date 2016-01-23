
namespace TriviaMag.Services
{
    using System;
    using System.Linq;
    using Models;
    using Contracts;

    public class GameSevice : IGameService
    {

        //private readonly IRepository<User> users;

        //public GameSevice(IRepository<User> users)
        //{
        //    this.users = users;
        //}

        public IQueryable<User> GetAll()
        {
            //return this.users.All();
            throw new NotImplementedException();
        }
    }
}
