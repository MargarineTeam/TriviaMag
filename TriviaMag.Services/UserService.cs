namespace TriviaMag.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;

    public class UserService : IUserService
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
