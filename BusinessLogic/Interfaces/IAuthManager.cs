using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        public (bool,bool) LogIn(string mail, string password);
        public bool Registration(UserDTO user, string password);
    }
}
