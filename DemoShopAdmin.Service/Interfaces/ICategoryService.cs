using DemoShopAdmin.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoShopAdmin.Service.Interfaces
{
	public interface ICategoryService:IBaseService<Category>
	{
		Task<IEnumerable<Category>> GetAllByStatusAsync();
	}
}
