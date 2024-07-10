using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(DataContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _context.Categories.Add(Category);
            _context.SaveChanges();
            TempData["success"] = "Category created successfully!";
            return RedirectToPage("Index");
        }
    }
}
