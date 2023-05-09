using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using Mishtiwala.Models;

namespace Mishtiwala.Controllers
{
    public class OfferController : ApiController
    {
        private readonly OfferService _offerService;

        public OfferController()
        {
            _offerService = new OfferService();
        }

        [HttpGet]
        [Route("api/offer")]
        public HttpResponseMessage Get()
        {
            var offerList = _offerService.GetAllOffers();
            return Request.CreateResponse(HttpStatusCode.OK, offerList);
        }

        [HttpGet]
        [Route("api/offer/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var offer = _offerService.GetOfferById(id);
            return Request.CreateResponse(HttpStatusCode.OK, offer);
        }

        [HttpPost]
        [Route("api/offer/add")]
        public HttpResponseMessage Add(OfferCreateModel offer)
        {
            if (ModelState.IsValid)
            {
                OfferDTO offerDTO = new OfferDTO
                {
                    IsActive = offer.IsActive,
                    DiscountAmount = offer.DiscountAmount,
                    SweetId = offer.SweetId
                };
                try
                {
                    _offerService.CreateOffer(offerDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "Offer Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPatch]
        [Route("api/offer/update/{id}")]
        public HttpResponseMessage Patch(OfferDTO offer, int id)
        {
            _offerService.UpdateOffer(offer, id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/offer/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _offerService.DeleteOffer(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}