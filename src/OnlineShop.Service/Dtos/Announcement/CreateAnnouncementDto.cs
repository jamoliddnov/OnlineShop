using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Announcement
{
    public class CreateAnnouncementDto
    {
        [Required]
        public string Title { get; set; } = String.Empty;
        [Required]
        public string Categorie { get; set; } = null!;
        [Required]
        public string ImagePath { get; set; } = String.Empty;
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        public string PhoneNumber { get; set; } = String.Empty;

        public static implicit operator OnlineShop.Domain.Entities.Announcements.Announcement(CreateAnnouncementDto createAnnouncement)
        {
            return new OnlineShop.Domain.Entities.Announcements.Announcement()
            {
                Title = createAnnouncement.Title,
                ImagePath = createAnnouncement.ImagePath,
                Description = createAnnouncement.Description,
                PhoneNumber = createAnnouncement.PhoneNumber,
            };
        }
    }
}


