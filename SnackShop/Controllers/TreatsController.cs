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
	
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Treat treat)
		{
			_db.Treats.Add(treat);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	
		public ActionResult Read(int id)
		{
			Treat thisTreat = _db.Treats
			.Include(treat => treat.Flavors)
			.ThenInclude(join => join.Flavor)
			.FirstOrDefault(Treat => Treat.TreatId == id);
			return View(thisTreat);
		}
	
		// NOTE: ADD READ ALL
		
		[HttpGet]
		public ActionResult Edit(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
			return View(thisTreat);
		}

		[HttpPost]
		public ActionResult Edit(Treat treat)
		{
			_db.Entry(treat).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
			return View(thisTreat);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
			_db.Treats.Remove(thisTreat);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		// NOTE: ADD DELETE ALL
		// NOTE: ADD DELETE ALL (CONFIRMATION)
	
		[HttpGet]
		public ActionResult AddFlavor(int id)
		{
			Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
			ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
			return View(thisTreat);
		}

		[HttpPost]
		public ActionResult AddFlavor(Treat treat, int FlavorId)
		{
			if (FlavorId !=0)
			{
				_db.TreatFlavor.Add(new TreatFlavor() {FlavorId = FlavorId, TreatId = treat.TreatId});
			}
			_db.SaveChanges();
			return RedirectToAction("Read", new {id = treat.TreatId});
		}

		[HttpPost]
		public ActionResult DeleteFlavor(int joinId)
		{
			TreatFlavor joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
			_db.TreatFlavor.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Read", new { id = joinEntry.TreatId});
		}
	
		// NOTE: ADD DELETE ALL FLAVORS
	}
}
