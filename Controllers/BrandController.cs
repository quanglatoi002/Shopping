﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Repository;

namespace Shopping_Tutorial.Controllers
{
    public class BrandController : Controller
    {
        private readonly DataContext _dataContext;
        public BrandController(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<IActionResult> Index(string Slug = "")
        {
            BrandModel? brand = _dataContext?.Brands.Where(c => c.Slug == Slug).FirstOrDefault();
            if (brand == null) return RedirectToAction("Index");
            // tìm sản phẩm ở trong dmuc này
            var productsByBrand = _dataContext?.Products.Where(c => c.BrandId == brand.Id);
            if(productsByBrand == null) return View("NoProductsFound");
            // sort theo id
            var sortedProducts = await productsByBrand.OrderByDescending(p => p.Id).ToListAsync();
            return View(sortedProducts);
        }
    }
}
