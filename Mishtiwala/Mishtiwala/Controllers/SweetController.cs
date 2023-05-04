using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mishtiwala.Models;

namespace Mishtiwala.Controllers
{
    public class SweetController : ApiController
    {
        private readonly SweetService _sweetService;

        public SweetController()
        {
            _sweetService = new SweetService();
        }

        [HttpGet]
        [Route("api/sweet")]
        public HttpResponseMessage Get()
        {
            var sweetList = _sweetService.GetAllSweets();
            return Request.CreateResponse(HttpStatusCode.OK, sweetList);
        }

        [HttpGet]
        [Route("api/sweet/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var sweet = _sweetService.GetSweetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, sweet);
        }

        [HttpPost]
        [Route("api/sweet/add")]
        public HttpResponseMessage Add(SweetCreateModel sweet)
        {
            if (ModelState.IsValid)
            {
                SweetDTO sweetDTO = new SweetDTO
                {
                    Name = sweet.Name,
                    Description = sweet.Description,
                    Price = sweet.Price,
                    CategoryId = sweet.CategoryId,
                    AreaId = sweet.AreaId
                };
                try
                {
                    _sweetService.CreateSweet(sweetDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "Sweet Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPatch]
        [Route("api/sweet/update/{id}")]
        public HttpResponseMessage Patch(SweetDTO sweet, int id)
        {
            _sweetService.UpdateSweet(sweet, id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/sweet/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _sweetService.DeleteSweet(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
