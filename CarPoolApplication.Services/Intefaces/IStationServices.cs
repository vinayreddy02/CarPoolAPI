using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IStationServices
    {
        public bool AddStation(Station place);    
        public List<Station> GetAll();
        public List<Station> GetStations(string placeId);
        public bool DeleteStation(string stationId);
        public Station GetStation(string stationId);
        public List<Station> GetStationsUsingOfferID(string offerId);
        public bool UpdateStation(Station place);
    }
}
