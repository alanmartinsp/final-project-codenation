using Business.Models;
using Business.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class AuthService : GenericService<User>
    {

        public AuthService(IUserRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Auth(string login, string password)
        {
            IUserRepository repository = _repository as IUserRepository;
            //string passCrypt = AuthService.Encrypt(password);

            return repository.GetByLoginAndPassword(login, password);
        }

        /// <summary>
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        //public static string Encrypt(string password)
        //{
        //    string textCrypt = "";

        //    int iterations = 10000;
        //    int saltSize = 16; // 128 bit 
        //    int keySize = 32; // 256 bit

        //    var algorithm = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA256);
        //    var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
        //    var salt = Convert.ToBase64String(algorithm.Salt);

        //    textCrypt = $"{iterations}.{salt}.{key}";

        //    return textCrypt;
        //}
    }
}

