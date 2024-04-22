using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;

namespace Shopping_Tutorial.Controllers 
{
	public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        public CategoryController(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IActionResult> Index(string Slug = "")
        {
            if (!string.IsNullOrEmpty(Slug){ }
                CategoryModel category = _dataContext?.Categories.Where(c => c.Slug == Slug).FirstOrDefault();
            if (category == null) return RedirectToAction("Index");
            // tìm sản phẩm ở trong dmuc này
            var productsByCategory = _dataContext?.Products.Where(c => c.CategoryId == category.Id);
            // sort theo id
            var sortedProducts = await productsByCategory.OrderByDescending(p => p.Id).ToListAsync();
            return View(sortedProducts);
        }
    }
}

