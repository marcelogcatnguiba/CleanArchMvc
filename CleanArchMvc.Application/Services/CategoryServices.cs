using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categorieEntity = await _categoryRepository.GetByIDAsync(id);
            return _mapper.Map<CategoryDTO>(categorieEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoryAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task CreateAsync(CategoryDTO categoryDTO)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categorieEntity);

        }
        public async Task RemoveAsync(int? id)
        {
            var categorieEntity = _categoryRepository.GetByIDAsync(id).Result;
            await _categoryRepository.RemoveAsync(categorieEntity);
        }
        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var categorieEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categorieEntity);
        }
    }
}
