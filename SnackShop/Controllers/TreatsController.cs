using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SnackShop.Models;
using System.Collections.Generic;

namespace SnackShop.Controllers
{
	public class TreatsController : Controller
	{
		private readonly SnackShopContext _db;
		public TreatsController(SnackShopContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			return View();
		}
	// create
	// create2
	// read
	// 
	// read all
	// edit
	// edit 2
	// delete
	// delete2
	// delete all
	// add flavor
	// add flavor 2
	// delete flavor
	// delete all flavors
	}
}
