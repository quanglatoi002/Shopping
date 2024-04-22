using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Shopping_Tutorial.Repository.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public CategoriesViewComponent(DataContext context)
        {
            _dataContext = context;
        }

        // Task dùng để đại diện cho đối tượng IViewComponentResult có thể xử lý bdb
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _dataContext.Categories.ToListAsync();
            return View(categories);
        }

    }
}
