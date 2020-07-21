using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Business.Services
{
    public class UserService : GenericService<User>
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Auth(string login, string password)
        {
            string hashPass = GenerateHashPassword(login, password);
            return (_repository as IUserRepository).GetByLoginAndPassword(login, hashPass);
        }

        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GenerateHashPassword(string login, string password)
        {
            string key = "codenationlog";
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes($"{login}.{password}.{key}"));

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        public override void Save(User user)
        {
            string hashPass = GenerateHashPassword(user.Email, user.Password);
            user.Password = hashPass;

            base.Save(user);
        }
    }
}
