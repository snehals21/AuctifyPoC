using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class CategoryService
    {
        private readonly CategoryInterface _repository;

        // This is the constructor of service class.
        public CategoryService(CategoryInterface repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await _repository.GetCategories();
        }

        public async Task<CategoryEntity> CreateCategory(CategoryEntity category)
        {
            return await _repository.CreateCategory(category);
        }

        public async Task<CategoryEntity> UpdateCategory(int id, CategoryEntity category)
        {
            return await _repository.UpdateCategory(id, category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _repository.DeleteCategory(id);
        }
    }
}
