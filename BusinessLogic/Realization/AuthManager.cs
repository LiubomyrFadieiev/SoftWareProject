using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.Realization;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Realization
{

    public class AuthManager : IAuthManager
    {
        UserDal uDal;
        public AuthManager(string connString)
        {
            uDal = new UserDal(connString);
        }
        public (bool,string) LogIn(string mail, string password)
        {
            (bool, bool) result = uDal.LogIn(mail, password);
            if (result.Item1)
            {
                if (result.Item2)
                {
                    return (true,"Autorization was successful.");
                }
                else
                {
                    return (false,"Password is incorrect.");
                }
            }
            return (false,"Invalid credentials.");
        }
    }
}
