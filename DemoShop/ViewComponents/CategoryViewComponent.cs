using DemoShop.Models;
using DemoShopAdmin.Model.Models;
using DemoShopAdmin.Service.Data;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShop.ViewComponents
{
	//[ViewComponent(Name = "Category")]
	public class CategoryViewComponent : ViewComponent
	{

		private readonly ICategoryService _categoryService;

		public CategoryViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var items = await _categoryService.GetAllByStatusAsync();
			List<CategoryViewModel> hierarchy = new List<CategoryViewModel>();
			hierarchy = items.Where(c => c.ParentId == null).Select(c => new CategoryViewModel()
			{
				Id = c.Id,
				Name = c.Name,
				ParentId = c.ParentId,
				ChildCategories = GetChildren(items, c.Id)
			}).ToList();
			return View(items);
		}
		private List<CategoryViewModel> GetChildren(IEnumerable<Category> categories, int parentId)
		{
			return categories
					.Where(c => c.ParentId == parentId)
					.Select(c => new CategoryViewModel()
					{
						Id = c.Id,
						Name = c.Name,
						ParentId = c.ParentId,
						ChildCategories = GetChildren(categories, c.Id)
					})
					.ToList();
		}

		
	}
}
