using NUnit.Framework;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Realization;

namespace DALTests
{
    [TestFixture]
    class BoughtGoodDalTests
    {
        string connString;
        [SetUp]
        public void SetUp()
        {
            connString = "Server=localhost;Username=postgres;Database=SoftwareTest;Port=5432;Password=admin;SSLMode=Prefer";
        }
        [Test]
        public void GetAllTest()
        {
            string expectedName = "Test";
            BoughtGoodDal dal = new BoughtGoodDal(connString);

            var bgoods = dal.GetAllBGoods();

            Assert.IsTrue(bgoods.Any(b => b.goodsName == expectedName));
        }
        [Test]
        public void GetByIDTest()
        {
            int id = 1;
            string expectedName = "Test";
            BoughtGoodDal dal = new BoughtGoodDal(connString);

            var bgood = dal.GetBGoodByID(id);

            Assert.IsTrue(bgood.goodsName == expectedName);
        }
        [Test]
        public void CreateTest()
        {
            BoughtGoodDTO newItem = new BoughtGoodDTO("New", "New item", 100, 400, 1);
            BoughtGoodDal dal = new BoughtGoodDal(connString);

            dal.CreateBGood(newItem);
            var bgoods = dal.GetAllBGoods();

            Assert.IsTrue(bgoods.Any(b => b.goodsName == newItem.goodsName));
        }
        [Test]
        public void ChangeUserTest()
        {
            int newUser = 2;
            string goodName = "New";
            BoughtGoodDal dal = new BoughtGoodDal(connString);
            //created good's id changes with every iteration, so we should found his id by name
            var ourGood = dal.GetAllBGoods().Where(b => b.goodsName == goodName).ToList();
            int id = ourGood[0].bgood_id;

            dal.ChangeBGoodUser(id, newUser);
            var bgoods = dal.GetAllBGoods();

            Assert.IsTrue(bgoods.Any(b => b.goodsName == goodName && b.user_id == newUser));
        }
        [Test]
        public void DeleteTest()
        {
            string deleteName = "New";
            BoughtGoodDal dal = new BoughtGoodDal(connString);
            //created good's id changes with every iteration, so we should found his id by name
            var ourGood = dal.GetAllBGoods().Where(b => b.goodsName == deleteName).ToList();
            int id = ourGood[0].bgood_id;

            dal.DeleteBGood(id);
            var bgoods = dal.GetAllBGoods();

            Assert.IsFalse(bgoods.Any(b => b.goodsName == deleteName));
        }
    }
}
