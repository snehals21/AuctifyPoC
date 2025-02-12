using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext dbContext) : CategoryInterface
    {
        // This is the repository class where we have implemented the interface in this class.
        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            return await dbContext.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> CreateCategory(CategoryEntity category)
        {
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<CategoryEntity> UpdateCategory(int id, CategoryEntity category)
        {
            var categoryEntity = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            if (categoryEntity != null)
            {
                categoryEntity.Name = category.Name;
                await dbContext.SaveChangesAsync();
                return categoryEntity;
            }

            return category;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var categoryEntity = await dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
            Console.WriteLine("outer", id, categoryEntity);
            if (categoryEntity != null)
            {
                dbContext.Categories.Remove(categoryEntity);
                await dbContext.SaveChangesAsync();
                Console.WriteLine("Hello", categoryEntity);
                return true;
            }

            return false;
        }

    }
}
