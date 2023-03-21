using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OnlineShop.Service.Common.Helpers;
using OnlineShop.Service.Interfaces;

namespace OnlineShop.Service.Services
{
	public class FileService : IFileService
	{
		private readonly string images = "images";
		private readonly string _rootpath;
		public FileService(IWebHostEnvironment webHostEnvironment)
		{
			_rootpath = webHostEnvironment.WebRootPath;
		}

		public async Task<string> SaveImageAsync(IFormFile formFile)
		{
			string imageName = ImageHelper.MakeImageName(formFile.FileName);
			try
			{
				string imagePath = System.IO.Path.Combine("wwwroot", images, imageName);
				var stream = new FileStream(imagePath, FileMode.Create);

				await formFile.CopyToAsync(stream);
				return Path.Combine(images, imageName);
			}
			catch
			{
				return "";
			}
		}
	}
}
