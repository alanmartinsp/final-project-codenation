using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User GetByLoginAndPassword(string login, string password);
    }
}
