using System;
using System.Collections.Generic;

namespace CarPoolApplication.DataBase
{
    public partial class StationTable
    {
        public string Id { get; set; }
        public string LocationId { get; set; }
        public string OfferId { get; set; }
        public int StationNumber { get; set; }

        public virtual OfferTable Offer { get; set; }
    }
}
