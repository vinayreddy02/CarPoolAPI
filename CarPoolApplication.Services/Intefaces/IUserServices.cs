using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IUserServices
    {
        public List<User> GetAllUsers();
        public bool AddUser(User user);
        public User GetUser(string userId);
        public bool DeleteUser(string userId);
        public bool IsValidUser(string ID, string password);
        public bool UpdateUser(User user);
    }
}
