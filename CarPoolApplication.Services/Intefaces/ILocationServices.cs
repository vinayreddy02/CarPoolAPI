using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
  public interface ILocationServices
    {
        public bool AddLocation(Location place);
        public List<Location> GetLocations(string place);
        public List<Location> GetAllLocations();
        public bool DeleteLocation(string LocationID);
        public Location GetLocation(string LocationID);
        public bool UpdateLocation(Location place);
    }
}
