using Business.Models;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Tests.Repositories;

namespace Tests
{
    [TestClass]
    public class UserTest
    {

        private UserService _userService;

        public UserTest()
        {
            List<User> users = new List<User>()
            {
                new User() { Id = 1, Name = "Alan Martins", Email = "alan@teste.com.br", Password = "1234" },
                new User() { Id = 2, Name = "Alan", Email = "alan1@teste.com.br", Password = "12345" }
            };

            _userService = new UserService(new UserRepository(users));
        }

        [TestMethod]
        public void User_Get_Id_2()
        {
            User result = _userService.Get(2);
            Assert.IsNotNull(result);
            Assert.AreEqual<int>(2, result.Id);
        }

        [TestMethod]
        public void User_GetAll_Count_2()
        {
            IEnumerable<User> result = _userService.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void User_Add_Id_99()
        {
            User user = new User() { Id = 99, Name = "user 99", Email = "user99@teste.com.br", Password = "aaaaaa" };
            _userService.Save(user);

            User result = _userService.Get(user.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual<User>(user, result);
        }

        [TestMethod]
        public void User_Update_Alter_Name()
        {
            User user = _userService.GetAll().FirstOrDefault();

            string oldName = user.Name;
            user.Name = "Alter name";

            _userService.Update(user);

            User result = _userService.Get(user.Id);

            Assert.IsNotNull(result);
            Assert.AreNotEqual<string>(oldName, result.Name);
        }
    }
}
