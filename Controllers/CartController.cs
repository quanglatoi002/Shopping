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
            // Lấy giỏ hàng từ Session
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();

            // Tạo đối tượng CartItemViewModel từ giỏ hàng
            CartItemViewModel cartVM = new ()
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

        public async Task<IActionResult> Add(int Id)
        {
            // search product in csdl
            ProductModel product = await _dataContext.Products.FindAsync(Id);

            // check product see it exsit?
            //if(product == null)
            //{
            //    return Redirect(Request.Headers["Referer"].ToString());
            //}
            //từ giỏ hàng lấy ra session
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") ?? new List<CartItemModel>();
            // tìm kiếm sản phẩm trong giỏ hàng dựa trên id sản phẩm
            CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            // add product on cart
            if(cartItems == null)
            {
                cart?.Add(new CartItemModel(product));
            }
            else
            {
                // if exsit + 1
                cartItems.Quantity += 1;
            }

            // Lưu giỏ hàng vào Session
            if (cart != null)
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            //else
            //{
            //    // Khởi tạo danh sách mới nếu cart là null
            //    cart = new List<CartItemModel>();
            //HttpContext.Session.SetJson("Cart", cart);
            //}

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
 
