using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarPoolApplication.Models;
using CarPoolApplication.DataBase;
using CarPoolApplication.Services.Intefaces;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
   public class BookingServices:IBooKingServices
    {      
        readonly CarpoolDBContext Context;
       readonly IStationServices StationServices;
        public BookingServices(CarpoolDBContext context, IStationServices stationServices)
        {
            Context = context;
            StationServices = stationServices;
        }    
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings =AutoMapping.DbtoModelBooking.Map<List<BookingTable>, List<Booking>>(Context.BookingTable.ToList());
            return bookings;
        }
        public bool AddBooking(Booking bookingRequest)
        {
            try
            {
                Context.BookingTable.Add(AutoMapping.ModelToDbBooking.Map<Booking, BookingTable>(bookingRequest));
                return Context.SaveChanges() > 0;              
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateBooking(Booking bookingRequest)
        {
            try
            {
                Context.Entry(AutoMapping.ModelToDbBooking.Map<Booking, BookingTable>(bookingRequest)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
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
                return AutoMapping.DbtoModelBooking.Map<BookingTable, Booking>(Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, bookingId)));
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
                Context.BookingTable.Remove(Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, bookingId)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<Booking> GetBookingRequests(string offerId)
        {
            try
            {
                return AutoMapping.DbtoModelBooking.Map<List<BookingTable>, List<Booking>>(Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerId) && (bookingrequests.BookingStatus.Equals(BookingStatus.pending))).ToList());
            }
            catch
            {
                return null;
            }
        }        
        public List<Booking> GetBookings(string userId)
        {
            try
            {
                return AutoMapping.DbtoModelBooking.Map<List<BookingTable>, List<Booking>>(Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.PassengerId, userId)).ToList());
            }
            catch
            {
                return null;
            }
        }
        public bool ApproveBookingRequests(string requestID,string offerID)
        {
            try
            {
                int numberOfPoints;
                List<Station> stations = StationServices.GetStationsUsingOfferID(offerID);
                BookingTable request=Context.BookingTable.FirstOrDefault(request => string.Equals(request.Id, requestID));
                OfferTable offer = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerID));
                int fromIndex = -1, toIndex = -1;
                for (int index = 0; index < stations.Count; index++)
                {
                    if (string.Equals(request.FromPointId, stations[index].LocationId))
                    {
                        fromIndex = index;
                    }
                    else if (string.Equals(request.ToPointId, stations[index].LocationId))
                    {
                        toIndex = index;
                    }
                    if (fromIndex != -1 && toIndex != -1)
                    {
                        if (stations[fromIndex].StationNumber < stations[toIndex].StationNumber)
                        {
                            numberOfPoints = stations[toIndex].StationNumber - stations[fromIndex].StationNumber;

                            request.Price = numberOfPoints * offer.CostperPoint* request.NumberOfSeats;
                            request.BookingStatus = BookingStatus.confirm.ToString();
                            offer.NumberOfSeats -= request.NumberOfSeats;
                            if (offer.NumberOfSeats == 0)
                            {
                                offer.OfferStatus = OfferStatus.close.ToString();
                            }                          
                        }
                        fromIndex = -1;
                        toIndex = -1;
                    }
                }
                return Context.SaveChanges() > 0;
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
                return AutoMapping.DbtoModelBooking.Map<List<BookingTable>, List<Booking>>(Context.BookingTable.Where(bookingrequests => string.Equals(bookingrequests.OfferId, offerId) && (bookingrequests.BookingStatus.Equals(BookingStatus.confirm))).ToList());
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
                bookings.ForEach(booking => booking.BookingStatus = BookingStatus.running.ToString());
                return Context.SaveChanges() > 0;
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
                bookings.ForEach(booking => booking.BookingStatus = BookingStatus.compleated.ToString());
                return Context.SaveChanges() > 0;
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
                bookings.ForEach(booking => booking.BookingStatus = BookingStatus.cancel.ToString());
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    } }

