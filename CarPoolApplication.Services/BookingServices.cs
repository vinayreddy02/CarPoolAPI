﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarPoolApplication.Models;
using CarPoolDataBase;
using CarPoolApplication.Services.Intefaces;
using AutoMapper;
using AutoMapper.Configuration;


namespace CarPoolApplication.Services
{
   public class BookingServices:IBookingServices
    {
        static MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<BookingTable, Booking>());
        IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<Booking, BookingTable>());
        IMapper modelToDb = modelToDbConfig.CreateMapper();
       
        CarpoolDBContext Context;
        public BookingServices(CarpoolDBContext context)
        {
            Context = context;
        }
        public List<Booking> GetAll()
        {
            List<BookingTable> bookingTable = Context.BookingTable.ToList();
            List<Booking> bookings = dbtoModel.Map<List<BookingTable>, List<Booking>>(bookingTable);
            return bookings;
        }
        public bool AddRequest(Booking bookingRequest)
        {
            try
            {
                BookingTable bookingTable = modelToDb.Map<Booking, BookingTable>(bookingRequest);
                Context.BookingTable.Add(bookingTable);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Booking GetBooking(string bookingId)
        {
            try
            {
                BookingTable request = Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, bookingId));
                return dbtoModel.Map<BookingTable, Booking>(request);
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteBooking(string bookingId)
        {
            try
            {
                BookingTable request = Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, bookingId));

                Context.BookingTable.Remove(request);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Booking> GetRequests(string offerId)
        {
            try
            {

                List<BookingTable> bookingTable = Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerId) && (bookingrequests.BookingStatus.Equals(BookingStatus.pending))).ToList();
                return dbtoModel.Map<List<BookingTable>, List<Booking>>(bookingTable);
            }
            catch
            {
                return null;
            }
        }
        
        public List<Booking> GetAllbookings(string userId)
        {
            try
            {
                List<BookingTable> bookingTable = Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.PassengerId, userId)).ToList();
                return dbtoModel.Map<List<BookingTable>, List<Booking>>(bookingTable);
            }
            catch
            {
                return null;
            }
        }
        public bool ApprovalOfBooking(string requestID,string offerID, List<Station> locations)
        {
            try
            {
                int numberOfPoints;
                BookingTable request=Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, requestID));
                OfferTable offer = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerID));
                int fromIndex = -1, toIndex = -1;
                for (int index = 0; index < locations.Count; index++)
                {
                    if (string.Equals(request.FromPointId, locations[index].LocationId))
                    {
                        fromIndex = index;
                    }
                    else if (string.Equals(request.ToPointId, locations[index].LocationId))
                    {
                        toIndex = index;
                    }
                    if (fromIndex != -1 && toIndex != -1)
                    {
                        if (locations[fromIndex].StationNumber < locations[toIndex].StationNumber)
                        {
                            numberOfPoints = locations[toIndex].StationNumber - locations[fromIndex].StationNumber;
                            
                            request.Price = numberOfPoints * offer.CostperPoint* request.NumberOfSeats;
                            request.BookingStatus = BookingStatus.confirm.ToString();
                            offer.NumberOfSeats -= request.NumberOfSeats;
                            if (offer.NumberOfSeats == 0)
                            {
                                offer.OfferStatus = OfferStatus.close.ToString();
                            }
                            Context.SaveChanges();
                        }
                        fromIndex = -1;
                        toIndex = -1;

                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<Booking> GetAllRidesToStart(string offerId)
        {
            try
            {
                List<BookingTable> bookingTable = Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerId) && (bookingrequests.BookingStatus.Equals(BookingStatus.confirm))).ToList();
                return dbtoModel.Map<List<BookingTable>, List<Booking>>(bookingTable);
            }
            catch
            {
                return null;
            }
        }

        public bool StartRides(string offerId)
        {
            try
            {
                List<BookingTable> bookings = Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerId) && (bookingrequests.BookingStatus.Equals(BookingStatus.confirm))).ToList();
                foreach (var booking in bookings)
                {
                    booking.BookingStatus = BookingStatus.running.ToString();
                }
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool EndRides(string offerID)

        {
            try
            {
                List<BookingTable> bookings = Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerID) && (bookingrequests.BookingStatus.Equals(BookingStatus.running))).ToList();
                foreach (var booking in bookings)
                {
                    booking.BookingStatus = BookingStatus.compleated.ToString();
                }
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CancelRides(string offerId)
        {
            try
            {
                List<BookingTable> bookings = Context.BookingTable.Where(bookingrequest => string.Equals(bookingrequest.OfferId, offerId) && (bookingrequest.BookingStatus.Equals(BookingStatus.confirm)) || (bookingrequest.BookingStatus.Equals(BookingStatus.pending))).ToList();
                foreach (var booking in bookings)
                {
                    booking.BookingStatus = BookingStatus.cancel.ToString();
                }
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    } }
