using Project.Models;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class StockItemRepository : BaseRepository, IStockItemRepository
    {
        public DataTable GetStockItem(int itemId, int stockRoomId, string tracingFactor)
        {
            command.Connection = connection;
            command.CommandText = "select * from StockItem as si where si.SRId=@SRId and si.ItemId=@ItemId and TracingFactor=@TracingFactor";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ItemId", itemId.ToString());
            command.Parameters.AddWithValue("@SRId", stockRoomId.ToString());
            command.Parameters.AddWithValue("@TracingFactor", tracingFactor);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }
        public StockItemViewModel GetStockItem(int stockItemId)
        {
            command.Connection = connection;
            command.CommandText = "select * from StockItem where StockItemId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", stockItemId);

            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockItem");
            connection.Close();
            if (ds.Tables["StockItem"].Rows.Count == 1)
            {
                StockItemViewModel model = new StockItemViewModel()
                {
                    StockItemId = (int)ds.Tables["StockItem"].Rows[0]["StockItemId"],
                    ItemId = (int)ds.Tables["StockItem"].Rows[0]["ItemId"],
                    SRId = (int)ds.Tables["StockItem"].Rows[0]["SRId"],
                    StockValue = (int)ds.Tables["StockItem"].Rows[0]["StockValue"],
                    CreatedDate = DateTime.Parse(ds.Tables["StockItem"].Rows[0]["CreatedDate"].ToString()),
                    TracingFactor = ds.Tables["StockItem"].Rows[0]["TracingFactor"].ToString()
                };
                return model;
            }
            return null;
        }

        public bool UpdateStockItem(int stockItemId, int ChangeValue)
        {
            command.Connection = connection;
            command.CommandText = "update StockItem set StockValue=StockValue+@ChangeValue where StockItemId=@StockItemId and (StockValue+@ChangeValue)>=0";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@StockItemId", stockItemId);
            command.Parameters.AddWithValue("@ChangeValue", ChangeValue);

            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public bool UpdateStockItem(int stockRoomId, int itemId, string tracingFactor, int ChangeValue)
        {
            command.Connection = connection;
            command.CommandText = "update StockItem set StockValue=StockValue+@ChangeValue where SRId=@StockRoomId and ItemId=@ItemId and TracingFactor=@TracingFactor and (StockValue+@ChangeValue)>0";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@StockRoomId", stockRoomId);
            command.Parameters.AddWithValue("@ItemId", itemId);
            command.Parameters.AddWithValue("@TracingFactor", tracingFactor);
            command.Parameters.AddWithValue("@ChangeValue", ChangeValue);

            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public DataTable GetStockItemsByFilter(int itemId = 0, int stockRoomId = 0, string tracingFactor = "")
        {
            command.Connection = connection;

            command.CommandText = "select * from StockItem as si inner join StockRoom as sr on sr.SRId=si.SRId where si.ItemId=@ItemId and CAST(si.SRId as varchar) like '%'+@SRId+'%' and TracingFactor like '%'+@TracingFactor+'%'";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ItemId",itemId>0? itemId.ToString():"");
            command.Parameters.AddWithValue("@SRId",stockRoomId>0? stockRoomId.ToString():"");
            command.Parameters.AddWithValue("@TracingFactor", tracingFactor);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockItem");
            connection.Close();
            return ds.Tables["StockItem"];
        }
        public int AddStockItem(StockItemViewModel model)
        {
            command.Connection = connection;
            command.CommandText = "insert into StockItem(ItemId,SRId,StockValue,TracingFactor,CreatedDate) Values(@ItemId,@SRId,@StockValue,@TracingFactor,@CreatedDate)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ItemId", model.ItemId);
            command.Parameters.AddWithValue("@SRId", model.SRId);
            command.Parameters.AddWithValue("@StockValue", 0);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@TracingFactor", model.TracingFactor);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                string query2 = "Select @@Identity as newId from StockItem";
                command.CommandText = query2;
                command.CommandType = CommandType.Text;
                var newId = command.ExecuteScalar();
                connection.Close();
                return int.Parse(newId.ToString());
            }
            connection.Close();
            return 0;
        }
    }
}
