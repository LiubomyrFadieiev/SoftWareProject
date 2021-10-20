using DAL.Interfaces;
using DAL.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.Realization
{
    public class UserDal : IUserDal
    {
        string connString;
        public UserDal()
        {
            connString = ConfigurationManager.ConnectionStrings["Auction"].ConnectionString;
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
                catch (Exception ex)
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
    }
}
