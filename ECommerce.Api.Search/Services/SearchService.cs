using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.Orders.Interfaces;
using ECommerce.Api.Search.Interfaces;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrdersService _orderService;
        public SearchService(IOrdersService ordersService)
        {
            _orderService = ordersService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAync(int customerId)
        {
            var ordersResult = await _orderService.GetOrdersAsync(customerId);
            if (ordersResult.isSuccess)
            {
                var result = new
                {
                    Orders = ordersResult.Orders
                };
                return (true, result);
            }
            return (false, null);
        }
    }
}
