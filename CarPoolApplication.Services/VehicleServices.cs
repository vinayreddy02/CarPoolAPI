using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolDataBase;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;
using System.Linq;

namespace CarPoolApplication.Services
{
    public class VehicleServices:IVehicleServices
    {
        static MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<VehicleTable, Vehicle>());
        IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, VehicleTable>());
        IMapper modelToDb = modelToDbConfig.CreateMapper();

        CarpoolDBContext Context;
        public VehicleServices(CarpoolDBContext context)
        {
            Context = context;

        }
        public List<Vehicle> GetVehicles()
        {
            try
            {
                List<VehicleTable> vehicleTables = Context.VehicleTable.ToList();
                return dbtoModel.Map<List<VehicleTable>, List<Vehicle>>(vehicleTables);
               

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
                VehicleTable vehicleTable = modelToDb.Map<Vehicle, VehicleTable>(vehicle);

                Context.VehicleTable.Add(vehicleTable);

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
                return dbtoModel.Map<VehicleTable, Vehicle>(vehicleTable);
   
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
