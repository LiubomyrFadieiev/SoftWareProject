using DAL.Interfaces;
using DAL.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace DAL.Realization
{
    public class BoughtGoodDal : IBoughtGoodDal
    {
        string connString;

        public BoughtGoodDal(string connString)
        {
            this.connString = connString;
        }

        public int ChangeBGoodUser(int bgood_id, int user_id)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("UPDATE BoughtGoods SET user_id = {0}, lastUpdateTime = NOW()::timestamp(0) WHERE bgood_id = {1}", user_id, bgood_id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public int CreateBGood(BoughtGoodDTO good)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("INSERT INTO boughtgoods (goodsname, goodsdesc, startprice, endprice, user_id) VALUES ('{0}','{1}',{2}, {3}, {4})", good.goodsName, good.goodsDesc, good.startPrice, good.endPrice, good.user_id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public int DeleteBGood(int id)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("DELETE FROM boughtgoods WHERE bgood_id = {0}", id);
                using (var comm = new NpgsqlCommand(commandText, conn))
                {
                    rows = comm.ExecuteNonQuery();
                }
            }
            return rows;
        }

        public List<BoughtGoodDTO> GetAllBGoods()
        {
            List<BoughtGoodDTO> bgoods = new List<BoughtGoodDTO>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT u.firstName, u.lastName, bg.bgood_id, bg.goodsname, bg.goodsdesc, bg.startPrice, bg.endPrice, bg.user_id, bg.InsertTime, bg.lastUpdateTime FROM BoughtGoods AS bg JOIN Users AS u ON bg.user_id = u.user_id ORDER BY bg.bgood_id", conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] list = new object[]
                            {
                                reader.GetString(0), reader.GetString(1)
                            };
                            bgoods.Add(new BoughtGoodDTO(
                                reader.GetFieldValue<int>(2), reader.GetString(3), reader.GetString(4),
                                reader.GetFieldValue<Double>(5),
                                reader.GetFieldValue<Double>(6),
                                reader.GetInt32(7), list,
                                reader.GetFieldValue<DateTime>(8),
                                reader.GetFieldValue<DateTime>(9)
                                ));
                        }
                    }
                }
            }
            return bgoods;
        }

        public BoughtGoodDTO GetBGoodByID(int id)
        {
            BoughtGoodDTO bgood;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandtext = String.Format("SELECT u.firstName, u.lastName, bg.bgood_id, bg.goodsname, bg.goodsdesc, bg.startPrice, bg.endPrice, bg.user_id, bg.InsertTime, bg.lastUpdateTime FROM BoughtGoods AS bg JOIN Users AS u ON bg.user_id = u.user_id ORDER BY bg.bgood_id", id);
                using (var command = new NpgsqlCommand(commandtext, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        object[] list = new object[]
                        {
                                reader.GetString(0), reader.GetString(1)
                        };
                        bgood = new BoughtGoodDTO(
                            reader.GetInt32(2), reader.GetString(3), reader.GetString(4),
                            reader.GetFieldValue<Double>(5),
                            reader.GetFieldValue<Double>(6),
                            reader.GetInt32(7), list,
                            reader.GetFieldValue<DateTime>(8),
                            reader.GetFieldValue<DateTime>(9)
                            );
                    }
                }
            }
            return bgood;
        }
        public int ChangeGoodState(BoughtGoodDTO bgood, GoodDTO good)
        {
            int rows = 0;
            using (var conn = new NpgsqlConnection(connString))
            {
               
                conn.Open();
                var tact = conn.BeginTransaction();
                try
                {
                    var comm = new NpgsqlCommand("INSERT INTO boughtgoods (goodsname, goodsdesc, startprice, endprice, user_id) VALUES (@name, @desc, @sprice, @eprice, @id)",conn);
                    comm.Parameters.AddWithValue("name", bgood.goodsName);
                    comm.Parameters.AddWithValue("desc", bgood.goodsDesc);
                    comm.Parameters.AddWithValue("sprice", bgood.startPrice);
                    comm.Parameters.AddWithValue("eprice", bgood.endPrice);
                    comm.Parameters.AddWithValue("id", bgood.user_id);
                    rows += comm.ExecuteNonQuery();

                    comm = new NpgsqlCommand("DELETE FROM goods WHERE good_id = @id", conn);
                    comm.Parameters.AddWithValue("id", good.good_id);
                    rows += comm.ExecuteNonQuery();

                    tact.Commit();
                }
                catch(Exception e)
                {
                    string en = e.Message;
                    tact.Rollback();
                }
                conn.Close();
            }
            return rows;
        }
    }
}
