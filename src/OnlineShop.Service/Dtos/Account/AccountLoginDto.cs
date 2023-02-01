using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required, MaxLength(30), MinLength(2), EmailAddress]
        public string Email { get; set; } = String.Empty;
        [Required, MinLength(6), MaxLength(10)]
        public string Password { get; set; } = String.Empty;

    }
}
