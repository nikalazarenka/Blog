using Blog.Data.Interfaces;
using Blog.Data.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategories _categoryRepository;
        public CategoryController(ICategories categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            IQueryable<Category> _categories = (IQueryable<Category>)_categoryRepository.Categories;
            var categories = new CategoriesViewModel
            {
                Categories = _categories
            };

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            _categoryRepository.Create(name);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Category _category = _categoryRepository.getObjectCategory(id);
                if (_category != null)
                {
                    var category = new CategoryViewModel
                    {
                        Name = _category.Name
                    };

                    return View(category);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _categoryRepository.Delete(id);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Category _category = _categoryRepository.getObjectCategory(id);
                if (_category != null)
                {
                    var category = new CategoryViewModel
                    {
                        Name = _category.Name
                    };

                    return View(category);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _categoryRepository.Edit(category);
            return RedirectToAction("Index", "Category");
        }
    }
}
