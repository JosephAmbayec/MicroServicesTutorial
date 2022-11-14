using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrderItemsProvider : IOrderItemsProvider
    {
        private readonly OrdersDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public OrderItemsProvider(OrdersDbContext dbContext, ILogger<OrderItemsProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;

            SeedData();
        }


        private void SeedData()
        {
            if (!_dbContext.OrderItems.Any())
            {
                _dbContext.OrderItems.Add(new Db.OrderItem() { Id = 1, OrderId = 1, ProductId = 1, Quanitity = 5, UnitPrice = 100 });
                _dbContext.SaveChanges();
            }
        }
        public Task<(bool IsSuccess, IEnumerable<OrderItem> OrderItems, string ErrorMessage)> GetOrderItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, OrderItem OrderItem, string ErrorMessage)> GetOrderItemAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
