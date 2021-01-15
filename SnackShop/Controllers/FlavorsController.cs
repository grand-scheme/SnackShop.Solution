using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SnackShop.Models;
using System.Collections.Generic;

namespace SnackShop.Controllers
{
	public class FlavorsController : Controller
	{
		private readonly SnackShopContext _db;
		public FlavorsController (SnackShopContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			return View();
		}
	
	// NOTE: ADD CREATE
	// NOTE: ADD CREATE POST
	// NOTE: ADD READ
	// NOTE: ADD READ ALL
	// NOTE: ADD EDIT
	// NOTE: ADD EDIT POST
	// NOTE: ADD DELETE
	// NOTE: ADD DELETE CONFIRMATION
	// NOTE: ADD ADD FLAVOR
	// NOTE: ADD ADD FLAVOR POST
	// NOTE: ADD DELETE FLAVOR
	// NOTE: ADD DELETE ALL FLAVORS
	// NOTE: ADD DELETE ALL FLAVORS CONFIRMATION
	
	
	
	
	
	
	
	
	
	
	
	
	
	}
}
