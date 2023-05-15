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
    public class OrderController : ApiController
    {
        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [HttpGet]
        [Route("api/order/{id}")]
        public IHttpActionResult GetOrderById(int id)
        {
            OrderDTO order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        [Route("api/order")]
        public IHttpActionResult GetAllOrders()
        {
            IEnumerable<OrderDTO> orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpPost]
        [Route("api/order")]
        public IHttpActionResult PlaceOrder(OrderCreateModel orderModel)
        {
            if (ModelState.IsValid)
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    User = MapToUserDTO(orderModel.User), // Assuming you have a mapping method
                    OrderDate = DateTime.Now,
                    OrderItems = MapToOrderItemDTOs(orderModel.OrderItems) // Assuming you have a mapping method
                };

                _orderService.AddOrder(orderDTO);
                return Ok("Order placed successfully.");
            }
            return BadRequest(ModelState);
        }

        [HttpPatch]
        [Route("api/order/{id}")]
        public IHttpActionResult UpdateOrder(OrderUpdateModel orderModel, int id)
        {
            if (ModelState.IsValid)
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    Id = id,
                    User = MapToUserDTO(orderModel.User), // Assuming you have a mapping method
                    OrderDate = orderModel.OrderDate,
                    OrderItems = MapToOrderItemDTOs(orderModel.OrderItems) // Assuming you have a mapping method
                };

                _orderService.UpdateOrder(orderDTO);
                return Ok("Order updated successfully.");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("api/order/{id}")]
        public IHttpActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return Ok("Order deleted successfully.");
        }

        private UserDTO MapToUserDTO(UserModel user)
        {
            // Map UserModel to UserDTO
            // Example:
            return new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Address = user.Address,
                Phone = user.Phone,
                Role = user.Role
            };
        }

        private List<OrderItemDTO> MapToOrderItemDTOs(List<OrderItemModel> orderItems)
        {
            // Map list of OrderItemModel to a list of OrderItemDTO
            // Example:
            return orderItems.Select(item => new OrderItemDTO
            {
                SweetId = item.SweetId,

                Quantity = item.Quantity
            }).ToList();
        }

        private SweetDTO MapToSweetDTO(SweetModel sweet)
        {
            // Map SweetModel to SweetDTO
            // Example:
            return new SweetDTO
            {
                Id = sweet.Id,
                Name = sweet.Name,
                Description = sweet.Description,
                Price = sweet.Price,
                CategoryId = sweet.CategoryId,
                AreaId = sweet.AreaId
            };
        }
    }
}
