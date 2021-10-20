using ConsoleApplication.Menus;
using System;
using System.Configuration;

namespace ConsoleApplication
{
    class Program
    {
        static void MenuShow(IMenu menu)
        {
            int i, rows;
            string[] options = menu.ReturnMenu();
            while (true)
            {
                Console.Clear();
                foreach (string s in options)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("0.Exit;\nEnter a number.");
                i = Int32.Parse(Console.ReadLine());
                Console.Clear();
                switch (i)
                {
                    case 1:
                        menu.ShowAllRows();
                        break;
                    case 2:
                        menu.ShowRowByID();
                        break;
                    case 3:
                        rows = menu.CreateRow();
                        Console.WriteLine("{0} rows has created.", rows);
                        break;
                    case 4:
                        rows = menu.ChangeRow();
                        Console.WriteLine("{0} rows has changed.", rows);
                        break;
                    case 5:
                        rows = menu.DeleteRow();
                        Console.WriteLine("{0} rows has deleted.", rows);
                        break;
                    case 0:
                        return;
                }
                Console.WriteLine("Press enter to continue.");
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            IMenu[] arrayMenu = new IMenu[] { new UserMenu(), new GoodMenu(), new BoughtGoodMenu(), new BidMenu() };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the entity to work with:\n1.Users;\n2.Goods;\n3.Bought Goods;\n4.Bids.\n0.Stop program. \nEnter the number.");
                int i = Int32.Parse(Console.ReadLine());
                if (i == 0) { return; }
                else { MenuShow(arrayMenu[i - 1]); }
            }
        }
    }
}

