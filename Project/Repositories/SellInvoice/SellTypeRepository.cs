using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;

namespace Project.Repositories
{
    public  class SellTypeRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public SellTypeRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
            //if (dr == null) dr = new SqlDataReader();

        }

        public DataTable GetData(int sellTypeId=0)
        {
            if (sellTypeId == 0)
                command = new SqlCommand("select * from SellType", connection);
            else
            {

                command.Connection = connection;
                command.CommandText = "select * from SellType where CAST(SellTypeId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", sellTypeId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellType");
            connection.Close();
            return ds.Tables["SellType"];
        }
        //public  bool DeleteItem(int itemId)
        //{
        //    command.Connection = connection;
        //    command.CommandText = "delete from Item where ItemId=@Id";
        //    command.Parameters.Clear();
        //    command.Parameters.AddWithValue("@Id", itemId);
        //    connection.Open();
        //    try
        //    {
        //        if (command.ExecuteNonQuery() > 0)
        //        {
        //            connection.Close();
        //            return true;
        //        }
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //}

        //public  bool AddItem(ItemModel model)
        //{
        //    command.Connection = connection;
        //    command.CommandText = "insert into Item(Title,Description,RefUnitId,TracingFactorId,pic) Values(@Title,@Description,@RefUnitId,@TracingFactorId,@pic)";
        //    command.Parameters.Clear();
        //    command.Parameters.AddWithValue("@Title", model.Title);
        //    command.Parameters.AddWithValue("@Description", model.Description);
        //    command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
        //    command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
        //    command.Parameters.AddWithValue("@pic", model.Pic);
        //    connection.Open();
        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        connection.Close();
        //        return true;
        //    }
        //    connection.Close();
        //    return false;
        //}
        //public  bool EditItem(ItemModel model)
        //{
        //    command.Connection = connection;
        //    command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,TracingFactorId=@TracingFactorId ,pic=@pic where ItemId=@Id";
        //    command.Parameters.Clear();
        //    command.Parameters.AddWithValue("@Id", model.ItemId);
        //    command.Parameters.AddWithValue("@Title", model.Title);
        //    command.Parameters.AddWithValue("@Description", model.Description);
        //    command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
        //    command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
        //    command.Parameters.AddWithValue("@pic", model.Pic);
        //    connection.Open();
        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        connection.Close();
        //        return true;
        //    }
        //    connection.Close();
        //    return false;
        //}

        //public  DataTable FindItem(int itemId)
        //{

        //    command.Connection = connection;
        //    command.CommandText = "select TOP 1 * from Item where ItemId=@Id";
        //    command.Parameters.Clear();
        //    command.Parameters.AddWithValue("@Id", itemId);
        //    connection.Open();
        //    adapter.SelectCommand = command;
        //    ds.Clear();
        //    adapter.Fill(ds, "Item");
        //    connection.Close();
        //    return ds.Tables["Item"];
        //}
    }
}
