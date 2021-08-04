using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories.Role
{
    public class PermissionRepository
    {
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataAdapter adapter { get; set; }
        public DataSet ds { get; set; }

        public PermissionRepository()
        {
            connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            ds = new DataSet();
        }

        public DataTable GetRolesPermissions(int roleId)
        {
            command.Connection = connection;
            command.CommandText = "select * from RolePermissions as rp inner join Permissions as p on p.PermissionId=rp.PermissionId where rp.RoleId=@RoleId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@RoleId", roleId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "RolePermissions");
            connection.Close();
            return ds.Tables["RolePermissions"];
        }
    }
}
