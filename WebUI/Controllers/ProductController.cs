using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task< IActionResult> AddProduct()
        {
            //var categories = _ca.GetAllCategories();
            //var categoryList = new SelectList(categories, "Id", "Name");

            // SelectList'i ViewBag veya ViewModel'e ekleyin
            // ViewBag.CategoryList = categoryList;
           ViewBag.Categories =  new SelectList(await _categoryService.GetAllAsync(), "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllAsync(), "Id", "CategoryName");

            await _productService.CreateAsync(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            var values = await _productService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, string id)
        {
            product.Id = new ObjectId(id);
            await _productService.UpdateAsync(product, product.Id.ToString());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
