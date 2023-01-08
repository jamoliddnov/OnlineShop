using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required, MaxLength(30), MinLength(2), EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MaxLength(8)]
        public string Password { get; set; } = String.Empty;

    }
}
