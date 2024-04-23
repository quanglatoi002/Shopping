using System;
using Microsoft.AspNetCore.Mvc;
using Shopping_Tutorial.Repository;

namespace Shopping_Tutorial.Controllers
{
	public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        public ProductController (DataContext context)
        {
            _dataContext = context;
        }
		public IActionResult Details(int Id)
		{
			if (Id < 0) return RedirectToAction("Index");
			var productsById = _dataContext?.Products.Where(c => c.Id == Id).FirstOrDefault();
			if (productsById == null) return RedirectToAction("Index");
			return View(productsById);
		}
	}
        
}

