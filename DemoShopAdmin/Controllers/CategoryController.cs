using DemoShopAdmin.Model.Models;
using DemoShopAdmin.Models;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShopAdmin.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		// GET: CategoryController
		public async  Task<ActionResult> Index(int page=1)
		{
			int pageSize = 3;   // количество элементов на странице

			
			var categories =await _categoryService.GetAllAsync();

			foreach (var item in categories)
			{
				var parentCategory = await _categoryService.GetAsync(item.ParentId);
				item.ParentName = parentCategory?.Name;
			}
			var count =  categories.Count();
			var items =  categories.Skip((page - 1) * pageSize).Take(pageSize);

			PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
			CategoryIndexViewModel viewModel = new CategoryIndexViewModel
			{
				PageViewModel = pageViewModel,
				Categories = items
			};
			
			return View(viewModel);
		}

		// GET: CategoryController/Details/5
		public async Task<ActionResult> Details(int id)
		{

			var category = await _categoryService.GetAsync(id);
			var parentCategory = await _categoryService.GetAsync(category.ParentId);
			category.ParentName = parentCategory?.Name;

			return View(category);
		}

		// GET: CategoryController/Create
		public async Task<ActionResult> Create()
		{
			ViewData["ParentCategories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

			return View();
		}

		// POST: CategoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Category category)
		{
			try
			{
				await _categoryService.CreateAsync(category);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewData["ParentCategories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", category.ParentId);

				return View(category);
			}
		}

		// GET: CategoryController/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			ViewData["ParentCategories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

			return View(await _categoryService.GetAsync(id));
		}

		// POST: CategoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Category category)
		{
			try
			{
				await _categoryService.UpdateAsync(category);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				
				return View(category);
			}
		}

		// GET: CategoryController/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{

			var category = await _categoryService.GetAsync(id);
			var parentCategory=await _categoryService.GetAsync(category.ParentId);
			category.ParentName = parentCategory?.Name;

			return View(category);
		}

		// POST: CategoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Category category)
		{
			try
			{
				await _categoryService.DeleteAsync(category);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
								ViewData["ParentCategories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", category.ParentId);

				return View();
			}
		}
	}
}
