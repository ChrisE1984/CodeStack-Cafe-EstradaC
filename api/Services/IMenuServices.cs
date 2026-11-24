
using api.DTOs;

namespace api.Services
{
    public interface IMenuServices
    {
        Task <List<MenuResponseDTO>> GetAllAsync();
        Task <MenuResponseDTO?> GetByIDAsync (int id);
        Task <MenuResponseDTO> CreateAsync(CreateMenuDTO dto);
        Task  <MenuResponseDTO> UpdateAsync (int id, UpdateMenuDTO dto);
        Task<bool> DeleteAsync(int id);

    }
}