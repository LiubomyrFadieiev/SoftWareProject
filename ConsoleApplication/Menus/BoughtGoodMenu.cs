using DAL.Realization;
using DAL.DTO;
using System;
using System.Collections.Generic;

namespace ConsoleApplication.Menus
{
    class BoughtGoodMenu : IMenu
    {
        readonly public string[] arrayOfOptions;
        BoughtGoodDal bgoodDal;
        public BoughtGoodMenu()
        {
            arrayOfOptions = new string[] { "1.Show all bought goods;", "2.Search bought good by id;", "3.Create bought good;", "4.Change bought good's user;", "5.Delete bought good." };
            bgoodDal = new BoughtGoodDal();
        }
        public int ChangeRow()
        {
            Console.Write("Please enter bought good's id:\nid = ");
            int bgood_id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter new buyer (user) id:\nid = ");
            int user_id = Int32.Parse(Console.ReadLine());
            return bgoodDal.ChangeBGoodUser(bgood_id, user_id);
        }

        public int CreateRow()
        {
            string name, desc; double start, end; int id;
            Console.WriteLine("You are going to create new bought good. Please enter ALL required parameters.");
            Console.Write("Good name = "); name = Console.ReadLine();
            Console.Write("Good description = "); desc = Console.ReadLine();
            Console.Write("Good start price = "); start = Double.Parse(Console.ReadLine());
            Console.Write("Good end price = "); end = Double.Parse(Console.ReadLine());
            Console.Write("User (Buyer) id = "); id = Int32.Parse(Console.ReadLine());
            BoughtGoodDTO TransportToDB = new BoughtGoodDTO(name, desc, start, end, id);
            return bgoodDal.CreateBGood(TransportToDB);

        }

        public int DeleteRow()
        {
            Console.WriteLine("You want to delete bought good.\n");
            Console.Write("Please enter good's id:\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            int numberOfRows = bgoodDal.DeleteBGood(id);
            return numberOfRows;
        }

        public void ShowAllRows()
        {
            string fullName;
            List<BoughtGoodDTO> bgoods = bgoodDal.GetAllBGoods();
            foreach (BoughtGoodDTO bg in bgoods)
            {
                fullName = String.Format((string)bg.userInformation[(int)UserInfo.firstName] + " " + (string)bg.userInformation[(int)UserInfo.lastName]);
                Console.WriteLine(bg.goodsName);
                Console.WriteLine("ID: {0}\nDescription: {1}\nStart Price: {2}\nEnd price: {3}\nBought by: {4}\nInsert Time: {5}\nLast Insert Time: {6}\n",
                    bg.bgood_id,
                    bg.goodsDesc,
                    bg.startPrice,
                    bg.endPrice,
                    fullName,
                    bg.insertTime,
                    bg.lastUpdateTime);
            }
        }

        public void ShowRowByID()
        {
            Console.Write("Please enter bought good's id\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            string fullName;
            BoughtGoodDTO bg = bgoodDal.GetBGoodByID(id);
            fullName = String.Format((string)bg.userInformation[(int)UserInfo.firstName] + (string)bg.userInformation[(int)UserInfo.lastName]);
            Console.WriteLine(bg.goodsName);
            Console.WriteLine("ID: {0}\nDescription: {1}\nStart Price: {2}\nEnd price: {3}\nBought by: {4}\nInsert Time: {5}\nLast Insert Time: {6}\n",
                bg.bgood_id,
                bg.goodsDesc,
                bg.startPrice,
                bg.endPrice,
                fullName,
                bg.insertTime,
                bg.lastUpdateTime);
        }
        public string[] ReturnMenu()
        {
            return arrayOfOptions;
        }
    }
}
