using DAL.DTO;
using DAL.Realization;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Menus
{
    public class UserMenu : IMenu
    {
        public string[] arrayOfOptions { get; set; }
        UserDal userDal;
        BoughtGoodDal bgoodDal;
        BidDal bidDal;
        public UserMenu()
        {
            arrayOfOptions = new string[] { "1.Show all users;", "2.Search user by id;", "3.Create user;", "4.Change user's name;", "5.Delete user." };
            userDal = new UserDal();
            bgoodDal = new BoughtGoodDal();
            bidDal = new BidDal();
        }
        public int ChangeRow()
        {
            Console.Write("Please enter user's id:\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            Console.Write("Please enter user's new first name:\nfirst name = ");
            string fName = Console.ReadLine();
            Console.Write("Please enter user's last name:\nlast name = ");
            string lName = Console.ReadLine();
            return userDal.ChangeUserName(id, fName, lName);

        }

        public int CreateRow()
        {
            string fName, lName, mail, pass;
            Console.WriteLine("You are going to create new user. Please enter ALL required parameters.");
            Console.Write("First name = "); fName = Console.ReadLine();
            Console.Write("Last name = "); lName = Console.ReadLine();
            Console.Write("E-mail = "); mail = Console.ReadLine();
            Console.Write("Password = "); pass = Console.ReadLine();
            UserDTO TransportToDB = new UserDTO(fName, lName, mail, pass);
            return userDal.CreateUser(TransportToDB);
        }

        public int DeleteRow()
        {
            int NumberofRows = 0;
            Console.WriteLine("You want to delete user.\nWARNING: The programm will delete this user's bought goods and bids too!\nEnter Y/N");
            char decision = Char.Parse(Console.ReadLine());
            if (decision == 'N')
            {
                return NumberofRows;
            }
            else
            {
                Console.Write("Please enter user's id:\nid = ");
                int id = Int32.Parse(Console.ReadLine());
                NumberofRows += userDal.DeleteUser(id);
                return NumberofRows;
            }
        }

        public void ShowAllRows()
        {
            List<UserDTO> users = userDal.GetAllUsers();
            foreach (UserDTO u in users)
            {
                Console.WriteLine("{0} {1}", u.firstName, u.lastName);
                Console.WriteLine("ID: {0}\nE-mail: {1}\nPassword: {2}\nLast Signed In: {3}\nInsert Time: {4}\nLast Update Time: {5}\n",
                    u.user_id,
                    u.eMail,
                    u.password,
                    u.lastSignedInTime,
                    u.insertTime,
                    u.lastUpdateTime);
            }
        }

        public void ShowRowByID()
        {
            Console.Write("Please enter user's id:\nid = ");
            int id = Int32.Parse(Console.ReadLine());
            UserDTO u = userDal.GetUserByID(id);
            Console.WriteLine("{0} {1}", u.firstName, u.lastName);
            Console.WriteLine("ID: {0}\nE-mail: {1}\nPassword: {2}\nLast Signed In: {3}\nInsert Time: {4}\nLast Update Time: {5}\n",
                u.user_id,
                u.eMail,
                u.password,
                u.lastSignedInTime,
                u.insertTime,
                u.lastUpdateTime);
        }

        public string[] ReturnMenu()
        {
            return arrayOfOptions;
        }
    }
}

