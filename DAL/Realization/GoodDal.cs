using DAL.Interfaces;
using DAL.DTO;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DAL.Realization
{
    public class GoodDal : IGoodDal
    {
        string connString;
        public GoodDal(string connString)
        {
            this.connString = connString;
        }
        public int ChangeGoodName(int id, string name)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("UPDATE Goods SET goodsName = '{0}', lastUpdateTime = NOW()::timestamp(0) WHERE good_id = {1}", name, id);
                using (var command = new NpgsqlCommand(commandText, conn))
                {
                    rows = command.ExecuteNonQuery();
                }
            }
            return rows;
        }
        public int CreateGood(GoodDTO good)
        {
            int rows;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandText = String.Format("INSERT INTO Goods (goodsName, goodsDesc, startPrice) VALUES ('{0}','{1}',{2})", good.goodsName, good.goodsDesc, good.startPrice);
                using (var command = new NpgsqlCommand(commandText, conn))
                {
                    rows = command.ExecuteNonQuery();
                }
            }
            return rows;
        }
        public int DeleteGood(int id)
        {
            int rows = 0; string commandtext; NpgsqlCommand command;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                var tact = conn.BeginTransaction();
                try
                {
                    commandtext = String.Format("DELETE FROM Bids WHERE good_id = {0}", id);
                    command = new NpgsqlCommand(commandtext, conn);
                    rows += command.ExecuteNonQuery();

                    commandtext = String.Format("DELETE FROM Goods WHERE good_id = {0}", id);
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
        public List<GoodDTO> GetAllGoods()
        {
            List<GoodDTO> goods = new List<GoodDTO>();
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand("SELECT good_id, goodsName, goodsDesc, startprice, inserttime, lastupdatetime FROM Goods g ORDER BY g.good_id", conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        goods.Add(new GoodDTO(
                            reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetFieldValue<double>(3),
                            reader.GetFieldValue<DateTime>(4),
                            reader.GetFieldValue<DateTime>(5)
                            ));
                    }

                }
            }
            return goods;
        }
        public GoodDTO GetGoodByID(int id)
        {
            GoodDTO good;
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                string commandtext = String.Format("SELECT g.good_id, goodsName, goodsDesc, startprice, inserttime, lastupdatetime FROM Goods g WHERE g.good_id = {0} ORDER BY g.good_id", id);
                using (var command = new NpgsqlCommand(commandtext, conn))
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    good = new GoodDTO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetFieldValue<double>(3),
                            reader.GetFieldValue<DateTime>(4),
                            reader.GetFieldValue<DateTime>(5)
                            );
                }
            }
            return good;
        }
    }
}
