using BusinessLogic.Realization;
using DAL.DTO;
using DAL.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BLLTests
{
    [TestFixture]
    class AuctionManagerTests
    {
        private Mock<IUserDal> userDal;
        private Mock<IGoodDal> goodDal;
        private Mock<IBidDal> bidDal;
        private Mock<IBoughtGoodDal> bgoodDal;
        private AuctionManager manager;

        [SetUp]
        public void SetUp()
        {
            goodDal = new Mock<IGoodDal>(MockBehavior.Strict);
            userDal = new Mock<IUserDal>(MockBehavior.Strict);
            bidDal = new Mock<IBidDal>(MockBehavior.Strict);
            bgoodDal = new Mock<IBoughtGoodDal>(MockBehavior.Strict);

            manager = new AuctionManager(userDal.Object, goodDal.Object, bidDal.Object, bgoodDal.Object);
        }
        [Test]
        public void GetAllGoods()
        {
            List<GoodDTO> goods = new List<GoodDTO>() {
                    new GoodDTO("Item1", "111", 111),
                    new GoodDTO("Item2", "222", 222)
            };

            goodDal.Setup(d => d.GetAllGoods()).Returns(goods);

            List<GoodDTO> res = manager.GetAllGoods();

            Assert.IsTrue(goods.All(res.Contains) && goods.Count == res.Count);
        }
        [Test]
        public void GetSearchedGoods()
        {
            string search = "Item";
            string type = "Name";
            List<GoodDTO> allGoods = new List<GoodDTO>()
            {
                    new GoodDTO("Item1", "111", 111),
                    new GoodDTO("Item2", "222", 222),
                    new GoodDTO("Not3", "333", 333)
            };
            List<GoodDTO> outGoods = new List<GoodDTO>()
            {
                    new GoodDTO("Item1", "111", 111),
                    new GoodDTO("Item2", "222", 222),
            };

            goodDal.Setup(d => d.GetAllGoods()).Returns(allGoods);

            List<GoodDTO> res = manager.GetSearchedGoods(search, type);

            Assert.True(res.TrueForAll(g => g.goodsName.Contains(search)) && res.Count == outGoods.Count);
        }
        [Test]
        public void GetGoodById()
        {
            int id = 1;
            GoodDTO outGood = new GoodDTO(1, "test", "test", 100, System.DateTime.MinValue, System.DateTime.MaxValue);

            goodDal.Setup(d => d.GetGoodByID(id)).Returns(outGood);

            GoodDTO res = manager.GetGoodById(id);

            Assert.AreEqual(outGood, res);
        }
        [Test]
        public void GetGoodsBids()
        {
            List<BidDTO> allBids = new List<BidDTO>()
            {
                new BidDTO(1,1,100),
                new BidDTO(1,2,100),
                new BidDTO(2,1,100),
                new BidDTO(2,2,100)
            };
            GoodDTO good = new GoodDTO("Item1", "Item1", 100); good.good_id = 1;

            bidDal.Setup(d => d.GetAllBids()).Returns(allBids);

            List<BidDTO> res = manager.GetGoodsBids(good);

            Assert.False(res.Exists(b => b.good_id != good.good_id));
        }
        [Test]
        public void GetUserBids()
        {
            List<BidDTO> allBids = new List<BidDTO>()
            {
                new BidDTO(1,1,100),
                new BidDTO(1,2,100),
                new BidDTO(2,1,100),
                new BidDTO(2,2,100)
            };
            UserDTO user = new UserDTO("", "", "", ""); user.user_id = 1;

            bidDal.Setup(d => d.GetAllBids()).Returns(allBids);

            List<BidDTO> res = manager.GetUsersBids(user);

            Assert.False(res.Exists(b => b.user_id != user.user_id));
        }
        [Test]
        public void GetAuthorisedUser()
        {
            UserDTO user = new UserDTO("", "", "login", "");
            string login = "login";

            userDal.Setup(d => d.GetUserByLogin(login)).Returns(user);

            UserDTO res = manager.GetAuthorisedUser(login);

            Assert.AreEqual(user, res);
        }
        [Test]
        public void InsertBid()
        {
            double price = 100;
            int good_id = 1;
            int user_id = 1;
            BidDTO bid = new BidDTO(user_id, good_id, price);

            bidDal.Setup(d => d.CreateBid(bid)).Returns(1);
            bool res = manager.InsertBid(bid);

            Assert.True(res);
        }
        [Test]
        public void UpdateBid()
        {
            double price = 100;
            int good_id = 1;
            int user_id = 1;
            BidDTO bid = new BidDTO(user_id, good_id, price);

            bidDal.Setup(d => d.ChangeBid(user_id, good_id, price)).Returns(1);
            bool res = manager.UpdateBid(price, good_id, user_id);

            Assert.True(res);
        }
        [Test]
        public void BuyItem()
        {
            UserDTO user = new UserDTO(1, "test", "test", "test@unit.m", "1234", System.DateTime.MinValue, System.DateTime.MaxValue, System.DateTime.MaxValue);
            GoodDTO good = new GoodDTO("Item1", "1111", 111);
            BoughtGoodDTO bgood = new BoughtGoodDTO("Item1", "1111", 111, 100, 1);

            bgoodDal.Setup(d => d.ChangeGoodState(bgood, good)).Returns(1);
            bool res = manager.BuyItem(good, bgood);

            Assert.True(res);
        }
        [Test]
        public void GetUsersGoods()
        {
            UserDTO user = new UserDTO("", "", "", ""); user.user_id = 1;
            List<BoughtGoodDTO> allGoods = new List<BoughtGoodDTO>()
            {
                new BoughtGoodDTO("Item1","111",111,222,1),
                new BoughtGoodDTO("Item2", "111", 111, 222, 2),
                new BoughtGoodDTO("Item3", "111", 111, 222, 1),
                new BoughtGoodDTO("Item4", "111", 111, 222, 3),
                new BoughtGoodDTO("Item5", "111", 111, 222, 4)
            };
            List<BoughtGoodDTO> outGoods = new List<BoughtGoodDTO>()
            {
                new BoughtGoodDTO("Item1","111",111,222,1),
                new BoughtGoodDTO("Item3", "111", 111, 222, 1)
            };

            bgoodDal.Setup(d => d.GetAllBGoods()).Returns(allGoods);

            List<BoughtGoodDTO> res = manager.GetUsersGoods(user);

            Assert.False(res.Exists(g => g.user_id != user.user_id));
        }
    }
}
