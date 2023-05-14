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
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        [HttpGet]
        [Route("api/users")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { data = _userService.GetAllUsers() });
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,new {data=_userService.GetUserById(id)});
        }

        [HttpPost]
        [Route("api/users/add")]
        public HttpResponseMessage Add(UserCreateModel user)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    Address= user.Address,
                    Email= user.Email,
                    Phone= user.Phone,
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    Role= user.Role,
                    Password= user.Password,
                };
                try
                {
                    _userService.CreateUser(userDTO);
                    return Request.CreateResponse(HttpStatusCode.OK, "User Created");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
        }

        [HttpPatch]
        [Route("api/users/update/{id}")]
        public HttpResponseMessage Patch(UserDTO user,int id) 
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/users/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
