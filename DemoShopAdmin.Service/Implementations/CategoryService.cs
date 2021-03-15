using DemoShopAdmin.Model.Models;
using DemoShopAdmin.Service.Data;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Service.Implementations
{
	internal class CategoryService:BaseService<Category>, ICategoryService
	{
		public CategoryService(DemoShopAdminContext context):base(context)
		{

		}

		public async Task<IEnumerable<Category>> GetAllByStatusAsync()
		{
			return await _context.Category.Where(x => x.Status == true).ToListAsync();
		}
	}
}
