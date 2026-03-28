using cinema.Services;
using cinema.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Cinema.RegistrationTests
{
    [TestClass]
    public class RegistrationTests
    {
        private DatabaseService dbService = new DatabaseService();

        [TestMethod]
        public void RegisterTestSuccess()
        {
            string uniqueEmail = $"test_{Guid.NewGuid()}@example.com";
            var registerWindow = new RegisterWindow();

            bool result = registerWindow.Register(uniqueEmail, "pass123", "Тестовый Пользователь", DateTime.Now.AddYears(-20), out string error);

            Assert.IsTrue(result, "Регистрация должна быть успешной");
            Assert.IsNull(error, "Сообщение об ошибке должно отсутствовать");

            var addedUser = dbService.GetUsers().FirstOrDefault(u => u.Email == uniqueEmail);
            Assert.IsNotNull(addedUser, "Пользователь не найден в БД");
            Assert.AreEqual("Тестовый Пользователь", addedUser.FullName);
            Assert.AreEqual("pass123", addedUser.Password);

            dbService.DeleteUser(addedUser.Id);

        }

        [TestMethod]
        public void RegisterTestFail()
        {
            var registerWindow = new RegisterWindow();
            var db = new DatabaseService();
            var existingUser = db.GetUsers().FirstOrDefault();

            Assert.IsFalse(registerWindow.Register("", "pass", "Name", null, out string error1));
            Assert.AreEqual("Заполните все обязательные поля", error1);

            Assert.IsFalse(registerWindow.Register("email@test.com", "", "Name", null, out string error2));
            Assert.AreEqual("Заполните все обязательные поля", error2);

            Assert.IsFalse(registerWindow.Register("email@test.com", "pass", "", null, out string error3));
            Assert.AreEqual("Заполните все обязательные поля", error3);

            Assert.IsFalse(registerWindow.Register("", "", "", null, out string error4));
            Assert.AreEqual("Заполните все обязательные поля", error4);

            if (existingUser != null)
            {
                Assert.IsFalse(registerWindow.Register(existingUser.Email, "newpass", "New Name", null, out string error5));
                Assert.AreEqual("Пользователь с таким email уже существует", error5);
            }
        }
    }
}