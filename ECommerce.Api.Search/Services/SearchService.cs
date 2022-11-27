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
        private readonly IProductsService _productsService;

        public SearchService(IOrdersService ordersService, IProductsService productsService)
        {
            _orderService = ordersService;
            _productsService = productsService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAync(int customerId)
        {
            var ordersResult = await _orderService.GetOrdersAsync(customerId);
            var productsResult = await _productsService.GetProductsAsync();

            if (ordersResult.isSuccess)
            {
                foreach (var order in ordersResult.Orders)
                {
                    foreach (var item in order.Items)
                    {
                        item.ProductName = productsResult.Products.FirstOrDefault(p => p.Id == item.ProductId).Name;
                    }
                }
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
