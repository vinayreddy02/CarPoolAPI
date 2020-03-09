using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IBooKingServices
    {
        public List<Booking> GetBookingRequests(string offerID);
        public List<Booking> GetBookings(string userID);
        public List<Booking> GetAllRidesToStart(string offerID);
        public bool ApproveBookingRequests(string requestID, string offerID);
        public bool StartRides(string offerID);
        public bool EndRides(string offerID);
        public bool CancelRides(string offerID);
        public bool DeleteBooking(string BookingID);
        public Booking GetBooking(string BookingID);
        public List<Booking> GetAllBookings();
        public bool AddBooking(Booking bookingRequest);
        public bool UpdateBooking(Booking bookingRequest);
    }
}
