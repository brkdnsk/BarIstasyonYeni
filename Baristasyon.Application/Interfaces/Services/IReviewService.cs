using Baristasyon.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Application.Interfaces.Services
{
    public interface IReviewService
    {
        Task<List<ResultReviewDto>> GetByRecipeIdAsync(int coffeeRecipeId);
        Task<bool> CreateAsync(CreateReviewDto dto);
    }
}
