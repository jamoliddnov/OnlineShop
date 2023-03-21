namespace OnlineShop.Service.ViewModels.Accounts
{
	public class AccountBaseViewModel
	{
		public long Id { get; set; }

		public string Name { get; set; } = String.Empty;

		public string Phone { get; set; } = String.Empty;

		public string Email { get; set; } = String.Empty;

		public string Password { get; set; } = String.Empty;
	}
}
