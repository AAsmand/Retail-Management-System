using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class BuyInvoiceRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public BuyInvoiceRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
            //if (dr == null) dr = new SqlDataReader();

        }

        public  DataTable GetData()
        {

            command.Connection = connection;
            command.CommandText = "select * from BuyInvoice";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "BuyInvoice");
            connection.Close();
            return ds.Tables["BuyInvoice"];
        }
        public  bool DeleteItem(int buyInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from BuyInvoice where BuyInvoiceId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", buyInvoiceId);
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

        public  bool AddItem(BuyInvoiceModel model)
        {
            command.Connection = connection;
            command.CommandText = "insert into BuyInvoice(BuyInvoiceId,SRId,CreatedDate,Supplier) Values(@BuyInvoiceId,@SRId,@CreatedDate,@Supplier)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@BuyInvoiceId", model.BuyInvoiceId);
            command.Parameters.AddWithValue("@SRId", model.SRId);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@Supplier", model.Supplier);
           
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                //string query2 = "Select @@Identity as newId from BuyInvoice";
                //command.CommandText = query2;
                //command.CommandType = CommandType.Text;
                //var newId = command.ExecuteScalar();
                connection.Close();
                //return int.Parse(newId.ToString());
                return true;
            }
            connection.Close();
            return false;
        }
        public  int GetLastId()
        {
            command.Connection = connection;
            command.CommandText = "select Top 1 BuyInvoiceId from BuyInvoice order by BuyInvoiceId desc";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "BuyInvoice");
            connection.Close();
            if (ds.Tables["BuyInvoice"].Rows.Count == 0)
                return 0;
            else return int.Parse(ds.Tables["BuyInvoice"].Rows[0]["BuyInvoiceId"].ToString());
        }
        //public static bool EditItem(ItemModel model)
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
    }
}
