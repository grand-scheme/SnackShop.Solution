using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SnackShop.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SnackShop.Controllers
{
	[Authorize]
	public class FlavorsController : Controller
	{
		private readonly SnackShopContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		public FlavorsController (UserManager<ApplicationUser> userManager, SnackShopContext db)
		{
			_userManager = userManager;
			_db = db;
		}
		
		[AllowAnonymous]
		public ActionResult Index()
		{
			List<Flavor> flavorList = _db.Flavors.ToList();
			return View(flavorList);
		}
	
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Flavor flavor)
		{
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			flavor.User = currentUser;
			_db.Flavors.Add(flavor);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[AllowAnonymous]
		public ActionResult Details(int id)
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
			ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
			return View(thisFlavor);
		}

		[HttpPost]
		public ActionResult AddTreat(Flavor flavor, int TreatId)
		{
			if (TreatId != 0)
			{
				_db.TreatFlavor.Add(
					new TreatFlavor() {
						TreatId = TreatId, FlavorId = flavor.FlavorId
						});
			}
			_db.SaveChanges();
			return RedirectToAction(
				"Details", new {id = flavor.FlavorId});
		}
	
		[HttpPost]
		public ActionResult DeleteTreat(int joinId)
		{
			TreatFlavor joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
			_db.TreatFlavor.Remove(joinEntry);
			_db.SaveChanges();

			return RedirectToAction("Details", new {id = joinEntry.FlavorId});
		}
	// NOTE: ADD DELETE ALL FLAVORS
	// NOTE: ADD DELETE ALL FLAVORS CONFIRMATION
	
	
	
	
	
	
	
	
	
	
	
	
	
	}
}
