using CIWithJenkins.Entities;

namespace CIWithJenkins.Interfaces.Repository
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> GetById(Guid id);
        public Task Delete(Product product);
        public Task Update(Product product);
        public Task Create(Product product);
    }
}
