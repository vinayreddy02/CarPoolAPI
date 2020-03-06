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
    public class StationController : ControllerBase
    {
        readonly IStationServices stationServices;
        public StationController(IStationServices services)
        {
            stationServices = services;
        }
        // GET: api/Station
        [HttpGet]       
        public List<Station> GetAll()
        {
            return stationServices.GetAll();
        }
        // POST: api/Station
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
        [HttpGet("{id}")]
        public Station GetStation(string id)
        {
            return stationServices.GetStation(id);
        }
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
        [HttpGet]
        [Route("GetStationsUsingLocationId/{locationId}")]
        public List<Station> GetStationsUsingLocationId(string locationId)
        {
            return stationServices.GetStations(locationId);
        }
        [HttpGet]
        [Route("GetStationsUsingOfferId/{offerId}")]
        public List<Station> GetStationsUsingOfferId(string offerId)
        {
            return stationServices.GetStationsUsingOfferID(offerId);
        }
    }
}