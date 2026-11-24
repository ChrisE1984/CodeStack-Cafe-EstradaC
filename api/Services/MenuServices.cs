using api.DTOs;
using api.Models;
using api.Repository;

namespace api.Services
{
    public class MenuServices : IMenuServices
    {

        private readonly IMenuRepository _repository;

        public MenuServices(IMenuRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<MenuResponseDTO>> GetAllAsync()
        {
            List<Menu> menu = await _repository.GetAllAsync();
            return menu.Select(ToDto).ToList();
        }

        public async Task<MenuResponseDTO?> GetByIDAsync(int id)
        {
            Menu? menu = await _repository.GetByIdAsync(id);
            return menu is null ? null : ToDto(menu);
        }

        public async Task<MenuResponseDTO> CreateAsync(CreateMenuDTO dto)
        {
            Menu menu = new Menu
            {
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                Description = dto.Description,
                Tag = dto.Tag
            };

            Menu created = await _repository.AddAsync(menu);
            return ToDto(created);
        }

        public async Task<MenuResponseDTO> UpdateAsync(int id, UpdateMenuDTO dto)
        {
            Menu menu = new Menu
            {
                Id = id,
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price,
                Description = dto.Description,
                Tag = dto.Tag
            };

            await _repository.UpdateAsync(menu);
            return ToDto(menu);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Menu? menu = await _repository.GetByIdAsync(id);
            if(menu is null)
            {
                return false;
            }
            await _repository.DeleteAsync(menu);
            return true;
        }


        private static MenuResponseDTO ToDto(Menu menu)
        {
            return new MenuResponseDTO
            {
                Id= menu.Id,
                Name= menu.Name,
                Category= menu.Category,
                Price=menu.Price,
                Description = menu.Description,
                Tag = menu.Tag
            };
        }

    }


}