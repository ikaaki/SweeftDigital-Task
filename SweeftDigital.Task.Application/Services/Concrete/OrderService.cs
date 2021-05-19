using Microsoft.EntityFrameworkCore;
using SweeftDigital.Task.Application.Services.Abstract;
using SweeftDigital.Task.Application.Services.DataModels;
using SweeftDigital.Task.Domain.Entities;
using SweeftDigital.Task.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftDigital.Task.Application.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAgentRepository _agentRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IAgentRepository agentRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _agentRepository = agentRepository;
        }

        public async Task<int> AddOrderAsync(OrderDTO orderDTO)
        {
            if(await _agentRepository.Query().AnyAsync(a => a.Id == orderDTO.AgentId && a.DateDeleted.HasValue))
            {
                throw new Exception("Agent not found");
            }

            var productIds = orderDTO.OrderLines.Select(ol => ol.ProductId).ToList();

            var products = await _productRepository.Query().Where(p => productIds.Contains(p.Id)).ToDictionaryAsync(key => key.Id, value => value);

            if (products.Count != orderDTO.OrderLines.Count)
            {
                throw new Exception("Products not found");
            }

            var order = new Order
            {
                AgentId = orderDTO.AgentId,
                OrderLines = orderDTO.OrderLines.Select(ol => new OrderLine 
                { 
                    Price = products[ol.ProductId].Price,
                    Quantity = ol.Quantity, 
                    ProductId = ol.ProductId
                }).ToList()
            };

            order.ApplayTotalPrice();

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return order.Id;
        }

        public async System.Threading.Tasks.Task ApproveOrderAsync(int orderId)
        {
            var order = await _orderRepository.FindByIdAsync(orderId);

            if (order == null)
            {
                throw new Exception($"Order not found: Id:{orderId}");
            }

            if (order.IsApproved)
            {
                throw new Exception($"Order is already approved: Id:{orderId}");
            }

            order.IsApproved = true;

            foreach (var orderLine in order.OrderLines)
            {
                await _productRepository.DecreaseStockAsync(orderLine.ProductId, orderLine.Quantity);
            }

            await _orderRepository.SaveChangesAsync();
        }
    }
}
