using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.DataBase;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services
{
    public static class AutoMapping
    {
        readonly static MapperConfiguration DbtoModelOfferConfig = new MapperConfiguration(cfg => cfg.CreateMap<OfferTable, Offer>());
        public static IMapper DbtoModelOffer = DbtoModelOfferConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbOfferConfig = new MapperConfiguration(cfg => cfg.CreateMap<Offer, OfferTable>());
        public static IMapper ModelToDbOffer = ModelToDbOfferConfig.CreateMapper();
        readonly static MapperConfiguration DbtoModelBookingConfig = new MapperConfiguration(cfg => cfg.CreateMap<BookingTable, Booking>());
        public static IMapper DbtoModelBooking = DbtoModelBookingConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbBookingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingTable>());
        public static IMapper ModelToDbBooking = ModelToDbBookingConfig.CreateMapper();
        readonly static MapperConfiguration DbtoModelLocationConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationTable, Location>());
        public static IMapper DbtoModelLocation = DbtoModelLocationConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbLocationConfig = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationTable>());
        public static IMapper ModelToDbLocation = ModelToDbLocationConfig.CreateMapper();
        readonly static MapperConfiguration DbtoModelStationConfig = new MapperConfiguration(cfg => cfg.CreateMap<StationTable, Station>());
        public static IMapper DbtoModelStation = DbtoModelStationConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbStationConfig = new MapperConfiguration(cfg => cfg.CreateMap<Station, StationTable>());
        public static IMapper ModelToDbStation = ModelToDbStationConfig.CreateMapper();
        readonly static MapperConfiguration DbtoModelUserConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserTable, User>());
        public static IMapper DbtoModelUser = DbtoModelUserConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbUserConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserTable>());
        public static IMapper ModelToDbUser = ModelToDbUserConfig.CreateMapper();
        readonly static MapperConfiguration DbtoModelVehicleConfig = new MapperConfiguration(cfg => cfg.CreateMap<VehicleTable, Vehicle>());
        public static IMapper DbtoModelVehicle = DbtoModelVehicleConfig.CreateMapper();
        readonly static MapperConfiguration ModelToDbVehicleConfig = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, VehicleTable>());
        public static IMapper ModelToDbVehicle = ModelToDbVehicleConfig.CreateMapper();
    }
}
