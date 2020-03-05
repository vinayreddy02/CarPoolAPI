using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Services;
using CarPoolApplication.Models;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationServices locationServices;
        public LocationController(ILocationServices services)
        {
            locationServices = services;
        }
        // GET: api/location
        [HttpGet]
        public List<Location> GetLocations()
        {
            return locationServices.GetAll();
        }
        // POST: api/location
        [HttpPost]
        public bool PostLocation(Location location)
        {
            if (locationServices.AddLocation(location))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // GET: api/location/5
        [HttpGet("{id}")]
        public Location GetLocation(string id)
        {
            return locationServices.GetLocation(id);
        }
        // DELETE: api/location/5
        [HttpDelete("{id}")]
        public bool DeleteLocation(string id)
        {
            if (locationServices.DeleteLocation(id))
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