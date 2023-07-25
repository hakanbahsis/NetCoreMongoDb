using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryService.CreateAsync(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task< IActionResult> UpdateCategory(string id)
        {
            
            var values=  await _categoryService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category,string id)
        {
            category.Id = new ObjectId(id);
            await _categoryService.UpdateAsync(category,category.Id.ToString());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
