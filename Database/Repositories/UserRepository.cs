using Business.Models;
using Business.Repositories;
using Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LocalContext context) : base(context)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetByLoginAndPassword(string login, string password)
        {
            return _context.Users
                           .FirstOrDefault();
        }
    }
}
