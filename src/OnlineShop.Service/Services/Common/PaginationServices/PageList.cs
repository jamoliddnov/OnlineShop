using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Service.Services.Common.PaginationServices
{
    public class PageList<T> : List<T>
    {
        public PaginationMetaData MetaData { get; set; } = default!;

        public PageList(List<T> items, PaginationParams @params, int totalItems)
        {
            this.MetaData = new PaginationMetaData(@params.PageNumber, @params.PageSize, totalItems);
            AddRange(items);
        }

        public static async Task<PageList<T>> ToPageListAsync(IQueryable<T> source, PaginationParams @params)
        {
            int totalItems = source.Count();
            var result = await source.Skip((@params.PageNumber - 1) * @params.PageSize)
             .Take(@params.PageSize).ToListAsync();
            return new PageList<T>(result, @params, totalItems);
        }
    }
}
