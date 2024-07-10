using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
			TempData["success"] = "Category created successfully!";
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0) return NotFound();
            Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
            if (category == null) return NotFound();
            return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			if (category.Name == category.DisplayOrder.ToString())
			{
				ModelState.AddModelError("Name", "Display Order cannot match Name");
			}

			if (!ModelState.IsValid) return View();
			_context.Categories.Update(category);
			_context.SaveChanges();
			TempData["success"] = "Category updated successfully!";
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0) return NotFound();
			Category category = _context.Categories.FirstOrDefault(category => category.Id == id);
			if (category == null) return NotFound();
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePost(Category category)
		{
			_context.Categories.Remove(category);
			_context.SaveChanges();
			TempData["success"] = "Category deleted successfully!";
			return RedirectToAction("Index");
		}
	}
}
