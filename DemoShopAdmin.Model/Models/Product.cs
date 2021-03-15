using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Model.Models
{
	public class Product:BaseEntity
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public decimal Price { get; set; }
		public decimal? OldPrice { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		[MaxLength(16)]
		public string SKU { get; set; }
		public int? CategoryId { get; set; }
		[Required]
		public Category Category { get; set; }
	}
}
