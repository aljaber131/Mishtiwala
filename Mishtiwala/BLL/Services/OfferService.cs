using BLL.DTOs;
using DAL.Models;
using DAL.Repos;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OfferService
    {
        private readonly IRepository<Offer> _offerRepository;
        public OfferService()
        {
            _offerRepository = DataAccessFactory.OfferData();
        }

        public void CreateOffer(OfferDTO offer)
        {
            _offerRepository.Add(new Offer
            {
                IsActive = offer.IsActive,
                DiscountAmount = offer.DiscountAmount,
                SweetId = offer.SweetId,
            });
        }

        public OfferDTO GetOfferById(int id)
        {
            var offerEntity = _offerRepository.GetById(id);
            if (offerEntity == null)
            {
                return null;
            }
            OfferDTO offer = new OfferDTO
            {
                IsActive = offerEntity.IsActive,
                DiscountAmount = offerEntity.DiscountAmount,
                SweetId = offerEntity.SweetId,
                Id = offerEntity.Id
            };
            return offer;
        }

        public List<OfferDTO> GetAllOffers()
        {
            var list = _offerRepository.GetAll();
            var offers = new List<OfferDTO>();
            foreach (var offer in list)
            {
                offers.Add(new OfferDTO
                {
                    IsActive = offer.IsActive,
                    DiscountAmount = offer.DiscountAmount,
                    SweetId = offer.SweetId,
                    Id = offer.Id
                });
            }
            return offers;
        }

        public void UpdateOffer(OfferDTO offer, int id)
        {
            var entity = _offerRepository.GetById(id);
            if (entity == null)
            {
                return;
            }
            entity.IsActive = offer.IsActive;
            entity.DiscountAmount = offer.DiscountAmount;
            entity.SweetId = offer.SweetId;
            _offerRepository.Update(entity);
        }

        public void DeleteOffer(int id)
        {
            var entity = _offerRepository.GetById(id);
            _offerRepository.Delete(entity);
        }
    }
}
