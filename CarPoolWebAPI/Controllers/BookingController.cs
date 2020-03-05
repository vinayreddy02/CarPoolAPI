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
   
    [ApiController]
    public class BookingController : ControllerBase
    {
        readonly IBooKingServices BookingServices;
        public BookingController(IBooKingServices services)
        {
            BookingServices = services;
        }
        // GET: api/Booking/GetBookings
        
        [HttpGet]
        [Route("api/[controller]/GetBookings")]
        public List<Booking> GetBookings()
        {
            return BookingServices.GetAll();
        }
        // POST: api/Booking/PostBooking
        [HttpPost]
        [Route("api/[controller]")]
        public bool PostBooking(Booking booking)
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
        // GET: api/Booking/GetBooking/id
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Booking GetBooking(string id)
        {
            return BookingServices.GetBooking(id);
        }
        // DELETE: api/Booking/DeleteBooking/id
        [HttpDelete]
        [Route("api/[controller]/{id}")]
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
        // PUT: api/Booking/PutBooking/id
        [HttpPut]
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]/GetBookingsWithUserId/{userId}")]
        public List<Booking> GetBookingsWithUserId(string userId)
        {
            return BookingServices.GetAllbookings(userId);
        }
        // GET: api/Bookings/GetAllRidesToStart
        [HttpGet]
        [Route("api/[controller]/GetAllRidesToStart/{offerId}")]
        public List<Booking> GetAllRidesToStart(string offerId)
        {
            return BookingServices.GetAllRidesToStart(offerId);
        }
        // GET: api/Bookings/GetRequests
        [HttpGet]
        [Route("api/[controller]/GetRequests/{offerId}")]
        public List<Booking> GetRequests(string offerId)
        {
            return BookingServices.GetRequests(offerId);
        }
        // GET: api/Bookings/StartRides
        [HttpGet]
        [Route("api/[controller]/StartRides/{offerId}")]
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
        [Route("api/[controller]/EndRides/{offerId}")]
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
        [Route("api/[controller]/CancelRides/{offerId}")]
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
        [Route("api/[controller]/requestId/Offer/{offerId}")]
        public bool ApproveRequests(string requestId, string offerId)
        {
            if (BookingServices.ApproveRequests(requestId, offerId))
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