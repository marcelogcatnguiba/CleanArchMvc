using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers.Categories
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.GetCategoriesAsync();
            return View(categories);
        }


    }
}
