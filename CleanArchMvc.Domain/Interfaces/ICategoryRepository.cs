using CleanArchMvc.Domain.Entities;


namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        // Task representa uma operacao assincrona
        //Busca de categorias
        Task<IEnumerable<Category>> GetCategoriesAsync(); // Lista de categorias
        Task<Category> GetByIDAsync(int? id); // Uma categoria somente

        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync(Category category);
    }
}
