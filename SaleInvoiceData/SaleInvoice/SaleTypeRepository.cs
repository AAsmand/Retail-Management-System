using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class SaleTypeRepository : BaseRepository, ISaleTypeRepository
    {
        public DataTable GetSaleTypesByFilter(int sellTypeId = 0)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "select * from SellType where CAST(SellTypeId as varchar) like '%'+@Id+'%'";
            command.Parameters.AddWithValue("@Id",sellTypeId>0? sellTypeId.ToString():"");
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellType");
            connection.Close();
            return ds.Tables["SellType"];
        }
        public DataTable GetSaleType(int sellTypeId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "select * from SellType where SellTypeId=@Id";
            command.Parameters.AddWithValue("@Id",sellTypeId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellType");
            connection.Close();
            return ds.Tables["SellType"];
        }
    }
}
