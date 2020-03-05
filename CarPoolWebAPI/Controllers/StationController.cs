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
        readonly IStationServices stationServices;
        public StationController(IStationServices services)
        {
            stationServices = services;
        }
        // GET: api/Stations
        [HttpGet]
        public List<Station> GetAll()
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
        // PUT: api/Station/5
        [HttpPut("{id}")]
        public string PutStation(string id, Station station)
        {
            if (id != station.Id)
            {
                return "Station does not exists";
            }
            else
            {
                if (stationServices.UpdateStation(station))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        [HttpGet("{locationid}")]
        public List<Station> GetStationsUsingLocationId(string locationId)
        {
            return stationServices.GetStations(locationId);
        }
        [HttpGet("{offerid}")]
        public List<Station> GetStationsusingOfferId(string offerid)
        {
            return stationServices.GetStationsUsingOfferID(offerid);
        }
    }
}