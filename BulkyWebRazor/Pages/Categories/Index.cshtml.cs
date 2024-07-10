using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public List<Category> CategoryList { get; set; }

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CategoryList = _context.Categories.ToList();
        }
    }
}
