using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductServices : IProductServices
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public ProductServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            //var productEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);

            var productsQuery = new GetProductsQuery();
            if(productsQuery == null)
            {
                throw new ApplicationException("Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        //public async Task<ProductDTO> GetByIdAsync(int? id)
        //{
        //    var productEntity = await _productRepository.GetByIdAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productEntity = await _productRepository.GetProductCategoryAsync(id);
        //    return _mapper.Map<ProductDTO>(productEntity);
        //}

        //public async Task Create(ProductDTO productDTO)
        //{
        //    var produtEntity = _mapper.Map<Product>(productDTO);
        //    await _productRepository.CreateAsync(produtEntity);
        //}
        //public async Task Remove(int? id)
        //{
        //    var productEntity = _productRepository.GetByIdAsync(id).Result;
        //    await _productRepository.RemoveAsync(productEntity);
        //}

        //public async Task Update(ProductDTO productDTO)
        //{
        //    var produtEntity = _mapper.Map<Product>(productDTO);
        //    await _productRepository.UpdateAsync(produtEntity);
        //}
    }
}
