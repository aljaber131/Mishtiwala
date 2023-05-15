using BLL.DTOs;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderItemService
    {
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderItemService(IRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public OrderItemDTO GetOrderItemById(int id)
        {
            OrderItem orderItem = _orderItemRepository.GetById(id);
            return MapToOrderItemDTO(orderItem);
        }

        public IEnumerable<OrderItemDTO> GetAllOrderItems()
        {
            IEnumerable<OrderItem> orderItems = _orderItemRepository.GetAll();
            return orderItems.Select(item => MapToOrderItemDTO(item));
        }

        public void AddOrderItem(OrderItemDTO orderItemDTO)
        {
            OrderItem orderItem = MapToOrderItemEntity(orderItemDTO);
            _orderItemRepository.Add(orderItem);
        }

        public void UpdateOrderItem(OrderItemDTO orderItemDTO)
        {
            OrderItem orderItem = MapToOrderItemEntity(orderItemDTO);
            _orderItemRepository.Update(orderItem);
        }

        public void DeleteOrderItem(int id)
        {
            OrderItem orderItem = _orderItemRepository.GetById(id);
            _orderItemRepository.Delete(orderItem);
        }

        private OrderItemDTO MapToOrderItemDTO(OrderItem orderItem)
        {
            // Map OrderItem entity to OrderItemDTO
            // You can use a mapping library like AutoMapper or manually map the properties
            // Example:
            return new OrderItemDTO
            {
                Id = orderItem.Id,
                Sweet = MapToSweetDTO(orderItem.Sweet),
                Quantity = orderItem.Quantity
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

        private OrderItem MapToOrderItemEntity(OrderItemDTO orderItemDTO)
        {
            // Map OrderItemDTO to OrderItem entity
            // Example:
            return new OrderItem
            {
                Id = orderItemDTO.Id,
                Sweet = MapToSweetEntity(orderItemDTO.Sweet),
                Quantity = orderItemDTO.Quantity
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
