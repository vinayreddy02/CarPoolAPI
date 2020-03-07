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
    public class LocationsController : ControllerBase
    {
        readonly ILocationServices locationServices;
        public LocationsController(ILocationServices services)
        {
            locationServices = services;
        }
        [HttpGet]
        public List<Location> GetLocations()
        {
            return locationServices.GetAll();
        }
        [HttpPost]
        public bool AddLocation(Location location)
        {
            return locationServices.AddLocation(location);         
        }
        [HttpGet("{id}")]
        public Location GetLocation(string id)
        {
            return locationServices.GetLocation(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteLocation(string id)
        {
            return locationServices.DeleteLocation(id);       
        }
        [HttpPut("{id}")]
        public bool UpdateLocation(string id, Location location)
        {
          return locationServices.UpdateLocation(location);
        }
        [HttpGet]
        [Route("GetLocationsWithPlace/{place}")]
        public List<Location> GetLocationsWithPlace(string place)
        {
            return locationServices.GetLocations(place);
        }
    }
}