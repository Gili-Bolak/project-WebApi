using Entities;
using Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }



        public async Task<Order> CreateNewOrder(Order order)
        {
            int order_sum = 0;

            foreach (OrderItem i in order.OrderItems)
            {
                Product product = await _productRepository.GetProductById(i.ProductId);
                order_sum += product.Price * i.Quantity;
            }
            if (order_sum != order.OrderSum)
            {
                _logger.LogError($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of {order_sum}");
                _logger.LogInformation($"user {order.UserId}  tried perchasing with a difffrent price {order.OrderSum} instead of {order_sum}");
            }
            order.OrderSum = order_sum;
            return await _orderRepository.CreateNewOrder(order);
        }

    }
}
