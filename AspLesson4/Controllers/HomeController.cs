using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspLesson4.Controllers
{
    public class HomeController : Controller
    {

        private readonly ProductDbContext _context;

        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return Json(_context.Categories);
        }


    }
}