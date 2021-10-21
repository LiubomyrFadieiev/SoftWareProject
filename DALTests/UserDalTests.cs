using NUnit.Framework;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Realization;

namespace DALTests
{
    [TestFixture]
    public class UserDalTests
    {
        string connString;
        [SetUp]
        public void Setup()
        {
            connString = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        }

        [Test]
        public void GetAllTest()
        {
            string expectedName = "Test";
            UserDal dal = new UserDal(connString);
            var users = dal.GetAllUsers();

            Assert.IsTrue(users.Any(u => u.firstName == expectedName));
        }
        [Test]
        public void GetByIDTest()
        {
            int id = 1;
            string expectedName = "Test";
            UserDal dal = new UserDal(connString);
            var user = dal.GetUserByID(id);

            Assert.IsTrue(user.firstName == expectedName);
        }
        [Test]
        public void CreateTest()
        {
            UserDTO newUser = new UserDTO("New", "User", "real@gmail.com", "1234");
            UserDal dal = new UserDal(connString);

            dal.CreateUser(newUser);
            var users = dal.GetAllUsers();

            Assert.IsTrue(users.Any(u => u.firstName == newUser.firstName));

        }
        [Test]
        public void ChangeNameTest()
        {
            string oldFirstName = "New";
            string newFirstName = "NewNew";
            string newLastName = "NewUser";
            UserDal dal = new UserDal(connString);
            //created user's id changes with every iteration, so we should found his id by name
            var ouruser = dal.GetAllUsers().Where(u => u.firstName == oldFirstName).ToList();
            int id = ouruser[0].user_id;

            dal.ChangeUserName(id, newFirstName, newLastName);
            var users = dal.GetAllUsers();

            Assert.IsTrue(
                users.Any(u => u.firstName == newFirstName) &&
                users.Any(u => u.lastName == newLastName));
        }
        [Test]
        public void DeleteTest()
        {
            string deleteName = "NewNew";
            UserDal dal = new UserDal(connString);
            //created user's id changes with every iteration, so we should found his id by name
            var ouruser = dal.GetAllUsers().Where(u => u.firstName == deleteName).ToList();
            int id = ouruser[0].user_id;

            dal.DeleteUser(id);
            var users = dal.GetAllUsers();

            Assert.IsFalse(users.Any(u => u.firstName == deleteName));
        }
    }
}