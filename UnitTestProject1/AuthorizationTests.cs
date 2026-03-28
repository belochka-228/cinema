using cinema.Services;
using cinema.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cinema.AuthorizationTests
{
    [TestClass]
    public class AuthorizationTests 
    {
        [TestMethod]
        public void AuthTest()  
        {
            var page = new LoginWindow();

            var loginWindow = new LoginWindow();

            Assert.IsTrue(loginWindow.Auth("sofi@gmail.com", "123456"));
            Assert.IsFalse(loginWindow.Auth("user1", "12345"));
            Assert.IsFalse(loginWindow.Auth("", ""));
            Assert.IsFalse(loginWindow.Auth(" ", " "));
        }

        [TestMethod]
        public void AuthTestSuccess()
        {
            var db = new DatabaseService();
            var users = db.GetUsers();
            var loginWindow = new LoginWindow();

            foreach (var user in users)
            {
                bool result = loginWindow.Auth(user.Email, user.Password);
                Assert.IsTrue(result, $"Не удалось войти для {user.Email}");
            }
        }

        [TestMethod]
        public void AuthTestFail()
        {
            var loginWindow = new LoginWindow();
            var db = new DatabaseService();
            var users = db.GetUsers().ToList();

            // пустые поля
            Assert.IsFalse(loginWindow.Auth("", ""));
            Assert.IsFalse(loginWindow.Auth("test@mail.com", ""));
            Assert.IsFalse(loginWindow.Auth("", "pass"));

            // несуществующий email
            Assert.IsFalse(loginWindow.Auth("nonexistent@mail.com", "anypass"));

            // неверный пароль для всех пользователей
            foreach (var user in users)
            {
                Assert.IsFalse(loginWindow.Auth(user.Email, "wrongpassword"));
            }

            // пробелы 
            Assert.IsFalse(loginWindow.Auth("   ", "   "));
        }
    }
}
