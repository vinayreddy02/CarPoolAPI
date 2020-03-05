using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IVehicleServices
    {
        public List<Vehicle> GetVehicles();
        public Vehicle GetVehicle(string vehicleId);
        public bool AddVehicle(Vehicle vehicle);
        public bool DeleteVehicle(string vehicleId);
        public bool UpdateVehicle(Vehicle vehicle);
    }
}
