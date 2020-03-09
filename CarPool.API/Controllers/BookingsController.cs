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
    public class BookingsController : ControllerBase
    {
        readonly IBooKingServices BookingServices;
        public BookingsController(IBooKingServices services)
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
            return BookingServices.AddRequest(booking);          
        }
        [HttpDelete("{id}")]       
        public bool DeleteBooking(string id)
        {
            return BookingServices.DeleteBooking(id);
        }     
        [HttpPut]
        public bool UpdateBooking(Booking booking)
        {       
                return BookingServices.UpdateBooking(booking);               
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
            return BookingServices.StartRides(offerId);          
        }
        [HttpGet]
        [Route("EndRidesUsingOfferId/{offerId}")]
        public bool EndRidesUsingOfferId(string offerId)
        {
            return BookingServices.EndRides(offerId);          
        }
        [HttpGet]
        [Route("CancelRidesUsingOfferId/{offerId}")]
        public bool CancelRidesUsingOfferId(string offerId)
        {
            return BookingServices.CancelRides(offerId);           
        }
        [HttpGet]
        [Route("ApproveRequests/{requestId}/Offer/{offerId}")]
        public bool ApproveRequests(string requestId, string offerId)
        {
            return BookingServices.ApproveRequests(requestId, offerId);
        }
    }
}