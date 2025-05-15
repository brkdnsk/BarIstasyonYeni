using Baristasyon.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface IEquipmentService
    {
        Task<List<ResultEquipmentDto>> GetAllAsync();
        Task<ResultEquipmentDto?> GetByIdAsync(int id);
        Task<ResultEquipmentDto> CreateAsync(CreateEquipmentDto dto);
        Task<bool> UpdateAsync(int id, UpdateEquipmentDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<ResultEquipmentDto>> GetByNameAsync(string name);

    }
}
