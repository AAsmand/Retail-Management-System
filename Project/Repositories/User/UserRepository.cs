using Project.Models.User;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Project.Repositories.User
{
    public class UserRepository:BaseRepository
    {
        public SqlConnection connection { get; set; }
        public SqlCommand command { get; set; }
        public SqlDataAdapter adapter { get; set; }
        public DataSet ds { get; set; }

        public UserRepository()
        {
            connection = new SqlConnection("data source=.\\sepidar;Initial Catalog=ProjectDB2;User Id=damavand;Password=damavand");
            command = new SqlCommand();
            adapter = new SqlDataAdapter();
            ds = new DataSet();
        }

        public DataTable LoginUser(string username, string password)
        {
            command.Connection = connection;
            command.CommandText = "select * from Users where Username=@User and Password=@Pass";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@User", username);
            command.Parameters.AddWithValue("@Pass", password);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Users");
            connection.Close();
            return ds.Tables["Users"];
        }
        public DataTable GetUser(int userId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "select UserId,Name,LastName,Username,Password,Avatar,IsActive,IsDeleted,Birthday , Cast(TimeStamp as int) as TimeStamp from Users where IsDeleted=0 and UserId=@UserId";
            command.Parameters.AddWithValue("@UserId", userId);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Users");
            connection.Close();
            return ds.Tables["Users"];
        }
        public DataTable GetUsers()
        {
            command.Connection = connection;
            command.CommandText = "select * from Users where IsDeleted=0";
            command.Parameters.Clear();
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Users");
            connection.Close();
            return ds.Tables["Users"];
        }
        public int AddUser(UserViewModel model)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "insert into Users(Name,LastName,Username,Password,Birthday,Avatar,IsActive,IsDeleted) Values(@Name,@LastName,@Username,@Password,@Birthday,@Avatar,@IsActive,@IsDeleted)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Name", model.Name);
            command.Parameters.AddWithValue("@LastName", model.LastName);
            command.Parameters.AddWithValue("@Username", model.Username);
            command.Parameters.AddWithValue("@Password", model.Password);
            command.Parameters.AddWithValue("@Birthday", model.Birthday);
            command.Parameters.AddWithValue("@Avatar", model.Avatar);
            command.Parameters.AddWithValue("@IsActive", model.IsActive);
            command.Parameters.AddWithValue("@IsDeleted", false);
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                string query2 = "Select @@Identity as newId from Users";
                command.CommandText = query2;
                command.CommandType = CommandType.Text;
                var newId = command.ExecuteScalar();
                connection.Close();
                return int.Parse(newId.ToString());
            }
            connection.Close();
            return 0;
        }

        public bool DeleteUser(int userId)
        {
            command.Connection = connection;
            command.Parameters.Clear();
            command.CommandText = "update Users set IsDeleted=1 where UserId=@UserId";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId",userId);
           
            connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }

        public bool UpdateUser(UserViewModel user)
        {
           
            command.Connection = connection;
            command.CommandText = "update Users set Name=@Name,LastName=@LastName,Username=@Username,Password=@Password,Birthday=@Birthday,Avatar=@Avatar,IsActive=@IsActive where UserId=@UserId and CAST(TimeStamp as int)=@TimeStamp";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.Parameters.AddWithValue("@Name", user.Name);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Birthday", user.Birthday);
            command.Parameters.AddWithValue("@Avatar", user.Avatar);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            command.Parameters.AddWithValue("@TimeStamp", user.TimeStamp);
            if (connection.State==ConnectionState.Closed)connection.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
        public override bool IsNotConcurrent(IConcurrency model)
        {
            command.Connection = connection;
            command.CommandText = "select * from Users where UserId=@UserId and CAST(TimeStamp as int)=@TimeStamp";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@UserId", model.Id);
            command.Parameters.AddWithValue("@TimeStamp", model.TimeStamp);
            connection.Open();
            adapter.SelectCommand = command;
            ds.Clear();
            adapter.Fill(ds, "Users");
            connection.Close();
            if (ds.Tables["Users"].Rows.Count > 0) return true;
            return false;
        }
    }
}
