using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;
using System.Linq;
using CarPoolApplication.Interfaces;
using CarPoolAPI;

namespace CarPoolApplication.Services
{
    public class UserServices: IUserService
    {
        // private List<User> Users = new List<User>();
        CarpoolDBContext context;
        public List<User> GetAll()
        {
            try
            {
                return context.Users;
            }
            catch
            {
                return null;
            }
        }
        public bool AddUser(User user)
        {
            try
            {
                context.Users.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public User GetUser( string userId)
        {
            try
            {
                return context.Users.FirstOrDefault(user => string.Equals(user.Id, userId));
            }
            catch
            {
                return null;
            }
        }
        public bool IsValidUser(string Id,string password)
        {
           
                return context.Users.Any(user => string.Equals(user.Id, Id) && string.Equals(user.Password, password));
           
        }
    }
}
