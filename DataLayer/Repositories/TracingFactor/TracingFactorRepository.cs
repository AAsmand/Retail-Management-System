using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories
{
    public class TracingFactorRepository
    {
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;
        public DataSet ds;

        public TracingFactorRepository()
        {
            if (connection == null) connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            if (command == null) command = new SqlCommand();
            if (adapter == null) adapter = new SqlDataAdapter();
            if (ds == null) ds = new DataSet();
        }

        public DataTable GetData()
        {
            if (command == null)
                command = new SqlCommand("select * from TracingFactor ", connection);
            else
            {
                command.Connection = connection;
                command.CommandText = "select * from TracingFactor";
                command.Parameters.Clear();
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "TracingFactor");
            connection.Close();
            return ds.Tables["TracingFactor"];
        }
    }
}
