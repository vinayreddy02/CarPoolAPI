using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;
using CarPoolApplication.DataBase;
using CarPoolApplication.Services.Intefaces;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
    public class StationServices:IStationServices
    {
        private readonly CarpoolDBContext Context;
        public StationServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public bool AddStation(Station place)
        {
            try
            {
                Context.StationTable.Add(AutoMapping.ModelToDbStation.Map<Station, StationTable>(place));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateStation(Station place)
        {
            try
            {
                Context.Entry(AutoMapping.ModelToDbStation.Map<Station, StationTable>(place)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<Station> GetAllStations()
        {
            try
            {
                return AutoMapping.DbtoModelStation.Map<List<StationTable>, List<Station>>(Context.StationTable.ToList());
            }
            catch
            {
                return null;
            }
        }
        public List<Station> GetStations(string placeID)
        {
            try
            {
                return AutoMapping.DbtoModelStation.Map<List<StationTable>, List<Station>>(Context.StationTable.Where(station => string.Equals(station.Id, placeID)).ToList());
            }
            catch
            {
                return null;
            }
        }
        public List<Station> GetStationsUsingOfferID(string offerID)
        {
            try
            {
                return AutoMapping.DbtoModelStation.Map<List<StationTable>, List<Station>>(Context.StationTable.Where(station => string.Equals(station.OfferId, offerID)).ToList());
            }
            catch
            {
                return null;
            }
        }
        public Station GetStation(string stationId)
        {
            try
            {
                return AutoMapping.DbtoModelStation.Map<StationTable, Station>(Context.StationTable.FirstOrDefault(station => string.Equals(station.Id, stationId)));
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteStation(string stationId)
        {
            try
            {
                Context.StationTable.Remove(Context.StationTable.FirstOrDefault(station => string.Equals(station.Id, stationId)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
