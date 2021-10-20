using DAL.Realization;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace ConsoleApplication.Menus
{
    public class GoodMenu : IMenu
    {
        readonly public string[] arrayOfOptions;
        GoodDal goodDal;
        public GoodMenu(string connString)
        {
            arrayOfOptions = new string[] { "1.Show all goods;", "2.Search good by id;", "3.Create good;", "4.Change good's name;", "5.Delete good." };
            goodDal = new GoodDal(connString);
        }
        public int ChangeRow()
        {
            Console.Write("Please enter good's id:\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter good's new name:\nfirst name = ");
            string name = Console.ReadLine();
            return goodDal.ChangeGoodName(id, name);
        }

        public int CreateRow()
        {
            string name, desc; double price;
            Console.WriteLine("You are going to create new good. Please enter ALL required parameters.");
            Console.Write("Name = "); name = Console.ReadLine();
            Console.Write("Description = "); desc = Console.ReadLine();
            Console.Write("Start Price = "); price = Double.Parse(Console.ReadLine());
            GoodDTO TransportToDB = new GoodDTO(name, desc, price);
            return goodDal.CreateGood(TransportToDB);
        }

        public int DeleteRow()
        {
            int NumberofRows = 0;
            Console.WriteLine("You want to delete good.\nWARNING: The programm will delete bids with this good too!\nEnter Y/N");
            char decision = Char.Parse(Console.ReadLine());
            if (decision == 'N')
            {
                return NumberofRows;
            }
            else
            {
                Console.Write("Please enter good's id:\nid = ");
                int id = Int32.Parse(Console.ReadLine());
                NumberofRows += goodDal.DeleteGood(id);
                return NumberofRows;
            }
        }

        public void ShowAllRows()
        {
            List<GoodDTO> goods = goodDal.GetAllGoods();
            foreach (GoodDTO g in goods)
            {
                Console.WriteLine(g.goodsName);
                Console.WriteLine("ID: {0}\nDescription: {1}\nStart Price: {2}\nInsert Time: {3}\nLast Update Time: {4}\n",
                    g.good_id,
                    g.goodsDesc,
                    g.startPrice,
                    g.insertTime,
                    g.lastUpdateTime);
            }
        }

        public void ShowRowByID()
        {
            Console.Write("Please enter good's id\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            GoodDTO g = goodDal.GetGoodByID(id);
            Console.WriteLine(g.goodsName);
            Console.WriteLine("ID: {0}\nDescription: {1}\nStart Price: {2}\nInsert Time: {3}\nLast Update Time: {4}\n",
                g.good_id,
                g.goodsDesc,
                g.startPrice,
                g.insertTime,
                g.lastUpdateTime);
        }
        public string[] ReturnMenu()
        {
            return arrayOfOptions;
        }
    }
}
