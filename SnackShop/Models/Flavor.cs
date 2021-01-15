using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SnackShop.Models
{
	public class Flavor
	{
		public Flavor()
		{}
		public int FlavorId {get;set;}
		[DisplayName("Flavor:")]
		public string FlavorName {get;set;}
		[DisplayName("Available from")]
		public string FlavorTimeOfDay {get;set;}

		public virtual ICollection<TreatFlavor> Treats {get;set;}
	}
}
