using CleanArchMvc.Application.DTOs;
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

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO =  await _categoryServices.GetByIdAsync(id);

            if(categoryDTO == null) return NotFound();

            return View(categoryDTO); 
        }

        [HttpPost()]

        public async Task<IActionResult> Edit(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryServices.UpdateAsync(categoryDTO);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(categoryDTO);
        }

        [HttpGet()]

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null) return NotFound();

            var categoryDto = await _categoryServices.GetByIdAsync(id);

            if (categoryDto == null) return NotFound();

            return View(categoryDto);
        }

        [HttpPost(), ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoryServices.RemoveAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoryDTO = await _categoryServices.GetByIdAsync(id);

            if (categoryDTO == null) return NotFound();

            return View(categoryDTO);
        }
    }
}
