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
	internal class ProductService:BaseService<Product>, IProductService
	{
		public ProductService(DemoShopAdminContext context):base(context)
		{

		}

		public override async Task<Product> GetAsync(int? id)
		{
			return await _context.Product.Include(x=>x.Category).FirstOrDefaultAsync(a=> a.Id==id);
		}
		public override async Task<IEnumerable<Product>> GetAllAsync()
		{
			return await _context.Product.Include(x=> x.Category).ToListAsync();
		}
	}
}
