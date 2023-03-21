using OnlineShop.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Accounts
{
	public class AccountRegisterDto
	{
		[Required, MaxLength(30), MinLength(2)]
		public string FullName { get; set; }

		[Required, MaxLength(13), MinLength(13)]
		public string PhoneNumber { get; set; } = String.Empty;

		[Required, EmailAddress]
		public string Email { get; set; } = String.Empty;

		[Required, MinLength(6), MaxLength(15)]
		public string Password { get; set; } = String.Empty;

		public static implicit operator User(AccountRegisterDto dto)
		{
			return new User()
			{
				FullName = dto.FullName,
				PhoneNumber = dto.PhoneNumber,
				Email = dto.Email
			};
		}
	}
}
