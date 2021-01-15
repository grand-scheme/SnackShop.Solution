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
	
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Flavor flavor)
		{
			_db.Flavors.Add(flavor);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Read(int id)
		{
			Flavor thisFlavor = _db.Flavors
			.Include(flavor => flavor.Treats)
			.ThenInclude(join => join.Treat)
			.FirstOrDefault(Flavor => Flavor.FlavorId == id);
			return View(thisFlavor);
		}
	
	// NOTE: ADD READ ALL

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Flavor thisFlavor = _db.Flavors
			.FirstOrDefault(flavor => flavor.FlavorId == id);
			return View(thisFlavor);
		}

		[HttpPost]
		public ActionResult Edit(Flavor flavor)
		{
			_db.Entry(flavor).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");

		}
	
		[HttpGet]
		public ActionResult Delete(int id)
		{
			Flavor thisFlavor = _db.Flavors
			.FirstOrDefault(flavor => flavor.FlavorId == id);
			return View(thisFlavor);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Flavor thisFlavor = _db.Flavors
			.FirstOrDefault(flavor => flavor.FlavorId == id);
			_db.Flavors.Remove(thisFlavor);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult AddTreat(int id)
		{
			Flavor thisFlavor = _db.Flavors
			.FirstOrDefault(flavor => flavor.FlavorId == id);
			ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreadName");
			return View(thisFlavor);
		}

		[HttpPost]
		public ActionResult AddTreat(Flavor flavor, int TreatId)
		{
			if (TreatId != 0)
			{
				_db.TreatFlavor.Add(new TreatFlavor() {TreatId = TreatId, FlavorId = flavor.FlavorId});
			}
			_db.SaveChanges();
			return RedirectToAction("Read", new {id = flavor.FlavorId});
		}
	
		[HttpPost]
		public ActionResult DeleteTreat(int joinId)
		{
			TreatFlavor joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
			_db.TreatFlavor.Remove(joinEntry);
			_db.SaveChanges();

			return RedirectToAction("Read", new {id = joinEntry.FlavorId});
		}
	// NOTE: ADD DELETE ALL FLAVORS
	// NOTE: ADD DELETE ALL FLAVORS CONFIRMATION
	
	
	
	
	
	
	
	
	
	
	
	
	
	}
}
