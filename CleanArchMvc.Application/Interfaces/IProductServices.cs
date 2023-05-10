using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    internal interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> GetByIdAsync(int? id);
        Task<ProductDTO> GetProductCategory(int? id);

        Task Create(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);
    }
}
