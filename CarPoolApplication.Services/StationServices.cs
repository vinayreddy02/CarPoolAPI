using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;
using CarPoolDataBase;
using CarPoolApplication.Services.Intefaces;
using AutoMapper;
using System.Linq;

namespace CarPoolApplication.Services
{
    public class StationServices:IStationServices
    {
        static MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationTable, Location>());
        IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationTable>());
        IMapper modelToDb = modelToDbConfig.CreateMapper();

        CarpoolDBContext Context;
        public StationServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public bool AddStation(Station place)
        {
            try
            {
                StationTable stationTable = modelToDb.Map<Station, StationTable>(place);
                Context.StationTable.Add(stationTable);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Station> GetAll()
        {
            try
            {
                List<StationTable> stationTables = Context.StationTable.ToList();
                return dbtoModel.Map<List<StationTable>, List<Station>>(stationTables);
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
                List<StationTable> stationTables = Context.StationTable.Where(station => string.Equals(station.Id, placeID)).ToList();
                return dbtoModel.Map<List<StationTable>, List<Station>>(stationTables);
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
                List<StationTable> stationTables = Context.StationTable.Where(station => string.Equals(station.OfferId, offerID)).ToList();
                return dbtoModel.Map<List<StationTable>, List<Station>>(stationTables);
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
                StationTable stationTable = Context.StationTable.FirstOrDefault(station => string.Equals(station.Id, stationId));
                return dbtoModel.Map<StationTable, Station>(stationTable);
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
                StationTable stationTable = Context.StationTable.FirstOrDefault(station => string.Equals(station.Id, stationId));

                Context.StationTable.Remove(stationTable);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
