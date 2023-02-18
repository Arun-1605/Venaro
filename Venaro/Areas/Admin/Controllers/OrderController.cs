using Microsoft.AspNetCore.Mvc;

namespace Venaro.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
