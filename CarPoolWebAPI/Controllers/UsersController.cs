using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IUserServices UserServices;
        public UsersController(IUserServices services)
        {
            UserServices = services;
        }
        // GET: api/Users
        [HttpGet]
        public List<User> GetUsers()
        {
            return UserServices.GetAll();
        }
        // POST: api/Users
        [HttpPost]
        public bool PostUser(User user)
        {
            if (UserServices.AddUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Users/5
        [HttpGet("{id}")]
        public User GetUser(string id)
        {
            return UserServices.GetUser(id);
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public bool DeleteUser(string id)
        {
            if (UserServices.DeleteUser(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public string PutUser(string id, User user)
        {
            if (id != user.Id)
            {
                return "user does not exists";
            }
            else
            {
                if (UserServices.UpdateUser(user))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        // POST: api/Users
        [HttpGet]
        [Route("api/[controller]/IsValidUser")]
        public bool IsValidUser(string id, string password)
        {
            if(UserServices.IsValidUser(id, password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
