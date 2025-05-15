using Baristasyon.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface IFavoriteRecipeService
    {
        Task<List<ResultFavoriteRecipeDto>> GetAllAsync();
        Task<ResultFavoriteRecipeDto?> GetByIdAsync(int id);
        Task<ResultFavoriteRecipeDto> CreateAsync(CreateFavoriteRecipeDto dto);
        Task<bool> UpdateAsync(int id, UpdateFavoriteRecipeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
