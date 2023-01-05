using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.Service.Common.Helpers;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineShop.Service.Services
{
    public class FileService : IFileService
    {
        private readonly string images = "images";
        private readonly string _rootpath;
        public FileService(IWebHostEnvironment webHostEnviroment)
        {
            _rootpath = webHostEnviroment.WebRootPath;
        }
        public async Task<string> SaveImageAsync(IFormFile fromFile)
        {


            string imageName = ImageHelper.MakeImageName(fromFile.FileName);

            string imagePath = Path.Combine(_rootpath, images, imageName);
            var stream = new FileStream(imagePath, FileMode.Create);
            try
            {
                await fromFile.CopyToAsync(stream);
                return Path.Combine(_rootpath, imageName);
            }
            catch
            {
                return "";
            }
        }
    }
}
