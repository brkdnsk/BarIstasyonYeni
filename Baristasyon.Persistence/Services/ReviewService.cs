using Baristasyon.Application.Dtos;
using Baristasyon.Application.Interfaces.Services;
using Baristasyon.Domain.Entities;
using Baristasyon.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baristasyon.Persistence.Services
{
    public class ReviewService : IReviewService
    {
        private readonly BaristasyonDbContext _context;

        public ReviewService(BaristasyonDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResultReviewDto>> GetByRecipeIdAsync(int coffeeRecipeId)
        {
            var reviews = await _context.Reviews
                .Where(x => x.CoffeeRecipeId == coffeeRecipeId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            // Dummy username atanıyor. Gerçek sistemde UserService'den alınmalı.
            return reviews.Select(r => new ResultReviewDto
            {
                Id = r.Id,
                UserId = r.UserId,
                Username = $"Kullanıcı {r.UserId}",
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            }).ToList();
        }

        public async Task<bool> CreateAsync(CreateReviewDto dto)
        {
            var review = new Review
            {
                UserId = dto.UserId,
                CoffeeRecipeId = dto.CoffeeRecipeId,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
