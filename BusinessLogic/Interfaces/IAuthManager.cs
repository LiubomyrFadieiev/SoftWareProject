using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        public (bool,string) LogIn(string mail, string password);
    }
}
