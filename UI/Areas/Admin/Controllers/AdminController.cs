using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Areas.Admin.Controllers
{
    //[Area("Admin")]
    //[Route("Admin/[controller]/[action]")]
    //[Authorize(Roles ="Admin")]
    public class AdminController : AdminBaseController
    {
        IProductService _productService;
        ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories=_categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "ürün ekledi :D");
            }
            return RedirectToAction("add");
        }
        public IActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "ürün güncellendi :D");
            }
            return RedirectToAction("update");
        }
        public IActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "ürün silindi :D");
            return RedirectToAction("Index");
        }
    }
}
