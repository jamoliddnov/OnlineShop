using OnlineShop.Domain.Entities.Users;
using OnlineShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
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
