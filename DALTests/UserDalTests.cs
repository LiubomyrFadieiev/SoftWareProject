using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DAL.Realization;
using DAL.DTO;

namespace DALTests
{
    [TestFixture]
    public class UserDalTests
    {
        string connString = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        [Test]
        public void GetAllTest()
        {
            UserDal userDal = new UserDal(connString);
            var users = userDal.GetAllUsers();

            Assert.IsTrue(users.Any(u => u.firstName == "Test"));
        }
        [Test]
        public void GetByIDTest()
        {

        }
        [Test]
        public void CreateTest()
        {

        }
        [Test]
        public void ChangeNameTest()
        {

        }
        [Test]
        public void DeleteTest()
        {

        }
    }
}
