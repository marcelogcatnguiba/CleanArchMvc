using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
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
            var productsQuery = new GetProductsQuery();
            if (productsQuery == null)
            {
                throw new ApplicationException("Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }
        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
            {
                throw new Exception("Entity could not be loaded");
            }

            var result = await _mediator.Send(productByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception("Entity could not be loaded");
        //    }

        //    var result = await _mediator.Send(productByIdQuery);
        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task Create(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);

            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if (productRemoveCommand == null)
            {
                throw new Exception("Entity could not be loaded");
            }
            await _mediator.Send(productRemoveCommand);
        }
    }
}
