using AspLesson4.Entities;
using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspLesson4.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;
        private IndexModel() { }
        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }
        public string Message { get; set; }
        public string Info { get; set; }
        
        public List<Entities.Product> Products { get; set; }

        public static int Id_P = -1;
        public void OnGet(string info = "", string value = "none", int OD = -1)
        {
        
            Products = _context.Products.ToList();
            Message = $"Today is {DateTime.Now.DayOfWeek}";
            DisplayM = value;
            if (OD != -1)
            {
                var data2 = _context.Products.FirstOrDefault(r => r.Id == OD);
                Id_P = OD;
                Product = data2;
            }
            else
            {
                Product = new Entities.Product();
            }
            Info = info;
        }

        [BindProperty]
        public Entities.Product Product { get; set; }
        [BindProperty]
        public string DisplayM { get; set; } = "flex";
        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} added successfully";
            return RedirectToPage("Index",new { info=Info});
        }

        public IActionResult OnPostEditProdcut(int id)
        {

            return RedirectToPage("Index", new { info = Info,value = DisplayM,OD=id});
        }

        public IActionResult OnPostEdit_Product()
        {
         
            var product2 = _context.Products.FirstOrDefault(p => p.Id == Id_P);
            product2.Changing(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} Edit successfully";

            return RedirectToPage("Index", new { info = Info });
        }

        public IActionResult OnPostMyButton(int id)
        {
            if (id != null)
            {
                var recordToDelete = _context.Products.FirstOrDefault(r => r.Id == id);
                if (recordToDelete != null)
                {
                    _context.Products.Remove(recordToDelete);
                    _context.SaveChanges();
                }
                else
                {
                    return BadRequest("Not ID");
                }
                Info = $"{Product.Name} Deleted successfully";
            }
            return RedirectToPage("Index", new { info = Info });

        }

    }
}
