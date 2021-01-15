using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SnackShop.Models
{
	public class Treat
	{
		public Treat()
		{}
		public int TreatId {get; set;}
		[DisplayName("Item:")]
		public string TreatName  {get; set;}
		[DisplayName("Calories:")]
		public int TreatCalories {get; set;}
		[DisplayName("In Stock:")]
		public bool TreatInStock {get; set;}
		[DisplayName("Price:")]
		public double TreatPrice  {get; set;}

		public virtual ICollection<TreatFlavor> Flavors {get;set;}
	}
}
