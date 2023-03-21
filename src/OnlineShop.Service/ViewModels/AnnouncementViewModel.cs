namespace OnlineShop.Service.ViewModels
{
	public class AnnouncementViewModel
	{
		public long Id { get; set; }
		public string UserName { get; set; } = String.Empty;
		public string Title { get; set; } = String.Empty;
		public string ImagePath { get; set; } = String.Empty;
		public string Description { get; set; } = String.Empty;
		public double Price { get; set; }
		public string PhoneNumber { get; set; } = String.Empty;
		public string CreateAt { get; set; } = String.Empty;
	}
}
