using System;
using DAL.DTO;
using DAL.Realization;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Menus
{
    public class BidMenu : IMenu
    {
        readonly public string[] arrayOfOptions;
        BidDal bidDal;
        public BidMenu(string connString)
        {
            arrayOfOptions = new string[] { "1.Show all bids;", "2.Search bid by id;", "3.Create bid;", "4.Change bid;", "5.Delete bid." };
            bidDal = new BidDal(connString);

        }
        public int ChangeRow()
        {
            Console.Write("Please enter user's id:\nid = ");
            int user_id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter good's id:\nid = ");
            int good_id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter new bid:\nbid = ");
            double bid = Double.Parse(Console.ReadLine());
            return bidDal.ChangeBid(user_id, good_id, bid);
        }

        public int CreateRow()
        {
            int user_id, good_id; double bid;
            Console.WriteLine("You are going to create new bid. Please enter ALL required parameters.");
            Console.Write("User (buyer) id = "); user_id = Int32.Parse(Console.ReadLine());
            Console.Write("Good id = "); good_id = Int32.Parse(Console.ReadLine());
            Console.Write("Current bid = "); bid = Double.Parse(Console.ReadLine());
            BidDTO TransportToDB = new BidDTO(user_id, good_id, bid);
            return bidDal.CreateBid(TransportToDB);
        }

        public int DeleteRow()
        {
            Console.WriteLine("You want to delete bid.\n");
            Console.Write("Please enter user id:\nid = ");
            int user_id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter good's id:\nid = ");
            int good_id = Int32.Parse(Console.ReadLine());
            int numberOfRows = bidDal.DeleteBid(user_id, good_id);
            return numberOfRows;
        }

        public void ShowAllRows()
        {
            string fullName;
            List<BidDTO> bids = bidDal.GetAllBids();
            foreach (BidDTO b in bids)
            {
                fullName = String.Format((string)b.userInformation[(int)UserInfo.firstName] + " " + (string)b.userInformation[(int)UserInfo.lastName]);
                Console.WriteLine("{0} bit {1}", fullName, b.goodInformation[(int)GoodInfo.name]);
                Console.WriteLine("ID of user: {0}\nID of good: {1}\nSize of bid: {2}\nDescription: {3}\nInsert Time: {4}\nLast Update Time: {5}\n",
                    b.user_id,
                    b.good_id,
                    b.bid,
                    b.goodInformation[(int)GoodInfo.description],
                    b.insertTime,
                    b.lastUpdateTime);
            }
        }

        public void ShowRowByID()
        {
            Console.Write("Please enter user's id\nid = ");
            int user_id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter good's id\nid = ");
            int good_id = Int32.Parse(Console.ReadLine());
            string fullName;
            BidDTO b = bidDal.GetBidById(user_id,good_id);
            fullName = String.Format((string)b.userInformation[(int)UserInfo.firstName] + " " + (string)b.userInformation[(int)UserInfo.lastName]);
            Console.WriteLine("{0} bit {1}", fullName, b.goodInformation[(int)GoodInfo.name]);
            Console.WriteLine("ID of user: {0}\nID of good: {1}\nSize of bid: {2}\nDescription: {3}\nInsert Time: {4}\nLast Update Time: {5}\n",
                b.user_id,
                b.good_id,
                b.bid,
                b.goodInformation[(int)GoodInfo.description],
                b.insertTime,
                b.lastUpdateTime);
        }
        public string[] ReturnMenu()
        {
            return arrayOfOptions;
        }
    }
}
