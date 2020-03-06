using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Services;
using CarPoolApplication.Models;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        readonly ILocationServices locationServices;
        public LocationController(ILocationServices services)
        {
            locationServices = services;
        }
        [HttpGet]
        public List<Location> GetLocations()
        {
            return locationServices.GetAll();
        }
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
        [HttpGet("{id}")]
        public Location GetLocation(string id)
        {
            return locationServices.GetLocation(id);
        }
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
        [HttpPut("{id}")]
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
        [Route("GetLocationsWithPlace/{place}")]
        public List<Location> GetLocationsWithPlace(string place)
        {
            return locationServices.GetLocations(place);
        }
    }
}