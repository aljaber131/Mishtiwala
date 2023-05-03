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
    public class CategoryController : ApiController
    {
        private readonly CategoryServices _categoryService;

        public CategoryController()
        {
            _categoryService= new CategoryServices();
        }

        [HttpGet]
        [Route("api/category")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/category/add")]
        public HttpResponseMessage Add(CategoryCreateModel category) {
            if (ModelState.IsValid)
            {
                CategoryDTO categoryDTO = new CategoryDTO
                {
                    Name = category.Name,
                };
                try
                {
                    _categoryService.CreateCategory(categoryDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "Category Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
        [HttpPatch]
        [Route("api/category/update/{id}")]
        public HttpResponseMessage Patch(CategoryDTO category, int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

