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
         IVehicleServices vehicleServices;
        public VehicleController(IVehicleServices services)
        {
            vehicleServices = services;
        }
        // GET: api/Vehicle
        [HttpGet]
        public List<Vehicle> GetVehicles()
        {
            return vehicleServices.GetVehicles();
        }
        // POST: api/Vehicle
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
        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public Vehicle GetVehicle(string id)
        {
            return vehicleServices.GetVehicle(id);
        }
        // DELETE: api/Vehicle/5
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
        // PUT: api/Vehicle/5
        [HttpPut("{id}")]
        public string PutVehicle(string id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return "Vehicle does not exists";
            }
            else
            {
                if (vehicleServices.UpdateVehicle(vehicle))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }

    }
}