using Microsoft.AspNetCore.Mvc;namespace SnackShop.Controllers{	public class HomeController : Controller	{		[HttpGet("/")]		public ActionResult Index()		{			return View();		}	}}
