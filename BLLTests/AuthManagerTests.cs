using BusinessLogic.Realization;
using DAL.DTO;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;

namespace BLLTests
{
    [TestFixture]
    public class AuthManagerTests
    {
        private Mock<IUserDal> userDal;
        private AuthManager authManager;

        [SetUp]
        public void SetUp()
        {
            userDal = new Mock<IUserDal>(MockBehavior.Strict);
            authManager = new AuthManager(userDal.Object);
        }
        [Test]
        public void LogIn()
        {
            string inLogin = "test@unit.n";
            string inPassword = "12345678";
            (bool, bool) outRes = (true, true);

            (bool, bool) logInResult = (true, true);
            userDal.Setup(d => d.LogIn(inLogin, inPassword)).Returns(logInResult);

            (bool, bool) res = authManager.LogIn(inLogin, inPassword);

            Assert.IsNotNull(res);
            Assert.AreEqual(outRes, res);
        }
        [Test]
        public void LogInIncorrectPassword()
        {
            string inLogin = "test@unit.n";
            string inPassword = "12345678";
            (bool, bool) outRes = (true, false);

            (bool, bool) logInResult = (true, false);
            userDal.Setup(d => d.LogIn(inLogin, inPassword)).Returns(logInResult);

            (bool, bool) res = authManager.LogIn(inLogin, inPassword);

            Assert.IsNotNull(res);
            Assert.AreEqual(outRes, res);
        }
        [Test]
        public void Registration()
        {
            string fname = "Test";
            string lname = "Test";
            string eMail = "test@unit.n";
            string password = "12345678";
            UserDTO newUser = new UserDTO(fname, lname, eMail, "");

            string guid = new Guid().ToString();
            byte[] testpass = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(password + guid));
            userDal.Setup(d => d.CreateUser(newUser)).Returns(1);
            userDal.Setup(d => d.SetSalt(newUser)).Returns(1);
            userDal.Setup(d => d.GetSalt(newUser)).Returns(guid);
            userDal.Setup(d => d.UpdateUserPassword(testpass)).Returns(1);

            bool outRes = authManager.Registration(newUser, password);

            Assert.IsTrue(outRes);
        }
    }
}
