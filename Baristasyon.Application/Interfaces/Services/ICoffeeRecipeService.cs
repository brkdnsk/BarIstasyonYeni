using Baristasyon.Application.Dtos;
using Baristasyon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface ICoffeeRecipeService
    {
        Task<List<ResultCoffeeRecipeDto>> GetAllAsync();
        Task<ResultCoffeeRecipeDto?> GetByIdAsync(int id);
        Task<ResultCoffeeRecipeDto> CreateAsync(CreateCoffeeRecipeDto dto);
        Task<bool> UpdateAsync(int id, UpdateCoffeeRecipeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

