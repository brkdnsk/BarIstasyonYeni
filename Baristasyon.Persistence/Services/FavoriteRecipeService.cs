using AutoMapper;
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
    public class FavoriteRecipeService : IFavoriteRecipeService
    {
        private readonly BaristasyonDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteRecipeService(BaristasyonDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultFavoriteRecipeDto>> GetAllAsync()
        {
            var entities = await _context.FavoriteRecipes.ToListAsync();
            return _mapper.Map<List<ResultFavoriteRecipeDto>>(entities);
        }

        public async Task<ResultFavoriteRecipeDto?> GetByIdAsync(int id)
        {
            var entity = await _context.FavoriteRecipes.FindAsync(id);
            return entity == null ? null : _mapper.Map<ResultFavoriteRecipeDto>(entity);
        }

        public async Task<ResultFavoriteRecipeDto> CreateAsync(CreateFavoriteRecipeDto dto)
        {
            var entity = _mapper.Map<FavoriteRecipe>(dto);
            _context.FavoriteRecipes.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ResultFavoriteRecipeDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateFavoriteRecipeDto dto)
        {
            var entity = await _context.FavoriteRecipes.FindAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.FavoriteRecipes.FindAsync(id);
            if (entity == null) return false;

            _context.FavoriteRecipes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ResultFavoriteRecipeDto>> GetByUserIdAsync(int userId)
        {
            var favorites = await _context.FavoriteRecipes
                .Where(f => f.UserId == userId)
                .ToListAsync();

            return _mapper.Map<List<ResultFavoriteRecipeDto>>(favorites);
        }
        public async Task<bool> IsFavoriteAsync(int userId, int recipeId)
        {
            return await _context.FavoriteRecipes
                .AnyAsync(f => f.UserId == userId && f.CoffeeRecipeId == recipeId);
        }
        public async Task<bool> ToggleFavoriteAsync(int userId, int recipeId)
        {
            var existing = await _context.FavoriteRecipes
                .FirstOrDefaultAsync(f => f.UserId == userId && f.CoffeeRecipeId == recipeId);

            if (existing != null)
            {
                _context.FavoriteRecipes.Remove(existing);
                await _context.SaveChangesAsync();
                return false; // çıkarıldı
            }

            var newFavorite = new FavoriteRecipe
            {
                UserId = userId,
                CoffeeRecipeId = recipeId,
                AddedAt = DateTime.UtcNow
            };

            _context.FavoriteRecipes.Add(newFavorite);
            await _context.SaveChangesAsync();
            return true; // eklendi
        }


    }
}
