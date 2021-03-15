using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Model.Models
{
	public partial class Category
	{
		[NotMapped]
		[Display(Name="Parent Name")]
		public string ParentName { get; set; }
	}
}
