using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Announcement
{
	public class CreateAnnouncementDto
	{
		[Required]
		public string Title { get; set; } = String.Empty;
		[Required]
		public string Categorie { get; set; }
		[Required]
		public IFormFile Image { get; set; }
		[Required]
		public string Description { get; set; } = String.Empty;
		[Required]
		public double Price { get; set; }
		[Required, MaxLength(9), MinLength(9)]
		public string PhoneNumber { get; set; } = String.Empty;

		public static implicit operator Domain.Entities.Announcement(CreateAnnouncementDto createAnnouncement)
		{
			return new Domain.Entities.Announcement()
			{
				Title = createAnnouncement.Title,
				CategoryId = long.Parse(createAnnouncement.Categorie),
				Description = createAnnouncement.Description,
				PhoneNumber = createAnnouncement.PhoneNumber,
				Price = createAnnouncement.Price
			};
		}
	}
}


