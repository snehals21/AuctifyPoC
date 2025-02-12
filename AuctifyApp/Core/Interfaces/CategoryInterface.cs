using Core.Entities;

namespace Core.Interfaces
{
    public interface CategoryInterface
    {
        // This is the interface class which contains the abstract methods. this class wll be implemented in the repository class.
        Task<IEnumerable<CategoryEntity>> GetCategories();
        Task<CategoryEntity> CreateCategory(CategoryEntity category);
        Task<CategoryEntity> UpdateCategory(int id, CategoryEntity category);
        Task<bool> DeleteCategory(int id);
    }
}
