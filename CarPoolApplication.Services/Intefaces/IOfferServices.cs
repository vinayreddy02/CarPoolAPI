﻿using System;
using System.Collections.Generic;
using System.Text;
using CarPoolApplication.Models;

namespace CarPoolApplication.Services.Intefaces
{
   public interface IOfferServices
    {
        public List<Offer> GetAllOffers();
        public bool AddOffer(Offer offer);
        public List<Offer> GetOffersByUserId(string userID);
        public List<Offer> GetAvilableOffers(string fromLocationId, string toLocationId, int numberOfSeats, DateTime dateTime);      
        public bool EndRide(string OfferID);
        public bool StartRide(string OfferID);
        public bool CancelRide(string OfferID);
        public List<Offer> GetAllOffersByUserId(string userID);
        public bool CloseOffer(string OfferID);
        public bool DeleteOffer(string OfferID);
        public Offer GetOffer(string offerId);
        public bool UpdateOffer(Offer offer);
    }
}
