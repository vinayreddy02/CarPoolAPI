using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.DataBase;
using CarPoolApplication.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarPoolApplication.Services
{
    public static class AutoMapping
    {
        public static IMapper DbtoModelOffer = new MapperConfiguration(cfg => cfg.CreateMap<OfferTable, Offer>()).CreateMapper();
        public static IMapper ModelToDbOffer = new MapperConfiguration(cfg => cfg.CreateMap<Offer, OfferTable>()).CreateMapper();
        public static IMapper DbtoModelBooking = new MapperConfiguration(cfg => cfg.CreateMap<BookingTable, Booking>()).CreateMapper();
        public static IMapper ModelToDbBooking = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingTable>()).CreateMapper();
        public static IMapper DbtoModelLocation = new MapperConfiguration(cfg => cfg.CreateMap<LocationTable, Location>()).CreateMapper();
        public static IMapper ModelToDbLocation = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationTable>()).CreateMapper();
        public static IMapper DbtoModelStation = new MapperConfiguration(cfg => cfg.CreateMap<StationTable, Station>()).CreateMapper();
        public static IMapper ModelToDbStation = new MapperConfiguration(cfg => cfg.CreateMap<Station, StationTable>()).CreateMapper();
        public static IMapper DbtoModelUser = new MapperConfiguration(cfg => cfg.CreateMap<UserTable, User>()).CreateMapper();
        public static IMapper ModelToDbUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserTable>()).CreateMapper();
        public static IMapper DbtoModelVehicle = new MapperConfiguration(cfg => cfg.CreateMap<VehicleTable, Vehicle>()).CreateMapper();
        public static IMapper ModelToDbVehicle = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, VehicleTable>()).CreateMapper();
    }
}
