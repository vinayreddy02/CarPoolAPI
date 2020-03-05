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
    public class StationController : ControllerBase
    {
        IStationServices stationServices;
        public StationController(IStationServices services)
        {
            stationServices = services;
        }
        // GET: api/Stations
        [HttpGet]
        public List<Station> GetStations()
        {
            return stationServices.GetAll();
        }
        // POST: api/Stations
        [HttpPost]
        public bool PostStation(Station station)
        {
            if (stationServices.AddStation(station))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // GET: api/Stations/5
        [HttpGet("{id}")]
        public Station GetStation(string id)
        {
            return stationServices.GetStation(id);
        }
        // DELETE: api/Stations/5
        [HttpDelete("{id}")]
        public bool DeleteStation(string id)
        {
            if (stationServices.DeleteStation(id))
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