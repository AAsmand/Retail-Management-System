using Project.Models.User;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories.Role
{
    public class RoleRepository : BaseRepository, IChooseRepository
    {
        public RoleRepository()
        {
        }

        public DataTable GetUserRoles(int userId)
        {
            command.Connection = connection;
            command.CommandText = "select * from UserRoles as us inner join Roles as r on r.RoleId=us.RoleId where us.UserId=@UserId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "UserRoles");
            connection.Close();
            return ds.Tables["UserRoles"];
        }
        public DataTable GetRoles(string sameRoleId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            if (sameRoleId != "0")
            {
                command.CommandText = "select * from Roles where CAST(RoleId as varchar) like '%'+@Id+'%'";
                command.Parameters.AddWithValue("@Id", sameRoleId);
            }
            else
            {
                command.CommandText = "select * from Roles";
            }
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Roles");
            connection.Close();
            return ds.Tables["Roles"];
        }
        public bool AddUserRole(int userId, int roleId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "insert into UserRoles(UserId,RoleId) Values(@UserId,@RoleId)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@RoleId", roleId);

            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public bool DeleteUserRoles(int userId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "delete from UserRoles where UserId=@UserId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", userId);

            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public DataTable GetDataToChoose(params object[] parameter)
        {
            return GetRoles(parameter[0].ToString());
        }
        public DataTable GetRole(int roleId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "select * from Roles where RoleId=@Id";
            command.Parameters.AddWithValue("@Id", roleId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Roles");
            connection.Close();
            return ds.Tables["Roles"];
        }
    }
}
