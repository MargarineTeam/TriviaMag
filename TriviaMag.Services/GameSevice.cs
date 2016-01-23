
namespace TriviaMag.Services
{
    using System;
    using System.Linq;
    using Models;
    using Contracts;

    public class GameSevice : IGameService
    {

      

        public IQueryable<User> GetAll()
        {
            //return this.games.All();
            throw new NotImplementedException();
        }
    }
}
