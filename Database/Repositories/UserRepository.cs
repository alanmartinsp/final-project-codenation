using Business.Models;
using Business.Repositories;
using Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LocalContext context) : base(context)
        {
        }
    }
}
