using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SnackShop.Models;
using System.Linq;

namespace SnackShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly SnackShopContext _db;
		
		public HomeController(SnackShopContext db)
		{
			_db = db;
		}

		[HttpGet("/")]
		public ActionResult Index()
		{
			List<Treat> treatList = _db.Treats.ToList();
			ViewBag.Treats = treatList;
			List<Flavor> flavorList = _db.Flavors.ToList();
			ViewBag.Flavors = flavorList;
			return View();
		}

	}
}
