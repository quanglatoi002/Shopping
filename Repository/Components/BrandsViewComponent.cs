using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Shopping_Tutorial.Repository.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public BrandsViewComponent(DataContext context)
        {
            _dataContext = context;
        }

        // Task dùng để xử lý bất đồng bộ
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // ToListAsync dùng để truy vấn csdl và trả về all các danh mục dưới dạng list
            var categories = await _dataContext.Brands.ToListAsync();
            return View(categories);
        }

    }
}
