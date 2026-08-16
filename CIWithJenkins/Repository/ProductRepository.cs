using CIWithJenkins.Context;
using CIWithJenkins.Entities;
using CIWithJenkins.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace CIWithJenkins.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(Product product)
        {
            await _storeContext.Products.AddAsync(product);
            await _storeContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _storeContext.Products.Remove(product);
            await _storeContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _storeContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _storeContext.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _storeContext.Products.Update(product);
            await _storeContext.SaveChangesAsync();
        }
    }
}
