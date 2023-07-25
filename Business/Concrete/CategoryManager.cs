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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task CreateAsync(Category entity)
        {
          await  _categoryDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _categoryDal.DeleteAsync(id);
        }

        public Task<IEnumerable<Category>> GetAl()
        {
            return _categoryDal.GetAl();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(string id)
        {
            return await _categoryDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Category entity, string id)
        {
            await _categoryDal.UpdateAsync(entity, id);
        }
    }
}
