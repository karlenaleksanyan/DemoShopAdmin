using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoShopAdmin.Model.Models
{
	public partial class Category:BaseEntity
	{
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public int? ParentId { get; set; }
		public ICollection<Product> Products { get; set; }

	}
}
