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
    public class SweetService
    {
        private readonly IRepository<Sweet> _sweetRepository;

        public SweetService()
        {
            _sweetRepository = DataAccessFactory.SweetData();
        }

        public void CreateSweet(SweetDTO sweet)
        {
            var sweetEntity = new Sweet
            {
                Name = sweet.Name,
                Description = sweet.Description,
                Price = sweet.Price,
                CategoryId = sweet.CategoryId,
                AreaId = sweet.AreaId
            };
            _sweetRepository.Add(sweetEntity);
        }

        public SweetDTO GetSweetById(int id)
        {
            var sweetEntity = _sweetRepository.GetById(id);
            if (sweetEntity == null)
            {
                return null;
            }

            var sweet = new SweetDTO
            {
                Name = sweetEntity.Name,
                Description = sweetEntity.Description,
                Price = sweetEntity.Price,
                CategoryId = sweetEntity.CategoryId,
                AreaId = sweetEntity.AreaId,
                Id = sweetEntity.Id
            };

            return sweet;
        }

        public List<SweetDTO> GetAllSweets()
        {
            var sweets = new List<SweetDTO>();
            foreach (var sweetEntity in _sweetRepository.GetAll())
            {
                var sweet = new SweetDTO
                {
                    Name = sweetEntity.Name,
                    Description = sweetEntity.Description,
                    Price = sweetEntity.Price,
                    CategoryId = sweetEntity.CategoryId,
                    AreaId = sweetEntity.AreaId,
                    Id = sweetEntity.Id
                };
                sweets.Add(sweet);
            }
            return sweets;
        }

        public void UpdateSweet(SweetDTO sweet, int id)
        {
            var sweetEntity = _sweetRepository.GetById(id);
            if (sweetEntity == null)
            {
                return;
            }

            sweetEntity.Name = sweet.Name;
            sweetEntity.Description = sweet.Description;
            sweetEntity.Price = sweet.Price;
            sweetEntity.CategoryId = sweet.CategoryId;
            sweetEntity.AreaId = sweet.AreaId;

            _sweetRepository.Update(sweetEntity);
        }

        public void DeleteSweet(int id)
        {
            var sweetEntity = _sweetRepository.GetById(id);
            _sweetRepository.Delete(sweetEntity);
        }
    }
}
