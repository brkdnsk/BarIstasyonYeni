using Baristasyon.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ResultUserDto> RegisterAsync(RegisterUserDto dto);
        Task<ResultUserDto?> LoginAsync(LoginUserDto dto);
        Task<ResultUserDto?> GetByIdAsync(int id);
        Task<List<ResultUserDto>> GetAllAsync();
        Task<bool> UpdatePasswordAsync(UpdatePasswordDto dto);
        Task<bool> UpdateProfileAsync(UpdateUserProfileDto dto);
        Task<bool> CheckEmailExistsAsync(string email);

    }
}
