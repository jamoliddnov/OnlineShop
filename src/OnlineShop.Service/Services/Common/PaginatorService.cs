using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineShop.Service.Common.Utils;
using OnlineShop.Service.Interfaces.Common;

namespace OnlineShop.Service.Services.Common
{
    public class PaginatorService : IPaginatorService
    {
        private readonly IHttpContextAccessor _accessor;
        public PaginatorService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public PaginatorService(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; }
        public int PageSize { get; }

        public async Task<IList<T>> ToPagedAsync<T>(IList<T> items, int pageNumber, int pageSize)
        {
            try
            {
                int totalItems = items.Count();
                PaginationMetaData paginationMetaData = new PaginationMetaData()
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
                    HasPrevious = pageNumber > 1
                };
                paginationMetaData.HasNext = paginationMetaData.CurrentPage < paginationMetaData.TotalPages;

                string json = JsonConvert.SerializeObject(paginationMetaData);
                _accessor.HttpContext!.Response.Headers.Add("X-Pagination", json);

                return items.Skip(pageNumber * pageSize - pageSize)
                                  .Take(pageSize).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
