using api.DTOs;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository _repository;

        public CategoriesServices(ICategoriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
            List<Categories> categories = await _repository.GetAllAsync();
            return categories.Select(ToDto).ToList();
        }

        public async Task<CategoryResponse?> GetByIdAsync(int id)
        {
            Categories? category = await _repository.GetByIdAsync(id);
            return category is null ? null : ToDto(category);
        }

        public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request)
        {
            Categories category = new Categories
            {
                Name = request.Name
            };

            Categories created = await _repository.AddAsync(category);
            return ToDto(created);
        }

        public async Task<CategoryResponse?> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            Categories? category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return null;
            }

            category.Name = request.Name;
            await _repository.UpdateAsync(category);
            return ToDto(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Categories? category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return false;
            }

            await _repository.DeleteAsync(category);
            return true;
        }

        private static CategoryResponse ToDto(Categories category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
