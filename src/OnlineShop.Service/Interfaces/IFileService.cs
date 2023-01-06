using Microsoft.AspNetCore.Http;

namespace OnlineShop.Service.Interfaces
{
    public interface IFileService
    {
        public Task<string> SaveImageAsync(IFormFile fromFile);
    }
}
