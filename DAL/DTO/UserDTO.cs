using System;

namespace DAL.DTO
{
    public enum UserInfo
    {
        firstName = 0,
        lastName = 1,
        numberOfProperties = 2,
    }
    public class UserDTO
    {
        public int user_id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }
        public string password { get; set; }
        public DateTime insertTime { get; set; }
        public DateTime lastSignedInTime { get; set; }
        public DateTime lastUpdateTime { get; set; }

        public UserDTO(int id, string fName, string lName, string mail, string pass, DateTime insTime, DateTime lastsiTime, DateTime luTime)
        {
            user_id = id; firstName = fName; lastName = lName;
            eMail = mail; password = pass;
            insertTime = insTime; lastSignedInTime = lastsiTime; lastUpdateTime = luTime;

        }
        public UserDTO(string fName, string lName, string mail, string pass)
        {
            firstName = fName; lastName = lName;
            eMail = mail; password = pass;
        }
    }
}
