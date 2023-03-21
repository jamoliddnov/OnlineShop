using Microsoft.AspNetCore.Mvc;
using OnlineShop.Service.Interfaces.Common;
using OnlineShop.Service.ViewModels.Accounts;

namespace OnlineShop.MVC.ViewComponents
{
	public class IdentityViewComponent : ViewComponent
	{
		private readonly IIdentityService _identityService;
		public IdentityViewComponent(IIdentityService identity)
		{
			this._identityService = identity;
		}
		public IViewComponentResult Invoke()
		{
			AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
			{
				Id = _identityService.Id!.Value
			};
			return View(accountBaseViewModel);
		}
	}
}
