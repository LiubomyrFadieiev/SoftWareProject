using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using DAL.DTO;
using DAL.Interfaces;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Realization
{

    public class AuthManager : IAuthManager
    {
        IUserDal uDal;
        public AuthManager(IUserDal userDal)
        {
            uDal = userDal;
        }
        public (bool,bool) LogIn(string mail, string password)
        {
            return uDal.LogIn(mail, password);
        }
        public bool Registration(UserDTO newUser, string password)
        {
            int rows = 0;
            rows += uDal.CreateUser(newUser);
            rows += uDal.SetSalt(newUser);
            string salt = uDal.GetSalt(newUser);
            byte[] pass = ComputeHash(password, salt);
            rows += uDal.UpdateUserPassword(pass);
            return rows == 3;
        }
        private byte[] ComputeHash(string password, string salt)
        {
            var alg = SHA512.Create();
            return alg.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
        }
    }
}
