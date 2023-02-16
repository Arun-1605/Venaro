using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Security.Claims;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;
using Venaro.Models.ViewModel;

namespace Venaro.Areas.Customer
{
	[Area("Customer")]
	[Authorize]
	public class CartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ShoppingCartVM ShoppingCartVM { get; set; }

		public CartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;

		}
		

		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

			ShoppingCartVM = new ShoppingCartVM()
			{
				ListItem = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId==claims.Value,includeProperties:"Product")

			};

			return View(ShoppingCartVM);
		}
	}
}
