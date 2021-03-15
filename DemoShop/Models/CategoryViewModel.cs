using DemoShopAdmin.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShop.Models
{
	public class CategoryViewModel
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public string Name { get; set; }
		public ICollection<CategoryViewModel> ChildCategories { get; set; }
	}
}
