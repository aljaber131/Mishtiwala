using BLL.DTOs;
using BLL.Services;
using Mishtiwala.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mishtiwala.Controllers
{
    public class AreaController : ApiController
    {
        private readonly AreaService _areaService;

        public AreaController()
        {
            _areaService = new AreaService();
        }

        [HttpGet]
        [Route("api/area")]
        public HttpResponseMessage Get()
        {
            var areaList = _areaService.GetAllAreas();
            return Request.CreateResponse(HttpStatusCode.OK, areaList);
        }

        [HttpGet]
        [Route("api/area/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var area = _areaService.GetAreaById(id);
            return Request.CreateResponse(HttpStatusCode.OK, area);
        }

        [HttpPost]
        [Route("api/area/add")]
        public HttpResponseMessage Add(AreaCreateModel area)
        {
            if (ModelState.IsValid)
            {
                AreaDTO areaDTO = new AreaDTO
                {
                    Name = area.Name,
                };
                try
                {
                    _areaService.CreateArea(areaDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "Area Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [HttpPatch]
        [Route("api/area/update/{id}")]
        public HttpResponseMessage Patch(AreaDTO area, int id)
        {
            _areaService.UpdateArea(area, id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/area/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _areaService.DeleteArea(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
