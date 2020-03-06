using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.Models;
using CarPoolApplication.DataBase;
using  System.Linq;
using CarPoolApplication.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace CarPoolApplication.Services
{
    public class OfferServices:IOfferServices
    {
       
        private readonly CarpoolDBContext Context;
        readonly IStationServices StationServices;
        public OfferServices(CarpoolDBContext context,IStationServices stationServices)
        {
            Context = context;
            StationServices = stationServices;
        }
        public List<Offer> GetAll()
        {
            try
            {
                List<OfferTable> offerTables = Context.OfferTable.ToList();
                return AutoMapping.dbtoModelOffer.Map<List<OfferTable>, List<Offer>>(offerTables);
            }
            catch
            {
                return null;
            }
        }
        public bool AddOffer(Offer offer)
        {
            try
            {
                OfferTable offerTable = AutoMapping.modelToDbOffer.Map<Offer, OfferTable>(offer);
                Context.OfferTable.Add(offerTable);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateOffer(Offer offer)
        {
            try
            {
                OfferTable offerTable = AutoMapping.modelToDbOffer.Map<Offer, OfferTable>(offer);
                Context.Entry(offerTable).State = EntityState.Modified;
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<Offer> GetOffers(string userID)
        {
            try
            {
                List<OfferTable> offerTables = Context.OfferTable.Where(offer => string.Equals(offer.DriverId, userID) && offer.OfferStatus.Equals(OfferStatus.open)).ToList();
                return AutoMapping.dbtoModelOffer.Map<List<OfferTable>, List<Offer>>(offerTables);
            }
            catch
            {
                return null;
            }
        }
        
        public List<Offer> GetAvilableOffers(string fromLocationId, string toLocationId, int numberOfSeats, DateTime dateTime)
        {
            try
            {
                OfferTable offerTable;
                int numberOfPoints;
                List<Station> fromStations = StationServices.GetStations(fromLocationId);
                List<Station> toStations= StationServices.GetStations(toLocationId);
                List<Offer> AvailableOffers = new List<Offer>();

                for (int fromIndex = 0; fromIndex < fromStations.Count; fromIndex++)
                {
                    for (int toIndex = 0; toIndex < toStations.Count; toIndex++)
                    {
                        if (string.Equals(fromStations[fromIndex].OfferId, toStations[toIndex].OfferId) && fromStations[fromIndex].StationNumber < toStations[toIndex].StationNumber)
                        {
                            offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, fromStations[fromIndex].OfferId));
                            
                            if (offerTable.OfferStatus.Equals(OfferStatus.open) && (offerTable.NumberOfSeats > numberOfSeats) && (string.Equals(offerTable.DateTime.Date.ToString(), dateTime.Date.ToString())))
                            {
                                numberOfPoints = toStations[toIndex].StationNumber - fromStations[fromIndex].StationNumber;
                                offerTable.Price = numberOfPoints * offerTable.CostperPoint;
                                Context.SaveChanges();
                                Offer offer= AutoMapping.dbtoModelOffer.Map<OfferTable,Offer>(offerTable);
                                AvailableOffers.Add(offer);
                            }
                        }
                    }
                }
                return AvailableOffers;
            }
            catch
            {
                return null;
            }
        }
        public bool EndRide(string offerId)
        {
            try
            {
                OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                offerTable.RideStatus = RideStatus.Compleated.ToString();
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<Offer> GetAllOffers(string userID)
        {
            try
            {
                List<OfferTable> offerTables = Context.OfferTable.Where(offer => string.Equals(offer.DriverId, userID)).ToList();
                return AutoMapping.dbtoModelOffer.Map<List<OfferTable>, List<Offer>>(offerTables);
            }
            catch
            {
                return null;
            }

        }
        public bool StartRide(string offerId)
        {
            try
            {
                OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                offerTable.RideStatus = RideStatus.running.ToString();
                if (offerTable.OfferStatus.Equals(OfferStatus.open))
                {
                    offerTable.OfferStatus = OfferStatus.close.ToString();
                }
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CloseOffer(string offerId)
        {
            try
            {    OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                offerTable.OfferStatus = OfferStatus.close.ToString();
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CancelRide(string offerId)
        {
            try
            {
                OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                offerTable.RideStatus = RideStatus.cancel.ToString();
                offerTable.OfferStatus = OfferStatus.close.ToString();
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Offer GetOffer(string offerId)
        {
            try
            {
                OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                return AutoMapping.dbtoModelOffer.Map<OfferTable, Offer>(offerTable);
            }
            catch
            {
                return null;
            }
        }
        public bool DeleteOffer(string offerId)
        {
            try
            {
                OfferTable offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId));
                Context.OfferTable.Remove(offerTable);
                Context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
