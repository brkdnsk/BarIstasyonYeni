using Baristasyon.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface IJobPostService
    {
        Task<List<ResultJobPostDto>> GetAllAsync();
        Task<ResultJobPostDto?> GetByIdAsync(int id);
        Task<ResultJobPostDto> CreateAsync(CreateJobPostDto dto);
        Task<bool> UpdateAsync(int id, UpdateJobPostDto dto);
        Task<bool> DeleteAsync(int id);
        Task<List<ResultJobPostDto>> GetByLocationAsync(string location);
        Task<List<ResultJobPostDto>> SearchByCompanyAsync(string companyName);
        Task<List<ResultJobPostDto>> GetRecentPostsAsync(int count);

    }
}
