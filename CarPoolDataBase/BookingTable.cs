using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class BookingTable
    {
        public string Id { get; set; }
        public string FromPointId { get; set; }
        public string ToPointId { get; set; }
        public string PassengerId { get; set; }
        public decimal Price { get; set; }
        public string OfferId { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime DateTime { get; set; }
        public string BookingStatus { get; set; }

        public virtual LocationTable FromPoint { get; set; }
        public virtual OfferTable Offer { get; set; }
        public virtual UserTable Passenger { get; set; }
        public virtual LocationTable ToPoint { get; set; }
    }
}
