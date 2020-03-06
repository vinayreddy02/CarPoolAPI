using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class UserTable
    {
        public UserTable()
        {
            BookingTable = new HashSet<BookingTable>();
            OfferTable = new HashSet<OfferTable>();
            VehicleTable = new HashSet<VehicleTable>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<BookingTable> BookingTable { get; set; }
        public virtual ICollection<OfferTable> OfferTable { get; set; }
        public virtual ICollection<VehicleTable> VehicleTable { get; set; }
    }
}
