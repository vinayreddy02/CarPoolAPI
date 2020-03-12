using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.DataBase;
using AutoMapper;
using System.Linq;
using CarPoolApplication.Services.Intefaces;
using Microsoft.EntityFrameworkCore;
namespace CarPoolApplication.Services
{
    public class LocationServices:ILocationServices
    {
        private readonly CarpoolDBContext Context;
        public LocationServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public bool AddLocation(Location place)
        {
            try
            {
                Context.LocationTable.Add(AutoMapping<LocationTable, Location>.Mapper.Map<Location, LocationTable>(place));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateLocation(Location place)
        {
            try
            {
                Context.Entry(AutoMapping<LocationTable, Location>.Mapper.Map<Location, LocationTable>(place)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<Location> GetAllLocations()
        {
            try
            {
                return AutoMapping<LocationTable, Location>.Mapper.Map<List<LocationTable>, List<Location>>(Context.LocationTable.ToList());
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
                return AutoMapping<LocationTable, Location>.Mapper.Map<List<LocationTable>, List<Location>>(Context.LocationTable.Where(location => string.Equals(location.Place, place)).ToList());
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
                return AutoMapping<LocationTable, Location>.Mapper.Map<LocationTable, Location>(Context.LocationTable.FirstOrDefault(location => string.Equals(location.Id, LocationID)));
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
                Context.LocationTable.Remove(Context.LocationTable.FirstOrDefault(location => string.Equals(location.Id, LocationID)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

    }
}
