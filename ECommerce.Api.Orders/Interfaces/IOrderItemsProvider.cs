using ECommerce.Api.Orders.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Interfaces
{
    public interface IOrderItemsProvider
    {
        Task<(bool IsSuccess, IEnumerable<OrderItem> OrderItems, string ErrorMessage)> GetOrderItemAsync();
        Task<(bool IsSuccess, OrderItem OrderItem, string ErrorMessage)> GetOrderItemAsync(int id);
    }
}
