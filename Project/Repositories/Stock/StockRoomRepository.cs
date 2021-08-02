using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace Project.Repositories
{
    public class StockRoomRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;
        public SqlDataReader dr;

        public StockRoomRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();

        }
        public DataTable GetData(int srId=0)
        {
            if (srId==0)
                command = new SqlCommand("select * from StockRoom ", connection);
            else
            {
                command.Connection = connection;
                command.CommandText = "select * from StockRoom where CAST(SRId as varchar) like '%'+@Id+'%'";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Id", srId.ToString());
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "StockRoom");
            connection.Close();
            return ds.Tables["StockRoom"];
        }
    }
}
