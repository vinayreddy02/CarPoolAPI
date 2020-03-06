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
                List<VehicleTable> vehicleTables = Context.VehicleTable.ToList();
                return AutoMapping.dbtoModelVehicle.Map<List<VehicleTable>, List<Vehicle>>(vehicleTables);
           
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
                VehicleTable vehicleTable = AutoMapping.modelToDbVehicle.Map<Vehicle, VehicleTable>(vehicle);
                Context.VehicleTable.Add(vehicleTable);
                Context.SaveChanges();
                return true;
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
                VehicleTable vehicleTable = AutoMapping.modelToDbVehicle.Map<Vehicle, VehicleTable>(vehicle);
                Context.Entry(vehicleTable).State = EntityState.Modified;
                Context.SaveChanges();
                return true;
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
                VehicleTable vehicleTable = Context.VehicleTable.FirstOrDefault(vehicle => string.Equals(vehicle.Id, vehicleId));
                return AutoMapping.dbtoModelVehicle.Map<VehicleTable, Vehicle>(vehicleTable);
   
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
                VehicleTable vehicleTable = Context.VehicleTable.FirstOrDefault(vehicle => string.Equals(vehicle.Id, vehicleId));

                Context.VehicleTable.Remove(vehicleTable);

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
