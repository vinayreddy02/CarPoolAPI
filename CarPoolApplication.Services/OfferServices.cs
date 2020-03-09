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
        public List<Offer> GetAllOffers()
        {
            try
            {
                return AutoMapping.DbtoModelOffer.Map<List<OfferTable>, List<Offer>>(Context.OfferTable.ToList());
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
                Context.OfferTable.Add(AutoMapping.ModelToDbOffer.Map<Offer, OfferTable>(offer));
                return Context.SaveChanges() > 0;
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
                Context.Entry(AutoMapping.ModelToDbOffer.Map<Offer, OfferTable>(offer)).State = EntityState.Modified;
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public List<Offer> GetOffersByUserId(string userId)
        {
            try
            {
                return AutoMapping.DbtoModelOffer.Map<List<OfferTable>, List<Offer>>(Context.OfferTable.Where(offer => string.Equals(offer.DriverId, userId) && offer.OfferStatus.Equals(OfferStatus.open)).ToList());
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
                                Offer offer= AutoMapping.DbtoModelOffer.Map<OfferTable,Offer>(offerTable);
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
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }

        }
        public List<Offer> GetAllOffersByUserId(string userID)
        {
            try
            {
                return AutoMapping.DbtoModelOffer.Map<List<OfferTable>, List<Offer>>(Context.OfferTable.Where(offer => string.Equals(offer.DriverId, userID)).ToList());
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
                return Context.SaveChanges() > 0;
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
                return Context.SaveChanges() > 0;
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
                return Context.SaveChanges() > 0;
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
                return AutoMapping.DbtoModelOffer.Map<OfferTable, Offer>(Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId)));
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
                Context.OfferTable.Remove(Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, offerId)));
                return Context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
