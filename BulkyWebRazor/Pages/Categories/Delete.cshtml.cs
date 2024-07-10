using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
    {
		private readonly DataContext _context;

		public Category Category { get; set; }

		public DeleteModel(DataContext context)
		{
			_context = context;
		}

		public void OnGet(int? id)
        {
			if (id != null && id != 0)
			{
				Category = _context.Categories.Find(id);
			}
		}

		public IActionResult OnPost()
		{
			_context.Categories.Remove(Category);
			_context.SaveChanges();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToPage("Index");
		}
	}
}
