using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Domain.Entities;
using OnlineShop.Service.Interfaces.Common.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace OnlineShop.Service.Services.Common.Security
{
	public class AuthManagerService : IAuthManagerService
	{
		private readonly IConfiguration _config;

		public AuthManagerService(IConfiguration config)
		{
			this._config = config.GetSection("Jwt");
		}

		public virtual string GenereteToken(User user)
		{
			var claims = new[]
			{
				new Claim("Id", user.Id.ToString()),
				new Claim("FullName", user.FullName),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Role.ToString())
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new JwtSecurityToken(_config["Issuer"], _config["Audience"], claims,
				expires: DateTime.Now.AddMinutes(double.Parse(_config["Lifetime"])),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
		}



	}
}