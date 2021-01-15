using System.Collections.Generic; // if lists

namespace SnackShop.Models
{
	public class Treat
	{
		public int TreatId {get; set;}
		public string TreatName  {get; set;}
		public int TreatCalories {get; set;}
		public bool TreatInStock {get; set;}
		public double TreatPrice  {get; set;}
	}
}
