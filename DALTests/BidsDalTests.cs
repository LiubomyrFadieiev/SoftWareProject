using NUnit.Framework;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using DAL.DTO;
using DAL.Realization;

namespace DALTests
{
    [TestFixture]
    class BidDalTests
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
            int[] expectedID = { 1, 1 };
            BidDal dal = new BidDal(connString);

            var bids = dal.GetAllBids();

            Assert.IsTrue(bids.Any(b => b.user_id == expectedID[0] &&
            b.good_id == expectedID[1]));
        }
        [Test]
        public void GetByIDTest()
        {
            int[] expectedID = { 1, 1 };
            int expectedBid = 250;
            BidDal dal = new BidDal(connString);

            var bid = dal.GetBidById(expectedID[0], expectedID[1]);

            Assert.IsTrue(bid.user_id == expectedID[0] &&
                bid.good_id == expectedID[1] &&
                bid.bid == expectedBid);
        }
        [Test]
        public void CreateTest()
        {
            BidDTO newItem = new BidDTO(2, 1, 100);
            BidDal dal = new BidDal(connString);

            dal.CreateBid(newItem);
            var bids = dal.GetAllBids();

            Assert.IsTrue(bids.Any(b => b.user_id == newItem.user_id &&
                b.good_id == newItem.good_id &&
                b.bid == newItem.bid));
        }
        [Test]
        public void ChangeBidTest()
        {
            int[] expectedID = { 2, 1 };
            int newbid = 500;
            BidDal dal = new BidDal(connString);

            dal.ChangeBid(expectedID[0], expectedID[1], newbid);
            var bid = dal.GetBidById(expectedID[0], expectedID[1]);

            Assert.IsTrue(bid.bid == newbid);
        }
        [Test]
        public void DeleteTest()
        {
            int[] expectedID = { 2, 1 };
            BidDal dal = new BidDal(connString);

            dal.DeleteBid(expectedID[0], expectedID[1]);
            var bids = dal.GetAllBids();

            Assert.IsFalse(bids.Any(b => b.user_id == expectedID[0] &&
            b.good_id == expectedID[1]));
        }
    }
}
