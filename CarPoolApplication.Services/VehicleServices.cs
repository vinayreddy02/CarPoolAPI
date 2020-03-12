using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.DataBase;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
    public class VehicleServices:IVehicleServices
    {     
        private readonly CarpoolDBContext Context;
        public VehicleServices(CarpoolDBContext context)
        {
            Context = context;

        }
        public List<Vehicle> GetVehicles()
        {
            try
            {
                return AutoMapping<VehicleTable,Vehicle>.Mapper.Map<List<VehicleTable>, List<Vehicle>>(Context.VehicleTable.ToList());           
            }
            catch
            {
                return null;
            }
        }
        public bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                Context.VehicleTable.Add(AutoMapping<VehicleTable, Vehicle>.Mapper.Map<Vehicle, VehicleTable>(vehicle));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                Context.Entry(AutoMapping<VehicleTable,Vehicle>.Mapper.Map<Vehicle, VehicleTable>(vehicle)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public Vehicle GetVehicle(string vehicleId)
        {
            try
            {
                return AutoMapping<VehicleTable,Vehicle>.Mapper.Map<VehicleTable, Vehicle>(Context.VehicleTable.FirstOrDefault(vehicle => string.Equals(vehicle.Id, vehicleId)));   
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteVehicle(string vehicleId)
        {
            try
            {
                Context.VehicleTable.Remove(Context.VehicleTable.FirstOrDefault(vehicle => string.Equals(vehicle.Id, vehicleId)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
