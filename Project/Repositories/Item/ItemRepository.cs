using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Project.Models;

namespace Project.Repositories
{
    public  class ItemRepository
    {
        public  SqlConnection connection { get; set; }
        public  SqlCommand command { get; set; }
        public  SqlDataAdapter adapter { get; set; }
        public  DataSet ds { get; set; }
        public  SqlDataReader dr { get; set; }

        public ItemRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
            //if (dr == null) dr = new SqlDataReader();

        }

        public DataTable GetData(int itemId=0)
        {
            if (itemId==0)
                command = new SqlCommand("select * from Item as i inner join unit as u on u.UnitId=RefUnitId left join TracingFactor as t on t.TracingFactorId=i.TracingFactorId", connection);
            else
            {

                command.Connection = connection;
                command.CommandText = "select * from Item as i inner join unit as u on u.UnitId=RefUnitId left join TracingFactor as t on t.TracingFactorId=i.TracingFactorId where CAST(ItemId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", itemId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Item");
            connection.Close();
            return ds.Tables["Item"];
        }
        public  bool DeleteItem(int itemId)
        {
            command.Connection = connection;
            command.CommandText = "delete from Item where ItemId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", itemId);
            connection.Open();
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
            finally
            {
                connection.Close();
            }

        }

        public  bool AddItem(ItemModel model)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (model.HasTracingFactor)
            {
                command.CommandText = "insert into Item(Title,Description,RefUnitId,HasTracingFactor,TracingFactorId,pic) Values(@Title,@Description,@RefUnitId,@HasTracingFactor,@TracingFactorId,@pic)";
                command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
            }
            command.CommandText = "insert into Item(Title,Description,RefUnitId,HasTracingFactor,pic) Values(@Title,@Description,@RefUnitId,@HasTracingFactor,@pic)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Title", model.Title);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
            command.Parameters.AddWithValue("@HasTracingFactor", model.HasTracingFactor);
            command.Parameters.AddWithValue("@pic", model.Pic);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public  bool EditItem(ItemModel model)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (model.HasTracingFactor)
            {
                command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,HasTracingFactor=@HasTracingFactor,TracingFactorId=@TracingFactorId ,pic=@pic where ItemId=@Id";
                command.Parameters.AddWithValue("@TracingFactorId", model.TracingFactorId);
            }
            else
            {
                command.CommandText = "update Item set Title=@Title, Description=@Description, RefUnitId=@RefUnitId ,HasTracingFactor=@HasTracingFactor ,pic=@pic where ItemId=@Id";
            }
            command.Parameters.AddWithValue("@Id", model.ItemId);
            command.Parameters.AddWithValue("@Title", model.Title);
            command.Parameters.AddWithValue("@Description", model.Description);
            command.Parameters.AddWithValue("@RefUnitId", model.RefUnitId);
            command.Parameters.AddWithValue("@HasTracingFactor", model.HasTracingFactor);
            command.Parameters.AddWithValue("@pic", model.Pic);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public  DataTable FindItem(int itemId)
        {

            command.Connection = connection;
            command.CommandText = "select TOP 1 * from Item where ItemId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", itemId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Item");
            connection.Close();
            return ds.Tables["Item"];
        }
    }
}
