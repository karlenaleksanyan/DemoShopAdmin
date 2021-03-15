using DemoShopAdmin.Service.Implementations;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoShopAdmin.Service.Extention
{
	public static class ServiceExtention
	{
		public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
		{
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<IProductService, ProductService>();
			return services;
		}
	}
}
