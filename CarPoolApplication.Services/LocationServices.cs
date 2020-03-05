﻿using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolDataBase;
using AutoMapper;
using System.Linq;
using CarPoolApplication.Services.Intefaces;
namespace CarPoolApplication.Services
{
    public class LocationServices:ILocationServices
    {
        static MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationTable, Location>());
        IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationTable>());
        IMapper modelToDb = modelToDbConfig.CreateMapper();
       
        CarpoolDBContext Context;
        public LocationServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public bool AddLocation(Location place)
        {
            try
            {
                LocationTable locationTable = modelToDb.Map<Location, LocationTable>(place);
                Context.LocationTable.Add(locationTable);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Location> GetAll()
        {
            try
            {
                List<LocationTable> locationTables= Context.LocationTable.ToList();
                return dbtoModel.Map<List<LocationTable>, List<Location>>(locationTables);
            }
            catch
            {
                return null;
            }
        }
        public List<Location> GetLocations(string place)
        {
            try
            {
                List<LocationTable> locationTables = Context.LocationTable.Where(location => string.Equals(location.Place, place)).ToList();
                return dbtoModel.Map<List<LocationTable>, List<Location>>(locationTables);
            }
            catch
            {
                return null;
            }
        }
        public Location GetLocation(string LocationID)
        {
            try
            {
                LocationTable locationTable = Context.LocationTable.FirstOrDefault(location => string.Equals(location.Id, LocationID));
                return dbtoModel.Map<LocationTable, Location>(locationTable);
             }
            catch
            {
                return null;
            }
        }
        public bool DeleteLocation(string LocationID)
        {
            try
            {
                LocationTable locationTable = Context.LocationTable.FirstOrDefault(location => string.Equals(location.Id, LocationID));
                Context.LocationTable.Remove(locationTable);
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