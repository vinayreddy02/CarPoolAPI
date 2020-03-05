using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarPoolApplication.Models;
using CarPoolDataBase;
using  System.Linq;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.Services
{
    public class OfferServices:IOfferServices
    {

        static MapperConfiguration dbtoModelConfig = new MapperConfiguration(cfg => cfg.CreateMap<OfferTable, Offer>());
        IMapper dbtoModel = dbtoModelConfig.CreateMapper();
        static MapperConfiguration modelToDbConfig = new MapperConfiguration(cfg => cfg.CreateMap<Offer, OfferTable>());
        IMapper modelToDb = modelToDbConfig.CreateMapper();

        private readonly CarpoolDBContext Context;

        public OfferServices(CarpoolDBContext context)
        {
            Context = context;
        }

        public List<Offer> GetAll()
        {
            try
            {
                List<OfferTable> offerTables = Context.OfferTable.ToList();
                return dbtoModel.Map<List<OfferTable>, List<Offer>>(offerTables);
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
                OfferTable offerTable = modelToDb.Map<Offer, OfferTable>(offer);


                Context.OfferTable.Add(offerTable);
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
                return dbtoModel.Map<List<OfferTable>, List<Offer>>(offerTables);
            }
            catch
            {
                return null;
            }
        }
        public Offer GetOfferUsingOfferID(string OfferID)
        {
            try
            {
                OfferTable offerTable= Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, OfferID));
                return dbtoModel.Map<OfferTable, Offer>(offerTable);


            }
            catch
            {
                return null;
            }
        }
        public List<Offer> GetAvilableOffers( List<Station> fromLocations, List<Station> toLocations, int numberOfSeats, DateTime dateTime)
        {
            try
            {
                OfferTable offerTable;
                int numberOfPoints;
                List<Offer> AvailableOffers = new List<Offer>();

                for (int fromIndex = 0; fromIndex < fromLocations.Count; fromIndex++)
                {
                    for (int toIndex = 0; toIndex < fromLocations.Count; toIndex++)
                    {
                        if (string.Equals(fromLocations[fromIndex].OfferId, toLocations[toIndex].OfferId) && fromLocations[fromIndex].StationNumber < toLocations[toIndex].StationNumber)
                        {
                            offerTable = Context.OfferTable.FirstOrDefault(offer => string.Equals(offer.Id, fromLocations[fromIndex].OfferId));
                            
                            if (offerTable.OfferStatus.Equals(OfferStatus.open) && (offerTable.NumberOfSeats > numberOfSeats) && (string.Equals(offerTable.DateTime.Date.ToString(), dateTime.Date.ToString())))
                            {
                                numberOfPoints = toLocations[toIndex].StationNumber - fromLocations[fromIndex].StationNumber;
                                offerTable.Price = numberOfPoints * offerTable.CostperPoint;
                                Context.SaveChanges();
                                Offer offer= dbtoModel.Map<OfferTable,Offer>(offerTable);
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
                return dbtoModel.Map<List<OfferTable>, List<Offer>>(offerTables);
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
                return iMapper.Map<OfferTable, Offer>(offerTable);
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
