using System.ComponentModel.DataAnnotations;
namespace DemoShopAdmin.Model.Models
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public bool Status { get; set; }
	}
}
