using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categoryList = _context.Categories.ToList();

            return View(categoryList);
        }

		public IActionResult Create() => View();

		[HttpPost]
		public IActionResult Create(Category category)
		{
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Display Order cannot match Name");
            }

            if (!ModelState.IsValid) return View();
            _context.Categories.Add(category);
            _context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
