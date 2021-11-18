using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    interface IUserDal
    {
        public List<UserDTO> GetAllUsers();
        public UserDTO GetUserByID(int id);
        public int CreateUser(UserDTO user);
        public int ChangeUserName(int user_id, string fName, string lName);
        public int DeleteUser(int id);
        public (bool, bool) LogIn(string login, string password);
    }
}
