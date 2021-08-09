using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories
{
    public class TracingFactorRepository:BaseRepository,ITracingFactorRepository
    {
        public TracingFactorRepository()
        {
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
