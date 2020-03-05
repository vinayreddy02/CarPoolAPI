using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolApplication.Models
{
    public class Booking
    {
        public string Id { get; set; }
        public string PassengerId { get; set; }
        public string FromPointId { get; set; }
        public string ToPointId { get; set; }
        public string OfferId { get; set; }
        public decimal Price { get; set; }
        public int NumberOfseats { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public DateTime DateTime { get; set; }
       
    }
}
