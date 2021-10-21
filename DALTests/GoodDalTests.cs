using NUnit.Framework;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Realization;

namespace DALTests
{
    [TestFixture]
    class GoodDalTests
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
            GoodDal dal = new GoodDal(connString);

            var goods = dal.GetAllGoods();

            Assert.IsTrue(goods.Any(g => g.goodsName == expectedName));
        }
        [Test]
        public void GetByIDTest()
        {
            int id = 1;
            string expectedName = "Test";
            GoodDal dal = new GoodDal(connString);

            var good = dal.GetGoodByID(id);

            Assert.IsTrue(good.goodsName == expectedName);
        }
        [Test]
        public void CreateTest()
        {
            GoodDTO newGood = new GoodDTO("New", "Good", 200);
            GoodDal dal = new GoodDal(connString);

            dal.CreateGood(newGood);
            var goods = dal.GetAllGoods();

            Assert.IsTrue(goods.Any(g => g.goodsName == newGood.goodsName));
        }
        [Test]
        public void ChangeNameTest()
        {
            string oldName = "New";
            string newName = "NewGood";
            GoodDal dal = new GoodDal(connString);
            //created good's id changes with every iteration, so we should found his id by name
            var ourgood = dal.GetAllGoods().Where(g => g.goodsName == oldName).ToList();
            int id = ourgood[0].good_id;
            
            dal.ChangeGoodName(id, newName);
            var goods = dal.GetAllGoods();

            Assert.IsTrue(goods.Any(g => g.goodsName == newName));
        }
        [Test]
        public void DeleteTest()
        {
            string deleteName = "NewGood";
            GoodDal dal = new GoodDal(connString);
            //created good's id changes with every iteration, so we should found his id by name
            var ourgood = dal.GetAllGoods().Where(g => g.goodsName == deleteName).ToList();
            int id = ourgood[0].good_id;

            dal.DeleteGood(id);
            var goods = dal.GetAllGoods();

            Assert.IsFalse(goods.Any(g => g.goodsName == deleteName));

        }
    }
}
