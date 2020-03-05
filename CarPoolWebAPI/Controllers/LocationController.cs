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
   
    [ApiController]
    public class LocationController : ControllerBase
    {
        readonly ILocationServices locationServices;
        public LocationController(ILocationServices services)
        {
            locationServices = services;
        }
        // GET: api/Location
        [HttpGet]
        [Route("api/[controller]/GetLocations")]
        public List<Location> GetLocations()
        {
            return locationServices.GetAll();
        }
        // POST: api/Location
        [HttpPost]
        [Route("api/[controller]")]
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
        // GET: api/Location/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Location GetLocation(string id)
        {
            return locationServices.GetLocation(id);
        }
        // DELETE: api/Location/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
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
        // PUT: api/Location/5
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public string PutLocation(string id, Location location)
        {
            if (id != location.Id)
            {
                return "Location does not exists";
            }
            else
            {
                if (locationServices.UpdateLocation(location))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        // GET: api/Location/place
        [HttpGet]
        [Route("api/[controller]/{place}")]
        public List<Location> GetLocationsWithName(string place)
        {
            return locationServices.GetLocations(place);
        }
    }
}