using DAL.Interfaces;
using DAL.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.Realization
{
    public class BidDal : IBidDal
    {
        string connString;

        public BidDal(string connString)
        {
            this.connString = connString;
        }
        public int ChangeBid(int user_id, int good_id, double price)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("UPDATE Bids SET bid = {0} WHERE user_id = {1} AND good_id = {2}", price, user_id, good_id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public int CreateBid(BidDTO bid)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("INSERT INTO Bids (user_id,good_id,bid) VALUES ({0},{1},{2})", bid.user_id, bid.good_id, bid.bid);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public int DeleteBid(int user_id, int good_id)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("DELETE FROM Bids WHERE user_id = {0} AND good_id = {1}", user_id, good_id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }
        public List<BidDTO> GetAllBids()
        {
            List<BidDTO> bids = new List<BidDTO>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("SELECT u.firstName, u.lastName, g.goodsname, g.goodsdesc, g.startPrice, b.user_id, b.good_id, b.bid, b.insertTime, b.lastUpdateTime " +
                    "FROM bids b JOIN goods g on b.good_id = g.good_id JOIN users u ON b.user_id = u.user_id ORDER BY b.user_id, b.good_id");
                using (var comm = new NpgsqlCommand(commandText, conn))
                using (var reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] userlist = new object[]
                        {
                            reader.GetString(0),reader.GetString(1)
                        };
                        object[] goodlist = new object[]
                        {
                            reader.GetString(2),reader.GetString(3),reader.GetFieldValue<double>(4)
                        };
                        bids.Add(new BidDTO(
                            userlist, goodlist,
                            reader.GetInt32(5), reader.GetInt32(6),
                            reader.GetFieldValue<double>(7),
                            reader.GetFieldValue<DateTime>(8),
                            reader.GetFieldValue<DateTime>(9)
                            ));
                    }
                }
            }
            return bids;
        }

        public BidDTO GetBidById(int id)
        {
            BidDTO bid;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("SELECT u.firstName, u.lastName, g.goodsname, g.goodsdesc, g.startPrice, b.user_id, b.good_id, b.bid, b.insertTime, b.lastUpdateTime FROM bids AS b JOIN goods g on b.good_id = g.good_id JOIN users AS u ON b.user_id = u.user_id WHERE b.user_id = {0} ORDER BY b.user_id, b.good_id", id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                using (var reader = comm.ExecuteReader())
                {
                    reader.Read();
                    object[] userlist = new object[]
                    {
                            reader.GetString(0),reader.GetString(1)
                    };
                    object[] goodlist = new object[]
                    {
                            reader.GetString(2),reader.GetString(3),reader.GetFieldValue<double>(4)
                    };
                    bid = new BidDTO(
                        userlist, goodlist,
                        reader.GetInt32(5), reader.GetInt32(6),
                        reader.GetFieldValue<double>(7),
                        reader.GetFieldValue<DateTime>(8),
                        reader.GetFieldValue<DateTime>(9)
                        );
                }
            }
            return bid;
        }
    }
}
