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
        readonly IBooKingServices BookingServices;
        public BookingController(IBooKingServices services)
        {
            BookingServices = services;
        }
        // GET: api/Bookings
        [HttpGet]
        public List<Booking> GetBookings()
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
        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public string PutBooking(string id, Booking booking)
        {
            if (id != booking.Id)
            {
                return "Booking does not exists";
            }
            else
            {
                if (BookingServices.UpdateBooking(booking))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        // GET: api/Bookings/GetBookingsWithUserId
        [HttpGet]
        public List<Booking> GetBookingsWithUserId(string userId)
        {
            return BookingServices.GetAllbookings(userId);
        }
        // GET: api/Bookings/GetAllRidesToStart
        [HttpGet]
        public List<Booking> GetAllRidesToStart(string offerId)
        {
            return BookingServices.GetAllRidesToStart(offerId);
        }
        // GET: api/Bookings/GetRequests
        [HttpGet]
        public List<Booking> GetRequests(string offerId)
        {
            return BookingServices.GetRequests(offerId);
        }
        // GET: api/Bookings/StartRides
        [HttpGet]
        public bool StartRides(string offerId)
        {
            if (BookingServices.StartRides(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Bookings/EndRides
        [HttpGet]
        public bool EndRides(string offerId)
        {
            if (BookingServices.EndRides(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Bookings/CancelRides
        [HttpGet]
        public bool CancelRides(string offerId)
        {
            if (BookingServices.CancelRides(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // GET: api/Bookings/ApproveRequests
        [HttpGet]
        public bool ApproveRequests(string requestID, string offerID)
        {
            if (BookingServices.ApproveRequests(requestID, offerID))
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