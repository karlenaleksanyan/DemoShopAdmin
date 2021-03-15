using DemoShopAdmin.Model.Models;
using DemoShopAdmin.Models;
using DemoShopAdmin.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShopAdmin.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		// GET: ProductController
		public async Task<ActionResult> Index(int page = 1)
		{
			int pageSize = 3;   // количество элементов на странице

			var products =await  _productService.GetAllAsync();
			foreach (var item in products)
			{
				var category = await _categoryService.GetAsync(item.CategoryId);
				item.Category.Name = category?.Name;
			}
			var count = products.Count();
			var items = products.Skip((page - 1) * pageSize).Take(pageSize);

			PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
			ProductIndexViewModel viewModel = new ProductIndexViewModel
			{
				PageViewModel = pageViewModel,
				Products = items
			};
			
			return View(viewModel);
		}

		// GET: ProductController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var products = await _productService.GetAsync(id);
			var category = await _categoryService.GetAsync(products.CategoryId);
			products.Category.Name = category?.Name;

			return View(products);
		}

		// GET: ProductController/Create
		public async Task<ActionResult> Create()
		{
			ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

			return View();
		}

		// POST: ProductController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Product collection)
		{
			try
			{
				await _productService.CreateAsync(collection);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", collection.CategoryId);

				return View(collection);
			}
		}

		// GET: ProductController/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");

			return View(await _productService.GetAsync(id));
		}

		// POST: ProductController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Product collection)
		{
			try
			{
				await _productService.UpdateAsync(collection);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", collection.CategoryId);

				return View(collection);
			}
		}

		// GET: ProductController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var products = await _productService.GetAsync(id);
			var category = await _categoryService.GetAsync(products.CategoryId);
			products.Category.Name = category?.Name;

			return View(products);
		}

		// POST: ProductController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Product collection)
		{
			try
			{
				await _productService.DeleteAsync(collection);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
