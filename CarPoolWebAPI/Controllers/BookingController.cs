using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Services;
using CarPoolApplication.Models;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.API.Controllers
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
        [HttpGet]        
        public List<Booking> GetBookings()
        {
            return BookingServices.GetAll();
        }
        [HttpGet("{id}")]
        public Booking GetBooking(string id)
        {
            return BookingServices.GetBooking(id);
        }
        [HttpPost]
        public bool AddBooking(Booking booking)
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
        [HttpPut("{id}")]
        public string UpdateBooking(string id, Booking booking)
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
        [HttpGet]
        [Route("GetBookingsWithUserId/{userId}")]
        public List<Booking> GetBookingsWithUserId(string userId)
        {
            return BookingServices.GetAllbookings(userId);
        }
        [HttpGet]
        [Route("GetAllRidesToStartUsingOfferId/{offerId}")]
        public List<Booking> GetAllRidesToStartUsingOfferId(string offerId)
        {
            return BookingServices.GetAllRidesToStart(offerId);
        }
        [HttpGet]
        [Route("GetRequestsUsingOfferId/{offerId}")]
        public List<Booking> GetRequestsUsingOfferId(string offerId)
        {
            return BookingServices.GetRequests(offerId);
        }
        [HttpGet]
        [Route("StartRidesUsingOfferId/{offerId}")]
        public bool StartRidesUsingOfferId(string offerId)
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
        [HttpGet]
        [Route("EndRidesUsingOfferId/{offerId}")]
        public bool EndRidesUsingOfferId(string offerId)
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
        [HttpGet]
        [Route("CancelRidesUsingOfferId/{offerId}")]
        public bool CancelRidesUsingOfferId(string offerId)
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
        [HttpGet]
        [Route("ApproveRequests/{requestId}/Offer/{offerId}")]
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