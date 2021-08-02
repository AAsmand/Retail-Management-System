using Project.Models.Role;
using Project.Repositories.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public class UserViewModel : IConcurrency
    {
       
        public  int UserId { get; set; }
        public  string Name { get; set; }
        public  string LastName { get; set; }
        public  string Username { get; set; }
        public  string Password { get; set; }
        public  DateTime Birthday { get; set; }
        public  bool IsActive { get; set; }
        public  string Avatar { get; set; }
        public  bool IsDeleted { get; set; }
        public  int TimeStamp { get; set; }
        public  List<RoleViewModel> Roles { get; set; }
        public int Id { get => UserId; set => UserId = value; }

        //public bool IsValid()
        //{
        //    return userRepository.IsValid(this.UserId, this.TimeStamp);
        //}
    }
}
