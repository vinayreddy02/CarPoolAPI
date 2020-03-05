using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Mappers;
using CarPoolApplication.Models;
using CarPoolDataBase;
using CarPoolApplication.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
   public class UserServices: IUserServices
    {    

        static readonly MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserTable, User>());
        readonly IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserTable>());
        readonly IMapper modelToDb = modelToDbConfig.CreateMapper();
        private readonly CarpoolDBContext Context;
        public UserServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public List<User> GetAll()
        {
            try
            {
                List<UserTable> userTables = Context.UserTable.ToList();
                List<User> users = dbtoModel.Map<List<UserTable>, List<User>>(userTables);
                return users;
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
                UserTable userTable = modelToDb.Map<User, UserTable>(user);
                Context.UserTable.Add(userTable);
                Context.SaveChanges();
                return true;
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
                UserTable userTable = Context.UserTable.FirstOrDefault(user => string.Equals(user.Id, userId));
                User user = dbtoModel.Map<UserTable, User>(userTable);
                return user;
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
                UserTable userTable = Context.UserTable.FirstOrDefault(user => string.Equals(user.Id, userId));
                Context.UserTable.Remove(userTable);
                Context.SaveChanges();
                return true;
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
                UserTable userTable = modelToDb.Map<User, UserTable>(user);
                Context.Entry(userTable).State = EntityState.Modified;
                Context.SaveChanges();
                return true;
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
        public bool UserExists(string userID)
        {
            return Context.UserTable.Any(user => string.Equals(user.Id, userID));
        }
    }
}
