using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.DataBase;


namespace CarPoolApplication.Models
{
  static public class AutoMapping
    {
        static readonly MapperConfiguration dbtoModelOfferConfig = new MapperConfiguration(cfg => cfg.CreateMap<OfferTable, Offer>());
        public static IMapper dbtoModelOffer = dbtoModelOfferConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbOfferConfig = new MapperConfiguration(cfg => cfg.CreateMap<Offer, OfferTable>());
        public static IMapper modelToDbOffer = modelToDbOfferConfig.CreateMapper();
        static readonly MapperConfiguration dbtoModelBookingConfig = new MapperConfiguration(cfg => cfg.CreateMap<BookingTable, Booking>());
        public static IMapper dbtoModelBooking = dbtoModelBookingConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbBookingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingTable>());
        public static IMapper modelToDbBooking = modelToDbBookingConfig.CreateMapper();
        static readonly MapperConfiguration dbtoModelLocationConfig = new MapperConfiguration(cfg => cfg.CreateMap<LocationTable, Location>());
        public static IMapper dbtoModelLocation = dbtoModelLocationConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbLocationConfig = new MapperConfiguration(cfg => cfg.CreateMap<Location, LocationTable>());
        public static IMapper modelToDbLocation = modelToDbLocationConfig.CreateMapper();
        static readonly MapperConfiguration dbtoModelStationConfig = new MapperConfiguration(cfg => cfg.CreateMap<StationTable, Station>());
        public static IMapper dbtoModelStation = dbtoModelStationConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbStationConfig = new MapperConfiguration(cfg => cfg.CreateMap<Station, StationTable>());
        public static IMapper modelToDbStation = modelToDbStationConfig.CreateMapper();
        static readonly MapperConfiguration dbtoModelUserConfig = new MapperConfiguration(cfg => cfg.CreateMap<UserTable, User>());
        public static IMapper dbtoModelUser = dbtoModelUserConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbUserConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserTable>());
        public static IMapper modelToDbUser = modelToDbUserConfig.CreateMapper();
        static readonly MapperConfiguration dbtoModelVehicleConfig = new MapperConfiguration(cfg => cfg.CreateMap<VehicleTable, Vehicle>());
        public static IMapper dbtoModelVehicle = dbtoModelVehicleConfig.CreateMapper();
        static readonly MapperConfiguration modelToDbVehicleConfig = new MapperConfiguration(cfg => cfg.CreateMap<Vehicle, VehicleTable>());
        public static IMapper modelToDbVehicle = modelToDbVehicleConfig.CreateMapper();
    }
}
