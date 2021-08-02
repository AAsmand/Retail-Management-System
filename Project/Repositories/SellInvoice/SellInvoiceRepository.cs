using Project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class SellInvoiceRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public SellInvoiceRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
        }

        public  DataTable GetData()
        {

            command.Connection = connection;
            command.CommandText = "select * from SellInvoice as s inner join SellType as st on s.SellTypeId=st.SellTypeId";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoice");
            connection.Close();
            return ds.Tables["SellInvoice"];
        }
        public  bool DeleteItem(int sellInvoiceId)
        {
            command.Connection = connection;
            command.CommandText = "delete from SellInvoice where SellInvoiceId=@Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", sellInvoiceId);
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

        public  bool AddItem(SellInvoiceModel model)
        {
            command.Connection = connection;
            command.CommandText = "insert into SellInvoice(SellInvoiceId,SellTypeId,CreatedDate,Customer) Values(@SellInvoiceId,@SellTypeId,@CreatedDate,@Customer)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@SellInvoiceId", model.SellInvoiceId);
            command.Parameters.AddWithValue("@SellTypeId", model.SellTypeId);
            command.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
            command.Parameters.AddWithValue("@Customer", model.Customer);
           
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public  int GetLastId()
        {
            command.Connection = connection;
            command.CommandText = "select Top 1 SellInvoiceId from SellInvoice order by SellInvoiceId desc";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "SellInvoice");
            connection.Close();
            if (ds.Tables["SellInvoice"].Rows.Count == 0)
                return 0;
            else return int.Parse(ds.Tables["SellInvoice"].Rows[0]["SellInvoiceId"].ToString());
        }
    }
}
