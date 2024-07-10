using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
	[BindProperties]
	public class EditModel : PageModel
    {
		private readonly DataContext _context;

		public Category Category { get; set; }

		public EditModel(DataContext context)
		{
			_context = context;
		}

		public void OnGet(int? id)
        {
			if(id != null && id != 0)
			{
				Category = _context.Categories.Find(id);
			}
        }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid) return Page();
			_context.Categories.Update(Category);
			_context.SaveChanges();
            TempData["success"] = "Category updated successfully!";
            return RedirectToPage("Index");
		}
    }
}
