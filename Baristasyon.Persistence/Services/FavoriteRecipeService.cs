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
    }
}
