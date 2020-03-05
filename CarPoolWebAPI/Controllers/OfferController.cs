using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarPoolApplication.Models;
using CarPoolApplication.Services;
using CarPoolApplication.Services.Intefaces;

namespace CarPoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        IOfferServices OfferServices;
        public OfferController(IOfferServices services)
        {
            OfferServices = services;
        }
        // GET: api/Offers
        [HttpGet]
        public List<Offer> GetOffers()
        {
            return OfferServices.GetAll();
        }
        // POST: api/Offers
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
        // GET: api/Offers/5
        [HttpGet("{id}")]
        public Offer GetOffer(string id)
        {
            return OfferServices.GetOfferUsingOfferID(id);
        }
        // DELETE: api/Offers/5
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
    }
}