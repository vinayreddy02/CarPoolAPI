using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        readonly IVehicleServices vehicleServices;
        public VehiclesController(IVehicleServices services)
        {
            vehicleServices = services;
        }
        [HttpGet]

        public List<Vehicle> GetVehicles()
        {
            return vehicleServices.GetVehicles();
        }
        [HttpPost]
        public bool AddVehicle(Vehicle vehicle)
        {
            return vehicleServices.AddVehicle(vehicle);
        }
        [HttpGet("{id}")]
        public Vehicle GetVehicle(string id)
        {
            return vehicleServices.GetVehicle(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteVehicle(string id)
        {
            return vehicleServices.DeleteVehicle(id);       
        }
        [HttpPut]
        public bool UpdateVehicle(Vehicle vehicle)
        {
            return vehicleServices.UpdateVehicle(vehicle);               
        }

    }
}