using DAL.Interfaces;
using DAL.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace DAL.Realization
{
    public class UserDal : IUserDal
    {
        string connString;
        public UserDal(string connString)
        {
            this.connString = connString;
        }
        public int ChangeUserName(int user_id, string fName, string lName)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("UPDATE Users SET firstName = '{0}', lastName = '{1}', lastUpdateTime = NOW()::timestamp(0) WHERE user_id = {2}", fName, lName, user_id);
                using (var command = new NpgsqlCommand(commandText, conn))
                {
                    rows = command.ExecuteNonQuery();
                }
            }
            return rows;
        }
        public int CreateUser(UserDTO user)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("INSERT INTO Users (firstName,lastName,\"e-mail\",\"password\") VALUES ('{0}','{1}','{2}','{3}')", user.firstName, user.lastName, user.eMail, user.password);
                using (var command = new NpgsqlCommand(commandText, conn))
                {
                    rows = command.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public int DeleteUser(int id)
        {
            int rows = 0; string commandtext; NpgsqlCommand command;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var tact = conn.BeginTransaction();
                try
                {
                    commandtext = String.Format("DELETE FROM Bids WHERE user_id = {0}", id);
                    command = new NpgsqlCommand(commandtext, conn);
                    rows += command.ExecuteNonQuery();
                    commandtext = String.Format("DELETE FROM boughtgoods WHERE user_id = {0}", id);
                    command = new NpgsqlCommand(commandtext, conn);
                    rows += command.ExecuteNonQuery();

                    commandtext = String.Format("DELETE FROM Users WHERE user_id = {0}", id);
                    command = new NpgsqlCommand(commandtext, conn);
                    rows += command.ExecuteNonQuery();

                    tact.Commit();
                }
                catch
                {
                    tact.Rollback();
                }
                conn.Close();
            }
            return rows;
        }

        public List<UserDTO> GetAllUsers()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT u.user_id, u.firstName, u.lastName, u.\"e-mail\", u.\"password\", u.insertTime, u.lastSignedInTime, u.lastUpdateTime FROM users u ORDER BY u.user_id", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new UserDTO(
                                reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetString(4),
                                reader.GetFieldValue<DateTime>(5),
                                reader.GetFieldValue<DateTime>(6),
                                reader.GetFieldValue<DateTime>(7)
                            ));
                    }

                }
            }
            return users;
        }

        public UserDTO GetUserByID(int id)
        {
            UserDTO user;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("SELECT u.user_id, u.firstName, u.lastName, u.\"e-mail\", u.\"password\", u.insertTime, u.lastSignedInTime, u.lastUpdateTime FROM users u WHERE u.user_id = {0} ORDER BY u.user_id", id);
                using (var command = new NpgsqlCommand(commandText, conn))
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    user = new UserDTO(
                                reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                reader.GetString(3), reader.GetString(4),
                                reader.GetFieldValue<DateTime>(5),
                                reader.GetFieldValue<DateTime>(6),
                                reader.GetFieldValue<DateTime>(7)
                        );
                }
                return user;
            }
        }
        public UserDTO GetUserByLogin(string login)
        {
            UserDTO user;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("SELECT u.user_id, u.firstName, u.lastName, u.\"e-mail\", u.\"password\", u.insertTime, u.lastSignedInTime, u.lastUpdateTime FROM users u WHERE u.\"e-mail\" = @login ORDER BY u.user_id");
                using (var command = new NpgsqlCommand(commandText, conn))
                {
                    command.Parameters.AddWithValue("login", login);
                    using (var reader = command.ExecuteReader())
                    {

                        reader.Read();
                        user = new UserDTO(
                                    reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader[4].ToString(),
                                    reader.GetFieldValue<DateTime>(5),
                                    reader.GetFieldValue<DateTime>(6),
                                    reader.GetFieldValue<DateTime>(7)
                            );
                    }
                    return user;
                }
            }
        }
        public (bool,bool) LogIn (string login, string password)
        {
            byte[] pass; string salt;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); 
                using (var command = new NpgsqlCommand("SELECT password, salt FROM users WHERE \"e-mail\" = @login", conn))
                {
                    command.Parameters.AddWithValue("login", login);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        pass = (byte[])reader[0];
                        salt = reader.GetGuid(1).ToString();
                    }
                    else
                    {
                        return (false, false);
                    }
                }
            }
            return (true, ComparePasswords(password, salt, pass));
        }

        public int SetSalt(UserDTO user)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                using(var comm = new NpgsqlCommand("UPDATE users SET salt = uuid_generate_v4(), lastUpdateTime = NOW()::timestamp(0) WHERE \"password\" = @pass", conn))
                {
                    comm.Parameters.AddWithValue("pass", "");
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public string GetSalt(UserDTO user)
        {
            string salt;
            using(var conn = new NpgsqlConnection(connString))
            {
                using(var comm = new NpgsqlCommand("SELECT salt FROM users WHERE \"password\" = @pass"))
                {
                    comm.Parameters.AddWithValue("pass", "");
                    var reader = comm.ExecuteReader();
                    reader.Read();
                    salt = reader[0].ToString();
               }
            }
            return salt;
        }

        public int UpdateUserPassword(byte[] pass)
        {
            int rows;
            using(var conn = new NpgsqlConnection(connString))
            {
                using(var comm = new NpgsqlCommand("UPDATE users SET \"password\" = @pass, lastUpdateTime = NOW()::timestamp(0) WHERE \"password\" = '' ", conn))
                {
                    comm.Parameters.AddWithValue("pass", pass);
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        private bool ComparePasswords(string password, string salt, byte[] pass)
        {
            var sha = SHA512.Create();
            byte[] ourPass = sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
            for(int i = 0; i<pass.Length; i++)
            {
                if (ourPass[i] != pass[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
