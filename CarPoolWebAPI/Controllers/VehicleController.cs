using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        VehicleServices vehicleServices;
        public VehicleController(VehicleServices services)
        {
            vehicleServices = services;
        }
        // GET: api/Vehicles
        [HttpGet]
        public List<Vehicle> GetVehicles()
        {
            return vehicleServices.GetVehicles();
        }
        // POST: api/Vehicles
        [HttpPost]
        public bool PostVehicle(Vehicle vehicle)
        {
            if (vehicleServices.AddVehicle(vehicle))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public Vehicle GetVehicle(string id)
        {
            return vehicleServices.GetVehicle(id);
        }
        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public bool DeleteVehicle(string id)
        {
            if (vehicleServices.DeleteVehicle(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}