using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using CarPoolApplication.Models;
using CarPoolApplication.DataBase;
using CarPoolApplication.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
   public class UserServices: IUserServices
    {    
        private readonly CarpoolDBContext Context;
        public UserServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public List<User> GetAllUsers()
        {
            try
            {                
                return AutoMapping<UserTable, User>.Mapper.Map< List<UserTable>, List<User>>(Context.UserTable.ToList());               
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
                Context.UserTable.Add(AutoMapping<UserTable, User>.Mapper.Map<User, UserTable>(user));
                return Context.SaveChanges() > 0;
               
            }
            catch
            {
                return false;
            }
        }
        public User GetUser(string userId)
        {
            try
            {
                return AutoMapping<UserTable, User>.Mapper.Map<UserTable, User>(Context.UserTable.FirstOrDefault(user => string.Equals(user.Id, userId)));               
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteUser(string userId)
        {
            try
            {
                Context.Remove(Context.UserTable.FirstOrDefault(user => string.Equals(user.Id, userId)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                Context.Entry(AutoMapping<UserTable, User>.Mapper.Map<User, UserTable>(user)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidUser(string Id, string password)
        {
            return Context.UserTable.Any(user => string.Equals(user.Id, Id) && string.Equals(user.Password, password));
        }
      
    }
}
