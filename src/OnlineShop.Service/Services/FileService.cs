using Microsoft.AspNetCore.Http;
using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Services
{
    public class FileService : IFileService
    {
        public Task<string> SaveImageAsync(IFormFile fromFile)
        {
            throw new NotImplementedException();
        }
    }
}
