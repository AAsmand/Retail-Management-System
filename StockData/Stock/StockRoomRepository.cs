using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class StockRoomRepository : BaseRepository, IStockRoomRepository
    {
        public DataTable GetItemStockRoomByFilter(int SRId = 0, int itemId = 0)
        {
            command.Connection = connection;

            command.CommandText = "select Distinct * from StockRoom as s inner join StockItem as si on si.SRId=s.SRId where CAST(s.SRId as varchar) like '%'+@Id+'%' and CAST(ItemId as varchar) like '%'+@ItemId+'%'";
            command.Parameters.AddWithValue("@ItemId", itemId > 0 ? itemId.ToString() : "");
            command.Parameters.AddWithValue("@Id", SRId > 0 ? SRId.ToString() : "");
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }

        public DataTable GetStockRoomByFilter(int stockRoomId = 0)
        {
            command.Connection = connection;

            command.CommandText = "select * from StockRoom where CAST(SRId as varchar) like '%'+@Id+'%'";
            command.Parameters.AddWithValue("@Id", stockRoomId > 0 ? stockRoomId.ToString() : "");
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }
    }
}
