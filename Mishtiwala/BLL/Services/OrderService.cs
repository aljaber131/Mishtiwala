using BLL.DTOs;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Services
{
    
        public class OrderService
        {
            private readonly IRepository<Order> _orderRepository;

            public OrderService()
            {
                _orderRepository = DataAccessFactory.OrderData();
            }

            public OrderDTO GetOrderById(int id)
            {
                Order order = _orderRepository.GetById(id);
                return MapToOrderDTO(order);
            }

            public IEnumerable<OrderDTO> GetAllOrders()
            {
                IEnumerable<Order> orders = _orderRepository.GetAll();
                return orders.Select(order => MapToOrderDTO(order));
            }

            public void AddOrder(OrderDTO orderDTO)
            {
                Order order = MapToOrderEntity(orderDTO);
                _orderRepository.Add(order);
            }

            public void UpdateOrder(OrderDTO orderDTO)
            {
                Order order = MapToOrderEntity(orderDTO);
                _orderRepository.Update(order);
            }

            public void DeleteOrder(int id)
            {
                Order order = _orderRepository.GetById(id);
                _orderRepository.Delete(order);
            }

            private OrderDTO MapToOrderDTO(Order order)
            {
                // Map Order entity to OrderDTO
                // You can use a mapping library like AutoMapper or manually map the properties
                // Example:
                return new OrderDTO
                {
                    Id = order.Id,
                    User = MapToUserDTO(order.User),
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(item => MapToOrderItemDTO(item)).ToList()
                };
            }

            private UserDTO MapToUserDTO(User user)
            {
                // Map User entity to UserDTO
                // Example:
                return new UserDTO
                {
                    // Map user properties
                };
            }

            private OrderItemDTO MapToOrderItemDTO(OrderItem item)
            {
                // Map OrderItem entity to OrderItemDTO
                // Example:
                return new OrderItemDTO
                {
                    Id = item.Id,
                    Sweet = MapToSweetDTO(item.Sweet),
                    Quantity = item.Quantity
                };
            }

            private SweetDTO MapToSweetDTO(Sweet sweet)
            {
                // Map Sweet entity to SweetDTO
                // Example:
                return new SweetDTO
                {
                    // Map sweet properties
                };
            }

            private Order MapToOrderEntity(OrderDTO orderDTO)
            {
                // Map OrderDTO to Order entity
                // Example:
                return new Order
                {
                    Id = orderDTO.Id,
                    User = MapToUserEntity(orderDTO.User),
                    OrderDate = orderDTO.OrderDate,
                    OrderItems = orderDTO.OrderItems.Select(item => MapToOrderItemEntity(item)).ToList()
                };
            }

            private User MapToUserEntity(UserDTO userDTO)
            {
                // Map UserDTO to User entity
                // Example:
                return new User
                {
                    // Map userDTO properties
                };
            }

            private OrderItem MapToOrderItemEntity(OrderItemDTO itemDTO)
            {
                // Map OrderItemDTO to OrderItem entity
                // Example:
                return new OrderItem
                {
                    Id = itemDTO.Id,
                    Sweet = MapToSweetEntity(itemDTO.Sweet),
                    Quantity = itemDTO.Quantity
                };
            }

            private Sweet MapToSweetEntity(SweetDTO sweetDTO)
            {
                // Map SweetDTO to Sweet entity
                // Example:
                return new Sweet
                {
                    // Map sweetDTO properties
                };
            }
        }
    }

