using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class VehicleTable
    {
        public VehicleTable()
        {
            OfferTable = new HashSet<OfferTable>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string UserId { get; set; }

        public virtual UserTable User { get; set; }
        public virtual ICollection<OfferTable> OfferTable { get; set; }
    }
}
