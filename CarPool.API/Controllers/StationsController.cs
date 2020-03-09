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
    public class StationsController : ControllerBase
    {
        readonly IStationServices stationServices;
        public StationsController(IStationServices services)
        {
            stationServices = services;
        }
        [HttpGet]       
        public List<Station> GetAll()
        {
            return stationServices.GetAll();
        }
        [HttpPost]
        public bool AddStation(Station station)
        {
            return stationServices.AddStation(station);         
        }
        [HttpGet("{id}")]
        public Station GetStation(string id)
        {
            return stationServices.GetStation(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteStation(string id)
        {
            return stationServices.DeleteStation(id);          
        }
         [HttpPut]
        public bool UpdateStation(string id, Station station)
        { 
            return stationServices.UpdateStation(station);                       
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