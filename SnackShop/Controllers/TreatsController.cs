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
	public class TreatsController : Controller
	{
		private readonly SnackShopContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public TreatsController(UserManager<ApplicationUser> userManager, SnackShopContext db)
		{
			_userManager = userManager;
			_db = db;
		}

		[AllowAnonymous]
		[HttpGet]
		public ActionResult Index()
		{
			List<Treat> treatList = _db.Treats.ToList();
			return View(treatList);
		}
		// [HttpGet]
		// public async Task<ActionResult> Index()
		// {
			// var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			// var currentUser = await _userManager.FindByIdAsync(userId);
			// List<Treat> treatList = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
			// return View(treatList);
	// }
	
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Create(Treat treat)
		{
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			treat.User = currentUser;
			_db.Treats.Add(treat);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	
		[AllowAnonymous]
		public ActionResult Details(int id)
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
			Treat thisTreat = _db.Treats
			.FirstOrDefault(treat => treat.TreatId == id);
			return View(thisTreat);
		}

		[HttpPost]
		public async Task<ActionResult> Edit(Treat treat)
		{
			int id = treat.TreatId;
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			treat.User = currentUser;
			_db.Entry(treat).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Details", new {id = id} );
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Treat thisTreat = _db.Treats
			.FirstOrDefault(treat => treat.TreatId == id);
			return View(thisTreat);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirm(int id)
		{
			Treat thisTreat = _db.Treats
			.FirstOrDefault(treat => treat.TreatId == id);
			_db.Treats.Remove(thisTreat);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult DeleteAll()
		{
			return View();
		}
		[HttpPost, ActionName("DeleteAll")]
		public ActionResult DeleteAllConfirm()
		{
			_db.Treats.RemoveRange(_db.Treats);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	
		[HttpGet]
		public ActionResult AddFlavor(int id)
		{
			Treat thisTreat = _db.Treats
			.FirstOrDefault(treat => treat.TreatId == id);
			ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
			return View(thisTreat);
		}

		[HttpPost]
		public ActionResult AddFlavor(Treat treat, int FlavorId)
		{
			if (FlavorId !=0)
			{
				_db.TreatFlavor.Add(
					new TreatFlavor(){
						FlavorId = FlavorId, TreatId = treat.TreatId
					});
			}
			_db.SaveChanges();
			return RedirectToAction(
				"Details", new { id = treat.TreatId } );
		}

		[HttpPost]
		public ActionResult DeleteFlavor(int joinId)
		{
			TreatFlavor joinEntry = _db.TreatFlavor
			.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
			_db.TreatFlavor.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Details", new { id = joinEntry.TreatId } );
		}
	}
}
