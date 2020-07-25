using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected List<User> _users = new List<User>();

        public UserRepository() {
        }

        public UserRepository(List<User> users) {
            _users = users;
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void Dispose()
        {
        }

        public User Get(int id)
        {
            return _users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _users.ToList();
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            return _users.Where(x => x.Email == login && x.Password == password)
                         .FirstOrDefault();
        }

        public void Save(User entity)
        {
            _users.Add(entity);
        }

        public void Update(User entity)
        {
            User user = _users.Where(x => x.Id == entity.Id).FirstOrDefault();
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
        }
    }
}
