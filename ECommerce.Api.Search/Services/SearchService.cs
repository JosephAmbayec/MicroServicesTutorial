using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Api.Search.Interfaces;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        public async Task<(bool IsSuccess, dynamic SearchResults)> SearchAync(int customerId)
        {
            await Task.Delay(1);
            return (true, new { Message = "Hello" });
        }
    }
}
