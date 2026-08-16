using CIWithJenkins.DTOs.Products;

namespace CIWithJenkins.Interfaces.Services
{
    public interface IProductService
    {
        public Task<List<ReadProductDTO>> GetAll();
        public Task<ReadProductDTO> GetById(Guid id);
        public Task Update(Guid id, ProductDTO productDTO);
        public Task Delete(Guid id);
        public Task Create(ProductDTO productDTO);
    }
}
