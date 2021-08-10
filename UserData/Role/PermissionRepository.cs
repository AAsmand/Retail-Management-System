using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Utility.Interfaces;

namespace Project.Repositories.Role
{
    public class PermissionRepository:BaseRepository,IPermissionRepository
    {
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
