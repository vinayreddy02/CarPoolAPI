using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolApplication.Models
{
    public class Offer
    {
        public string Id { get; set; }
        public string DriverId { get; set; }
        public string FromPointId { get; set; }
        public string ToPointId { get; set; }
        public string VehicleId { get; set; }
        public int NumberOfSeats { get; set; }
        public int CostperPoint { get; set; }
        public int Price { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public RideStatus RideStatus { get; set; }
        public DateTime DateTime { get; set; }
    }
}
