using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Services;
using CarPoolApplication.Models;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBookingServices BookingServices;
        public BookingController(IBookingServices services)
        {
            BookingServices = services;
        }
        // GET: api/Bookings
        [HttpGet]
        public List<Booking> GetBookingss()
        {
            return BookingServices.GetAll();
        }
        // POST: api/Bookings
        [HttpPost]
        public bool PostUser(Booking booking)
        {
            if (BookingServices.AddRequest(booking))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public Booking GetBooking(string id)
        {
            return BookingServices.GetBooking(id);
        }
        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public bool DeleteBooking(string id)
        {
            if (BookingServices.DeleteBooking(id))
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