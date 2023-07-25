using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task CreateAsync(Product entity)
        {
            await _productDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _productDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productDal.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _productDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Product entity, string id)
        {
            await _productDal.UpdateAsync(entity, id);
        }
    }
}
