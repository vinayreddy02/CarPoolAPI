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
    public class OfferController : ControllerBase
    {
        readonly IOfferServices OfferServices;
        public OfferController(IOfferServices services)
        {
            OfferServices = services;
        }
        [HttpGet]
        public List<Offer> GetOffers()
        {
            return OfferServices.GetAll();
        }
        [HttpPost]
        public bool PostUser(Offer offer)
        {
            if (OfferServices.AddOffer(offer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet("{id}")]
        public Offer GetOffer(string id)
        {
            return OfferServices.GetOffer(id);
        }
        [HttpDelete("{id}")]
        public bool DeleteOffer(string id)
        {
            if (OfferServices.DeleteOffer(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPut("{id}")]
        public string PutOffer(string id, Offer offer)
        {
            if (id != offer.Id)
            {
                return "Station does not exists";
            }
            else
            {
                if (OfferServices.UpdateOffer(offer))
                {
                    return "updated";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        [HttpGet]
        [Route("AllAvailableOffers/{fromLocationId}/{toLocationId}/{numberOfSeats:int}/{dateTime:DateTime}")]
        public List<Offer> AllAvailableOffers(string fromLocationId, string toLocationId, int numberOfSeats, DateTime dateTime)
        {
            return OfferServices.GetAvilableOffers(fromLocationId, toLocationId, numberOfSeats, dateTime);
        }
        [HttpGet]
        [Route("CancelRide/{offerId}")]
        public bool CancelRideUsingOfferId(string offerId)
        {
            if (OfferServices.CancelRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("EndRide/{offerId}")]
        public bool EndRide(string offerId)
        {
            if (OfferServices.EndRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("CloseOffer/{offerId}")]
        public bool CloseOffer(string offerId)
        {
            if (OfferServices.CloseOffer(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("StartRide/{offerId}")]
        public bool StartRide(string offerId)
        {
            if (OfferServices.StartRide(offerId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpGet]
        [Route("GetOffersUsingUserId/{userId}")]
        public List<Offer> GetOffersUsingUserId(string userId)
        {
            return OfferServices.GetOffers(userId);
        }
    }
}