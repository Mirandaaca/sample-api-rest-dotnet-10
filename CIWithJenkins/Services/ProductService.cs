using CIWithJenkins.DTOs.Products;
using CIWithJenkins.Entities;
using CIWithJenkins.Exceptions;
using CIWithJenkins.Interfaces.Repository;
using CIWithJenkins.Interfaces.Services;
using FluentValidation;

namespace CIWithJenkins.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductDTO> _productValidator;
        public ProductService(IProductRepository productRepository, IValidator<ProductDTO> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }
        public async Task Create(ProductDTO productDTO)
        {
            await _productValidator.ValidateAndThrowAsync(productDTO);
            Product product = new Product
            {
                Name = productDTO.Name,
                Quantity = productDTO.Quantity,
                Price = productDTO.Price,
                Brand = productDTO.Brand
            };
            await _productRepository.Create(product);
        }

        public async Task Delete(Guid id)
        {
            Product product = await _productRepository.GetById(id);
            if (product == null) throw new ProductNotFoundException(id);
            await _productRepository.Delete(product);
        }

        public async Task<List<ReadProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return products.Select(product => new ReadProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Brand = product.Brand
            }).ToList();
        }

        public async Task<ReadProductDTO> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null) throw new ProductNotFoundException(id);
            return new ReadProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price,
                Brand = product.Brand
            };
        }

        public async Task Update(Guid id, ProductDTO productDTO)
        {
            await _productValidator.ValidateAndThrowAsync(productDTO);
            var product = await _productRepository.GetById(id);
            if (product == null) throw new ProductNotFoundException(id);

            product.Name = productDTO.Name;
            product.Quantity = productDTO.Quantity;
            product.Price = productDTO.Price;
            product.Brand = productDTO.Brand;

            await _productRepository.Update(product);
        }
    }
}
