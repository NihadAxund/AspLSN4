using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AspLesson4.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ProductDbContext _context;

        public CategoryListViewComponent(ProductDbContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke(string filter = "")
        {
            return View(
                new CategoryListViewModel
                {

                    Categories = (string.IsNullOrEmpty(filter)) ? _context.Categories.ToList() :
                    _context.Categories.Where(c => c.Title.ToLower().Contains(filter.ToLower())).ToList()
                });
        }
    }
}
