using System;
using Microsoft.AspNetCore.Mvc;
using Shopping_Tutorial.Models;
using Shopping_Tutorial.Models.ViewModels;
using Shopping_Tutorial.Repository;

namespace Shopping_Tutorial.Controllers
{
	public class CartController : Controller
    {
        private readonly DataContext _dataContext;

        public CartController(DataContext context)
		{
			_dataContext = context;
		}

		public IActionResult Index()
        {
			// HttpContext.Session để quản lý session của user
			// kấy từ khóa key được chỉ định GetJson<List<CartItemModel>>("Cart")
			List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }

        public IActionResult Checkout()
        {
            return View("~/Views/Checkout/Index.cshtml");
        }
    }
}
 
