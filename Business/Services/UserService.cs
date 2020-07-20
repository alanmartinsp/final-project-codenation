using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class UserService : GenericService<User>
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}
