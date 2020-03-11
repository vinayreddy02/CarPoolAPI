using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        readonly IOfferServices OfferServices;
        public OffersController(IOfferServices services)
        {
            OfferServices = services;
        }
        [HttpGet]
        public List<Offer> GetOffers()
        {
            return OfferServices.GetAllOffers();
        }
        [HttpPost]
        public bool AddOffer(Offer offer)
        {
            return OfferServices.AddOffer(offer);           
        }
        [HttpGet("{id}")]
        public Offer GetOffer(string id)
        {
            return OfferServices.GetOffer(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteOffer(string id)
        {
            return OfferServices.DeleteOffer(id);         
        }
        [HttpPut]
        public bool UpdateOffer(Offer offer)
        {
            return OfferServices.UpdateOffer(offer);                      
        }
        [HttpGet]
        [Route("GetAllAvailableOffers/{fromLocationId}/{toLocationId}/{numberOfSeats:int}/{dateTime:DateTime}")]
        public List<Offer> GetAllAvailableOffers(string fromLocationId, string toLocationId, int numberOfSeats, DateTime dateTime)
        {
            return OfferServices.GetAvilableOffers(fromLocationId, toLocationId, numberOfSeats, dateTime);
        }
        [HttpGet]
        [Route("CancelRide/{offerId}")]
        public bool CancelRideUsingOfferId(string offerId)
        {
            return OfferServices.CancelRide(offerId);          
        }
        [HttpGet]
        [Route("EndRide/{offerId}")]
        public bool EndRide(string offerId)
        {
            return OfferServices.EndRide(offerId);
        }
        [HttpGet]
        [Route("CloseOffer/{offerId}")]
        public bool CloseOffer(string offerId)
        {
            return OfferServices.CloseOffer(offerId);          
        }
        [HttpGet]
        [Route("StartRide/{offerId}")]
        public bool StartRide(string offerId)
        {
            return OfferServices.StartRide(offerId);          
        }
        [HttpGet]
        [Route("GetAllOffersUsingUserId/{userId}")]
        public List<Offer> GetAllOfferByUserId(string userId)
        {
            return OfferServices.GetAllOffersByUserId(userId);
        }
        [HttpGet]
        [Route("GetOffersUsingUserId/{userId}")]
        public List<Offer> GetOffersByUserId(string userId)
        {
            return OfferServices.GetOffersByUserId(userId);
        }
    }
}