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
    public class AreaService
    {
        private readonly IRepository<Area> _areaRepository;
        public AreaService()
        {
            _areaRepository = DataAccessFactory.AreaData();
        }

        public void CreateArea(AreaDTO areaDTO)
        {
            _areaRepository.Add(new Area
            {
                Name = areaDTO.Name,
            });
        }

        public AreaDTO GetAreaById(int id)
        {
            var areaEntity = _areaRepository.GetById(id);
            if (areaEntity == null)
            {
                return null;
            }
            AreaDTO area = new AreaDTO
            {
                Name = areaEntity.Name,
                Id = areaEntity.Id
            };
            return area;
        }

        public List<AreaDTO> GetAllAreas()
        {
            var list = _areaRepository.GetAll();
            var areas = new List<AreaDTO>();
            foreach (var area in list)
            {
                areas.Add(new AreaDTO
                {
                    Name = area.Name,
                    Id = area.Id
                });
            }
            return areas;
        }

        public void UpdateArea(AreaDTO area, int id)
        {
            var entity = _areaRepository.GetById(id);
            if (entity == null)
            {
                return;
            }
            entity.Name = area.Name;
            entity.Id = area.Id;
            _areaRepository.Update(entity);
        }

        public void DeleteArea(int id)
        {
            var entity = _areaRepository.GetById(id);
            _areaRepository.Delete(entity);
        }
    }
}
