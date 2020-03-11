using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.API.Controllers
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
        [HttpGet]        
        public List<User> GetUsers()
        {
            return UserServices.GetAllUsers();
        }
        [HttpPost]
        public bool AddUser(User user)
        {
            return UserServices.AddUser(user);           
        }
        [HttpGet("{id}")]
        public User GetUser(string id)
        {
            return UserServices.GetUser(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteUser(string id)
        {
            return UserServices.DeleteUser(id);          
        }
        [HttpPut]
        public bool UpdateUser(User user)
        {
            return UserServices.UpdateUser(user);             
        }
        [HttpGet]
        [Route("IsvalidUser/{id}/{password}")]
        public bool IsValidUser(string id, string password)
        {
            return UserServices.IsValidUser(id, password);          
        }
    }
}
