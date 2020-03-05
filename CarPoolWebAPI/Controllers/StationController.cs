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
        [Route("api/[controller]")]
        public List<Station> GetAll()
        {
            return stationServices.GetAll();
        }
        // POST: api/Station
        [HttpPost]
        [Route("api/[controller]")]
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
        // GET: api/Station/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Station GetStation(string id)
        {
            return stationServices.GetStation(id);
        }
        // DELETE: api/Station/5
        [HttpDelete]
        [Route("api/[controller]/{id}")]
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
        [HttpPut]
        [Route("api/[controller]/{id}")]
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
        // GET: api/Station/GetStationsUsingLocationId
        [HttpGet]
        [Route("api/[controller]/GetStationsUsingLocationId/{locationId}")]
        public List<Station> GetStationsUsingLocationId(string locationId)
        {
            return stationServices.GetStations(locationId);
        }
        // GET: api/Station/GetStationsusingOfferId
        [HttpGet]
        [Route("api/[controller]/GetStationsUsingOfferId/{offerId}")]
        public List<Station> GetStationsUsingOfferId(string offerId)
        {
            return stationServices.GetStationsUsingOfferID(offerId);
        }
    }
}