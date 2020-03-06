using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class OfferTable
    {
        public OfferTable()
        {
            BookingTable = new HashSet<BookingTable>();
            StationTable = new HashSet<StationTable>();
        }

        public string Id { get; set; }
        public string FromPointId { get; set; }
        public string ToPointId { get; set; }
        public string DriverId { get; set; }
        public string VehicleId { get; set; }
        public decimal CostperPoint { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string RideStatus { get; set; }
        public string OfferStatus { get; set; }
        public int NumberOfSeats { get; set; }

        public virtual UserTable Driver { get; set; }
        public virtual LocationTable FromPoint { get; set; }
        public virtual LocationTable ToPoint { get; set; }
        public virtual VehicleTable Vehicle { get; set; }
        public virtual ICollection<BookingTable> BookingTable { get; set; }
        public virtual ICollection<StationTable> StationTable { get; set; }
    }
}
