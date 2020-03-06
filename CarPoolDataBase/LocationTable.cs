using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class LocationTable
    {
        public LocationTable()
        {
            BookingTableFromPoint = new HashSet<BookingTable>();
            BookingTableToPoint = new HashSet<BookingTable>();
            OfferTableFromPoint = new HashSet<OfferTable>();
            OfferTableToPoint = new HashSet<OfferTable>();
        }
        public string Id { get; set; }
        public string Place { get; set; }
        public virtual ICollection<BookingTable> BookingTableFromPoint { get; set; }
        public virtual ICollection<BookingTable> BookingTableToPoint { get; set; }
        public virtual ICollection<OfferTable> OfferTableFromPoint { get; set; }
        public virtual ICollection<OfferTable> OfferTableToPoint { get; set; }
    }
}
