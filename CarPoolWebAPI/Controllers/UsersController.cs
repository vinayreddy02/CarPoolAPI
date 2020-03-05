﻿using System;
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
        IUserServices UserServices;
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


    }
}