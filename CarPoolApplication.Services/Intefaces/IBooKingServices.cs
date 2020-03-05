using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IBookingServices
    {
        public List<Booking> GetRequests(string offerID);
        public List<Booking> GetAllbookings(string userID);
        public List<Booking> GetAllRidesToStart(string offerID);
        public bool ApprovalOfBooking(string requestID, string offerID, List<Station> locations);
        public bool StartRides(string offerID);
        public bool EndRides(string offerID);
        public bool CancelRides(string offerID);
        public bool DeleteBooking(string BookingID);
        public Booking GetBooking(string BookingID);
        public List<Booking> GetAll();
        public bool AddRequest(Booking bookingRequest);
    }
}
