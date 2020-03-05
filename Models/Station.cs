using System;
using System.Collections.Generic;
using System.Text;

namespace CarPoolApplication.Models
{
   public class Station
    {
        public string Id { get; set; }
        public string LocationId { get; set; }
        public string OfferId { get; set; }
        public int StationNumber { get; set; }
    }
}
